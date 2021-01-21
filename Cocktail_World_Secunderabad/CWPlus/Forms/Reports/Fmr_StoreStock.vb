Public Class Frm_StoreStock
    Dim objCocktail As New CWPlusBL.Master.ClsCocktailReports
    Dim ObjDs As DataSet
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
        ObjDs = New DataSet
        objCocktail = New CWPlusBL.Master.ClsCocktailReports
        objCocktail.FromDate = dtFrom.Value
        objCocktail.ToDate = dtTo.Value
        If Not cmbBrandName.SelectedValue = 0 Then
            objCocktail.Brand = cmbBrandName.Text
        Else
            objCocktail.Brand = ""
        End If
        If Not Cmbcategory.SelectedValue = 0 Then
            objCocktail.Category = Cmbcategory.Text
        Else
            objCocktail.Category = ""
        End If
        ObjDs = objCocktail.FunFetchCostingVerification
        grdData.DataSource = Nothing
        grdData.DataSource = ObjDs.Tables(0)
        MakeIDColumnsHide(grdData)

        grdLic.DataSource = Nothing
        If ObjDs.Tables.Count > 1 Then
            grdLic.DataSource = ObjDs.Tables(1)
            MakeIDColumnsHide(grdLic)
        End If

        grdData.Columns("brand").Width = 250
        grdData.Columns("category").Width = 200
        lblCount.Text = "Number of brands : " & ObjDs.Tables(0).DefaultView.ToTable(True, "brand").Rows.Count
    End Sub
#End Region

    Private Sub frmBrandlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtFrom.Value = CDate(DateSerial(Today.Year, Today.Month, 1))
        dtTo.Value = CDate(DateSerial(Today.Year, Today.Month + 1, 0))
        BindCategory()
        BindBrand(0)
        BindGrid()
        Me.AcceptButton = btnSearch
    End Sub

    'Private Sub btnExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim dt As DataTable = DirectCast(grdData.DataSource, DataTable)
    '    ExportExcelTemplate(dt)
    'End Sub

    'Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim arrReportName(0) As String

    '    arrReportName(0) = "Brand Details Reports"
    '    Dim SaveFile As New SaveFileDialog
    '    If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        If IO.File.Exists(SaveFile.FileName) Then
    '            IO.File.Delete(SaveFile.FileName)
    '        End If
    '        Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
    '        ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdData)
    '        Dim dlgRes As DialogResult
    '        dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        If dlgRes = Windows.Forms.DialogResult.Yes Then
    '            Process.Start(SaveFile.FileName & ".pdf")

    '        End If
    '    End If
    'End Sub

    Private Sub btnMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BindGrid()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindGrid()
    End Sub


    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(dtFrom.Value, "dd-MMM-yyyy") & "','" & Format(dtTo.Value, "dd-MMM-yyyy") & "','" & gblUserName & "'"
        GenerateReport("stockregister3", "proc#" & "Spr_FetchStockRegisterReport" & "#" & StrParam)
    End Sub


    Private Sub BtnStockRegister_Click(sender As System.Object, e As System.EventArgs) Handles BtnStockRegister.Click
        Try
            If txtTimeout.Text = "" Then
                txtTimeout.Text = 2000000
            End If
            objCocktail = New CWPlusBL.Master.ClsCocktailReports()
            objCocktail.FromDate = dtFrom.Value
            objCocktail.ToDate = dtTo.Value
            objCocktail.UserName = gblUserName
            objCocktail.CategoryID = Cmbcategory.SelectedValue
            objCocktail.BrandID = cmbBrandName.SelectedValue
            objCocktail.SubProcessStockRegister(txtTimeout.Text)
            MsgBox("Data Processed for Stock Register report")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class