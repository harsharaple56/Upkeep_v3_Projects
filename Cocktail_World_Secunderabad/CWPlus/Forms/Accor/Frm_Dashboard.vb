Imports CWPlusBL.Accor
Imports System.Data

Public Class Frm_Dashboard

    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable

    Private Sub Frm_Dashboard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindReportNames()
    End Sub

    Private Sub BindReportNames()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjPriDt = ObjCls.FunFetchEvalPackDashboardReports()
            ComboBindingTemplate(drpReport, ObjPriDt, "ReportName", "ProcNo")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        BindReport()
       
    End Sub

    Private Sub BindReport()
        Try
            If drpReport.Text = "--Select--" Then
                MsgBox("Please select report name")
                Exit Sub
            End If
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Fromdate = Format(DtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
            ObjCls.UserName = gblUserName
            ObjPriDt = ObjCls.FetchEvalPackFetchDashboard(drpReport.SelectedValue)
            If ObjPriDt.Rows.Count > 0 Then
                BtnPlotChart.Visible = True
            End If
            grdReport.DataSource = ObjPriDt
            'gblDtDashboard = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

   
    Private Sub BtnPlotChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPlotChart.Click
        Me.Hide()

    End Sub
End Class