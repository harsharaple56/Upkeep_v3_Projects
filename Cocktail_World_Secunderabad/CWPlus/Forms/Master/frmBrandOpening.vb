Imports System.Xml
Public Class frmBrandOpening
    Dim ObjCategorySizeLnkUp As CWPlusBL.Master.ClsCategorySizelinlup
    Dim ObjCategory As CWPlusBL.Master.ClsCategory
    Dim ObjBrand As CWPlusBL.Master.ClsBrandHeadDet
    Dim ObjBrandOpening As CWPlusBL.Master.ClsBrandOpening
    Dim ObjDt As DataTable

    Dim arrRowIndex, arrTmp As ArrayList

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
    End Sub
#Region "Procedures"

    Private Sub ClrScr()
        txtLpegRate.Text = 0
        txtSPegRate.Text = 0
        cmbBrandName.Text = ""
        cmbBrandName.SelectedValue = -1
        grdBrandOpening.Rows.Clear()
    End Sub

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><BrandOpening></BrandOpening></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("BrandOpeningDet")
        For ctr = 0 To arrRowIndex.Count - 1
            'If CBool(grdBrandOpening.Item("sel", index).Value) Then
            Dim index As Integer = arrRowIndex.Item(ctr)
            XmlElt = xmldoc.CreateElement("BrandOpeningDet")
            XmlElt.SetAttribute("categorysizelinkupid", grdBrandOpening.Item("categorysizelinkupid", index).Value)
            XmlElt.SetAttribute("sRate", grdBrandOpening.Item("sRate", index).Value)
            XmlElt.SetAttribute("OpeningQty", grdBrandOpening.Item("OpeningQty", index).Value)
            XmlElt.SetAttribute("OpSpQty", grdBrandOpening.Item("OpSpQty", index).Value)
            XmlElt.SetAttribute("BaseQty", grdBrandOpening.Item("BaseQty", index).Value)
            XmlElt.SetAttribute("OrdNo", grdBrandOpening.Item("OrdNo", index).Value)
            XmlElt.SetAttribute("ReorderLevel", grdBrandOpening.Item("ReorderLevel", index).Value)
            XmlElt.SetAttribute("OptimumLevel", grdBrandOpening.Item("OptimumLevel", index).Value)
            xmldoc.DocumentElement.Item("BrandOpening").AppendChild(XmlElt)
            'End If
        Next
        Return xmldoc
    End Function
    Private Function GeneratecategorysizeXML() As XmlDocument
        Dim xmldoc1 As New XmlDocument
        xmldoc1.LoadXml("<Master><BrandOpening></BrandOpening></Master>")
        Dim XmlElt As XmlElement = xmldoc1.CreateElement("categorysizeDet")
        For index = 0 To grdBrandOpening.RowCount - 1
            If CBool(grdBrandOpening.Item("sel", index).Value) Then
                XmlElt = xmldoc1.CreateElement("categorysizeDet")
                XmlElt.SetAttribute("categorysizelinkupid", grdBrandOpening.Item("categorysizelinkupid", index).Value)
                xmldoc1.DocumentElement.Item("BrandOpening").AppendChild(XmlElt)
            End If
        Next
        Return xmldoc1
    End Function
    Private Function validateMultiplelicensewise() As Boolean
        validateMultiplelicensewise = False
        ObjBrandOpening = New CWPlusBL.Master.ClsBrandOpening
        ObjBrandOpening.categorySizeXML = GeneratecategorysizeXML()
        ObjBrandOpening.LicensewiseXML = GenerateLicenseIDXML()
        ObjBrandOpening.UserID = gblUserID
        validateMultiplelicensewise = ObjBrandOpening.FunValidatelicenseWise()
    End Function
    Private Function GenerateLicenseIDXML() As XmlDocument
        Dim xmldoc2 As New XmlDocument
        xmldoc2.LoadXml("<Master><BrandOpening></BrandOpening></Master>")
        Dim XmlElt As XmlElement = xmldoc2.CreateElement("LicenseDet")
        For index = 0 To MDI.chkLicenseName.CheckedItems.Count - 1
            If Not DirectCast(MDI.chkLicenseName.CheckedItems(index), System.Data.DataRowView).Row.ItemArray(0) = 0 Then
                XmlElt = xmldoc2.CreateElement("LicenseDet")
                XmlElt.SetAttribute("Licenseid", DirectCast(MDI.chkLicenseName.CheckedItems(index), System.Data.DataRowView).Row.ItemArray(0))
                xmldoc2.DocumentElement.Item("BrandOpening").AppendChild(XmlElt)
            End If
        Next
        Return xmldoc2
    End Function
    Public Sub FetchCategorySizeLinkUp(ByVal CategoryID As Double)

        Try
            ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
            ObjDt = New DataTable
            ObjCategorySizeLnkUp.CategoryID = CategoryID
            ObjCategorySizeLnkUp.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDt = ObjCategorySizeLnkUp.FunFetch

            If ObjDt.Rows.Count > 0 Then
                For rwctr = 0 To ObjDt.Rows.Count - 1
                    grdBrandOpening.Rows.Add()
                    grdBrandOpening("categorysizelinkupid", rwctr).Value = ObjDt.Rows(rwctr)("CategorySizeLinkID")
                    grdBrandOpening("size", rwctr).Value = ObjDt.Rows(rwctr)("Alias")
                    grdBrandOpening("sRate", rwctr).Value = 0
                    grdBrandOpening("OpeningQty", rwctr).Value = 0
                    grdBrandOpening("OpSpQty", rwctr).Value = 0
                    grdBrandOpening("BaseQty", rwctr).Value = 0
                    grdBrandOpening("OrdNo", rwctr).Value = 0
                    grdBrandOpening("reorderlevel", rwctr).Value = 0
                    grdBrandOpening("optimumlevel", rwctr).Value = 0
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    Public Function CheckExistence() As String
        Dim str As String = ""
        arrRowIndex = New ArrayList
        arrTmp = New ArrayList
        For index = 0 To grdBrandOpening.RowCount - 1
            'If CBool(grdBrandOpening.Item("sel", index).Value) And CBool(grdBrandOpening.Item("isvaluechanged", index).Value) Then
            If CBool(grdBrandOpening.Item("sel", index).Value) Then
                arrTmp.Add(index)
                ObjBrandOpening = New CWPlusBL.Master.ClsBrandOpening
                ObjBrandOpening.BrandID = cmbBrandName.SelectedValue
                ObjBrandOpening.LicenseID = MDI.cmbLicenseName.SelectedValue
                ObjBrandOpening.CategorySizeLinkID = grdBrandOpening.Item("categorysizelinkupid", index).Value
                If Not ObjBrandOpening.CheckBrandOpeningExistence Then
                    str &= "," & grdBrandOpening.Item("size", index).Value
                Else
                    arrRowIndex.Add(index)
                End If
            End If
        Next
        If Not str = "" Then
            str = str.Trim(",")
            str &= " are already used."
        End If

        Return str
    End Function

    Public Function CheckOrderNo() As Boolean
        CheckOrderNo = False
        Dim tmpDt As DataTable
        tmpDt = New DataTable
        tmpDt.Columns.Add("OrderNo", GetType(System.Double))

        For index = 0 To grdBrandOpening.RowCount - 1
            If CBool(grdBrandOpening.Item("sel", index).Value) Then
                If Not grdBrandOpening.Item("OrdNo", index).Value = 0 Then
                    tmpDt.Rows.Add(grdBrandOpening.Item("OrdNo", index).Value)
                End If

            End If
        Next

        If tmpDt.Rows.Count = 0 Then
            CheckOrderNo = True
            Exit Function
        End If

        tmpDt.DefaultView.Sort = "OrderNo"
        Dim vCount As Integer = 1
        For index = 0 To tmpDt.DefaultView.Count - 1
            If Not tmpDt.DefaultView(index)("OrderNo") = vCount Then
                Exit Function
            End If
            vCount += 1
        Next
        CheckOrderNo = True
    End Function

    Public Function Save() As Boolean
        Save = False
        If cmbBrandName.SelectedValue = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Brand Opening")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Brand Opening")
                Exit Function
            End If
        End If
        If Not cmbBrandName.SelectedValue > 0 Then
            MsgBox("Select brand name", MsgBoxStyle.Critical, "Brand Opening")
            Exit Function
        ElseIf validateMultiplelicensewise() = False Then
            MsgBox("Sizes Are Not Available For License", MsgBoxStyle.Critical, "Brand Opening")
            Exit Function

        ElseIf (MDI.cmbLicenseName.Text = "") Then
            MsgBox("Please Select License Name", MsgBoxStyle.Critical, "Brand Opening")
            MDI.cmbLicenseName.Focus()
            Exit Function
        ElseIf (cmbBrandName.Text = "") Then
            MsgBox("Please Select Brand Name", MsgBoxStyle.Critical, "Brand Opening")
            MDI.cmbLicenseName.Focus()
            Exit Function
        ElseIf Not CheckOrderNo() Then
            MsgBox("Order No. not proper", MsgBoxStyle.Critical, "Brand Opening")
            Exit Function

        End If
        Try
            If MDI.cmdMultiSelect.Text = "M" And MDI.chkLicenseName.CheckedItems.Count = 0 Then
                Dim tmpStr As String = ""
                tmpStr = CheckExistence()

                If chkEditBaseQuantity.Checked Then
                    arrRowIndex = arrTmp
                    GoTo step1
                End If


                If Not tmpStr = "" Then
                    MsgBox(tmpStr, MsgBoxStyle.Information, "Opening Stock")
                    If arrRowIndex.Count = 0 Then
                        Exit Function
                    End If
                End If
                'If Not arrRowIndex.Count > 0 Then
                '    MsgBox("There are no changes to save")
                '    Exit Function
                'End If
