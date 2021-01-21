Imports CWPlusBL

Public Class Dashboard
    Dim ObjSchVar As CWPlusBL.Master.ClsScheduleVariance
    Dim objDt As DataTable

#Region "Variables"
    Dim objDash As ClsQuickExcess
    Dim dt As DataTable
#End Region

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
            .AllowUserToAddRows = False






        End With
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub FetchSchedule()
        Try
            lblStock.Text = ""
            If MDI.cmbLicenseName.SelectedValue = 0 Then
                Exit Sub
            End If
            ObjSchVar = New CWPlusBL.Master.ClsScheduleVariance
            objDt = New DataTable
            ObjSchVar.LicenseID = MDI.cmbLicenseName.SelectedValue
            objDt = ObjSchVar.FunFetch

            If objDt.Rows.Count > 0 Then
                AssignSchedule(objDt)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(objDt) Then
                objDt = Nothing
            End If
            If Not IsNothing(ObjSchVar) Then
                ObjSchVar = Nothing
            End If
        End Try
    End Sub

    Public Sub AssignSchedule(ByVal dt As DataTable)

        Dim vCurMnth As Date = Date.Now

        For index = 0 To dt.Rows.Count - 1
            Dim vStartDate As Date = dt.Rows(index)("startdate")
            Dim vAddDays As Integer = dt.Rows(index)("repeat")
            If vStartDate > vCurMnth Then
                Continue For
            End If
            Dim vDiff As Integer = DateDiff(DateInterval.Day, vStartDate, vCurMnth)
            Dim vCtr As Integer = vDiff Mod vAddDays
            If vCtr = 0 Then
                lblStock.Text = "Stock Taking Expected"
                Exit Sub
            End If

        Next

    End Sub


    Public Sub AddChartList()
        Dim dt As DataTable = GetDashletLists()
        ListBox1.DataSource = dt
        ListBox1.ValueMember = "Dashboardid"
        ListBox1.DisplayMember = "DashName"
        FillDashLet()
    End Sub

    Private Sub Dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'This methos is used to bind period of controls
        BindControlsPeriod()


        'ADD CHART LIST & CONTROL LIST
        AddChartList()


        GetDashLetByUser()

    End Sub

