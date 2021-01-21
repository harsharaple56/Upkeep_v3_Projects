Imports System.Xml
Imports CWPlusBL.Master
Public Class FrmpurchaseMst
    Dim Objpurchase As CWPlusBL.Master.Clspurchase
    Dim objdt As DataTable
    Dim ObjCategorySizeLnkUp As CWPlusBL.Master.ClsCategorySizelinlup
    Dim objlicense As CWPlusBL.Master.Utitity
    Dim ds As DataSet
    Dim dt As DataTable
    Dim BoolPriBotandspeg As Boolean = False
    Public IsReport As Boolean = False
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Me.lblid.Text = text1

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
        AddTheme(SplitContainer2.Panel1)

    End Sub
    Property PurchaseID As Double = 0
    Private Sub Clrscr()
        cmbbrand.Text = ""
        cmbsize.Text = ""
        cmbtaxtype.Text = ""
        cmbSuplier.Text = ""
        cmblicense.Text = ""
        txtchg.Clear()
        txtGRNForCode.Clear()
        txtInvoiceno.Clear()
        txttpno.Clear()
        txtothchg.Clear()
        txtdesc.Clear()
        grdpurchase.Rows.Clear()
    End Sub
    Private Sub Frmpurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        Dim toolTip1 As New ToolTip()

        toolTip1.SetToolTip(btnAdd, "Add Rows To Grid.")
        toolTip1.ShowAlways = True
        toolTip1.IsBalloon = True
        BindLicense()
        bindsupplier()
        If PurchaseID <> 0 Then
            Me.lblid.Text = PurchaseID
            FetchPurchase()
        End If
        BindBrand(0)
    End Sub
    Private Sub BindLicense()
        Try

            objlicense = New CWPlusBL.Master.Utitity
            objdt = New DataTable
            objdt = objlicense.FunFetchLicense



            'objlicense.DataSource = Nothing
            ComboBindingTemplate(cmblicense, objdt, "LicenseDesc", "LicenseID")

            'With cmblicense
            '    .DisplayMember = "LicenseDesc"
            '    .ValueMember = "LicenseID"
            '    .DataSource = objdt
            '    .Text = ""
            '    .SelectedValue = -1
            'End With


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(objlicense) Then
                objlicense = Nothing
            End If
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
        End Try
    End Sub
    Public Sub bindsupplier()
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            ds = New DataSet
            ds = Objpurchase.BindSupplier
            ComboBindingTemplate(cmbSuplier, ds.Tables(0), "SupplierName", "SupplierID")
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
    Public Sub bindtax()
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            ds = New DataSet

            Objpurchase.BrandID = cmbbrand.SelectedValue
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            ds = Objpurchase.BindSizes
            ComboBindingTemplate(cmbtaxtype, ds.Tables(1), "Taxtype", "CategoryTaxId")
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


    Public Function CheckDuplicateRecord(ByVal vBrandOpeningID As Double) As Boolean
        CheckDuplicateRecord = False
        For rwctr = 0 To grdpurchase.RowCount - 1
            If vBrandOpeningID = grdpurchase("batch", rwctr).Value Then
                CheckDuplicateRecord = True
                Exit Function
            End If
        Next
    End Function
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, AddToolStripMenuItem1.Click
        If Not TypeOf cmbbrand.SelectedValue Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf cmbsize.SelectedValue Is Decimal Then
            Exit Sub
        End If
        If cmbsize.SelectedValue = 0 Then
            MsgBox("Please Select Size")
            Exit Sub
        End If

        Objpurchase = New CWPlusBL.Master.Clspurchase
        objdt = New DataTable
        Objpurchase.BrandID = cmbbrand.SelectedValue
        Objpurchase.CategorySizeLinkID = cmbsize.SelectedValue
        Objpurchase.CategoryTaxID = cmbtaxtype.SelectedValue
        objdt = Objpurchase.BindPurchaseRate

        Dim PurchaseTrnRate, brandopeningID, Taxpercetage, purratepeg As Double
        If objdt.Rows.Count > 0 Then
            brandopeningID = objdt.Rows(0).Item("brandopeningID")
            PurchaseTrnRate = objdt.Rows(0).Item("PurchaseTrnRate")
            Taxpercetage = objdt.Rows(0).Item("Taxpercetage")
            purratepeg = objdt.Rows(0).Item("PurRatePeg")
        End If

        'If CheckDuplicateRecord(brandopeningID) Then
        '    MsgBox("Brand & Size already exists", MsgBoxStyle.Information)
        '    Exit Sub
        'End If


        'Add Rows In Grid
        If cmbtaxtype.SelectedValue = 0 Then
            grdpurchase.Rows.Add(Nothing, brandopeningID, cmbbrand.Text, cmbsize.SelectedValue, cmbsize.Text, 0, PurchaseTrnRate, 0, 0, purratepeg, 0, 0, 0, 0, "", 0, lblStock.Text)
            cmbbrand.Focus()
        Else
            grdpurchase.Rows.Add(Nothing, brandopeningID, cmbbrand.Text, cmbsize.SelectedValue, cmbsize.Text, 0, PurchaseTrnRate, 0, 0, purratepeg, 0, 0, 0, cmbtaxtype.SelectedValue, cmbtaxtype.Text, Taxpercetage, lblStock.Text)
            cmbbrand.Focus()
        End If


        lblStock.Text = ""

        cmbbrand.SelectedIndex = -1
        cmbsize.SelectedIndex = -1
        cmbtaxtype.SelectedIndex = -1
    End Sub

    Public Sub BindBrand(ByVal BrandOpeningID As Double)
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable
            Objpurchase.BrandopeningID = BrandOpeningID
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            'Objpurchase.TransDate = Dtdate.Text.ToString   'Added by Samvedna on [23-01-2020]
            Objpurchase.TransDate = Dtdate.Value   'Added by Samvedna on [23-01-2020]

            objdt = Objpurchase.BindBrandOpening
            ComboBindingTemplate(cmbbrand, objdt, "BrandDesc", "brandid")
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
            ComboBindingTemplate(cmbsize, ds.Tables(0), "alias", "CategorySizeLinkUpID")
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
    Private Sub cmbbrand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbrand.SelectedIndexChanged
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf (cmbbrand.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        BindSize(cmbbrand.SelectedValue)
        bindtax()
    End Sub
    Public Function Save() As Boolean
        Save = False
        Dim StrPriError As String = ""

        If PurchaseID = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Purchase")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Purchase")
                Exit Function
            End If
        End If

        If (MDI.cmbLicenseName.Text = "") Then
            MsgBox("Select License Name", MsgBoxStyle.Critical, "Purchase")
            MDI.cmbLicenseName.Focus()
            Exit Function
        ElseIf (txttpno.Text = "") Then
            MsgBox("Enter TPNo ", MsgBoxStyle.Critical, "Purchase")
            txttpno.Focus()
            Exit Function
        ElseIf (cmbSuplier.SelectedValue = 0) Then
            MsgBox("Selct supplier name ", MsgBoxStyle.Critical, "Purchase")
            cmbSuplier.Focus()
            Exit Function
        End If
        If (grdpurchase.RowCount = 0) Then
            MsgBox("Nothing To Save", MsgBoxStyle.Critical, "Purchase")
            Exit Function
        End If
        If (grdpurchase.Item("Qty", 0).Value = 0) And (grdpurchase.Item("sPeg", 0).Value = 0) Then
            MsgBox("Enter Quantity ", MsgBoxStyle.Critical, "Purchase")
            Exit Function
        End If

        '[+][13/12/2019][Ajay Prajapati]
        Dim VarianceCount As Integer
        Dim ObjSaler As New ClsSale
        Dim ObjCheckVariance As New DataTable
        ObjSaler.LicenseID = MDI.cmbLicenseName.SelectedValue
        ObjSaler.BillDate = Dtdate.Value
        ObjSaler.TransactionType = "P" 'Purchase
        ObjCheckVariance = ObjSaler.FunCheckVariance()
        If (ObjCheckVariance.Rows.Count > 0) Then
            VarianceCount = Convert.ToInt32(ObjCheckVariance.Rows(0)("VarianceCount"))
        End If

        If (VarianceCount > 0) Then
            MsgBox("Can not save the Purchase since Variance done", MsgBoxStyle.OkOnly, "Purchase")
            Exit Function
        End If
        '[-][13/12/2019][Ajay Prajapati]



        Try
            StrPriError = ValidatePurchase()
            If StrPriError <> "" Then
                MsgBox(StrPriError)
                Exit Function
            End If

            Objpurchase = New CWPlusBL.Master.Clspurchase
            Objpurchase.PurchaseID = lblid.Text
            Objpurchase.SupplierID = cmbSuplier.SelectedValue
            Objpurchase.TPno = txttpno.Text
            Objpurchase.GRNForCode = txtGRNForCode.Text  'Add by Mohammed on 29-March-2019
            Objpurchase.InvoiceNo = txtInvoiceno.Text
            Objpurchase.Purchasedate = Dtdate.Value
            Objpurchase.OtherchargeType = txtothchg.Text
            Objpurchase.Othercharge = IIf(txtchg.Text = "", 0, txtchg.Text)
            Objpurchase.Discountper = IIf(txtdesc.Text = "", 0, txtdesc.Text)
            Objpurchase.Discount = IIf(txtdesc.Text = "", 0, txtdesc.Text)
            Objpurchase.ForLicenseId = IIf(cmblicense.Text = "", Nothing, cmblicense.SelectedValue)
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            Objpurchase.PurchaseXML = GenerateXML()
            Objpurchase.UserName = gblUserName
            Save = Objpurchase.FunSave
            MsgBox(Objpurchase.ErrorMsg)
            ' Clrscr()
            If IsReport Then
                FrmCocktailReport.btnok.PerformClick()
            Else
                FrmPurchasedetail.btnSearch.PerformClick()
            End If
            Me.Close()

            'OpenForm(MDI.tvMenu.SelectedNode)
            FrmPurchasedetail.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
        End Try
    End Function

    Private Function ValidatePurchase() As String
        ValidatePurchase = ""
        Dim ObjPriDt As New DataTable
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            Objpurchase.PurchaseID = lblid.Text
            Objpurchase.PurchaseXML = GenerateXML()
            ObjPriDt = Objpurchase.FunValidatePurchaseSave()
            If ObjPriDt.Rows.Count > 0 Then
                ValidatePurchase = "Sale already exists for" & vbCrLf
                For IntLocCnter As Integer = 0 To ObjPriDt.Rows.Count - 1
                    ValidatePurchase &= ObjPriDt.Rows(IntLocCnter)("brandname") & " " & ObjPriDt.Rows(IntLocCnter)("size") & vbCrLf
                Next
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Function

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><Purchase></Purchase></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Purchasedetail")
        For index = 0 To grdpurchase.RowCount - 1
            XmlElt = xmldoc.CreateElement("Purchasedetail")
            XmlElt.SetAttribute("BrandopeningId", grdpurchase.Item("BrandopeningId", index).Value)
            XmlElt.SetAttribute("SQuantity", grdpurchase.Item("sPeg", index).Value)
            XmlElt.SetAttribute("SRate", grdpurchase.Item("sRate", index).Value)
            XmlElt.SetAttribute("BottleQty", grdpurchase.Item("Qty", index).Value)
            XmlElt.SetAttribute("BottleRate", grdpurchase.Item("rate", index).Value)
            XmlElt.SetAttribute("FreeQty", grdpurchase.Item("freeqty", index).Value)
            XmlElt.SetAttribute("Noofbox", grdpurchase.Item("box", index).Value)
            ' XmlElt.SetAttribute("CategoryTaxId", 0)
            'XmlElt.SetAttribute("taxper", 0)
            XmlElt.SetAttribute("CategoryTaxId", IIf(grdpurchase.Item("taxtypeid", index).Value = Nothing, 0, grdpurchase.Item("taxtypeid", index).Value))
            XmlElt.SetAttribute("taxper", IIf(grdpurchase.Item("taxper", index).Value = 0, 0, grdpurchase.Item("taxper", index).Value))
            XmlElt.SetAttribute("batchNo", grdpurchase.Item("batch", index).Value)
            XmlElt.SetAttribute("Mfg", grdpurchase.Item("mfg", index).Value)
            xmldoc.DocumentElement.Item("Purchase").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function
    Public Sub FetchPurchase()
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable

            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            Objpurchase.PurchaseID = lblid.Text
            Objpurchase.Purchasedate = Dtdate.Value
            
            Objpurchase.TPno = txttpno.Text
            Objpurchase.GRNForCode = txtGRNForCode.Text           'Added By Mohammed On 29-March-2019
            Objpurchase.InvoiceNo = txtInvoiceno.Text
            objdt = Objpurchase.FunFetch()
            grdpurchase.Rows.Clear()
            If objdt.Rows.Count > 0 Then
                For rwctr = 0 To objdt.Rows.Count - 1
                    grdpurchase.Rows.Add()
                    lblid.Text = objdt.Rows(rwctr)("PurchaseId")
                    'txttpno.Text = objdt.Rows(rwctr)("TPNo")
                    cmbSuplier.SelectedValue = objdt.Rows(rwctr)("SupplierId")
                    'txtothchg.Text = objdt.Rows(rwctr)("OtherchargeType")
                    ' txtchg.Text = objdt.Rows(rwctr)("Othercharge")
                    'txtdesc.Text = objdt.Rows(rwctr)("Discountper")
                    ' txtActualdesc.Text = objdt.Rows(rwctr)("Discount")
                    ' txtInvoiceno.Text = objdt.Rows(rwctr)("InvoiceNo")
                    'cmblicense.SelectedValue = objdt.Rows(rwctr)("ForLicenseId")
                    MDI.cmbLicenseName.SelectedValue = objdt.Rows(rwctr)("LicenseId")
                    grdpurchase.Item("BrandopeningId", rwctr).Value = objdt.Rows(rwctr)("BrandOpeningID")
                    grdpurchase.Item("BrandName", rwctr).Value = objdt.Rows(rwctr)("branddesc")
                    grdpurchase.Item("sPeg", rwctr).Value = objdt.Rows(rwctr)("SQuantity")
                    grdpurchase.Item("sRate", rwctr).Value = objdt.Rows(rwctr)("SRate")
                    grdpurchase.Item("Qty", rwctr).Value = objdt.Rows(rwctr)("BottleQty")
                    grdpurchase.Item("rate", rwctr).Value = objdt.Rows(rwctr)("BottleRate")
                    grdpurchase.Item("freeqty", rwctr).Value = objdt.Rows(rwctr)("FreeQty")
                    grdpurchase.Item("box", rwctr).Value = objdt.Rows(rwctr)("Noofbox")
                    grdpurchase.Item("taxtypeid", rwctr).Value = IIf(objdt.Rows(rwctr)("CategoryTaxId").ToString = "", Nothing, objdt.Rows(rwctr)("CategoryTaxId"))
                    grdpurchase.Item("tax", rwctr).Value = objdt.Rows(rwctr)("Taxtype")
                    grdpurchase.Item("taxper", rwctr).Value = IIf(objdt.Rows(rwctr)("taxper").ToString = "", Nothing, objdt.Rows(rwctr)("taxper"))
                    grdpurchase.Item("batch", rwctr).Value = objdt.Rows(rwctr)("batchNo")
                    grdpurchase.Item("mfg", rwctr).Value = objdt.Rows(rwctr)("Mfg")
                    grdpurchase.Item("Size", rwctr).Value = objdt.Rows(rwctr)("Alias")

                Next
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


    Private Sub grdpurchase_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdpurchase.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim Ans As String = MsgBox("Are You Sure Want To Remove", MsgBoxStyle.YesNo, "Remove")
            If Ans = vbNo Then
                Exit Sub
            End If
            grdpurchase.Rows.Remove(grdpurchase.CurrentRow)
        End If
    End Sub

    Private Sub grdpurchase_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdpurchase.CellValueChanged
        'If e.ColumnIndex = 5 Then
        '    grdpurchase.Item("sPeg", e.ColumnIndex).Value = 0

        'End If
    End Sub
    Public Sub FetchBrandType()
        Dim objBrandType As New ClsAutobilling
        Dim ObjPriDt As New DataTable
        Try
            objBrandType.BrandID = cmbBrand.SelectedValue
            objBrandType.LicenseID = MDI.cmbLicenseName.SelectedValue
            objBrandType.CategorySizeLinkID = cmbsize.SelectedValue
            objBrandType.AutoDate = Dtdate.Value
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

    Private Sub cmbsize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsize.SelectedIndexChanged
        If Not TypeOf (cmbsize.SelectedValue) Is Decimal OrElse cmbsize.SelectedValue = 0 Then
            Exit Sub
        End If
        FetchBrandType()
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click, SaveToolStripMenuItem.Click
        'If Not BatchValidation() Then
        'MsgBox("Duplicate Batch No.")
        'Exit Sub
        'End If
        'CheckOrderNo()
        Save()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        'Dim parentNod As New TreeNode("transaction")
        'Dim childNod As New TreeNode("purchase")
        'parentNod.Nodes.Add(childNod)
        'OpenForm(childNod)
        'Me.Close()
        'OpenForm(MDI.tvMenu.SelectedNode)
        Me.Close()
    End Sub

    Private Sub txtothchg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtothchg.KeyPress, txtchg.KeyPress, txtdesc.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
    End Sub
    Public Function BatchValidation() As Boolean
        BatchValidation = False
        Dim dt As DataTable
        dt = New DataTable
        dt.Columns.Add("Batch")
        If grdpurchase.Rows.Count > 0 Then
            For row = 0 To grdpurchase.Rows.Count - 1
                If grdpurchase.Item("batch", row).Value = "0" Then
                    Continue For
                End If
                If row = 0 Then
                    dt.Rows.Add(grdpurchase.Item("batch", row).Value)
                    Continue For
                Else
                    Dim dv As DataView
                    dv = New DataView(dt)
                    dv.RowFilter = "batch='" & grdpurchase.Item("batch", row).Value & "'"
                    If dv.Count > 0 Then
                        BatchValidation = False
                        Exit Function
                    Else
                        dt.Rows.Add(grdpurchase.Item("batch", row).Value)
                    End If
                End If
            Next
            BatchValidation = True
        End If

    End Function



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

    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles grdpurchase.EditingControlShowing
        If grdpurchase.Columns(grdpurchase.CurrentCell.ColumnIndex).Name = "Qty" Or grdpurchase.Columns(grdpurchase.CurrentCell.ColumnIndex).Name = "freeqty" Then
            BoolPriBotandspeg = True
            Dim txtEdit As TextBox = e.Control
            'remove any existing handler
            RemoveHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress
            AddHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress
        Else
            BoolPriBotandspeg = False
        End If
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub Dtdate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Dtdate.ValueChanged
        BindBrand(0)    'Added by Samvedna on [23-01-2020]
    End Sub
End Class