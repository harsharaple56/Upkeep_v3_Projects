Imports CWPlusBL.Marriot
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.OleDb
Imports System.Xml
Imports System.Xml.Xsl
Imports System.IO
Imports System.Web.UI
Imports System.Text.RegularExpressions

Public Class FrmDCC_REPORTMR
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice
    Dim StrPriHeaderFooter As String = ""

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Fromdate = Format(DtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
            ObjCls.UserName = gblUserName
            ObjPriDt = ObjCls.FunFetchDCCReport()
            StrPriHeaderFooter = ObjCls.ErrorMsg
            grdDCCReport.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            ObjExp = New ClsMsOffice
            ObjPriDt = DirectCast(grdDCCReport.DataSource, DataTable)
            ObjExp.ExportToExcelHeaderFooter(IO.Path.GetTempPath, "temp.xls", StrPriHeaderFooter, ObjPriDt)
            Process.Start(IO.Path.GetTempPath & "\temp.xls")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub




    'Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    '    'ImportFile()


    '    'Dim ObjPriDs As DataSet
    '    'ObjCls = New ClsReports
    '    'ObjCls.Fromdate = Format(DtFromDate.Value, "dd-MMM-yyyy")
    '    'ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
    '    'ObjCls.IsDept = 0


    '    'ObjPriDs = ObjCls.FunFetchNonPromotionalMealSummary()
    '    'ExportToExcelHeaderFooter11(IO.Path.GetTempPath, "temp.xls", "Bhalya", ObjPriDs.Tables(0), ObjPriDs.Tables(1), ObjPriDs.Tables(2))
    '    'Process.Start(IO.Path.GetTempPath & "\temp.xls")
    'End Sub




    Private Sub ImportFile()
        Dim opnflDlg As New OpenFileDialog
        If opnflDlg.ShowDialog = DialogResult.OK Then
            Dim Filename As String = opnflDlg.FileName
            Dim safeFileName As String = Path.GetFileName(Filename)
            Dim dataLines() As String = File.ReadAllLines(Filename)
            Dim body As String
            body = ""
            For index = 0 To dataLines.Length - 1
                body = body & dataLines(index)
            Next

            Dim ds As DataSet = ConvertHTMLTablesToDataSet(body)

            For irows As Integer = 0 To ds.Tables(2).Rows.Count - 2
                For icolomns As Integer = 0 To ds.Tables(2).Columns.Count - 1

                    If Not IsDBNull(ds.Tables(2).Rows(irows)(icolomns)) Then
                        ds.Tables(2).Rows(irows)(icolomns) = Regex.Replace(ds.Tables(2).Rows(irows)(icolomns), "<(.|\n)+?>", "")
                        ds.Tables(2).Rows(irows)(icolomns) = Regex.Replace(ds.Tables(2).Rows(irows)(icolomns), "&nbsp;", "")
                    End If
                Next
            Next

            Dim maindt As DataTable = ds.Tables(2)

            For icolomns As Integer = 0 To ds.Tables(2).Columns.Count - 1
                maindt.Columns(icolomns).ColumnName = maindt.Rows(0)(icolomns)

            Next
            maindt.Rows(0).Delete()
            maindt.Rows(maindt.Rows.Count - 1).Delete()


        End If
    End Sub

    'Private Function ConvertHTMLTablesToDataSet(ByVal HTML As String) As DataSet
    '    ' Declarations  
    '    Dim ds As New DataSet
    '    Dim dt As DataTable
    '    Dim dr As DataRow
    '    Dim dc As DataColumn
    '    Dim TableExpression As String = "<table[^>]*>(.*?)</table>"
    '    Dim HeaderExpression As String = "<th[^>]*>(.*?)</th>"
    '    Dim RowExpression As String = "<tr[^>]*>(.*?)</tr>"
    '    Dim ColumnExpression As String = "<td[^>]*>(.*?)</td>"
    '    Dim HeadersExist As Boolean = False
    '    Dim iCurrentColumn As Integer = 0
    '    Dim iCurrentRow As Integer = 0

    '    ' Get a match for all the tables in the HTML  
    '    Dim Tables As MatchCollection = Regex.Matches(HTML, TableExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

    '    ' Loop through each table element  
    '    For Each Table As Match In Tables

    '        ' Reset the current row counter and the header flag  
    '        iCurrentRow = 0
    '        HeadersExist = False

    '        ' Add a new table to the DataSet  
    '        dt = New DataTable

    '        ' Create the relevant amount of columns for this table (use the headers if they exist, otherwise use default names)  
    '        If Table.Value.Contains("<th") Then
    '            ' Set the HeadersExist flag  
    '            HeadersExist = True

    '            ' Get a match for all the rows in the table  
    '            Dim Headers As MatchCollection = Regex.Matches(Table.Value, HeaderExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

    '            ' Loop through each header element  
    '            For Each Header As Match In Headers
    '                dt.Columns.Add(Header.Groups(1).ToString)
    '            Next
    '        Else
    '            For iColumns As Integer = 1 To Regex.Matches(Regex.Matches(Regex.Matches(Table.Value, TableExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Item(0).ToString, RowExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Item(0).ToString, ColumnExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Count
    '                dt.Columns.Add("Column " & iColumns)
    '            Next
    '        End If

    '        ' Get a match for all the rows in the table  
    '        Dim Rows As MatchCollection = Regex.Matches(Table.Value, RowExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

    '        ' Loop through each row element  
    '        For Each Row As Match In Rows

    '            ' Only loop through the row if it isn't a header row  
    '            If Not (iCurrentRow = 0 And HeadersExist = True) Then

    '                ' Create a new row and reset the current column counter  
    '                dr = dt.NewRow
    '                iCurrentColumn = 0

    '                ' Get a match for all the columns in the row  
    '                Dim Columns As MatchCollection = Regex.Matches(Row.Value, ColumnExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

    '                ' Loop through each column element  
    '                For Each Column As Match In Columns
    '                    ' Add the value to the DataRow  
    '                    dr(iCurrentColumn) = Column.Groups(1).ToString

    '                    ' Increase the current column  
    '                    iCurrentColumn += 1
    '                Next

    '                ' Add the DataRow to the DataTable  
    '                dt.Rows.Add(dr)

    '            End If

    '            ' Increase the current row counter  
    '            iCurrentRow += 1
    '        Next

    '        ' Add the DataTable to the DataSet  
    '        ds.Tables.Add(dt)

    '    Next

    '    Return (ds)

    'End Function


    Private Function ConvertHTMLTablesToDataSet(ByVal HTML As String) As DataSet
        ' Declarations  
        Dim ds As New DataSet
        Dim dt As DataTable
        Dim dr As DataRow
        Dim dc As DataColumn
        Dim TableExpression As String = "<table[^>]*>(.*?)</table>"
        Dim HeaderExpression As String = "<th[^>]*>(.*?)</th>"
        Dim RowExpression As String = "<tr[^>]*>(.*?)</tr>"
        Dim ColumnExpression As String = "<td[^>]*>(.*?)</td>"
        Dim HeadersExist As Boolean = False
        Dim iCurrentColumn As Integer = 0
        Dim iCurrentRow As Integer = 0

        ' Get a match for all the tables in the HTML  
        Dim Tables As MatchCollection = Regex.Matches(HTML, TableExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)
        ''Dim cnt As Integer = 0
        '''' Loop through each table element  
        For Each Table As Match In Tables
            ''If cnt = 0 Then
            ''    cnt = cnt + 1
            ''    Continue For
            ''End If

            ' Reset the current row counter and the header flag  
            iCurrentRow = 0
            HeadersExist = False

            ' Add a new table to the DataSet  
            dt = New DataTable

            ' Create the relevant amount of columns for this table (use the headers if they exist, otherwise use default names)  
            If Table.Value.Contains("<th") Then
                ' Set the HeadersExist flag  
                HeadersExist = True

                ' Get a match for all the rows in the table  
                Dim Headers As MatchCollection = Regex.Matches(Table.Value, HeaderExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

                ' Loop through each header element  
                For Each Header As Match In Headers
                    dt.Columns.Add(Header.Groups(1).ToString)
                Next
            Else
                For iColumns As Integer = 1 To 13 'Regex.Matches(Regex.Matches(Regex.Matches(Table.Value, TableExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Item(0).ToString, RowExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Item(0).ToString, ColumnExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Count
                    dt.Columns.Add("Column " & iColumns)
                Next
            End If

            ' Get a match for all the rows in the table  
            Dim Rows As MatchCollection = Regex.Matches(Table.Value, RowExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

            ' Loop through each row element  
            For Each Row As Match In Rows

                ' Only loop through the row if it isn't a header row  
                If Not (iCurrentRow = 0 And HeadersExist = True) Then

                    ' Create a new row and reset the current column counter  
                    dr = dt.NewRow
                    iCurrentColumn = 0

                    ' Get a match for all the columns in the row  
                    Dim Columns As MatchCollection = Regex.Matches(Row.Value, ColumnExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

                    ' Loop through each column element  
                    For Each Column As Match In Columns

                        ' Add the value to the DataRow  
                        dr(iCurrentColumn) = Column.Groups(1).ToString

                        ' Increase the current column  
                        iCurrentColumn += 1
                    Next

                    ' Add the DataRow to the DataTable  
                    dt.Rows.Add(dr)

                End If

                ' Increase the current row counter  
                iCurrentRow += 1
            Next

            ' Add the DataTable to the DataSet  
            ds.Tables.Add(dt)

        Next

        Return (ds)

    End Function

    '    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCoverStmt.Click
    '        Dim StrParam As String = ""
    '        StrParam = "'" & Format(DtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(DtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "',''"
    '        GenerateReport("coverstmt", "proc#" & "Spr_FetchCoverStatementReport" & "#" & StrParam & "#100")
    '    End Sub


    Public Function ExportToExcelHeaderFooter11(ByVal filepath As String, ByVal filename As String, ByVal StrLocHeader As String, ByVal ParamArray DTable() As Data.DataTable) As String
        Dim Excel = CreateObject("Excel.Application")
        Dim strFilename As String
        Dim intCol, intRow As Integer
        Dim strPath As String = filepath
        Dim errMessage As String = "Record Exported Sucessfully"
        Dim ErrorOccured As Boolean = False
        Dim rwCtr As Integer
        Dim childDt, childDt1, ColDt As New DataTable
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

                childDt1 = DTable(1)

                ColDt = DTable(2)


                .Worksheets(worksheetCtr).Select()

                'For intRow = 0 To ColDt.Rows.Count - 1
                '    .Cells(1, intRow + 1).value = ColDt.Rows(intRow)(1)
                '    .Cells(1, intRow + 1).EntireRow.Font.Bold = True
                'Next

                For intRow = 2 To ColDt.Rows.Count - 1
                    .Cells(1, intRow + 1).value = ColDt.Rows(intRow)(1)
                    .Cells(1, intRow + 1).EntireRow.Font.Bold = True
                    intRow = intRow + 2
                Next

                For intRow = 1 To ColDt.Rows.Count - 1
                    .Cells(1, intRow + 1).Interior.ColorIndex = 34
                    .Cells(1, intRow + 2).Interior.ColorIndex = 34
                    .Cells(1, intRow + 3).Interior.ColorIndex = 34



                    intRow = intRow + 5
                Next

                For intRow = 0 To ColDt.Rows.Count - 1
                    .Cells(2, intRow + 1).value = ColDt.Rows(intRow)(2)
                    .Cells(2, intRow + 1).EntireRow.Font.Bold = True
                Next

                For intRow = 1 To ColDt.Rows.Count - 1
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

                For intRow = 0 To childDt.Rows.Count - 1
                    rwCtr = rwCtr + 1
                    For icolomns As Integer = 0 To childDt.Columns.Count - 1
                        .Cells(rwCtr, icolomns + 1).value = childDt.Rows(intRow)(icolomns)
                        .Cells(rwCtr, icolomns + 1).Borders.LineStyle = 2
                    Next
                Next

                .Cells(rwCtr, 1).EntireRow.Font.Bold = True

                'Promotional block
                rwCtr = rwCtr + 2

                .Cells(rwCtr, 1).value = "Promotional"
                .Cells(rwCtr, 1).EntireRow.Font.Bold = True


                For intRow = 0 To childDt1.Rows.Count - 1
                    rwCtr = rwCtr + 1
                    For icolomns As Integer = 0 To childDt1.Columns.Count - 1
                        .Cells(rwCtr, icolomns + 1).value = childDt1.Rows(intRow)(icolomns)
                        .Cells(rwCtr, icolomns + 1).Borders.LineStyle = 2
                    Next
                Next

                .Cells(rwCtr - 1, 1).EntireRow.Font.Bold = True
                .Cells(rwCtr, 1).EntireRow.Font.Bold = True

                .Cells(rwCtr - 1, 1).EntireRow.Borders.LineStyle = 1
                .Cells(rwCtr, 1).EntireRow.Borders.LineStyle = 1

                '.Cells(1, 1).value = Split(StrLocHeader, "#")(0)
                '.Cells(1, 1).EntireRow.Font.Bold = True
                ''.Cells(1, 1).EntireRow.Font.Color = RGB(255, 0, 0)
                '.Cells(1, 1).EntireRow.Interior.Color = RGB(255, 255, 0)

                '.Cells(1, 1).EntireRow.Font.Size = 16

                '.Cells(2, 1).value = Split(StrLocHeader, "#")(1)
                '.Cells(2, 1).EntireRow.Font.Bold = True
                '.Cells(2, 1).EntireRow.Interior.Color = RGB(255, 255, 0)


                'rwCtr = 4

                'For intCol = 0 To childDt.Columns.Count - 1
                '    .Cells(rwCtr, intCol + 1).value = childDt.Columns(intCol).ColumnName
                '    .Cells(rwCtr, intCol + 1).EntireRow.Font.Bold = True
                '    .Cells(rwCtr, intCol + 1).Interior.ColorIndex = 8
                'Next

                'Dim intK As Integer = 1
                'For intRow = 0 To childDt.Rows.Count - 1
                '    rwCtr += 1
                '    For intCol = 0 To childDt.Columns.Count - 1
                '        .Cells(rwCtr, intK).Value = childDt.Rows(intRow).ItemArray(intCol)
                '        .Cells(rwCtr, intCol + 1).Interior.ColorIndex = 34
                '        '.Cells(rwCtr, intCol + 1).Interior.ColorIndex = intK
                '        intK += 1
                '    Next
                '    intK = 1
                'Next
                'rwCtr += 3

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



    Private Sub btnCoverStmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim StrParam As String = ""
        StrParam = "'" & Format(DtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(DtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "',''"
        GenerateReport("coverstmt", "proc#" & "Spr_FetchMRCoverStatementReport" & "#" & StrParam & "#100")
    End Sub


End Class