#Region "Tile Manager"

    'Public Sub FillTile2()
    '    objDash = New ClsQuickExcess
    '    objDash.TopBrands = topBrands.Value
    '    objDash.BrandOption = cmbBrandOptions.Text
    '    dt = objDash.FetchTopBrands
    '    chtTopBrands.Series.Clear()
    '    chtTopBrands.ChartAreas.Clear()
    '    chtTopBrands.ChartAreas.Add("chartArea")
    '    chtTopBrands.Series.Add("Sample")
    '    chtTopBrands.Series(0).Points.Clear()
    '    chtTopBrands.ChartAreas(0).CursorX.Interval = 0
    '    chtTopBrands.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
    '    chtTopBrands.ChartAreas(0).CursorY.Interval = 0
    '    chtTopBrands.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
    '    For rCtr = 0 To dt.Rows.Count - 1
    '        chtTopBrands.Series(0).Points.AddXY(dt.Rows(rCtr)("BrandDesc"), dt.Rows(rCtr)("Sale Amount"))
    '    Next
    'End Sub


    Private Sub BindControlsPeriod()
        Try
            objDash = New ClsQuickExcess
            dt = objDash.FunFetchControlsPeriod()
            ComboBindingTemplate(cmbPeriod, dt, "Period", "ValueField")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

  
    Public Function TotalBrandCount() As Integer
        Dim objMAster As New CWPlusBL.Master.ClsBrandHeadDet
        Return objMAster.FunFetch().Rows.Count - 1
    End Function


    Public Function MakeMyChart() As DataVisualization.Charting.Chart
        Dim Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Chart1.Legends.Add(Legend1)
        Chart1.Location = New System.Drawing.Point(287, 57)
        Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Chart1.Series.Add(Series1)
        Chart1.Size = New System.Drawing.Size(273, 154)
        Chart1.TabIndex = 0
        Chart1.Text = "Chart1"
        Return Chart1
    End Function

    Private Sub topBrands_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' FillTile2()
    End Sub


    Public Sub TurnOn3D(ByVal boolOn As Boolean)

        Dim chartCtrl As Control = TableLayoutPanel1.GetControlFromPosition(0, 0)
        If Not IsNothing(chartCtrl) Then
            TurnOn3d2(chartCtrl, boolOn)
        End If

        chartCtrl = TableLayoutPanel1.GetControlFromPosition(0, 1)
        If Not IsNothing(chartCtrl) Then
            TurnOn3d2(chartCtrl, boolOn)
        End If

        chartCtrl = TableLayoutPanel1.GetControlFromPosition(1, 1)
        If Not IsNothing(chartCtrl) Then
            TurnOn3d2(chartCtrl, boolOn)
        End If

        chartCtrl = TableLayoutPanel1.GetControlFromPosition(1, 0)
        If Not IsNothing(chartCtrl) Then
            TurnOn3d2(chartCtrl, boolOn)
        End If
    End Sub

    Public Sub TurnOn3d2(chartCtrl As Control, boolOn As Boolean)
        For Each ctrl As Control In chartCtrl.Controls
            If TypeOf ctrl Is DataVisualization.Charting.Chart Then
                DirectCast(ctrl, DataVisualization.Charting.Chart).ChartAreas(0).Area3DStyle.Enable3D = boolOn
            End If
            If ctrl.Controls.Count > 0 Then
                TurnOn3d2(ctrl, boolOn)
            End If
        Next
    End Sub

    Private Sub btn3D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3D.Click
        If btn3D.Tag = 1 Then
            btn3D.Text = "Turn Off 3D !"
            btn3D.Image = My.Resources.lightbulb
            btn3D.BackColor = Color.FromArgb(255, 255, 192)
            btn3D.Tag = 2
            TurnOn3D(True)
        Else
            btn3D.Text = "Turn On 3D !"
            btn3D.Image = My.Resources.lightbulb_off
            btn3D.BackColor = Color.LightGray
            btn3D.Tag = 1
            TurnOn3D(False)
        End If


    End Sub

    Private Sub cmbPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPeriod.SelectedIndexChanged
        If Not TypeOf (cmbPeriod.SelectedValue) Is Decimal Then
            Exit Sub
        End If
    End Sub

    Private Sub btnSelectControlPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectControlPeriod.Click
        Dim dlgSelection As New dlgControlPeriod

        If dlgSelection.ShowDialog = Windows.Forms.DialogResult.OK Then
            btnSelectControlPeriod.ToolTipText = dlgSelection.toolTip
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lblStock.ForeColor = Color.Green Then
            lblStock.ForeColor = Color.Maroon
        Else
            lblStock.ForeColor = Color.Green
        End If
    End Sub

#Region "Dashlet Functions"
    Dim listOfDashLet = New List(Of UserControl)

    Public Sub FillDashLet()
        listOfDashLet.Add(New SaleToPurchaseRatio)
        listOfDashLet.Add(New TopNBrand)
        listOfDashLet.Add(New LiqBevSummary)
        listOfDashLet.Add(New ControlsSummary)
        listOfDashLet.Add(New ControlsData)
        listOfDashLet.Add(New ActualCosting)
        listOfDashLet.Add(New PotentialCosting)
        listOfDashLet.Add(New Variance)

    End Sub

    Public Function GetDashletLists() As DataTable
        objDash = New ClsQuickExcess
        GetDashletLists = objDash.FetchDashLists()
    End Function

    Public Function GetDashLetByUser() As String
        objDash = New ClsQuickExcess
        objDash.UserID = gblUserID
        GetDashLetByUser = objDash.FetchUserChartList.Rows(0)(0)

        Dim ArrCharId() As String = GetDashLetByUser.Split("#")
        Dim colCtr, rowCtr As Integer
        For Each strCharID As String In ArrCharId

            For Each crtl As UserControl In listOfDashLet
                If crtl.Tag = strCharID Then
                    crtl.Dock = DockStyle.Fill
                    TableLayoutPanel1.Controls.Add(crtl, colCtr, rowCtr)
                End If
            Next
            If colCtr = 1 Then
                colCtr = 0
                rowCtr = 1
            Else
                colCtr += 1
            End If

        Next
        
    End Function

    Public Sub Save_Tiles()
        objDash = New ClsQuickExcess
        objDash.UserID = gblUserID
        objDash.DashBoardID = ArrDashBoardID
        objDash.SaveUserChartList()
    End Sub

