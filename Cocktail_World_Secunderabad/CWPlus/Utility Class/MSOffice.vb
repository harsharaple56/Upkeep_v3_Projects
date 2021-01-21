Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.OleDb
Imports System.Xml
Imports System.Xml.Xsl
Imports System.IO
Imports System.Web.UI
Imports Microsoft.Office.Interop

''' <summary>
''' Class For Office Excel
''' </summary>
''' <remarks></remarks>
Public Class ClsMsOffice

    Public Function ExportQV(ByVal filepath As String, ByVal filename As String, ByVal DTable As Data.DataTable) As String
        filepath = Directory.GetParent(filepath).FullName
        'ADD LICENSE ID 2 TABLE
        DTable.Columns.Add("LicenseID")
        For index = 0 To DTable.Rows.Count - 1
            DTable.Rows(index)("LicenseID") = gblLicenseID
        Next


        Dim Excel As Object = CreateObject("Excel.Application")
        Dim strFilename As String
        Dim intCol, intRow As Integer
        Dim strPath As String = filepath
        Dim errMessage As String = "Record Exported Sucessfully"
        Dim ErrorOccured As Boolean = False

        If Excel Is Nothing Then
            ErrorOccured = True
            errMessage = "An Error Occured"
            Return errMessage
        End If
        Try
            With Excel
                .SheetsInNewWorkbook = 1
                .Workbooks.Add()
                .Worksheets(1).Select()
                Dim intI As Integer = 1
                For intCol = 0 To DTable.Columns.Count - 1
                    Dim strCol As String = DTable.Columns(intCol).ColumnName
                    If Not (strCol = "inBottle" OrElse strCol = "inSpeg" OrElse strCol = "inGlass") Then
                        .cells(1, intI).Interior.Color = RGB(192, 192, 192)
                    End If
                    .cells(1, intI).value = strCol
                    .cells(1, intI).EntireRow.Font.Bold = True
                    intI += 1
                Next

                intI = 2
                Dim intK As Integer = 1
                For intCol = 0 To DTable.Columns.Count - 1
                    intI = 2
                    For intRow = 0 To DTable.Rows.Count - 1
                        Dim strCol As String = DTable.Columns(intCol).ColumnName
                        If Not (strCol = "inBottle" OrElse strCol = "inSpeg" OrElse strCol = "inGlass") Then
                            .Cells(intI, intK).Interior.Color = RGB(192, 192, 192)
                        End If

                        .Cells(intI, intK).Value = DTable.Rows(intRow).ItemArray(intCol)
                        If strCol = "Size" Then
                            If Not .cells(intI, intK).value.ToString.IndexOf("ML") > 0 Then
                                .cells(intI, intK).value = .cells(intI, intK).value.ToString & " ML"
                            End If
                        End If
                        intI += 1
                    Next
                    intK += 1
                Next
                If Mid$(strPath, strPath.Length, 1) <> "\" Then
                    strPath = strPath & "\"
                End If
                strFilename = strPath & filename
                .ActiveCell.Worksheet.SaveAs(strFilename)
            End With
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
            Excel = Nothing
            ErrorOccured = False
        Catch ex As Exception
            ErrorOccured = True
            errMessage = ex.Message
        End Try
        Process.Start(strFilename)
        Return errMessage
    End Function


    Public Sub ExportToExcelHTML(ByVal Exten As String, ByVal FilePath As String, ByVal FileName As String, ByVal Titles() As String, ByVal ParamArray srcGrid() As DataGridView)
        Dim fs As New FileStream(Path.Combine(FilePath, FileName & "." & Exten), FileMode.Create, FileAccess.Write)
        Dim swr As New StreamWriter(fs)
        Dim strwr As New StringWriter

        strwr.Write("<div width='95%' style='border:1px solid silver;margin:4px;padding:6px;width:95%;'>")
        strwr.Write("<style>table{font-family:verdana;font-size:14px;}</style>")
        Dim titleCounter As Integer = 0
        For Each grid As DataGridView In srcGrid
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim grd As New System.Web.UI.WebControls.DataGrid
            Dim dtLoc As DataTable = grid.ToDataTable("Out")
            grd.HeaderStyle.Font.Bold = True
            grd.HeaderStyle.BackColor = Color.Gray
            grd.DataSource = dtLoc
            grd.DataMember = dtLoc.TableName
            grd.DataBind()
            grd.BorderColor = Color.Silver
            sw.Write("<h2 style='color:navy;'><u>" & Titles(titleCounter).Replace(vbCrLf, "") & "</U></h2>")
            grd.RenderControl(hw)
            'REPLACE VBCRL (NEWLINE) WITH <BR />
            hw.InnerWriter.ToString.Replace(vbCrLf, "<br />")
            Dim sr As New StringReader(sw.ToString().Replace(vbCrLf, "<br />").Replace("</tr><br />", "</tr>").Replace("</td><br />", "</td>").Replace("<tr><br />", "<tr>").Replace("<tr style=" & ChrW(34) & "font-weight:bold;" & ChrW(34) & "><br />", "<tr style=" & ChrW(34) & "font-weight:bold;" & ChrW(34) & ">"))
            strwr.Write(sr.ReadToEnd & "<hr width='100%' style='width:100%;border-color:silver;'/>")
            titleCounter += 1
        Next
        strwr.Write("<br/></div><br/><br/>")
        swr.Write(strwr)
        swr.Flush()
        swr.Close()
        fs.Close()
    End Sub


    Property ExcelFormat() As Microsoft.Office.Interop.Excel.XlFileFormat
    Public Function ExportToExcel(ByVal filepath As String, ByVal filename As String, ByVal ParamArray DTable() As Data.DataTable) As String
        Dim Excel = CreateObject("Excel.Application")
        Dim strFilename As String
        Dim intCol, intRow As Integer
        Dim strPath As String = filepath
        Dim errMessage As String = "Record Exported Sucessfully"
        Dim ErrorOccured As Boolean = False
        Dim rwCtr As Integer
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


                For Each childDt As DataTable In DTable
                    .Worksheets(worksheetCtr).Select()

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
                            intK += 1
                        Next
                        intK = 1
                    Next
                    rwCtr += 3
                    worksheetCtr += 1
                Next
                .Worksheets(1).Select()
                '---------note updates for header in excel sheet by Abhijeet on 1st July 2016

                .Worksheets(1).PageSetup.CenterHeader = UCase(gblMenuDesc) & " " & "Report"
                .WorkSheets(1).PageSetup.LeftHeader = FrmCocktailReport.dtpCocktailReport.Text
                .WorkSheets(1).PageSetup.RightHeader = MDI.cmbLicenseName.Text.ToUpper()

                '---------note updates for header in excel sheet by Abhijeet on 1st July 2016


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

    Public Function ExportToExcelHeaderFooter(ByVal filepath As String, ByVal filename As String, ByVal StrLocHeader As String, ByVal ParamArray DTable() As Data.DataTable) As String
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

                .Worksheets(worksheetCtr).Select()


                .Cells(1, 1).value = Split(StrLocHeader, "#")(0)
                .Cells(1, 1).EntireRow.Font.Bold = True
                '.Cells(1, 1).EntireRow.Font.Color = RGB(255, 0, 0)
                .Cells(1, 1).EntireRow.Interior.Color = RGB(255, 255, 0)

                .Cells(1, 1).EntireRow.Font.Size = 16

                .Cells(2, 1).value = Split(StrLocHeader, "#")(1)
                .Cells(2, 1).EntireRow.Font.Bold = True
                .Cells(2, 1).EntireRow.Interior.Color = RGB(255, 255, 0)


                rwCtr = 4

                For intCol = 0 To childDt.Columns.Count - 1
                    .Cells(rwCtr, intCol + 1).value = childDt.Columns(intCol).ColumnName
                    .Cells(rwCtr, intCol + 1).EntireRow.Font.Bold = True
                    .Cells(rwCtr, intCol + 1).Interior.ColorIndex = 8
                Next

                Dim intK As Integer = 1
                For intRow = 0 To childDt.Rows.Count - 1
                    rwCtr += 1
                    For intCol = 0 To childDt.Columns.Count - 1
                        .Cells(rwCtr, intK).Value = childDt.Rows(intRow).ItemArray(intCol)
                        .Cells(rwCtr, intCol + 1).Interior.ColorIndex = 34
                        '.Cells(rwCtr, intCol + 1).Interior.ColorIndex = intK
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
                    .ActiveCell.Worksheet.SaveAs(strFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlAddIn8)
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

    Public Function ExportToExcelHeaderFooterEval(ByVal filepath As String, ByVal filename As String, ByVal StrLocHeader As String, ByVal DTable As Data.DataSet) As String
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
                .SheetsInNewWorkbook = DTable.Tables.Count
                .Workbooks.Add()

                'SET EXCEL HEADER
                For i As Integer = 1 To DTable.Tables.Count
                    childDt = DTable.Tables(i - 1)

                    .Worksheets(i).Select()


                    .Cells(1, 1).value = StrLocHeader
                    .Cells(1, 1).EntireRow.Font.Bold = True
                    '.Cells(1, 1).EntireRow.Font.Color = RGB(255, 0, 0)
                    ''.Cells(1, 1).EntireRow.Interior.Color = RGB(255, 255, 0) by Bhalya

                    .Cells(1, 1).EntireRow.Font.Size = 16

                    '.Cells(2, 1).value = Split(StrLocHeader, "#")(1) by Bhalya 
                    .Cells(2, 1).EntireRow.Font.Bold = True
                    '.Cells(2, 1).EntireRow.Interior.Color = RGB(255, 255, 0) by Bhalya


                    rwCtr = 4

                    For intCol = 0 To childDt.Columns.Count - 1
                        .Cells(rwCtr, intCol + 1).value = childDt.Columns(intCol).ColumnName
                        .Cells(rwCtr, intCol + 1).EntireRow.Font.Bold = True
                        '.Cells(rwCtr, intCol + 1).Interior.ColorIndex = 8  by Bhalya
                    Next

                    Dim intK As Integer = 1
                    For intRow = 0 To childDt.Rows.Count - 1
                        rwCtr += 1
                        For intCol = 0 To childDt.Columns.Count - 1
                            .Cells(rwCtr, intK).Value = childDt.Rows(intRow).ItemArray(intCol)
                            '.Cells(rwCtr, intCol + 1).Interior.ColorIndex = 34  by Bhalya
                            '.Cells(rwCtr, intCol + 1).Interior.ColorIndex = intK
                            intK += 1
                        Next
                        intK = 1
                    Next
                    rwCtr += 3

                    .Worksheets(i).Select()
                Next
                If Mid$(strPath, strPath.Length, 1) <> "\" Then
                    strPath = strPath & "\"
                End If
                strFilename = strPath & filename


                If Trim(Path.GetExtension(filename)) = ".xlsx" Then
                    .ActiveCell.Worksheet.SaveAs(strFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8)
                ElseIf Trim(Path.GetExtension(filename)) = ".xls" Then
                    .ActiveCell.Worksheet.SaveAs(strFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlAddIn8)
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

    Public Function ExportToExcelHeaderFooter11(ByVal filepath As String, ByVal filename As String, ByVal StrLocHeader As String, ByVal ParamArray DTable() As Data.DataTable) As String
        Dim Excel = CreateObject("Excel.Application")
        Dim strFilename As String
        Dim intCol, intRow As Integer
        Dim strPath As String = filepath
        Dim errMessage As String = "Record Exported Sucessfully"
        Dim ErrorOccured As Boolean = False
        Dim rwCtr As Integer
        Dim childDtSaleCostNonPro, childDtSaleCostPro, ColDtsaleCost, childDtSaleNonPro, childDtSalePro, ColDtSale, childDtCostNonPro, childDtCostPro, ColDtCost As New DataTable
        If Excel Is Nothing Then
            ErrorOccured = True
            errMessage = "An Error Occured"
            Return errMessage
        End If
        Try
            Dim worksheetCtr As Integer = 1

            With Excel
                .SheetsInNewWorkbook = 3
                .Workbooks.Add()

                'SET EXCEL HEADER

                childDtSaleCostNonPro = DTable(0)

                childDtSaleCostPro = DTable(1)

                ColDtsaleCost = DTable(2)

                childDtSaleNonPro = DTable(3)
                childDtSalePro = DTable(4)
                ColDtSale = DTable(5)
                childDtCostNonPro = DTable(6)
                childDtCostPro = DTable(7)
                ColDtCost = DTable(8)

                'A&G Summery with sale and Cost

                .Worksheets(1).Select()

                'For intRow = 0 To ColDt.Rows.Count - 1
                '    .Cells(1, intRow + 1).value = ColDt.Rows(intRow)(1)
                '    .Cells(1, intRow + 1).EntireRow.Font.Bold = True
                'Next

                For intRow = 2 To ColDtsaleCost.Rows.Count - 1
                    .Cells(1, intRow + 1).value = ColDtsaleCost.Rows(intRow)(1)
                    .Cells(1, intRow + 1).EntireRow.Font.Bold = True
                    intRow = intRow + 2
                Next

                For intRow = 1 To ColDtsaleCost.Rows.Count - 1
                    .Cells(1, intRow + 1).Interior.ColorIndex = 34
                    .Cells(1, intRow + 2).Interior.ColorIndex = 34
                    .Cells(1, intRow + 3).Interior.ColorIndex = 34

                    'Dim xRng As Excel.Range = CType(Excel.Cells(1, intRow + 3), Excel.Range)
                    'Dim val As Object = xRng.Value()
                    '.Worksheets(1).Range(val).MergeCells = True

                    intRow = intRow + 5
                Next

                For intRow = 0 To ColDtsaleCost.Rows.Count - 1
                    .Cells(2, intRow + 1).value = ColDtsaleCost.Rows(intRow)(2)
                    .Cells(2, intRow + 1).EntireRow.Font.Bold = True
                Next

                For intRow = 1 To ColDtsaleCost.Rows.Count - 1
                    .Cells(2, intRow + 1).Interior.ColorIndex = 34
                    .Cells(2, intRow + 2).Interior.ColorIndex = 34
                    .Cells(2, intRow + 3).Interior.ColorIndex = 34
                    intRow = intRow + 5
                Next

                .Cells(3, 1).value = "Non-Promotional"
                .Cells(3, 1).EntireRow.Font.Bold = True
                .Cells(3, 1).EntireRow.Borders.LineStyle = 1

                'Non-Promotional block
                rwCtr = 3

                For intRow = 0 To childDtSaleCostNonPro.Rows.Count - 1
                    rwCtr = rwCtr + 1
                    For icolomns As Integer = 0 To childDtSaleCostNonPro.Columns.Count - 1
                        .Cells(rwCtr, icolomns + 1).value = childDtSaleCostNonPro.Rows(intRow)(icolomns)
                        .Cells(rwCtr, icolomns + 1).Borders.LineStyle = 2
                    Next
                Next

                .Cells(rwCtr, 1).EntireRow.Font.Bold = True

                'Promotional block
                rwCtr = rwCtr + 2

                .Cells(rwCtr, 1).value = "Promotional"
                .Cells(rwCtr, 1).EntireRow.Font.Bold = True


                For intRow = 0 To childDtSaleCostPro.Rows.Count - 1
                    rwCtr = rwCtr + 1
                    For icolomns As Integer = 0 To childDtSaleCostPro.Columns.Count - 1
                        .Cells(rwCtr, icolomns + 1).value = childDtSaleCostPro.Rows(intRow)(icolomns)
                        .Cells(rwCtr, icolomns + 1).Borders.LineStyle = 2
                    Next
                Next

                .Cells(rwCtr - 1, 1).EntireRow.Font.Bold = True
                .Cells(rwCtr, 1).EntireRow.Font.Bold = True

                .Cells(rwCtr - 1, 1).EntireRow.Borders.LineStyle = 1
                .Cells(rwCtr, 1).EntireRow.Borders.LineStyle = 1


                'A&G Summery with sale
                .Worksheets(2).Select()

                For intRow = 2 To ColDtSale.Rows.Count - 1
                    .Cells(1, intRow + 1).value = ColDtSale.Rows(intRow)(1)
                    .Cells(1, intRow + 1).EntireRow.Font.Bold = True
                    intRow = intRow + 2
                Next

                For intRow = 1 To ColDtSale.Rows.Count - 1
                    .Cells(1, intRow + 1).Interior.ColorIndex = 34
                    .Cells(1, intRow + 2).Interior.ColorIndex = 34
                    .Cells(1, intRow + 3).Interior.ColorIndex = 34



                    intRow = intRow + 5
                Next

                For intRow = 0 To ColDtSale.Rows.Count - 1
                    .Cells(2, intRow + 1).value = ColDtSale.Rows(intRow)(2)
                    .Cells(2, intRow + 1).EntireRow.Font.Bold = True
                Next

                For intRow = 1 To ColDtSale.Rows.Count - 1
                    .Cells(2, intRow + 1).Interior.ColorIndex = 34
                    .Cells(2, intRow + 2).Interior.ColorIndex = 34
                    .Cells(2, intRow + 3).Interior.ColorIndex = 34
                    intRow = intRow + 5
                Next

                .Cells(3, 1).value = "Non-Promotional"
                .Cells(3, 1).EntireRow.Font.Bold = True
                .Cells(3, 1).EntireRow.Borders.LineStyle = 1

                'Non-Promotional block
                rwCtr = 3

                For intRow = 0 To childDtSaleNonPro.Rows.Count - 1
                    rwCtr = rwCtr + 1
                    For icolomns As Integer = 0 To childDtSaleNonPro.Columns.Count - 1
                        .Cells(rwCtr, icolomns + 1).value = childDtSaleNonPro.Rows(intRow)(icolomns)
                        .Cells(rwCtr, icolomns + 1).Borders.LineStyle = 2
                    Next
                Next

                .Cells(rwCtr, 1).EntireRow.Font.Bold = True

                'Promotional block
                rwCtr = rwCtr + 2

                .Cells(rwCtr, 1).value = "Promotional"
                .Cells(rwCtr, 1).EntireRow.Font.Bold = True


                For intRow = 0 To childDtSalePro.Rows.Count - 1
                    rwCtr = rwCtr + 1
                    For icolomns As Integer = 0 To childDtSalePro.Columns.Count - 1
                        .Cells(rwCtr, icolomns + 1).value = childDtSalePro.Rows(intRow)(icolomns)
                        .Cells(rwCtr, icolomns + 1).Borders.LineStyle = 2
                    Next
                Next

                .Cells(rwCtr - 1, 1).EntireRow.Font.Bold = True
                .Cells(rwCtr, 1).EntireRow.Font.Bold = True

                .Cells(rwCtr - 1, 1).EntireRow.Borders.LineStyle = 1
                .Cells(rwCtr, 1).EntireRow.Borders.LineStyle = 1


                'A&G Summery with cost
                .Worksheets(3).Select()

                For intRow = 2 To ColDtCost.Rows.Count - 1
                    .Cells(1, intRow + 1).value = ColDtCost.Rows(intRow)(1)
                    .Cells(1, intRow + 1).EntireRow.Font.Bold = True
                    intRow = intRow + 2
                Next

                For intRow = 1 To ColDtCost.Rows.Count - 1
                    .Cells(1, intRow + 1).Interior.ColorIndex = 34
                    .Cells(1, intRow + 2).Interior.ColorIndex = 34
                    .Cells(1, intRow + 3).Interior.ColorIndex = 34



                    intRow = intRow + 5
                Next

                For intRow = 0 To ColDtCost.Rows.Count - 1
                    .Cells(2, intRow + 1).value = ColDtCost.Rows(intRow)(2)
                    .Cells(2, intRow + 1).EntireRow.Font.Bold = True
                Next

                For intRow = 1 To ColDtCost.Rows.Count - 1
                    .Cells(2, intRow + 1).Interior.ColorIndex = 34
                    .Cells(2, intRow + 2).Interior.ColorIndex = 34
                    .Cells(2, intRow + 3).Interior.ColorIndex = 34
                    intRow = intRow + 5
                Next

                .Cells(3, 1).value = "Non-Promotional"
                .Cells(3, 1).EntireRow.Font.Bold = True
                .Cells(3, 1).EntireRow.Borders.LineStyle = 1

                'Non-Promotional block
                rwCtr = 3

                For intRow = 0 To childDtCostNonPro.Rows.Count - 1
                    rwCtr = rwCtr + 1
                    For icolomns As Integer = 0 To childDtCostNonPro.Columns.Count - 1
                        .Cells(rwCtr, icolomns + 1).value = childDtCostNonPro.Rows(intRow)(icolomns)
                        .Cells(rwCtr, icolomns + 1).Borders.LineStyle = 2
                    Next
                Next

                .Cells(rwCtr, 1).EntireRow.Font.Bold = True

                'Promotional block
                rwCtr = rwCtr + 2

                .Cells(rwCtr, 1).value = "Promotional"
                .Cells(rwCtr, 1).EntireRow.Font.Bold = True


                For intRow = 0 To childDtCostPro.Rows.Count - 1
                    rwCtr = rwCtr + 1
                    For icolomns As Integer = 0 To childDtCostPro.Columns.Count - 1
                        .Cells(rwCtr, icolomns + 1).value = childDtCostPro.Rows(intRow)(icolomns)
                        .Cells(rwCtr, icolomns + 1).Borders.LineStyle = 2
                    Next
                Next

                .Cells(rwCtr - 1, 1).EntireRow.Font.Bold = True
                .Cells(rwCtr, 1).EntireRow.Font.Bold = True

                .Cells(rwCtr - 1, 1).EntireRow.Borders.LineStyle = 1
                .Cells(rwCtr, 1).EntireRow.Borders.LineStyle = 1

                .Worksheets(1).Select()

                If Mid$(strPath, strPath.Length, 1) <> "\" Then
                    strPath = strPath & "\"
                End If
                strFilename = strPath & filename


                If Trim(Path.GetExtension(filename)) = ".xlsx" Then
                    .ActiveCell.Worksheet.SaveAs(strFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8)
                ElseIf Trim(Path.GetExtension(filename)) = ".xls" Then
                    .ActiveCell.Worksheet.SaveAs(strFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlAddIn8)
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


    Public Function ExportToExcelLicensewiseSummary(ByVal filepath As String, ByVal filename As String, ByVal StrLocHeader As String, ByVal ParamArray DTable() As Data.DataTable) As String
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
                For intCol = 0 To 1
                    childDt.Columns(0).ColumnName = "Brand Name"
                    childDt.Columns(1).ColumnName = "Size"
                Next

                .Worksheets(worksheetCtr).Select()


                .Cells(1, 1).value = Split(StrLocHeader, "#")(0)
                .Cells(1, 1).EntireRow.Font.Bold = True
                '.Cells(1, 1).EntireRow.Font.Color = RGB(255, 0, 0)
                .Range(Excel.Cells(1, 1), Excel.Cells(1, childDt.Columns.Count)).Merge()

                .Cells(1, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                '.ActiveSheet.Range("A1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

                .Cells(1, 1).EntireRow.Font.Size = 16

                .Cells(2, 1).value = Split(StrLocHeader, "#")(1)
                .Cells(2, 1).EntireRow.Font.Bold = True
                .Cells(2, 1).EntireRow.Font.Size = 13
                .Range(Excel.Cells(2, 1), Excel.Cells(2, childDt.Columns.Count)).Merge()
                .Cells(2, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                '.Cells(2, 1).Interior.Color = RGB(255, 255, 0)


                rwCtr = 4

                For intCol = 0 To childDt.Columns.Count - 1
                    .Cells(rwCtr, intCol + 1).value = childDt.Columns(intCol).ColumnName
                    .Cells(rwCtr, intCol + 1).EntireRow.Font.Bold = True
                    .Cells(rwCtr, intCol + 1).Interior.ColorIndex = 8

                Next

                Dim intK As Integer = 1
                For intRow = 0 To childDt.Rows.Count - 1
                    rwCtr += 1
                    For intCol = 0 To childDt.Columns.Count - 1
                        .Cells(rwCtr, intK).Value = "'" & childDt.Rows(intRow).ItemArray(intCol)
                        .Cells(rwCtr, intCol + 1).Interior.ColorIndex = 34
                        '.Cells(rwCtr, intCol + 1).Interior.ColorIndex = intK
                        .cells(rwCtr, intCol + 1).EntireColumn.AutoFit()
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
                    .ActiveCell.Worksheet.SaveAs(strFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlAddIn8)
                End If
                '.ActiveCell.Worksheet.SaveAs(strFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8)

            End With
            Excel.Visible = True
            Excel.UserControl = True
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
End Class



Public Class ExcelReader

    Private path As String
    Private strConnection As String


    Public Sub New(ByVal path As String, ByVal hasHeaders As Boolean, ByVal hasMixedData As Boolean)
        Me.path = path
        Dim strBuilder As New OleDbConnectionStringBuilder()
        If IO.Path.GetExtension(path).ToLower = ".xls" Then
            'strBuilder.Provider = "Microsoft.Jet.OLEDB.4.0"
            strBuilder.Provider = "Microsoft.ACE.OLEDB.12.0"
        Else
            strBuilder.Provider = "Microsoft.ACE.OLEDB.12.0"
        End If
        strBuilder.DataSource = path
        strBuilder.Add("Extended Properties", "Excel 8.0;" & "HDR=" & (If(hasHeaders, "Yes", "No")) & ";"c & "Imex=" & (If(hasMixedData, "2", "0")) & ";"c & "")
        strConnection = strBuilder.ToString()
    End Sub

    Public Function GetWorksheetList() As String()
        Dim worksheets As String()

        Try
            Dim connection As New OleDbConnection(strConnection)
            connection.Open()
            Dim tableWorksheets As DataTable = connection.GetSchema("Tables")
            connection.Close()

            worksheets = New String(tableWorksheets.Rows.Count - 1) {}

            For i As Integer = 0 To worksheets.Length - 1
                worksheets(i) = DirectCast(tableWorksheets.Rows(i)("TABLE_NAME"), String)
                worksheets(i) = worksheets(i).Remove(worksheets(i).Length - 1).Trim(""""c, "'"c)
                ' removes the trailing $ and other characters appended in the table name
                While worksheets(i).EndsWith("$")
                    worksheets(i) = worksheets(i).Remove(worksheets(i).Length - 1).Trim(""""c, "'"c)
                End While
            Next
        Catch
            Throw
        End Try

        Return worksheets
    End Function

    Public Function GetColumnsList(ByVal worksheet As String) As String()
        Dim columns As String()

        Try
            Dim connection As New OleDbConnection(strConnection)
            connection.Open()
            Dim tableColumns As DataTable = connection.GetSchema("Columns", New String() {Nothing, Nothing, worksheet & "$"c, Nothing})
            connection.Close()

            columns = New String(tableColumns.Rows.Count - 1) {}

            For i As Integer = 0 To columns.Length - 1
                columns(i) = DirectCast(tableColumns.Rows(i)("COLUMN_NAME"), String)
            Next
        Catch
            Throw
        End Try

        Return columns
    End Function

    Public Function GetWorksheet(ByVal worksheet As String) As DataTable
        Dim ws As DataTable

        Dim connection As New OleDbConnection(strConnection)
        Dim adaptor As New OleDbDataAdapter([String].Format("SELECT * FROM [{0}$]", worksheet), connection)
        ws = New DataTable(worksheet)
        adaptor.FillSchema(ws, SchemaType.Source)
        adaptor.Fill(ws)

        adaptor.Dispose()
        connection.Close()

        Return ws
    End Function

    Public Function GetWorkplace() As DataSet
        Dim workplace As DataSet

        Dim connection As New OleDbConnection(strConnection)
        Dim adaptor As New OleDbDataAdapter("SELECT * FROM *", connection)
        workplace = New DataSet()
        adaptor.FillSchema(workplace, SchemaType.Source)
        adaptor.Fill(workplace)

        adaptor.Dispose()
        connection.Close()

        Return workplace
    End Function
End Class


