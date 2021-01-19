Imports System.Windows.Forms
Imports CWPlusBL.Master
Imports System.Data.SqlClient
Imports System.Configuration

Public Class MDI
    Dim objlicense As CWPlusBL.Master.Utitity
    Dim objDt As DataTable
#Region "Custom Functions"
    Public Sub setToolStripIcons()
        NewToolStripButton.Image = imgToolStrip.Images(0)
        SaveToolStripButton.Image = imgToolStrip.Images(1)
        PrintToolStripButton.Image = imgToolStrip.Images(2)
        PrintPreviewToolStripButton.Image = imgToolStrip.Images(3)
    End Sub
#End Region

    Private Sub BindLicense()
        Try
            ' objlicense.UserID = gblUserID
            objlicense = New CWPlusBL.Master.Utitity
            objDt = New DataTable
            objlicense.UserID = gblUserID
            objDt = objlicense.FunFetchLicenseByRights

            Dim tmpDt As New DataTable
            tmpDt = objDt.Copy

            cmbLicenseName.DataSource = Nothing
            ComboBindingTemplate(cmbLicenseName, tmpDt, "LicenseDesc", "LicenseID")


            'With cmbLicenseName
            '    .DisplayMember = "LicenseDesc"
            '    .ValueMember = "LicenseID"
            '    .DataSource = objDt
            '    .SelectedValue = -1
            'End With

            Dim chkDt As New DataTable
            chkDt = objDt.Copy
            Dim dr As DataRow
            dr = chkDt.NewRow
            dr("LicenseDesc") = "Select All"
            dr("LicenseID") = 0
            chkDt.Rows.InsertAt(dr, 0)

            'For i = 0 To objDt.Rows.Count - 1
            '    chkLicenseName.Items.Add(objDt.Rows(i).Item("LicenseDesc"))
            'Next
            With chkLicenseName
                .DataSource = chkDt
                .DisplayMember = "LicenseDesc"
                .ValueMember = "LicenseID"
            End With


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(objlicense) Then
                objlicense = Nothing
            End If
            If Not IsNothing(objDt) Then
                objDt = Nothing
            End If
        End Try


    End Sub

    Public Sub CenterLoginContainer()
        Dim vwidth As Integer = 336
        Dim vheight As Integer = 192 + 148
        Dim vleft As Integer = Integer.Parse((Me.Width / 2) - (vwidth / 2))
        Dim vtop As Integer = Integer.Parse((Me.Height / 2) - (vheight / 2))
        pnlLoginContainer.Left = vleft
        pnlLoginContainer.Top = vtop
    End Sub

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.

        If Not IsNothing(Me.ActiveMdiChild) Then
            Me.ActiveMdiChild.Close()
        End If

        OpenForm(tvMenu.SelectedNode)
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

#Region "Window Style"

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

