Imports System.Xml
Imports System.IO
Imports CWPlusBL.Master
Public Class frmInterFaceFileSale

    Dim Objpurchase As CWPlusBL.Master.Clspurchase
    Dim ObjInterfaceFile As CWPlusBL.ClsInterfaceFile
    Dim ObjInterfaceFileMaster As CWPlusBL.Master.ClsInterfaceFileSetUp
    Dim ObjDtPermitHolder As CWPlusBL.Master.ClsPermitHolderMaster
    Dim ObjAssignctcode As CWPlusBL.Master.AssignCocktailCode
    Dim Objcocktail As CWPlusBL.Master.ClsAutobilling

    Dim objdt As DataTable
    Dim dt As DataTable
    Dim ArrPermitList As New ArrayList
    Dim BrandrwIndex, CocktailRwIndex As Integer
    Dim dtXMLpermitholder As DataTable
    'commented by sachin on 29 mayt 2013 and setup field flag use
    'Dim chkPriceSeq As Boolean = False
    Dim dtMasterDet As New DataTable
    Dim strFileName As String = ""

    'Tables used to hold bill master table SKALA
    Dim ObjPriBillDt As New DataTable
    Dim BoolPriUpdateBillNo As Boolean = False


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetFileSettings()
    End Sub

#Region "Functions"

    Public Function GetFileSettings() As Boolean
        ObjInterfaceFileMaster = New CWPlusBL.Master.ClsInterfaceFileSetUp
        ObjInterfaceFileMaster.LicenseID = MDI.cmbLicenseName.SelectedValue
        dtMasterDet = ObjInterfaceFileMaster.FunFetch

        If ObjInterfaceFileMaster.Outbit = 0 Then
            MsgBox("File Setting not found for this License.")
            DisableControls()
        End If

        'If dtMasterDet.Rows.Count > 0 Then
        '    If Not dtMasterDet.Rows(0)("DATE") = "Null" Then
        '        dtpDate.Enabled = False
        '    End If

        'End If
    End Function

    Private Sub DisableControls()
        btnUseThisFile.Enabled = False
        btnImport.Enabled = False
        imgSave.Enabled = False
        btnAdd.Enabled = False
    End Sub

    Public Sub BindBrand(ByVal BrandOpeningID As Double)
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable
            Objpurchase.BrandopeningID = BrandOpeningID
            Objpurchase.LicenseID = CDbl(grdBrand.Item("licenseid", BrandrwIndex).Value)
            objdt = Objpurchase.BindBrandOpening
            If Not objdt.Rows.Count > 0 Then
                Exit Sub
            End If
            ComboBindingTemplate(cmbBrand, objdt, "BrandDesc", "BrandID")
           
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

    Private Sub BindSize(ByVal brandid As Double)
        Dim Objpurchase As New CWPlusBL.Master.Clspurchase
        Dim ds As New DataSet
        Try

            Objpurchase.BrandID = cmbBrand.SelectedValue
            Objpurchase.LicenseID = CDbl(grdBrand.Item("licenseid", BrandrwIndex).Value)
            ds = Objpurchase.BindSizes
            cmbSize.DataSource = Nothing
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

    Public Sub BindCocktail(ByVal LicenseID As Double)
        Try
            ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
            Dim ObjDt As New DataTable
            ObjAssignctcode.LicenseID = LicenseID
            ObjDt = ObjAssignctcode.FetchCocktailCodeByLicenseWise
            ComboBindingTemplate(cmbCocktail, ObjDt, "CocktailName", "CocktailID")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjAssignctcode) Then
                ObjAssignctcode = Nothing
            End If

        End Try
    End Sub

    Private Function GenerateBrandXML(ByVal dt As DataTable) As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Interface><SaleInterface></SaleInterface></Interface>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Brand")
        For index = 0 To dt.Rows.Count - 1
            XmlElt = xmldoc.CreateElement("Brand")
            XmlElt.SetAttribute("LicenseCode", dt.Rows(index)("LicenseCode"))
            XmlElt.SetAttribute("BillNo", dt.Rows(index)("BillNo"))
            XmlElt.SetAttribute("BrandCode", dt.Rows(index)("BrandCode"))
            XmlElt.SetAttribute("Quantity", dt.Rows(index)("Quantity"))
            XmlElt.SetAttribute("Rate", dt.Rows(index)("Rate"))
          If dt.Columns.Contains("PriceSeq") Then
                XmlElt.SetAttribute("PriceSeq", dt.Rows(index)("PriceSeq"))
                'chkPriceSeq = True
            Else
                'chkPriceSeq = False
            End If
            xmldoc.DocumentElement.Item("SaleInterface").AppendChild(XmlElt)

        Next

        Return xmldoc
    End Function

    Private Function GenerateBrandXMLv2(ByVal dt As DataTable) As XmlDocument
        GenerateBrandXMLv2 = Nothing
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            MsgBox("Please select license", vbInformation, "CWPlus")
            Exit Function
        End If

        Dim objLicenseCode As New ClsLicenseMst
        Dim ObjPriDt As New DataTable

        objLicenseCode.LicenseID = MDI.cmbLicenseName.SelectedValue
        ObjPriDt = objLicenseCode.FunFetchLicenseCodeMaster

        If ObjPriDt.Rows.Count = 0 Then
            MsgBox("License code not set", vbInformation, "CWPlus")
            Exit Function
        End If

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Interface><SaleInterface></SaleInterface></Interface>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Brand")
        For index = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(index)("Order No#")) Then
                XmlElt = xmldoc.CreateElement("Brand")
                XmlElt.SetAttribute("LicenseCode", ObjPriDt.Rows(0)("LicenseCode"))
                XmlElt.SetAttribute("BillNo", dt.Rows(index)("Order No#"))
                XmlElt.SetAttribute("BrandCode", dt.Rows(index)("Menu Item"))
                XmlElt.SetAttribute("Quantity", dt.Rows(index)("Billed Qty#"))
                XmlElt.SetAttribute("Rate", dt.Rows(index)("Rate"))
                xmldoc.DocumentElement.Item("SaleInterface").AppendChild(XmlElt)
            End If
        Next
        Return xmldoc
    End Function

    Private Function GeneratePermitXML(ByVal dtdata As DataTable) As XmlDocument

        Dim xmldocPermitHolder As New XmlDocument

        xmldocPermitHolder.LoadXml("<Interface><SaleInterfacePermit></SaleInterfacePermit></Interface>")

        Dim XmlElt As XmlElement = xmldocPermitHolder.CreateElement("Permit")
        For index = 0 To dtdata.Rows.Count - 1
            XmlElt = xmldocPermitHolder.CreateElement("Permit")

            XmlElt.SetAttribute("billno", dtdata.Rows(index)("BillNo"))
            XmlElt.SetAttribute("permitholderid", dtdata.Rows(index)("permitholderid"))
            xmldocPermitHolder.DocumentElement.Item("SaleInterfacePermit").AppendChild(XmlElt)
        Next

        Return xmldocPermitHolder
    End Function

    Private Function GenerateInterfaceFileXML() As XmlDocument

        BindPermitName()

        dtXMLpermitholder = PermitHolderxmlcolumns()

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Interface><SaleInterface></SaleInterface></Interface>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Brand")
        For index = 0 To grdBrand.Rows.Count - 1
            If CBool(grdBrand.Item("isnegative", index).Value) Then
                Continue For
            End If
            XmlElt = xmldoc.CreateElement("Brand")
            XmlElt.SetAttribute("LicenseID", grdBrand.Item("Licenseid", index).Value)
            XmlElt.SetAttribute("LicenseCodeID", grdBrand.Item("LicenseCodeID", index).Value)
            dtXMLpermitholder.Rows.Add()
            dtXMLpermitholder.Rows(dtXMLpermitholder.Rows.Count - 1)("BillNo") = grdBrand.Item("Bill No", index).Value
            XmlElt.SetAttribute("BillNo", grdBrand.Item("Bill No", index).Value)
            If IsNothing(grdBrand.Item("newbrandopeningid", index).Value) Then
                XmlElt.SetAttribute("BrandOpeningID", grdBrand.Item("BrandOpeningID", index).Value)
            Else
                XmlElt.SetAttribute("BrandOpeningID", grdBrand.Item("newBrandOpeningID", index).Value)
            End If
            XmlElt.SetAttribute("sPeg", grdBrand.Item("speg", index).Value)
            XmlElt.SetAttribute("sPegRate", grdBrand.Item("spegRate", index).Value)
            XmlElt.SetAttribute("lPeg", grdBrand.Item("lpeg", index).Value)
            XmlElt.SetAttribute("lPegRate", grdBrand.Item("lpegRate", index).Value)
            XmlElt.SetAttribute("BottleQty", grdBrand.Item("BottleQty", index).Value)
            XmlElt.SetAttribute("BottleRate", grdBrand.Item("BottleRate", index).Value)

            xmldoc.DocumentElement.Item("SaleInterface").AppendChild(XmlElt)

        Next
        'GeneratePermitHolder()
        Return xmldoc
    End Function

    Private Function Cocktailxmlcolumns() As DataTable
        Dim dtXML As New DataTable
        dtXML.Columns.Add("billno")
        dtXML.Columns.Add("Cocktailid")
        dtXML.Columns.Add("Qty")
        dtXML.Columns.Add("Rate")
        dtXML.Columns.Add("CategoryTaxTypeId")
        dtXML.Columns.Add("TaxPercetage")
        dtXML.Columns.Add("cocktailtotal")
        Return dtXML
    End Function

    Private Function GenerateCocktailXML() As XmlDocument

        Dim xmldocCocktail As New XmlDocument

        xmldocCocktail.LoadXml("<Interface><SaleInterfacePermit></SaleInterfacePermit></Interface>")


        Dim XmlElt As XmlElement = xmldocCocktail.CreateElement("Cocktail")
        For index = 0 To grdCocktail.Rows.Count - 1
            If CBool(grdCocktail.Item("ISCocktailNegative", index).Value) Then
                Continue For
            End If
            XmlElt = xmldocCocktail.CreateElement("Cocktail")
            XmlElt.SetAttribute("LicenseID", grdCocktail.Item("LicenseID", index).Value)
            XmlElt.SetAttribute("LicenseCodeID", grdCocktail.Item("LicenseCodeID", index).Value)
            dtXMLpermitholder.Rows.Add()
            dtXMLpermitholder.Rows(dtXMLpermitholder.Rows.Count - 1)("BillNo") = grdCocktail.Item("BillNo", index).Value
            XmlElt.SetAttribute("billno", grdCocktail.Item("BillNo", index).Value)
            If IsNothing(grdCocktail.Item("newCocktailid", index).Value) Then
                XmlElt.SetAttribute("Cocktailid", grdCocktail.Item("Cocktailid", index).Value)
            Else
                XmlElt.SetAttribute("Cocktailid", grdCocktail.Item("newCocktailid", index).Value)
            End If

            XmlElt.SetAttribute("Qty", grdCocktail.Item("Quantity", index).Value)
            XmlElt.SetAttribute("Rate", grdCocktail.Item("Rate", index).Value)
            XmlElt.SetAttribute("CategoryTaxTypeId", 0)
            XmlElt.SetAttribute("TaxPercetage", 0)

            XmlElt.SetAttribute("cocktailtotal", grdCocktail.Item("cocktailtotal", index).Value)
            xmldocCocktail.DocumentElement.Item("SaleInterfacePermit").AppendChild(XmlElt)
        Next
        GeneratePermitHolder()
        Return xmldocCocktail
    End Function

    Private Function PermitHolderxmlcolumns() As DataTable
        Dim dtXML As New DataTable
        dtXML.Columns.Add("billno")
        dtXML.Columns.Add("permitholderid")
        Return dtXML
    End Function

    Private Sub GeneratePermitHolder()
        dtXMLpermitholder.DefaultView.Sort = "BillNo"
        ''''For Permit Holder'''''
        Dim rn As New Random()


        Dim dv As New DataView
        dv = dtXMLpermitholder.DefaultView
        For index = 0 To dtXMLpermitholder.Rows.Count - 1

            Dim PermitValue As Integer = rn.Next(0, ArrPermitList.Count - 2)
            dtXMLpermitholder.DefaultView(index)("permitholderid") = ArrPermitList(PermitValue)

            Dim chk As Boolean = False
            Dim ctr As Integer = 0

            Do Until chk = True
                If index + ctr = dtXMLpermitholder.Rows.Count - 1 Then
                    Exit For
                End If
                If dtXMLpermitholder.DefaultView(index + ctr)("BillNo") = dtXMLpermitholder.DefaultView(index + ctr + 1)("BillNo") Then
                    dtXMLpermitholder.DefaultView(index + ctr + 1)("permitholderid") = ArrPermitList(PermitValue)
                    ctr += 1
                Else
                    chk = True
                End If
            Loop
            If Not ctr = 0 Then
                index += ctr
            End If
        Next

    End Sub

    Public Sub BindPermitName()
        Dim ObjDtPermitHolder As New CWPlusBL.Master.ClsPermitHolderMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjDtPermitHolder.ExpireDate = dtpDate.Value
            'ObjDtPermitHolder.PermitHolderID = lblid.Text

            ObjPriDt = ObjDtPermitHolder.FunFetchPermitHolderExpiryDate

            ArrPermitList = New ArrayList

            If ObjPriDt.Rows.Count > 0 Then
                For index = 1 To ObjPriDt.Rows.Count - 1
                    ArrPermitList.Add(ObjPriDt.Rows(index).Item("PermitHolderID").ToString())
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtPermitHolder) = False Then
                ObjDtPermitHolder = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try

    End Sub

    Public Sub FetchBrandType()
        Dim objBrandType As New ClsAutobilling
        Dim ObjPriDt As New DataTable
        Try
            objBrandType.BrandID = cmbBrand.SelectedValue
            objBrandType.LicenseID = CDbl(grdBrand.Item("licenseid", BrandrwIndex).Value)
            objBrandType.CategorySizeLinkID = cmbsize.SelectedValue
            objBrandType.AutoDate = dtpDate.Value
            ObjPriDt = objBrandType.FunFetchBrandQuntity()
            If ObjPriDt.Rows.Count > 0 Then
                lblstock.Text = ObjPriDt.Rows(0).Item("BrandStock").ToString()

            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
        End Try
    End Sub

    Private Sub AddHideGridColumns()
        Try
            'Brand Grid
            grdBrand.Columns("LicenseID").Visible = False
            grdBrand.Columns("brandopeningid").Visible = False
            'grdBrand.Columns("stockqty").Visible = False
            grdBrand.Columns("categorysizelinkupid").Visible = False
            'grdBrand.Columns("lpeg").Visible = False
            'grdBrand.Columns("lpegrate").Visible = False
            'grdBrand.Columns("bottleqty").Visible = False
            'grdBrand.Columns("bottlerate").Visible = False
            grdBrand.Columns("licensecodeid").Visible = False

            grdBrand.Columns("isnegative").ReadOnly = True

            grdBrand.Columns("Brand").Width = 150
            grdBrand.Columns("isnegative").Width = 80
            grdBrand.Columns("stock").Width = 80


            grdBrand.Columns.Add("Newbrandopeningid", "Newbrandopeningid")
            grdBrand.Columns("Newbrandopeningid").Visible = False
            grdBrand.Columns.Add("NewBrand", "Brand")
            grdBrand.Columns("newBrand").Width = 150
            grdBrand.Columns.Add("NewSize", "Size")


            For index = 0 To grdBrand.RowCount - 1
                If CBool(grdBrand.Item("isnegative", index).Value) Then
                    grdBrand.Rows(index).DefaultCellStyle.BackColor = Color.OrangeRed
                End If

            Next

            'Cocktail Grid
            grdCocktail.Columns("CocktailID").Visible = False
            'grdCocktail.Columns("LicenseID").Visible = False
            'grdCocktail.Columns("LicensecodeID").Visible = False
            'grdCocktail.Columns("ISCocktailNegative").Visible = False

            grdCocktail.Columns("ISCocktailNegative").ReadOnly = True

            grdCocktail.Columns.Add("NewCocktailID", "CocktailID")
            grdCocktail.Columns("NewCocktailID").Visible = False
            grdCocktail.Columns.Add("NewCocktailName", "Cocktail Name")
            grdCocktail.Columns.Add("NewCocktailRate", "Cocktail Rate")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ColorCocktail()
        For index = 0 To grdCocktail.RowCount - 1
            If CBool(grdCocktail.Item("ISCocktailNegative", index).Value) Then
                grdCocktail.Rows(index).DefaultCellStyle.BackColor = Color.OrangeRed
            End If
        Next

    End Sub

    Private Sub AddBrand()
        If Not TypeOf cmbBrand.SelectedValue Is Decimal Then
            MsgBox("Select Brand", MsgBoxStyle.Information)
           
            Exit Sub
        ElseIf Not TypeOf cmbSize.SelectedValue Is Decimal Then
            MsgBox("Select Size", MsgBoxStyle.Information)
            Exit Sub
        ElseIf Not cmbSize.SelectedValue = grdBrand.Item("CategorySizeLinkUpID", BrandrwIndex).Value Then
            MsgBox("Category Not Matching", MsgBoxStyle.Information)
            Exit Sub
        End If
        Try
            Dim objAutoBill As New ClsAutobilling
            Dim dblUnitwiseQty As Double
            objAutoBill.BrandID = cmbBrand.SelectedValue
            objAutoBill.LicenseID = grdBrand.Item("licenseid", BrandrwIndex).Value
            objAutoBill.CategorySizeLinkID = cmbSize.SelectedValue
            objAutoBill.AutoDate = dtpDate.Value
            objdt = objAutoBill.FunFetchBrandQuntity()
            dblUnitwiseQty = objAutoBill.UnitwiseQty
           
            If grdBrand.Item("stockqty", BrandrwIndex).Value > dblUnitwiseQty Then
                MsgBox("Less Stock", MsgBoxStyle.Information)
                cmbBrand.SelectedValue = 0
                cmbSize.DataSource = Nothing
                Exit Sub
            End If

            Objpurchase = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable
            Objpurchase.BrandID = cmbBrand.SelectedValue
            Objpurchase.CategorySizeLinkID = cmbSize.SelectedValue
            objdt = Objpurchase.BindPurchaseRate
            If objdt.Rows.Count > 0 Then

                grdBrand.Item("newBrandopeningId", BrandrwIndex).Value = objdt.Rows(0).Item("BrandopeningId")
                grdBrand.Item("newbrand", BrandrwIndex).Value = cmbBrand.Text
                grdBrand.Item("newsize", BrandrwIndex).Value = cmbSize.Text
                grdBrand.Item("isnegative", BrandrwIndex).Value = False
                grdBrand.Rows(BrandrwIndex).DefaultCellStyle.BackColor = Color.LightGreen
                cmbBrand.SelectedValue = 0
                cmbSize.DataSource = Nothing
                lblStock.Text = ""
            End If

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

    Private Sub AddCocktail()
        If Not TypeOf cmbCocktail.SelectedValue Is Decimal Then
            Exit Sub
        End If
        Objcocktail = New CWPlusBL.Master.ClsAutobilling
        objdt = New DataTable
        Objcocktail.CocktailId = cmbCocktail.SelectedValue
        Objcocktail.LicenseID = CDbl(grdCocktail.Item("LicenseID", CocktailRwIndex).Value)
        objdt = Objcocktail.BindCocktailRate
        If objdt.Rows.Count > 0 Then
            grdCocktail.Item("NewCocktailID", CocktailRwIndex).Value = cmbCocktail.SelectedValue
            grdCocktail.Item("NewCocktailName", CocktailRwIndex).Value = cmbCocktail.Text
            grdCocktail.Item("NewCocktailRate", CocktailRwIndex).Value = objdt.Rows(0)("Rate")

        End If
    End Sub

    Private Sub ImportFile()

        Dim opnflDlg As New OpenFileDialog
        If opnflDlg.ShowDialog = DialogResult.OK Then
            strFileName = opnflDlg.FileName

            If dtMasterDet.Rows(0)("positionbillno") = 0 Then
                BoolPriUpdateBillNo = True
                CreateFileForSkala(opnflDlg.FileName)
            Else
                SetFiles(opnflDlg.FileName)
            End If

        End If
    End Sub

    Public Function Save() As Boolean
        Save = False
        If Not GblBoolNew Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Interface File Sale")
            Exit Function
        End If
        Try
            ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
            ObjInterfaceFile.InterfaceFileDate = dtpDate.Value
            ObjInterfaceFile.BrandXml = GenerateInterfaceFileXML()
            ObjInterfaceFile.CocktailXml = GenerateCocktailXML()
            ObjInterfaceFile.PermitHolderXml = GeneratePermitXML(dtXMLpermitholder.DefaultView.ToTable)
            ObjInterfaceFile.UserName = gblUserName
            Save = ObjInterfaceFile.FunSave()
            If BoolPriUpdateBillNo Then
                UpdateBillMaster()
            End If
            MsgBox(ObjInterfaceFile.ErrorMsg)
            grdCocktail.DataSource = Nothing
            grdBrand.DataSource = Nothing

            If Trim(dtMasterDet.Rows(0)("backupfilepath")) <> "" Then
                Dim dest As String = Path.Combine(dtMasterDet.Rows(0)("backupfilepath"), Path.GetFileName(strFileName))
                If File.Exists(dest) Then File.Delete(dest)
                File.Move(strFileName, dest)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub UpdateBillMaster()
        Try
            Dim xmldoc As New XmlDocument
            xmldoc.LoadXml("<Interface><Billmaster></Billmaster></Interface>")
            Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
            For index = 0 To ObjPriBillDt.Rows.Count - 1
                XmlElt = xmldoc.CreateElement("License")
                XmlElt.SetAttribute("Licenseid", ObjPriBillDt.Rows(index)("Licenseid"))
                XmlElt.SetAttribute("CurrentBillNo", ObjPriBillDt.Rows(index)("CurrentBillNo"))
                xmldoc.DocumentElement.Item("Billmaster").AppendChild(XmlElt)
            Next

            ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
            ObjInterfaceFile.BrandXml = xmldoc
            ObjInterfaceFile.UpdateBillMaster()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GetDate(ByVal filename As String)
        Dim str As String = Path.GetFileNameWithoutExtension(filename).Replace(dtMasterDet.Rows(0)("fileprefix"), "")
        If dtMasterDet.Rows(0)("date") = "YYYYMMDD" Then

            GoTo step1
        End If
        str = str.Insert(2, "/")
        str = str.Insert(5, "/")
        Select Case dtMasterDet.Rows(0)("date")
            Case "DDMMYYYY"
               str = str.Insert(0, str.Substring(3, 3))
                str = str.Remove(6, 3)
            Case "DDMMYY"
               str = str.Insert(0, str.Substring(3, 3))
                str = str.Remove(6, 3)
                'Case "MMDDYY" Or "MMDDYYYY"
            Case "YYMMDD"
                str = str.Insert(str.Length - 1, str.Substring(0, 2))
                str = str.Remove(0, 2)
        End Select

