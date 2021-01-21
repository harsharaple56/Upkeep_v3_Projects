Imports CWPlusBL.Accor
Imports System.Data

Public Class FrmAGEntSummary
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice
    Dim ObjPriDts As DataSet
    Dim StrPriHeaderFooter As String = ""

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjExp = New ClsMsOffice
            ObjCls.Fromdate = Format(dtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(dtToDate.Value, "dd-MMM-yyyy")
            ObjPriDt = ObjCls.FunFetchAGEntSummary()
            StrPriHeaderFooter = ObjCls.ErrorMsg
            grdDCCReport.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Try
            ObjPriDt = DirectCast(grdDCCReport.DataSource, DataTable)
            ObjPriDts.Tables.Add(ObjPriDt)
            ObjExp.ExportToExcelHeaderFooterEval(IO.Path.GetTempPath, "temp.xls", StrPriHeaderFooter, ObjPriDts)
            Process.Start(IO.Path.GetTempPath & "\temp.xls")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "',''"
        GenerateReport("agent", "proc#" & "Spr_FetchAGEntSummary" & "#" & StrParam)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveVoid(0, dtFromDate.Value, dtToDate.Value, DirectCast(grdDCCReport.DataSource, DataTable), 2)
    End Sub
End Class