Imports CWPlusBL.Accor
Imports System.Text
Imports System.IO

Public Class FrmViewDatav2

    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable

    Private Sub FrmViewDatav2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        BindRevenueCenters()
    End Sub

    Private Sub BindRevenueCenters()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjPriDt = ObjCls.FunFetchRevenueCenters()
            ComboBindingTemplate(drpRevenueCenter, ObjPriDt, "revenuecentername", "revenuecenterid")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Public Sub BindData()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.BusinessDate = Format(DtBusinessDate.Value, "dd-MMM-yyyy")
            ObjCls.RevenueCenterId = drpRevenueCenter.SelectedValue
            ObjCls.OfficerBillNo = txtCheckNo.Text
            ObjPriDt = ObjCls.FunFetchSaleData
            grdSaleData.DataSource = ObjPriDt

            grdSaleData.Columns("RevenueCenterId").Visible = False
            grdSaleData.Columns("PriceLevel").Visible = False
            grdSaleData.Columns("M_item_weight").Visible = False
            grdSaleData.Columns("EmpNo").Visible = False
            grdSaleData.Columns("EmpCheckName").Visible = False
            grdSaleData.Columns("EmpFirstName").Visible = False
            grdSaleData.Columns("Quantity1").Visible = False
            grdSaleData.Columns("Rate1").Visible = False
            grdSaleData.Columns("M_ob_dtl04_rtn").Visible = False
            grdSaleData.Columns("MIDEF_cond_grp_mem_seq").Visible = False
            grdSaleData.Columns("MenuItemGrpId").Visible = False
            grdSaleData.Columns("MenuItemGrpName").Visible = False
            grdSaleData.Columns("MajorGroupId").Visible = False
            grdSaleData.Columns("MajorGroupName").Visible = False
            grdSaleData.Columns("FamilyGroupId").Visible = False
            grdSaleData.Columns("FamilyGroupName").Visible = False

            grdSaleData.Columns("CheckNo").Frozen = True
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnMore_Click(sender As System.Object, e As System.EventArgs) Handles btnMore.Click
        BindData()
    End Sub

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub grdSaleData_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSaleData.CellDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If grdSaleData.Columns(e.ColumnIndex).Name = "Discount Type" Then
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Discount")
                Exit Sub
            End If

            'If Not IsDBNull(grdSaleData(e.ColumnIndex, e.RowIndex).Value) Then
            If IsDBNull(grdSaleData("OldData", e.RowIndex).Value) Then
                GblStrOldDiscountTypeOldVD = IIf(IsDBNull(grdSaleData("Discount Type", e.RowIndex).Value), "", grdSaleData("Discount Type", e.RowIndex).Value)
                'grdSaleData("Discount Type", e.RowIndex).Value
            Else
                GblStrOldDiscountTypeOldVD = IIf(IsDBNull(grdSaleData("OldData", e.RowIndex).Value), "", grdSaleData("OldData", e.RowIndex).Value)
                'grdSaleData("OldData", e.RowIndex).Value
            End If
            GblStrRemarkVD = IIf(IsDBNull(grdSaleData("remarks", e.RowIndex).Value), "", grdSaleData("remarks", e.RowIndex).Value)
            GblDtBusinessDate = grdSaleData("BusinessDate", e.RowIndex).Value
            GBLDblRevenueCenterId = grdSaleData("RevenueCenterId", e.RowIndex).Value
            GblStrRevenueCenterName = grdSaleData("RevenueCenterName", e.RowIndex).Value
            GblDblCheckId = grdSaleData("CheckId", e.RowIndex).Value
            GblStrBillNo = grdSaleData("CheckNo", e.RowIndex).Value
            GblStrBillUniqueId = grdSaleData("D_dtl_seq", e.RowIndex).Value & grdSaleData("DtlId", e.RowIndex).Value

            Dim frmForm2 As New FrmAssignDiscountv2
            frmForm2.StartPosition = FormStartPosition.CenterScreen
            frmForm2.ShowDialog()

            'End If
        ElseIf grdSaleData.Columns(e.ColumnIndex).Name = "CheckNo" Then
        Dim StrParam As String = ""
        StrParam = grdSaleData("RevenueCenterId", e.RowIndex).Value & ",'" & Format(grdSaleData("BusinessDate", e.RowIndex).Value, "dd-MMM-yyyy") & "'," & grdSaleData("CheckId", e.RowIndex).Value & ",'" & grdSaleData("CheckNo", e.RowIndex).Value & "'"
        GenerateReport("checkview", "proc#" & "Spr_CheckView" & "#" & StrParam & "#100")
        ElseIf grdSaleData.Columns(e.ColumnIndex).Name = "Reference" Then
        If grdSaleData("IsMembership", e.RowIndex).Value Then
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Discount")
                Exit Sub
            End If

            GblStrDiscountType = grdSaleData("Discount Type", e.RowIndex).Value
            GblDtBusinessDate = grdSaleData("BusinessDate", e.RowIndex).Value
            GBLDblRevenueCenterId = grdSaleData("RevenueCenterId", e.RowIndex).Value
            GblStrRevenueCenterName = grdSaleData("RevenueCenterName", e.RowIndex).Value
            GblDblCheckId = grdSaleData("CheckId", e.RowIndex).Value
            GblStrBillNo = grdSaleData("CheckNo", e.RowIndex).Value
            GblStrBillUniqueId = grdSaleData("D_dtl_seq", e.RowIndex).Value & grdSaleData("DtlId", e.RowIndex).Value

            Dim frmForm2 As New FrmAssignCardNo
            frmForm2.StartPosition = FormStartPosition.CenterScreen
            frmForm2.ShowDialog()
        End If
        End If
    End Sub

End Class