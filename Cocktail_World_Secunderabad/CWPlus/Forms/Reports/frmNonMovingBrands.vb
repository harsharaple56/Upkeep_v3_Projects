Public Class frmNonMovingBrands
    Dim objCocktail As New CWPlusBL.Master.ClsCocktailReports

    Dim ObjDtBrand, ObjDtCatg As DataTable
    Dim ObjDs As DataSet

#Region "Procedures"
    Public Sub BindGrid()
        Try
            ObjDtBrand = New DataTable
            objCocktail = New CWPlusBL.Master.ClsCocktailReports
            objCocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
            objCocktail.FromDate = dtFrom.Value
            objCocktail.ToDate = dtTo.Value
            ObjDs = objCocktail.FunFetchNonMovingBrandsReport
            ObjDtBrand = ObjDs.Tables(0)
            ObjDtCatg = ObjDs.Tables(1)
            grdBrands.DataSource = Nothing
            grdBrands.DataSource = ObjDtBrand

            grdCategorywise.DataSource = Nothing
            grdCategorywise.DataSource = ObjDtCatg

            MakeIDColumnsHide(grdBrands)
            MakeIDColumnsHide(grdCategorywise)
            lblCount.Text = "Total Brands: " & grdBrands.RowCount
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region
    Private Sub btnok_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        BindGrid()
    End Sub

    Private Sub btnExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ExportExcelTemplate(ObjDtBrand, ObjDtCatg)
    End Sub

    Dim arrReportName(0) As String
    Private Sub btnPdf_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        arrReportName(0) = "Non Moving Brands Report"
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdBrands)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub
    Public Sub SendReport()
        Dim SaveFile As String = Application.StartupPath & "\CW_Report.pdf"
        If IO.File.Exists(SaveFile) Then
            IO.File.Delete(SaveFile)
        End If
        Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
        ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile), IO.Path.GetFileNameWithoutExtension(SaveFile), arrReportName, grdBrands)
        frmSendReport.Show()
    End Sub

    Private Sub btnMailReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMailReport.Click
        SendReport()
    End Sub
End Class