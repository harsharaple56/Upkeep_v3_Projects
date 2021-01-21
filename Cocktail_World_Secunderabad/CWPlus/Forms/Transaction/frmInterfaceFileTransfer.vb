Imports CWPlusBL.Master
Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions

Public Class frmInterfaceFileTransfer
    Dim strFileName As String = ""
    Dim ObjInterfaceFile As CWPlusBL.ClsInterfaceFile
    Dim ObjFile As CWPlusBL.Master.ClsInterfaceFileSetUp
    Dim Objpurchase As CWPlusBL.Master.Clspurchase
    Dim dtMasterDet As New DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetFileSettings()
    End Sub

#Region "Functions"

    Public Sub GetFileSettings()
        ObjFile = New ClsInterfaceFileSetUp
        dtMasterDet = ObjFile.FunFetchInterfaceFileTransferSetUp
    End Sub

    Private Sub ImportFile()

        Dim opnflDlg As New OpenFileDialog
        If opnflDlg.ShowDialog = DialogResult.OK Then
            strFileName = opnflDlg.FileName
            SetFiles(opnflDlg.FileName)
        End If
    End Sub

    Private Function GenerateBrandXML(ByVal dt As DataTable) As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Interface><TransferInterface></TransferInterface></Interface>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Brand")
        'Sam
        '    For index = 0 To dt.Rows.Count - 1
        '    XmlElt = xmldoc.CreateElement("Brand")
        '    XmlElt.SetAttribute("TransferDate", dt.Rows(index)("TransferDate"))
        '    XmlElt.SetAttribute("TPNO", dt.Rows(index)("TPNO"))
        '    XmlElt.SetAttribute("FromLicenseCode", dt.Rows(index)("FromLicenseCode"))
        '    XmlElt.SetAttribute("ToLicenseCode", dt.Rows(index)("ToLicenseCode"))
        '    XmlElt.SetAttribute("ItemCode", dt.Rows(index)("ItemCode"))
        '    XmlElt.SetAttribute("Quantity", dt.Rows(index)("Quantity"))
        '    XmlElt.SetAttribute("Rate", dt.Rows(index)("Rate"))
        '    ' XmlElt.SetAttribute("FreeQty", dt.Rows(index)("FreeQty"))



        For index = 0 To dt.Rows.Count - 1
            XmlElt = xmldoc.CreateElement("Brand")
            'XmlElt.SetAttribute("TransferDate", dt.Rows(index)("TransferDate"))
            XmlElt.SetAttribute("TransferDate", Format(dtpDate2.Value, "dd-MMM-yyyy"))
            XmlElt.SetAttribute("FromLicenseCode", dt.Rows(index)("FromLicenseCode"))
            XmlElt.SetAttribute("ToLicenseCode", dt.Rows(index)("ToLicenseCode"))
            XmlElt.SetAttribute("TPNO", dt.Rows(index)("TPNO"))
            XmlElt.SetAttribute("ItemCode", dt.Rows(index)("ItemCode"))
            XmlElt.SetAttribute("Quantity", dt.Rows(index)("Quantity"))
            XmlElt.SetAttribute("Rate", dt.Rows(index)("Rate"))
            'XmlElt.SetAttribute("FreeQty", dt.Rows(index)("FreeQty"))

            xmldoc.DocumentElement.Item("TransferInterface").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function

    Private Function GenerateBrandXMLv2(ByVal dt As DataTable) As XmlDocument

        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Interface><TransferInterface></TransferInterface></Interface>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Brand")
        For index = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(index)("Post date")) Then
                'sam  
                'XmlElt = xmldoc.CreateElement("Brand")
                'XmlElt.SetAttribute("TransferDate", dt.Rows(index)("Post date"))
                'XmlElt.SetAttribute("TPNO", "")
                'XmlElt.SetAttribute("FromLicenseCode", dt.Rows(index)("From storeroom ID"))
                'XmlElt.SetAttribute("ToLicenseCode", dt.Rows(index)("To Storeroom ID"))
                'XmlElt.SetAttribute("ItemCode", Trim(dt.Rows(index)("Part #").ToString()))
                'XmlElt.SetAttribute("Quantity", dt.Rows(index)("To Quantity"))
                'XmlElt.SetAttribute("Rate", dt.Rows(index)("To extended home amt"))
                XmlElt = xmldoc.CreateElement("Brand")
                dt.Columns.Add("TransferDate", dt.Rows(index)("Post date"))
                XmlElt.SetAttribute("FromLicenseCode", dt.Rows(index)("From storeroom ID"))
                XmlElt.SetAttribute("ToLicenseCode", dt.Rows(index)("To Storeroom ID"))
                XmlElt.SetAttribute("TPNO", "")
                XmlElt.SetAttribute("ItemCode", Trim(dt.Rows(index)("Part #").ToString()))
                XmlElt.SetAttribute("Quantity", dt.Rows(index)("To Quantity"))
                XmlElt.SetAttribute("Rate", dt.Rows(index)("To extended home amt"))

                xmldoc.DocumentElement.Item("TransferInterface").AppendChild(XmlElt)
            End If
        Next
        Return xmldoc
    End Function

    Public Sub SetFiles(ByVal Filename As String)

        Dim dt As New DataTable
        'sam
        'dt.Columns.Add("TransferDate")
        'dt.Columns.Add("TPNO")
        'dt.Columns.Add("FromLicenseCode")
        'dt.Columns.Add("ToLicenseCode")
        'dt.Columns.Add("ItemCode")
        'dt.Columns.Add("Quantity")
        'dt.Columns.Add("Rate")

        'dt.Columns.Add("TransferDate")
        dt.Columns.Add("FromLicenseCode")
        dt.Columns.Add("ToLicenseCode")
        dt.Columns.Add("TPNO")
        dt.Columns.Add("ItemCode")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Rate")
        dt.Columns.Add("FreeQty")    'updated 17-6-2016 abhijeet


        Dim safeFileName As String = Path.GetFileName(Filename)
        Dim dataLines() As String = File.ReadAllLines(Filename)

        For Each item As String In dataLines
            Dim ArrData As Array = item.Split(",")
            dt.Rows.Add()

            For index = 0 To ArrData.Length - 1
                dt.Rows(dt.Rows.Count - 1)(index) = ArrData(index)
            Next
        Next

        Dim newDs As New DataSet
        ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
        ObjInterfaceFile.InterfaceFileXml = GenerateBrandXML(dt)

        grdBrand.DataSource = Nothing
        newDs = ObjInterfaceFile.FunFetchInterfacefileTransfer()
        If newDs.Tables(1).Rows.Count > 0 Then
            Dim objBrCd As New dlgBrandCodeForInterfaceFile(newDs.Tables(1))
            objBrCd.ShowDialog()
            'MsgBox("Code not found for " & ObjInterfaceFile.ErrorMsg, MsgBoxStyle.Information, "Interface File")
        End If
        grdBrand.Columns.Clear()
        grdBrand.DataSource = Nothing
        grdBrand.DataSource = newDs.Tables(0)
        grdBrand.AutoResizeColumns()

        MakeIDColumnsHide(grdBrand)


        For index = 0 To grdBrand.RowCount - 1
            If CBool(grdBrand.Item("IsNegative", index).Value) Then
                grdBrand.Rows(index).DefaultCellStyle.BackColor = Color.OrangeRed
            End If
        Next
    End Sub

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><Transfer></Transfer></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Transferdetail")
        For index = 0 To grdBrand.RowCount - 1
            If CBool(grdBrand.Item("isnegative", index).Value) Then
                Continue For
            End If
            XmlElt = xmldoc.CreateElement("Transferdetail")
            XmlElt.SetAttribute("TransferDate", grdBrand.Item("TransferDate", index).Value)
            XmlElt.SetAttribute("TPHead", grdBrand.Item("TPHead", index).Value)
            XmlElt.SetAttribute("InvoiceNo", grdBrand.Item("InvoiceNo", index).Value)
            XmlElt.SetAttribute("ForLicenseID", grdBrand.Item("ForLicenseID", index).Value)
            XmlElt.SetAttribute("FLIV", grdBrand.Item("FLIV", index).Value)
            XmlElt.SetAttribute("FLIVAddress", grdBrand.Item("FLIVAddress", index).Value)
            XmlElt.SetAttribute("LicenseID", grdBrand.Item("LicenseID", index).Value)
            XmlElt.SetAttribute("DeptID", grdBrand.Item("DeptID", index).Value)
            XmlElt.SetAttribute("BrandopeningId", grdBrand.Item("BrandopeningId", index).Value)
            XmlElt.SetAttribute("against", "")
            XmlElt.SetAttribute("TPNO", grdBrand.Item("TPNO", index).Value)
            XmlElt.SetAttribute("batch", grdBrand.Item("batch", index).Value)
            XmlElt.SetAttribute("mfg", grdBrand.Item("mfg", index).Value)
            XmlElt.SetAttribute("box", grdBrand.Item("box", index).Value)
            XmlElt.SetAttribute("remarks", grdBrand.Item("remarks", index).Value)
            XmlElt.SetAttribute("spegqty", grdBrand.Item("spegqty", index).Value)
            XmlElt.SetAttribute("spegrate", grdBrand.Item("spegrate", index).Value)
            XmlElt.SetAttribute("bottleqty", grdBrand.Item("bottleqty", index).Value)
            XmlElt.SetAttribute("bottlerate", grdBrand.Item("bottlerate", index).Value)
            XmlElt.SetAttribute("ForBrandOpeningID", grdBrand.Item("ForBrandOpeningID", index).Value)

            xmldoc.DocumentElement.Item("Transfer").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function

    Public Function Save() As Boolean
        Save = False
        Dim ObjTransferHead As New ClsTransfer
        If Not grdBrand.RowCount > 0 Then
            MsgBox("Nothing to save", MsgBoxStyle.Information, "Interface File Transfer")
            Exit Function
        End If

        Try
            ObjTransferHead.TransferDetailsXML = GenerateXML()
            ObjTransferHead.UserName = gblUserName
            ObjTransferHead.FunSaveTransferInterface()
            MsgBox(ObjTransferHead.ErrorMsg)

            'Dim dest As String = Path.Combine(dtMasterDet.Rows(0)("backupfilepath"), Path.GetFileName(strFileName))
            'If File.Exists(dest) Then File.Delete(dest)
            'File.Move(strFileName, dest)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjTransferHead) Then
                ObjTransferHead = Nothing
            End If

        End Try

    End Function