#End Region


    Dim ArrDashBoardID As String = "#"

    Private Sub DsaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DsaToolStripMenuItem.Click
        Dim remControl As Control = TableLayoutPanel1.GetControlFromPosition(0, 0)
        TableLayoutPanel1.Controls.Remove(remControl)
        For Each crtl As UserControl In listOfDashLet
            If crtl.Tag = ListBox1.SelectedValue Then
                crtl.Dock = DockStyle.Fill
                TableLayoutPanel1.Controls.Add(crtl, 0, 0)
            End If
        Next

    End Sub

    Private Sub AddToTile2ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToTile2ToolStripMenuItem.Click
        Dim remControl As Control = TableLayoutPanel1.GetControlFromPosition(1, 0)
        TableLayoutPanel1.Controls.Remove(remControl)
        For Each crtl As UserControl In listOfDashLet
            If crtl.Tag = ListBox1.SelectedValue Then
                crtl.Dock = DockStyle.Fill
                TableLayoutPanel1.Controls.Add(crtl, 1, 0)
            End If
        Next

    End Sub

    Private Sub AddToTile3ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToTile3ToolStripMenuItem.Click
        Dim remControl As Control = TableLayoutPanel1.GetControlFromPosition(0, 1)
        TableLayoutPanel1.Controls.Remove(remControl)
        For Each crtl As UserControl In listOfDashLet
            If crtl.Tag = ListBox1.SelectedValue Then
                crtl.Dock = DockStyle.Fill
                TableLayoutPanel1.Controls.Add(crtl, 0, 1)
            End If
        Next
    End Sub

    Private Sub AddToTile4ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToTile4ToolStripMenuItem.Click
        Dim remControl As Control = TableLayoutPanel1.GetControlFromPosition(1, 1)
        TableLayoutPanel1.Controls.Remove(remControl)
        For Each crtl As UserControl In listOfDashLet
            If crtl.Tag = ListBox1.SelectedValue Then
                crtl.Dock = DockStyle.Fill
                TableLayoutPanel1.Controls.Add(crtl, 1, 1)
            End If
        Next
    End Sub

    Private Sub btnChartList_Click(sender As System.Object, e As System.EventArgs) Handles btnChartList.Click
        splitMain.Panel1Collapsed = Not splitMain.Panel1Collapsed
    End Sub

    Private Sub TableLayoutPanel1_ControlAdded(sender As System.Object, e As System.Windows.Forms.ControlEventArgs) Handles TableLayoutPanel1.ControlAdded
        ArrDashBoardID = ""
        If Not IsNothing(TableLayoutPanel1.GetControlFromPosition(0, 0)) Then
            ArrDashBoardID &= TableLayoutPanel1.GetControlFromPosition(0, 0).Tag & "#"
        End If
        If Not IsNothing(TableLayoutPanel1.GetControlFromPosition(1, 0)) Then
            ArrDashBoardID &= TableLayoutPanel1.GetControlFromPosition(1, 0).Tag & "#"
        End If
        If Not IsNothing(TableLayoutPanel1.GetControlFromPosition(0, 1)) Then
            ArrDashBoardID &= TableLayoutPanel1.GetControlFromPosition(0, 1).Tag & "#"
        End If
        If Not IsNothing(TableLayoutPanel1.GetControlFromPosition(1, 1)) Then
            ArrDashBoardID &= TableLayoutPanel1.GetControlFromPosition(1, 1).Tag & "#"
        End If
        Save_Tiles()
    End Sub

    Private Sub ListBox1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Dim idx As Integer = ListBox1.IndexFromPoint(e.Location)
        If idx <> ListBox.NoMatches Then
            For Each crtl As UserControl In listOfDashLet
                If crtl.Tag = ListBox1.SelectedValue Then
                    crtl.Dock = DockStyle.Fill
                    Dim dlgPreview As New dlgDashPreviewer
                    dlgPreview.Controls.Add(crtl)
                    dlgPreview.ShowDialog()
                End If
            Next
        End If

    End Sub

    Private Sub ListBox1_MouseHover(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseClick
        Dim idx As Integer = ListBox1.IndexFromPoint(e.Location)
        If idx <> ListBox.NoMatches Then
            ChartListToolTip.Show("Double click on chart list to preview !", ListBox1)
        End If
        'Double click on chart list to preview !
    End Sub
End Class