Imports CWPlusBL.Accor
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.OleDb
Imports System.Xml
Imports System.Xml.Xsl
Imports System.IO
Imports System.Web.UI
Imports System.Text.RegularExpressions

Public Class FrmFoodBevStats
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Fromdate = Format(DtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
            ObjCls.UserName = gblUserName
            ObjPriDt = ObjCls.FunFetchFodBevStats()
            grdDCCReport.DataSource = ObjPriDt
            grdDCCReport.Columns("Ord").Visible = False
            grdDCCReport.AutoResizeColumns()
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnExport_Click_1(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Try
            Dim StrPriHeader As String
            StrPriHeader = "Food & Beverage Statistics#" & DtFromDate.Text & " - " & DtToDate.Text
            ObjExp = New ClsMsOffice
            ObjPriDt = DirectCast(grdDCCReport.DataSource, DataTable)
            ObjPriDt.Columns.Remove("Ord")
            ObjExp.ExportToExcelHeaderFooter(IO.Path.GetTempPath, "temp.xls", StrPriHeader, ObjPriDt)
            Process.Start(IO.Path.GetTempPath & "\temp.xls")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

End Class