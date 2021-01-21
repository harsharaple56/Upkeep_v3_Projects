
Imports CWPlusBL.Master
Public Class FrmBrandwiseComparison
    Dim objCocktail As ClsCocktailReports
    Dim objDt As DataTable

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        objCocktail = New ClsCocktailReports
        Try
            FetchMDILicenseChecked(MDI.chkLicenseName, Nothing)
            If MDI.cmbLicenseName.SelectedValue = 0 And gblArrMDICheckedLicense.Count = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
            If cmbType.Text = "" Then
                MsgBox("Please Select Type")
                Exit Sub
            End If
            If CDate(dtFromDate.Text) > CDate(dtToDate.Text) Then
                MsgBox("Please select proper date range")
                Exit Sub
            End If
            If rdbBrand.Checked Then
                objCocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
                objCocktail.FromDate = dtFromDate.Text
                objCocktail.ToDate = dtToDate.Text
                objCocktail.Type = cmbType.Text
                grdBrandwiseComparison.DataSource = Nothing
                objDt = objCocktail.FunFetchBrandwiseComparisonReport()
                objDt.Columns.Remove("Brandopeningid")
                objDt.Columns("categorydesc").ColumnName = "Category"
                objDt.Columns("branddesc").ColumnName = "Brand Name"
                objDt.Columns("alias").ColumnName = "Size"
                grdBrandwiseComparison.DataSource = objDt
            ElseIf rdbCategory.Checked Then
                objCocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
                objCocktail.FromDate = dtFromDate.Text
                objCocktail.ToDate = dtToDate.Text
                objCocktail.Type = cmbType.Text
                grdBrandwiseComparison.DataSource = Nothing
                objDt = objCocktail.FunFetchCategorywiseComparisonReport()
                objDt.Columns("categorydesc").ColumnName = "Category"
                objDt.Columns("branddesc").ColumnName = "Brand Name"
                objDt.Columns("alias").ColumnName = "Size"
                grdBrandwiseComparison.DataSource = objDt
            End If
           
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As System.EventArgs) Handles btnExport.Click
        If Me.grdBrandwiseComparison.Rows.Count = 0 Then
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
End Class