// ****************************************
// FileName:MoqikakaExcel.cs
// Description:摩奇卡卡Excel文档操作类
// Tables:None
// Author:Gavin
// Create Date:2014-06-01
// Revision History:
// ****************************************

using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Common.Excel
{
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;

    /// <summary>
    /// 摩奇卡卡Excel文档操作类
    /// </summary>
    public class MoqikakaExcel : ExcelBase
    {
        #region 属性

        /// <summary>
        /// Excel文档更改日志
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// 数值字段类型集合
        /// </summary>
        public List<String> NumericList = new List<String> { 
            "int", "double", "tinyint","int32", "int64", "byte", "bit","ubyte","short", "long", "float", "numeric" };

        /// <summary>
        /// 表数据
        /// </summary>
        public DataSet Data { get; set; }

        #endregion

        #region 初始化

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path">Excel文档路径</param>
        public MoqikakaExcel(String path)
            : base(path)
        {
            ModifyDate = File.GetLastWriteTime(path);
        }

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static MoqikakaExcel()
        {
            //设置读取表单的参考行/列序号
            ExcelHelper.SetReferIndex(1, 0);
        }

        #endregion

        #region 读取

        /// <summary>
        /// 尝试加载excel对象
        /// </summary>
        public void TryLoad()
        {
            try
            {
                this.Workbook = ExcelHelper.Load(Path);
                Data = ReadDataSet();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 读取为DataSet
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet ReadDataSet()
        {
            DataSet dataSet = new DataSet();

            for (int i = 0; i < Workbook.NumberOfSheets; i++)
            {
                //读取表单数据
                DataTable table = ReadAt(i);

                if (table != null) dataSet.Tables.Add(table);
            }

            return dataSet;
        }

        /// <summary>
        /// 读取表单数据
        /// </summary>
        /// <param name="sheetIndex">表单Index</param>
        /// <returns>表单数据</returns>
        public override DataTable ReadAt(Int32 sheetIndex)
        {
            //正常读取表单数据
            DataTable table = base.TryReadAt(sheetIndex);

            return HandleTable(table);
        }

        /// <summary>
        /// 处理表单数据格式
        /// </summary>
        /// <param name="table">数据源</param>
        /// <returns>处理后的数据</returns>
        private DataTable HandleTable(DataTable table)
        {
            if (table == null) return null;

            DataRow row0 = table.Rows[0];

            for (int i = 0; i < row0.ItemArray.Length; i++)
            {
                table.Columns[i].ColumnName = row0[i].ToString();
            }

            table.Rows.RemoveAt(0);

            return table;
        }

        #endregion

        #region 写入

        #endregion
    }
}