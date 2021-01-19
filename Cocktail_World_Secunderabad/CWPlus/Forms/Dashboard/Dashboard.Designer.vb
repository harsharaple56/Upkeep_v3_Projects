<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbPeriod = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MkDataGridView1 = New ThemedDataGrid.MKDataGridView()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DsaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToTile2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToTile3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToTile4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChartListToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btn3D = New System.Windows.Forms.ToolStripButton()
        Me.btnSelectControlPeriod = New System.Windows.Forms.ToolStripButton()
        Me.btnChartList = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.MkDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn3D, Me.ToolStripSeparator1, Me.btnSelectControlPeriod, Me.btnChartList})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(875, 35)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AllowDrop = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(871, 443)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'cmbPeriod
        '
        Me.cmbPeriod.FormattingEnabled = True
        Me.cmbPeriod.Location = New System.Drawing.Point(651, 6)
        Me.cmbPeriod.Name = "cmbPeriod"
        Me.cmbPeriod.Size = New System.Drawing.Size(213, 21)
        Me.cmbPeriod.TabIndex = 2
        Me.cmbPeriod.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(608, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Period"
        Me.Label6.Visible = False
        '
        'MkDataGridView1
        '
        Me.MkDataGridView1.AllowUserToAddRows = False
        Me.MkDataGridView1.AllowUserToDeleteRows = False
        Me.MkDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MkDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MkDataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.MkDataGridView1.Name = "MkDataGridView1"
        Me.MkDataGridView1.ReadOnly = True
        Me.MkDataGridView1.Size = New System.Drawing.Size(415, 183)
        Me.MkDataGridView1.TabIndex = 0
        '
        'lblStock
        '
        Me.lblStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStock.AutoSize = True
        Me.lblStock.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.ForeColor = System.Drawing.Color.Green
        Me.lblStock.Location = New System.Drawing.Point(669, 13)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(0, 15)
        Me.lblStock.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'splitMain
        '
        Me.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.Location = New System.Drawing.Point(0, 35)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.Controls.Add(Me.ListBox1)
        Me.splitMain.Panel1Collapsed = True
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.splitMain.Size = New System.Drawing.Size(875, 447)
        Me.splitMain.SplitterDistance = 174
        Me.splitMain.SplitterWidth = 1
        Me.splitMain.TabIndex = 3
        '
        'ListBox1
        '
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(170, 96)
        Me.ListBox1.TabIndex = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DsaToolStripMenuItem, Me.AddToTile2ToolStripMenuItem, Me.AddToTile3ToolStripMenuItem, Me.AddToTile4ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(142, 92)
        '
        'DsaToolStripMenuItem
        '
        Me.DsaToolStripMenuItem.Name = "DsaToolStripMenuItem"
        Me.DsaToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.DsaToolStripMenuItem.Text = "Add To Tile1"
        '
        'AddToTile2ToolStripMenuItem
        '
        Me.AddToTile2ToolStripMenuItem.Name = "AddToTile2ToolStripMenuItem"
        Me.AddToTile2ToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.AddToTile2ToolStripMenuItem.Text = "Add To Tile2"
        '
        'AddToTile3ToolStripMenuItem
        '
        Me.AddToTile3ToolStripMenuItem.Name = "AddToTile3ToolStripMenuItem"
        Me.AddToTile3ToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.AddToTile3ToolStripMenuItem.Text = "Add To Tile3"
        '
        'AddToTile4ToolStripMenuItem
        '
        Me.AddToTile4ToolStripMenuItem.Name = "AddToTile4ToolStripMenuItem"
        Me.AddToTile4ToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.AddToTile4ToolStripMenuItem.Text = "Add To Tile4"
        '
        'ChartListToolTip
        '
        Me.ChartListToolTip.AutomaticDelay = 250
        '
        'btn3D
        '
        Me.btn3D.BackColor = System.Drawing.Color.LightGray
        Me.btn3D.Image = Global.CWPlus.My.Resources.Resources.lightbulb_off
        Me.btn3D.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn3D.Name = "btn3D"
        Me.btn3D.Size = New System.Drawing.Size(106, 32)
        Me.btn3D.Tag = "1"
        Me.btn3D.Text = "Turn On 3D !"
        '
        'btnSelectControlPeriod
        '
        Me.btnSelectControlPeriod.Checked = True
        Me.btnSelectControlPeriod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnSelectControlPeriod.Image = Global.CWPlus.My.Resources.Resources.crystalReport
        Me.btnSelectControlPeriod.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectControlPeriod.Name = "btnSelectControlPeriod"
        Me.btnSelectControlPeriod.Size = New System.Drawing.Size(155, 32)
        Me.btnSelectControlPeriod.Text = "Select Controls Period"
        '
        'btnChartList
        '
        Me.btnChartList.Checked = True
        Me.btnChartList.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnChartList.Image = Global.CWPlus.My.Resources.Resources.list
        Me.btnChartList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnChartList.Margin = New System.Windows.Forms.Padding(6, 1, 0, 2)
        Me.btnChartList.Name = "btnChartList"
        Me.btnChartList.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnChartList.Size = New System.Drawing.Size(133, 32)
        Me.btnChartList.Text = "Toggle Chart List"
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 482)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbPeriod)
        Me.Controls.Add(Me.splitMain)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.MkDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel2.ResumeLayout(False)
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn3D As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MkDataGridView1 As ThemedDataGrid.MKDataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSelectControlPeriod As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblStock As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents splitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DsaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToTile2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnChartList As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddToTile3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToTile4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChartListToolTip As System.Windows.Forms.ToolTip
End Class
