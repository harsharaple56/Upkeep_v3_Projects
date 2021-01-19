Imports CWPlusBL
Imports System.Xml
Imports CWPlus.CWUtility
Imports System.IO


Public Class QVMain
    Dim objQV As ClsQuickExcess
    Dim dt As DataTable
    Dim ds As DataSet

    Dim LicenseID As String
    Public Sub New(ByVal Lic As String)
        InitializeComponent()
        LicenseID = Lic
    End Sub


    Public Function GenerateVarianceXML() As XmlDocument
        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml("<CWPlus><Variance><Details></Details></Variance></CWPlus>")
        For rCtr = 0 To grdVariancesInput.Rows.Count - 1
            Dim XmlElt As XmlElement = xmlDoc.CreateElement("Details")
            XmlElt.SetAttribute("BrandOpeningID", grdQV("BrandopeningID", rCtr).FormattedValue)

            'HIDDEN COLUMN VALUES
            XmlElt.SetAttribute("VarBottle", IIf(IsDBNull(grdVariancesInput("hdBottle", rCtr).Value), -99999, grdVariancesInput("hdBottle", rCtr).Value))
            XmlElt.SetAttribute("VarSpeg", IIf(IsDBNull(grdVariancesInput("hdSpeg", rCtr).Value), -99999, grdVariancesInput("hdSpeg", rCtr).Value))
            XmlElt.SetAttribute("VarGlass", -99999)

            'ACTUAL STOCK 
            XmlElt.SetAttribute("aBottle", IIf(IsDBNull(grdQV("inbottle", rCtr).Value), -99999, grdQV("inBottle", rCtr).Value))
            XmlElt.SetAttribute("aSpeg", IIf(IsDBNull(grdQV("insPeg", rCtr).Value), -99999, grdQV("inSpeg", rCtr).Value))
            XmlElt.SetAttribute("aGlass", -99999)

            'DISPLAYED VARIANCES
            XmlElt.SetAttribute("DispBottle", IIf(IsDBNull(grdVariancesInput("Bottle", rCtr).Value), -99999, grdVariancesInput("Bottle", rCtr).Value))
            XmlElt.SetAttribute("DispSpeg", IIf(IsDBNull(grdVariancesInput("sPeg", rCtr).Value), -99999, grdVariancesInput("sPeg", rCtr).Value))
            XmlElt.SetAttribute("DispGlass", -99999)

            'systemstock
            XmlElt.SetAttribute("sysBottle", IIf(IsDBNull(grdQV("Bottle", rCtr).Value), -99999, grdQV("Bottle", rCtr).Value))
            XmlElt.SetAttribute("sysSpeg", IIf(IsDBNull(grdQV("sPeg", rCtr).Value), -99999, grdQV("sPeg", rCtr).Value))
            XmlElt.SetAttribute("sysGlass", -99999)

            xmlDoc.DocumentElement("Variance").AppendChild(XmlElt)
        Next
        Return xmlDoc
    End Function

    Public Sub Save()
        Try
            If Not String.IsNullOrEmpty(gblUserName) AndAlso cmbLicenseName.SelectedValue > 0 Then
                objQV = New ClsQuickExcess
                objQV.VarianceID = 0
                objQV.UserName = gblUserName
                objQV.LicenseID = cmbLicenseName.SelectedValue
                objQV.PurchaseDate = GblPurchaseDate
                objQV.OutPutType = IIf(rdML.Checked, rdML.Tag, rdsPeg.Tag)
                objQV.VarDetailsXML = GenerateVarianceXML()
                objQV.SaveVariance()
                MessageBox.Show(objQV.ErrorMsg, "CWPlus", MessageBoxButtons.OK, MessageBoxIcon.Information)

                grdVariancesInput.Columns.Clear()
                grdVariancesInput.DataSource = Nothing

                FetchVariances()

                '[+][14/09/2019][Ajay Prajapati]
                btnCalculateVars.Enabled = False
                btnImport.Enabled = False
                'BtnSettlePlus.Enabled = False
                'btnSettalment.Enabled = False
                btnSave.Enabled = False
                '[-][14/09/2019][Ajay Prajapati]

            Else
                MsgBox("License Id / Username Missing !", "Error", MsgBoxStyle.SystemModal)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub SetGridTheme(ByVal srcGrid As DataGridView)
        With srcGrid
            .EnableHeadersVisualStyles = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 236, 243)
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Black
            .AlternatingRowsDefaultCellStyle.Font = New Font("Verdana", 9)
            .BorderStyle = Windows.Forms.BorderStyle.None
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(79, 129, 189)
            .ColumnHeadersDefaultCellStyle.Font = New Font("Verdana", 9.75, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = 30
            .DefaultCellStyle.BackColor = Color.FromArgb(208, 216, 232)
            .DefaultCellStyle.Font = New Font("Verdana", 9)
            .GridColor = Color.White
            .RowHeadersVisible = False
            .RowTemplate.Height = 28
            .BackgroundColor = Color.White
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub BindLicense()
        Try
            ' objlicense.UserID = gblUserID
            Dim objDt As DataTable
            Dim objlicense = New CWPlusBL.Master.Utitity
            objDt = New DataTable
            objlicense.UserID = gblUserID
            objDt = objlicense.FunFetchLicenseByRights
            ComboBindingTemplate(cmbLicenseName, objDt, "LicenseDesc", "LicenseID")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SetColumnHeaderColors()
        grdQV.Columns("inbottle").HeaderCell.Style.BackColor = Color.Brown
        grdQV.Columns("insPeg").HeaderCell.Style.BackColor = Color.Brown
        'grdQV.Columns("inGlass").HeaderCell.Style.BackColor = Color.Brown

        grdQV.Columns("Bottle").HeaderCell.Style.BackColor = Color.BurlyWood
        grdQV.Columns("Bottle").ReadOnly = True
        grdQV.Columns("sPeg").HeaderCell.Style.BackColor = Color.BurlyWood
        grdQV.Columns("sPeg").ReadOnly = True
        'grdQV.Columns("Glass").HeaderCell.Style.BackColor = Color.BurlyWood
        'grdQV.Columns("Glass").ReadOnly = True

        grdVariancesInput.Columns("sPeg").HeaderText = "sPeg / ML"
        grdVariancesInput.Columns("Bottle").ReadOnly = True
        grdVariancesInput.Columns("sPeg").ReadOnly = True

        'grdQV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill)
        grdQV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdVariancesInput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdQV.AllowUserToResizeRows = False
        grdVariancesInput.AllowUserToResizeRows = False

        grdQV.Columns("Bottle").SortMode = DataGridViewColumnSortMode.NotSortable
        grdQV.Columns("sPeg").SortMode = DataGridViewColumnSortMode.NotSortable
        grdQV.Columns("inbottle").SortMode = DataGridViewColumnSortMode.NotSortable
        grdQV.Columns("insPeg").SortMode = DataGridViewColumnSortMode.NotSortable
        grdQV.Columns("Category").SortMode = DataGridViewColumnSortMode.NotSortable
        grdQV.Columns("Brand Name").SortMode = DataGridViewColumnSortMode.NotSortable
        grdQV.Columns("Size").SortMode = DataGridViewColumnSortMode.NotSortable

        grdVariancesInput.Columns("Bottle").SortMode = DataGridViewColumnSortMode.NotSortable
        grdVariancesInput.Columns("sPeg").SortMode = DataGridViewColumnSortMode.NotSortable




    End Sub

    Public Sub HideColumns()
        grdQV.Columns("LicenseID").Visible = False
        grdQV.Columns("brandopeningid").Visible = False
        grdQV.Columns("IsSettlement").Visible = False
        grdQV.Columns("CategorySizeLinkID").Visible = False
        grdQV.Columns("CategoryType").Visible = False
        grdVariancesInput.Columns("hdBottle").Visible = False
        grdVariancesInput.Columns("hdsPeg").Visible = False

        ''[+][13/12/2019][Ajay Prajapati]
        'grdQV.Columns("TransferQuantity").Visible = False
        ''[-][13/12/2019][Ajay Prajapati]

        'grdVariancesInput.Columns("hdGlass").Visible = False

        'grdQV.Columns("Glass").Visible = False
        'grdQV.Columns("inGlass").Visible = False
        'grdVariancesInput.Columns("Glass").Visible = False
    End Sub

    Public Sub FetchVariances()
        grdQV.Columns.Clear()
        objQV = New ClsQuickExcess
        objQV.PurchaseDate = GblPurchaseDate
        objQV.LicenseID = cmbLicenseName.SelectedValue
        ds = objQV.FetchBrandQuantity()
        dt = ds.Tables(0)
        grdQV.DataSource = dt
        grdVariancesInput.DataSource = ds.Tables(1)

        If ds.Tables(1).Rows.Count > 0 Then
            btnSettalment.Enabled = CBool(ds.Tables(0).Rows(0)("IsSettlement"))
            BtnSettlePlus.Enabled = CBool(ds.Tables(0).Rows(0)("IsSettlement"))

            Else
                btnSettalment.Enabled = False
                BtnSettlePlus.Enabled = False
        End If

        '[+][14/09/2019][Ajay Prajapati]
        btnSave.Enabled = False
        cmbLicenseName.Enabled = False
        Dim License_ID As Double
        Dim Var_Date As Date
        Dim Selected_LicID As Double
        Dim Selected_Date As Date

        License_ID = MainModule.License_ID
        Var_Date = MainModule.VarianceDate

        Selected_LicID = Convert.ToDouble(cmbLicenseName.SelectedValue)
        Selected_Date = GblPurchaseDate

        If License_ID = Selected_LicID Then
            If Var_Date > Selected_Date Then
                btnCalculateVars.Enabled = False
                btnImport.Enabled = False
                'BtnSettlePlus.Enabled = False
                'btnSettalment.Enabled = False
                btnSave.Enabled = False
            End If

        End If
        License_ID = 0.0
        'Var_Date = null
        If CBool(ds.Tables(0).Rows(0)("IsSettlement")) = True Then
            btnCalculateVars.Enabled = False
            btnImport.Enabled = False
            'BtnSettlePlus.Enabled = False
            'btnSettalment.Enabled = False
            btnSave.Enabled = False
        End If

        If ds.Tables.Count > 2 Then

            If ds.Tables(2).Rows.Count > 0 Then
                Dim Positive_Settlement As Integer
                Dim Negative_Settlement As Integer

                Positive_Settlement = Convert.ToInt32(ds.Tables(2).Rows(0)("Positve_Settlement"))
                Negative_Settlement = Convert.ToInt32(ds.Tables(2).Rows(0)("Negative_Settlement"))

                If Positive_Settlement > 0 Then
                    BtnSettlePlus.Enabled = False
                    'Else
                    '    BtnSettlePlus.Enabled = True
                End If

                If Negative_Settlement > 0 Then
                    btnSettalment.Enabled = False
                    'Else
                    '    btnSettalment.Enabled = True
                End If

                If MainModule.is_PreviousDate = "Yes" Then
                    BtnSettlePlus.Enabled = False
                    btnSettalment.Enabled = False
                    If Positive_Settlement = 0 Then
                        MainModule.is_PositiveSettlement = "Yes"
                        BtnSettlePlus.Enabled = True
                        'MessageBox.Show("Already used in variance")
                        'BtnSettlePlus.ToolTipText = "Already used in variance"
                    Else
                        MainModule.is_PositiveSettlement = "No"
                    End If
                    If Negative_Settlement = 0 Then
                        MainModule.is_NegativeSettlement = "Yes"
                        btnSettalment.Enabled = True
                        'MessageBox.Show("Already used in variance")
                        'btnSettalment.ToolTipText = "Already used in variance"
                    Else
                        MainModule.is_NegativeSettlement = "No"
                    End If
                    'MainModule.is_PreviousDate = ""
                Else
                    MainModule.is_PositiveSettlement = "No"
                    MainModule.is_NegativeSettlement = "No"
                End If

            End If
        End If

        '[-][14/09/2019][Ajay Prajapati]


        grdVariancesInput.EndEdit()
        grdVariancesInput.Refresh()
        'REMOVE FOCUS FROM GRID
        grdVariancesInput.ClearSelection()
        HideColumns()
        SetColumnHeaderColors()
        FillArrayWithRowIndex()

        '[+][13/12/2019][Ajay Prajapati]
        grdQV.Columns("TransferQuantity").Visible = False
        '[-][13/12/2019][Ajay Prajapati]


        'For cnt = 0 To grdQV.Rows.Count - 1

        '    If grdQV("inbottle", cnt).Value Is Nothing Then
        '        MsgBox("inbo")
        '    End If

        'Next

        'For Each row As DataGridViewRow In grdQV.Rows
        '    If row.Cells("inbottle").Value = String.Empty Then
        '        MsgBox("Missing Information")
        '    End If

        'Next


    End Sub

    Private Sub QVMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'btnSettalment.Visible = False


        SetGridTheme(grdQV)

        'SET PROPERTY OF VARIANCE GRID
        With grdVariancesInput
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .RowTemplate.Height = 28
        End With

        Me.Hide()
        'Show Date Selection
        objQV = New ClsQuickExcess
        objQV.Month = Date.Now.Month

        '[+][14/09/2019][Ajay Prajapati]
        objQV.Year = Date.Now.Year
        objQV.LicenseID = MainModule.LicenseName
        '[-][14/09/2019][Ajay Prajapati]

        Dim dt As DataSet = objQV.FetchVarianceDatewise

        '[+][14/09/2019][Ajay Prajapati]
        'If dt.Tables(0).Rows.Count > 0 Then
        '    MainModule.License_ID = Convert.ToDouble(dt.Tables(0).Rows(0)("LicenseID"))
        '    MainModule.VarianceDate = Convert.ToDateTime(dt.Tables(0).Rows(0)("VarDate"))
        'End If

        '[-][14/09/2019][Ajay Prajapati]

        Dim objCView As New dlgQVCalendarView(dt)
        If objCView.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblDate.Text = GblPurchaseDate.ToString("dd-MMM-yyyy")
            'FetchVariances()

            '[+][14/09/2019][Ajay Prajapati]
            Dim Selected_date = GblPurchaseDate.ToString("dd-MMM-yy")
            Dim dt1 As New DataTable()
            dt1 = dt.Tables(0)
            For Each dr As DataRow In dt1.Rows
                If dr.Item("VarDate").ToString = Selected_date + " 12:00:00 AM" Then
                    MainModule.License_ID = Convert.ToDouble(dt.Tables(0).Rows(0)("LicenseID"))
                    MainModule.VarianceDate = Convert.ToDateTime(dt.Tables(0).Rows(0)("VarDate"))

                End If

                Dim dt2 As New DataTable()
                dt2 = dt.Tables(0)
                Dim currentValue As DateTime, maxValue As DateTime
                'maxValue = 0

                For c As Integer = 0 To dt2.Rows.Count - 1
                    currentValue = dt2.Compute("MAX(VarDate)", "")
                    If currentValue > maxValue Then maxValue = currentValue
                Next

                MainModule.is_PreviousDate = ""
                If maxValue > GblPurchaseDate Then
                    MainModule.is_PreviousDate = "Yes"
                Else
                    MainModule.is_PreviousDate = "No"
                End If

            Next
            '[-][14/09/2019][Ajay Prajapati]

            Me.Show()
            BindLicense()
            cmbLicenseName.SelectedValue = LicenseID
            'gblLicenseID
            btnSettalment.Enabled = objQV.HideButton
            BtnSettlePlus.Enabled = objQV.HideButton
            FetchVariances()


        Else
            Me.Close()
        End If
    End Sub

    Dim ArrRowChanged As New ArrayList
    Private Sub grdQV_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdQV.CellValueChanged
        If IsDBNull(grdQV(e.ColumnIndex, e.RowIndex).Value) Then
            ArrRowChanged.Remove(e.RowIndex)
            grdVariancesInput(0, e.RowIndex).Value = 0
            grdVariancesInput(1, e.RowIndex).Value = 0
            grdVariancesInput(2, e.RowIndex).Value = 0
            Exit Sub
        End If
        ArrRowChanged.Add(e.RowIndex)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        CalculateVariance(True)
        Save()
    End Sub

    Private Sub cmbLicenseName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLicenseName.SelectedIndexChanged
        If TypeOf cmbLicenseName.SelectedValue Is Decimal Then
            gblLicenseID = cmbLicenseName.SelectedValue

            gblLicenseNameForQuickControl = cmbLicenseName.Text
            FetchVariances()
        End If

    End Sub

    Public Sub ExportOutput() Handles btnExport.Click
        Dim ObjCls As New ClsQuickExcess
        Dim ObjPriDt As New DataTable
        Try
            ObjCls.FromDate = GblPurchaseDate
            ObjCls.LicenseID = 1
            ObjPriDt = ObjCls.FunFetchBevRecon()

            ExportToExcelHeaderFooter(IO.Path.GetTempPath, "variancereport.xls", ObjPriDt)
            Process.Start(IO.Path.GetTempPath & "\variancereport.xls")
        Catch ex As Exception
            Throw ex
        End Try
        'Dim objUtility As New ClsExportToPdf
        'Dim dtBook As DataTable = grdQV.ToDataTable("Out1")
        'Dim dtIn As DataTable = grdVariancesInput.ToDataTable("Out2")
        'Dim newDt As New DataTable


        'For clCtr = 0 To dtIn.Columns.Count - 1
        '    dtBook.Columns.Add(dtIn.Columns(clCtr).Caption & clCtr)
        'Next

        'For rCtr = 0 To dtBook.Rows.Count - 1
        '    dtBook.Rows(rCtr)(dtBook.Columns.Count - 3) = dtIn.Rows(rCtr)(0)
        '    dtBook.Rows(rCtr)(dtBook.Columns.Count - 2) = dtIn.Rows(rCtr)(1)
        '    dtBook.Rows(rCtr)(dtBook.Columns.Count - 1) = dtIn.Rows(rCtr)(2)
        'Next


        'If objUtility.MakeVariancePdf(dtBook) Then
        '    MsgBox("Report Exported Successfully !", MsgBoxStyle.Information, "CWPlus - Export")
        '    Process.Start(IO.Path.Combine(Application.StartupPath, "PDFR", "Output.pdf"))
        'End If

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

    Private Sub lblDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDate.Click
        objQV = New ClsQuickExcess
        objQV.Month = Date.Now.Month
        Dim dt As DataSet = objQV.FetchVarianceDatewise
        Dim objCView As New dlgQVCalendarView(dt)
        If objCView.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblDate.Text = GblPurchaseDate.ToString("dd-MMM-yyyy")
            FetchVariances()
        End If
    End Sub


    Private Sub CalculateVariance(ByVal LocSave As Boolean)
        For IntLocrow = 0 To grdVariancesInput.Rows.Count - 1
            For IntLocCol = 0 To grdVariancesInput.Columns.Count - 1
                grdVariancesInput.Item(IntLocCol, IntLocrow).Value = 0
            Next
        Next
        'grdVariancesInput.DataSource = Nothing
        'grdVariancesInput.Rows.Clear()
        'grdVariancesInput.Rows.Add(grdQV.Rows.Count)
        Dim tmpArray As Array = ArrRowChanged.ToArray.Distinct.ToArray()
        For i = 0 To tmpArray.Length - 1
            objQV = New ClsQuickExcess
            objQV.CategorySizeLinkID = grdQV("CategorySizeLinkID", tmpArray(i)).Value
            If LocSave Then
                objQV.OutPutType = rdsPeg.Tag
            Else
                objQV.OutPutType = IIf(rdML.Checked, rdML.Tag, rdsPeg.Tag)
            End If

            objQV.BookBottle = IIf(IsDBNull(grdQV("Bottle", tmpArray(i)).Value), 0, grdQV("Bottle", tmpArray(i)).Value)
            objQV.BookSpeg = IIf(IsDBNull(grdQV("Speg", tmpArray(i)).Value), 0, grdQV("Speg", tmpArray(i)).Value)
            objQV.ActualBottle = IIf(IsDBNull(grdQV("inBottle", tmpArray(i)).Value), 0, grdQV("inBottle", tmpArray(i)).Value)
            objQV.ActualSpeg = IIf(IsDBNull(grdQV("inSpeg", tmpArray(i)).Value), 0, grdQV("inSpeg", tmpArray(i)).Value)

            'Dim sendType As Integer = grdQV("Categorytype", tmpArray(i)).Value
            'Select Case sendType
            '    Case 1
            '        objQV.BookBottle = IIf(IsDBNull(grdQV("Bottle", tmpArray(i)).Value), 0, grdQV("Bottle", tmpArray(i)).Value)
            '        objQV.ActualBottle = IIf(IsDBNull(grdQV("inBottle", tmpArray(i)).Value), 0, grdQV("inBottle", tmpArray(i)).Value)
            '    Case 2
            '        objQV.BookBottle = IIf(IsDBNull(grdQV("Bottle", tmpArray(i)).Value), 0, grdQV("Bottle", tmpArray(i)).Value)
            '        objQV.BookSpeg = IIf(IsDBNull(grdQV("Glass", tmpArray(i)).Value), 0, grdQV("Glass", tmpArray(i)).Value)
            '        objQV.ActualBottle = IIf(IsDBNull(grdQV("inBottle", tmpArray(i)).Value), 0, grdQV("inBottle", tmpArray(i)).Value)
            '        objQV.ActualSpeg = IIf(IsDBNull(grdQV("inGlass", tmpArray(i)).Value), 0, grdQV("inGlass", tmpArray(i)).Value)
            '    Case 3
            '        objQV.BookBottle = IIf(IsDBNull(grdQV("Bottle", tmpArray(i)).Value), 0, grdQV("Bottle", tmpArray(i)).Value)
            '        objQV.BookSpeg = IIf(IsDBNull(grdQV("Speg", tmpArray(i)).Value), 0, grdQV("Speg", tmpArray(i)).Value)
            '        objQV.ActualBottle = IIf(IsDBNull(grdQV("inBottle", tmpArray(i)).Value), 0, grdQV("inBottle", tmpArray(i)).Value)
            '        objQV.ActualSpeg = IIf(IsDBNull(grdQV("inSpeg", tmpArray(i)).Value), 0, grdQV("inSpeg", tmpArray(i)).Value)
            '    Case Else
            'End Select
            Dim dt As DataTable = objQV.FetchVariances
            System.Threading.Thread.Sleep(300)
            grdVariancesInput("Bottle", tmpArray(i)).Value = dt.Rows(0)("Bottle")
            grdVariancesInput("sPeg", tmpArray(i)).Value = dt.Rows(0)("sPeg")
            'grdVariancesInput("Glass", tmpArray(i)).Value = dt.Rows(0)("Glass")
            grdVariancesInput("hdBottle", tmpArray(i)).Value = dt.Rows(0)("hdBottle")
            grdVariancesInput("hdsPeg", tmpArray(i)).Value = dt.Rows(0)("hdsPeg")
            'grdVariancesInput("hdGlass", tmpArray(i)).Value = dt.Rows(0)("hdGlass")
        Next

        '[+][14/09/2019][Ajay Prajapati]
        btnSave.Enabled = True
        '[-][14/09/2019][Ajay Prajapati]
    End Sub

    Private Sub btnCalculateVars_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCalculateVars.ClickButtonArea

        CalculateVariance(False)
    End Sub

    Private Sub btnQuickControls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuickControls.Click
        Dim objqc = New QCMain
        objqc.WindowState = FormWindowState.Maximized
        objqc.Show()
        Me.Close()
    End Sub

    Private Sub btnExportFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportFormat.Click
        Dim objOffice As New ClsMsOffice
        Dim dlgSaveDlg As New SaveFileDialog
        dlgSaveDlg.Title = "CWPlus - Export Variance Format"
        Dim dt As New DataTable
        dlgSaveDlg.DefaultExt = ".xls"
        If dlgSaveDlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            For index = 0 To grdQV.ColumnCount - 1
                dt.Columns.Add(grdQV.Columns(index).HeaderText)
            Next



            For index = 0 To grdVariancesInput.ColumnCount - 3
                dt.Columns.Add("Variance-" & grdVariancesInput.Columns(index).HeaderText)
            Next

            For index = 0 To grdQV.RowCount - 1
                dt.Rows.Add()
                For clCtr = 0 To grdQV.ColumnCount - 1
                    dt.Rows(index)(clCtr) = grdQV(clCtr, index).Value
                Next

                For clctr = 0 To grdVariancesInput.ColumnCount - 3
                    dt.Rows(index)(grdQV.ColumnCount + clctr) = grdVariancesInput(clctr, index).Value
                Next

            Next

            dt.Columns.Remove("TransferQuantity")

            MsgBox(objOffice.ExportToExcel(IO.Path.GetDirectoryName(dlgSaveDlg.FileName), IO.Path.GetFileName(dlgSaveDlg.FileName), dt))
            'MsgBox(objOffice.ExportToExcel(IO.Path.GetDirectoryName(dlgSaveDlg.FileName), IO.Path.GetFileName(dlgSaveDlg.FileName), grdQV.ToDataTable(True)))
        End If


    End Sub

    Private Sub FillArrayWithRowIndex()
        ArrRowChanged.Clear()
        For idx = 0 To grdQV.RowCount - 1
            If IsDBNull(grdQV("inBottle", idx).Value) AndAlso IsDBNull(grdQV("inSpeg", idx).Value) Then
                Continue For
            End If
            ArrRowChanged.Add(idx)
        Next
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim dlgOpen As New OpenFileDialog

        'grdQV.Columns("LicenseID").Visible = True

        If dlgOpen.ShowDialog = DialogResult.OK Then
            Dim exls As New ExcelReader(dlgOpen.FileName, True, False)
            grdQV.DataSource = Nothing
            Dim dtTemp As DataTable = exls.GetWorksheet("Sheet1")
            dtTemp.Columns.Remove("Variance-Bottle")
            dtTemp.Columns.Remove("Variance-sPeg / ML")

            '[+][14/09/2019][Ajay Prajapati]
            'dtTemp.Columns.Remove("Bottle")
            'dtTemp.Columns.Remove("sPeg")
            '[-][14/09/2019][Ajay Prajapati]

            'GET LICENSE ID
            cmbLicenseName.SelectedValue = dtTemp.Rows(0)("LicenseID")

            'commented by sachin on 7 Oct 2014 to resolve save->export->import issue
            'REMOVE THE LICENSE COLUMN
            'dtTemp.Columns.Remove("LicenseID")
            'dtTemp.Columns.Remove("IsSettlement")

            dtTemp.DefaultView.Sort = "Category,[Brand Name]"
            grdQV.DataSource = dtTemp.DefaultView

            grdVariancesInput.Columns.Clear()
            grdVariancesInput.DataSource = Nothing
            grdVariancesInput.Columns.Add("Bottle", "Bottle")
            grdVariancesInput.Columns.Add("sPeg", "sPeg")
            grdVariancesInput.Columns.Add("HdBottle", "HdBottle")
            grdVariancesInput.Columns.Add("HdsPeg", "HdsPeg")
            grdVariancesInput.Rows.Add(dtTemp.DefaultView.Count)

            grdQV.Columns("brandopeningid").Visible = False
            grdQV.Columns("CategorySizeLinkID").Visible = False
            grdQV.Columns("CategoryType").Visible = False
            grdVariancesInput.Columns("hdBottle").Visible = False
            grdVariancesInput.Columns("hdsPeg").Visible = False
            'grdVariancesInput.Columns("hdGlass").Visible = False

            'grdQV.Columns("Glass").Visible = False
            'grdQV.Columns("inGlass").Visible = False
            'grdVariancesInput.Columns("Glass").Visible = False

            SetColumnHeaderColors()
            HideColumns()
            FillArrayWithRowIndex()



        End If

    End Sub

    Private Sub grdQV_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles grdQV.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
            grdVariancesInput.FirstDisplayedScrollingRowIndex = grdQV.FirstDisplayedScrollingRowIndex
        End If
    End Sub

    Private Sub grdQV_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdQV.DataError
        e.ThrowException = False
        MsgBox("Enter Numbers Only !", MsgBoxStyle.Information)
    End Sub

    Private Sub btnSettalment_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettalment.Click


        '[+][14/09/2019][Ajay Prajapati]
        If MainModule.is_NegativeSettlement = "Yes" Then
            MessageBox.Show("Already used in variance")

        Else

            '[-][14/09/2019][Ajay Prajapati]

        Dim parentNod As New TreeNode("master")
        Dim childNod As New TreeNode("autobilling")
        parentNod.Nodes.Add(childNod)
        OpenForm(childNod, False)
            Me.Close()

            '[+][14/09/2019][Ajay Prajapati]
        End If
        '[-][14/09/2019][Ajay Prajapati]
    End Sub

    Private Sub BtnSettlePlus_Click(sender As System.Object, e As System.EventArgs) Handles BtnSettlePlus.Click
        'Dim parentNod As New TreeNode("master")
        'Dim childNod As New TreeNode("salemst")
        'parentNod.Nodes.Add(childNod)
        'OpenForm(childNod)
        'Me.Close()

        '[+][14/09/2019][Ajay Prajapati]
        If MainModule.is_PositiveSettlement = "Yes" Then
            MessageBox.Show("Already used in variance")

        Else
       
        '[-][14/09/2019][Ajay Prajapati]

        Dim parentnode As New TreeNode("master")
        Dim childnode As New TreeNode("salemst")
        childnode.Tag = "Sale"
        parentnode.Nodes.Add(childnode)
        OpenForm(childnode, False)
        Me.Close()

            '[+][14/09/2019][Ajay Prajapati]
        End If
        '[-][14/09/2019][Ajay Prajapati]

    End Sub

    Private Sub btnExpVarReport_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class