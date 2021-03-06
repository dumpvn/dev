﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace ERPCore.Accounting.UserControl
{
    public partial class InventoryVoucherEdit : System.Web.UI.UserControl
    {
        private class datasample
        {
            public string Code { get; set; }            
            public string Name { get; set; }
            public string Unit { get; set; }
            public string Quantity { get; set; }
            public string Price { get; set; }
            public int Amount { get; set; }
            public int Credit { get; set; }
            public int Debit { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = new[] {  new{   c1 = "PXK001",c2 = "Xuất kho 1",c3 = "Bán",c4 = "Xuất kho 1",c5 = "25/06/2013",c6 = "100.000.000",c7 = "Đã duyệt"},
                                                new{   c1 = "PXK002",c2 = "Xuất kho 2",c3 = "Khuyến mãi",c4 = "Xuất kho 2",c5 = "27/06/2013",c6 = "5.000.000",c7 = "Đã duyệt"},
                                                new{   c1 = "PXK003",c2 = "Xuất kho 3",c3 = "Bán",c4 = "Xuất kho 1",c5 = "01/07/2013",c6 = "40.000.000",c7 = "Chưa duyệt"},
                                                new{   c1 = "PXK004",c2 = "Xuất kho 4",c3 = "Khuyến mãi",c4 = "Xuất kho 2",c5 = "03/07/2013",c6 = "10.000.000",c7 = "Chưa duyệt"},
                                                new{   c1 = "PXK005",c2 = "Xuất kho 5",c3 = "Bán",c4 = "Xuất kho 1",c5 = "25/067/2013",c6 = "300.000.000",c7 = "Chưa duyệt"}};
            ASPxGridView1.KeyFieldName = "c1";
            ASPxGridView1.DataBind();
        }

        protected void grdData_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {

        }

        protected void grdData_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {

        }

        protected void grdData_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

        }

        protected void grdData_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

        }
    }
}