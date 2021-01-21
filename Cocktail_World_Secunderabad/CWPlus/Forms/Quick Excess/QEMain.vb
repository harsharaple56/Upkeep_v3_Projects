Imports System.Threading

Public Class QEMain

    Public Delegate Sub DelSlider()


    Public PurchaseDate As DateTime
    Dim tmrPanelSlider As Timers.Timer
    Dim objlicense As CWPlusBL.Master.Utitity

    Private Sub BindLicense()
        Try
            ' objlicense.UserID = gblUserID 
            Dim objDt As DataTable
            objlicense = New CWPlusBL.Master.Utitity
            objDt = New DataTable
            objlicense.UserID = gblUserID
            'objlicense.L()
            objDt = objlicense.FunFetchLicenseByRights

            'objlicense.DataSource = Nothing

            With cmbLicenseName
                .DisplayMember = "LicenseDesc"
                .ValueMember = "LicenseID"
                .DataSource = objDt
                '  BindCombo(objDt, "LicenseID", "LicenseDesc")
                .Text = ""
                .SelectedValue = -1

            End With


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(objlicense) Then
                objlicense = Nothing
            End If
        End Try


    End Sub

    Private Sub SlideStepsReverse()
        If Me.InvokeRequired Then
            Me.Invoke(New DelSlider(AddressOf SlideStepsReverse))
        Else
            'UNDOCK CONTROLS
            PurchaseControl1.Dock = DockStyle.None
            Sales1.Dock = DockStyle.None
            DecIncSales1.Dock = DockStyle.None
            Reports1.Dock = DockStyle.None
            Select Case SelectedStep
                Case 1
                    PurchaseControl1.SplitContainer1.Visible = False
                    PurchaseControl1.SplitContainer2.Visible = False
                    PurchaseControl1.SplitContainer3.Visible = False
                    'SET STEP FOCUS
                    Step1.Enabled = True
                    Step2.Enabled = False
                    Step3.Enabled = False
                    Step4.Enabled = False
                    'SLIDE THE CONTROL
                    Sales1.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + Sales1.Width, Sales1.Location.Y)
                    Dim locationX As Integer = (Me.ClientSize.Width - PurchaseControl1.Width) / 2
                    Do Until PurchaseControl1.Location.X >= locationX
                        PurchaseControl1.Location = New Point(PurchaseControl1.Location.X + 2, PurchaseControl1.Location.Y)
                    Loop
                    PurchaseControl1.Dock = DockStyle.Fill
                    PurchaseControl1.SplitContainer1.Visible = True
                    PurchaseControl1.SplitContainer2.Visible = True
                    PurchaseControl1.SplitContainer3.Visible = True
                Case 2
                    Step1.Enabled = False
                    Step2.Enabled = True
                    Step3.Enabled = False
                    Step4.Enabled = False
                    'SLIDE THE CONTROL
                    DecIncSales1.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + DecIncSales1.Width, DecIncSales1.Location.Y)
                    Dim locationX As Integer = (Me.ClientSize.Width - Sales1.Width) / 2
                    Do Until Sales1.Location.X >= locationX
                        Sales1.Location = New Point(Sales1.Location.X + 2, Sales1.Location.Y)
                    Loop
                    Sales1.Dock = DockStyle.Fill
                Case 3
                    Step1.Enabled = False
                    Step2.Enabled = False
                    Step3.Enabled = True
                    Step4.Enabled = False
                    Reports1.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + Reports1.Width, Reports1.Location.Y)
                    Dim locationX As Integer = (Me.ClientSize.Width - DecIncSales1.Width) / 2
                    Do Until DecIncSales1.Location.X >= locationX
                        DecIncSales1.Location = New Point(DecIncSales1.Location.X + 2, DecIncSales1.Location.Y)
                    Loop
                    DecIncSales1.Dock = DockStyle.Fill
                Case Else
                    'Throw New Exception("Invalid Step")
            End Select
        End If
    End Sub

    Private Sub SlideSteps()
        If Me.InvokeRequired Then
            Me.Invoke(New DelSlider(AddressOf SlideSteps))
        Else
          
            'UNDOCK CONTROLS
            PurchaseControl1.Dock = DockStyle.None
            Sales1.Dock = DockStyle.None
            DecIncSales1.Dock = DockStyle.None
            Reports1.Dock = DockStyle.None

            Select Case SelectedStep
                Case 1
                    'MAKE CONTROLS INVISIBLE TO SLIDE FAST
                    PurchaseControl1.SplitContainer1.Visible = False
                    PurchaseControl1.SplitContainer2.Visible = False
                    PurchaseControl1.SplitContainer3.Visible = False
                    'SET STEP FOCUS
                    Step1.Enabled = True
                    Step2.Enabled = False
                    Step3.Enabled = False
                    Step4.Enabled = False
                    'SLIDE THE CONTROL
                    Dim locationX As Integer = (Me.ClientSize.Width - PurchaseControl1.Width) / 2
                    Do Until PurchaseControl1.Location.X <= locationX
                        PurchaseControl1.Location = New Point(PurchaseControl1.Location.X - 2, PurchaseControl1.Location.Y)
                    Loop
                    PurchaseControl1.Dock = DockStyle.Fill
                    'MAKE CONTROLS VISIBLE
                    PurchaseControl1.SplitContainer1.Visible = True
                    PurchaseControl1.SplitContainer2.Visible = True
                    PurchaseControl1.SplitContainer3.Visible = True
                Case 2
                    Label2.Text = "############################## Step 2 Description ############################"
                    Step1.Enabled = False
                    Step2.Enabled = True
                    Step3.Enabled = False
                    Step4.Enabled = False
                    'SLIDE THE CONTROL
                    PurchaseControl1.Location = New Point(-(Screen.PrimaryScreen.WorkingArea.Width + PurchaseControl1.Width), PurchaseControl1.Location.Y)
                    Dim locationX As Integer = (Me.ClientSize.Width - Sales1.Width) / 2
                    Do Until Sales1.Location.X <= locationX
                        Sales1.Location = New Point(Sales1.Location.X - 2, Sales1.Location.Y)
                    Loop
                    Sales1.Dock = DockStyle.Fill
                Case 3
                    Step1.Enabled = False
                    Step2.Enabled = False
                    Step3.Enabled = True
                    Step4.Enabled = False
                    DecIncSales1.BringToFront()
                    Sales1.Location = New Point(-(Screen.PrimaryScreen.WorkingArea.Width + Sales1.Width), Sales1.Location.Y)
                    Dim locationX As Integer = (Me.ClientSize.Width - DecIncSales1.Width) / 2
                    Do Until DecIncSales1.Location.X <= locationX
                        DecIncSales1.Location = New Point(DecIncSales1.Location.X - 2, DecIncSales1.Location.Y)
                    Loop
                    DecIncSales1.Dock = DockStyle.Fill
                Case 4
                    Step1.Enabled = False
                    Step2.Enabled = False
                    Step3.Enabled = False
                    Step4.Enabled = True
                    Reports1.BringToFront()
                    DecIncSales1.Location = New Point(-(Screen.PrimaryScreen.WorkingArea.Width + DecIncSales1.Width), DecIncSales1.Location.Y)
                    Dim locationX As Integer = (Me.ClientSize.Width - Reports1.Width) / 2
                    Do Until Reports1.Location.X <= locationX
                        Reports1.Location = New Point(Reports1.Location.X - 2, Reports1.Location.Y)
                    Loop
                    Reports1.Dock = DockStyle.Fill
                Case Else
                    Throw New Exception("Invalid Step")
            End Select
        End If
    End Sub

    Public Sub SetControlPosition()
        PurchaseControl1.BindPurchaseDate(0)
        PurchaseControl1.Width = Me.ClientSize.Width - 10
        PurchaseControl1.Height = SplitContainer1.Panel1.Height - SplitContainer1.Panel2.Height
        PurchaseControl1.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + PurchaseControl1.Width, PurchaseControl1.Location.Y)

        Sales1.Width = Me.ClientSize.Width - 10
        Sales1.Height = SplitContainer1.Panel1.Height - SplitContainer1.Panel2.Height
        Sales1.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + Sales1.Width, Sales1.Location.Y)

        DecIncSales1.Width = Me.ClientSize.Width - 10
        DecIncSales1.Height = SplitContainer1.Panel1.Height - SplitContainer1.Panel2.Height
        DecIncSales1.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + DecIncSales1.Width, DecIncSales1.Location.Y)

        Reports1.Width = Me.ClientSize.Width - 10
        Reports1.Height = SplitContainer1.Panel1.Height - SplitContainer1.Panel2.Height
        Reports1.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + Reports1.Width, Reports1.Location.Y)
        
    End Sub

