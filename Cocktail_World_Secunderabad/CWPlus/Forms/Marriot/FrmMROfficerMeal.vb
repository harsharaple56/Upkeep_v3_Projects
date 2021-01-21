Imports CWPlusBL.Marriot
Imports System.Data

Public Class FrmOfficerMealMR

    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice

    Public Sub BindCheckData()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjExp = New ClsMsOffice
            ObjCls.Fromdate = Format(DtFromdate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
            ObjCls.RevenueCenterId = drpRevenueCenter.SelectedValue
            ObjCls.OfficerBillNo = txtCheckNo.Text
            ObjPriDt = ObjCls.FunFetchCheckForAnG()

            grdDCCReport.Rows.Clear()
            If ObjPriDt.Rows.Count > 0 Then
                For index = 0 To ObjPriDt.Rows.Count - 1
                    grdDCCReport.Rows.Add()
                    grdDCCReport.Item("businessdate", index).Value = ObjPriDt.Rows(index)("businessdate")
                    grdDCCReport.Item("RevenueCenterId", index).Value = ObjPriDt.Rows(index)("RevenueCenterId")
                    grdDCCReport.Item("RevenueCenterName", index).Value = ObjPriDt.Rows(index)("RevenueCenterName")
                    grdDCCReport.Item("CheckId", index).Value = ObjPriDt.Rows(index)("CheckId")
                    grdDCCReport.Item("BillNo", index).Value = ObjPriDt.Rows(index)("BillNo")
                    grdDCCReport.Item("Discount", index).Value = ObjPriDt.Rows(index)("Discount")
                    grdDCCReport.Item("Type", index).Value = ObjPriDt.Rows(index)("Type")
                    grdDCCReport.Item("Amount", index).Value = ObjPriDt.Rows(index)("Amount")
                    grdDCCReport.Item("DiscountType", index).Value = ObjPriDt.Rows(index)("DiscountType")
                    grdDCCReport.Item("AnGFields", index).Value = ObjPriDt.Rows(index)("AnGFields")
                    grdDCCReport.Item("AnGFieldInfo", index).Value = ObjPriDt.Rows(index)("AnGFieldInfo")
                    grdDCCReport.Item("AngHeadId", index).Value = ObjPriDt.Rows(index)("AngHeadId")
                    grdDCCReport.Item("Reference", index).Value = ObjPriDt.Rows(index)("Reference")
                Next

            End If




            grdDCCReport.Columns("DiscountType").Visible = False
            grdDCCReport.Columns("revenuecenterid").Visible = False
            grdDCCReport.Columns("checkid").Visible = False
            grdDCCReport.Columns("angheadid").Visible = False
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        BindCheckData()
    End Sub

    Private Sub grdDCCReport_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDCCReport.CellContentClick
        If grdDCCReport.Columns(e.ColumnIndex).Name = "sel" Then
            If CBool(grdDCCReport.Item("Sel", e.RowIndex).Value) Then
                grdDCCReport.Item("Sel", e.RowIndex).Value = False
            Else
                grdDCCReport.Item("Sel", e.RowIndex).Value = True
            End If
        End If
    End Sub

    Private Sub grdDCCReport_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDCCReport.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        'If grdDCCReport.Columns(e.ColumnIndex).Name = "sel" Then
        If Not CBool(grdDCCReport.Item("Sel", e.RowIndex).Value) Then
            grdDCCReport.Item("Sel", e.RowIndex).Value = True
        End If
        'Exit Sub
        'End If

        If grdDCCReport.Columns(e.ColumnIndex).Name = "BillNo" Then
            Dim StrParam As String = ""
            StrParam = grdDCCReport("RevenueCenterId", e.RowIndex).Value & ",'" & Format(grdDCCReport("businessdate", e.RowIndex).Value, "dd-MMM-yyyy") & "'," & grdDCCReport("CheckId", e.RowIndex).Value & ",'" & grdDCCReport("BillNo", e.RowIndex).Value & "'"
            GenerateReport("checkview", "proc#" & "Spr_CheckMRView" & "#" & StrParam & "#100")
            Exit Sub
        End If




        'commendted by sachin for multiple saving
        'GblDblCheckId = grdDCCReport("CheckId", e.RowIndex).Value()
        'GBLDblRevenueCenterId = grdDCCReport("RevenueCenterId", e.RowIndex).Value()
        'GblStrRevenueCenterName = grdDCCReport("RevenueCenterName", e.RowIndex).Value()
        'GblStrBillNo = grdDCCReport("BillNo", e.RowIndex).Value()

        ''''GblStrDiscount = grdDCCReport("Discount", e.RowIndex).Value()
        ''''GblDblAmount = grdDCCReport("Amount", e.RowIndex).Value()

        'GblStrDiscountType = grdDCCReport("DiscountType", e.RowIndex).Value()
        'GblDtBusinessDate = grdDCCReport("businessdate", e.RowIndex).Value()
        'GblDblAngHeadId = grdDCCReport("AngHeadId", e.RowIndex).Value()

        Dim frmForm2 As New FrmAssignOfficerMR
        frmForm2.StartPosition = FormStartPosition.CenterScreen
        frmForm2.Show()
    End Sub

    Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click
        Dim CostPerc As Double
        CostPerc = IIf(Trim(txtCostPerc.Text) = "", 0, txtCostPerc.Text)
        Dim StrParam As String = ""
        StrParam = "'" & Format(DtFromdate.Value, "dd-MMM-yyyy") & "','" & Format(DtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "',''"
        GenerateReport("nonpromtional-A", "proc#" & "Spr_FetchMRNonPromotionalMealv2" & "#" & StrParam)
    End Sub

    Private Sub FrmOfficerMeal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub BtnSummary_Click(sender As System.Object, e As System.EventArgs) Handles BtnSummary.Click
        ''Dim StrParam As String = ""
        ''Dim booldept As Int16 = 0
        ''If chkDepartment.Checked Then
        ''    booldept = 1
        ''End If
        ''StrParam = "'" & Format(DtFromdate.Value, "dd-MMM-yyyy") & "','" & Format(DtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "'," & booldept & ",''"
        ''GenerateReport("nonpromtionalsummary", "proc#" & "Spr_FetchNonPromotionalMealSummaryForMR" & "#" & StrParam)

        ''for Novotel Juhu


        ObjExp = New ClsMsOffice
        Dim ObjPriDs As DataSet
        ObjCls = New ClsReports
        ObjCls.Fromdate = Format(DtFromdate.Value, "dd-MMM-yyyy")
        ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
        If chkDepartment.Checked Then
            ObjCls.IsDept = 1
        End If

        ObjPriDs = ObjCls.FunFetchNonPromotionalMealSummary()
        ObjExp.ExportToExcelHeaderFooter(IO.Path.GetTempPath, "temp.xls", " # ", ObjPriDs.Tables(0))
        Process.Start(IO.Path.GetTempPath & "\temp.xls")
    End Sub
End Class