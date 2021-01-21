Public Class frmBrandCodeReport
    Dim objCocktail As New CWPlusBL.Master.ClsCocktailReports
    Dim ObjDt As DataTable
    Dim ObjBrand As CWPlusBL.Master.ClsBrandHeadDet
#Region "Procedures"
    Public Sub BindGrid()
        ObjDt = New DataTable
        objCocktail = New CWPlusBL.Master.ClsCocktailReports

        objCocktail.BrandID = cmbBrandName.SelectedValue
        objCocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
        objCocktail.BrandCode = txtBrand.Text

        ObjDt = objCocktail.FunFetchBrandCOdeReport
        grdBrandCodeReport.DataSource = Nothing
        grdBrandCodeReport.DataSource = ObjDt
        MakeIDColumnsHide(grdBrandCodeReport)
        grdBrandCodeReport.Columns("brand name").Width = 300
    End Sub
#End Region

    'Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    ObjDt = New DataTable
    '    ObjDt = DirectCast(grdBrandCodeReport.DataSource, DataTable)
    '    ExportExcelTemplate(ObjDt)

    'End Sub

    Private Sub frmBrandCodeReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not MDI.cmbLicenseName.SelectedValue = 0 Then
            BindBrand(0)
            BindGrid()
        End If
    End Sub

    
    Private Sub btnExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        ObjDt = New DataTable
        ObjDt = DirectCast(grdBrandCodeReport.DataSource, DataTable)
        ExportExcelTemplate(ObjDt)
    End Sub
    Dim arrReportName(0) As String
    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click

        arrReportName(0) = "BrandCodeReport"
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdBrandCodeReport)

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
#End Region
End Class