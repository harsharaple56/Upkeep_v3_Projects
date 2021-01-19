Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml

Public Class FrmTransfer
    Property TransferHeadID As Double = 0
    Dim gblForLicense As Double
    Dim gblForBrandOpeningID As Double
    Dim BoolPriBotandspeg As Boolean = False
    Dim ObjButton As New clsGeneralSetup
    Dim FLIVAddress As Boolean
    Public IsReport As Boolean = False
    Dim ObjDept As CWPlusBL.Master.ClsDeptMaster
    'Dim LicenseDesc As String
    Private Sub FrmTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim pridt As DataTable = ObjButton.FunFetchGSetUp()
        FLIVAddress = pridt.Rows.Item(0)("FLIVAddress")
        AssignRights(gblMenuDesc)
        lblBrandDetailsLable.Visible = False

        BindBrand(0)
        BindAgainst()
        BindDept()
        BindLicenseForTransfer()
        If FLIVAddress = True Then
            txtAddress.Visible = True
            lbladdress.Visible = True
        Else
            txtAddress.Visible = False
            lbladdress.Visible = False
        End If

        If TransferHeadID <> 0 Then
            Me.lblTransferHeadID.Text = TransferHeadID

            FetchTransferHaedDetails()
            chkShowExcise.Enabled = False
        End If

    End Sub

    Public Sub BindDept()
        Dim ObjDt As New DataTable
        Try
            ObjDept = New CWPlusBL.Master.ClsDeptMaster
            ObjDt = ObjDept.FunFetch
            cmbDept.DataSource = Nothing
            ComboBindingTemplate(cmbDept, ObjDt, "Department", "DeptId")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjDept) Then
                ObjDept = Nothing
            End If
        End Try

    End Sub

    Public Sub BindBrand(ByVal brandopeningid As Double)

        Dim Objpurchase As New Clspurchase
        Dim objdt As New DataTable
        Try
            Objpurchase.BrandopeningID = brandopeningid
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            Objpurchase.TransDate = dtpTransferHead.Text.ToString   'Added by Samvedna on [23-01-2020]

            objdt = Objpurchase.BindBrandOpening
            ComboBindingTemplate(cmbBrandName, objdt, "BrandDesc", "brandid")
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
    Public Sub BindAgainst()
        cmbAgainst.Items.Add("General")
        cmbAgainst.Items.Add("TP")
        cmbAgainst.SelectedItem = "General"
        txtTransferDetailTPno.Enabled = False
    End Sub

    Public Sub BindLicenseForTransfer()
        Dim ObjLicense As New Utitity
        Dim objdt As New DataTable
        Try
            ObjLicense.LicenseID = MDI.cmbLicenseName.SelectedValue
            objdt = ObjLicense.FunFetchLicenseForTransferWise

            ComboBindingTemplate(cmbLicense, objdt, "LicenseDesc", "LicenseID")
            cmbAgainst.SelectedItem = "General"
            cmbLicense.SelectedValue = 0
            If objdt.Rows.Count = 2 Then
                If objdt.Rows(1)("IsSelected") Then
                    cmbLicense.SelectedValue = objdt.Rows(1)("LicenseID")
                    cmbAgainst.SelectedItem = "TP"
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjLicense) Then
                ObjLicense = Nothing
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
            Objpurchase.BrandID = cmbBrandName.SelectedValue
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            ds = Objpurchase.BindSizes
            ComboBindingTemplate(cmbSize, ds.Tables(0), "alias", "CategorySizeLinkUpID")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
            If Not IsNothing(ds) Then
                ds = Nothing
            End If
        End Try
    End Sub


    Public Function ValidateQty()
        ValidateQty = True
        ''''Validation On SPeegQty and BottleQty
        For cntr = 0 To grdTransfer.Rows.Count - 1
            'If (IIf(Trim(grdTransfer.Item("spegqty", cntr).Value) = "", 0, grdTransfer.Item("spegqty", cntr).Value) = 0 And IIf(Trim(grdTransfer.Item("bottleqty", cntr).Value) = "", 0, Trim(grdTransfer.Item("bottleqty", cntr).Value)) = 0) Then
            '    MsgBox("Please Insert Qty")
            '    Exit Function
            'End If
            Dim IsValid As Boolean = False
            If Not IsNothing(grdTransfer.Item("spegqty", cntr).Value) Then

                If Not grdTransfer.Item("spegqty", cntr).Value = 0 Then
                    Continue For
                Else
                    'MsgBox("Please Insert Qty")
                    'ValidateQty = False
                    'Exit Function
                End If

            Else
                'MsgBox("Please Insert Qty")
                'IsValid = False
                grdTransfer.Item("spegqty", cntr).Value = 0
            End If

            If Not IsNothing(grdTransfer.Item("bottleqty", cntr).Value) Then

                If Not grdTransfer.Item("bottleqty", cntr).Value = 0 Then
                    Continue For
                Else
                    MsgBox("Please Insert Qty")
                    ValidateQty = False

                    Exit Function
                End If
            Else
                MsgBox("Please Insert Qty")
                IsValid = False
                grdTransfer.Item("bottleqty", cntr).Value = 0
            End If

            'If IIf(Trim(grdTransfer.Item("spegqty", cntr).Value) = "", 0, grdTransfer.Item("spegqty", cntr).Value) = 0 And IIf(Trim(grdTransfer.Item("bottleqty", cntr).Value) = "", 0, Trim(grdTransfer.Item("bottleqty", cntr).Value)) = 0 Then
            '    MsgBox("Please Insert Qty")
            '    Exit Function
            'End If

        Next
        ''''End Validation On SPeegQty and BottleQty

    End Function


    Public Sub Save()
        imgSave.PerformClick()
    End Sub

    Private Function NegativeStock() As String
        NegativeStock = ""
        Dim ObjPriDt As New DataTable
        Dim ObjDtAutoBill As New ClsTransfer
        Dim xmlGridBrand As New XmlDocument
        Try

            xmlGridBrand.LoadXml("<Trans><Sale></Sale></Trans>")
            Dim XmlElt As XmlElement = xmlGridBrand.CreateElement("Brand")
            For index = 0 To grdTransfer.Rows.Count - 1
                XmlElt = xmlGridBrand.CreateElement("Brand")
                XmlElt.SetAttribute("BrandOpeningID", grdTransfer.Item("brandopeningid", index).Value)
                XmlElt.SetAttribute("BottleQty", grdTransfer.Item("bottleqty", index).Value)
                XmlElt.SetAttribute("Bottlerate", 0)
                XmlElt.SetAttribute("Speg", grdTransfer.Item("Spegqty", index).Value)
                XmlElt.SetAttribute("SpegRate", 0)
                xmlGridBrand.DocumentElement.Item("Sale").AppendChild(XmlElt)
            Next
            ObjDtAutoBill.TransferHeadID = TransferHeadID
            ObjDtAutoBill.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDtAutoBill.XmlBrand = xmlGridBrand
            ObjPriDt = ObjDtAutoBill.FunValidateNegativeStockForTransfer(dtpTransferHead.Text)
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

    'Public Function saveTransferDetailsMSt() As Boolean
    '    saveTransferDetailsMSt = False
    '    If (MDI.cmbLicenseName.Text = "") Then
    '        MsgBox("Select License Name", MsgBoxStyle.Critical, "Purchase")
    '        MDI.cmbLicenseName.Focus()
    '        Exit Function
    '    End If
    '    If (grdTransfer.RowCount = 0) Then
    '        MsgBox("Nothing To Save", MsgBoxStyle.Critical, "Purchase")
    '        Exit Function
    '    End If

    '    Dim ObjTransferHead As New ClsTransfer
    '    Dim ObjPriDt As New DataTable
    '    Try
    '        ObjTransferHead.BrandID = cmbBrandName.SelectedValue
    '        ObjTransferHead.SizeID = cmbSize.SelectedValue

    '        If cmbAgainst.SelectedItem = "General" Then
    '            ObjTransferHead.Against = "GN"
    '        Else
    '            ObjTransferHead.Against = "TP"
    '        End If
    '        ObjTransferHead.TrDetailsTPNo = txtTransferDetailTPno.Text
    '        ObjTransferHead.TransferDetailsXML = GenerateXML()

    '        saveTransferDetailsMSt = ObjTransferHead.FunSaveTransferDetailsMSt()
    '        MsgBox(ObjTransferHead.ErrorMsg)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        If Not IsNothing(ObjTransferHead) Then
    '            ObjTransferHead = Nothing
    '        End If
    '        If Not IsNothing(ObjPriDt) Then
    '            ObjPriDt = Nothing
    '        End If

    '    End Try

    'End Function
    Private Function GenerateXML() As XmlDocument
        Dim XmlDoc As New XmlDocument
        XmlDoc.LoadXml("<Master><Transfer></Transfer></Master>")
        Dim XmlElt As XmlElement = XmlDoc.CreateElement("transferdetail")
        For index = 0 To grdTransfer.RowCount - 1
            XmlElt = XmlDoc.CreateElement("transferdetail")
            XmlElt.SetAttribute("BrandopeningId", grdTransfer.Item("BrandopeningId", index).Value)

            'XmlElt.SetAttribute("brandname", grdTransfer.Item("brandname", index).Value)
            'XmlElt.SetAttribute("size", grdTransfer.Item("size", index).Value)
            XmlElt.SetAttribute("against", grdTransfer.Item("against", index).Value)
            XmlElt.SetAttribute("tpno", grdTransfer.Item("tpno", index).Value)

            XmlElt.SetAttribute("batch", grdTransfer.Item("batch", index).Value)
            XmlElt.SetAttribute("mfg", grdTransfer.Item("mfg", index).Value)
            XmlElt.SetAttribute("box", grdTransfer.Item("box", index).Value)
            XmlElt.SetAttribute("remarks", grdTransfer.Item("remarks", index).Value)

            XmlElt.SetAttribute("spegqty", grdTransfer.Item("spegqty", index).Value)
            '   XmlElt.SetAttribute("spegqty", IIf(grdTransfer.Item("spegqty", index).Value = "", 0, grdTransfer.Item("spegqty", index).Value))

            XmlElt.SetAttribute("spegrate", grdTransfer.Item("spegrate", index).Value)
            XmlElt.SetAttribute("bottleqty", grdTransfer.Item("bottleqty", index).Value)
            XmlElt.SetAttribute("bottlerate", grdTransfer.Item("bottlerate", index).Value)
            XmlElt.SetAttribute("ForBrandOpeningID", grdTransfer.Item("ForbrandopningId", index).Value)

            XmlDoc.DocumentElement.Item("Transfer").AppendChild(XmlElt)
        Next
        Return XmlDoc
    End Function
    Public Function ValidateBrand() As Boolean
        gblForBrandOpeningID = 0
        Dim Objpurchase As New CWPlusBL.Master.ClsTransfer
        Dim ObjDt As New DataTable
        ValidateBrand = False
        Try
            Objpurchase.BrandID = cmbBrandName.SelectedValue
            Objpurchase.CategorySizeLinkID = cmbSize.SelectedValue
            Objpurchase.ForLicenseID = cmbLicense.SelectedValue
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            gblForLicense = cmbLicense.SelectedValue

            'ValidateBrand = Objpurchase.ValidateBrandTransfer()
            ObjDt = Objpurchase.ValidateBrandTransfer()
            gblForBrandOpeningID = ObjDt.Rows(0).Item("ForBrandOpeningID")

            If ObjDt.Rows(0).Item("OutBit") = "True" Then
                ValidateBrand = True
            End If


        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(Objpurchase) = False Then
                Objpurchase = Nothing
            End If
        End Try
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, AddToolStripMenuItem.Click
        gblForBrandOpeningID = 0
        If (cmbLicense.SelectedValue = 0 And cmbLicense.Visible) And txtFLIV.Text = "" Then
            MsgBox("Please Select For License/Enter FLIV License")
            Exit Sub
        End If
        If (cmbDept.SelectedValue = 0 And cmbDept.Visible) And txtFLIV.Text = "" Then
            MsgBox("Please Select Department")
            Exit Sub
        End If
        If cmbBrandName.SelectedValue = 0 Then
            MsgBox("Please Select brand")
            Exit Sub
        End If
        If cmbSize.SelectedValue = 0 Then
            MsgBox("Please Select Size")
            Exit Sub
        End If
        If LTrim(RTrim(txtTransferHeadTPNo.Text)) = "" Then
            MsgBox("Enter TPNO", MsgBoxStyle.Critical, "Transfer")
            Exit Sub
        End If
        If cmbAgainst.SelectedItem = "TP" Then
            If txtTransferDetailTPno.Text = "" Then
                MsgBox("Please Insert TP no")
                Exit Sub
            End If
        End If
        'If cmbLicense.SelectedValue = 0 Then
        '    GoTo step1
        'End If
        If Not cmbLicense.SelectedValue = 0 Then

            If Not ValidateBrand() Then
                Dim r1 As DialogResult = MessageBox.Show("No Brand for " & cmbLicense.Text, "CWPlus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                If r1 = DialogResult.OK Then
                    Exit Sub
                End If

                Exit Sub
            End If
        End If
        'If ValidateBrand() = True Then

step1:  Dim Objpurchase As New CWPlusBL.Master.Clspurchase
        Dim objdt As New DataTable

        If Not TypeOf cmbBrandName.SelectedValue Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf cmbSize.SelectedValue Is Decimal Then
            Exit Sub
        End If
        Try
            Objpurchase.BrandID = cmbBrandName.SelectedValue
            Objpurchase.CategorySizeLinkID = cmbSize.SelectedValue
            objdt = Objpurchase.BindPurchaseRate
            Dim PurchaseTrnRate As Double = 0
            If objdt.Rows.Count > 0 Then
                If gblForBrandOpeningID = 0 Then
                    gblForBrandOpeningID = objdt.Rows(0).Item("brandopeningID")
                End If
                PurchaseTrnRate = objdt.Rows(0).Item("PurchaseTrnRate")
            End If

            If cmbAgainst.SelectedItem = "TP" Then
                grdTransfer.Rows.Add(objdt.Rows(0).Item("brandopeningID"), cmbBrandName.Text, cmbSize.Text, cmbAgainst.SelectedItem, txtTransferDetailTPno.Text, 0, 0, 0, 0, 0, 0, 0, PurchaseTrnRate, gblForBrandOpeningID, lblBrandDetailsLable.Text, objdt.Rows(0).Item("boxqty"))
            Else
                grdTransfer.Rows.Add(objdt.Rows(0).Item("brandopeningID"), cmbBrandName.Text, cmbSize.Text, cmbAgainst.SelectedItem, txtTransferHeadTPNo.Text, 0, 0, 0, 0, 0, 0, 0, PurchaseTrnRate, gblForBrandOpeningID, lblBrandDetailsLable.Text, objdt.Rows(0).Item("boxqty"))
            End If
            lblBrandDetailsLable.Text = ""
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

        cmbBrandName.SelectedItem = Nothing
        cmbSize.SelectedItem = Nothing
        cmbAgainst.SelectedItem = "General"
        txtTransferDetailTPno.Text = ""



    End Sub
    Private Sub cmbBrandName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrandName.SelectedIndexChanged

        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf (cmbBrandName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        BindSize(cmbBrandName.SelectedValue)
    End Sub

    Public Function FetchTransferHaedDetails() As Boolean
        Dim ObjTransfer As New ClsTransfer
        Dim ObjDt As New DataSet
        Try

            ObjTransfer.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjTransfer.TransferHeadID = lblTransferHeadID.Text
            ObjTransfer.TPNo = ""
            ObjTransfer.InviceNo = ""
            ObjTransfer.TransferDate = "1-1-1900"

            ObjDt = ObjTransfer.FunFetchTransferHeadMaster()

            If ObjDt.Tables(0).Rows.Count > 0 Then
                txtTransferHeadTPNo.Text = ObjDt.Tables(0).Rows(0)("tpno")
                txtInvoiceNo.Text = ObjDt.Tables(0).Rows(0)("invioceno")
                If IsDBNull(ObjDt.Tables(0).Rows(0)("ForLicenseId")) Then
                    chkShowExcise.Checked = False
                    cmbDept.SelectedValue = ObjDt.Tables(0).Rows(0)("deptid")
                Else
                    chkShowExcise.Checked = True
                    cmbLicense.SelectedValue = ObjDt.Tables(0).Rows(0)("ForLicenseId")
                End If
                MDI.cmbLicenseName.SelectedValue = ObjDt.Tables(0).Rows(0)("LicenseID")
                BindLicenseForTransfer()
                cmbLicense.SelectedValue = ObjDt.Tables(0).Rows(0)("ForLicenseId")
                dtpTransferHead.Text = ObjDt.Tables(0).Rows(0)("transferdate")
                txtFLIV.Text = ObjDt.Tables(0).Rows(0)("fliv")
                txtAddress.Text = ObjDt.Tables(0).Rows(0)("flivAddress")

                'If LTrim(RTrim(txtAddress.Text)) <> "" Then
                '    txtAddress.Visible = True
                'End If

            End If

            Dim ObjTransfer1 As New ClsTransfer
            Dim ObjDt1 As New DataSet

            ObjTransfer1.TransferHeadID = lblTransferHeadID.Text
            ObjTransfer1.TPNo = txtTransferDetailTPno.Text
            ObjTransfer1.InviceNo = txtInvoiceNo.Text
            ObjTransfer1.TransferDate = dtpTransferHead.Value

            ObjDt1 = ObjTransfer1.FunFetchTransferHeadMaster()
            If ObjDt1.Tables(1).Rows.Count > 0 Then
                For rwctr = 0 To ObjDt1.Tables(1).Rows.Count - 1
                    grdTransfer.Rows.Add()
                    grdTransfer.Item("size", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("Alias")
                    grdTransfer.Item("brandname", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("BrandDesc")
                    grdTransfer.Item("BrandopeningId", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("brandopeningid")
                    grdTransfer.Item("against", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("Against")
                    grdTransfer.Item("tpno", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("TrDetailTPNo")
                    grdTransfer.Item("batch", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("Batch")
                    grdTransfer.Item("mfg", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("Mfg")
                    grdTransfer.Item("box", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("Box")
                    grdTransfer.Item("remarks", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("Remarks")
                    grdTransfer.Item("spegqty", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("spegqty")
                    grdTransfer.Item("spegrate", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("spegrate")
                    grdTransfer.Item("bottleqty", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("bottleqty")
                    grdTransfer.Item("bottlerate", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("bottlerate")
                    grdTransfer.Item("ForbrandopningId", rwctr).Value = ObjDt1.Tables(1).Rows(rwctr)("Forbrandopeningid")


                Next

            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(ObjTransfer) Then
                ObjTransfer = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Function

    Public Sub SaveCheck()

        If TransferHeadID = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Transfer")
                Exit Sub
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Transfer")
                Exit Sub
            End If
        End If
        If ltrim(rtrim(txtTransferHeadTPNo.Text)) = "" Then
            MsgBox("Enter TPNO", MsgBoxStyle.Critical, "Transfer")
            Exit Sub
        ElseIf (MDI.cmbLicenseName.Text = "") Then
            MsgBox("Select License Name", MsgBoxStyle.Critical, "Transfer")
            MDI.cmbLicenseName.Focus()
            Exit Sub
        ElseIf (grdTransfer.Rows.Count = 0) Then
            MsgBox("Nothing To Save", MsgBoxStyle.Critical, "Transfer")
            Exit Sub

        End If

        '[+][13/12/2019][Ajay Prajapati]
        Dim VarianceCount As Integer
        Dim ObjSaler As New ClsSale
        Dim ObjCheckVariance As New DataTable
        ObjSaler.LicenseID = MDI.cmbLicenseName.SelectedValue
        ObjSaler.BillDate = dtpTransferHead.Value
        ObjSaler.TransactionType = "T" 'Transfer
        ObjCheckVariance = ObjSaler.FunCheckVariance()
        If (ObjCheckVariance.Rows.Count > 0) Then
            VarianceCount = Convert.ToInt32(ObjCheckVariance.Rows(0)("VarianceCount"))
        End If

        If (VarianceCount > 0) Then
            MsgBox("Can not save the Transfer since Variance done", MsgBoxStyle.OkOnly, "Transfer")
            Exit Sub
        End If
        '[-][13/12/2019][Ajay Prajapati]




        If ValidateQty() = True Then

            Dim ObjTransferHead As New ClsTransfer
            Dim ObjPriDt As New DataTable
            Dim StrPriNeg As String = ""
            Try

                StrPriNeg = NegativeStock()
                If StrPriNeg <> "" Then
                    MsgBox(StrPriNeg)
                    Exit Sub
                End If
                ObjTransferHead.TransferHeadID = lblTransferHeadID.Text
                ObjTransferHead.TransferDate = dtpTransferHead.Text
                ObjTransferHead.TPNo = txtTransferHeadTPNo.Text
                ObjTransferHead.InviceNo = txtInvoiceNo.Text
                ObjTransferHead.ForLicenseID = cmbLicense.SelectedValue
                ObjTransferHead.DeptId = cmbDept.SelectedValue
                ObjTransferHead.FLIV = txtFLIV.Text
                ObjTransferHead.FLIVAddress = LTrim(RTrim(txtAddress.Text))
                ObjTransferHead.LicenseID = MDI.cmbLicenseName.SelectedValue
                ObjTransferHead.BrandID = cmbBrandName.SelectedValue
                ObjTransferHead.SizeID = cmbSize.SelectedValue
                'If cmbAgainst.SelectedItem = "General" Then
                '    ObjTransferHead.Against = "GN"
                'Else
                '    ObjTransferHead.Against = "TP"
                'End If
                ObjTransferHead.TrDetailsTPNo = txtTransferDetailTPno.Text
                ObjTransferHead.TransferDetailsXML = GenerateXML()
                ObjTransferHead.UserName = gblUserName
                ObjTransferHead.FunSave()
                MsgBox(ObjTransferHead.ErrorMsg)

                'Dim Parentnode As New TreeNode("transaction")
                'Dim ChildNode As New TreeNode("transfer")
                'Parentnode.Nodes.Add(ChildNode)
                'OpenForm(ChildNode)

                If IsReport Then
                    FrmTransferReport.btnok.PerformClick()
                Else
                    FrmTransferList.btnSearch.PerformClick()
                End If
                Me.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Not IsNothing(ObjTransferHead) Then
                    ObjTransferHead = Nothing
                End If
                If Not IsNothing(ObjPriDt) Then
                    ObjPriDt = Nothing
                End If

            End Try




        End If

    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click, SaveToolStripMenuItem.Click
      
        If LTrim(RTrim(txtFLIV.Text)) <> "" And FLIVAddress = True And LTrim(RTrim(txtAddress.Text)) = "" Then
            MsgBox("Please Insert FLIV Address Before Save!!", MsgBoxStyle.Critical)
        Else
            SaveCheck()
        End If

    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        'Dim parentNod As New TreeNode("transaction")
        'Dim childNod As New TreeNode("transfer")
        'parentNod.Nodes.Add(childNod)
        'OpenForm(childNod)
        Me.Close()
    End Sub

    Public Sub Worning()
        Try
            Dim r1 As DialogResult = MessageBox.Show("Grid Will Be Clear", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If r1 = DialogResult.Yes Then
                btnCallEvent_Click(btnCallEvent, New EventArgs())
                grdTransfer.Refresh()
                If Not IsNothing(grdTransfer.DataSource) Then
                    grdTransfer.DataSource = Nothing
                    grdTransfer.Refresh()
                Else
                    grdTransfer.Rows.Clear()
                    grdTransfer.Refresh()
                End If

            ElseIf r1 = DialogResult.No Then
                'added by sachin J on 4 Feb 2015 to check license is changed
                cmbLicense.SelectedValue = gblForLicense
                'Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbLicense_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLicense.SelectionChangeCommitted
        'LicenseDesc = cmbLicense.Text.ToString()


        If Not TypeOf (cmbLicense.SelectedValue) Is Decimal Then
            Exit Sub
        End If

        If grdTransfer.Rows.Count > 0 Then
            Worning()
            Exit Sub
        Else
            Exit Sub
        End If
    End Sub


    Private Sub cmbSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSize.SelectedIndexChanged
        'If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
        '    Exit Sub
        'End If
        'If Not TypeOf (cmbSize.SelectedValue) Is Decimal Then
        '    Exit Sub
        'End If

        If Not TypeOf (cmbSize.SelectedValue) Is Decimal OrElse cmbSize.SelectedValue = 0 Then
            Exit Sub
        End If
        FetchBrandType()

    End Sub

    Public Sub FetchBrandType()
        Dim objBrandType As New ClsAutobilling
        Dim ObjPriDt As New DataTable
        Try
            objBrandType.BrandID = cmbBrandName.SelectedValue
            objBrandType.LicenseID = MDI.cmbLicenseName.SelectedValue
            objBrandType.CategorySizeLinkID = cmbSize.SelectedValue
            objBrandType.AutoDate = dtpTransferHead.Text
            ObjPriDt = objBrandType.FunFetchBrandQuntity()
            If ObjPriDt.Rows.Count > 0 Then
                lblBrandDetailsLable.Text = ObjPriDt.Rows(0).Item("BrandStock").ToString()
                lblBrandDetailsLable.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objBrandType) Then
                objBrandType = Nothing
            End If
            If Not IsNothing(ObjPriDt) Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Private Sub cmbAgainst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgainst.SelectedIndexChanged
        If cmbAgainst.SelectedItem = "TP" Then
            txtTransferDetailTPno.Enabled = True
        Else
            txtTransferDetailTPno.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowExcise.CheckedChanged

        If grdTransfer.RowCount > 0 Then
            chkShowExcise.CheckState = CheckState.Unchecked
            MsgBox("Rows Added", MsgBoxStyle.Information, "Transfer")
            Exit Sub
        End If
        If chkShowExcise.Checked Then
            lblLicenseID.Text = "For License"
            cmbDept.Visible = False
            cmbDept.SelectedValue = 0
            cmbLicense.Visible = True
        Else
            lblLicenseID.Text = "Department"
            cmbDept.Visible = True
            cmbLicense.Visible = False
            cmbLicense.SelectedValue = 0
        End If
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        If Not TypeOf (cmbDept.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not cmbDept.SelectedValue > 0 Then
            Exit Sub
        End If
        Dim ObjDt As New DataTable
        Try
            ObjDept = New CWPlusBL.Master.ClsDeptMaster
            ObjDept.DeptId = cmbDept.SelectedValue
            ObjDt = ObjDept.FunFetch
            If Not IsDBNull(ObjDt.Rows(0)("licenseid")) Then
                cmbLicense.SelectedValue = ObjDt.Rows(0)("licenseid")
            Else
                cmbLicense.SelectedValue = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjDept) Then
                ObjDept = Nothing
            End If
        End Try
    End Sub

    Private Sub grdTransfer_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTransfer.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        If grdTransfer.Item("Boxhideqty", e.RowIndex).Value = 0 Then Exit Sub

        If grdTransfer.Columns(e.ColumnIndex).Name = "bottleqty" Then
            If grdTransfer.Item("bottleqty", e.RowIndex).Value >= grdTransfer.Item("Boxhideqty", e.RowIndex).Value Then
                Dim vCoeff As Integer = 0
                Dim vRem As Integer = 0
                vCoeff = grdTransfer.Item("bottleqty", e.RowIndex).Value / grdTransfer.Item("Boxhideqty", e.RowIndex).Value
                vRem = (grdTransfer.Item("bottleqty", e.RowIndex).Value Mod grdTransfer.Item("Boxhideqty", e.RowIndex).Value)
                If vRem.ToString.Length = 1 Then
                    grdTransfer.Item("Box", e.RowIndex).Value = vCoeff & ".0" & vRem
                Else
                    grdTransfer.Item("Box", e.RowIndex).Value = vCoeff & "." & vRem
                End If
            Else
                grdTransfer.Item("Box", e.RowIndex).Value = "0." & grdTransfer.Item("bottleqty", e.RowIndex).Value
            End If
            'Else
            '    MsgBox("Please Enter Valid Bottle Quantity", MsgBoxStyle.Information)
        End If
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

    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles grdTransfer.EditingControlShowing
        If grdTransfer.Columns(grdTransfer.CurrentCell.ColumnIndex).Name = "bottleqty" Or grdTransfer.Columns(grdTransfer.CurrentCell.ColumnIndex).Name = "spegqty" Then
            BoolPriBotandspeg = True
            Dim txtEdit As TextBox = e.Control
            'remove any existing handler
            RemoveHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress
            AddHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress

        Else
            BoolPriBotandspeg = False
        End If

    End Sub

    Public Sub btnCallEvent_Click(sender As System.Object, e As System.EventArgs) Handles btnCallEvent.Click
        Try
            Me.grdTransfer.Refresh()
            Me.grdTransfer.DataSource = Nothing
            Me.grdTransfer.Rows.Clear()
            Me.grdTransfer.Refresh()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub dtpTransferHead_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpTransferHead.ValueChanged
        BindBrand(0)   'Added by Samvedna on [23-01-2020]
    End Sub
End Class