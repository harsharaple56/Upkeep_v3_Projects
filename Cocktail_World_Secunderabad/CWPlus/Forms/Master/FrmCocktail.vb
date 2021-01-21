Imports System.Xml
Public Class FrmCocktail
    Dim Objcocktail As CWPlusBL.Master.Clscocktail
    Dim Objpurchase As CWPlusBL.Master.Clspurchase
    Dim ObjCategorySizeLnkUp As CWPlusBL.Master.ClsCategorySizelinlup
    Dim ObjDt As DataTable
    Dim ObjBrand As CWPlusBL.Master.ClsBrandHeadDet
    Dim ds As DataSet
    Dim ObjAssignctcode As CWPlusBL.Master.AssignCocktailCode
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AddTheme(GroupBox1)
    End Sub
    Public Sub Clrscr()
        cmbcocktail.SelectedValue = -1
        txtrate.Text = "0"
        cmbbrand.SelectedValue = -1
        cmbsize.SelectedValue = -1
        txtpeg.Clear()
    End Sub
    
    'Public Sub BindBrand(ByVal BrandOpeningID As Double)
    '    Try
    '        Objpurchase = New CWPlusBL.Master.Clspurchase
    '        objdt = New DataTable
    '        Objpurchase.BrandopeningID = BrandopeningId
    '        objdt = Objpurchase.BindBrandOpening
    '        If Not objdt.Rows.Count > 0 Then
    '            Exit Sub
    '        End If

    '        With cmbbrand
    '            .DataSource = ObjDt
    '            .ValueMember = "brandid"
    '            .DisplayMember = "BrandDesc"
    '            .SelectedIndex = -1
    '        End With


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
    Public Sub BindBrand(ByVal BrandOpeningID As Double)
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable
            Objpurchase.BrandopeningID = BrandOpeningID
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
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
            cmbsize.DataSource = Nothing
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
    Public Sub FetchCocktail()
        If gblArrMDICheckedLicense.Item(0) = 0 Then
            grdcocktail.Rows.Clear()
            Exit Sub
        End If

        grdcocktail.Rows.Clear()
        Objcocktail = New CWPlusBL.Master.Clscocktail
        ObjDt = New DataTable
        Objcocktail.CocktailId = cmbcocktail.SelectedValue
        Objcocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
        ObjDt = Objcocktail.FunFetch
        If ObjDt.Rows.Count > 0 Then
            grdcocktail.Rows.Clear()
            For rwctr = 0 To ObjDt.Rows.Count - 1
                grdcocktail.Rows.Add()
                txtrate.Text = ObjDt.Rows(rwctr)("Rate")
                grdcocktail.Item("Brandid", rwctr).Value = ObjDt.Rows(rwctr)("BrandId")
                grdcocktail.Item("BrandName", rwctr).Value = ObjDt.Rows(rwctr)("branddesc")
                grdcocktail.Item("SizeId", rwctr).Value = ObjDt.Rows(rwctr)("CategorysizelinkID")
                grdcocktail.Item("Size", rwctr).Value = ObjDt.Rows(rwctr)("Alias")
                grdcocktail.Item("peg", rwctr).Value = ObjDt.Rows(rwctr)("Speg")
            Next
        End If

    End Sub
   
    Public Function Save() As Boolean
        Save = False
        If (cmbcocktail.Text = "") Then
            MsgBox("Please Select/Enter Cocktail Name", MsgBoxStyle.Critical, "cocktail")
            cmbcocktail.Focus()
            Exit Function
        End If
        If (MDI.cmbLicenseName.Text = "") Then
            MsgBox("Please Select License Name", MsgBoxStyle.Critical, "cocktail")
            MDI.cmbLicenseName.Focus()
            Exit Function
        End If
        If grdcocktail.RowCount = 0 Then
            MsgBox("Noting to Save", MsgBoxStyle.Critical, "Cocktail")
            Exit Function
        End If
        Try
            'gblArrMDICheckedLicense.Clear()

            If gblArrMDICheckedLicense.Count > 0 Then
                For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                    Objcocktail = New CWPlusBL.Master.Clscocktail
                    Objcocktail.CocktailId = cmbcocktail.SelectedValue
                    Objcocktail.CocktailName = cmbcocktail.Text
                    Objcocktail.LicenseID = gblArrMDICheckedLicense.Item(cntr)
                    Objcocktail.rate = IIf(txtrate.Text = "", 0, txtrate.Text)
                    Objcocktail.CocktailXML = GenerateXML()
                    Objcocktail.UserName = gblUserName
                    Save = Objcocktail.FunSave
                Next
                MsgBox(Objcocktail.ErrorMsg)
            End If

            'Objcocktail = New CWPlusBL.Master.Clscocktail
            'Objcocktail.CocktailId = cmbcocktail.SelectedValue
            'Objcocktail.CocktailName = cmbcocktail.Text
            'Objcocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
            'Objcocktail.rate = IIf(txtrate.Text = "", 0, txtrate.Text)
            'Objcocktail.CocktailXML = GenerateXML()
            'Save = Objcocktail.FunSave
            ' MsgBox(Objcocktail.ErrorMsg)
            Clrscr()
            grdcocktail.Rows.Clear()
            'txtrate.Text = "0"
            'cmbbrand.SelectedValue = -1
            'cmbsize.SelectedValue = -1
            'txtpeg.Clear()
            BindCombo()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objcocktail) Then
                Objcocktail = Nothing
            End If
        End Try
    End Function
    Public Function FunDelete() As Boolean
        FunDelete = False
        If GblBoolDelete = False Then
            MsgBox("Access Denied")
            Exit Function
        End If
        Dim Ans As String = MsgBox("Are You Sure Want To Delete", MsgBoxStyle.YesNo, "Delete")
        If Ans = vbNo Then
            Exit Function
        End If
        If (cmbcocktail.Text = "") Then
            MsgBox("Please Select Cocktail Name", MsgBoxStyle.Critical, "cocktail")
            cmbcocktail.Focus()
            Exit Function
        ElseIf (MDI.cmbLicenseName.Text = "") Then
            MsgBox("Please Select License Name", MsgBoxStyle.Critical, "cocktail")
            MDI.cmbLicenseName.Focus()
            Exit Function
        End If

        Try
            Objcocktail = New CWPlusBL.Master.Clscocktail
            Objcocktail.CocktailId = cmbcocktail.SelectedValue
            Objcocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
            Objcocktail.UserName = gblUserName
            Dim str As String = Objcocktail.FunDelete
            MsgBox(Objcocktail.ErrorMsg)
            Clrscr()
            BindCombo()
            grdcocktail.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objcocktail) Then
                Objcocktail = Nothing
            End If
        End Try
    End Function
    Public Sub BindCombo()
        Try
            ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
            ds = New DataSet
            ObjAssignctcode.AssigncocktailcodeId = cmbcocktail.SelectedValue
            ds = ObjAssignctcode.FetchAssigncocktail
            With cmbcocktail
                .DataSource = ds.Tables(0)
                .DisplayMember = "Cocktailname"
                .ValueMember = "CocktailId"
                .SelectedValue = -1
                .Text = ""
            End With
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

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><CatgSizeLnk></CatgSizeLnk></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("CatgSize")
        For index = 0 To grdcocktail.RowCount - 1
            XmlElt = xmldoc.CreateElement("CatgSize")
            XmlElt.SetAttribute("brandid", grdcocktail.Item("BrandID", index).Value)
            XmlElt.SetAttribute("categorysizelinkId", grdcocktail.Item("sizeId", index).Value)
            XmlElt.SetAttribute("Speg", grdcocktail.Item("peg", index).Value)
            xmldoc.DocumentElement.Item("CatgSizeLnk").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function

    Private Sub FrmCocktail_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MDI.chkLicenseName.Visible = False
        For rctr = 0 To MDI.chkLicenseName.Items.Count - 1
            MDI.chkLicenseName.SetItemChecked(rctr, False)
        Next

    End Sub
    Private Sub FrmCocktail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        For rctr = 0 To MDI.chkLicenseName.Items.Count - 1
            MDI.chkLicenseName.SetItemChecked(rctr, False)
        Next

        BindCombo()
        BindBrand(0)
        Dim toolTip1 As New ToolTip()
        toolTip1.ShowAlways = True
        toolTip1.IsBalloon = True
        toolTip1.SetToolTip(btnAdd, "Add Rows To Grid.")

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, AddToolStripMenuItem1.Click
        If Not TypeOf (cmbbrand.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf (cmbsize.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If (txtpeg.Text = "") Then
            MsgBox("Enter ML/Peg", MsgBoxStyle.Critical, "Cocktail")
            txtpeg.Focus()
            Exit Sub
        End If
        Objpurchase = New CWPlusBL.Master.Clspurchase
        ObjDt = New DataTable
        Objpurchase.BrandID = cmbbrand.SelectedValue
        Objpurchase.CategorySizeLinkID = cmbsize.SelectedValue
        ObjDt = Objpurchase.BindPurchaseRate

        grdcocktail.Rows.Add(Nothing, ObjDt.Rows(0).Item("brandopeningID"), cmbbrand.Text, cmbsize.SelectedValue, cmbsize.Text, txtpeg.Text)
        cmbbrand.SelectedValue = -1
        cmbsize.SelectedValue = -1
        txtpeg.Clear()
    End Sub

    Private Sub cmbbrand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbrand.SelectedIndexChanged
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf (cmbbrand.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        BindSize(cmbbrand.SelectedValue)
    End Sub

    Private Sub cmbcocktail_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcocktail.SelectedIndexChanged
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf (cmbcocktail.SelectedValue) Is Decimal Then
            Exit Sub
        End If

        If gblArrMDICheckedLicense.Item(0) = 0 Then
            grdcocktail.Rows.Clear()
            Exit Sub
        End If
        FetchCocktail()
    End Sub

    Private Sub cmbcocktail_SelectedIndexChang(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcocktail.TextChanged
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        grdcocktail.Rows.Clear()
        cmbbrand.SelectedIndex = -1
        cmbsize.Text = ""
        txtpeg.Clear()
        txtrate.Clear()
    End Sub


    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim Ans As String = MsgBox("Are You Sure Want To Delete", MsgBoxStyle.YesNo, "Delete")
        'If Ans = vbNo Then
        '    Exit Sub
        'End If
        'FunDelete()
    End Sub

    Private Sub grdcocktail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcocktail.CellContentClick

        If e.ColumnIndex = 0 Then
            If Not GblBoolDelete Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Cocktail")
                Exit Sub
            End If
            Dim Ans As String = MsgBox("Are You Sure Want To Remove", MsgBoxStyle.YesNo, "Cocktail")
            If Ans = vbNo Then
                Exit Sub
            End If
            grdcocktail.Rows.Remove(grdcocktail.CurrentRow)
        End If
    End Sub

    Public Sub SaveCheck()
        If GblBoolNew = False Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Cocktail")
            Exit Sub
        End If
        If MDI.cmbLicenseName.SelectedValue = "0" Then
            MsgBox("Please Select License")
            Exit Sub
        End If

        gblArrMDICheckedLicense.Clear()
        FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

        If gblArrMDICheckedLicense.Count > 0 Then
            Save()
            For rctr = 0 To MDI.chkLicenseName.Items.Count - 1
                MDI.chkLicenseName.SetItemChecked(rctr, False)
            Next
        Else
            MsgBox("Please Select License")
        End If
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click, SaveToolStripMenuItem.Click
        SaveCheck()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click

        FunDelete()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
          Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If

        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
    End Sub

End Class