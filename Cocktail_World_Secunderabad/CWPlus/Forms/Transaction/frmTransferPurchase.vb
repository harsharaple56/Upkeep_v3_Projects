Imports CWPlusBL.Master
Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions

Public Class frmTransferPurchase
    Dim strFileName As String = ""
    Dim ObjInterfaceFile As CWPlusBL.ClsInterfaceFile
    Dim ObjFile As CWPlusBL.Master.ClsInterfaceFileSetUp
    Dim Objpurchase As CWPlusBL.Master.Clspurchase
    Dim dtMasterDet As New DataTable

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        ImportFile()
    End Sub
    Private Sub ImportFile()
        Dim opnflDlg As New OpenFileDialog
        If opnflDlg.ShowDialog = DialogResult.OK Then
            strFileName = opnflDlg.FileName
            SetFiles(opnflDlg.FileName)
        End If
    End Sub
    Public Sub SetFiles(ByVal FileName As String)
        Dim dt As New DataTable
        dt.Columns.Add("FromLicenseCode")
        dt.Columns.Add("ToLicenseCode")
        dt.Columns.Add("IssueNo")
        dt.Columns.Add("ItemCode")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Rate")
        dt.Columns.Add("FreeQty")
        dt.Columns.Add("TransferDate")
        Dim safeFileName As String = Path.GetFileName(FileName)
        Dim dataLinse() As String = File.ReadAllLines(FileName)

        Dim date1 As String                ' Updated on 16-june-2016 to get purchase present in file name.
        date1 = safeFileName.Substring(2, 6)
        Dim day As String = date1.Substring(0, 2)
        Dim mon As String = date1.Substring(2, 2)
        Dim year As String = date1.Substring(4, 2)
        date1 = day & "/" & mon & "/" & year

        Dim expenddt As Date = Date.ParseExact(date1, "dd/MM/yy",
                   System.Globalization.DateTimeFormatInfo.InvariantInfo)

        dtpDate.Value = expenddt




        For Each Item As String In dataLinse
            Dim ArrData As Array = Item.Split(",")
            dt.Rows.Add()

            For Index = 0 To ArrData.Length - 1
                dt.Rows(dt.Rows.Count - 1)(Index) = ArrData(Index)
            Next
        Next

        Dim newDs As New DataSet
        ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
        ObjInterfaceFile.InterfaceFileXml = GenrateBrandXML(dt)
        grdBrand.DataSource = Nothing
        newDs = ObjInterfaceFile.FunFetchPurchaseInterfaceFileTransfer

        grdBrand.DataSource = newDs.Tables(0)
        ' MakeIDColumnsHide(grdBrand)

        'For index = 0 To grdBrand.RowCount - 1
        '    If CBool(grdBrand.Item("IsNegative", index).Value) Then
        '        grdBrand.Rows(index).DefaultCellStyle.BackColor = Color.OrangeRed
        '    End If
        'Next

    End Sub
    Private Function GenrateBrandXML(ByVal dt As DataTable) As XmlDocument

        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Interface><TransferPurchase></TransferPurchase></Interface>")
        Dim xmlElt As XmlElement = xmldoc.CreateElement("Brand")
        For Index = 0 To dt.Rows.Count - 1
            xmlElt = xmldoc.CreateElement("Brand")
            xmlElt.SetAttribute("FromLicenseCode", dt.Rows(Index)("FromLicenseCode"))
            xmlElt.SetAttribute("ToLicenseCode", dt.Rows(Index)("ToLicenseCode"))
            xmlElt.SetAttribute("ItemCode", dt.Rows(Index)("ItemCode"))
            xmlElt.SetAttribute("IssueNo", dt.Rows(Index)("IssueNo"))
            xmlElt.SetAttribute("Quantity", dt.Rows(Index)("Quantity"))
            xmlElt.SetAttribute("Rate", dt.Rows(Index)("Rate"))
            xmlElt.SetAttribute("FreeQty", dt.Rows(Index)("FreeQty"))
            xmlElt.SetAttribute("TransferDate", (dtpDate.Value))
            xmldoc.DocumentElement.Item("TransferPurchase").AppendChild(xmlElt)
        Next
        Return xmldoc
    End Function

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Save()
        Dim parentNode As New TreeNode("transaction")
        Dim childeNode As New TreeNode("transfer")
        parentNode.Nodes.Add(childeNode)
        OpenForm(childeNode)
        Me.Close()
    End Sub

    Public Function Save() As Boolean
        Save = False
        Dim ObjTransferHead As New ClsTransfer
        If Not grdBrand.RowCount > 0 Then
            MsgBox("Nothing to save!", MsgBoxStyle.Information, "Transfer Purchase")
            Exit Function
        End If

        Try
            ObjTransferHead.TransferDetailsXML = GenrateXML()
            ObjTransferHead.UserName = gblUserName
            ObjTransferHead.FunSaveTransferPurchase()

        Catch ex As Exception

        End Try

    End Function

    Private Function GenrateXML() As XmlDocument
        Dim xmlDoc As New XmlDocument
        xmlDOc.LoadXml("<Master><Transfer></Transfer></Master>")
        Dim xmlElt As XmlElement = xmlDoc.CreateElement("Transferdetail")
        For Index = 0 To grdBrand.RowCount - 1
            If CBool(grdBrand.Item("isnegative", Index).Value) Then
                Continue For
            End If
            xmlElt = xmlDoc.CreateElement("Transferdetail")
            xmlElt.SetAttribute("TransferDate", grdBrand.Item("TransferDate", Index).Value)
            xmlElt.SetAttribute("TPHead", grdBrand.Item("TPHead", Index).Value)
            'xmlElt.SetAttribute("InvoiceNo", grdBrand.Item("InvoiceNo", Index).Value)
            xmlElt.SetAttribute("ForLicenseID", grdBrand.Item("ForLicenseID", Index).Value)
            xmlElt.SetAttribute("LicenseID", grdBrand.Item("LicenseID", Index).Value)
            xmlElt.SetAttribute("DeptID", grdBrand.Item("DeptID", Index).Value)
            xmlElt.SetAttribute("BrandopeningId", grdBrand.Item("BrandopeningId", Index).Value)
            xmlElt.SetAttribute("box", grdBrand.Item("box", Index).Value)
            xmlElt.SetAttribute("spegqty", grdBrand.Item("spegqty", Index).Value)
            xmlElt.SetAttribute("spegrate", grdBrand.Item("spegrate", Index).Value)
            xmlElt.SetAttribute("Brand", grdBrand.Item("Brand", Index).Value)
            xmlElt.SetAttribute("Size", grdBrand.Item("Size", Index).Value)
            xmlElt.SetAttribute("bottleqty", grdBrand.Item("bottleqty", Index).Value)
            xmlElt.SetAttribute("bottlerate", grdBrand.Item("bottlerate", Index).Value)
            xmlElt.SetAttribute("ForBrandOpeningID", grdBrand.Item("ForBrandopeningid", Index).Value)
            xmlElt.SetAttribute("UnitQty", grdBrand.Item("UnitQty", Index).Value)
            xmlElt.SetAttribute("IsNegative", grdBrand.Item("IsNegative", Index).Value)
            xmlDoc.DocumentElement.Item("Transfer").AppendChild(xmlElt)
        Next
        Return xmlDoc
    End Function

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class