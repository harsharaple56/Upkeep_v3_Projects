Imports CWPlusBL.Marriot
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.OleDb
Imports System.Xml
Imports System.Xml.Xsl
Imports System.IO
Imports System.Web.UI
Imports System.Text.RegularExpressions

Public Class FrmDCC_TopSheetREPORTMR
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice
    Dim StrPriHeaderFooter As String = ""

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Fromdate = Format(DtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
            ObjCls.UserName = gblUserName
            ObjPriDt = ObjCls.FunFetchTopSheet()

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
            ObjExp = New ClsMsOffice
            StrPriHeaderFooter = "Top Sheet#" + Format(DtFromDate.Value, "dd-MMM-yyyy") + " - " + Format(DtToDate.Value, "dd-MMM-yyyy")
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


    'Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    '    'ImportFile()


    '    'Dim ObjPriDs As DataSet
    '    'ObjCls = New ClsReports
    '    'ObjCls.Fromdate = Format(DtFromDate.Value, "dd-MMM-yyyy")
    '    'ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
    '    'ObjCls.IsDept = 0


    '    'ObjPriDs = ObjCls.FunFetchNonPromotionalMealSummary()
    '    'ExportToExcelHeaderFooter11(IO.Path.GetTempPath, "temp.xls", "Bhalya", ObjPriDs.Tables(0), ObjPriDs.Tables(1), ObjPriDs.Tables(2))
    '    'Process.Start(IO.Path.GetTempPath & "\temp.xls")
    'End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(DtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(DtToDate.Value, "dd-MMM-yyyy") & "'"
        GenerateReport("topsheet", "proc#" & "Spr_FetchMRTopSheet" & "#" & StrParam & "#100")
    End Sub

End Class