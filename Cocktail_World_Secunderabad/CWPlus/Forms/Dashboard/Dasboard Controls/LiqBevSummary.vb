Imports CWPlusBL

Public Class LiqBevSummary

    Dim objDash As ClsQuickExcess
    Dim dt As DataTable

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

    Public Sub FillTile1()
        objDash = New ClsQuickExcess
        objDash.LicenseID = gblLicenseID
        dt = objDash.FetchLiqBevSummary()
        grdLiqBevSummary.DataSource = dt
        MakeIDColumnsHide(grdLiqBevSummary)
        For rCtr = 0 To dt.Rows.Count - 1
            chtLiqBevSummary.Series(0).Points.AddXY(dt.Rows(rCtr)("Category"), CDbl(dt.Rows(rCtr)("Sale Amount")))
        Next
    End Sub

    Private Sub LiqBevSummary_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SetGridTheme(grdLiqBevSummary)
        FillTile1()
    End Sub

    Private Sub grdLiqBevSummary_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdLiqBevSummary.CellDoubleClick
        Dim dt As DataTable
        objDash = New ClsQuickExcess
        objDash.CategoryID = grdLiqBevSummary("CategoryID", e.RowIndex).Value
        dt = objDash.FetchLiqBevSummaryCategoryWise()
        Dim objDashDetail As New dlgDashDetails
        SetControlsInDashDetails(objDashDetail, dt)
        objDashDetail.ShowDialog()
    End Sub


    Public Sub SetControlsInDashDetails(ByVal objDashDetail As dlgDashDetails, ByVal dt As DataTable)
        Dim grdDetail As New DataGridView
        Dim cht As DataVisualization.Charting.Chart
        cht = MakeMyChart()
        cht.Dock = DockStyle.Fill
        grdDetail.DataSource = dt
        grdDetail.BackgroundColor = Color.White
        grdDetail.Dock = DockStyle.Fill
        SetGridTheme(grdDetail)
        objDashDetail.TabControl1.TabPages(0).Controls.Add(grdDetail)
        objDashDetail.TabControl1.TabPages(0).Text = "Details"
        objDashDetail.TabControl1.TabPages.Add("Charts")
        For rCtr = 0 To dt.Rows.Count - 1
            cht.Series(0).Points.AddXY(dt.Rows(rCtr)("BrandDesc"), CDbl(dt.Rows(rCtr)("Sale Amount")))
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dt = New DataTable
        dt = DirectCast(grdLiqBevSummary.DataSource, DataTable).DefaultView.ToTable(False, "category", "Sale amount", "percentage")
        ExportExcelTemplate(dt)
    End Sub
End Class
