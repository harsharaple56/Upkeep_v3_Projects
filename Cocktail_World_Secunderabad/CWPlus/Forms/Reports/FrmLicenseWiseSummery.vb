Imports System.Xml
Imports CWPlusBL.Master
Imports System.IO

Public Class FrmLicenseWiseSummery
    Dim objCocktail As ClsCocktailReports
    Dim objDt As DataTable

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Dim IntLicenseValue As Integer

        FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

        For cntr = 0 To gblArrMDICheckedLicense.Count - 1
            IntLicenseValue = gblArrMDICheckedLicense.Item(cntr)
        Next

        If IntLicenseValue = 0 Then
            If MDI.cmbLicenseName.SelectedValue = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
        End If

        Dim ObjApBang As New CWPlusBL.Master.ClsCocktailReports
        Try
            ObjApBang.CocktailReportXml = GenerateLicenseXML()
            ObjApBang.FromDate = dtFromDate.Value.ToString("dd-MMM-yyyy")
            ObjApBang.ToDate = dtToDate.Value.ToString("dd-MMM-yyyy")
            If chkInML.Checked Then
                ObjApBang.isML = 1
            Else
                ObjApBang.isML = 0
            End If
            If rdbClosing.Checked Then
                ObjApBang.Type = "c"
            End If
            If rdbPurchase.Checked Then
                ObjApBang.Type = "p"
            End If
            If rdbSale.Checked Then
                ObjApBang.Type = "s"
            End If
            If rdbTransfer.Checked Then
                ObjApBang.Type = "t"
            End If

            objDt = ObjApBang.FunFetchLicenseWiseSummery()

            grdLicensewiseSummery.DataSource = objDt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GenerateLicenseXML() As XmlDocument
        GenerateLicenseXML = Nothing
        Dim xmldoc As XmlDocument
        xmldoc = New XmlDocument
        xmldoc.LoadXml("<CWPLUS><AllLicense></AllLicense></CWPLUS>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
        For cntr = 0 To gblArrMDICheckedLicense.Count - 1
            XmlElt = xmldoc.CreateElement("License")
            XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cntr))
            xmldoc.DocumentElement.Item("AllLicense").AppendChild(XmlElt)
        Next
        GenerateLicenseXML = xmldoc
    End Function

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If Me.grdLicensewiseSummery.Rows.Count = 0 Then
            MsgBox("Nothing To Export ")
            Exit Sub
        End If
        Dim ObjApBang As New CWPlusBL.Master.ClsCocktailReports
        Dim ObjExp As ClsMsOffice
        ObjExp = New ClsMsOffice

        Try

            If rdbClosing.Checked Then
                ObjApBang.Filename = "Closing_From_" + dtFromDate.Value.ToString("dd-MMM-yyyy") + "_To_" + dtToDate.Value.ToString("dd-MMM-yyyy") + ".xls"
                ObjApBang.Header = "License wise Closing Summary#From " + dtFromDate.Value.ToString("dd-MMM-yyyy") + " To " + dtToDate.Value.ToString("dd-MMM-yyyy")
            End If
            If rdbPurchase.Checked Then
                ObjApBang.Filename = "Purchase_From_" + dtFromDate.Value.ToString("dd-MMM-yyyy") + "_To_" + dtToDate.Value.ToString("dd-MMM-yyyy") + ".xls"
                ObjApBang.Header = "License wise Purchase Summary#From " + dtFromDate.Value.ToString("dd-MMM-yyyy") + " To " + dtToDate.Value.ToString("dd-MMM-yyyy")
            End If
            If rdbSale.Checked Then
                ObjApBang.Filename = "Sale_From_" + dtFromDate.Value.ToString("dd-MMM-yyyy") + "_To_" + dtToDate.Value.ToString("dd-MMM-yyyy") + ".xls"
                ObjApBang.Header = "License wise Sale Summary#From " + dtFromDate.Value.ToString("dd-MMM-yyyy") + " To " + dtToDate.Value.ToString("dd-MMM-yyyy")
            End If
            If rdbTransfer.Checked Then
                ObjApBang.Filename = "Transfer_From_" + dtFromDate.Value.ToString("dd-MMM-yyyy") + "_To_" + dtToDate.Value.ToString("dd-MMM-yyyy") + ".xls"
                ObjApBang.Header = "License wise Transfer Summary#From " + dtFromDate.Value.ToString("dd-MMM-yyyy") + " To " + dtToDate.Value.ToString("dd-MMM-yyyy")
            End If

            ObjExp.ExportToExcelLicensewiseSummary(IO.Path.GetTempPath, ObjApBang.Filename, ObjApBang.Header, objDt)
            Process.Start(IO.Path.GetTempPath & "\" & ObjApBang.Filename)
            'ExportExcelTemplate(objDt)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(objCocktail) = False Then
                objCocktail = Nothing
            End If
        End Try
    End Sub
End Class