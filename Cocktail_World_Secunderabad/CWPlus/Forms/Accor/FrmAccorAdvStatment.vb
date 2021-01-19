Imports CWPlusBL.Accor
Imports System.Data

Public Class FrmAccorAdvStatment
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice
    Dim ObjPriDts As DataSet


    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Fromdate = Format(DtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
            ObjCls.UserName = gblUserName
            ObjPriDt = ObjCls.FunFetchAccorAdvStatment()
            grdDCCReport.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(DtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(DtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "'"
        GenerateReport("accoradvstmt", "proc#" & "Spr_FetchAccorAdvStatment" & "#" & StrParam & "#100")
    End Sub

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try

            ObjCls = New CWPlusBL.Accor.ClsReports
            ObjCls.Fromdate = DtFromDate.Value
            ObjCls.ToDate = DtToDate.Value


            ObjPriDt = ObjCls.FunFetchAccorAdvStatment
            ObjPriDts.Tables.Add(ObjPriDt)
            ObjExp = New ClsMsOffice
            ObjExp.ExportToExcelHeaderFooterEval(IO.Path.GetTempPath, "temp.xls", "Accor Advantage Statment Report", ObjPriDts)
            Process.Start(IO.Path.GetTempPath & "\temp.xls")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub
End Class