#End Region

#Region "Events"
    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        ImportFile()
    End Sub
    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()

        Dim Parentnode As New TreeNode("transaction")
        Dim ChildNode As New TreeNode("transfer")
        Parentnode.Nodes.Add(ChildNode)
        OpenForm(ChildNode)
        Me.Close()
    End Sub
    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
#End Region

    Private Sub frmInterfaceFileTransfer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If dtMasterDet.Rows.Count > 0 Then
            BindFiles()
        Else
            'MsgBox("Inerface file setup not found!", vbInformation, "CWPlus")
        End If
    End Sub

    Public Sub BindFiles()
        Try
            Dim flInfo() As String = Directory.GetFiles(dtMasterDet.Rows(0)("FilePath"), Trim(dtMasterDet.Rows(0)("FilePrefix").ToString) & "*." & Trim(dtMasterDet.Rows(0)("FileExtension")))
            lstFiles.Items.AddRange(flInfo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUseThisFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseThisFile.Click
        If lstFiles.SelectedItem = "" Then
            MsgBox("Select a file from list", MsgBoxStyle.Information, "Interface File")
            Exit Sub
        End If
        strFileName = lstFiles.SelectedItem.ToString
        SetFiles(lstFiles.SelectedItem.ToString)
    End Sub

    Private Sub BtnImportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportExcel.Click
        Dim dt As New DataTable
        Dim DlgexcelFile As New OpenFileDialog
        DlgexcelFile.InitialDirectory = Application.StartupPath
        If DlgexcelFile.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim ObjOfc As New ExcelReader(DlgexcelFile.FileName, True, False)
            dt = GetExcelSheetData(DlgexcelFile.FileName)
        End If

        'Dim dt As DataTable = ImportExcellFile()

        Dim newDs As New DataSet
        ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
        ObjInterfaceFile.InterfaceFileXml = GenerateBrandXML(dt)
        grdBrand.DataSource = Nothing
        newDs = ObjInterfaceFile.FunFetchInterfacefileTransfer()
        grdBrand.DataSource = newDs.Tables(0)
        grdBrand.AutoResizeColumns()

        MakeIDColumnsHide(grdBrand)

        'For index = 0 To grdBrand.RowCount - 1
        '    If CBool(grdBrand.Item("IsNegative", index).Value) Then
        '        grdBrand.Rows(index).DefaultCellStyle.BackColor = Color.OrangeRed
        '    End If
        'Next

        If newDs.Tables(1).Rows.Count > 0 Then
            Dim objBrCd As New dlgBrandCodeForInterfaceFile(newDs.Tables(1))
            objBrCd.ShowDialog()
            'MsgBox("Code not found for " & ObjInterfaceFile.ErrorMsg, MsgBoxStyle.Information, "Interface File")
        End If
    End Sub


    Private Function ImportExcellFile()
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
                        ds.Tables(2).Rows(irows)(icolomns) = Regex.Replace(ds.Tables(2).Rows(irows)(icolomns), "Rs", "")
                        ds.Tables(2).Rows(irows)(icolomns) = Regex.Replace(ds.Tables(2).Rows(irows)(icolomns), ",", "")
                    End If
                Next
            Next

            Dim maindt As DataTable = ds.Tables(2)

            For icolomns As Integer = 0 To ds.Tables(2).Columns.Count - 1
                maindt.Columns(icolomns).ColumnName = maindt.Rows(0)(icolomns)

            Next
            maindt.Rows(0).Delete()
            maindt.Rows(maindt.Rows.Count - 1).Delete()

            Return (maindt)
        End If
    End Function

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

        ' Loop through each table element  
        For Each Table As Match In Tables

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
                For iColumns As Integer = 1 To Regex.Matches(Regex.Matches(Regex.Matches(Table.Value, TableExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Item(0).ToString, RowExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Item(0).ToString, ColumnExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Count
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

    Public Function GetExcelSheetData(ByVal FileName As String) As DataTable
        Try
            Dim extension As String = LCase(IO.Path.GetExtension(FileName))
            If extension = ".xls" OrElse extension = ".xlsx" Then
                Dim db As New ExcelReader(FileName, False, False)
                GetExcelSheetData = db.GetWorksheet("Sheet1")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class