step1:          ObjBrandOpening = New CWPlusBL.Master.ClsBrandOpening
                ObjBrandOpening.BrandID = cmbBrandName.SelectedValue
                ObjBrandOpening.LicenseID = MDI.cmbLicenseName.SelectedValue
                ObjBrandOpening.BrandOpeningXML = GenerateXML()
                ObjBrandOpening.IsBaseQty = chkEditBaseQuantity.Checked
                ObjBrandOpening.SpegRate = txtSPegRate.Text
                ObjBrandOpening.LpegRate = txtLpegRate.Text
                ObjBrandOpening.UserID = gblUserID
                ObjBrandOpening.UserName = gblUserName
                Save = ObjBrandOpening.FunSave
            Else
                For chkCtr = 0 To MDI.chkLicenseName.CheckedItems.Count - 1
                    If Not DirectCast(MDI.chkLicenseName.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0) = 0 Then
                        ObjBrandOpening = New CWPlusBL.Master.ClsBrandOpening
                        ObjBrandOpening.BrandID = cmbBrandName.SelectedValue
                        ObjBrandOpening.LicenseID = DirectCast(MDI.chkLicenseName.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0)
                        'ObjBrandOpening.LicenseID = MDI.cmbLicenseName.SelectedValue
                        ObjBrandOpening.BrandOpeningXML = GenerateXML()
                        ObjBrandOpening.SpegRate = txtSPegRate.Text
                        ObjBrandOpening.LpegRate = txtLpegRate.Text
                        ObjBrandOpening.UserName = gblUserName
                        Save = ObjBrandOpening.FunSave
                    End If
                Next
            End If

            MsgBox(ObjBrandOpening.ErrorMsg)
            ClrScr()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(arrRowIndex) Then
                arrRowIndex.Clear()
            End If
        End Try
    End Function

    Public Function FunDelete(ByVal CategorySizeLinkUpID As Double) As Boolean
        FunDelete = False

        Try
            ObjBrandOpening = New CWPlusBL.Master.ClsBrandOpening
            ObjBrandOpening.BrandID = cmbBrandName.SelectedValue
            ObjBrandOpening.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjBrandOpening.CategorySizeLinkID = CategorySizeLinkUpID
            ObjBrandOpening.UserID = gblUserID
            FunDelete = ObjBrandOpening.FunDelete
            MsgBox(ObjBrandOpening.ErrorMsg)
            ClrScr()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(arrRowIndex) Then
                arrRowIndex.Clear()
            End If
        End Try
    End Function

    Public Sub BindBrand(ByVal BrandID As Double)
        Try
            ObjBrand = New CWPlusBL.Master.ClsBrandHeadDet
            ObjDt = New DataTable
            ObjBrand.BrandID = BrandID
            ObjDt = ObjBrand.FunFetch
            If Not ObjDt.Rows.Count > 0 Then
                Exit Sub
            End If
            If BrandID = 0 Then
                ComboBindingTemplate(cmbBrandName, ObjDt, "dispfield", "valuefield")
            Else
                FetchCategorySizeLinkUp(ObjDt.Rows(0)("categoryid"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    Public Sub FetchBrandOpening()
        Try
            ObjBrandOpening = New CWPlusBL.Master.ClsBrandOpening
            ObjDt = New DataTable
            ObjBrandOpening.BrandID = cmbBrandName.SelectedValue
            ObjBrandOpening.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDt = ObjBrandOpening.FunFetch
            txtLpegRate.Text = 0
            txtSPegRate.Text = 0
            If Not ObjDt.Rows.Count > 0 Then Exit Sub
            txtLpegRate.Text = ObjDt.Rows(0)("LpegRate")
            txtSPegRate.Text = ObjDt.Rows(0)("spegRate")
            For rwctr = 0 To grdBrandOpening.RowCount - 1
                Dim tmpDv As DataView
                tmpDv = New DataView(ObjDt)
                tmpDv.RowFilter = "CategorySizeLinkUpID=" & grdBrandOpening.Item("CategorySizeLinkUpID", rwctr).Value
                If tmpDv.Count > 0 Then
                    grdBrandOpening.Item("sel", rwctr).Value = True
                    grdBrandOpening.Item("sRate", rwctr).Value = tmpDv(0)("sRate")
                    grdBrandOpening.Item("OpeningQty", rwctr).Value = tmpDv(0)("OpeningQty")
                    grdBrandOpening.Item("OpSpQty", rwctr).Value = tmpDv(0)("OpSpQty")
                    grdBrandOpening.Item("BaseQty", rwctr).Value = tmpDv(0)("BaseQty")
                    grdBrandOpening.Item("OrdNo", rwctr).Value = tmpDv(0)("OrdNo")
                    grdBrandOpening.Item("ReorderLevel", rwctr).Value = tmpDv(0)("ReorderLevel")
                    grdBrandOpening.Item("OptimumLevel", rwctr).Value = tmpDv(0)("OptimumLevel")
                End If
                'grdBrandOpening.Item("IsValueChanged", rwctr).Value = False
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub
#End Region

    Private Sub frmBrandOpening_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MDI.chkLicenseName.Visible = False
    End Sub

   
    Private Sub frmBrandOpening_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        BindBrand(0)
    End Sub
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Save()
    End Sub
    Private Sub cmbBrandName_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrandName.SelectedIndexChanged
        grdBrandOpening.Rows.Clear()
        If Not TypeOf cmbBrandName.SelectedValue Is Decimal Then
            chkEditBaseQuantity.Checked = False
            chkEditBaseQuantity.Visible = False
            Exit Sub
        End If
        chkEditBaseQuantity.Visible = True
        BindBrand(cmbBrandName.SelectedValue)
        FetchBrandOpening()

        If Not TypeOf (cmbBrandName.SelectedValue) Is Decimal Or cmbBrandName.SelectedValue = 0 Then
            chkEditBaseQuantity.Checked = False
            chkEditBaseQuantity.Visible = False
        End If
    End Sub

    Public Sub SaveCheck()
        Save()
        For rctr = 0 To MDI.chkLicenseName.Items.Count - 1
            MDI.chkLicenseName.SetItemChecked(rctr, False)
        Next
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        SaveCheck()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub grdBrandOpening_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBrandOpening.CellValueChanged
        'If e.RowIndex < 0 Then Exit Sub

        'If e.ColumnIndex = 0 Then
        '    If CBool(grdBrandOpening.Item(e.ColumnIndex, e.RowIndex).Value) Then
        '        grdBrandOpening.Item("IsValueChanged", e.RowIndex).Value = True
        '        Exit Sub
        '    End If
        'End If

        'If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
        '    If Not vTempCellValue = grdBrandOpening.Item(e.ColumnIndex, e.RowIndex).Value Then
        '        grdBrandOpening.Item("IsValueChanged", e.RowIndex).Value = True
        '    End If
        'End If
    End Sub

    Private Sub grdBrandOpening_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBrandOpening.CellContentClick
        If grdBrandOpening.Columns(e.ColumnIndex).Name.ToLower = "vremove" Then
            If Not GblBoolDelete Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Opening Stock")
                Exit Sub
            End If
            ObjBrandOpening = New CWPlusBL.Master.ClsBrandOpening
            ObjBrandOpening.BrandID = cmbBrandName.SelectedValue
            ObjBrandOpening.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjBrandOpening.CategorySizeLinkID = grdBrandOpening.Item("categorysizelinkupid", e.RowIndex).Value
            'If Not ObjBrandOpening.CheckBrandOpeningExistence Then
            '    MsgBox(grdBrandOpening.Item("size", e.RowIndex).Value & " is used you can't remove this")
            '    Exit Sub
            'Else
            FunDelete(grdBrandOpening.Item("categorysizelinkupid", e.RowIndex).Value)
            'End If
        End If
    End Sub

    Dim vTempCellValue As Double = 0

    Private Sub grdBrandOpening_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBrandOpening.CellEnter
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
            vTempCellValue = grdBrandOpening.Item(e.ColumnIndex, e.RowIndex).Value
        End If

    End Sub


    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSPegRate.KeyPress, txtLpegRate.KeyPress
        Dim txt As TextBox = DirectCast(sender, TextBox)
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
    End Sub
End Class