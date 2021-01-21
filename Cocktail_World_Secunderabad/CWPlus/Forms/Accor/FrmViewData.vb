Imports CWPlusBL.Accor
Imports System.Text
Imports System.IO

Public Class FrmViewData
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjPriMainDt As DataTable
    Dim ObjPriChngDt As DataTable
    Dim StrChangedDiscount As String

    Dim remarkTable As New Hashtable

    Dim ObjPriOldDr, ObjPriNewDr As New List(Of DataRow)

    'Dim vCurRowIndex As Integer = 0

    Private Sub FrmViewData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each cell As DataGridViewColumn In grdSaleData.Columns
            cell.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        GblStrDiscountTypeIDVD = ""
        GblStrDiscountTypeDescVD = ""
        GblStrOldDiscountTypeOldVD = ""
        GblStrRemarkVD = ""

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

    Private Sub FetchMainData()
        Try
            ObjPriMainDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.BusinessDate = Format(DtBusinessDate.Value, "dd-MMM-yyyy")
            ObjPriMainDt = ObjCls.FunFetchSaleData
            ObjPriChngDt = ObjPriMainDt.Clone
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMore.Click
        Try
            If IsNothing(ObjPriMainDt) Then
                FetchMainData()
            End If
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

    Private Sub grdSaleData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSaleData.CellDoubleClick
       

        If e.RowIndex < 0 Then Exit Sub
        'vCurRowIndex = e.RowIndex

        If grdSaleData.Columns(e.ColumnIndex).Name = "Discount Type" Then
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Discount")
                Exit Sub
            End If
            If Not IsDBNull(grdSaleData(e.ColumnIndex, e.RowIndex).Value) Then
                GblStrOldDiscountTypeOldVD = grdSaleData("Discount Type", e.RowIndex).Value
                GblStrRemarkVD = IIf(IsDBNull(grdSaleData("remarks", e.RowIndex).Value), "", grdSaleData("remarks", e.RowIndex).Value) 'grdSaleData("Remarks", e.RowIndex).Value

                Dim frmForm2 As New FrmAssignDiscount
                frmForm2.StartPosition = FormStartPosition.CenterScreen
                frmForm2.ShowDialog()
                'frmForm2.Show()
            End If
        ElseIf grdSaleData.Columns(e.ColumnIndex).Name = "CheckNo" Then
            Dim StrParam As String = ""
            StrParam = grdSaleData("RevenueCenterId", e.RowIndex).Value & ",'" & Format(grdSaleData("BusinessDate", e.RowIndex).Value, "dd-MMM-yyyy") & "'," & grdSaleData("CheckId", e.RowIndex).Value & ",'" & grdSaleData("CheckNo", e.RowIndex).Value & "'"
            GenerateReport("checkview", "proc#" & "Spr_CheckView" & "#" & StrParam & "#100")
        End If
    End Sub

    Dim tmpRwIdx As Integer = -1

    Public Sub SubApplyChanges()

        For Each cell As DataGridViewCell In grdSaleData.SelectedCells
            Dim rwIndex As Integer = cell.RowIndex  'grdSaleData.SelectedCells(cnt).RowIndex

            If IsDBNull(grdSaleData("remarks", rwIndex).Value) Then
                GblStrOldDiscountTypeOldVD = grdSaleData("Discount Type", rwIndex).Value
            End If
            'GblStrRemarkVD = IIf(IsDBNull(grdSaleData("remarks", rwIndex).Value), "", grdSaleData("remarks", rwIndex).Value) 'grdSaleData("Remarks", e.RowIndex).Value

            For IntLocCnt As Integer = ObjPriOldDr.Count - 1 To 0 Step -1
                If ObjPriOldDr(IntLocCnt)("IDN") = grdSaleData("IDN", rwIndex).Value Then
                    ObjPriOldDr.RemoveAt(IntLocCnt)
                    ObjPriNewDr.RemoveAt(IntLocCnt)
                End If
            Next

            'Track Old Record
            ObjPriOldDr.Add(DirectCast(grdSaleData.Rows(rwIndex).DataBoundItem, DataRowView).Row)

            grdSaleData("Discount Type", rwIndex).Value = GblStrDiscountTypeDescVD
            grdSaleData("Discount Id", rwIndex).Value = GblStrDiscountTypeIDVD

            'Insert New Values to DR
            ObjPriNewDr.Add(DirectCast(grdSaleData.Rows(rwIndex).DataBoundItem, DataRowView).Row)

            BindChangedRows()

            '2 september
            'If IsDBNull(grdSaleData("remarks", vCurRowIndex).Value) Then
            '    grdSaleData("OldData", vCurRowIndex).Value = GblStrOldDiscountTypeOldVD
            'End If
            'grdSaleData("remarks", vCurRowIndex).Value = GblStrRemarkVD
            'grdSaleData("ChangedDate", vCurRowIndex).Value = Date.Now
            'grdSaleData("ChangedBy", vCurRowIndex).Value = gblUserName



            If IsDBNull(grdSaleData("remarks", rwIndex).Value) Then
                grdSaleData("OldData", rwIndex).Value = GblStrOldDiscountTypeOldVD
            End If

            grdSaleData("ChangedDate", rwIndex).Value = Date.Now
            grdSaleData("ChangedBy", rwIndex).Value = gblUserName
            grdSaleData("remarks", rwIndex).Value = GblStrRemarkVD

        Next
        GblStrOldDiscountTypeOldVD = ""
        GblStrRemarkVD = ""
        GblStrDiscountTypeDescVD = ""
        GblStrDiscountTypeIDVD = ""

        'For Each cell As DataGridViewColumn In grdSaleData.Columns
        '    cell.SortMode = DataGridViewColumnSortMode.Automatic
        'Next

        'grdSaleData.Sort(grdSaleData.Columns("IDN"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub BtnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SubApplyChanges()
    End Sub

    Private Sub BindChangedRows()
        ObjPriChngDt.Rows.Clear()
        For Each itm As DataRow In ObjPriNewDr
            ObjPriChngDt.Rows.Add(itm.ItemArray)
        Next
        grdNewData.DataSource = ObjPriChngDt

        grdNewData.Columns("RevenueCenterId").Visible = False
        grdNewData.Columns("PriceLevel").Visible = False
        grdNewData.Columns("M_item_weight").Visible = False
        grdNewData.Columns("EmpNo").Visible = False
        grdNewData.Columns("EmpCheckName").Visible = False
        grdNewData.Columns("EmpFirstName").Visible = False
        grdNewData.Columns("Quantity1").Visible = False
        grdNewData.Columns("Rate1").Visible = False
        grdNewData.Columns("M_ob_dtl04_rtn").Visible = False
        grdNewData.Columns("MIDEF_cond_grp_mem_seq").Visible = False
        grdNewData.Columns("MenuItemGrpId").Visible = False
        grdNewData.Columns("MenuItemGrpName").Visible = False
        grdNewData.Columns("MajorGroupId").Visible = False
        grdNewData.Columns("MajorGroupName").Visible = False
        grdNewData.Columns("FamilyGroupId").Visible = False
        grdNewData.Columns("FamilyGroupName").Visible = False
        grdNewData.Columns("CheckNo").Frozen = True
    End Sub

