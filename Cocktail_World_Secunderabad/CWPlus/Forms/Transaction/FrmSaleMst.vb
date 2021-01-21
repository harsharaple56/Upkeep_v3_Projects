Imports CWPlusBL.Master
Imports System.Xml
Public Class FrmSaleMst

    Dim Objpurchase As CWPlusBL.Master.Clspurchase
    Dim Objcocktail As CWPlusBL.Master.Clscocktail
    Dim ObjSale As CWPlusBL.Master.ClsSale
    Dim objlicense As CWPlusBL.Master.Utitity
    Dim ObjAssignctcode As CWPlusBL.Master.AssignCocktailCode
    Dim objdt As DataTable
    Dim ds As DataSet
    Dim dt As DataTable

    Dim spegAmt As Double
    Dim spegAmtTotal As Double
    Dim LpegAmt As Double
    Dim LpegAmtTotal As Double
    Dim BottalpegAmt As Double
    Dim BottalpegAmtTotal As Double
    Dim BoolPriBotandspeg As Boolean = False

    Public IsReport As Boolean = False

    Dim IsFormLoaded As Boolean = True

#Region "Procedures"
    Property BillID As Double = 0
    Public Sub ClrScr()
        grdBrand.Rows.Clear()
        grdCocktail.Rows.Clear()
        grdPermitName.Rows.Clear()
        txtBillno.Clear()
        Dtdate.Value = DateTime.Now
    End Sub

    Public Sub BindBrand(ByVal BrandOpeningID As Double)
        Try
            '[+][14/09/2019][Ajay Prajapati]
            'Dtdate.Enabled = False
            '[+][14/09/2019][Ajay Prajapati]

            Objpurchase = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable
            Objpurchase.BrandopeningID = BrandOpeningID
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            Objpurchase.TransDate = Dtdate.Text.ToString   'Added by Samvedna on [23-01-2020]

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
        Objpurchase = New CWPlusBL.Master.Clspurchase
        ds = New DataSet
        Try

            Objpurchase.BrandID = cmbbrand.SelectedValue
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            ds = Objpurchase.BindSizes
            cmbSize.DataSource = Nothing
            ComboBindingTemplate(cmbSize, ds.Tables(0), "alias", "CategorySizeLinkUpID")
            'With cmbsize
            '    .DataSource = ds.Tables(0)
            '    .DisplayMember = "alias"
            '    .ValueMember = "CategorySizeLinkUpID"
            '    .Text = ""
            '    .SelectedValue = -1
            'End With
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

    Public Sub BindTaxType()
        Try

            Objpurchase = New CWPlusBL.Master.Clspurchase
            ds = New DataSet
            Objpurchase.BrandID = cmbBrand.SelectedValue
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            ds = Objpurchase.BindSizes
            ComboBindingTemplate(cmbtaxType, ds.Tables(1), "Taxtype", "CategoryTaxId")

            Objpurchase = New CWPlusBL.Master.Clspurchase
            ds = New DataSet
            ds = Objpurchase.BindSizes
            ComboBindingTemplate(cmbCocktailTaxtype, ds.Tables(1), "Taxtype", "CategoryTaxId")

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

    Public Sub BindCocktail()
        Try
            ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
            ds = New DataSet
            ObjAssignctcode.AssigncocktailcodeId = cmbCocktail.SelectedValue
            ds = ObjAssignctcode.FetchAssigncocktail
            ComboBindingTemplate(cmbCocktail, ds.Tables(0), "Cocktailname", "CocktailId")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjAssignctcode) Then
                ObjAssignctcode = Nothing
            End If
            If Not IsNothing(ds) Then
                ds = Nothing
            End If
        End Try
    End Sub

    Public Sub BindPermitName()
        Dim ObjDtPermitHolder As New ClsPermitHolderMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjDtPermitHolder.ExpireDate = Dtdate.Value
            'Following Line is Commented By Sachin Shinde on 2nd Jan 2014
            'ObjDtPermitHolder.PermitHolderID = lblid.Text
            ObjDtPermitHolder.PermitHolderID = 0
            ObjPriDt = ObjDtPermitHolder.FunFetchPermitHolderExpiryDate
            ComboBindingTemplate(cmbPermitName, ObjPriDt, "dispfield", "PermitHolderID")

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
        'grdPermitType.Columns("DefaultRole").Visible = False

    End Sub

    Public Sub FetchBrandType()
        Dim objBrandType As New ClsAutobilling
        Dim ObjPriDt As New DataTable
        Try
            objBrandType.BrandID = cmbBrand.SelectedValue
            objBrandType.LicenseID = MDI.cmbLicenseName.SelectedValue
            objBrandType.CategorySizeLinkID = cmbSize.SelectedValue
            objBrandType.AutoDate = Dtdate.Value
            ObjPriDt = objBrandType.FunFetchBrandQuntity()
            If ObjPriDt.Rows.Count > 0 Then
                lblbrandName.Text = ObjPriDt.Rows(0).Item("BrandStock").ToString()
                lblbrandName.Visible = True
            End If


        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objBrandType) Then
                objBrandType = Nothing
            End If
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
        End Try
    End Sub

    Public Sub FetchPermitNameDet(ByVal PermitHolderID As Double)
        Dim ObjDtPermitHolder As New ClsPermitHolderMaster
        Dim ObjPriDt As New DataTable
        Try

            ObjDtPermitHolder.PermitHolderID = PermitHolderID
            ObjPriDt = ObjDtPermitHolder.FunFetch
            If ObjPriDt.Rows.Count > 0 Then
                grdPermitName.Rows.Add()
                Dim vCtr As Integer = grdPermitName.RowCount - 1
                grdPermitName.Item("PermitHolderID", vCtr).Value = PermitHolderID
                grdPermitName.Item("Permitname", vCtr).Value = ObjPriDt.Rows(0)("PermitHolderName")
                grdPermitName.Item("Permitno", vCtr).Value = ObjPriDt.Rows(0)("PermitHolderNumber")
                grdPermitName.Item("ExpDate", vCtr).Value = ObjPriDt.Rows(0)("PermitExpireDate")
                grdPermitName.Item("permittypeid", vCtr).Value = ObjPriDt.Rows(0)("permittypeid")
                grdPermitName.Item("permittype", vCtr).Value = ObjPriDt.Rows(0)("permitdesc")
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

    Public Function FetchCocktailRate() As Double
        Objcocktail = New CWPlusBL.Master.Clscocktail
        objdt = New DataTable
        Objcocktail.CocktailId = cmbCocktail.SelectedValue
        Objcocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
        objdt = Objcocktail.FunFetch

        Return objdt.Rows(0)("Rate")

    End Function

    Private Function GenerateBrandXML() As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Trans><Sale></Sale></Trans>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Brand")
        For index = 0 To grdBrand.RowCount - 1

            XmlElt = xmldoc.CreateElement("Brand")
            XmlElt.SetAttribute("BrandOpeningID", grdBrand.Item("brandid", index).Value)
            XmlElt.SetAttribute("BottleQty", grdBrand.Item("BottleQty", index).Value)
            XmlElt.SetAttribute("Bottlerate", grdBrand.Item("Bottlerate", index).Value)
            XmlElt.SetAttribute("Speg", grdBrand.Item("SpegQty", index).Value)
            XmlElt.SetAttribute("SpegRate", grdBrand.Item("SpegRate", index).Value)
            XmlElt.SetAttribute("Lpeg", grdBrand.Item("LpegQty", index).Value)
            XmlElt.SetAttribute("LpegRate", grdBrand.Item("LpegRate", index).Value)
            XmlElt.SetAttribute("CategorytaxID", grdBrand.Item("taxtypeid", index).Value)
            XmlElt.SetAttribute("Taxper", grdBrand.Item("Taxperc", index).Value)
            XmlElt.SetAttribute("TotalAmount", grdBrand.Item("TotalAmount", index).Value)
            xmldoc.DocumentElement.Item("Sale").AppendChild(XmlElt)

        Next

        Return xmldoc
    End Function

    Private Function GenerateCocktailXML() As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Trans><Sale></Sale></Trans>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Cocktail")
        For index = 0 To grdCocktail.RowCount - 1
            XmlElt = xmldoc.CreateElement("Cocktail")
            XmlElt.SetAttribute("Cocktailid", grdCocktail.Item("Cocktailid", index).Value)
            XmlElt.SetAttribute("Quantity", grdCocktail.Item("Qty", index).Value)
            XmlElt.SetAttribute("Rate", grdCocktail.Item("Rate", index).Value)
            XmlElt.SetAttribute("CategoryTaxTypeId", grdCocktail.Item("vTaxTypeId", index).Value)
            XmlElt.SetAttribute("TacPercentage", grdCocktail.Item("tax", index).Value)
            XmlElt.SetAttribute("taxamount", grdCocktail.Item("taxamt", index).Value)
            XmlElt.SetAttribute("amount", grdCocktail.Item("amount", index).Value)


            xmldoc.DocumentElement.Item("Sale").AppendChild(XmlElt)


        Next

        Return xmldoc
    End Function

    Private Function GeneratePermitXML() As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Trans><Sale></Sale></Trans>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Permit")
        For index = 0 To grdPermitName.RowCount - 1
            XmlElt = xmldoc.CreateElement("Permit")
            XmlElt.SetAttribute("PermitHolderID", grdPermitName.Item("PermitHolderID", index).Value)
            XmlElt.SetAttribute("PermitHolderName", grdPermitName.Item("PermitName", index).Value)
            If grdPermitName.Item("ExpDate", index).Value = "Life Time" Then
                XmlElt.SetAttribute("PermitExpireDate", "1-Jan-1900")
            Else
                XmlElt.SetAttribute("PermitExpireDate", Format(grdPermitName.Item("ExpDate", index).Value)) ', "dd-MMM-yyyy"))
            End If
            XmlElt.SetAttribute("PermitTypeID", grdPermitName.Item("PermitTypeID", index).Value)
            xmldoc.DocumentElement.Item("Sale").AppendChild(XmlElt)
        Next

        Return xmldoc
    End Function
    Public Function ValidateQty()
        ValidateQty = True
        For cntr = 0 To grdBrand.Rows.Count - 1
            If IsNothing(grdBrand.Item("spegqty", cntr).Value) Then
                grdBrand.Item("spegqty", cntr).Value = 0
            End If
            If IsNothing(grdBrand.Item("lPegQty", cntr).Value) Then
                grdBrand.Item("lPegQty", cntr).Value = 0
            End If
            If IsNothing(grdBrand.Item("bottleqty", cntr).Value) Then
                grdBrand.Item("bottleqty", cntr).Value = 0
            End If

            If grdBrand.Item("spegqty", cntr).Value = 0 And grdBrand.Item("lPegQty", cntr).Value = 0 And grdBrand.Item("bottleqty", cntr).Value = 0 Then
                MsgBox("Please insert quantity")
                ValidateQty = False
                Exit Function
            End If
        Next
    End Function



    Public Function Save() As Boolean
        Save = False

        '[+][13/12/2019][Ajay Prajapati]
        'Dim VarianceCount As Integer

        'Dim ObjSaler As New ClsSale
        'Dim ObjCheckVariance As New DataTable
        'ObjSaler.LicenseID = MDI.cmbLicenseName.SelectedValue
        'ObjSaler.BillDate = Dtdate.Value
        'ObjSaler.TransactionType = "S" 'Sale
        'ObjCheckVariance = ObjSaler.FunCheckVariance()
        'If (ObjCheckVariance.Rows.Count > 0) Then
        '    VarianceCount = Convert.ToInt32(ObjCheckVariance.Rows(0)("VarianceCount"))
        'End If

        'If (VarianceCount > 0) Then
        '    Dim Ans As String = MsgBox("Can not save the sale since Variance done", MsgBoxStyle.OkOnly, "Sale")
        '    If Ans = vbNo Then
        '        Exit Function
        '    End If
        'Else

        '[-][13/12/2019][Ajay Prajapati]

        Dim StrPriNeg As String = ""
        Try

            StrPriNeg = NegativeStock()
            If StrPriNeg <> "" Then
                MsgBox(StrPriNeg)
                Exit Function
            End If

            For cntr = 0 To grdBrand.Rows.Count - 1
                If grdBrand.Item("sPegQty", cntr).Value And grdBrand.Item("lPegQty", cntr).Value And grdBrand.Item("BottleQty", cntr).Value = 0 Then
                    MsgBox("Please Insert qty")
                    Exit Function
                End If

            Next


            ObjSale = New CWPlusBL.Master.ClsSale
            ObjSale.BillID = lblid.Text
            ObjSale.BillNo = txtBillno.Text
            ObjSale.BillDate = Dtdate.Value
            ObjSale.LicenseID = MDI.cmbLicenseName.SelectedValue

            ObjSale.BrandSaleXML = GenerateBrandXML()
            ObjSale.BrandPermitXML = GeneratePermitXML()
            ObjSale.BrandCocktailXML = GenerateCocktailXML()
            ObjSale.UserName = gblUserName
            Save = ObjSale.FunSave
            MsgBox(ObjSale.ErrorMsg)
            ClrScr()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjSale) Then
                ObjSale = Nothing
            End If
        End Try

        'End If

    End Function

    

    Private Function NegativeStock() As String
        NegativeStock = ""
        Dim ObjPriDt As New DataTable
        Dim ObjDtAutoBill As New ClsTransfer
        Dim xmlGridBrand As New XmlDocument
        Dim xmlGridCocktail As New XmlDocument
        Try

            xmlGridBrand.LoadXml("<Trans><Sale></Sale></Trans>")
            Dim XmlElt As XmlElement = xmlGridBrand.CreateElement("Brand")
            For index = 0 To grdBrand.Rows.Count - 1

                XmlElt = xmlGridBrand.CreateElement("Brand")
                XmlElt.SetAttribute("billno", 0)
                XmlElt.SetAttribute("BrandOpeningID", grdBrand.Item("brandid", index).Value)
                XmlElt.SetAttribute("BottleQty", grdBrand.Item("BottleQty", index).Value)
                XmlElt.SetAttribute("Bottlerate", 0)
                XmlElt.SetAttribute("Speg", grdBrand.Item("Spegqty", index).Value)
                XmlElt.SetAttribute("SpegRate", 0)
                XmlElt.SetAttribute("Lpeg", grdBrand.Item("Lpegqty", index).Value)
                XmlElt.SetAttribute("LpegRate", 0)
                XmlElt.SetAttribute("CategorytaxID", 0)
                XmlElt.SetAttribute("Taxper", 0)
                XmlElt.SetAttribute("TotalAmount", 0)
                xmlGridBrand.DocumentElement.Item("Sale").AppendChild(XmlElt)
            Next

            xmlGridCocktail.LoadXml("<Trans><cocktailSale></cocktailSale></Trans>")
            XmlElt = xmlGridCocktail.CreateElement("Cocktail")
            For index = 0 To grdCocktail.Rows.Count - 1
                XmlElt = xmlGridCocktail.CreateElement("Cocktail")
                XmlElt.SetAttribute("billno", 0)
                XmlElt.SetAttribute("Cocktailid", grdCocktail.Item("Cocktailid", index).Value)
                XmlElt.SetAttribute("Qty", grdCocktail.Item("Qty", index).Value)
                XmlElt.SetAttribute("Rate", grdCocktail.Item("Rate", index).Value)
                XmlElt.SetAttribute("CategoryTaxTypeId", 0)
                XmlElt.SetAttribute("TaxPercetage", 0)
                XmlElt.SetAttribute("cocktailtotal", 0)
                xmlGridCocktail.DocumentElement.Item("cocktailSale").AppendChild(XmlElt)
            Next



            ObjDtAutoBill.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDtAutoBill.XmlBrand = xmlGridBrand
            ObjDtAutoBill.XmlCocktail = xmlGridCocktail
            ObjDtAutoBill.BillID = lblid.Text

            ObjPriDt = ObjDtAutoBill.FunValidateNegativeStockForSale(Dtdate.Value)
            If ObjPriDt.Rows.Count > 0 Then
                NegativeStock = "Negative stock found for" & vbCrLf
                For IntDtCnt = 0 To ObjPriDt.Rows.Count - 1
                    NegativeStock += ObjPriDt.Rows(IntDtCnt)("branddesc") & " : " & ObjPriDt.Rows(IntDtCnt)("stock") & vbCrLf
                Next
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
            If IsNothing(ObjDtAutoBill) = False Then
                ObjDtAutoBill = Nothing
            End If
        End Try
    End Function
