Imports System.Xml
Imports CWPlusBL.Master
Public Class frmBrandwise_Monthly_
    Dim objCocktail As ClsCocktailReports
    Dim objDt As DataTable
    Dim CocktailReportMenuID As Integer
    Dim StrProcedureName As String
    Dim GroupBoxName As String
    Dim StrReportName As String
    Dim StrSubReportName As String
    Public _Brand As String = ""
    Public _Category As String = ""
    Public _Size As String = ""
    Public _Cocktail As String = ""
    Dim arrReportName(0) As String
    Dim objpurchasedet As CWPlusBL.Master.Clspurchase
    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        BindBrnadWiseGrid()
    End Sub

    Public Sub BindBrnadWiseGrid()
        objCocktail = New ClsCocktailReports
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><CocktailReports></CocktailReports></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Report")

        Try
            If MDI.cmbLicenseName.SelectedValue = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If

            XmlElt = xmldoc.CreateElement("Report")
            XmlElt.SetAttribute("LicenseID", MDI.cmbLicenseName.SelectedValue)
            XmlElt.SetAttribute("FromDate", dtFromDate.Text)
            XmlElt.SetAttribute("ToDate", dtToDate.Text)
            XmlElt.SetAttribute("Brandwise", True)
            XmlElt.SetAttribute("Categorywise", False)
            XmlElt.SetAttribute("SubCategorywise", False)
            XmlElt.SetAttribute("IsBulkLitre", False)
            xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)

            objCocktail.CocktailReportXml = xmldoc
            grdApBangloreReport.DataSource = Nothing
            objDt = objCocktail.FunFetchReport("Spr_FetchBrandwiseSummary", 999999999)
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

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Dim ObjSearch As New dlgReportSearch
        ObjSearch.IntForm = 1
        If ObjSearch.ShowDialog = DialogResult.OK Then
            BindBrnadWiseGrid()
        End If
    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        'If gblMenuDesc = Trim("Brand Summary") Then
        '    arrReportName(0) = "Brand Summary Report"
        'Else
        '    arrReportName(0) = "Brand Summary"
        'End If

        arrReportName(0) = "Brandwise Monthly Report"


        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdApBangloreReport)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub
End Class