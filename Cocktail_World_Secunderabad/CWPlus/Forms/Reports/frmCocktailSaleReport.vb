Public Class frmCocktailSaleReport
    Dim ObjDt As DataTable
    Dim objCocktail As New CWPlusBL.Master.ClsCocktailReports
#Region "Procedures"
    Public Sub BindGrid()
        ObjDt = New DataTable
        objCocktail = New CWPlusBL.Master.ClsCocktailReports
        If gblArrMDICheckedLicense.Count > 1 Then
            Dim strLic As String = ""
            strLic = String.Join(",", gblArrMDICheckedLicense.ToArray)
            objCocktail.LicenseList = strLic
        Else
            objCocktail.LicenseList = MDI.cmbLicenseName.SelectedValue
        End If
        objCocktail.CocktailName = txtCocktailName.Text
        objCocktail.Brand = txtBrand.Text
        objCocktail.BillNo = txtBillNo.Text
        If chkDate.Checked Then
            objCocktail.FromDate = dtFromDate.Value
            objCocktail.ToDate = dtTodate.Value
        Else
            objCocktail.FromDate = "01-jan-1900"
            objCocktail.ToDate = "01-jan-1900"
          
        End If
       
        ObjDt = objCocktail.FunFetchCocktailSaleReport
        grdCocktailSaleReport.DataSource = Nothing
        grdCocktailSaleReport.DataSource = ObjDt
        'grdCocktailSaleReport.Columns("brand").Width = 200

        Dim vSpeg As Double = 0
        For index = 0 To grdCocktailSaleReport.RowCount - 1
            vSpeg += grdCocktailSaleReport("Quantity", index).Value
        Next
        lblTotalQuantity.Text = "Quantity:   " & vSpeg
    End Sub
#End Region

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ObjDt = New DataTable
        ObjDt = DirectCast(grdCocktailSaleReport.DataSource, DataTable)
        ExportExcelTemplate(ObjDt)
    End Sub

  Private Sub frmCocktailSaleReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindGrid()
    End Sub

    Private Sub btnMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMore.Click
        BindGrid()
    End Sub


   

End Class