#End Region

    Private Sub cmbbrand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrand.SelectedIndexChanged
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If

        If Not TypeOf (cmbBrand.SelectedValue) Is Decimal Then
            Exit Sub
        End If

        If Not cmbBrand.SelectedValue > 0 Then
            Exit Sub
        End If
        BindSize(cmbBrand.SelectedValue)
        'FetchBrandType()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, AddToolStripMenuItem1.Click
        If Not TypeOf cmbBrand.SelectedValue Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf cmbSize.SelectedValue Is Decimal Then
            Exit Sub
        End If


        Objpurchase = New CWPlusBL.Master.Clspurchase
        objdt = New DataTable
        Objpurchase.BrandID = cmbBrand.SelectedValue
        Objpurchase.CategorySizeLinkID = cmbSize.SelectedValue
        objdt = Objpurchase.BindPurchaseRate
        Dim Objpurchase1 As CWPlusBL.Master.ClscategoryTax
        Objpurchase1 = New CWPlusBL.Master.ClscategoryTax
        'dt = New DataTable
        Objpurchase1.CategoryTaxID = cmbtaxType.SelectedValue
        dt = Objpurchase1.FunFetchcategorytax
        Dim djmak As Double
        If dt.Rows.Count > 0 Then
            djmak = dt.Rows(0).Item("Taxpercetage")
        End If

        IsFormLoaded = False
        If cmbtaxType.SelectedValue = 1 Then
            grdBrand.Rows.Add(objdt.Rows(0).Item("brandopeningID"), cmbBrand.Text, cmbSize.SelectedValue, cmbSize.Text, cmbtaxType.SelectedValue, "", djmak, 0, objdt.Rows(0).Item("SpegRate"), 0, objdt.Rows(0).Item("LpegRate"), 0, objdt.Rows(0).Item("sRate"), "", lblbrandName.Text)
            cmbBrand.Focus()
        Else
            grdBrand.Rows.Add(objdt.Rows(0).Item("brandopeningID"), cmbBrand.Text, cmbSize.SelectedValue, cmbSize.Text, cmbtaxType.SelectedValue, cmbtaxType.Text, djmak, 0, objdt.Rows(0).Item("SpegRate"), 0, objdt.Rows(0).Item("LpegRate"), 0, objdt.Rows(0).Item("sRate"), "", lblbrandName.Text)
            cmbBrand.Focus()
            'Trial By Shiva
            'grdBrand.Rows.Add(objdt.Rows(0).Item("brandopeningID"), cmbBrand.Text, cmbSize.SelectedValue, cmbSize.Text, cmbtaxType.SelectedValue, cmbtaxType.Text, djmak, 0, 1, 0, 2, 0, 3, "", lblbrandName.Text)
        End If
        lblbrandName.Text = ""
        cmbBrand.SelectedValue = 0
        cmbSize.DataSource = Nothing
        cmbtaxType.SelectedValue = 0
    End Sub

    Private Sub FrmSaleMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        ' FetchSale()
        lblbrandName.Visible = False
        BindBrand(0)
        BindTaxType()

        BindCocktail()
        BindPermitName()
        If BillID <> 0 Then
            Me.lblid.Text = BillID
            FetchSale()

            lblbrandName.Visible = False
            BindBrand(0)
            BindTaxType()

            BindCocktail()
            'Following Line is Commented By Sachin Shinde on 2nd Jan 2014
            ' BindPermitName()

            Exit Sub
        Else

            FetchCurrentBillNumberForSaleMaster()
            txtBillno.Text = SaleCurrentBillNo + 1

        End If

        If GblPurchaseDate <> #1/1/1900# Then
            Dim dtLastDate As Date
            '[+][14/09/2019][Ajay Prajapati]
            dtLastDate = GblPurchaseDate.AddDays(-1)
            'dtLastDate = GblPurchaseDate
            '[-][14/09/2019][Ajay Prajapati]
            Dtdate.Value = dtLastDate.ToShortDateString()
            ' Dtdate.Value = Convert.ToDateTime(GblPurchaseDate.AddDays(-1))
            ' Dtdate.Value = dtLastDate.ToString("mm/dd/yyyy")
            BindSettalementGrid()
        End If

        '  BindPermitName()



    End Sub

