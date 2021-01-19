Imports System.Xml
Public Class frmAssignMMSBrandCode
    Dim ObjCategorySizeLnkUp As CWPlusBL.Master.ClsCategorySizelinlup
    Dim ObjBrand As CWPlusBL.Master.ClsBrandHeadDet
    Dim ObjAssignBrand As CWPlusBL.Master.ClsAssignMMSCode
    Dim ObjDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(GroupBox1)
    End Sub

#Region "Procedures"

    Private Sub ClrScr()
        cmbBrandName.Text = ""
        cmbBrandName.SelectedValue = -1
        txtbottle.Clear()
        txtspeg.Clear()
        txtlpeg.Clear()

    End Sub

    Private Function GenerateXML() As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Master><AssignBrandCode></AssignBrandCode></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("AssignBrandCodeDet")




        If Trim(txtbottle.Text) <> "" Then
            XmlElt = xmldoc.CreateElement("AssignBrandCodeDet")
            XmlElt.SetAttribute("BrandCode", txtbottle.Text)
            XmlElt.SetAttribute("TypeID", 1)
            xmldoc.DocumentElement.Item("AssignBrandCode").AppendChild(XmlElt)
        End If

        If Trim(txtspeg.Text) <> "" Then
            XmlElt = xmldoc.CreateElement("AssignBrandCodeDet")
            XmlElt.SetAttribute("BrandCode", txtspeg.Text)
            XmlElt.SetAttribute("TypeID", 2)
            xmldoc.DocumentElement.Item("AssignBrandCode").AppendChild(XmlElt)
        End If

        If Trim(txtlpeg.Text) <> "" Then
            XmlElt = xmldoc.CreateElement("AssignBrandCodeDet")
            XmlElt.SetAttribute("BrandCode", txtlpeg.Text)
            XmlElt.SetAttribute("TypeID", 3)
            xmldoc.DocumentElement.Item("AssignBrandCode").AppendChild(XmlElt)
        End If
        Return xmldoc
    End Function

    'Public Sub BindBrand(ByVal BrandID As Double)
    '    Try

    '        ObjBrand = New CWPlusBL.Master.ClsBrandHeadDet
    '        ObjDt = New DataTable
    '        ObjBrand.BrandID = BrandID
    '        ObjDt = ObjBrand.FunFetch
    '        If Not ObjDt.Rows.Count > 0 Then
    '            Exit Sub
    '        End If
    '        If BrandID = 0 Then
    '            ComboBindingTemplate(cmbBrandName, ObjDt, "dispfield", "valuefield")

    '        Else
    '            FetchCategorySizeLinkUp(ObjDt.Rows(0)("categoryid"))
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        If Not IsNothing(ObjCategorySizeLnkUp) Then
    '            ObjCategorySizeLnkUp = Nothing
    '        End If
    '        If Not IsNothing(ObjDt) Then
    '            ObjDt = Nothing
    '        End If
    '    End Try
    'End Sub

    Public Sub BindBrand(ByVal BrandOpeningID As Double)

        Dim Objpurchase = New CWPlusBL.Master.Clspurchase
        ObjDt = New DataTable
        Try
            Objpurchase.BrandopeningID = BrandOpeningID
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDt = Objpurchase.BindBrandOpening
            If Not ObjDt.Rows.Count > 0 Then
                Exit Sub
            End If
            ComboBindingTemplate(cmbBrandName, ObjDt, "BrandDesc", "BrandID")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    'Public Sub BindBrand(ByVal BrandOpeningID As Double)

    '    Dim Objpurchase = New CWPlusBL.Master.Clspurchase
    '    ObjDt = New DataTable
    '    Try
    '        Objpurchase.BrandopeningID = BrandOpeningID
    '        Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
    '        ObjDt = Objpurchase.BindBrandOpening
    '        If Not ObjDt.Rows.Count > 0 Then
    '            Exit Sub
    '        End If
    '        ComboBindingTemplate(cmbBrandName, ObjDt, "BrandDesc", "BrandID")

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        If Not IsNothing(Objpurchase) Then
    '            Objpurchase = Nothing
    '        End If
    '        If Not IsNothing(ObjDt) Then
    '            ObjDt = Nothing
    '        End If
    '    End Try
    'End Sub

    Private Sub FetchCategorySizeLinkUp(ByVal CategoryID As Double)
        Try
            ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
            ObjDt = New DataTable
            ObjCategorySizeLnkUp.CategoryID = CategoryID
            ObjCategorySizeLnkUp.LicenseID = MDI.cmbLicenseName.SelectedValue

            ObjDt = ObjCategorySizeLnkUp.FunFetch
            cmbSize.DataSource = Nothing

            ComboBindingTemplate(cmbSize, ObjDt, "alias", "CategorySizeLinkID")


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

    Public Function IsBlank() As Boolean
        IsBlank = False
        If txtbottle.Text = "" And txtlpeg.Text = "" And txtspeg.Text = "" Then
            MsgBox("Nothing To Save", MsgBoxStyle.Critical, "Brand Code")
            Return False
        Else
            Dim btCode As String = IIf(txtbottle.Text = "", "bt", txtbottle.Text)
            Dim lpegCode As String = IIf(txtlpeg.Text = "", "lp", txtlpeg.Text)
            Dim spegCode As String = IIf(txtspeg.Text = "", "sp", txtspeg.Text)
            If btCode = lpegCode Or btCode = spegCode Or lpegCode = spegCode Then
                MsgBox("Duplicate Code", MsgBoxStyle.Critical, "Duplicate")
                Return False
            Else
                Return True
            End If
        End If

    End Function

    'Private Sub BindSize(ByVal brandid As Double)
    '    Objpurchase = New CWPlusBL.Master.Clspurchase
    '    ds = New DataSet
    '    Try

    '        Objpurchase.BrandID = cmbBrand.SelectedValue
    '        Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
    '        ds = Objpurchase.BindSizes
    '        ComboBindingTemplate(cmbSize, ds.Tables(0), "alias", "CategorySizeLinkUpID")

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        If Not IsNothing(Objpurchase) Then
    '            Objpurchase = Nothing
    '        End If
    '        If Not IsNothing(objdt) Then
    '            objdt = Nothing
    '        End If
    '    End Try
    'End Sub

    Public Function Save() As Boolean
        Save = False
        If lblassignbrandcodeid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Assign Brand Code")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Assign Brand Code")
                Exit Function
            End If
        End If
        If LCase(MDI.cmdMultiSelect.Text) = "s" And MDI.chkLicenseName.CheckedItems.Count = 0 Then
            MsgBox("Select License Name.", MsgBoxStyle.Critical, "Brand Code")
            Exit Function
            'End If
            'If MDI.cmbLicenseName.Text = "" Then
            '    MsgBox("Enter License Name", MsgBoxStyle.Critical, "Brand Code")
            '    MDI.cmbLicenseName.Focus()
            '    Exit Function

        ElseIf cmbSize.Text = "" Then
            MsgBox("Select Size", MsgBoxStyle.Critical, "Brand Code")
            Exit Function

        ElseIf cmbSize.SelectedValue = 0 Then
            MsgBox("Please Select Size")
            Exit Function

        ElseIf IsBlank() Then

            Try
                ' gblArrMDICheckedLicense.Clear()
                'For chkCtr = 0 To MDI.chkLicenseName.CheckedItems.Count - 1
                '    If Not DirectCast(MDI.chkLicenseName.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0) = 0 Then
                ' ObjAssignBrand.LicenseID = DirectCast(MDI.chkLicenseName.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0)
                If gblArrMDICheckedLicense.Count > 0 Then
                    For cntr = 0 To gblArrMDICheckedLicense.Count - 1

                        ObjAssignBrand = New CWPlusBL.Master.ClsAssignMMSCode
                        'ObjAssignBrand.AssignBrandCodeID = cmbBrandName.SelectedValue
                        If lblassignbrandcodeid.Text <> "" Then
                            ObjAssignBrand.MMSCode = lblassignbrandcodeid.Text
                        Else
                            ObjAssignBrand.MMSCode = 0
                        End If
                        ObjAssignBrand.BrandID = cmbBrandName.SelectedValue
                        ObjAssignBrand.CategorySizeLinkID = cmbSize.SelectedValue
                        If LTrim(RTrim(txtbottle.Text)) <> "" Then
                            ObjAssignBrand.TypeID = 1
                        ElseIf txtlpeg.Text <> "" Then
                            ObjAssignBrand.TypeID = 3
                        ElseIf txtspeg.Text <> "" Then
                            ObjAssignBrand.TypeID = 2
                        Else
                            ObjAssignBrand.TypeID = 0
                        End If
                        ObjAssignBrand.LicenseID = gblArrMDICheckedLicense.Item(cntr)
                        ObjAssignBrand.AssignBrandCodeXML = GenerateXML()
                        ObjAssignBrand.UserName = gblUserName
                        Save = ObjAssignBrand.FunSave
                    Next
                    MsgBox(ObjAssignBrand.ErrorMsg)
                End If
                cmbSize.SelectedValue = -1
                txtbottle.Clear()
                txtlpeg.Clear()
                txtspeg.Clear()
                lblassignbrandcodeid.Text = 0
                FetchAssignBrandCode()
                BindBrand(0)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Not IsNothing(ObjCategorySizeLnkUp) Then
                    ObjCategorySizeLnkUp = Nothing
                End If
            End Try
        End If



    End Function

    Public Sub FetchAssignBrandCode()
        Try
            ObjAssignBrand = New CWPlusBL.Master.ClsAssignMMSCode
            ObjDt = New DataTable
            ObjAssignBrand.BrandID = lblassignbrandcodeid.Text
            ObjAssignBrand.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjAssignBrand.AssignBrandCodeID = cmbBrandName.SelectedValue
            ObjDt = ObjAssignBrand.FunFetch
            grdAssignBrandCode.DataSource = ObjDt
            grdAssignBrandCode.AutoResizeColumns()
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
        'grdAssignBrandCode.Columns("MMSCodeID").Visible = False
        grdAssignBrandCode.Columns("BrandID").Visible = False
        grdAssignBrandCode.Columns("typeid").Visible = False
        grdAssignBrandCode.Columns("SizeID").Visible = False
        grdAssignBrandCode.Columns("LicenseID").Visible = False
        'grdAssignBrandCode.Columns("Alias").HeaderText = "Size"
    End Sub

