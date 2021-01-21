Imports System.Data
Imports CWPlusBL.ClsInterfaceFile
Imports System.Xml
Public Class QCStep3

    Public Sub InitMe()
        FetchControls()
        If gblControlHeadID > 0 Then
            AssignDateToLable()
            FetchQcStep3()
            Exit Sub
        Else
            FetchFromDateToDate()
            AssignDateToLable()
            FetchQcStep3()
            Exit Sub
        End If

        'FetchFromDateToDate()
        'AssignDateToLable()

        'FetchQcStep3()
        grdQuickControlStep3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
    End Sub
    Public Sub AssignDateToLable()
        lblFromDate.Text = GblFromDate.ToString("dd-MMM-yyyy") & " To " & GblToDate.ToString("dd-MMM-yyyy")
    End Sub
    Public Sub FetchFromDateToDate()
        Dim ObjDate As New CWPlusBL.ClsQuickControl
        Dim Objdt As New DataTable
        Try
            ObjDate.ToDate = GblPurchaseDate
            Objdt = ObjDate.FunFetcFromDateToDate()
            If Objdt.Rows.Count > 0 Then
                GblFromDate = Objdt.Rows(0).Item("FromDate")
                GblToDate = Objdt.Rows(0).Item("ToDate")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjDate) = False Then
                ObjDate = Nothing
            End If
            If IsNothing(Objdt) = False Then
                Objdt = Nothing
            End If
        End Try
    End Sub
    Public Sub FetchQcStep3()
        Try
            'lblPeriodName.Text = GblFromDate.ToString("dd-MMM-yyyy") & " And " & GblToDate.ToString("dd-MMM-yyyy")
            'lblTotalCost.Text = GblTotalCost
            'lblGrossRevenue.Text = gblGrossTotal
            'lblNetRevenue.Text = gblNetTotal

            'Dim Profit As Double
            'Profit = gblNetTotal - GblTotalCost

            grdQuickControlStep3.Rows.Clear()
            For rwctr = 0 To grdQuickControlStep3.RowCount
                grdQuickControlStep3.Rows.Add()
                grdQuickControlStep3("controlHeadID", rwctr).Value = gblControlHeadID
                grdQuickControlStep3("Period", rwctr).Value = GblFromDate.ToString("dd-MMM-yyyy") & " And " & GblToDate.ToString("dd-MMM-yyyy")
                grdQuickControlStep3("TotalCost", rwctr).Value = GblTotalCost
                grdQuickControlStep3("GrossTotal", rwctr).Value = gblGrossTotal
                grdQuickControlStep3("NetTotal", rwctr).Value = gblNetTotal
                grdQuickControlStep3("Diff", rwctr).Value = (gblNetTotal - GblTotalCost)
            Next




        Catch ex As Exception
            Throw ex

        End Try


    End Sub
    Private Sub QCStep3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
    '        MsgBox("Please select license", vbInformation, "CWPlus")
    '        Exit Sub
    '    End If

    '    Dim ObjQc3 As New CWPlusBL.ClsQuickControl
    '    Dim ObjDs As New DataSet

    '    Try
    '        ObjQc3.LicenseID = gblLicenseID
    '        ObjQc3.FromDate = GblFromDate
    '        ObjQc3.ToDate = GblToDate

    '        ObjDs = ObjQc3.FunFectQCSTEP3Excel()

    '        'If ObjDs.Tables(0).Rows.Count > 0 Then

    '        '    Dim dlgSaveFile As New SaveFileDialog
    '        '    dlgSaveFile.DefaultExt = ".xls"
    '        '    dlgSaveFile.Filter = "Excel Files (*.xlsx) | *.xlsx"
    '        '    If dlgSaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        '        Dim ObjExp As New ClsMsOffice
    '        '        ObjExp.ExportToExcel(IO.Path.GetDirectoryName(dlgSaveFile.FileName), IO.Path.GetFileName(dlgSaveFile.FileName), ObjDs.Tables(0))
    '        '        Dim dlgRes As DialogResult
    '        '        dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        '        If dlgRes = Windows.Forms.DialogResult.Yes Then
    '        '            Process.Start(dlgSaveFile.FileName)

    '        '        End If
    '        '    End If

    '        'End If


    '        Dim dlgSaveFile As New SaveFileDialog
    '        dlgSaveFile.DefaultExt = ".xls"
    '        dlgSaveFile.Filter = "Excel Files (*.xlsx) | *.xlsx"

    '        If dlgSaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
    '            Dim ObjExp As New ClsMsOffice
    '            ObjExp.ExportToExcel(IO.Path.GetDirectoryName(dlgSaveFile.FileName), IO.Path.GetFileName(dlgSaveFile.FileName), ObjDs.Tables(0), ObjDs.Tables(1), ObjDs.Tables(2))
    '        End If


    '        Dim dlgRes As DialogResult
    '        dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        If dlgRes = Windows.Forms.DialogResult.Yes Then
    '            Process.Start(dlgSaveFile.FileName)

    '        End If
    '    Catch ex As Exception

    '    End Try




    'End Sub

    Private Sub grdQuickControlStep3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdQuickControlStep3.CellContentClick
        If e.ColumnIndex = 6 Then
            If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
                MsgBox("Please select license", vbInformation, "CWPlus")
                Exit Sub
            End If

            Dim ObjQc3 As New CWPlusBL.ClsQuickControl
            Dim ObjDs As New DataSet

            Try
                ObjQc3.LicenseID = gblLicenseID
                ObjQc3.ControlHeadID = gblControlHeadID
                ObjQc3.FromDate = GblFromDate
                ObjQc3.ToDate = GblToDate
                ObjDs = ObjQc3.FunFectQCSTEP3Excel()
                Dim dlgSaveFile As New SaveFileDialog
                dlgSaveFile.DefaultExt = ".xls"
                dlgSaveFile.Filter = "Excel Files (*.xls) | *.xls"

                If dlgSaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim ObjExp As New ClsMsOffice
                    ObjExp.ExportToExcel(IO.Path.GetDirectoryName(dlgSaveFile.FileName), IO.Path.GetFileName(dlgSaveFile.FileName), ObjDs.Tables(0), ObjDs.Tables(1), ObjDs.Tables(2))

                End If
                Dim dlgRes As DialogResult
                dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dlgRes = Windows.Forms.DialogResult.Yes Then
                    Process.Start(dlgSaveFile.FileName)

                End If



            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(ObjQc3) = False Then
                    ObjQc3 = Nothing
                End If

                If IsNothing(ObjDs) = False Then
                    ObjDs = Nothing
                End If
            End Try



        End If
    End Sub

    Public Sub FetchControls()
        Dim ObjControls As New CWPlusBL.ClsQuickControl
        Dim ObjDt As New DataSet
        Try
            gblControlHeadID = 0
            ObjControls.LicenseID = gblLicenseID
            ObjControls.FromDate = GblPurchaseDate
            ObjDt = ObjControls.FunFetchContorlForQCStep2()

            If ObjDt.Tables(0).Rows.Count > 0 Then
                gblControlHeadID = ObjDt.Tables(0).Rows(0).Item("ControlHeadID")
                GblFromDate = ObjDt.Tables(0).Rows(0).Item("FromDate")
                GblToDate = ObjDt.Tables(0).Rows(0).Item("ToDate")
                gblNetTotal = ObjDt.Tables(0).Rows(0).Item("NetRevenue")
                gblGrossTotal = ObjDt.Tables(0).Rows(0).Item("GrossRevenue")
            End If
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    'Module ExportingCellByCellMethod

    'Public Sub ExportToExcel(ByVal ObjDs As DataSet, ByVal outputPath As String)
    '    ' Create the Excel Application object
    '    Dim excelApp As New ApplicationClass()

    '    ' Create a new Excel Workbook
    '    Dim excelWorkbook As Workbook = excelApp.Workbooks.Add(Type.Missing)

    '    Dim sheetIndex As Integer = 0
    '    Dim col, row As Integer
    '    Dim excelSheet As Worksheet

    '    ' Copy each DataTable as a new Sheet
    '    For Each dt As System.Data.DataTable In DataSet.Tables

    '        sheetIndex += 1

    '        ' Create a new Sheet
    '        excelSheet = CType( _
    '            excelWorkbook.Sheets.Add(excelWorkbook.Sheets(sheetIndex), _
    '            Type.Missing, 1, XlSheetType.xlWorksheet), Worksheet)

    '        excelSheet.Name = dt.TableName

    '        ' Copy the column names (cell-by-cell)
    '        For col = 0 To dt.Columns.Count - 1
    '            excelSheet.Cells(1, col + 1) = dt.Columns(col).ColumnName
    '        Next

    '        CType(excelSheet.Rows(1, Type.Missing), Range).Font.Bold = True

    '        ' Copy the values (cell-by-cell)
    '        For col = 0 To dt.Columns.Count - 1
    '            For row = 0 To dt.Rows.Count - 1
    '                excelSheet.Cells(row + 2, col + 1) = dt.Rows(row).ItemArray(col)
    '            Next
    '        Next

    '        excelSheet = Nothing
    '    Next

    '    ' Save and Close the Workbook
    '    excelWorkbook.SaveAs(outputPath, XlFileFormat.xlWorkbookNormal, Type.Missing, _
    '     Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, _
    '     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

    '    excelWorkbook.Close(True, Type.Missing, Type.Missing)

    '    excelWorkbook = Nothing

    '    ' Release the Application object
    '    excelApp.Quit()
    '    excelApp = Nothing

    '    ' Collect the unreferenced objects
    '    GC.Collect()
    '    GC.WaitForPendingFinalizers()

    'End Sub

    'End Module



End Class
