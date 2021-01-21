Imports CWPlusBL.Master
Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions
Imports System.Data
Imports System.Globalization


Public Class frmInterfaceFilePurchase
    Dim objpurchasedet As CWPlusBL.Master.Clspurchase
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
        dtMasterDet = ObjFile.FunFetchInterfaceFilePurchaseSetUp
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

        xmldoc.LoadXml("<Interface><PurchaseInterface></PurchaseInterface></Interface>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Brand")
        For index = 0 To dt.Rows.Count - 1
            XmlElt = xmldoc.CreateElement("Brand")
            XmlElt.SetAttribute("LicenseId", gblLicenseID.ToString())
            XmlElt.SetAttribute("LocationNo", Trim(dt.Rows(index)("LocationNumber")))
            XmlElt.SetAttribute("SupplierCode", dt.Rows(index)("SupplierCode"))
            XmlElt.SetAttribute("TPNO", dt.Rows(index)("TPNO"))
            'XmlElt.SetAttribute("ChalanNo", dt.Rows(index)("ChalanNo"))
            'XmlElt.SetAttribute("ExtraCharge", dt.Rows(index)("ExtraCharge"))
            XmlElt.SetAttribute("GRNForCode", Trim(dt.Rows(index)("GRNForCode")))                         'Added By Mohammed on 29-March-2019
            XmlElt.SetAttribute("ItemCode", Trim(dt.Rows(index)("ItemCode")))
            XmlElt.SetAttribute("Quantity", dt.Rows(index)("Quantity"))
            XmlElt.SetAttribute("Rate", dt.Rows(index)("Rate"))
            XmlElt.SetAttribute("FreeQty", dt.Rows(index)("FreeQty"))
            XmlElt.SetAttribute("PurchaseDate", Format(dtpDate.Value, "dd-MMM-yyyy"))

            xmldoc.DocumentElement.Item("PurchaseInterface").AppendChild(XmlElt)

        Next

        Return xmldoc
    End Function

    Private Function GenerateBrandXMLv2(ByVal dt As DataTable) As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Interface><PurchaseInterface></PurchaseInterface></Interface>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Brand")
        For index = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(index)("Received date")) Then
                XmlElt = xmldoc.CreateElement("Brand")
                XmlElt.SetAttribute("SupplierCode", "")
                XmlElt.SetAttribute("TPNO", "")
                XmlElt.SetAttribute("ChalanNo", "")
                XmlElt.SetAttribute("PurchaseDate", dt.Rows(index)("Received date").ToString())
                XmlElt.SetAttribute("ExtraCharge", 0)
                XmlElt.SetAttribute("GRNForCode", dt.Rows(index)("Department code"))                             'Added By Mohammed on 29-March-2019
                XmlElt.SetAttribute("ItemCode", Trim(dt.Rows(index)("Item #").ToString()))
                XmlElt.SetAttribute("Quantity", dt.Rows(index)("Rec'd qty"))
                XmlElt.SetAttribute("Rate", dt.Rows(index)("Unit price"))
                XmlElt.SetAttribute("FreeQty", 0)
                xmldoc.DocumentElement.Item("PurchaseInterface").AppendChild(XmlElt)
            End If
        Next
        Return xmldoc

    End Function

    Public Sub SetFiles(ByVal Filename As String)

        Dim dt As New DataTable
        dt.Columns.Add("LicenseId")
        dt.Columns.Add("LocationNumber")
        dt.Columns.Add("SupplierCode")
        dt.Columns.Add("GRNForCode")
        dt.Columns.Add("TPNO")
        dt.Columns.Add("ItemCode")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Rate")
        dt.Columns.Add("FreeQty")
        dt.Columns.Add("PurchaseDate")


        ''------------------------------- Updated on 16-june-2016 to get purchase present in file name.
        Dim safeFileName As String = Path.GetFileName(Filename)
        Dim dataLines() As String = File.ReadAllLines(Filename)


        If Trim(dtMasterDet.Rows(0)("fileextension")) <> "" Then
            If Not Path.GetExtension(safeFileName).ToLower = "." & dtMasterDet.Rows(0)("fileextension").ToString.ToLower Then
                MsgBox("File Extension mismatched")
                Exit Sub
            End If
        End If

        Dim chkCol As Boolean = True

        For Each item As String In dataLines
            Dim ArrData As Array
            If dtMasterDet.Rows(0)("symbol").ToString.Length = 1 Then
                ArrData = item.Split(dtMasterDet.Rows(0)("symbol"))
            Else
                ArrData = Split(item, dtMasterDet.Rows(0)("symbol"))
            End If

            'If dtMasterDet.Rows(0)("PositionPriceSequence") <> 0 And chkCol Then
            '    dt.Columns.Add("PriceSeq")
            '    chkCol = False
            'End If
            Dim strFlName As String = ""
            'If dtMasterDet.Rows(0)("licensecodedef") = 1 Then
            '    strFlName = safeFileName.Substring((CInt(dtMasterDet.Rows(0)("licensecodeposition")) - 1), dtMasterDet.Rows(0)("licensecodelength"))
            '    'dt.Rows.Add(strFlName, ArrData(0), ArrData(1), ArrData(2), ArrData(3))
            dt.Rows.Add(strFlName, ArrData(dtMasterDet.Rows(0)("PositionLocationNo") - 1), ArrData(dtMasterDet.Rows(0)("PositionSupplierCode") - 1),
             ArrData(dtMasterDet.Rows(0)("PostionRRnumber") - 1), ArrData(dtMasterDet.Rows(0)("PositionTPnumber") - 1),
             ArrData(dtMasterDet.Rows(0)("PostionItemCode") - 1), ArrData(dtMasterDet.Rows(0)("PositionQuantity") - 1),
             ArrData(dtMasterDet.Rows(0)("PositionRate") - 1), ArrData(dtMasterDet.Rows(0)("PositionFreeQty") - 1))
            'ElseIf dtMasterDet.Rows(0)("licensecodedef") = 2 Then
            'strFlName = ArrData(dtMasterDet.Rows(0)("licensecodeposition") - 1).ToString.Substring(0, dtMasterDet.Rows(0)("licensecodelength"))
            'If dtMasterDet.Rows(0)("positionbillno") = 1 Then
            '    'commented by sachin for licensecode + billno
            '    'dt.Rows.Add(strFlName, ArrData(0).ToString.Replace(strFlName, ""), ArrData(dtMasterDet.Rows(0)("positioncode") - 1), ArrData(dtMasterDet.Rows(0)("positionqty") - 1), ArrData(dtMasterDet.Rows(0)("positionrate") - 1))
            '    dt.Rows.Add(strFlName, Trim(ArrData(0)), Trim(ArrData(dtMasterDet.Rows(0)("positioncode") - 1)), Trim(ArrData(dtMasterDet.Rows(0)("positionqty") - 1)))
            'Else
            '    dt.Rows.Add(strFlName, Trim(ArrData(dtMasterDet.Rows(0)("positionbillno") - 1)), Trim(ArrData(dtMasterDet.Rows(0)("positioncode") - 1)), Trim(ArrData(dtMasterDet.Rows(0)("positionqty") - 1)))
            'End If
            'If Not dtMasterDet.Rows(0)("positionrate") = 0 Then
            '    dt.Rows(dt.Rows.Count - 1)("Rate") = Trim(ArrData(dtMasterDet.Rows(0)("positionrate") - 1))
            'Else
            '    dt.Rows(dt.Rows.Count - 1)("Rate") = 0
            'End If

            'ElseIf dtMasterDet.Rows(0)("licensecodedef") = 3 Then
            'strFlName = Path.GetFileNameWithoutExtension(safeFileName)
            'dt.Rows.Add(strFlName, Trim(ArrData(1)), Trim(ArrData(2)), Trim(ArrData(3)), Trim(ArrData(dtMasterDet.Rows(0)("positionpricesequence") - 1)))
            'End If
            'dt.Rows.Add(strFlName, ArrData(0).ToString.Substring(dtMasterDet.Rows(0)("licensecodelength"), ArrData(0).ToString.Length - dtMasterDet.Rows(0)("licensecodelength")), ArrData(1), ArrData(2), ArrData(3))

            'If dt.Columns.Contains("PriceSeq") Then
            '    dt.Rows(dt.Rows.Count - 1)("PriceSeq") = Trim(ArrData(dtMasterDet.Rows(0)("positionpricesequence") - 1))
            'End If
        Next

        Dim newDs As New DataSet
        ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
        ObjInterfaceFile.InterfaceFileDate = dtpDate.Value
        'If dtMasterDet.Rows(0)("PositionPriceSequence") <> 0 Then
        '    ObjInterfaceFile.IsPriceSeqAvail = True
        'Else
        '    ObjInterfaceFile.IsPriceSeqAvail = False
        'End If
        ObjInterfaceFile.InterfaceFileXml = GenerateBrandXML(dt)
        ObjInterfaceFile.UserID = gblUserID
        newDs = ObjInterfaceFile.FunFetchInterfacefilePurchase()
        If newDs.Tables(1).Rows.Count > 0 Then
            Dim objBrCd As New dlgBrandCodeForInterfaceFile(newDs.Tables(1))
            objBrCd.ShowDialog()
            'MsgBox("Code not found for " & ObjInterfaceFile.ErrorMsg, MsgBoxStyle.Information, "Interface File")
        End If
        grdBrand.Columns.Clear()
        grdBrand.DataSource = Nothing
        grdBrand.DataSource = newDs.Tables(0)

        grdBrand.Columns("LicenseID").Visible = False
        grdBrand.Columns("SupplierID").Visible = False


        'If CInt(grdBrand.RowCount) > 0 Then
        '    BindBrand(0)
        'End If


        'grdCocktail.Columns.Clear()
        'grdCocktail.DataSource = Nothing
        'grdCocktail.DataSource = newDs.Tables(1)

        'AddHideGridColumns()



        ''---------------------------------------------------------------
        'Dim date1 As String
        'date1 = safeFileName.Substring(2, 8)
        'Dim day As String = date1.Substring(0, 2)
        'Dim mon As String = date1.Substring(2, 2)
        'Dim year As String = date1.Substring(4, 4)
        'date1 = day & "/" & mon & "/" & year

        'Dim expenddt As Date = Date.ParseExact(date1, "dd/MM/yyyy",
        '          System.Globalization.DateTimeFormatInfo.InvariantInfo)

        'dtpDate.Value = expenddt

        'For Each item As String In dataLines


        '    'Dim ArrData As Array = item.Split("$#$")
        '    'Dim ArrData As Array = Split(item, "$#$")

        '    Dim ArrData As Array = Split(item, ",")
        '    dt.Rows.Add()

        '    For index = 0 To ArrData.Length - 1
        '        dt.Rows(dt.Rows.Count - 1)(index) = ArrData(index)

        '    Next
        'Next

        'Dim newDs As New DataSet
        'ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
        'ObjInterfaceFile.InterfaceFileXml = GenerateBrandXML(dt)
        'grdBrand.DataSource = Nothing
        'newDs = ObjInterfaceFile.FunFetchInterfacefilePurchase()

        'If newDs.Tables(1).Rows.Count > 0 Then
        '    Dim objBrCd As New dlgBrandCodeForInterfaceFile(newDs.Tables(1))
        '    objBrCd.ShowDialog()
        '    ' MsgBox("Code not found for " & ObjInterfaceFile.ErrorMsg, MsgBoxStyle.Information, "Interface File")
        'End If
        'grdBrand.DataSource = newDs.Tables(0)

        'MakeIDColumnsHide(grdBrand)
        ''---------------------------------------------------------------
    End Sub



    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><Purchase></Purchase></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Purchasedetail")
        For index = 0 To grdBrand.RowCount - 1
            XmlElt = xmldoc.CreateElement("Purchasedetail")
            XmlElt.SetAttribute("SupplierID", grdBrand.Item("SupplierID", index).Value)
            XmlElt.SetAttribute("TPNO", grdBrand.Item("TPNO", index).Value)
            XmlElt.SetAttribute("InvoiceNo", grdBrand.Item("ChalanNo", index).Value)
            XmlElt.SetAttribute("GRNForCode", grdBrand.Item("GRNForCode", index).Value)                           'Added By Mohammed on 15-MAR-2019
            XmlElt.SetAttribute("PurchaseDate", grdBrand.Item("PurchaseDate", index).Value)
            XmlElt.SetAttribute("ExtraCharge", grdBrand.Item("ExtraCharge", index).Value)
            XmlElt.SetAttribute("LicenseID", grdBrand.Item("LicenseID", index).Value)
            XmlElt.SetAttribute("BrandopeningId", grdBrand.Item("BrandopeningId", index).Value)
            XmlElt.SetAttribute("SQuantity", grdBrand.Item("SQuantity", index).Value)
            XmlElt.SetAttribute("SRate", grdBrand.Item("sRate", index).Value)
            XmlElt.SetAttribute("BottleQty", grdBrand.Item("BottleQty", index).Value)
            XmlElt.SetAttribute("BottleRate", grdBrand.Item("BottleRate", index).Value)
            XmlElt.SetAttribute("FreeQty", grdBrand.Item("freeqty", index).Value)
            XmlElt.SetAttribute("Noofbox", grdBrand.Item("NoOfBox", index).Value)
            XmlElt.SetAttribute("CategoryTaxID", grdBrand.Item("CategoryTaxID", index).Value)
            XmlElt.SetAttribute("taxper", grdBrand.Item("taxper", index).Value)
            XmlElt.SetAttribute("batchNo", grdBrand.Item("BatchNo", index).Value)
            XmlElt.SetAttribute("Mfg", grdBrand.Item("mfg", index).Value)
            xmldoc.DocumentElement.Item("Purchase").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function

    Public Function Save() As Boolean
        Save = False
        If Not grdBrand.RowCount > 0 Then
            MsgBox("Nothing to save", MsgBoxStyle.Information, "Interface File Purchase")
            Exit Function
        End If

        Try

            Objpurchase = New CWPlusBL.Master.Clspurchase

            Objpurchase.PurchaseXML = GenerateXML()
            Objpurchase.UserName = gblUserName
            Save = Objpurchase.FunSavePurchaseInterface
            MsgBox(Objpurchase.ErrorMsg)

            'Dim dest As String = Path.Combine(dtMasterDet.Rows(0)("backupfilepath"), Path.GetFileName(strFileName))
            'If File.Exists(dest) Then File.Delete(dest)
            'File.Move(strFileName, dest)

            ' Clrscr()
            Me.Close()
            OpenForm(MDI.tvMenu.SelectedNode)
            FrmPurchasedetail.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
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
        Dim ChildNode As New TreeNode("purchase")
        Parentnode.Nodes.Add(ChildNode)
        OpenForm(ChildNode)
        Me.Close()
    End Sub
    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