#Region "sachin"

    Private Sub UpdateData()
        For index = 0 To ObjPriNewDr.Count - 1
            Dim dr() As DataRow = ObjPriMainDt.Select("IDN=" & ObjPriNewDr(index)("IDN"))
            For colsctr = 0 To ObjPriMainDt.Columns.Count - 1
                dr(0)(colsctr) = ObjPriNewDr(index)(colsctr)
            Next
        Next
        ObjPriMainDt.Columns.Remove("IDN")
        ObjCls = New ClsReports
        ObjCls.OperationName = "EvalSale"
        Dim dt As DataTable = ObjCls.FunFetchBulkInsertfilePath
        If dt.Rows.Count > 0 Then
            GenerateInterface(dt.Rows(0)("ServerPath"), dt.Rows(0)("FilePrefix") & Format(DtBusinessDate.Value, "yyyyMMdd"))
        Else
            MsgBox("File path not found", MsgBoxStyle.Information, "CWPlus")
        End If

    End Sub
    Public Sub GenerateInterface(ByVal filePath As String, ByVal filename As String)
        Try
            Dim strContent As String = DatatableToText(ObjPriMainDt)
            File.WriteAllText(Path.Combine(filePath, filename) & ".intf", strContent)
            MsgBox("Interface file generated successfully !", MsgBoxStyle.Information, "Success")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function DatatableToText(ByVal dt As DataTable) As String

        Dim strBuilder As New StringBuilder
        For Each rw As DataRow In dt.Rows
            Dim idx As Integer = 0
            For idx = 0 To rw.ItemArray.Length - 2
                strBuilder.Append(rw.ItemArray(idx) & "$#$")
                'File.AppendAllText(fileName, )
            Next
            strBuilder.Append(rw.ItemArray(idx) & vbCrLf)
        Next
        Return strBuilder.ToString
    End Function

#End Region

    Private Sub imgSave_Click(sender As System.Object, e As System.EventArgs) Handles imgSave.Click
        If ObjPriOldDr.Count > 0 Then
            UpdateData()
        Else
            MsgBox("Modified data not found")
        End If

        GblStrDiscountTypeIDVD = ""
        GblStrDiscountTypeDescVD = ""
        GblStrOldDiscountTypeOldVD = ""
        GblStrRemarkVD = ""

        Me.Close()
    End Sub

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim BoolValidDiscount = True


        For Each cell As DataGridViewCell In grdSaleData.SelectedCells
            Dim rwIndex As Integer = cell.RowIndex

            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Discount")
                Exit Sub
            End If
            If IsDBNull(grdSaleData("Discount Type", rwIndex).Value) Then
                BoolValidDiscount = False
                MsgBox("Empty discount field selected", MsgBoxStyle.Information, "Discount")
                Exit Sub
            End If
        Next


        'For Each cell As DataGridViewColumn In grdSaleData.Columns
        '    cell.SortMode = DataGridViewColumnSortMode.NotSortable
        'Next
        Dim frmForm2 As New FrmAssignDiscount
        frmForm2.StartPosition = FormStartPosition.CenterScreen
        frmForm2.ShowDialog()
    End Sub
End Class