#Region "Settalement Function"
    Public Sub BindSettalementGrid()

        Dim ObjSettalement As New CWPlusBL.Master.ClsAutobilling
        Dim ObjDt As New DataTable
        Try
            ObjSettalement.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjSettalement.AutoDate = GblPurchaseDate.ToString("dd-MMM-yyyy")
            ObjDt = ObjSettalement.funFetchSettelementData(2)
            '  grdBrand.DataSource = ObjDt

            If ObjDt.Rows.Count > 0 Then

                For index = 0 To ObjDt.Rows.Count - 1
                    grdBrand.Rows.Add()
                    grdBrand.Item("brandid", index).Value = ObjDt.Rows(index)("brandID")
                    grdBrand.Item("Brand", index).Value = ObjDt.Rows(index)("Brand")
                    grdBrand.Item("CategorySizeLinkUpID", index).Value = ObjDt.Rows(index)("CategorySizeLinkUpID")
                    grdBrand.Item("Size", index).Value = ObjDt.Rows(index)("Size")
                    grdBrand.Item("taxtypeid", index).Value = ObjDt.Rows(index)("taxtypeid")
                    grdBrand.Item("taxtype", index).Value = ObjDt.Rows(index)("taxtype")
                    grdBrand.Item("taxperc", index).Value = ObjDt.Rows(index)("taxper")
                    grdBrand.Item("spegQty", index).Value = ObjDt.Rows(index)("speg")
                    grdBrand.Item("SpegRate", index).Value = ObjDt.Rows(index)("SpegRate")
                    grdBrand.Item("lPegQty", index).Value = ObjDt.Rows(index)("lPegQty")
                    grdBrand.Item("LpegRate", index).Value = ObjDt.Rows(index)("LpegRate")
                    grdBrand.Item("BottleQty", index).Value = ObjDt.Rows(index)("BottleQty")
                    grdBrand.Item("BottleRate", index).Value = ObjDt.Rows(index)("BottleRate")
                    grdBrand.Item("TotalAmount", index).Value = ObjDt.Rows(index)("Amount")
                    grdBrand.Item("Stock", index).Value = ObjDt.Rows(index)("Stock")
                Next
            End If

            FetchPermitNameDet(3)
            cmbPermitName.SelectedValue = 0

            Exit Sub
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjSettalement) = False Then
                ObjSettalement = Nothing
            End If

            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

