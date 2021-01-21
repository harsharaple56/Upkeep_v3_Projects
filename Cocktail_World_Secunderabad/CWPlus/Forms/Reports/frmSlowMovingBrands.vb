Imports CWPlusBL
Public Class frmSlowMovingBrands
    Dim objdash As ClsQuickExcess
    Dim ObjDt As DataTable
    Dim PercMargin As Double = 50
#Region "Procedures"

    Function Fetchdata() As DataSet
        objdash = New ClsQuickExcess
        objdash.LicenseID = gblLicenseID
        objdash.FromDate = dtFrom.Value
        objdash.ToDate = dtTo.Value
        Return objdash.FetchSlowMovingBrands()
    End Function
    Public Sub BindGrid()
        Dim ds As DataSet = Fetchdata()
        grdBrand.DataSource = Nothing

        ds.Tables(0).DefaultView.Sort = "salepercentage"
        grdBrand.DataSource = ds.Tables(0).DefaultView
      
        grdBrand.Columns("Category").Width = 150
        grdBrand.Columns("brand").Width = 200
        MakeIDColumnsHide(grdBrand)

        ds.Tables(1).DefaultView.Sort = "salepercentage"
        grdCategory.DataSource = Nothing
        grdCategory.DataSource = ds.Tables(1).DefaultView
        grdCategory.Columns("Category").Width = 150
        makeColor()
    End Sub

    Sub makeColor()
        Dim vCount As Integer = 0

        For index = 0 To grdBrand.RowCount - 1
            If grdBrand("salepercentage", index).Value = 0 Then
                grdBrand.Rows(index).DefaultCellStyle.BackColor = Color.Red
                vCount += 1
                Continue For
            End If
            If grdBrand("salepercentage", index).Value < PercMargin Then
                grdBrand.Rows(index).DefaultCellStyle.BackColor = Color.Orange
                vCount += 1
            End If
        Next
        lblBrandCount.Text = "Total: " & grdBrand.RowCount
        lblBelowBrand.Text = "Below " & PercMargin & "%: " & vCount
        lblAboveBrand.Text = "Above " & PercMargin & "%: " & grdBrand.RowCount - vCount

        vCount = 0
        For index = 0 To grdCategory.RowCount - 1
            If grdCategory("salepercentage", index).Value = 0 Then
                grdCategory.Rows(index).DefaultCellStyle.BackColor = Color.Red
                vCount += 1
                Continue For
            End If
            If grdCategory("salepercentage", index).Value < PercMargin Then
                grdCategory.Rows(index).DefaultCellStyle.BackColor = Color.Orange
                vCount += 1
            End If
        Next
        lblCategory.Text = "Total: " & grdCategory.RowCount
        lblBelowCategory.Text = "Below " & PercMargin & "%: " & vCount
        lblAbovecategory.Text = "Above " & PercMargin & "%: " & grdCategory.RowCount - vCount
    End Sub

    Function MakeCategorySizeWise(ByVal dtData As DataTable) As DataTable

        Dim dtOut As New DataTable
        dtOut.Columns.Add("Category")
        dtOut.Columns.Add("Size")
        dtOut.Columns.Add("Stock")
        dtOut.Columns.Add("Purchase")
        dtOut.Columns.Add("Sale")
        dtOut.Columns.Add("SalePerc", GetType(System.Double))

        Dim dvtmp As DataView
        dvtmp = New DataView(dtData)
        Dim dtGrp As DataTable
        dtGrp = dvtmp.ToTable(True, "Category", "alias")

        For index = 0 To dtGrp.Rows.Count - 1
            Dim dv As DataView
            dv = New DataView(dtData)
            dv.RowFilter = "Category='" & dtGrp.Rows(index)("Category") & "' and alias='" & dtGrp.Rows(index)("alias") & "'"
            dtOut.Rows.Add(dtGrp.Rows(index)("Category"), dtGrp.Rows(index)("alias"), dv.ToTable.Compute("sum(totUnitQty)", ""), dv.ToTable.Compute("sum(totNonMovableQty)", ""), dv.ToTable.Compute("sum(sale)", ""))
            dtOut.Rows(dtOut.Rows.Count - 1)("SalePerc") = Format((dtOut.Rows(dtOut.Rows.Count - 1)("Sale") / dtOut.Rows(dtOut.Rows.Count - 1)("Purchase")) * 100, "#.###")
        Next

        dtOut.DefaultView.Sort = "saleperc"
        Return dtOut.DefaultView.ToTable
    End Function

#End Region
    Private Sub btnok_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        BindGrid()
    End Sub

    Private Sub btnExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ObjDt = New DataTable
        ObjDt = DirectCast(grdBrand.DataSource, DataTable)
        ExportExcelTemplate(ObjDt)
    End Sub
    Dim arrReportName(0) As String
    Private Sub btnPdf_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click


        arrReportName(0) = "Slow Moving Brands Report"
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdBrand)
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
        ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile), IO.Path.GetFileNameWithoutExtension(SaveFile), arrReportName, grdBrand)
        frmSendReport.Show()
    End Sub

    Private Sub btnMailReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMailReport.Click
        SendReport()
    End Sub

    Private Sub frmSlowMovingBrands_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtFrom.Value = DateAdd("m", 0, DateSerial(Year(Today), Month(Today), 1))
        BindGrid()
        makeColor()
    End Sub
End Class