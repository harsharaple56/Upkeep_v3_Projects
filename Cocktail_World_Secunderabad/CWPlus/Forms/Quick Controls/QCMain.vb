Imports System.Threading
Imports CWPlusBL.Master

Public Class QCMain


#Region "SLIDER FUNCTION AND VARIABLES"

    Public Delegate Sub DelSlider()
    Public SelectedStep As Integer = 0

    Private Sub SlideStepsReverse()
        If Me.InvokeRequired Then
            Me.Invoke(New DelSlider(AddressOf SlideStepsReverse))
        Else
            'UNDOCK CONTROLS
            QcStep11.Dock = DockStyle.None
            QcStep21.Dock = DockStyle.None
            QcStep31.Dock = DockStyle.None
            Select Case SelectedStep
                Case 1
                    'SET STEP FOCUS
                    btnPrev.Enabled = False
                    btnNext.Enabled = True
                    Step1.Enabled = True
                    Step2.Enabled = False
                    Step3.Enabled = False
                    cmbLicenseName.Enabled = False
                    'SLIDE THE CONTROL
                    QcStep21.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + QcStep21.Width, QcStep21.Location.Y)
                    Dim locationX As Integer = (Me.ClientSize.Width - QcStep11.Width) / 2
                    Do Until QcStep11.Location.X >= locationX
                        QcStep11.Location = New Point(QcStep11.Location.X + 2, QcStep11.Location.Y)
                    Loop
                    QcStep11.Dock = DockStyle.Fill

                Case 2
                    btnPrev.Enabled = True
                    btnNext.Enabled = True
                    Step1.Enabled = False
                    Step2.Enabled = True
                    Step3.Enabled = False

                    'SLIDE THE CONTROL
                    QcStep31.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + QcStep31.Width, QcStep31.Location.Y)
                    Dim locationX As Integer = (Me.ClientSize.Width - QcStep31.Width) / 2
                    Do Until QcStep21.Location.X >= locationX
                        QcStep21.Location = New Point(QcStep21.Location.X + 2, QcStep21.Location.Y)
                    Loop
                    QcStep21.Dock = DockStyle.Fill
                Case Else
                    'Throw New Exception("Invalid Step")
            End Select
        End If
    End Sub

    Public Sub SlideSteps()
        If Me.InvokeRequired Then
            Me.Invoke(New DelSlider(AddressOf SlideSteps))
        Else

            'UNDOCK CONTROLS
            QcStep11.Dock = DockStyle.None
            QcStep21.Dock = DockStyle.None
            QcStep31.Dock = DockStyle.None

            Select Case SelectedStep
                Case 1
                    'MAKE CONTROLS INVISIBLE TO SLIDE FAST


                    'SET STEP FOCUS
                    btnPrev.Enabled = False

                    Step1.Enabled = True
                    Step2.Enabled = False
                    Step3.Enabled = False
                    cmbLicenseName.Enabled = False
                    QcStep21.SplitContainer1.Visible = False
                    'SLIDE THE CONTROL
                    Dim locationX As Integer = (Me.ClientSize.Width - QcStep11.Width) / 2
                    Do Until QcStep11.Location.X <= locationX
                        QcStep11.Location = New Point(QcStep11.Location.X - 2, QcStep11.Location.Y)
                    Loop
                    QcStep11.Dock = DockStyle.Fill
                    'MAKE CONTROLS VISIBLE

                Case 2
                    Label2.Text = "############################## Step 2 Description ############################"
                    btnPrev.Enabled = True
                    Step1.Enabled = False
                    Step2.Enabled = True
                    Step3.Enabled = False
                    cmbLicenseName.Enabled = False
                    QcStep21.SplitContainer1.Visible = False
                    'SLIDE THE CONTROL
                    QcStep11.Location = New Point(-(Screen.PrimaryScreen.WorkingArea.Width + QcStep11.Width), QcStep11.Location.Y)
                    Dim locationX As Integer = (Me.ClientSize.Width - QcStep21.Width) / 2
                    Do Until QcStep21.Location.X <= locationX
                        QcStep21.Location = New Point(QcStep21.Location.X - 2, QcStep21.Location.Y)
                    Loop

                    QcStep21.SplitContainer1.Visible = True
                    QcStep21.Dock = DockStyle.Fill
                    QcStep21.initMe()
                Case 3
                    btnPrev.Enabled = True
                    btnNext.Enabled = False
                    Step1.Enabled = False
                    Step2.Enabled = False
                    Step3.Enabled = True
                    cmbLicenseName.Enabled = False
                    QcStep21.Location = New Point(-(Screen.PrimaryScreen.WorkingArea.Width + QcStep21.Width), QcStep21.Location.Y)
                    Dim locationX As Integer = (Me.ClientSize.Width - QcStep31.Width) / 2
                    Do Until QcStep31.Location.X <= locationX
                        QcStep31.Location = New Point(QcStep31.Location.X - 2, QcStep31.Location.Y)
                    Loop
                    QcStep31.Dock = DockStyle.Fill
                    QcStep31.InitMe()
                Case Else
                    Throw New Exception("Invalid Step")
            End Select
        End If
    End Sub

    Public Sub SetControlPosition()

        QcStep11.Width = Me.ClientSize.Width - 10
        QcStep11.Height = SplitContainer1.Panel1.Height - SplitContainer1.Panel2.Height
        QcStep11.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + QcStep11.Width, QcStep11.Location.Y)

        QcStep21.Width = Me.ClientSize.Width - 10
        QcStep21.Height = SplitContainer1.Panel1.Height - SplitContainer1.Panel2.Height
        QcStep21.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + QcStep21.Width, QcStep21.Location.Y)

        QcStep31.Width = Me.ClientSize.Width - 10
        QcStep31.Height = SplitContainer1.Panel1.Height - SplitContainer1.Panel2.Height
        QcStep31.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width + QcStep31.Width, QcStep31.Location.Y)

    End Sub

    Public Sub HideToggleControls(hideme As Boolean)
        PictureBox1.Visible = hideme
        cmbLicenseName.Visible = hideme
        Label1.Visible = hideme
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

    Dim ThreadSlider As Thread
    Public Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.ClickButtonArea
        'If gblQcStep2Save = False Then
        '    MsgBox("Please Save QCStep 2")
        '    Exit Sub
        'End If

        cmbLicenseName.Enabled = False

        SelectedStep += 1
        ThreadSlider = New Thread(New ThreadStart(AddressOf SlideSteps))
        ThreadSlider.Start()

    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.ClickButtonArea
        SelectedStep -= 1
        ThreadSlider = New Thread(New ThreadStart(AddressOf SlideStepsReverse))
        ThreadSlider.Start()
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

#End Region

    Private Sub BindLicense()
        Dim objDt As DataTable
        Dim objlicense As New Utitity
        objDt = New DataTable
        Try
            objlicense.UserID = gblUserID
            objDt = objlicense.FunFetchLicenseByRights
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

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblQCLicenseName.Text = gblLicenseNameForQuickControl

        lblQCLicenseName.Visible = True

        '  BindLicense()
        'cmbLicenseName.SelectedValue = gblLicenseID
        QcStep11.InitMe()
        QcStep21.initMe()
        ' QcStep31.FetchQcStep3()

        ' BindLicense()
        SetControlPosition()
        System.Threading.Thread.Sleep(500)
        btnNext_Click(Nothing, Nothing)

        AddHandler QcStep21.imgSave.Click, AddressOf imgSave_Click

        ' cmbLicenseName.Enabled = False
    End Sub



    Private Sub cmbLicenseName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLicenseName.SelectionChangeCommitted
        'gblLicenseID = cmbLicenseName.SelectedValue
        QcStep11.FetchQcStep1()
        QcStep21.FetchControls()
    End Sub

   
    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If QcStep21.SaveQcStep2() = True Then
            btnNext_Click(Nothing, Nothing)
        End If
    End Sub




End Class