#End Region

    Private Sub frmInterfaceFilePurchase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
        'Standard format
        Dim dt As New DataTable
        Dim DlgexcelFile As New OpenFileDialog
        DlgexcelFile.InitialDirectory = Application.StartupPath
        If DlgexcelFile.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim ObjOfc As New ExcelReader(DlgexcelFile.FileName, True, False)
            dt = GetExcelSheetData(DlgexcelFile.FileName)
        End If


        'RITZ Fornmat
        'Dim dt As DataTable = ImportExcellFile()

        Dim newDs As New DataSet
        ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
        ObjInterfaceFile.InterfaceFileXml = GenerateBrandXML(dt)
        grdBrand.DataSource = Nothing
        newDs = ObjInterfaceFile.FunFetchInterfacefilePurchase()
        grdBrand.DataSource = newDs.Tables(0)
        grdBrand.AutoResizeColumns()

        ''If newDs.Tables(1).Rows.Count > 0 Then
        ''    Dim objBrCd As New dlgBrandCodeForInterfaceFile(newDs.Tables(1))
        ''    objBrCd.ShowDialog()
        ''    'MsgBox("Code not found for " & ObjInterfaceFile.ErrorMsg, MsgBoxStyle.Information, "Interface File")
        ''End If

        MakeIDColumnsHide(grdBrand)
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


            maindt.Rows(0).Delete()
            maindt.Rows(1).Delete()
            For icolomns As Integer = 0 To ds.Tables(2).Columns.Count - 1
                maindt.Columns(icolomns).ColumnName = maindt.Rows(0)(icolomns)

            Next

            For irows As Integer = 0 To maindt.Rows.Count - 2
                If irows < maindt.Rows.Count - 2 Then
                    If IsDBNull(maindt.Rows(irows)(4)) Or maindt.Rows(irows)(4) = "" Then
                        maindt.Rows(irows).Delete()
                    End If
                End If
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
                For iColumns As Integer = 1 To 13 ' Regex.Matches(Regex.Matches(Regex.Matches(Table.Value, TableExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Item(0).ToString, RowExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Item(0).ToString, ColumnExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Count
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




    Private Sub grdBrand_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBrand.CellContentClick, grdBrand.CellContentDoubleClick

    End Sub

End Class