#End Region

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub


    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.AcceptButton = cmdLogin
        'set the imagelist to treeview
        tvMenu.ImageList = imgTreeMenu
        txtUsername.Focus()
        CenterLoginContainer()
        setToolStripIcons()
        HideMenuToolStripMenuItem.PerformClick()
        FillUserPass()
        '  BindLicense()
    End Sub


    Private Sub tvMenu_AfterCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMenu.AfterCollapse
        If e.Node.ImageIndex = 4 Then
            Exit Sub
        End If

        e.Node.ImageIndex = 0
        e.Node.SelectedImageIndex = 0
    End Sub

    Private Sub tvMenu_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMenu.AfterExpand
        If e.Node.ImageIndex = 4 Then
            Exit Sub
        End If


        e.Node.ImageIndex = 1
        e.Node.SelectedImageIndex = 1
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles SaveToolStripButton.Click, SaveToolStripMenuItem.Click
        Dim ActiveMDI As Form = Me.ActiveMdiChild

        If Not IsNothing(ActiveMDI) Then
            Select Case LCase(ActiveMDI.Name)

                Case "frmsupplier"
                    frmSupplier.Save()
                Case "frmsize"
                    FrmSize.Save()
                Case "frmcategorysizelinlup"
                    FrmCategorySizelinlup.Savecheck()
                Case "frmcategory"
                    FrmCategory.SaveCategory()
                Case "frmcategorytax"
                    FrmCategoryTax.Save()
                Case "frmss_permittypemaster"
                    FrmSS_PermitTypeMaster.SaveCheck()
                Case "frmpermitholdermaster"
                    FrmPermitHolderMaster.SaveCheck()
                Case "frmusermaster"
                    FrmUserMaster.Save()
                Case "frmassignbrandcode"
                    frmAssignBrandCode.SaveCheck()
                Case "frmbrand"
                    frmBrand.Save()
                Case "frmbrandopening"
                    frmBrandOpening.SaveCheck()
                Case "frmusermenurights"
                    FrmUserMenuRights.Save()
                Case "frmcocktail"
                    FrmCocktail.SaveCheck()
                Case "frmassigncocktailcode"
                    FrmAssignCocktailCode.SaveCheck()
                Case "frmpurchasemst"
                    FrmpurchaseMst.Save()
                Case "frmuserlicense"
                    FrmUserLicense.Save()
                Case "frmbillbook"
                    FrmBillBook.Save()
                Case "frminterfacefilesetup"
                    FrmInterfaceFileSetUp.Save()
                Case "frmtransfer"
                    FrmTransfer.SaveCheck()
                Case "frmsalemst"
                    FrmSaleMst.Save()
                Case "frmconsumption"
                    FrmConsumption.Save()
                Case "frm_subcategorymaster"
                    Frm_SubCategoryMaster.Save()
               Case "frminterfacefilesale"
                    frmInterFaceFileSale.Save()
                Case "frmlicenselist"
                    FrmLicenseList.Save()
                Case "frmparameter"
                    FrmParameter.Save()
                Case "frmdeptmaster"
                    frmDeptMaster.Save()
                Case "frmdesignation"
                    frmDesignation.Save()
                Case "frmsavedrr"
                    FrmSaveDRR.Save()
                Case Else

            End Select

        End If


    End Sub


    Public Sub FillUserPass()
        If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Cwpluslogin.txt") Then
            Dim strUserDet() As String = IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Cwpluslogin.txt")
            txtUsername.Text = strUserDet(0)
            txtPass.Text = strUserDet(1)
            chkRemember.Checked = True
        End If
    End Sub


    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        If txtUsername.Text = "" And txtPass.Text = "" Then
            MsgBox("Enter User Name and Password")
            Exit Sub
        Else
            If Not ValidateLogin() Then
                MsgBox("Incorrect Login")
                Exit Sub
            End If

        End If

        If chkRemember.Checked Then
            IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Cwpluslogin.txt", txtUsername.Text & vbCrLf & txtPass.Text)
        Else
            If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Cwpluslogin.txt") Then IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Cwpluslogin.txt")
        End If
        pnlLoginContainer.Visible = False
        GetAllowedmenus()
        Panel1.Visible = False
        HideMenuToolStripMenuItem.PerformClick()
        BindLicense()
        Dim ChildForm As New Form
        ChildForm = Dashboard
        ChildForm.MdiParent = Me
        ChildForm.Show()
        'If Not ChildForm.WindowState = FormWindowState.Maximized Then
        ChildForm.WindowState = FormWindowState.Maximized
        'End If
    End Sub

    Public Function ValidateLogin() As Boolean
        ValidateLogin = False
        Dim ObjDtLogin As New ClsUserMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjDtLogin.UserName = Trim(txtUsername.Text)
            ObjDtLogin.gloPassword = Trim(txtPass.Text)
            ObjPriDt = ObjDtLogin.funValidate()
            If ObjPriDt.Rows.Count > 0 Then
                gblUserID = ObjPriDt.Rows(0).Item("UserID").ToString()
                gblUserName = ObjPriDt.Rows(0).Item("User").ToString()

                If txtUsername.Text = ObjPriDt.Rows(0).Item("User").ToString() And txtPass.Text = ObjPriDt.Rows(0).Item("Password").ToString() Then
                    If ObjPriDt.Columns.Count > 3 Then
                        StatusBarVersion.Text = ObjPriDt.Rows(0).Item("Version").ToString()
                    End If
                    Return True
                End If

                ' gblsaveUserName = ObjDtLogin.UserName
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtLogin) Then
                ObjDtLogin = Nothing
            End If
            If Not IsNothing(ObjPriDt) Then
                ObjPriDt = Nothing
            End If
        End Try
    End Function

    'Public Sub GetAllowedmenus()
    '    tvMenu.Nodes.Clear()
    '    Dim CurMasterID As Long
    '    '###### FETCH MENU LIST ######################
    '    Dim objMenu As New Utitity

    '    objMenu.UserID = gblUserID
    '    Dim dt As DataTable = objMenu.FunFetchmenu()

    '    For dtRow = 0 To dt.Rows.Count - 1
    '        If IsDBNull(dt.Rows(dtRow)("ParentMenuID")) Then
    '            CurMasterID = dt.Rows(dtRow)("MenuID")
    '            tvMenu.Nodes.Add(CurMasterID.ToString, dt.Rows(dtRow)("MenuDesc"), 0, 0)
    '        Else
    '            CurMasterID = dt.Rows(dtRow)("ParentMenuID")
    '            Dim MenuId As Integer = dt.Rows(dtRow)("MenuID")
    '            If MenuId = 41 Then
    '                QEMenu.Visible = True
    '                Continue For
    '            End If
    '            If MenuId = 42 Then
    '                QVToolStripMenuItem.Visible = True
    '                Continue For
    '            End If

    '            tvMenu.Nodes(CurMasterID.ToString).Nodes.Add(dt.Rows(dtRow)("MenuID"), dt.Rows(dtRow)("MenuDesc"), 2, 2)
    '        End If
    '    Next

    'End Sub


    Public Sub GetAllowedmenus()
        Try
            tvMenu.Nodes.Clear()
            'Dim CurMasterID As Long
            '###### FETCH MENU LIST ######################
            Dim objMenu As New Utitity

            objMenu.UserID = gblUserID
            Dim dt As DataTable = objMenu.FunFetchmenu()


            Dim dtgrp As New DataTable

            Dim dvTmp As DataView
            dvTmp = New DataView(dt)

            dtgrp = dvTmp.ToTable(True, "ParentMenuID")

            For index = 1 To dtgrp.Rows.Count - 1
                Dim dv1 As DataView
                dv1 = New DataView(dt)

                If IsDBNull(dtgrp.Rows(index)("ParentMenuID")) Then
                    Continue For
                End If


                dv1.RowFilter = "menuid=" & dtgrp.Rows(index)("ParentMenuID") & " and ParentMenuID is null"

                If Not dv1.Count > 0 Then Continue For

                Dim MainMaster As Long
                MainMaster = dv1(0)("menuid")
                tvMenu.Nodes.Add(MainMaster.ToString, dv1(0)("MenuDesc"), 0, 0)

                dv1 = Nothing
                dv1 = New DataView(dt)
                dv1.RowFilter = "ParentMenuID=" & dtgrp.Rows(index)("ParentMenuID")

                For dvCtr = 0 To dv1.Count - 1

                    If CInt(dv1(dvCtr)("MenuID")) = 41 Then
                        QVToolStripMenuItem.Visible = True
                        Continue For
                    End If
                    If CInt(dv1(dvCtr)("MenuID")) = 42 Then
                        QEMenu.Visible = True
                        Continue For
                    End If


                    Dim dv2 As DataView
                    dv2 = New DataView(dt)
                    dv2.RowFilter = "ParentMenuID=" & dv1(dvCtr)("menuid")
                    Dim SubMaster As Long

                    SubMaster = dv1(dvCtr)("menuid")

                    If dv2.Count > 0 Then
                        tvMenu.Nodes(MainMaster.ToString).Nodes.Add(SubMaster.ToString, dv1(dvCtr)("MenuDesc"), 4, 4)
                        For inctr = 0 To dv2.Count - 1
                            tvMenu.Nodes(MainMaster.ToString).Nodes(SubMaster.ToString).Nodes.Add(dv2(inctr)("menuid"), dv2(inctr)("MenuDesc"), 2, 2)
                        Next
                    Else
                        tvMenu.Nodes(MainMaster.ToString).Nodes.Add(SubMaster.ToString, dv1(dvCtr)("MenuDesc"), 2, 2)
                    End If
                Next

            Next
            'For dtRow = 0 To dt.Rows.Count - 1
            '    If CInt(dt.Rows(dtRow)("MenuID")) = 41 Then
            '        QEMenu.Visible = True
            '        Continue For
            '    End If
            '    If CInt(dt.Rows(dtRow)("MenuID")) = 42 Then
            '        QVToolStripMenuItem.Visible = True
            '        Continue For
            '    End If

            '    If IsDBNull(dt.Rows(dtRow)("ParentMenuID")) Then
            '        CurMasterID = dt.Rows(dtRow)("MenuID")
            '        tvMenu.Nodes.Add(CurMasterID.ToString, dt.Rows(dtRow)("MenuDesc"), 0, 0)
            '    Else
            '        CurMasterID = dt.Rows(dtRow)("ParentMenuID")
            '        Dim MenuId As Integer = dt.Rows(dtRow)("MenuID")


            '        tvMenu.Nodes(CurMasterID.ToString).Nodes.Add(dt.Rows(dtRow)("MenuID"), dt.Rows(dtRow)("MenuDesc"), 2, 2)
            '    End If
            'Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogout.Click
        mnuLogout.Visible = False

        'ClearMenuList(tvMenu)
        txtUsername.Text = ""
        txtPass.Text = ""
        Panel1.Visible = True
        GroupBox1.Enabled = True
        Label2.Visible = False
        txtUsername.Focus()

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Dim ActiveMDI As Form = Me.ActiveMdiChild
        If Not IsNothing(ActiveMDI) Then
            Select Case LCase(ActiveMDI.Name)
                Case "frmcategory"
                    FrmCategory.FunDelete()
                Case "frmsize"
                    FrmSize.FunDelete()
                Case "frmsupplier"
                    frmSupplier.FunDelete()
                Case "frmusermaster"
                    FrmUserMaster.FunDelete()
                Case "frmss_permittypemaster"
                    FrmSS_PermitTypeMaster.FunDelete()
                Case "frmbrand"
                    frmBrand.delete()
                Case "frmdeptmaster"
                    frmDeptMaster.FunDelete()
                Case "frmpermitholdermaster"
                    FrmPermitHolderMaster.FunDelete()
                Case "frmcocktail"
                    FrmCocktail.FunDelete()
                Case "frmconsumption"
                    FrmConsumption.FunDelete()
                Case "frmdesignation"
                    frmDesignation.FunDelete()
                Case Else
            End Select
        End If
    End Sub



    Private Sub ShowPanelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.tvMenu.Visible = True Then
            Me.tvMenu.Visible = False
        Else
            Me.tvMenu.Visible = True
        End If
    End Sub

    Private Sub cmdMultiSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiSelect.Click


        Dim ActiveMDI As Form = Me.ActiveMdiChild
        If DirectCast(sender, Button).Text = "M" Then
            DirectCast(sender, Button).Text = "S"
            chkLicenseName.Visible = True
        Else
            DirectCast(sender, Button).Text = "M"
            chkLicenseName.Visible = False
        End If
        If Not IsNothing(ActiveMDI) Then
            If LCase(ActiveMDI.Name) = "frmbrand" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False
            ElseIf LCase(ActiveMDI.Name) = "frmsupplier" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False
            ElseIf LCase(ActiveMDI.Name) = "frmss_permittypemaster" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False
                'ElseIf LCase(ActiveMDI.Name) = "frmcategorytax" Then
                '    cmdMultiSelect.Text = "M"
                '    chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frm_subcategorymaster" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmassignbrandcode" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmassigncocktailcode" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False
            ElseIf LCase(ActiveMDI.Name) = "frmbillbook" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmbrandopening" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False
            ElseIf LCase(ActiveMDI.Name) = "frmcocktail" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False
            ElseIf LCase(ActiveMDI.Name) = "frmconsumption" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False
            ElseIf LCase(ActiveMDI.Name) = "frmfreezdate" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False
            ElseIf LCase(ActiveMDI.Name) = "frminterfacefilesetup" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmlicenselist" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmlicensemst" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmparameter" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmpermitholdermaster" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False


            ElseIf LCase(ActiveMDI.Name) = "frmsize" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmuserlicense" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False


            ElseIf LCase(ActiveMDI.Name) = "frmusermaster" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmusermenurights" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmautobilling" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frminterfacefilesale" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmpurchasedetail" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmpurchasemst" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmsalemst" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmtransfer" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmtransferlist" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frnsalelist" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False

            ElseIf LCase(ActiveMDI.Name) = "frmcategorytax" Then
                cmdMultiSelect.Text = "M"
                chkLicenseName.Visible = False
           
            End If

        End If

      
    End Sub



    Private Sub HideMenuToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideMenuToolStripMenuItem.Click
        tvMenu.Visible = Not HideMenuToolStripMenuItem.Checked

    End Sub

    Private Sub chkLicenseName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLicenseName.SelectedIndexChanged
        If chkLicenseName.SelectedIndex = 0 Then
            For rctr = 1 To chkLicenseName.Items.Count - 1
                chkLicenseName.SetItemChecked(rctr, chkLicenseName.GetItemChecked(0))
            Next
        End If
        'cmbLicenseName.SelectedValue = 0
        FetchMDILicenseChecked(Me.chkLicenseName, cmbLicenseName.SelectedValue)
    End Sub

    Private Sub QUICKACCESSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QEMenu.Click
        QEMain.Show()
    End Sub

    Private Sub cmbLicenseName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLicenseName.SelectedIndexChanged

        If Not TypeOf cmbLicenseName.SelectedValue Is Decimal Then
            Exit Sub
        End If
        'Uncheck the multiple license Selected
        For rctr = 0 To chkLicenseName.Items.Count - 1
            chkLicenseName.SetItemChecked(rctr, False)
        Next

        gblLicenseID = cmbLicenseName.SelectedValue
        MainModule.LicenseName = gblLicenseID
        chkLicenseName.Visible = False

        FetchMDILicenseChecked(Me.chkLicenseName, cmbLicenseName.SelectedValue)
        FetchCurrentBillNumber()

        Dim ActiveMDI As Form = Me.ActiveMdiChild

        If Not IsNothing(ActiveMDI) Then
            Select Case LCase(ActiveMDI.Name)
                Case "dashboard"

                    Dashboard.Close()
                    Dim ChildForm As New Form
                    ChildForm = Dashboard
                    ChildForm.MdiParent = Me
                    ChildForm.Show()
                    ChildForm.WindowState = FormWindowState.Maximized

                Case "frmcocktailcodereport"
                    frmCocktailCodeReport.BindGrid()
                Case "frmbrandcodereport"
                    frmBrandCodeReport.BindBrand(0)
                    frmBrandCodeReport.BindGrid()
                Case "dashboard"
                    Dashboard.FetchSchedule()
                Case "frmautobilling"
                    FrmAutobilling.BindCocktail()
                    FrmAutobilling.BindBrand(0)
                    FrmAutobilling.grdBrand.Rows.Clear()
                    FrmAutobilling.grdCocktail.Rows.Clear()
                    FrmAutobilling.grdPermitName.Rows.Clear()
                Case "frmtransfer"
                    FrmTransfer.BindLicenseForTransfer()
                    FrmTransfer.BindBrand(0)
                    FrmTransfer.Worning()
                    FrmTransfer.grdTransfer.Rows.Clear()
                    'FrmTransfer.btnCallEvent.PerformClick()
                    'FrmTransfer.btnCallEvent_Click(FrmTransfer.btnCallEvent, New EventArgs())
                Case "frmcategorysizelinlup"
                    FrmCategorySizelinlup.FetchSizes()
                    FrmCategorySizelinlup.FetchCategorySizeLinkUp()
                Case "frmbrandopening"
                    frmBrandOpening.FetchBrandOpening()
                Case "frmpurchasemst"
                    FrmpurchaseMst.BindBrand(0)
                    FrmpurchaseMst.grdpurchase.Rows.Clear()
                Case "frmsalemst"
                    FrmSaleMst.BindBrand(0)
                    FrmSaleMst.grdBrand.Rows.Clear()
                    FrmSaleMst.grdCocktail.Rows.Clear()
                    FrmSaleMst.grdPermitName.Rows.Clear()
                Case "frmcocktail"
                    FrmCocktail.BindBrand(0)
                Case "frmassignbrandcode"
                    frmAssignBrandCode.BindBrand(0)
                Case "frmcocktaildescreport"
                    FrmCocktailDescReport.BindGrid()
                Case "frm_licensetransfer"
                    Frm_LicenseTransfer.BindLicense()
                Case "frnsalelist"
                    FrnSaleList.FetchSaleList()
                Case "frmtransferlist"
                    FrmTransferList.FetchTransferHeadDetails()
                Case "frmpurchasedetail"
                    FrmPurchasedetail.Bindgrid()
                Case "frmtransferreport"
                    FrmTransferReport.FetchTransferReports()
                    FrmTransferReport.BindLicenseForTransfer()
                Case "frmonedaypermitnumber"
                    frmOneDayPermitNumber.FetchOneDayPermitNumber()
                Case "frmassignonedaypermitsale"
                    frmAssignOneDayPermitSale.FetchSaleList()
                Case "frmassignmmsbrandcode"
                    frmAssignMMSBrandCode.BindBrand(0)
                Case "frmwashday"
                    frmWashDay.BindLicenseForTransfer()
            End Select
        End If



    End Sub

    Private Sub tvMenu_KeyDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tvMenu.KeyUp
        If e.KeyCode = Keys.Enter Then
            ShowNewForm(Nothing, Nothing)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For chkCtr = 0 To chkLicenseName.CheckedItems.Count - 1
            If Not DirectCast(chkLicenseName.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0) = 0 Then
                MsgBox(DirectCast(chkLicenseName.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0))
            End If
        Next
    End Sub

    Private Sub QVToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QVToolStripMenuItem.Click
        If Not Me.cmbLicenseName.SelectedValue > 0 Then
            MsgBox("Please select license")
            Exit Sub
        End If
        Dim ObjQVMain As New QVMain(Me.cmbLicenseName.SelectedValue)
        ObjQVMain.Show()
    End Sub

    Dim vPrevNode As TreeNode
    Private Sub tvMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tvMenu.DoubleClick
        If Not IsNothing(vPrevNode) Then
            vPrevNode.ForeColor = Color.Black
        End If
        MakeBold(vPrevNode, FontStyle.Regular)
        OpenForm(tvMenu.SelectedNode)

        vPrevNode = tvMenu.SelectedNode
    End Sub

    Private Sub chkforUpdates_Click(sender As System.Object, e As System.EventArgs) Handles chkforUpdates.Click
        'Dim regKey As Microsoft.Win32.RegistryKey
        'regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\CWPlus")
        Process.Start(IO.Path.Combine(Application.StartupPath, "Updater", "cUpdater.exe"))
    End Sub

    Private Sub menu_manualUpdates_Click(sender As System.Object, e As System.EventArgs) Handles menu_manualUpdates.Click
        Process.Start(IO.Path.Combine(Application.StartupPath, "Updater", "cExtr.exe"))
    End Sub

    Private Sub OpenApplicationPathToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenApplicationPathToolStripMenuItem.Click
        Process.Start(Application.StartupPath)
    End Sub

    Private Sub ViewErrorsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewErrorsToolStripMenuItem.Click
        Dim ObjClog As New cErrorLog.cLogger
        ObjClog.ShowErrorList()
    End Sub

    Private Sub ConnectionSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConnectionSettingToolStripMenuItem.Click
        ConnectionSettings.ShowDialog()
    End Sub

    Private Sub BackupDatabaseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BackupDatabaseToolStripMenuItem.Click
        BackupDB.ShowDialog()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        FrmChangePassword.ShowDialog()
    End Sub

    Private Sub OpenFTPExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFTPExplorerToolStripMenuItem.Click
        FtpExplorer.Show()
    End Sub

    Private Sub RunScriptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunScriptToolStripMenuItem.Click
        'commented by Hitesh on 8 dec 2014
        ExecuteScript.Show()

       
    End Sub

    Private Sub ResetMenusToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResetMenusToolStripMenuItem.Click
        'Added by sachin on 22 Feb
        GetAllowedmenus()
    End Sub

    Private Sub BillingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BillingToolStripMenuItem.Click
        Frm_Billing.Show()
    End Sub

    Private Sub mnuupdateScript_Click(sender As System.Object, e As System.EventArgs) Handles mnuupdateScript.Click

        Dim ObjDtVersion As New clsGeneralSetup
        Dim ObjPriDt As New DataTable
        

        Dim CS As String
        Dim builder As SqlConnectionStringBuilder

        Try
            CS = ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString
            builder = New SqlConnectionStringBuilder(CS)
            Dim serverName As String = builder.DataSource
            Dim dbName As String = builder.InitialCatalog
            Dim UserName As String = builder.UserID
            Dim password As String = builder.Password
            Dim path As String = Application.StartupPath & "/CWPlus_DB.sql"

            MessageBox.Show("Executing sql script file this may take few minutes !", "::CWPlus:: Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim Proc As New Process
            Dim argument As String = "/k osql -S " & serverName & " -U " & UserName & " -P " & password & " -d " & dbName & " -i " & path & " -n"
            Proc.StartInfo.FileName = "cmd.exe"
            Proc.StartInfo.Arguments = argument
            Proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Proc.StartInfo.CreateNoWindow = True
            ' Proc.StartInfo.RedirectStandardOutput = True
            ' Proc.StartInfo.UseShellExecute = False
            Proc.Start()
            'Dim msg As String = Proc.StandardOutput.ReadToEnd()
            '[MsgBox(msg, MsgBoxStyle.Information)
            MsgBox("Script Executed Successfully", MsgBoxStyle.Information)


        
            ObjPriDt = ObjDtVersion.FunFetchClient()
                If ObjPriDt.Rows.Count > 0 Then
                StatusBarVersion.Text = "Version : CWPlus." & ObjPriDt.Rows(0).Item("Version").ToString()
                End If

        Catch ex As Exception
            Throw ex
        Finally

            If Not IsNothing(ObjDtVersion) Then
                ObjDtVersion = Nothing
            End If
            If Not IsNothing(ObjPriDt) Then
                ObjPriDt = Nothing
            End If
            builder = Nothing

        End Try
    End Sub


    End Class
