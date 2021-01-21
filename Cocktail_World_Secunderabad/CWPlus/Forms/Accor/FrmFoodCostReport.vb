Imports CWPlusBL.Accor
Imports System.Data

Public Class FrmFoodCostReport
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Try
            If drpCostCenter.Text = "--Select--" Then
                MsgBox("Please select Costcenter")
                Exit Sub
            End If
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Fromdate = Format(dtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(dtToDate.Value, "dd-MMM-yyyy")
            ObjPriDt = ObjCls.FunFetchFoodCostReport(drpCostCenter.Text)
            grdDCCReport.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click
        If drpCostCenter.Text = "--Select--" Then
            MsgBox("Please select Costcenter")
            Exit Sub
        End If
        Dim cost As Double
        cost = IIf(Trim(txtExtraCost.Text) = "", 0, Trim(txtExtraCost.Text))
        Dim StrParam As String = ""
        'StrParam = "'" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtToDate.Value, "dd-MMM-yyyy") & "','" & drpCostCenter.Text & "'," & cost
        StrParam = "'" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtToDate.Value, "dd-MMM-yyyy") & "','" & drpCostCenter.Text & "'"
        'GenerateReport("confoodcost", "proc#" & "Spr_FetchCONSOLIDATEDFOODCOSTREPORT" & "#" & StrParam)
        'GenerateReport("confoodcostv2", "proc#" & "Spr_FetchCONSOLIDATEDFOODCOSTREPORT" & "#" & StrParam & "#30")
        GenerateReport("FoodCostv2", "proc#" & "Spr_FetchFoodCostReport" & "#" & StrParam & "#100")
    End Sub

    Private Sub FrmFoodCostReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FetchCostCenters()
    End Sub

    Private Sub FetchCostCenters()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjPriDt = ObjCls.FunFetchMCRevenueCenter
            ComboBindingTemplate(drpCostCenter, ObjPriDt, "RevenueCenterName", "Id")
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
End Class