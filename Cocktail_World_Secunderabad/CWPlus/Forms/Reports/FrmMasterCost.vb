Imports System.Xml
Imports System.IO
Imports CWPlusBL.Master

Public Class FrmMasterCost

    Dim objCocktail As New CWPlusBL.Master.ClsCocktailReports
    Dim ObjPriDs As DataSet
    Dim ObjBrandDt, ObjCatgDt, ObjDt As DataTable
    Dim ObjCategory As CWPlusBL.Master.ClsCategory
    Dim ObjBrand As CWPlusBL.Master.ClsBrandHeadDet
    Dim Objpurchase As CWPlusBL.Master.Clspurchase
    Dim ObjCategorySizeLnkUp As CWPlusBL.Master.ClsCategorySizelinlup


#Region "Button click"
    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        BindGrid()
    End Sub
#End Region

#Region "Procedures"
    Public Sub BindGrid()
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<CWPLUS><AllLicense></AllLicense></CWPLUS>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
        Try
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)
            If gblArrMDICheckedLicense.Count = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
            gblArrMDICheckedLicense.Clear()
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)
            For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                XmlElt = xmldoc.CreateElement("License")
                XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cntr))
                xmldoc.DocumentElement.Item("AllLicense").AppendChild(XmlElt)
            Next

            ObjBrandDt = New DataTable
            objCocktail = New CWPlusBL.Master.ClsCocktailReports
            objCocktail.CocktailReportXml = xmldoc
            objCocktail.FromDate = dtFrom.Value
            objCocktail.ToDate = dtTo.Value
            objCocktail.BrandID = cmbBrandName.SelectedValue
            objCocktail.CategoryID = Cmbcategory.SelectedValue
            objCocktail.SubCategoryID = cmbSubCategory.SelectedValue
            objCocktail.SizeID = cmbSize.SelectedValue
            If chkInML.Checked Then
                objCocktail.isML = 1
            Else
                objCocktail.isML = 0
            End If
            If rdbAvgCost.Checked Then
                objCocktail.CostType = "A"
            Else
                objCocktail.CostType = "M"
            End If

            ObjBrandDt = objCocktail.FunFetchCostEvaluationReportv2
            grdBrandwise.DataSource = Nothing
            grdBrandwise.DataSource = ObjBrandDt

            

            If gblArrMDICheckedLicense.Count > 1 Then
                grdBrandwise.Columns("BaseQty").Visible = False
                grdBrandwise.Columns("OptimumLevel").Visible = False
                grdBrandwise.Columns("ExcessQty").Visible = False

            Else
                For index = 0 To grdBrandwise.RowCount - 1
                    If grdBrandwise("color", index).Value = "Red" Then
                        'grdBrandwise.Rows(index).DefaultCellStyle.BackColor = Color.MediumVioletRed
                        grdBrandwise.Rows(index).Cells("ExcessQty").Style.BackColor = Color.MediumVioletRed
                    ElseIf grdBrandwise("color", index).Value = "Green" Then
                        'grdBrandwise.Rows(index).DefaultCellStyle.BackColor = Color.LawnGreen
                        grdBrandwise.Rows(index).Cells("ExcessQty").Style.BackColor = Color.LawnGreen
                    End If
                Next
            End If

            grdBrandwise.Columns("color").Visible = False
            grdBrandwise.Columns(0).Frozen = True
            grdBrandwise.Columns(1).Frozen = True
            grdBrandwise.Columns(2).Frozen = True
            grdBrandwise.Columns(3).Frozen = True
            grdBrandwise.AutoResizeColumns()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click


        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<CWPLUS><AllLicense></AllLicense></CWPLUS>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
        Try
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)
            If gblArrMDICheckedLicense.Count = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
            gblArrMDICheckedLicense.Clear()
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)
            For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                XmlElt = xmldoc.CreateElement("License")
                XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cntr))
                xmldoc.DocumentElement.Item("AllLicense").AppendChild(XmlElt)
            Next

            ObjBrandDt = New DataTable
            objCocktail = New CWPlusBL.Master.ClsCocktailReports
            objCocktail.CocktailReportXml = xmldoc
            objCocktail.FromDate = dtFrom.Value
            objCocktail.ToDate = dtTo.Value
            If chkInML.Checked Then
                objCocktail.isML = 1
            Else
                objCocktail.isML = 0
            End If
            If rdbAvgCost.Checked Then
                objCocktail.CostType = "A"
            Else
                objCocktail.CostType = "M"
            End If
            ObjBrandDt = objCocktail.FunFetchCostEvaluationReportv2
            Dim dlgSaveFile As New SaveFileDialog
            dlgSaveFile.DefaultExt = ".xls"
            dlgSaveFile.Filter = "Excel Files (*.xls) | *.xls"
            If dlgSaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                If IO.File.Exists(dlgSaveFile.FileName) Then
                    IO.File.Delete(dlgSaveFile.FileName)
                End If

                'ExportExcelTemplate(grdBrandwise.DataSource)
                ExportToExcelHeaderFooter(IO.Path.GetDirectoryName(dlgSaveFile.FileName), IO.Path.GetFileName(dlgSaveFile.FileName), ObjBrandDt)
                Dim dlgRes As DialogResult
                dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dlgRes = Windows.Forms.DialogResult.Yes Then
                    Process.Start(dlgSaveFile.FileName)
                End If
            End If
            'Process.Start(IO.Path.GetTempPath & "\costreport.xls")


        Catch ex As Exception
            Throw ex
        End Try
        
    End Sub

    Dim arrReportName(0) As String
    Private Sub btnPdf_Click(sender As System.Object, e As System.EventArgs) Handles btnPdf.Click
        arrReportName(0) = "Cost valuation from " & Format(dtFrom.Value, "dd-MMM-yyyy") & "-" & Format(dtTo.Value, "dd-MMM-yyyy")
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdBrandwise)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub

    Private Sub btnMailReport_Click(sender As System.Object, e As System.EventArgs) Handles btnMailReport.Click
        SendReport()
    End Sub

    Public Sub SendReport()
        Try
            arrReportName(0) = "Cost valuation from " & Format(dtFrom.Value, "dd-MMM-yyyy") & "-" & Format(dtTo.Value, "dd-MMM-yyyy")
            Dim SaveFile As String = Application.StartupPath & "\CW_Report.pdf"
            If IO.File.Exists(SaveFile) Then
                IO.File.Delete(SaveFile)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile), IO.Path.GetFileNameWithoutExtension(SaveFile), arrReportName, grdBrandwise)
            frmSendReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Function ExportToExcelHeaderFooter(ByVal filepath As String, ByVal filename As String, ByVal ParamArray DTable() As Data.DataTable) As String
        Dim Excel = CreateObject("Excel.Application")
        Dim strFilename As String
        Dim intCol, intRow As Integer
        Dim strPath As String = filepath
        Dim errMessage As String = "Record Exported Sucessfully"
        Dim ErrorOccured As Boolean = False
        Dim rwCtr As Integer
        Dim childDt As New DataTable
        If Excel Is Nothing Then
            ErrorOccured = True
            errMessage = "An Error Occured"
            Return errMessage
        End If
        Try
            Dim worksheetCtr As Integer = 1

            With Excel
                .SheetsInNewWorkbook = DTable.Length
                .Workbooks.Add()

                'SET EXCEL HEADER

                childDt = DTable(0)
                'childDt.Columns.Remove("color")    
                .Worksheets(worksheetCtr).Select()

                '.Cells(1, 1).value = Split(StrLocHeader, "#")(0)
                '.Cells(1, 1).EntireRow.Font.Bold = True
                ''.Cells(1, 1).EntireRow.Font.Color = RGB(255, 0, 0)
                '.Cells(1, 1).EntireRow.Interior.Color = RGB(255, 255, 0)

                '.Cells(1, 1).EntireRow.Font.Size = 16

                '.Cells(2, 1).value = Split(StrLocHeader, "#")(1)
                '.Cells(2, 1).EntireRow.Font.Bold = True
                '.Cells(2, 1).EntireRow.Interior.Color = RGB(255, 255, 0)


                rwCtr = 1

                For intCol = 0 To childDt.Columns.Count - 1
                    .Cells(rwCtr, intCol + 1).value = childDt.Columns(intCol).ColumnName
                    .Cells(rwCtr, intCol + 1).EntireRow.Font.Bold = True
                Next

                Dim intK As Integer = 1
                For intRow = 0 To childDt.Rows.Count - 1
                    rwCtr += 1
                    For intCol = 0 To childDt.Columns.Count - 1
                        .Cells(rwCtr, intK).Value = childDt.Rows(intRow).ItemArray(intCol)
                        If childDt.Columns(intCol).ColumnName = "ExcessQty" And childDt.Rows(intRow)("Color") = "Red" Then
                            .Cells(rwCtr, intCol + 1).Interior.ColorIndex = 3
                        ElseIf childDt.Columns(intCol).ColumnName = "ExcessQty" And childDt.Rows(intRow)("Color") = "Green" Then
                            .Cells(rwCtr, intCol + 1).Interior.ColorIndex = 4
                        End If
                        'ElseIf childDt.Rows(intRow)("color") = "green" Then
                        'If childDt.Columns(intCol).ColumnName = "ExcessQty" Then
                        '.Cells(rwCtr, intCol + 1).Interior.ColorIndex = 4
                        'End If
                        'End If
                        intK += 1
                    Next
                    intK = 1
                Next
                rwCtr += 3

                .Worksheets(1).Select()

                If Mid$(strPath, strPath.Length, 1) <> "\" Then
                    strPath = strPath & "\"
                End If
                strFilename = strPath & filename


                If Trim(Path.GetExtension(filename)) = ".xlsx" Then
                    .ActiveCell.Worksheet.SaveAs(strFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8)
                ElseIf Trim(Path.GetExtension(filename)) = ".xls" Then
                    .ActiveCell.Worksheet.SaveAs(strFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8)
                End If
                '.ActiveCell.Worksheet.SaveAs(strFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8)

            End With
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel.ActiveWorkbook)
            Excel.ActiveWorkbook.Close()
            Excel.Quit()
            Excel = Nothing
            ErrorOccured = False
        Catch ex As Exception
            ErrorOccured = True
            errMessage = ex.Message
        End Try
        ' The excel is created and opened for insert value. We most close this excel using this system
        Dim pro() As Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each i As Process In pro
            i.Kill()
        Next
        Return errMessage
    End Function

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

    Private Sub BindSize(ByVal brandid As Double)
        Objpurchase = New CWPlusBL.Master.Clspurchase
        Dim ds As New DataSet
        Try

            If MDI.cmbLicenseName.SelectedValue = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
            Objpurchase.BrandID = cmbBrandName.SelectedValue
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            ds = Objpurchase.BindSizes
            ComboBindingTemplate(cmbSize, ds.Tables(0), "alias", "CategorySizeLinkUpID")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
        End Try

    End Sub

    Public Sub FetchCategorySizeLinkUp()
        Try
            If MDI.cmbLicenseName.SelectedValue = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
            ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
            ObjDt = New DataTable
            ObjCategorySizeLnkUp.CategoryID = Cmbcategory.SelectedValue
            ObjCategorySizeLnkUp.LicenseID = MDI.cmbLicenseName.SelectedValue

            ObjDt = ObjCategorySizeLnkUp.FunFetch
            ComboBindingTemplate(cmbSize, ObjDt, "alias", "CategorySizeLinkID")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    Public Sub FetchSubCategory()
        Dim ObjSubCategory As New ClsSubCategoryMaster
        Dim dt As New DataTable
        Try
            ObjSubCategory.CategoryID = cmbCategory.SelectedValue
            dt = ObjSubCategory.FunFetchSubCategoryMaster

            cmbSubCategory.DataSource = Nothing
            ComboBindingTemplate(cmbSubCategory, dt, "SubCategoryName", "SubCategoryid")

            'FetchSelectValues()

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(ObjCategory) Then
                ObjCategory = Nothing
            End If
            If Not IsNothing(dt) Then
                dt = Nothing
            End If
        End Try

    End Sub

    Private Sub FrmMasterCost_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindCategory()
        FetchSubCategory()
        BindBrand(0)
    End Sub


    Private Sub cmbBrandName_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbBrandName.SelectedIndexChanged
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf (cmbBrandName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        BindSize(cmbBrandName.SelectedValue)
    End Sub

    Private Sub Cmbcategory_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Cmbcategory.SelectedIndexChanged
        cmbBrandName.SelectedValue = 0
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf (Cmbcategory.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If cmbBrandName.SelectedValue = 0 Then
            FetchCategorySizeLinkUp()
        End If

        FetchSubCategory()
    End Sub
End Class