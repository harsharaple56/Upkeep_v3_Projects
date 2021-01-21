Imports System.Xml
Imports CWPlusBL.Accor

Public Class FrmParStockReport
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice
    Dim StrPriHeaderFooter As String = ""

    Public gblArrEvalLicense As New ArrayList

    Private Function GenerateLicenseXML() As XmlDocument
        GenerateLicenseXML = Nothing
        Dim xmldoc As XmlDocument
        xmldoc = New XmlDocument
        xmldoc.LoadXml("<Report><EvalPack></EvalPack></Report>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
        For cntr = 0 To gblArrEvalLicense.Count - 1
            XmlElt = xmldoc.CreateElement("License")
            XmlElt.SetAttribute("Licenseid", gblArrEvalLicense.Item(cntr))
            xmldoc.DocumentElement.Item("EvalPack").AppendChild(XmlElt)
        Next
        GenerateLicenseXML = xmldoc
    End Function

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        Try
            If drpRevenueCenter.SelectedValue = 0 Then
                MsgBox("Please select RevenueCenter")
                Exit Sub
            End If


            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjExp = New ClsMsOffice
            ObjCls.LicenseID = drpRevenueCenter.SelectedValue
            ObjCls.Fromdate = Format(dtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(dtToDate.Value, "dd-MMM-yyyy")
            If ObjCls.Fromdate > ObjCls.ToDate Then
                MsgBox("From date should be smaller than to date")
                Exit Sub
            End If

            ObjCls.UserName = gblUserName
            ObjCls.Article = LTrim(RTrim(txtSearchByArticle.Text))
            ObjPriDt = ObjCls.FunFetchParStockReport()
            grdParStock.DataSource = ObjPriDt

            grdParStock.AutoResizeColumns()
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click
        Dim StrParam As String = ""
        StrParam = drpRevenueCenter.SelectedValue & ",'" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "'"
        GenerateReport("parstock", "proc#" & "Spr_FetchParStockReport" & "#" & StrParam & "#10000")
    End Sub

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub FrmBeverageReconciliation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindEvalLicense()
    End Sub

    Private Sub BindEvalLicense()
        Dim ObjClsEval As CWPlusBL.Accor.ClsEvalLicense
        Try
            ObjPriDt = New DataTable
            ObjClsEval = New CWPlusBL.Accor.ClsEvalLicense
            ObjPriDt = ObjClsEval.FunFetch()
            ComboBindingTemplate(drpRevenueCenter, ObjPriDt, "LicenseName", "EvalLicenseID")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub
End Class