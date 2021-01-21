Imports CWPlusBL.Accor
Imports System.Data

Public Class FrmSplitChecks
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice
    Dim StrPriHeaderFooter As String = ""

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Fromdate = Format(DtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
            ObjCls.UserName = gblUserName
            ObjPriDt = ObjCls.FunFetchSplitCheckReport()
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
        GenerateReport("splitcheck", "proc#" & "Spr_FetchSplitCheckReport" & "#" & StrParam & "#100")
    End Sub

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
End Class