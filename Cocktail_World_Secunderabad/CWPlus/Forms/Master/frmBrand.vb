Imports System.Xml
Imports CWPlusBL.Master

Public Class frmBrand
    Dim ObjCategorySizeLnkUp As CWPlusBL.Master.ClsCategorySizelinlup
    Dim ObjCategory As CWPlusBL.Master.ClsCategory
    Dim ObjBrand As CWPlusBL.Master.ClsBrandHeadDet
    Dim ObjDt As DataTable
    Dim chk As Boolean = False
    'Dim chkDisable As Boolean = True

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(GroupBox1)
    End Sub
#Region "Procedures"
    Private Sub ClrScr()
        lblID.Text = 0
        cmbBrand.Text = ""
        cmbBrand.SelectedValue = -1
        cmbCategory.Text = ""
        cmbCategory.SelectedValue = -1
        txtPurRatePeg.Text = "0"
        txtShortname.Clear()
        txtStrength.Text = "0"
        ChkBDisable.Checked = False  'Added by Samvedna on [23-01-20]

        grdBrand.Rows.Clear()
    End Sub
    Private Sub BindCategory()
        Try
            ObjCategory = New CWPlusBL.Master.ClsCategory
            ObjDt = New DataTable
            ObjDt = ObjCategory.FunFetch

            cmbCategory.DataSource = Nothing
            chk = True
            ComboBindingTemplate(cmbCategory, ObjDt, "categorydesc", "categoryid")

            chk = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategory) Then
                ObjCategory = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    Private Function GenerateXML() As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Master><Brand></Brand></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("BrandDet")
        For index = 0 To grdBrand.RowCount - 1
            XmlElt = xmldoc.CreateElement("BrandDet")
            XmlElt.SetAttribute("SizeId", grdBrand.Item("sizeid", index).Value)
            XmlElt.SetAttribute("BoxQuantity", grdBrand.Item("BoxQty", index).Value)
            XmlElt.SetAttribute("PurchaseRate", grdBrand.Item("PurRate", index).Value)
            xmldoc.DocumentElement.Item("Brand").AppendChild(XmlElt)
        Next

        Return xmldoc
    End Function

    Public Sub FetchCategorySizes()
        Dim dt As New DataTable
        Try
            ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup

            ObjCategorySizeLnkUp.CategoryID = cmbCategory.SelectedValue
            ObjCategorySizeLnkUp.LicenseID = MDI.cmbLicenseName.SelectedValue
            dt = ObjCategorySizeLnkUp.FunFetch

            grdBrand.Rows.Clear()
            For rwctr = 0 To dt.Rows.Count - 1
                grdBrand.Rows.Add()
                grdBrand.Item("sizeid", rwctr).Value = dt.Rows(rwctr)("sizeid")
                grdBrand.Item("size", rwctr).Value = dt.Rows(rwctr)("sizedesc")
                grdBrand.Item("sizeAlias", rwctr).Value = dt.Rows(rwctr)("Alias")
                grdBrand.Item("boxqty", rwctr).Value = 0
                grdBrand.Item("purrate", rwctr).Value = 0
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(dt) Then
                dt = Nothing
            End If
        End Try
    End Sub

    Public Function Save() As Boolean
        Save = False
        ''Added by Samvedna on [22-01-20] starts
        'If ChkBDisable.Checked = True Then
        '    chk = 0

        'ElseIf chk = 1 Then
        'End If

        If ChkBDisable.Checked = True Then
            chk = False

        ElseIf ChkBDisable.Checked = False Then
            chk = True
        End If




        ''Added by Samvedna on [22-01-20] Ends

        If cmbBrand.SelectedValue = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Brand")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Brand")
                Exit Function
            End If
        End If
        If txtShortname.Text = "" Then
            MsgBox("Enter Short Name", MsgBoxStyle.Critical, "Brand")
            txtShortname.Focus()
            Exit Function
        ElseIf cmbBrand.Text = "" Then
            MsgBox("Enter Brand Name", MsgBoxStyle.Critical, "Brand")
            cmbBrand.Focus()
            Exit Function
        ElseIf cmbCategory.Text = "--Select--" Then
            MsgBox("Select Category", MsgBoxStyle.Critical, "Brand")
            cmbCategory.Focus()
            Exit Function
        ElseIf grdBrand.RowCount = 0 Then
            MsgBox("Sizes Are Not Available", MsgBoxStyle.Critical, "Brand")
            Exit Function
        End If

        Try
            ObjBrand = New CWPlusBL.Master.ClsBrandHeadDet
            ObjBrand.BrandID = lblID.Text
            ObjBrand.BrandDesc = cmbBrand.Text
            ObjBrand.Shortname = txtShortname.Text
            ObjBrand.Strength = CDbl(txtStrength.Text)
            ObjBrand.PurRate = txtPurRatePeg.Text
            ObjBrand.BrandDetXML = GenerateXML()
            ObjBrand.CategoryID = cmbCategory.SelectedValue
            ObjBrand.SubCategoryID = cmbSubCategory.SelectedValue
            ObjBrand.DisableID = chk   'Added by Samvedna on [22-01-20] 
            Save = ObjBrand.FunSave

            MsgBox(ObjBrand.ErrorMsg)
            ClrScr()

            BindBrand(cmbBrand.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
        End Try
    End Function
    Public Function delete() As Boolean
        delete = False
        If Not GblBoolDelete Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Brand Opening")
        End If
        Dim str As DialogResult = MsgBox("Are You Sure Want to Delete?", MsgBoxStyle.YesNo, "Brand")
        If str = vbNo Then
            Exit Function
        End If
        If cmbBrand.Text = "" Then
            MsgBox("Select / Enter Brand Name", MsgBoxStyle.Critical, "Brand")
            cmbBrand.Focus()
            Exit Function
        End If
        Try
            ObjBrand = New CWPlusBL.Master.ClsBrandHeadDet
            ObjBrand.BrandID = cmbBrand.SelectedValue
            ObjBrand.UserName = gblUserName
            delete = ObjBrand.FunDelete
            MsgBox(ObjBrand.ErrorMsg)
            ClrScr()
            BindCategory()
            BindBrand(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjBrand) Then
                ObjCategory = Nothing
            End If
        End Try
    End Function

    Public Sub BindBrand(ByVal BrandID As Double)
        Try
            cmbCategory.Enabled = True
            ObjBrand = New CWPlusBL.Master.ClsBrandHeadDet
            ObjDt = New DataTable
            ObjBrand.BrandID = BrandID
            ObjDt = ObjBrand.FunFetch
            If Not ObjDt.Rows.Count > 0 Then
                Exit Sub
            End If
            If BrandID = 0 Then
                chk = True
                ComboBindingTemplate(cmbBrand, ObjDt, "dispfield", "valuefield")

                chk = False
            Else
                'Added by Samvedna on [23-01-2020] Starts
                If ((ObjDt.Rows(0)("Is_Active") = True) = True) Then
                    ChkBDisable.Checked = False
                Else
                    ChkBDisable.Checked = True
                End If
                'Added by Samvedna on [23-01-2020] Ends
                txtPurRatePeg.Text = ObjDt.Rows(0)("PurRatePeg")
                txtShortname.Text = ObjDt.Rows(0)("shortname")
                txtStrength.Text = ObjDt.Rows(0)("strength")
                cmbCategory.SelectedValue = ObjDt.Rows(0)("categoryid")
                FetchCategorySizes()
                FetchSubCategory()
                cmbSubCategory.SelectedValue = ObjDt.Rows(0)("subcategoryid")

                cmbCategory.Enabled = False
                For rwctr = 0 To grdBrand.Rows.Count - 1
                    Dim dv As DataView
                    dv = New DataView(ObjDt)
                    dv.RowFilter = "sizeid=" & grdBrand.Item("sizeid", rwctr).Value
                    If dv.Count > 0 Then
                        grdBrand.Item("boxqty", rwctr).Value = dv(0)("BoxQty")
                        grdBrand.Item("purrate", rwctr).Value = dv(0)("PurchaseRate")
                    End If
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
#End Region

    Private Sub frmBrand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        ClrScr()
        BindCategory()
        BindBrand(0)


    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged, cmbCategory.SelectedValueChanged
        If Not TypeOf cmbCategory.SelectedValue Is Decimal Or chk Then
            Exit Sub
            grdBrand.Rows.Clear()
        End If

        FetchCategorySizes()
        FetchSubCategory()
    End Sub

    Private Sub cmbBrand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrand.SelectedIndexChanged, cmbBrand.SelectedValueChanged
        If Not TypeOf cmbBrand.SelectedValue Is Decimal Or chk Then
            Exit Sub
        End If
        lblID.Text = Trim(cmbBrand.SelectedValue)
        BindBrand(Trim(cmbBrand.SelectedValue))
    End Sub
    Private Sub cmbbrand_lostfocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrand.TextChanged
        'txtShortname.Clear()
        'cmbCategory.Enabled = True
        'FetchSubCategory()
        ' '' cmbCategory.SelectedValue = 0
        'txtStrength.Text = 0
        'txtPurRatePeg.Text = 0
        'grdBrand.Rows.Clear()
    End Sub

    'Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
    '    Dim str As DialogResult = MsgBox("Are You Sure Want to Delete?", MsgBoxStyle.YesNo, "Brand")
    '    If str = vbNo Then
    '        Exit Sub
    '    End If
    '    delete()
    'End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        cmbCategory.Enabled = True
    End Sub

    Public Sub FetchSubCategory()
        Dim ObjSubCategory As New ClsSubCategoryMaster
        Dim dt As New DataTable
        Try
            ObjSubCategory.CategoryID = cmbCategory.SelectedValue
            dt = ObjSubCategory.FunFetchSubCategoryMaster

            cmbSubCategory.DataSource = Nothing
            ComboBindingTemplate(cmbSubCategory, dt, "SubCategoryName", "SubCategoryid")

            'FetchSelectValues()

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(ObjCategory) Then
                ObjCategory = Nothing
            End If
            If Not IsNothing(dt) Then
                dt = Nothing
            End If
        End Try

    End Sub

    Public Sub FetchSelectValues()
        Dim ObjSubCategory As New ClsSubCategoryMaster
        Dim ObjDt As New DataTable
        Try
            ObjSubCategory.CategoryID = cmbCategory.SelectedValue
            ObjDt = ObjSubCategory.FunFetchSubCategoryMaster
            If ObjDt.Rows.Count > 0 Then
                cmbSubCategory.SelectedValue = ObjDt.Rows(0).Item("SubCategoryID").ToString()
            End If



        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(ObjCategory) Then
                ObjCategory = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
       Save() 
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
       
        delete()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub txtStrength_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStrength.KeyPress, txtPurRatePeg.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If


    End Sub

    Private Sub ChkBDisable_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkBDisable.CheckedChanged

    End Sub
End Class