step1:  dtpDate.Value = CDate(str)
    End Sub

    Public Sub SetFiles(ByVal Filename As String)
        'If Not dtpDate.Enabled Then
        'End If
        'If Not dtMasterDet.Rows(0)("DATE") = "Null" Then
        '    GetDate(Filename)
        'End If

        Dim dt As New DataTable
        dt.Columns.Add("LicenseCode")
        dt.Columns.Add("BillNo")
        dt.Columns.Add("BrandCode")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Rate")
      
        Dim safeFileName As String = Path.GetFileName(Filename)

        Dim dataLines() As String = File.ReadAllLines(Filename)
        'If dtMasterDet.Rows(0)("date") = "Null" Then
        '    dtpDate.Value = Date.Parse(Path.GetFileNameWithoutExtension(Filename).Replace(dtMasterDet.Rows(0)("fileprefix"), ""))
        'End If

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

            If dtMasterDet.Rows(0)("PositionPriceSequence") <> 0 And chkCol Then
                dt.Columns.Add("PriceSeq")
                chkCol = False
            End If
            Dim strFlName As String = ""
            If dtMasterDet.Rows(0)("licensecodedef") = 1 Then
                strFlName = safeFileName.Substring((CInt(dtMasterDet.Rows(0)("licensecodeposition")) - 1), dtMasterDet.Rows(0)("licensecodelength"))
                'dt.Rows.Add(strFlName, ArrData(0), ArrData(1), ArrData(2), ArrData(3))
                dt.Rows.Add(strFlName, ArrData(dtMasterDet.Rows(0)("positionbillno") - 1), ArrData(dtMasterDet.Rows(0)("positioncode") - 1), ArrData(dtMasterDet.Rows(0)("positionqty") - 1), ArrData(dtMasterDet.Rows(0)("positionrate") - 1))
            ElseIf dtMasterDet.Rows(0)("licensecodedef") = 2 Then
                strFlName = ArrData(dtMasterDet.Rows(0)("licensecodeposition") - 1).ToString.Substring(0, dtMasterDet.Rows(0)("licensecodelength"))
                If dtMasterDet.Rows(0)("positionbillno") = 1 Then
                    'commented by sachin for licensecode + billno
                    'dt.Rows.Add(strFlName, ArrData(0).ToString.Replace(strFlName, ""), ArrData(dtMasterDet.Rows(0)("positioncode") - 1), ArrData(dtMasterDet.Rows(0)("positionqty") - 1), ArrData(dtMasterDet.Rows(0)("positionrate") - 1))
                    dt.Rows.Add(strFlName, Trim(ArrData(0)), Trim(ArrData(dtMasterDet.Rows(0)("positioncode") - 1)), Trim(ArrData(dtMasterDet.Rows(0)("positionqty") - 1)))
                Else
                    dt.Rows.Add(strFlName, Trim(ArrData(dtMasterDet.Rows(0)("positionbillno") - 1)), Trim(ArrData(dtMasterDet.Rows(0)("positioncode") - 1)), Trim(ArrData(dtMasterDet.Rows(0)("positionqty") - 1)))
                End If
                If Not dtMasterDet.Rows(0)("positionrate") = 0 Then
                    dt.Rows(dt.Rows.Count - 1)("Rate") = Trim(ArrData(dtMasterDet.Rows(0)("positionrate") - 1))
                Else
                    dt.Rows(dt.Rows.Count - 1)("Rate") = 0
                End If

            ElseIf dtMasterDet.Rows(0)("licensecodedef") = 3 Then
                strFlName = Path.GetFileNameWithoutExtension(safeFileName)
                dt.Rows.Add(strFlName, Trim(ArrData(1)), Trim(ArrData(2)), Trim(ArrData(3)), Trim(ArrData(dtMasterDet.Rows(0)("positionpricesequence") - 1)))
            End If
            'dt.Rows.Add(strFlName, ArrData(0).ToString.Substring(dtMasterDet.Rows(0)("licensecodelength"), ArrData(0).ToString.Length - dtMasterDet.Rows(0)("licensecodelength")), ArrData(1), ArrData(2), ArrData(3))

            If dt.Columns.Contains("PriceSeq") Then
                dt.Rows(dt.Rows.Count - 1)("PriceSeq") = Trim(ArrData(dtMasterDet.Rows(0)("positionpricesequence") - 1))
            End If
        Next

        Dim newDs As New DataSet
        ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
        ObjInterfaceFile.InterfaceFileDate = dtpDate.Value
        If dtMasterDet.Rows(0)("PositionPriceSequence") <> 0 Then
            ObjInterfaceFile.IsPriceSeqAvail = True
        Else
            ObjInterfaceFile.IsPriceSeqAvail = False
        End If
        ObjInterfaceFile.InterfaceFileXml = GenerateBrandXML(dt)
        ObjInterfaceFile.UserID = gblUserID
        newDs = ObjInterfaceFile.FunFetchInterfacefiledata()
        If newDs.Tables(2).Rows.Count > 0 Then
            Dim objBrCd As New dlgBrandCodeForInterfaceFile(newDs.Tables(2))
            objBrCd.ShowDialog()
            'MsgBox("Code not found for " & ObjInterfaceFile.ErrorMsg, MsgBoxStyle.Information, "Interface File")
        End If
        grdBrand.Columns.Clear()
        grdBrand.DataSource = Nothing
        grdBrand.DataSource = newDs.Tables(0)

        If CInt(grdBrand.RowCount) > 0 Then
            BindBrand(0)
        End If


        grdCocktail.Columns.Clear()
        grdCocktail.DataSource = Nothing
        grdCocktail.DataSource = newDs.Tables(1)

        AddHideGridColumns()
        'ColorCocktail()
    End Sub

    Private Sub CreateFileForSkala(Filename As String)
        Dim LicenseCode As String = ""
        Try
            Dim dt As New DataTable
            dt.Columns.Add("LicenseCode")
            dt.Columns.Add("BillNo")
            dt.Columns.Add("BrandCode")
            dt.Columns.Add("Quantity")
            dt.Columns.Add("Rate")

            Dim safeFileName As String = Path.GetFileName(Filename)

            Dim dataLines() As String = File.ReadAllLines(Filename)

          
            If Not Path.GetExtension(safeFileName).ToLower = "." & dtMasterDet.Rows(0)("fileextension").ToString.ToLower Then
                MsgBox("File Extension mismatched")
                Exit Sub
            End If

            For Each item As String In dataLines
                Dim ArrData As Array = item.Split(dtMasterDet.Rows(0)("symbol"))
                If ArrData.Length = 1 Then
                    LicenseCode = item
                    Continue For
                End If
                dt.Rows.Add(LicenseCode, 1, ArrData(0), ArrData(1), ArrData(2))
            Next

            Dim newDs As New DataSet
            ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
            ObjInterfaceFile.InterfaceFileDate = dtpDate.Value
            If dtMasterDet.Rows(0)("PositionPriceSequence") <> 0 Then
                ObjInterfaceFile.IsPriceSeqAvail = True
            Else
                ObjInterfaceFile.IsPriceSeqAvail = False
            End If
            ObjInterfaceFile.InterfaceFileXml = GenerateBrandXML(dt)
            ObjInterfaceFile.UserID = gblUserID
            newDs = ObjInterfaceFile.FunFetchInterfacefiledata()
            If newDs.Tables(2).Rows.Count > 0 Then
                Dim objBrCd As New dlgBrandCodeForInterfaceFile(newDs.Tables(2))
                objBrCd.ShowDialog()
                'MsgBox("Code not found for " & ObjInterfaceFile.ErrorMsg, MsgBoxStyle.Information, "Interface File")
            End If
            grdBrand.Columns.Clear()
            grdBrand.DataSource = Nothing
            grdBrand.DataSource = newDs.Tables(0)

            If CInt(grdBrand.RowCount) > 0 Then
                BindBrand(0)
            End If


            grdCocktail.Columns.Clear()
            grdCocktail.DataSource = Nothing
            grdCocktail.DataSource = newDs.Tables(1)

            AddHideGridColumns()
            'ColorCocktail()

            FunFetchBillMaster()

            Dim ObjLovDv As New DataView
            For index = 0 To grdBrand.RowCount - 1
                If CBool(grdBrand.Item("isnegative", index).Value) Then
                    Continue For
                End If
                ObjLovDv = ObjPriBillDt.DefaultView
                ObjLovDv.RowFilter = "LicenseDesc='" & Trim(grdBrand("License", index).Value) & "'"
                ObjLovDv(0)("CurrentBillNo") = ObjLovDv(0)("CurrentBillNo") + 1
                If ObjLovDv(0)("CurrentBillNo") > ObjLovDv(0)("CurrentBillNo") Then
                    imgSave.Enabled = False
                    MsgBox("Please Increase Bill Range")
                    Exit Sub
                End If
                grdBrand.Item("Bill No", index).Value = ObjLovDv(0)("CurrentBillNo")
            Next

            For index = 0 To grdCocktail.RowCount - 1
                If CBool(grdCocktail.Item("IsCocktailNegative", index).Value) Then
                    Continue For
                End If
                ObjLovDv = ObjPriBillDt.DefaultView
                ObjLovDv.RowFilter = "LicenseId='" & Trim(grdCocktail("LicenseId", index).Value) & "'"
                ObjLovDv(0)("CurrentBillNo") = ObjLovDv(0)("CurrentBillNo") + 1

                If ObjLovDv(0)("CurrentBillNo") > ObjLovDv(0)("CurrentBillNo") Then
                    imgSave.Enabled = False
                    MsgBox("Please Increase Bill Range")
                    Exit Sub
                End If
                grdCocktail.Item("BillNo", index).Value = ObjLovDv(0)("CurrentBillNo")

            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Fetch Bill master table for skala
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FunFetchBillMaster()
        Dim ObjPriBill As New ClsBillMaster
        Try
            ObjPriBill.BillID = 0
            ObjPriBillDt = ObjPriBill.FunFetch()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjPriBill) = False Then
                ObjPriBill = Nothing
            End If
        End Try
    End Sub

    Public Sub BindFiles()
        Try
            Dim flInfo() As String = Directory.GetFiles(dtMasterDet.Rows(0)("FilePath"), Trim(dtMasterDet.Rows(0)("FilePrefix").ToString) & "*." & Trim(dtMasterDet.Rows(0)("FileExtension")))
            lstFiles.Items.AddRange(flInfo)
        Catch ex As Exception

        End Try

    End Sub