#End Region

    Dim SaleCurrentBillNo As Integer
    Public Sub FetchCurrentBillNumberForSaleMaster()
        Dim ObjCurrentBill As New ClsAutobilling
        Dim ObjDt As New DataTable
        Try
            ObjCurrentBill.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDt = ObjCurrentBill.FunFetchCurrentBill()
            If ObjDt.Rows.Count > 0 Then
                SaleCurrentBillNo = ObjDt.Rows(0).Item("CurrentBillNo").ToString()
                gloBillEndNo = ObjDt.Rows(0).Item("BillEndNo").ToString()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If IsNothing(ObjCurrentBill) = False Then
                ObjCurrentBill = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If

        End Try
    End Sub

    'Private Sub btnCocktailAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCocktailAdd1.Click
    '    '  Dim Objpurchase1 As CWPlusBL.Master.ClscategoryTax
    '    If Not TypeOf cmbBrand.SelectedValue Is Decimal Then
    '        Exit Sub
    '    End If
    '    'If Not TypeOf cmbSize.SelectedValue Is Decimal Then
    '    '    Exit Sub
    '    'End If

    '    Dim Objpurchase1 As New CWPlusBL.Master.ClscategoryTax
    '    'dt = New DataTable
    '    Objpurchase1.CategoryTaxID = cmbtaxType.SelectedValue
    '    dt = Objpurchase1.FunFetchcategorytax
    '    Dim djmak As Double
    '    If dt.Rows.Count > 0 Then
    '        djmak = dt.Rows(0).Item("Taxpercetage")
    '    End If
    '    If cmbCocktailTaxtype.SelectedValue = 0 Then
    '        grdCocktail.Rows.Add(cmbCocktail.SelectedValue, cmbCocktail.Text, cmbCocktailTaxtype.SelectedValue, "", djmak)
    '    Else
    '        grdCocktail.Rows.Add(cmbCocktail.SelectedValue, cmbCocktail.Text, cmbCocktailTaxtype.SelectedValue, cmbCocktailTaxtype.Text, djmak)
    '    End If


    '    cmbCocktail.SelectedValue = 0
    '    cmbCocktailTaxtype.SelectedValue = 0

    'End Sub

    Private Sub btnPermitAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FetchPermitNameDet(cmbPermitName.SelectedValue)
        cmbPermitName.SelectedValue = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Save()
    End Sub
    Public Sub CalculateAmount(ByVal RowIdx As Integer)
        spegAmt = (grdBrand.Item("SpegQty", RowIdx).Value * grdBrand.Item("SpegRate", RowIdx).Value) * ((grdBrand.Item("taxperc", RowIdx).Value) / 100)
        spegAmtTotal = grdBrand.Item("SpegQty", RowIdx).Value * grdBrand.Item("SpegRate", RowIdx).Value + spegAmt
        LpegAmt = ((grdBrand.Item("LpegQty", RowIdx).Value * grdBrand.Item("Lpegrate", RowIdx).Value * grdBrand.Item("taxperc", RowIdx).Value) / 100)
        LpegAmtTotal = grdBrand.Item("LpegQty", RowIdx).Value * grdBrand.Item("Lpegrate", RowIdx).Value + LpegAmt
        BottalpegAmt = ((grdBrand.Item("BottleQty", RowIdx).Value * grdBrand.Item("Bottlerate", RowIdx).Value * grdBrand.Item("taxperc", RowIdx).Value) / 100)
        BottalpegAmtTotal = grdBrand.Item("BottleQty", RowIdx).Value * grdBrand.Item("Bottlerate", RowIdx).Value + BottalpegAmt
    End Sub
    Private Sub grdBrand_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBrand.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub

        If IsFormLoaded = True Then
            Exit Sub
        End If

        Dim newInteger As Integer
        If Not Integer.TryParse(grdBrand.Item(e.ColumnIndex, e.RowIndex).Value.ToString(), newInteger) OrElse newInteger < 0 Then
            grdBrand.Item(e.ColumnIndex, e.RowIndex).Value = 0
            MsgBox("Please enter only positive number", MsgBoxStyle.Information)
            Exit Sub
        End If
        If e.ColumnIndex >= 7 Or e.ColumnIndex <= 12 Then
            'grdBrand.Item("totalamount", e.RowIndex).Value = grdBrand.Item(e.ColumnIndex - 1, e.RowIndex).Value * grdBrand.Item(e.ColumnIndex, e.RowIndex).Value
            CalculateAmount(e.RowIndex)
            'grdBrand.Item("totalAmount", e.RowIndex).Value = spegAmt + LpegAmt + BottalpegAmt
            grdBrand.Item("totalamount", e.RowIndex).Value = spegAmtTotal + LpegAmtTotal + BottalpegAmtTotal
        End If
    End Sub

    Private Sub grdCocktail_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCocktail.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub

        If IsFormLoaded = True Then
            Exit Sub
        End If

        Dim newInteger As Integer
        If Not Integer.TryParse(grdCocktail.Item(e.ColumnIndex, e.RowIndex).Value.ToString(), newInteger) OrElse newInteger < 0 Then
            grdCocktail.Item(e.ColumnIndex, e.RowIndex).Value = 0
            MsgBox("Please enter only positive number", MsgBoxStyle.Information)
            Exit Sub
        End If

        If e.ColumnIndex = 6 Then
            grdCocktail.Item("taxamt", e.RowIndex).Value = (grdCocktail.Item("tax", e.RowIndex).Value * grdCocktail.Item("rate", e.RowIndex).Value * grdCocktail.Item("qty", e.RowIndex).Value) / 100
            grdCocktail.Item("amount", e.RowIndex).Value = grdCocktail.Item("taxamt", e.RowIndex).Value + (grdCocktail.Item("rate", e.RowIndex).Value * grdCocktail.Item("qty", e.RowIndex).Value)
        End If
    End Sub


    Private Sub Dtdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtdate.ValueChanged
        BindPermitName()
        BindBrand(0)   'Added by Samvedna on [23-01-2020]
    End Sub



    Public Function FetchSale() As Boolean

        Dim ObjSale As New ClsSale
        Dim ObjDt As New DataSet
        Try
            ObjSale.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjSale.BillID = lblid.Text
            ObjSale.BillNo = ""
            ObjSale.BillDate = "1-1-1900"
            ObjDt = ObjSale.FunFecthBrandCocktailPermit()

            'If ObjDt.Tables(4).Rows.Count > 0 Then
            '    MsgBox("Cannot Edit used in Variance", MsgBoxStyle.Information)
            '    Return False
            '    Exit Function
            'End If
            If ObjDt.Tables(0).Rows.Count > 0 Then
                txtBillno.Text = ObjDt.Tables(0).Rows(0).Item("BillNo")
                Dtdate.Text = ObjDt.Tables(0).Rows(0).Item("BillDate")
                MDI.cmbLicenseName.SelectedValue = ObjDt.Tables(0).Rows(0)("LicenseID")
            End If
            Dim ObjSale1Brand As New ClsSale
            Dim ObjPriDtBrand As New DataSet
            ObjSale1Brand.BillID = lblid.Text
            ObjSale1Brand.BillNo = txtBillno.Text
            ObjSale1Brand.BillDate = Dtdate.Value
            ObjPriDtBrand = ObjSale1Brand.FunFecthBrandCocktailPermit()


            If ObjPriDtBrand.Tables(1).Rows.Count > 0 Then
                IsFormLoaded = True
                For rwctr = 0 To ObjPriDtBrand.Tables(1).Rows.Count - 1
                    grdBrand.Rows.Add()

                    grdBrand.Item("Size", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("Alias")
                    grdBrand.Item("CategorySizeLinkUpID", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("sizeID")
                    grdBrand.Item("BrandID", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("BrandOpeningID")
                    grdBrand.Item("SpegQty", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("Speg")
                    grdBrand.Item("SpegRate", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("sPegRate")
                    grdBrand.Item("BottleQty", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("BottleQty")
                    grdBrand.Item("BottleRate", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("BottleRate")
                    grdBrand.Item("LpegQty", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("Lpeg")
                    grdBrand.Item("LpegRate", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("lPegRate")
                    grdBrand.Item("taxtypeid", rwctr).Value = IIf(ObjPriDtBrand.Tables(1).Rows(rwctr)("CategoryTaxId").ToString = "", 0, ObjPriDtBrand.Tables(1).Rows(rwctr)("CategoryTaxId"))
                    'grdBrand.Item("tax", rwctr).Value = ObjDt.Tables(1).Rows(rwctr)("Taxtype")
                    grdBrand.Item("Taxperc", rwctr).Value = IIf(ObjPriDtBrand.Tables(1).Rows(rwctr)("taxper").ToString = "", 0, ObjPriDtBrand.Tables(1).Rows(rwctr)("taxper"))
                    grdBrand.Item("TotalAmount", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("TotalAmount")
                    grdBrand.Item("Brand", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("brandDesc")
                    grdBrand.Item("taxtype", rwctr).Value = ObjPriDtBrand.Tables(1).Rows(rwctr)("taxtype")


                Next
                IsFormLoaded = False
            End If

            Dim ObjSaleCocktail As New ClsSale
            Dim ObjPriDtCock As New DataSet
            ObjSaleCocktail.BillID = lblid.Text
            ObjSaleCocktail.BillNo = txtBillno.Text
            ObjSaleCocktail.BillDate = Dtdate.Value

            ObjPriDtCock = ObjSaleCocktail.FunFecthBrandCocktailPermit()
            If ObjPriDtCock.Tables(2).Rows.Count > 0 Then
                IsFormLoaded = True
                For rwctr = 0 To ObjPriDtCock.Tables(2).Rows.Count - 1
                    grdCocktail.Rows.Add()
                    MDI.cmbLicenseName.SelectedValue = ObjPriDtCock.Tables(2).Rows(rwctr)("LicenseID")
                    '  cmbCocktail.SelectedValue = ObjPriDtCock.Tables(2).Rows(rwctr)("cocktailname")

                    grdCocktail.Item("cocktail", rwctr).Value = ObjPriDtCock.Tables(2).Rows(rwctr)("cocktailname")
                    grdCocktail.Item("vtaxtype", rwctr).Value = IIf(ObjPriDtCock.Tables(2).Rows(rwctr)("taxtype").ToString = "", Nothing, ObjPriDtCock.Tables(2).Rows(rwctr)("taxtype"))
                    ' grdCocktail.Item("taxtype", rwctr).Value = ObjPriDtCock.Tables(2).Rows(rwctr)("taxtype")
                    grdCocktail.Item("rate", rwctr).Value = ObjPriDtCock.Tables(2).Rows(rwctr)("rate")

                    grdCocktail.Item("qty", rwctr).Value = ObjPriDtCock.Tables(2).Rows(rwctr)("quantity")
                    grdCocktail.Item("tax", rwctr).Value = ObjPriDtCock.Tables(2).Rows(rwctr)("tacpercentage")
                    grdCocktail.Item("amount", rwctr).Value = ObjPriDtCock.Tables(2).Rows(rwctr)("cocktailtotal")
                    grdCocktail.Item("CocktailID", rwctr).Value = ObjPriDtCock.Tables(2).Rows(rwctr)("cocktailId")
                    grdCocktail.Item("vtaxtypeid", rwctr).Value = ObjPriDtCock.Tables(2).Rows(rwctr)("categorytaxid")

                Next
                IsFormLoaded = False
            End If

            Dim ObjSalePermit As New ClsSale
            Dim ObjPriDtPermit As New DataSet
            ObjSalePermit.BillID = lblid.Text
            ObjSalePermit.BillNo = txtBillno.Text
            ObjSalePermit.BillDate = Dtdate.Value
            ObjPriDtPermit = ObjSalePermit.FunFecthBrandCocktailPermit()
            If ObjPriDtPermit.Tables(3).Rows.Count > 0 Then
                For rwctr = 0 To ObjPriDtPermit.Tables(3).Rows.Count - 1
                    grdPermitName.Rows.Add()
                    grdPermitName.Item("ExpDate", rwctr).Value = ObjPriDtPermit.Tables(3).Rows(rwctr)("permitexpiredate")
                    grdPermitName.Item("permitholderid", rwctr).Value = ObjPriDtPermit.Tables(3).Rows(rwctr)("permitholderid")
                    grdPermitName.Item("permittypeid", rwctr).Value = ObjPriDtPermit.Tables(3).Rows(rwctr)("permittypeid")
                    grdPermitName.Item("permitname", rwctr).Value = ObjPriDtPermit.Tables(3).Rows(rwctr)("permitholdername")
                    grdPermitName.Item("permitno", rwctr).Value = ObjPriDtPermit.Tables(3).Rows(rwctr)("permitholdernumber")
                    grdPermitName.Item("permittype", rwctr).Value = ObjPriDtPermit.Tables(3).Rows(rwctr)("PermitDesc")
                Next
            End If

        Catch ex As Exception
            Throw ex
            If Not IsNothing(ObjSale) Then
                Objpurchase = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try

    End Function


    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click, SaveToolStripMenuItem.Click

        If BillID = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Sale")
                Exit Sub
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Sale")
                Exit Sub
            End If
        End If
        If grdBrand.RowCount = 0 And grdCocktail.RowCount = 0 Then
            MsgBox("Nothing to save")
            Exit Sub
        End If
        If grdPermitName.RowCount = 0 Then
            MsgBox("Permit holder list cannot be blank")
            Exit Sub
        End If
        If ValidateQty() = True Then
            If Save() = True Then

                'Dim Parentnode As New TreeNode("transaction")
                'Dim ChildNode As New TreeNode("sale")
                'Parentnode.Nodes.Add(ChildNode)
                'OpenForm(ChildNode)

                Me.Close()
                If IsReport Then
                    FrmCocktailReport.btnok.PerformClick()
                Else
                    FrnSaleList.btnSearch.PerformClick()
                End If

            End If
        End If

    End Sub

    

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click

        'Dim Parentnode As New TreeNode("transaction")
        'Dim ChildNode As New TreeNode("sale")
        'Parentnode.Nodes.Add(ChildNode)
        'OpenForm(ChildNode)

        Me.Close()
    End Sub

    Private Sub cmbSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSize.SelectedIndexChanged
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf (cmbSize.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        FetchBrandType()
    End Sub


    Private Sub btnCocktailAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCocktailAdd.Click
        '  Dim Objpurchase1 As CWPlusBL.Master.ClscategoryTax
        If Not TypeOf cmbBrand.SelectedValue Is Decimal Then
            Exit Sub
        End If
        'If Not TypeOf cmbSize.SelectedValue Is Decimal Then
        '    Exit Sub
        'End If

        Dim Objpurchase1 As New CWPlusBL.Master.ClscategoryTax
        'dt = New DataTable
        Objpurchase1.CategoryTaxID = cmbtaxType.SelectedValue
        dt = Objpurchase1.FunFetchcategorytax
        Dim djmak As Double
        If dt.Rows.Count > 0 Then
            djmak = dt.Rows(0).Item("Taxpercetage")
        End If
        IsFormLoaded = False
        If cmbCocktailTaxtype.SelectedValue = 0 Then
            grdCocktail.Rows.Add(cmbCocktail.SelectedValue, cmbCocktail.Text, cmbCocktailTaxtype.SelectedValue, "", djmak)
        Else
            grdCocktail.Rows.Add(cmbCocktail.SelectedValue, cmbCocktail.Text, cmbCocktailTaxtype.SelectedValue, cmbCocktailTaxtype.Text, djmak)
        End If


        cmbCocktail.SelectedValue = 0
        '    cmbCocktailTaxtype.SelectedValue = 0

    End Sub
    Private Sub btnPermitAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPermitAdd.Click
        FetchPermitNameDet(cmbPermitName.SelectedValue)
        cmbPermitName.SelectedValue = 0
    End Sub


    Private Sub txtEdit_Keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If BoolPriBotandspeg Then
            If IsNumeric(e.KeyChar.ToString()) Or e.KeyChar = ChrW(Keys.Back) Then
                e.Handled = False 'if numeric display 
            Else
                MsgBox("Enter Numbers Only")
                e.Handled = True  'if non numeric don't display
            End If
        End If
    End Sub

    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles grdBrand.EditingControlShowing
        If grdBrand.Columns(grdBrand.CurrentCell.ColumnIndex).Name = "bottleqty" Or grdBrand.Columns(grdBrand.CurrentCell.ColumnIndex).Name = "spegqty" Or _
            grdBrand.Columns(grdBrand.CurrentCell.ColumnIndex).Name = "lpegqty" Then
            BoolPriBotandspeg = True
            Dim txtEdit As TextBox = e.Control
            'remove any existing handler
            RemoveHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress
            AddHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress
        Else
            BoolPriBotandspeg = False
        End If

    End Sub
End Class