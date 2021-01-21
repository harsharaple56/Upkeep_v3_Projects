Imports System.Xml

Public Class FrmCostValuationReport

    Dim objCocktail As New CWPlusBL.Master.ClsCocktailReports
    Dim ObjPriDs As DataSet
    Dim ObjBrandDt, ObjCatgDt As DataTable

#Region "Button click"
    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        BindGrid()
    End Sub
#End Region

#Region "Procedures"
    Public Sub BindGrid()
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<CWPLUS><AllLicense></AllLicense></CWPLUS>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
        Try
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)
            If gblArrMDICheckedLicense.Count = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
            gblArrMDICheckedLicense.Clear()
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)
            For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                XmlElt = xmldoc.CreateElement("License")
                XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cntr))
                xmldoc.DocumentElement.Item("AllLicense").AppendChild(XmlElt)
            Next
            ObjPriDs = New DataSet
            ObjBrandDt = New DataTable
            objCocktail = New CWPlusBL.Master.ClsCocktailReports
            objCocktail.CocktailReportXml = xmldoc
            objCocktail.FromDate = dtFrom.Value
            objCocktail.ToDate = dtTo.Value
            ObjPriDs = objCocktail.FunFetchCostEvaluationReport
            ObjBrandDt = ObjPriDs.Tables(0)
            ObjCatgDt = ObjPriDs.Tables(1)
            grdBrandwise.DataSource = Nothing
            grdBrandwise.DataSource = ObjBrandDt

            grdCategorywise.DataSource = Nothing
            grdCategorywise.DataSource = ObjCatgDt

            MakeIDColumnsHide(grdBrandwise)
            MakeIDColumnsHide(grdCategorywise)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region





    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        ExportExcelTemplate(ObjBrandDt, ObjCatgDt)
    End Sub

    Dim arrReportName(0) As String
    Private Sub btnPdf_Click(sender As System.Object, e As System.EventArgs) Handles btnPdf.Click
        arrReportName(0) = "Cost valuation from " & Format(dtFrom.Value, "dd-MMM-yyyy") & "-" & Format(dtTo.Value, "dd-MMM-yyyy")
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdBrandwise)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub

    Private Sub btnMailReport_Click(sender As System.Object, e As System.EventArgs) Handles btnMailReport.Click
        SendReport()
    End Sub

    Public Sub SendReport()
        Try
            arrReportName(0) = "Cost valuation from " & Format(dtFrom.Value, "dd-MMM-yyyy") & "-" & Format(dtTo.Value, "dd-MMM-yyyy")
            Dim SaveFile As String = Application.StartupPath & "\CW_Report.pdf"
            If IO.File.Exists(SaveFile) Then
                IO.File.Delete(SaveFile)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile), IO.Path.GetFileNameWithoutExtension(SaveFile), arrReportName, grdBrandwise)
            frmSendReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class