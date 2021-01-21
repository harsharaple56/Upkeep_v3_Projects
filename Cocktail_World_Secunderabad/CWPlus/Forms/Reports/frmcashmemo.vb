Imports System.Xml

Public Class frmcashmemo

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub frmcashmemo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim StrParam As String = ""
        StrParam = "'" & Format(Dtfrom.Value, "dd-MMM-yyyy") & "','" & Format(DtTo.Value, "dd-MMM-yyyy") & "'"
        GenerateReport("cashmemo", "proc#" & "Spr_FetchCashmemoreport" & "#" & StrParam & ",0,''")
    End Sub

    Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><CocktailReports></CocktailReports></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Report")
        FetchMDILicenseChecked(MDI.chkLicenseName, Nothing)

        If MDI.cmbLicenseName.SelectedValue = 0 And gblArrMDICheckedLicense.Count = 0 Then
            MsgBox("Please Select License")
            Exit Sub
        End If

        If gblArrMDICheckedLicense.Count > 0 Then
            For index = 0 To gblArrMDICheckedLicense.Count - 1
                XmlElt = xmldoc.CreateElement("Report")
                XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense(index))
                xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
            Next
        Else
            XmlElt = xmldoc.CreateElement("Report")
            XmlElt.SetAttribute("LicenseID", MDI.cmbLicenseName.SelectedValue)
            xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
        End If

        Dim StrParam As String = ""
        StrParam = "'" & Format(Dtfrom.Value, "dd-MMM-yyyy") & "','" & Format(DtTo.Value, "dd-MMM-yyyy") & "','" & xmldoc.InnerXml & "'"
        GenerateReport("cashmemo", "proc#" & "Spr_FetchCashmemoreport" & "#" & StrParam & ",0,''")
    End Sub
End Class