#End Region

    Private Sub frmAssignBrandCode_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MDI.chkLicenseName.Visible = False
        For rctr = 0 To MDI.chkLicenseName.Items.Count - 1
            MDI.chkLicenseName.SetItemChecked(rctr, False)
        Next
    End Sub

    Private Sub frmAssignBrandCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        For rctr = 0 To MDI.chkLicenseName.Items.Count - 1
            MDI.chkLicenseName.SetItemChecked(rctr, False)
        Next
        BindBrand(0)
        'BindType()

    End Sub

    Private Sub cmbBrandName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrandName.SelectedIndexChanged
        If Not TypeOf cmbBrandName.SelectedValue Is Decimal Then
            Exit Sub
        End If
        ' BindBrand(cmbBrandName.SelectedValue)
        BindSize(cmbBrandName.SelectedValue)
        FetchAssignBrandCode()

    End Sub

    Private Sub BindSize(ByVal brandid As Double)
        Dim Objpurchase = New CWPlusBL.Master.Clspurchase
        Dim ds = New DataSet
        Try

            Objpurchase.BrandID = cmbBrandName.SelectedValue
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            ds = Objpurchase.BindSizes
            cmbSize.DataSource = Nothing
            ComboBindingTemplate(cmbSize, ds.Tables(0), "alias", "SizeID")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try

    End Sub
    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    If cmbType.Text = "--Select--" Then
    '        MsgBox("Select Type", MsgBoxStyle.Critical, "Brand Code")
    '        cmbType.Focus()
    '        Exit Sub
    '    ElseIf Not TypeOf cmbBrandName.SelectedValue Is Decimal Then
    '        MsgBox("Select Brand", MsgBoxStyle.Critical, "Brand Code")
    '        cmbBrandName.Focus()
    '        Exit Sub
    '    ElseIf Not TypeOf cmbSize.SelectedValue Is Decimal Then
    '        MsgBox("Select Size", MsgBoxStyle.Critical, "Brand Code")
    '        cmbSize.Focus()
    '        Exit Sub
    '    ElseIf txtCode.Text = "" Then
    '        MsgBox("Enter Code", MsgBoxStyle.Critical, "Brand Code")
    '        txtCode.Focus()
    '        Exit Sub
    '    End If

    '    For i = 0 To grdAssignBrandCode.RowCount - 1
    '        If grdAssignBrandCode.Item("code", i).Value = txtCode.Text Then
    '            MsgBox("Duplicate code", MsgBoxStyle.Critical, "Duplicate")
    '            Exit Sub
    '        End If
    '    Next
    '    grdAssignBrandCode.Rows.Add(Nothing, Nothing, cmbBrandName.SelectedValue, cmbBrandName.Text, cmbSize.SelectedValue, cmbSize.Text, cmbType.SelectedValue, cmbType.Text, txtCode.Text)
    '    cmbType.Text = "--Select--"
    '    txtCode.Clear()
    'End Sub
    Private Sub grdAssignBrandCode_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAssignBrandCode.CellContentClick
        txtbottle.Clear()
        txtlpeg.Clear()
        txtspeg.Clear()
        If e.ColumnIndex = 0 Then
            If Not GblBoolDelete Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Assign Brand Code")
                Exit Sub
            End If
            If (MDI.cmbLicenseName.Text = "") Then
                MsgBox("Please Select License Name", MsgBoxStyle.Critical, "Assign Brand Code")
                MDI.cmbLicenseName.Focus()
                Exit Sub
            End If
            Dim Ans As String = MsgBox("Are You Sure Want to Delete", MsgBoxStyle.YesNo, "Assign Brand Code")
            If Ans = vbNo Then
                Exit Sub
            End If

            Try
                ObjAssignBrand = New CWPlusBL.Master.ClsAssignMMSCode
                ObjAssignBrand.AssignBrandCodeID = grdAssignBrandCode.Item("MMsCodeID", e.RowIndex).Value
                ObjAssignBrand.LicenseID = MDI.cmbLicenseName.SelectedValue
                'ObjAssignBrand.UserName = gblUserName
                Dim vijay As String = ObjAssignBrand.FunDelete
                MsgBox(ObjAssignBrand.ErrorMsg)
                'ClrScr()
                FetchAssignBrandCode()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Not IsNothing(ObjAssignBrand) Then
                    ObjAssignBrand = Nothing
                End If
            End Try
        ElseIf e.ColumnIndex = 1 Then
            ObjAssignBrand = New CWPlusBL.Master.ClsAssignMMSCode
            ObjDt = New DataTable

            'ObjAssignBrand.BrandID = lblassignbrandcodeid.Text
            'ObjAssignBrand.LicenseID = MDI.cmbLicenseName.SelectedValue
            'ObjAssignBrand.AssignBrandCodeID = cmbBrandName.SelectedValue
            ObjAssignBrand.BrandID = grdAssignBrandCode.Item("MMSCodeID", e.RowIndex).Value
            ObjAssignBrand.AssignBrandCodeID = grdAssignBrandCode.Item("BrandID", e.RowIndex).Value
            ObjAssignBrand.LicenseID = grdAssignBrandCode.Item("LicenseID", e.RowIndex).Value

            ObjDt = ObjAssignBrand.FunFetch
            'grdAssignBrandCode.DataSource = ObjDt
            If ObjDt.Rows.Count > 0 Then
                cmbBrandName.SelectedValue = ObjDt.Rows(0).Item("BrandId")
                cmbSize.SelectedValue = ObjDt.Rows(0).Item("SizeID")
                If ObjDt.Rows(0).Item("TypeID") = 1 Then
                    txtbottle.Text = ObjDt.Rows(0).Item("MMSBrandcode")
                ElseIf ObjDt.Rows(0).Item("TypeID") = 2 Then
                    txtspeg.Text = ObjDt.Rows(0).Item("MMSBrandcode")
                ElseIf ObjDt.Rows(0).Item("TypeID") = 3 Then
                    txtlpeg.Text = ObjDt.Rows(0).Item("MMSBrandcode")
                End If
                lblassignbrandcodeid.Text = grdAssignBrandCode.Item("MMSCodeID", e.RowIndex).Value
            End If


        End If
    End Sub

    Public Sub SaveCheck()
        If Save() = True Then
            For rctr = 0 To MDI.chkLicenseName.Items.Count - 1
                MDI.chkLicenseName.SetItemChecked(rctr, False)
            Next

        End If
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        SaveCheck()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    'Private Sub txtbottle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbottle.KeyPress, txtlpeg.KeyPress, txtspeg.KeyPress
    '    If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
    '      Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
    '        e.Handled = True
    '    End If
    '    If Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
    '        e.Handled = False
    '    End If
    'End Sub
    
End Class