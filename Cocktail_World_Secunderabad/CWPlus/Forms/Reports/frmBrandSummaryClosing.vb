﻿Imports System.Xml
Imports CWPlusBL.Master
Public Class frmBrandSummaryClosing
    Dim objCocktail As ClsCocktailReports
    Dim objDt As DataTable

    Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><CocktailReports></CocktailReports></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Report")

        If gblArrMDICheckedLicense.Count > 0 Then
            For index = 0 To gblArrMDICheckedLicense.Count - 1
                XmlElt = xmldoc.CreateElement("Report")
                XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense(index))
                XmlElt.SetAttribute("FromDate", dtFromDate.Text)
                XmlElt.SetAttribute("ToDate", dtToDate.Text)
                XmlElt.SetAttribute("Brandwise", rdbBrandwise.Checked)
                XmlElt.SetAttribute("Categorywise", rdbCategorywise.Checked)
                XmlElt.SetAttribute("SubCategorywise", rdbSubcategorywise.Checked)
                XmlElt.SetAttribute("IsBulkLitre", chkIsBulkLitre.Checked)
                xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
            Next
        Else
            XmlElt = xmldoc.CreateElement("Report")
            XmlElt.SetAttribute("LicenseID", MDI.cmbLicenseName.SelectedValue)
            XmlElt.SetAttribute("FromDate", dtFromDate.Text)
            XmlElt.SetAttribute("ToDate", dtToDate.Text)
            XmlElt.SetAttribute("Brandwise", rdbBrandwise.Checked)
            XmlElt.SetAttribute("Categorywise", rdbCategorywise.Checked)
            XmlElt.SetAttribute("SubCategorywise", rdbSubcategorywise.Checked)
            XmlElt.SetAttribute("IsBulkLitre", chkIsBulkLitre.Checked)
            xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
        End If
        Return xmldoc
    End Function

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        objCocktail = New ClsCocktailReports
        Try
            FetchMDILicenseChecked(MDI.chkLicenseName, Nothing)
            If MDI.cmbLicenseName.SelectedValue = 0 And gblArrMDICheckedLicense.Count = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
            objCocktail.CocktailReportXml = GenerateXML()
            grdApBangloreReport.DataSource = Nothing
            objDt = objCocktail.FunFetchReport("Spr_FetchBrandwiseSummaryClosing", 999999999)
            grdApBangloreReport.DataSource = objDt
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        If Me.grdApBangloreReport.Rows.Count = 0 Then
            MsgBox("Nothing To Export ")
            Exit Sub
        End If

        Try
            ExportExcelTemplate(objDt)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(objCocktail) = False Then
                objCocktail = Nothing
            End If
        End Try
    End Sub
    Dim arrReportName(0) As String
    'Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click


    '    If gblMenuDesc = Trim("flr1a") Then
    '        arrReportName(0) = "FLR1A Report"
    '    Else
    '        arrReportName(0) = "FLR9A Report"
    '    End If

    '    'arrReportName(0) = "FLR1A Report"


    '    Dim SaveFile As New SaveFileDialog
    '    If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        If IO.File.Exists(SaveFile.FileName) Then
    '            IO.File.Delete(SaveFile.FileName)
    '        End If
    '        Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
    '        'ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdFLR1A)
    '        Dim dlgRes As DialogResult
    '        dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        If dlgRes = Windows.Forms.DialogResult.Yes Then
    '            Process.Start(SaveFile.FileName & ".pdf")

    '        End If
    '    End If
    'End Sub

    Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click

        FetchMDILicenseChecked(MDI.chkLicenseName, Nothing)
        If MDI.cmbLicenseName.SelectedValue = 0 And gblArrMDICheckedLicense.Count = 0 Then
            MsgBox("Please Select License")
            Exit Sub
        End If
        If rdbBrandwise.Checked Then
            GenerateReport("BrandSummary", "proc#" & "Spr_FetchBrandwiseSummaryClosing" & "#'" & GenerateXML.InnerXml & "',0,''")
        ElseIf rdbCategorywise.Checked Then
            GenerateReport("BrandSummaryCatg", "proc#" & "Spr_FetchBrandwiseSummaryClosing" & "#'" & GenerateXML.InnerXml & "',0,''")
        ElseIf rdbSubcategorywise.Checked Then
            GenerateReport("BrandSummarySubCatg", "proc#" & "Spr_FetchBrandwiseSummaryClosing" & "#'" & GenerateXML.InnerXml & "',0,''")
        End If

    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        If gblMenuDesc = Trim("Brand Summary") Then
            arrReportName(0) = "Brand Summary Report"
        Else
            arrReportName(0) = "Brand Summary"
        End If

        arrReportName(0) = "Brand Summary Report"


        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2New(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdApBangloreReport)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub

    Private Sub grpApReport_Enter(sender As System.Object, e As System.EventArgs) Handles grpApReport.Enter

    End Sub
End Class