#Region "Upper Toogle"

    Public Sub ClosePanel()
        If Panel1.InvokeRequired Then
            Panel1.Invoke(New MethodInvoker(AddressOf ClosePanel))
        Else
            btnToggle.Tag = 2
            'Button1.Image = My.Resources._1335851906_arrow_sans_down_32
            If Not Panel1.Height <= 24 Then
                Panel1.Height -= 2
            Else
                tmrPanelSlider.Enabled = False
            End If
        End If
    End Sub

    Public Sub OpenPanel()
        If Panel1.InvokeRequired Then
            Panel1.Invoke(New MethodInvoker(AddressOf ClosePanel))
        Else
            btnToggle.Tag = 1
            'Button1.Image = My.Resources._1335851911_arrow_sans_up_32
            If Not Panel1.Height <= 160 Then
                Panel1.Height += 2
            Else
                tmrPanelSlider.Enabled = False
            End If
        End If
    End Sub

    Public Sub HideToggleControls(hideme As Boolean)
        PictureBox1.Visible = hideme
        cmbLicenseName.Visible = hideme
        Label1.Visible = hideme
    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        'Show Date Selection
        Dim objDateSelection As New dlgLicenceAndDate
        If objDateSelection.ShowDialog = Windows.Forms.DialogResult.OK Then
            objDateSelection.Close()
            Me.Show()
        Else
            Me.Close()
            Exit Sub
        End If
        SetControlPosition()
        BindLicense()
        System.Threading.Thread.Sleep(500)
        btnNext_Click(Nothing, Nothing)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggle.Click
        If btnToggle.Tag = 1 Then
            HideToggleControls(False)
            btnToggle.Image = My.Resources._1335851906_arrow_sans_down_32
            btnToggle.Tag = 2
            Timer1.Enabled = True
            Timer2.Enabled = False
        Else
            HideToggleControls(True)
            btnToggle.Image = My.Resources._1335851911_arrow_sans_up_32
            btnToggle.Tag = 1
            Timer1.Enabled = False
            Timer2.Enabled = True
        End If
        btnToggle.Text = "Selected License : " & cmbLicenseName.Text
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not Panel1.Height <= 24 Then
            Panel1.Height -= 4
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Panel1.Height <= 160 Then
            Panel1.Height += 4
        Else
            Timer2.Enabled = False
        End If
    End Sub

    Dim SelectedStep As Integer = 0


    Dim ThreadSlider As Thread
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.ClickButtonArea
        SelectedStep += 1
        ThreadSlider = New Thread(New ThreadStart(AddressOf SlideSteps))
        ThreadSlider.Start()

    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.ClickButtonArea
        SelectedStep -= 1
        ThreadSlider = New Thread(New ThreadStart(AddressOf SlideStepsReverse))
        ThreadSlider.Start()
    End Sub


    Private Sub cmbLicenseName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLicenseName.SelectionChangeCommitted
        gblLicenseID = cmbLicenseName.SelectedValue
        'INITIALIZE PURCHASE CONTROL
        PurchaseControl1.InitControls()
        PurchaseControl1.BindPurchaseDate(cmbLicenseName.SelectedValue)
        'INITIALIZE SALES CONTROL
        Sales1.SaleAutoBill1.InitSales()
        Sales1.SaleAutoBill1.BindCocktail()
        Sales1.BindPurchaseDate(cmbLicenseName.SelectedValue)
        Sales1.SaleAutoBill1.BindBrand(0)
    End Sub
End Class
