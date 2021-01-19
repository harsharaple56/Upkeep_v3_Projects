Imports System.Xml

Public Class FrmKarnatakMonthly


    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
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
        Dim ObjDt As New DataTable
        Try
            ObjApBang.CocktailReportXml = GenerateLicenseXML()
            ObjApBang.FromDate = dtFromDate.Value.ToString("dd-MMM-yyyy")
            ObjApBang.ToDate = dtToDate.Value.ToString("dd-MMM-yyyy")
            ObjDt = ObjApBang.FunFetchbanglorereportmonthly(IIf(txtTimeOut.Text = "", 30, CInt(txtTimeOut.Text)))

            grdKarMonthly.DataSource = ObjDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjApBang = Nothing
            ObjDt = Nothing
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click

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
        Dim xmldocString As String
        xmldocString = GenerateLicenseXML().InnerXml

        Dim StrParam As String = ""
        StrParam = "'" & xmldocString & "','" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtToDate.Value, "dd-MMM-yyyy") & "'"
        'GenerateReport("bangloremonthlyv2", "proc#" & "Spr_Fetchbanglorereportmonthly" & "#" & StrParam & "#" & txtTimeOut.Text)
        GenerateReport("bangloremonthlyv2", "proc#" & "Spr_Fetchbanglorereportmonthly" & "#" & StrParam & "#" & txtTimeOut.Text & vbCrLf & "bangloremonthlyTP.rpt")
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

    'Private Sub BtnTpNo_Click(sender As System.Object, e As System.EventArgs)
    '    If MDI.cmbLicenseName.SelectedValue = 0 Then
    '        MsgBox("Please select license")
    '        Exit Sub
    '    End If

    '    Dim StrParam As String = ""
    '    StrParam = MDI.cmbLicenseName.SelectedValue & ",'" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtToDate.Value, "dd-MMM-yyyy") & "',1"
    '    GenerateReport("bangloremonthly-TP", "proc#" & "Spr_Fetchbanglorereportmonthly" & "#" & StrParam & "#" & txtTimeOut.Text)
    'End Sub

    Private Sub FrmKarnatakMonthly_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class