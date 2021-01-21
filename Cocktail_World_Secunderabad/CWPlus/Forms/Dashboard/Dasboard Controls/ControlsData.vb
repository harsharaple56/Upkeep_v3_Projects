Imports CWPlusBL

Public Class ControlsData

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


    Public Sub SetControlsForControlsDataInDashDetails(ByVal objDashDetail As dlgDashDetails, ByVal dt As DataTable)
        Dim grdDetail As New DataGridView
        Dim cht As DataVisualization.Charting.Chart
        cht = MakeMyChart()
        cht.Dock = DockStyle.Fill
        grdDetail.DataSource = dt
        MakeIDColumnsHide(grdDetail)
        grdDetail.BackgroundColor = Color.White
        grdDetail.Dock = DockStyle.Fill
        SetGridTheme(grdDetail)
        objDashDetail.TabControl1.TabPages(0).Controls.Add(grdDetail)
        objDashDetail.TabControl1.TabPages(0).Text = "Details"
        objDashDetail.TabControl1.TabPages.Add("Charts")
        For rCtr = 0 To dt.Rows.Count - 1
            cht.Series(0).Points.AddXY(dt.Rows(rCtr)("BrandDesc"), CDbl(dt.Rows(rCtr)("Cost")))
        Next
        objDashDetail.TabControl1.TabPages(1).Controls.Add(cht)
    End Sub


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

    Private Sub BindControlsData()
        Try
            objDash = New ClsQuickExcess
            objDash.ControlHeadID = cmbPeriod.SelectedValue
            objDash.LicenseID = gblLicenseID
            dt = objDash.FunFetchControlsDataByPeriod()
            grdControlsData.DataSource = dt

            'grdControlsData.Columns("CategoryID").Visible = False

            grdControlsData.Columns("Category").Width = 200
            'grdControlsData.Columns("Quantity").Width = 150
            grdControlsData.Columns("Cost").Width = 200

            chartControlData.Series.Clear()
            chartControlData.Series.Add("Category")

            'Add Rating in Y Location
            For i As Integer = 0 To dt.Rows.Count - 1

                Dim XValue As String = String.Empty
                Dim YValue As String = String.Empty

                XValue = dt.Rows(i)("Category")
                YValue = CDbl(dt.Rows(i)("Cost"))
                chartControlData.Series("Category").Points.AddXY(XValue, YValue)

            Next
            chartControlData.Series("Category").ChartType = DataVisualization.Charting.SeriesChartType.Column
            chartControlData.Series("Category").BorderWidth = 3
            chartControlData.Series("Category").IsValueShownAsLabel = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BindControlsPeriod()
        Try
            objDash = New ClsQuickExcess
            objDash.LicenseID = gblLicenseID
            dt = objDash.FunFetchControlsPeriod()
            With cmbPeriod
                .DisplayMember = "Period"
                .ValueMember = "ValueField"
                .DataSource = dt
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ControlsData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindControlsPeriod()
    End Sub


    Private Sub grdControlsData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdControlsData.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim dt As DataTable
        objDash = New ClsQuickExcess
        'objDash.ControlHeadID = cmbPeriod.SelectedValue
        objDash.CategoryID = grdControlsData("CategoryID", e.RowIndex).Value
        dt = objDash.FunFetchControlsDataByPeriodCategorywise()
        Dim objDashDetail As New dlgDashDetails
        SetControlsForControlsDataInDashDetails(objDashDetail, dt)
        objDashDetail.ShowDialog()
    End Sub

    Private Sub cmbPeriod_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPeriod.SelectedIndexChanged
        BindControlsData()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dt = New DataTable
        dt = DirectCast(grdControlsData.DataSource, DataTable)
        ExportExcelTemplate(dt)
    End Sub
End Class
