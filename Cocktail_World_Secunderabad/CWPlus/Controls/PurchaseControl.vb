Imports System.Windows.Forms
Imports System.Data
Imports CWPlusBL
Imports System.Xml
Imports CWPlusBL.Master

Public Class PurchaseControl
    Dim Objpurchase As CWPlusBL.Master.Clspurchase
    Dim objdt As DataTable
    Dim ObjCategorySizeLnkUp As CWPlusBL.Master.ClsCategorySizelinlup
    Dim objlicense As CWPlusBL.Master.Utitity
    Dim ds As DataSet
    Dim dt As DataTable
    Dim ObjQE As ClsQuickExcess

#Region "Main Functions"

    Public Sub SetGridTheme(srcGrid As DataGridView)
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
            .ColumnHeadersHeight = 30
            .DefaultCellStyle.BackColor = Color.FromArgb(208, 216, 232)
            .DefaultCellStyle.Font = New Font("Verdana", 9)
            .GridColor = Color.White
            .RowHeadersVisible = False
            .RowTemplate.Height = 28
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Public Sub SetGridThemeForPurchase(srcGrid As DataGridView)
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
            .ColumnHeadersHeight = 30
            .DefaultCellStyle.BackColor = Color.FromArgb(208, 216, 232)
            .DefaultCellStyle.Font = New Font("Verdana", 9)
            .GridColor = Color.White
            .RowHeadersVisible = False
            .RowTemplate.Height = 28
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Function GetTPNo(Optional LicenseId As Double = 0) As DataTable
        ObjQE = New ClsQuickExcess
        ObjQE.PurchaseDate = GblPurchaseDate
        ObjQE.LicenseID = LicenseId
        GetTPNo = ObjQE.FetchTPNo
    End Function

    ''' <summary>
    ''' Bind The Purchasdate to GRID
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub BindPurchaseDate(lic As Double)
        Dtdate.Value = GblPurchaseDate
        Dtdate.Enabled = False

        grdTpNoByLicenseNo.DataSource = GetTPNo(lic)
        grdTpNoByLicenseNo.Columns("PurchaseID").Visible = False
        grdTpNoByLicenseNo.Columns("LicenseID").Visible = False
        grdTpNoByLicenseNo.Columns("LicenseDesc").Visible = False
        If DirectCast(grdTpNoByLicenseNo.DataSource, DataTable).Rows.Count > 0 Then
            grdTpNoByLicenseNo.Columns("TPNO").HeaderText = DirectCast(grdTpNoByLicenseNo.DataSource, DataTable).Rows(0)("LicenseDesc")
        End If

        'BIND TP NO FOR ALL LIC
        Dim ds As New DataSet
        Dim dtAll As DataTable = GetTPNo()
        Dim dv As New DataView
        dv = dtAll.DefaultView
        Dim dt As New DataTable
        dt = dv.ToTable(True, "LicenseID")
        For rCtr = 0 To dt.Rows.Count - 1
            dv.RowFilter = "LicenseID='" & dt.Rows(rCtr)(0) & "'"
            ds.Tables.Add(dv.ToTable("out" & rCtr))
            dv.RowFilter = ""
        Next

        SplitContainer2.Panel2.Controls.Clear() 'CLEAR ALL THE GRID CONTROLS

        For Each subdt As DataTable In ds.Tables
            If subdt.Rows(0)("LicenseID") = lic Then Continue For 'SKIP FOR THE SELECTED LICENSE 
            Dim grd As New DataGridView
            grd.DataSource = subdt
            grd.Width = SplitContainer2.Panel2.Width
            SplitContainer2.Panel2.Controls.Add(grd)
            grd.Columns("PurchaseID").Visible = False
            grd.Columns("LicenseID").Visible = False
            grd.Columns("LicenseDesc").Visible = False
            grd.Columns("TPNO").HeaderText = grd("LicenseDesc", 0).Value
            grd.AllowUserToAddRows = False
            grd.BackgroundColor = Color.White
            grd.Dock = DockStyle.Top
            SetGridTheme(grd)
            SplitContainer2.Panel2.VerticalScroll.Visible = True
        Next

        'grdTpNoAllLicenseNo.DataSource =
        'grdTpNoAllLicenseNo.Columns("PurchaseID").Visible = False
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Me.lblid.Text = text1

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
        AddTheme(SplitContainer2.Panel1)
        grdpurchase1.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Accent1
        'SetGridThemeForPurchase(grdpurchase1)
        SetGridTheme(grdTpNoByLicenseNo)
    End Sub

    Public Sub InitControls()

        Dim toolTip1 As New ToolTip()

        toolTip1.SetToolTip(btnAdd, "Add Rows To Grid.")
        toolTip1.ShowAlways = True
        toolTip1.IsBalloon = True
        BindBrand(0)
        BindLicense()
        bindsupplier()
        bindtax()
        If PurchaseID <> 0 Then
            Me.lblid.Text = PurchaseID
            FetchPurchase()
        End If
    End Sub

