Imports CWPlusBL.Marriot
Imports System.Data
Imports CWPlusBL.Master
Public Class Frm_MR_VoidDiscSummary
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice
    Dim StrPriHeaderFooter As String = ""
    Dim ObjClsVoid As ClsVoid

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjExp = New ClsMsOffice
            ObjCls.Fromdate = Format(dtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(dtToDate.Value, "dd-MMM-yyyy")
            ObjPriDt = ObjCls.FunFetchMRVoidDiscountSummary()
            StrPriHeaderFooter = ObjCls.ErrorMsg
            grdDCCReport.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            ObjPriDt = DirectCast(grdDCCReport.DataSource, DataTable)
            ObjExp.ExportToExcelHeaderFooter(IO.Path.GetTempPath, "temp.xls", StrPriHeaderFooter, ObjPriDt)
            Process.Start(IO.Path.GetTempPath & "\temp.xls")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "',''"
        GenerateReport("voiddisc", "proc#" & "Spr_FetchMRVoidDiscountSummary" & "#" & StrParam & vbCrLf & "changeremarks.rpt")
        'GenerateReport("costvsslaes", "proc#" & "Spr_FetchCostvsSales" & "#" & StrParam & vbCrLf & "Costvssale2")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveMRVoid(0, dtFromDate.Value, dtToDate.Value, DirectCast(grdDCCReport.DataSource, DataTable), 1)
    End Sub

    Private Sub BtnRptDetailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptDetailed.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtToDate.Value, "dd-MMM-yyyy") & "'"
        GenerateReport("VoidDetailed", "proc#" & "Spr_FetchMRVoidDetailed" & "#" & StrParam)
        'GenerateReport("costvsslaes", "proc#" & "Spr_FetchCostvsSales" & "#" & StrParam & vbCrLf & "Costvssale2")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtToDate.Value, "dd-MMM-yyyy") & "'"
        GenerateReport("DiscountDetailed", "proc#" & "Spr_FetchMRDiscountDetailed" & "#" & StrParam)
        'GenerateReport("costvsslaes", "proc#" & "Spr_FetchCostvsSales" & "#" & StrParam & vbCrLf & "Costvssale2")
    End Sub
End Class