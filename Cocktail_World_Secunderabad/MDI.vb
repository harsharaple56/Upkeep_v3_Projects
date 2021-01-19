Imports System.Windows.Forms

Public Class MDI
    Dim ServiceMenus As TourmaticBL.ServiceMenus

    Dim ds As DataSet


    Public Sub CenterLoginContainer()
        ShowPanelToolStripMenuItem.PerformClick()
        Dim vwidth As Integer = 336
        Dim vheight As Integer = 192 + 148
        Dim vleft As Integer = Integer.Parse((Me.Width / 2) - (vwidth / 2))
        Dim vtop As Integer = Integer.Parse((Me.Height / 2) - (vheight / 2))
        pnlLoginContainer.Left = vleft
        pnlLoginContainer.Top = vtop
    End Sub

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
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

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdLogin
        'set the imagelist to treeview
        tvMenu.ImageList = ImageList1
        txtUsername.Focus()
        CenterLoginContainer()
    End Sub


    Private Sub ResetMenusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetMenusToolStripMenuItem.Click
        ServiceMenus = New TourmaticBL.ServiceMenus

        ds = New DataSet
        ds = ServiceMenus.SetMenus(CurUserName)
        'show the return message of the webservice
        MsgBox(ds.Tables(0).Rows(0)("description"), MsgBoxStyle.OkOnly, ds.Tables(0).Rows(0)("title"))
    End Sub

    Private Sub tvMenu_AfterCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMenu.AfterCollapse
        e.Node.ImageIndex = 0
        e.Node.SelectedImageIndex = 0
    End Sub

    Private Sub tvMenu_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMenu.AfterExpand
        e.Node.ImageIndex = 1
        e.Node.SelectedImageIndex = 1
    End Sub

    Private Sub tvMenu_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMenu.AfterSelect

    End Sub

    Private Sub tvMenu_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvMenu.DoubleClick
        OpenForm(tvMenu.SelectedNode)
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles SaveToolStripButton.Click, SaveToolStripMenuItem.Click

        Dim ActiveMDI As Form = Me.ActiveMdiChild

        'based on the current active form call the save proc
        If LCase(ActiveMDI.Name) = "frmstate" Then
            DirectCast(ActiveMDI, frmState).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "vehicletypemaster" Then
            DirectCast(ActiveMDI, VehicleTypeMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmcity" Then
            DirectCast(ActiveMDI, frmCity).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmroomtype" Then
            DirectCast(ActiveMDI, frmRoomType).saveentry()
        ElseIf LCase(ActiveMDI.Name) = "frmroomcharges" Then
            DirectCast(ActiveMDI, frmRoomCharges).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmroute" Then
            DirectCast(ActiveMDI, frmRoute).saveentry()
        ElseIf LCase(ActiveMDI.Name) = "attraction" Then
            DirectCast(ActiveMDI, Attraction).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmfoodtype" Then
            DirectCast(ActiveMDI, frmFoodtype).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmtourtype" Then
            DirectCast(ActiveMDI, frmTourType).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmvendor" Then
            DirectCast(ActiveMDI, frmVendor).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmhomestate" Then
            DirectCast(ActiveMDI, frmHomestate).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmpermitcharge" Then
            DirectCast(ActiveMDI, frmPermitcharge).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmroomchg" Then
            DirectCast(ActiveMDI, FrmRoomchg).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmfoodchg" Then
            DirectCast(ActiveMDI, frmfoodchg).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmcitydistance" Then
            DirectCast(ActiveMDI, frmCitydistance).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmoutsourcechg" Then
            DirectCast(ActiveMDI, frmoutsourcechg).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "travelmodemaster" Then
            DirectCast(ActiveMDI, TravelModeMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmholidaymaster" Then
            DirectCast(ActiveMDI, frmHolidayMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmnewschedule" Then
            DirectCast(ActiveMDI, frmNewSchedule).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmvehicletype" Then
            DirectCast(ActiveMDI, frmVehicleType).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmitenaryreworked" Then
            DirectCast(ActiveMDI, frmItenaryReworked).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmtourplan" Then
            DirectCast(ActiveMDI, frmTourPlan).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmnewsubtour" Then
            DirectCast(ActiveMDI, frmNewSubTour).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmusers" Then
            DirectCast(ActiveMDI, frmUsers).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmgroup" Then
            DirectCast(ActiveMDI, frmGroup).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmcommissionmaster" Then
            DirectCast(ActiveMDI, frmCommissionMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmagentmaster" Then
            DirectCast(ActiveMDI, FrmAgentMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmreceiptmaster" Then
            DirectCast(ActiveMDI, frmReceiptMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmbankmaster" Then
            DirectCast(ActiveMDI, frmBankMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmcancellationcharges" Then
            DirectCast(ActiveMDI, frmCancellationCharges).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmrights" Then
            DirectCast(ActiveMDI, frmRights).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmschedulewithdates" Then
            DirectCast(ActiveMDI, frmScheduleWithDates).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmpickuppoint" Then
            DirectCast(ActiveMDI, frmPickUpPoint).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmpackagepickup" Then
            DirectCast(ActiveMDI, frmPackagePickUp).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmopentourform" Then
            DirectCast(ActiveMDI, frmOpenTourForm).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmregion" Then
            DirectCast(ActiveMDI, FrmRegion).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmdistricttaluka" Then
            DirectCast(ActiveMDI, frmDistrictTaluka).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmtourboarding" Then
            DirectCast(ActiveMDI, frmTourBoarding).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmsra" Then
            DirectCast(ActiveMDI, frmSRA).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmssagentrecipmst" Then
            DirectCast(ActiveMDI, frmSSAgentRecipMst).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmperiodmaster" Then
            DirectCast(ActiveMDI, frmPeriodMaster).SaveEntry()
            '******************************************************************
            'TOUR MANAGEMENT
        ElseIf LCase(ActiveMDI.Name) = "frmbusdetailmaster" Then
            DirectCast(ActiveMDI, frmBusDetailMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmopenbusmapping" Then
            DirectCast(ActiveMDI, frmopenbusmapping).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmheadmaster" Then
            DirectCast(ActiveMDI, frmheadmaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmsubhead" Then
            DirectCast(ActiveMDI, frmsubhead).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmassignstaff" Then
            DirectCast(ActiveMDI, frmassignstaff).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmsettlement" Then
            DirectCast(ActiveMDI, frmSettlement).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmioumaster" Then
            DirectCast(ActiveMDI, frmIOUMaster).SaveEntry()
       
        ElseIf LCase(ActiveMDI.Name) = "frmtourstaffmaster" Then
            DirectCast(ActiveMDI, frmTourStaffMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmtourstaffmaster" Then
            DirectCast(ActiveMDI, frmTourStaffMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmagespecification" Then
            DirectCast(ActiveMDI, frmAgeSpecification).SaveEntry()
            'Daily Tour
            'ElseIf LCase(ActiveMDI.Name) = "frmpickuppoint" Then
            '    DirectCast(ActiveMDI, frmPickUpPoint).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmdailyroute" Then
            DirectCast(ActiveMDI, frmDailyRoute).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmdailytour" Then
            DirectCast(ActiveMDI, frmDailyTour).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmdailytourinfo" Then
            DirectCast(ActiveMDI, frmDailyTourInfo).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmdailytourschedule" Then
            DirectCast(ActiveMDI, frmDailyTourSchedule).SaveEntry()
            'WORKFLOW
        ElseIf LCase(ActiveMDI.Name) = "frmwfmoduleMaster" Then
            DirectCast(ActiveMDI, frmWFModuleMaster).SaveEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmwfactioninfodetails" Then
            DirectCast(ActiveMDI, frmWFActionInfoDetails).SaveEntry()
        End If
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click

        If txtUsername.Text = "" And txtPass.Text = "" Then
            MsgBox("Enter User Name and Password")
            Exit Sub
        End If

        ServiceMenus = New TourmaticBL.ServiceMenus
        ds = New DataSet

        'check for valid user
        ds = ServiceMenus.VerifyUser(txtUsername.Text, txtPass.Text)
        If ds.Tables(0).Rows.Count <= 0 Then
            MsgBox("Invalid")
            Exit Sub
        End If

        'Set UserRights To Global Table
        UserRightsTable = ds.Tables(1)
        CurUserName = txtUsername.Text
        GroupBox1.Enabled = False
        menus = New Threading.Thread(AddressOf GetAllowedmenus)
        Timer1.Enabled = True
        Label2.Visible = True
        menus.Start()
        ShowPanelToolStripMenuItem.PerformClick()
    End Sub
    Dim menus As Threading.Thread
    Public Sub GetAllowedmenus()
        ServiceMenus = New TourmaticBL.ServiceMenus
        ds = New DataSet
        'get the allowed menus
        ds = ServiceMenus.GetAllowedMenusList(txtUsername.Text)
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogout.Click
        mnuLogout.Visible = False
        CloseAllToolStripMenuItem.PerformClick()
        ShowPanelToolStripMenuItem.PerformClick()
        ClearMenuList(tvMenu)
        txtUsername.Text = ""
        txtPass.Text = ""
        Panel1.Visible = True
        GroupBox1.Enabled = True
        Label2.Visible = False
        txtUsername.Focus()
    End Sub


    Private Sub cmdLogin_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.MouseHover

    End Sub

    Private Sub tvMenu_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvMenu.Enter

    End Sub

    Private Sub tvMenu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tvMenu.KeyPress
        'Dim val As Integer = Char.get
        'If Char.GetNumericValue(e.KeyChar) = 16 Then
        '    OpenForm(tvMenu.SelectedNode)
        'End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Label2.Text = "Initializing Menu List..." Then
            Label2.Text = "Initializing Menu List"
        End If
        Label2.Text &= "."
        If menus.ThreadState = Threading.ThreadState.Stopped Then
            'show the menus
            RefreshMenuList(ds, tvMenu)
            Panel1.Visible = False
            mnuLogout.Visible = True
            Timer1.Enabled = False
            Timer1.Dispose()
        End If
    End Sub

    Private Sub MDI_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Process.Start(Application.StartupPath & "\CompelUpdates.exe")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click, mnuDelete.Click
        Dim ActiveMDI As Form = Me.ActiveMdiChild

        If IsNothing(ActiveMDI) Then
            Exit Sub
        End If

        'based on the current active form call the save proc
        If LCase(ActiveMDI.Name) = "frmstate" Then
            DirectCast(ActiveMDI, frmState).DeleteEntry()
            'ElseIf LCase(ActiveMDI.Name) = "vehicletypemaster" Then
            '    DirectCast(ActiveMDI, VehicleTypeMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmcity" Then
            DirectCast(ActiveMDI, frmCity).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmroomtype" Then
            DirectCast(ActiveMDI, frmRoomType).DeleteEntry()
            'ElseIf LCase(ActiveMDI.Name) = "frmroomcharges" Then
            '    DirectCast(ActiveMDI, frmRoomCharges).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmroute" Then
            DirectCast(ActiveMDI, frmRoute).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "attraction" Then
            DirectCast(ActiveMDI, Attraction).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmfoodtype" Then
            DirectCast(ActiveMDI, frmFoodtype).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmtourtype" Then
            DirectCast(ActiveMDI, frmTourType).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmvendor" Then
            DirectCast(ActiveMDI, frmVendor).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmhomestate" Then
            DirectCast(ActiveMDI, frmHomestate).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmpermitcharge" Then
            DirectCast(ActiveMDI, frmPermitcharge).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmcommissionmaster" Then
            DirectCast(ActiveMDI, frmCommissionMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmagentmaster" Then
            DirectCast(ActiveMDI, FrmAgentMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmtourplan" Then
            DirectCast(ActiveMDI, frmTourPlan).DeleteEntry()
            'ElseIf LCase(ActiveMDI.Name) = "frmfoodchg" Then
            '    DirectCast(ActiveMDI, frmfoodchg).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmcitydistance" Then
            DirectCast(ActiveMDI, frmCitydistance).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmoutsourcechg" Then
            DirectCast(ActiveMDI, frmoutsourcechg).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "travelmodemaster" Then
            DirectCast(ActiveMDI, TravelModeMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmholidaymaster" Then
            DirectCast(ActiveMDI, frmHolidayMaster).DeleteEntry()
            'ElseIf LCase(ActiveMDI.Name) = "frmschedulemaster" Then
            '    DirectCast(ActiveMDI, frmScheduleMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmvehicletype" Then
            DirectCast(ActiveMDI, frmVehicleType).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmreceiptmaster" Then
            DirectCast(ActiveMDI, frmReceiptMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmbankmaster" Then
            DirectCast(ActiveMDI, frmBankMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmcancellationcharges" Then
            DirectCast(ActiveMDI, frmCancellationCharges).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmitenaryreworked" Then
            DirectCast(ActiveMDI, frmItenaryReworked).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmpickuppoint" Then
            DirectCast(ActiveMDI, frmPickUpPoint).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmpackagepickup" Then
            DirectCast(ActiveMDI, frmPackagePickUp).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmtourboarding" Then
            DirectCast(ActiveMDI, frmTourBoarding).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmsra" Then
            DirectCast(ActiveMDI, frmSRA).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmssagentrecipmst" Then
            DirectCast(ActiveMDI, frmSSAgentRecipMst).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmperiodmaster" Then
            DirectCast(ActiveMDI, frmPeriodMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmopentourform" Then
            DirectCast(ActiveMDI, frmOpenTourForm).DeleteEntry()
            'ElseIf LCase(ActiveMDI.Name) = "frmtourplan" Then
            '    DirectCast(ActiveMDI, frmTourPlan).DeleteEntry()
            'ElseIf LCase(ActiveMDI.Name) = "frmusers" Then
            '    DirectCast(ActiveMDI, frmUsers).DeleteEntry()
            'ElseIf LCase(ActiveMDI.Name) = "frmgroup" Then
            '    DirectCast(ActiveMDI, frmGroup).DeleteEntry()

            '******************************************************************
            'TOUR MANAGEMENT
        ElseIf LCase(ActiveMDI.Name) = "frmbusdetailmaster" Then
            DirectCast(ActiveMDI, frmBusDetailMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmheadmaster" Then
            DirectCast(ActiveMDI, frmheadmaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmsubhead" Then
            DirectCast(ActiveMDI, frmsubhead).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmassignstaff" Then
            DirectCast(ActiveMDI, frmassignstaff).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmsettlement" Then
            DirectCast(ActiveMDI, frmSettlement).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmioumaster" Then
            DirectCast(ActiveMDI, frmIOUMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmstafftypemaster" Then
            DirectCast(ActiveMDI, frmStaffTypeMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmtourstaffmaster" Then
            DirectCast(ActiveMDI, frmTourStaffMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmvouchertypemaster" Then
            DirectCast(ActiveMDI, frmVoucherTypeMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmagespecification" Then
            DirectCast(ActiveMDI, frmAgeSpecification).DeleteEntry()
            'Daily Tour
            'ElseIf LCase(ActiveMDI.Name) = "frmpickuppoint" Then
            '    DirectCast(ActiveMDI, frmPickUpPoint).DeleteEntry()
            'WORKFLOW
        ElseIf LCase(ActiveMDI.Name) = "frmwfmoduleMaster" Then
            DirectCast(ActiveMDI, frmWFModuleMaster).DeleteEntry()
        ElseIf LCase(ActiveMDI.Name) = "frmwfactioninfodetails" Then
            DirectCast(ActiveMDI, frmWFActionInfoDetails).DeleteEntry()
        End If
    End Sub

    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem.Click
        testreport.WindowState = FormWindowState.Maximized
        testreport.MdiParent = Me
        testreport.Show()
    End Sub

    Private Sub ShowPanelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowPanelToolStripMenuItem.Click
        If Me.tvMenu.Visible = True Then
            Me.tvMenu.Visible = False
        Else
            Me.tvMenu.Visible = True
        End If
    End Sub

    Private Sub MDI_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dlg As DialogResult
        dlg = MsgBox("Do you want to exit?", MsgBoxStyle.YesNoCancel)
        If dlg = DialogResult.Yes Then
            e.Cancel = False
        ElseIf dlg = DialogResult.No Then
            e.Cancel = True
        ElseIf dlg = DialogResult.Cancel Then
            e.Cancel = True
        End If
    End Sub
End Class
