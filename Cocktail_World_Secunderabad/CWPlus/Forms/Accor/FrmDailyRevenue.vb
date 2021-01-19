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

Public Class FrmDailyRevenue
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Fromdate = Format(DtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
            ObjCls.UserName = gblUserName
            ObjPriDt = ObjCls.FunFetchDailyRevenue()
            grdDCCReport.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click
        Dim FoodRevenue As Double = IIf(Trim(txtFoodRevenue.Text) = "", 0, txtFoodRevenue.Text)
        Dim OtherRevenue As Double = IIf(Trim(txtOtherRevenue.Text) = "", 0, txtOtherRevenue.Text)
        Dim StrParam As String = ""
        StrParam = "'" & Format(DtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(DtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "'," & FoodRevenue & "," & OtherRevenue & ",''"
        GenerateReport("dailyrevenue", "proc#" & "Spr_FetchDailyRevenue" & "#" & StrParam & "#100")
    End Sub

End Class