#End Region

    Private Sub frmInterFaceFileSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        If dtMasterDet.Rows.Count > 0 Then
            BindFiles()
            'BindBrand(0)
        Else
            MsgBox("Inerface file setup not found!", vbInformation, "CWPlus")
        End If
    End Sub

    'Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport1.Click
    '    ImportFile()
    'End Sub

    Private Sub cmbBrand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrand.SelectedIndexChanged

        If Not TypeOf (cmbBrand.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        BindSize(cmbBrand.SelectedValue)
    End Sub

    Private Sub grdInterface_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBrand.CellEnter
        BrandrwIndex = e.RowIndex
        BindBrand(0)
    End Sub

    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd1.Click
    '    AddBrand()
    'End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave1.Click
    '    Save()
    ' End Sub

    Private Sub grdCocktail_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCocktail.CellEnter
        CocktailRwIndex = e.RowIndex
        cmbCocktail.DataSource = Nothing
        BindCocktail(CDbl(grdCocktail.Item("LicenseID", e.RowIndex).Value))
    End Sub

    'Private Sub btnAddCocktail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCocktail1.Click
    '    AddCocktail()
    'End Sub

    
    'Private Sub btnShowFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowFiles.Click
    '    If btnShowFiles.Text = "Show Files" Then
    '        blShowFile = True
    '    Else
    '        blShowFile = False
    '    End If
    '    tmrShowFile.Enabled = True
    'End Sub

    'Private Sub btnUseThisFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseThisFile1.Click
    '    SetFiles(lstFiles.SelectedItem.ToString)
    'End Sub


    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
        'Dim Parentnode As New TreeNode("transaction")
        'Dim ChildNode As New TreeNode("sale")
        'Parentnode.Nodes.Add(ChildNode)
        'OpenForm(ChildNode)
        'Me.Close()
    End Sub

    Private Sub btnImport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        ResetVariables()
        ImportFile()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub btnUseThisFile_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseThisFile.Click
        ResetVariables()
        If lstFiles.SelectedItem = "" Then
            MsgBox("Select a file from list", MsgBoxStyle.Information, "Interface File")
            Exit Sub
        End If
        strFileName = lstFiles.SelectedItem.ToString
        'SetFiles(lstFiles.SelectedItem.ToString)
        If dtMasterDet.Rows(0)("positionbillno") = 0 Then
            BoolPriUpdateBillNo = True
            CreateFileForSkala(lstFiles.SelectedItem.ToString)
        Else
            SetFiles(lstFiles.SelectedItem.ToString)
        End If
    End Sub

    Private Sub btnAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AddBrand()
    End Sub

    Private Sub btnAddCocktail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCocktail.Click
        AddCocktail()
    End Sub

    Private Sub cmbSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSize.SelectedIndexChanged
        If Not TypeOf (cmbSize.SelectedValue) Is Decimal OrElse cmbSize.SelectedValue = 0 Then
            Exit Sub
        End If
        FetchBrandType()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            ColorCocktail()
        End If
    End Sub

    Private Sub BtnImportExcel_Click(sender As System.Object, e As System.EventArgs) Handles BtnImportExcel.Click
        Dim dt As New DataTable
        Dim DlgexcelFile As New OpenFileDialog
        DlgexcelFile.InitialDirectory = Application.StartupPath
        If DlgexcelFile.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim ObjOfc As New ExcelReader(DlgexcelFile.FileName, True, False)
            dt = GetExcelSheetData(DlgexcelFile.FileName)
        End If


        Dim newDs As New DataSet
        ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
        ObjInterfaceFile.InterfaceFileDate = dtpDate.Value
        ObjInterfaceFile.IsPriceSeqAvail = False
        ObjInterfaceFile.InterfaceFileXml = GenerateBrandXMLv2(dt)
        If IsNothing(ObjInterfaceFile.InterfaceFileXml) Then
            Exit Sub
        End If
        ObjInterfaceFile.UserID = gblUserID
        newDs = ObjInterfaceFile.FunFetchInterfacefiledata()
        If newDs.Tables(2).Rows.Count > 0 Then
            Dim objBrCd As New dlgBrandCodeForInterfaceFile(newDs.Tables(2))
            objBrCd.ShowDialog()
            'MsgBox("Code not found for " & ObjInterfaceFile.ErrorMsg, MsgBoxStyle.Information, "Interface File")
        End If
        grdBrand.Columns.Clear()
        grdBrand.DataSource = Nothing
        grdBrand.DataSource = newDs.Tables(0)

        If CInt(grdBrand.RowCount) > 0 Then
            BindBrand(0)
        End If


        grdCocktail.Columns.Clear()
        grdCocktail.DataSource = Nothing
        grdCocktail.DataSource = newDs.Tables(1)

        AddHideGridColumns()
        'ColorCocktail()
    End Sub

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

    Private Sub ResetVariables()
        Objpurchase = New CWPlusBL.Master.Clspurchase
        ObjInterfaceFile = New CWPlusBL.ClsInterfaceFile
        ObjInterfaceFileMaster = New CWPlusBL.Master.ClsInterfaceFileSetUp
        ObjDtPermitHolder = New CWPlusBL.Master.ClsPermitHolderMaster
        ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
        Objcocktail = New CWPlusBL.Master.ClsAutobilling
        objdt = Nothing
        dt = Nothing
        'ArrPermitList = Nothing
        BrandrwIndex = 0
        CocktailRwIndex = 0
        dtXMLpermitholder = Nothing
        ObjPriBillDt = Nothing
        BoolPriUpdateBillNo = False
    End Sub

End Class