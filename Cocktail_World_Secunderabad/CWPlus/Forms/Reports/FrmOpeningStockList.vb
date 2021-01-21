Public Class FrmOpeningStockList
    Dim objCocktail As New CWPlusBL.Master.ClsCocktailReports
    Dim ObjDt As DataTable
    Dim ObjBrand As CWPlusBL.Master.ClsBrandHeadDet
    Dim ObjCategory As CWPlusBL.Master.ClsCategory

#Region "BindBrand"
    Public Sub BindBrand(ByVal BrandID As Double)
        Try
            ObjBrand = New CWPlusBL.Master.ClsBrandHeadDet
            ObjDt = New DataTable
            ObjBrand.BrandID = BrandID
            ObjDt = ObjBrand.FunFetch
            If Not ObjDt.Rows.Count > 0 Then
                Exit Sub
            End If
            If BrandID = 0 Then
                ComboBindingTemplate(cmbBrandName, ObjDt, "dispfield", "valuefield")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjBrand) Then
                ObjBrand = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    Private Sub BindCategory()
        Try
            ObjCategory = New CWPlusBL.Master.ClsCategory
            ObjDt = New DataTable
            ObjDt = ObjCategory.FunFetch

            Cmbcategory.DataSource = Nothing
            ComboBindingTemplate(Cmbcategory, ObjDt, "categorydesc", "categoryid")

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(ObjCategory) Then
                ObjCategory = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub
#End Region
#Region "Procedures"
    Public Sub BindGrid()
        Try
            ObjDt = New DataTable
            objCocktail = New CWPlusBL.Master.ClsCocktailReports
            objCocktail.LicenseID = gblLicenseID
            objCocktail.BrandID = cmbBrandName.SelectedValue
            objCocktail.BrandCode = Cmbcategory.SelectedValue
            ObjDt = objCocktail.FetchOpeningStockReport
            grdBrandOpening.DataSource = Nothing
            grdBrandOpening.DataSource = ObjDt
            MakeIDColumnsHide(grdBrandOpening)
        Catch ex As Exception
            Throw ex
        End Try
        
    End Sub
#End Region
    Private Sub FrmOpeningStockList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindCategory()
        BindBrand(0)
        BindGrid()

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ObjDt = New DataTable
        ObjDt = DirectCast(grdBrandOpening.DataSource, DataTable)
        ExportExcelTemplate(ObjDt)
    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        Dim arrReportName(0) As String

        arrReportName(0) = "Brand Opening Reports"
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdBrandOpening)
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