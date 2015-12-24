using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelCompare
{
    using Common.Excel;
    using System.Diagnostics;
    using System.IO;
    using Util;
    using Util.Config;

    public partial class Main : Form
    {
        //加载的Excel文档对象集合
        private Dictionary<String, MoqikakaExcel> mExcelsA = new Dictionary<String, MoqikakaExcel>();
        private Dictionary<String, MoqikakaExcel> mExcelsB = new Dictionary<String, MoqikakaExcel>();

        public Main()
        {
            InitializeComponent();

            InitControls();

            this.SizeChanged += (s, e) =>
            {
                tabControlA.Height = treeViewExcels.Height / 2;
                tabControlB.Height = treeViewExcels.Height / 2;
            };
        }

        #region 控件事件

        private void txtPathA_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            txtPathA.Text = dialog.SelectedPath;

            SavePath();
        }

        private void txtPath2_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            txtPathB.Text = dialog.SelectedPath;

            SavePath();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtPathA.Text) || !Directory.Exists(txtPathB.Text))
            {
                MessageBox.Show("请先设置正确的对比路径");
                return;
            }

            List<String> excelFilesA = Directory.GetFiles(txtPathA.Text, "*.xlsx").ToList();
            List<String> excelFilesB = Directory.GetFiles(txtPathB.Text, "*.xlsx").ToList();

            var compareFiles = GetCompareExcels(txtPathA.Text);
            if (compareFiles.Count <= 0) return;

            treeViewExcels.Nodes.Clear();
            tabControlA.TabPages[0].Controls.Clear();
            tabControlB.TabPages[0].Controls.Clear();

            Boolean firstNode = true;
            foreach (var file in compareFiles)
            {
                //路径B对应的该文件路径
                String pathB = Path.Combine(txtPathB.Text, Path.GetFileName(file));
                if (!File.Exists(pathB))
                {
                    MessageBox.Show(String.Format("路径B中不存在对应的[{0}]文档", Path.GetFileName(file)));
                    continue;
                }

                MoqikakaExcel excelA = new MoqikakaExcel(file);
                MoqikakaExcel excelB = new MoqikakaExcel(pathB);

                //异步加载Excel对象
                var task = Task.Run(() =>
                {
                    excelA.TryLoad();
                    excelB.TryLoad();

                    //加入到缓存
                    mExcelsA[excelA.Path] = excelA;
                    mExcelsB[excelB.Path] = excelB;

                    InvokeMainActon(() =>
                    {
                        //绑定TreeView
                        TreeNode listViewItem = new TreeNode(excelA.FileName, GetSheetNodesByExcelFile(excelA, excelB))
                        {
                            Checked = true,
                            ToolTipText = "查看整个Excel表单",
                        };

                        if (firstNode)
                        {
                            listViewItem.ExpandAll();
                            firstNode = false;
                        }

                        treeViewExcels.Nodes.Add(listViewItem);
                    });
                });

            }

            //保存路径
            SavePath();
        }

        private void linkOpenPathAClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenDirectory(this.txtPathA.Text.Trim());
        }

        private void linkOpenPathBClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenDirectory(this.txtPathB.Text.Trim());
        }

        private void treeViewExcels_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level != 1) return;

            var filePathA = mExcelsA.Keys.FirstOrDefault(p => p.EndsWith(e.Node.Parent.Text));
            var filePathB = mExcelsB.Keys.FirstOrDefault(p => p.EndsWith(e.Node.Parent.Text));

            DataGridView dgA = null;
            DataGridView dgB = null;

            if (filePathA != null)
            {
                var excelA = mExcelsA[filePathA];

                dgA = CreatSingleGridview(excelA.Data.Tables[e.Node.Text]);

                dgA.Scroll += (s, a) =>
                {
                    if (dgB != null)
                    {
                        Int32 showRowIndexB = dgA.FirstDisplayedScrollingRowIndex;
                        if (showRowIndexB > dgB.Rows.Count - 1) showRowIndexB = dgB.Rows.Count - 1;
                        if (showRowIndexB < 0) showRowIndexB = 0;

                        dgB.FirstDisplayedScrollingRowIndex = showRowIndexB;
                        dgB.HorizontalScrollingOffset = dgA.HorizontalScrollingOffset;
                    }
                };

                AddControl(tabPageA, dgA);
            }

            if (filePathB != null)
            {
                var excelB = mExcelsB[filePathB];

                dgB = CreatSingleGridview(excelB.Data.Tables[e.Node.Text]);

                AddControl(tabPageB, dgB);
            }

            tabPageA.Focus();

            Comparer(dgA, dgB);
        }

        private void btnPreDiff_Click(object sender, EventArgs e)
        {
            if (tabControlA.TabPages[0].Controls.Count == 0) return;
            if (tabControlB.TabPages[0].Controls.Count == 0) return;

            var dgA = tabControlA.TabPages[0].Controls[0] as DataGridView;
            var dgB = tabControlB.TabPages[0].Controls[0] as DataGridView;

            Int32 currIndex = dgA.CurrentCell.RowIndex - 1;
            if (currIndex < 0) return;

            for (int i = currIndex; i >= 0; i--)
            {
                foreach (DataGridViewCell item in dgA.Rows[i].Cells)
                {
                    if (item.Style.BackColor == Color.Red)
                    {
                        dgA.FirstDisplayedScrollingRowIndex = i;
                        dgA.CurrentCell = item;

                        if (dgB.Rows.Count > item.RowIndex && dgB.ColumnCount > item.ColumnIndex)
                        {
                            dgB.CurrentCell = dgB.Rows[i].Cells[item.ColumnIndex];
                        }

                        //item.OwningRow.Selected = true;
                        return;
                    }
                }
            }
        }

        private void btnNextDiff_Click(object sender, EventArgs e)
        {
            if (tabControlA.TabPages[0].Controls.Count == 0) return;
            if (tabControlB.TabPages[0].Controls.Count == 0) return;

            var dgA = tabControlA.TabPages[0].Controls[0] as DataGridView;
            var dgB = tabControlB.TabPages[0].Controls[0] as DataGridView;

            Int32 currIndex = dgA.CurrentCell.RowIndex + 1;
            if (currIndex > dgA.Rows.Count - 1) return;

            for (int i = currIndex; i < dgA.Rows.Count; i++)
            {
                foreach (DataGridViewCell item in dgA.Rows[i].Cells)
                {
                    if (item.Style.BackColor == Color.Red)
                    {
                        dgA.FirstDisplayedScrollingRowIndex = i;
                        dgA.CurrentCell = item;

                        if (dgB.Rows.Count > item.RowIndex && dgB.ColumnCount > item.ColumnIndex)
                        {
                            dgB.CurrentCell = dgB.Rows[i].Cells[item.ColumnIndex];
                        }

                        //item.Style.BackColor = Color.Gray;
                        //item.OwningRow.Selected = true;
                        return;
                    }
                }
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N)
            {
                btnNextDiff_Click(null, null);
                return;
            }
            if (e.KeyCode == Keys.P)
            {
                btnPreDiff_Click(null, null);
                return;
            }
        }

        #endregion

        #region 内部调用方法

        private void InitControls()
        {
            txtPathA.Text = ConfigUtil.GetAppSetting("PathA");
            txtPathB.Text = ConfigUtil.GetAppSetting("PathB");
        }

        private void OpenDirectory(String path)
        {
            if (Directory.Exists(path))
            {
                Process.Start(path);
            }
        }

        private void SavePath()
        {
            ConfigUtil.UpdateAppSetting("PathA", txtPathA.Text);
            ConfigUtil.UpdateAppSetting("PathB", txtPathB.Text);
        }

        private TreeNode[] GetSheetNodesByExcelFile(MoqikakaExcel excelA, MoqikakaExcel excelB)
        {
            //存放表单节点的数组
            List<TreeNode> nodeList = new List<TreeNode>();

            //添加A中的所有节点
            for (Int32 i = 0; i < excelA.Data.Tables.Count; i++)
            {
                var table = excelA.Data.Tables[i];
                if (table == null) continue;

                Boolean existInExcelB = excelB.Data.Tables.Contains(table.TableName);

                TreeNode node = new TreeNode(table.TableName)
                {
                    ToolTipText = existInExcelB ? "右键复制" : "该表不存在于PathB的文档中",
                    ForeColor = existInExcelB ? Color.Black : Color.Gray
                };

                //添加到对应节点
                nodeList.Add(node);
            }

            //添加B中存在, A中不存在的节点
            for (Int32 i = 0; i < excelB.Data.Tables.Count; i++)
            {
                var table = excelB.Data.Tables[i];
                if (table == null) continue;

                Boolean existInExcelA = excelA.Data.Tables.Contains(table.TableName);

                if (!existInExcelA)
                {
                    TreeNode node = new TreeNode(table.TableName)
                    {
                        ToolTipText = "该表不存在于PathA的文档中",
                        ForeColor = Color.Gray
                    };

                    //添加到对应节点
                    nodeList.Add(node);
                }
            }

            return nodeList.ToArray();
        }

        private void InvokeMainActon(Action action)
        {
            this.Invoke(action);
        }

        private List<String> GetCompareExcels(String baseDirectory)
        {
            List<String> fileList = new List<String>();

            //构造弹出对话框
            OpenFileDialog diog = new OpenFileDialog
            {
                Filter = "需要对比的Excel文档|*.xls;*.xlsx;*.xlsm",
                Multiselect = true,
                InitialDirectory = baseDirectory
            };

            //未选择直接返回
            if (diog.ShowDialog() != DialogResult.OK || diog.FileNames.Length == 0)
                return fileList;

            return diog.FileNames.ToList();
        }

        private void Comparer(DataGridView dgA, DataGridView dgB)
        {
            if (dgA == null || dgB == null) return;

            for (int i = 0; i < dgA.Rows.Count; i++)
            {
                ComparerRow(dgA, dgB, i);
            }
        }

        private void AddControl(TabPage tabPage, Control control)
        {
            tabPage.Controls.Clear();

            tabPage.Controls.Add(control);
        }

        private DataGridView CreatSingleGridview(DataTable dt)
        {
            //创建新的DataGridView,并设置其样式和绑定数据源
            DataGridView dgv = new DataGridView();
            dgv.BackgroundColor = Color.White;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            //dgv.DefaultCellStyle.SelectionBackColor = Color.White;
            //dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowHeadersWidth = 25;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.Dock = DockStyle.Fill;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.KeyDown += Main_KeyDown;
            dgv.DataSource = dt;

            return dgv;
        }

        private void ComparerRow(DataGridView dgA, DataGridView dgB, Int32 rowIndex)
        {
            if (rowIndex > dgB.Rows.Count - 1)
            {
                foreach (DataGridViewCell cell in dgA.Rows[rowIndex].Cells)
                {
                    cell.Style.BackColor = Color.Red;
                }

                return;
            }

            var rowA = dgA.Rows[rowIndex];
            var rowB = dgB.Rows[rowIndex];

            for (int i = 0; i < rowA.Cells.Count; i++)
            {
                if (i > rowB.Cells.Count - 1)
                {
                    rowA.Cells[i].Style.BackColor = Color.Red;
                    continue;
                }

                if (!IsStringEqual(rowA.Cells[i].Value, rowB.Cells[i].Value))
                {
                    rowA.Cells[i].Style.BackColor = Color.Red;
                }
            }
        }

        private Boolean IsStringEqual(Object objA, Object objB)
        {
            if (objA == null) return objB == null;
            if (objB == null) return objA == null;

            return objA.ToString() == objB.ToString();
        }

        #endregion
    }
}
