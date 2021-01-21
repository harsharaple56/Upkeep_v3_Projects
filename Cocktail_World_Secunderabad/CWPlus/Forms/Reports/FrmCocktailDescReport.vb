Imports System.Data
Imports CWPlusBL.Master


Public Class FrmCocktailDescReport

    Private Sub FrmCocktailDescReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BindGrid()
    End Sub

    Public Sub BindGrid()
        Dim ObjCocktail As New ClsCocktailReports
        Dim objDt As New DataTable
        Try
            ObjCocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
            objDt = ObjCocktail.FunFetchCocktailDescReport(txtCocktail.Text, txtBrand.Text)
            grdCocktailReportDesc.DataSource = Nothing
            grdCocktailReportDesc.DataSource = objDt
            MakeIDColumnsHide(grdCocktailReportDesc)
            lblCount.Text = "Number of cocktails : " & objDt.DefaultView.ToTable(True, "cocktailname").Rows.Count
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing("ObjCocktail") = False Then
                ObjCocktail = Nothing
            End If

            If IsNothing("objDt") = False Then
                ObjCocktail = Nothing
            End If


        End Try

    End Sub

    Private Sub btnExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim ObjDt As New DataTable

        ObjDt = New DataTable
        ObjDt = DirectCast(grdCocktailReportDesc.DataSource, DataTable)
        ExportExcelTemplate(ObjDt)
    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        Dim arrReportName(0) As String

        arrReportName(0) = "Cocktail Report Details"
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdCocktailReportDesc)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub

   
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindGrid()
    End Sub
End Class