#End Region




    Property PurchaseID As Double = 0

    Private Sub Clrscr()
        cmbbrand.Text = ""
        cmbsize.Text = ""
        cmbtaxtype.Text = ""
        cmbSuplier.Text = ""
        cmblicense.Text = ""
        txtchg.Clear()
        txtActualdesc.Clear()
        txtInvoiceno.Clear()
        txttpno.Clear()
        txtothchg.Clear()
        txtdesc.Clear()
        grdpurchase1.Rows.Clear()
    End Sub
    Private Sub Frmpurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim toolTip1 As New ToolTip()

        toolTip1.SetToolTip(btnAdd, "Add Rows To Grid.")
        toolTip1.ShowAlways = True
        toolTip1.IsBalloon = True
        ''Adding Rows To the Grid
        'grdSize.Rows.Add(2)
        'grdSize.Item("desc", 0).Value = "Qty"
        'grdSize.Item("desc", 1).Value = "Rate"

        'grdSize.Item("vSpeg", 0).Value = 0
        'grdSize.Item("vBottle", 0).Value = 0
        'grdSize.Item("vSpeg", 1).Value = 0
        'grdSize.Item("vBottle", 1).Value = 0


        ' bindcombo
    End Sub
    Private Sub BindLicense()
        Try

            objlicense = New CWPlusBL.Master.Utitity
            objdt = New DataTable
            objdt = objlicense.FunFetchLicense

            'objlicense.DataSource = Nothing

            With cmblicense
                .DisplayMember = "LicenseDesc"
                .ValueMember = "LicenseID"
                .DataSource = objdt
                .Text = ""
                .SelectedValue = -1
            End With


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
            With cmbSuplier
                .DataSource = ds.Tables(0)
                .DisplayMember = "SupplierName"
                .ValueMember = "SupplierID"
                .Text = ""
                .SelectedValue = -1
            End With
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
            ds = Objpurchase.BindSupplier
            With cmbtaxtype
                .DataSource = ds.Tables(1)
                .DisplayMember = "Taxtype"
                .ValueMember = "CategoryTaxId"
                .Text = ""
                .SelectedValue = -1
            End With
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
        For rwctr = 0 To grdpurchase1.RowCount - 1
            If vBrandOpeningID = grdpurchase1("brandopeningID", rwctr).Value Then
                CheckDuplicateRecord = True
                Exit Function
            End If
        Next

    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.ClickButtonArea
        If Not TypeOf cmbbrand.SelectedValue Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf cmbsize.SelectedValue Is Decimal Then
            Exit Sub
        End If

        Objpurchase = New CWPlusBL.Master.Clspurchase
        objdt = New DataTable
        Objpurchase.BrandID = cmbbrand.SelectedValue
        Objpurchase.CategorySizeLinkID = cmbsize.SelectedValue
        Objpurchase.CategoryTaxID = cmbtaxtype.SelectedValue
        objdt = Objpurchase.BindPurchaseRate

        Dim purchaserate, brandopeningID, Taxpercetage, purratepeg As Double
        If objdt.Rows.Count > 0 Then
            brandopeningID = objdt.Rows(0).Item("brandopeningID")
            ' purchaserate = objdt.Rows(0).Item("purchaserate")
            Taxpercetage = objdt.Rows(0).Item("Taxpercetage")
            purratepeg = objdt.Rows(0).Item("PurRatePeg")
        End If

        If CheckDuplicateRecord(brandopeningID) Then
            MsgBox("Brand & Size already exists", MsgBoxStyle.Information)
            Exit Sub
        End If

        'Add Rows In Grid
        grdpurchase1.Rows.Add(Nothing, brandopeningID, cmbbrand.Text, cmbsize.SelectedValue, cmbsize.Text, 0, purchaserate, 0, 0, purratepeg, 0, 0, 0, cmbtaxtype.SelectedValue, cmbtaxtype.Text, Taxpercetage)

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
            Objpurchase.LicenseID = gblLicenseID
            objdt = Objpurchase.BindBrandOpening
            If Not objdt.Rows.Count > 0 Then
                Exit Sub
            End If
            'If BrandOpeningID = 0 Then
            With cmbbrand
                .DataSource = objdt
                .DisplayMember = "BrandDesc"
                .ValueMember = "brandid"
                .Text = ""
                .SelectedValue = -1
            End With

            '   Else
            'BindSize(objdt.Rows(0)("brandid"))
            ' End If
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
            cmbsize.DataSource = Nothing
            With cmbsize
                .DataSource = ds.Tables(0)
                .DisplayMember = "alias"
                .ValueMember = "CategorySizeLinkUpID"
                .Text = ""
                .SelectedValue = -1
            End With
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
        If (gblLicenseID = 0) Then
            MsgBox("Select License Name", MsgBoxStyle.Critical, "Purchase")
            Exit Function
        ElseIf (txttpno.Text = "") Then
            MsgBox("Enter TPNo ", MsgBoxStyle.Critical, "Purchase")
            txttpno.Focus()
            Exit Function
        End If


        'If (grdpurchase.Item("Qty", 0).Value = 0) + (grdpurchase.Item("sPeg", 0).Value = 0) Then
        '    MsgBox("Enter Quantity ", MsgBoxStyle.Critical, "Purchase")
        '    Exit Function
        'End If
        'If grdpurchase.Item("freeqty", 0).Value = 0 Then
        '    MsgBox("Enter free Quantity ", MsgBoxStyle.Critical, "Purchase")
        '    Exit Function
        'End If
        If (grdpurchase1.RowCount = 0) Then
            MsgBox("Nothing To Save", MsgBoxStyle.Critical, "Purchase")
            Exit Function
        End If
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            Objpurchase.PurchaseID = lblid.Text
            Objpurchase.SupplierID = cmbSuplier.SelectedValue
            Objpurchase.TPno = txttpno.Text
            Objpurchase.InvoiceNo = txtInvoiceno.Text
            Objpurchase.Purchasedate = Dtdate.Value
            Objpurchase.OtherchargeType = txtothchg.Text
            Objpurchase.Othercharge = IIf(txtchg.Text = "", 0, txtchg.Text)
            Objpurchase.Discountper = IIf(txtdesc.Text = "", 0, txtdesc.Text)
            Objpurchase.Discount = IIf(txtActualdesc.Text = "", 0, txtActualdesc.Text)
            Objpurchase.ForLicenseId = IIf(cmblicense.Text = "", Nothing, cmblicense.SelectedValue)
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            Objpurchase.PurchaseXML = GenerateXML()
            Save = Objpurchase.FunSave
            MsgBox(Objpurchase.ErrorMsg)
            Clrscr()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
        End Try
    End Function
    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><Purchase></Purchase></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Purchasedetail")
        For index = 0 To grdpurchase1.RowCount - 1
            XmlElt = xmldoc.CreateElement("Purchasedetail")
            XmlElt.SetAttribute("BrandopeningId", grdpurchase1.Item("BrandopeningId", index).Value)
            XmlElt.SetAttribute("SQuantity", grdpurchase1.Item("sPeg", index).Value)
            XmlElt.SetAttribute("SRate", grdpurchase1.Item("sRate", index).Value)
            XmlElt.SetAttribute("BottleQty", grdpurchase1.Item("Qty", index).Value)
            XmlElt.SetAttribute("BottleRate", grdpurchase1.Item("rate", index).Value)
            XmlElt.SetAttribute("FreeQty", grdpurchase1.Item("freeqty", index).Value)
            XmlElt.SetAttribute("Noofbox", grdpurchase1.Item("box", index).Value)
            ' XmlElt.SetAttribute("CategoryTaxId", 0)
            'XmlElt.SetAttribute("taxper", 0)
            XmlElt.SetAttribute("CategoryTaxId", IIf(grdpurchase1.Item("taxtypeid", index).Value = Nothing, 0, grdpurchase1.Item("taxtypeid", index).Value))
            XmlElt.SetAttribute("taxper", IIf(grdpurchase1.Item("taxper", index).Value = 0, 0, grdpurchase1.Item("taxper", index).Value))
            XmlElt.SetAttribute("batchNo", grdpurchase1.Item("batch", index).Value)
            XmlElt.SetAttribute("Mfg", grdpurchase1.Item("mfg", index).Value)
            xmldoc.DocumentElement.Item("Purchase").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function
    Public Sub FetchPurchase()
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable
            Objpurchase.PurchaseID = lblid.Text
            Objpurchase.Purchasedate = Dtdate.Value
            Objpurchase.TPno = txttpno.Text
            Objpurchase.InvoiceNo = txtInvoiceno.Text
            objdt = Objpurchase.FunFetch()
            grdpurchase1.Rows.Clear()
            If objdt.Rows.Count > 0 Then
                For rwctr = 0 To objdt.Rows.Count - 1
                    grdpurchase1.Rows.Add()
                    lblid.Text = objdt.Rows(rwctr)("PurchaseId")
                    txttpno.Text = objdt.Rows(rwctr)("TPNo")
                    cmbSuplier.SelectedValue = objdt.Rows(rwctr)("SupplierId")
                    txtothchg.Text = objdt.Rows(rwctr)("OtherchargeType")
                    txtchg.Text = objdt.Rows(rwctr)("Othercharge")
                    txtdesc.Text = objdt.Rows(rwctr)("Discountper")
                    txtActualdesc.Text = objdt.Rows(rwctr)("Discount")
                    txtInvoiceno.Text = objdt.Rows(rwctr)("InvoiceNo")
                    cmblicense.SelectedValue = objdt.Rows(rwctr)("ForLicenseId")
                    MDI.cmbLicenseName.SelectedValue = objdt.Rows(rwctr)("LicenseId")
                    grdpurchase1.Item("BrandopeningId", rwctr).Value = objdt.Rows(rwctr)("BrandOpeningID")
                    grdpurchase1.Item("BrandName", rwctr).Value = objdt.Rows(rwctr)("branddesc")
                    grdpurchase1.Item("sPeg", rwctr).Value = objdt.Rows(rwctr)("SQuantity")
                    grdpurchase1.Item("sRate", rwctr).Value = objdt.Rows(rwctr)("SRate")
                    grdpurchase1.Item("Qty", rwctr).Value = objdt.Rows(rwctr)("BottleQty")
                    grdpurchase1.Item("rate", rwctr).Value = objdt.Rows(rwctr)("BottleRate")
                    grdpurchase1.Item("freeqty", rwctr).Value = objdt.Rows(rwctr)("FreeQty")
                    grdpurchase1.Item("box", rwctr).Value = objdt.Rows(rwctr)("Noofbox")
                    grdpurchase1.Item("taxtypeid", rwctr).Value = IIf(objdt.Rows(rwctr)("CategoryTaxId").ToString = "", Nothing, objdt.Rows(rwctr)("CategoryTaxId"))
                    grdpurchase1.Item("tax", rwctr).Value = objdt.Rows(rwctr)("Taxtype")
                    grdpurchase1.Item("taxper", rwctr).Value = IIf(objdt.Rows(rwctr)("taxper").ToString = "", Nothing, objdt.Rows(rwctr)("taxper"))
                    grdpurchase1.Item("batch", rwctr).Value = objdt.Rows(rwctr)("batchNo")
                    grdpurchase1.Item("mfg", rwctr).Value = objdt.Rows(rwctr)("Mfg")
                    grdpurchase1.Item("PurSize", rwctr).Value = objdt.Rows(rwctr)("Alias")
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Save()
    End Sub

    Private Sub grdpurchase_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdpurchase1.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim Ans As String = MsgBox("Are You Sure Want To Remove", MsgBoxStyle.YesNo, "Remove")
            If Ans = vbNo Then
                Exit Sub
            End If
            grdpurchase1.Rows.Remove(grdpurchase1.CurrentRow)
        End If
    End Sub

    Private Sub grdpurchase_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdpurchase1.CellValueChanged
        'If e.ColumnIndex = 5 Then
        '    grdpurchase.Item("sPeg", e.ColumnIndex).Value = 0

        'End If
    End Sub
    Public Sub FetchBrandType()
        Dim objBrandType As New ClsAutobilling
        Dim ObjPriDt As New DataTable
        Try
            objBrandType.BrandID = cmbbrand.SelectedValue
            objBrandType.LicenseID = MDI.cmbLicenseName.SelectedValue
            objBrandType.CategorySizeLinkID = cmbsize.SelectedValue
            ObjPriDt = objBrandType.FunFetchBrandQuntity()
            If ObjPriDt.Rows.Count > 0 Then
                lblStock.Text = ObjPriDt.Rows(0).Item("BrandStock").ToString()
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
        If Not TypeOf (cmbsize.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        FetchBrandType()
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

    Private Sub btnSave_ClickButtonArea(Sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnSave.ClickButtonArea
        Save()
    End Sub

    Private Sub grdTpNoByLicenseNo_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTpNoByLicenseNo.CellDoubleClick
        If e.ColumnIndex = 1 Then
            PurchaseID = grdTpNoByLicenseNo("PurchaseID", e.RowIndex).Value
            txttpno.Text = grdTpNoByLicenseNo("TPNO", e.RowIndex).Value
            InitControls()
        End If
    End Sub
End Class
