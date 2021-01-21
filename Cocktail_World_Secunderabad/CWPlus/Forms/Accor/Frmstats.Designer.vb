<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStats
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.listVarsM1 = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.listGroupM1 = New System.Windows.Forms.ListBox()
        Me.listAnalysisM1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOKM1 = New System.Windows.Forms.Button()
        Me.btnResetM1 = New System.Windows.Forms.Button()
        Me.btnAnalysisM1 = New System.Windows.Forms.PictureBox()
        Me.btnGroupM1 = New System.Windows.Forms.PictureBox()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.btnAnalysisM1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGroupM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(120, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Analysis Variable"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnAnalysisM1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnGroupM1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.listVarsM1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnOKM1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnResetM1)
        Me.SplitContainer2.Size = New System.Drawing.Size(628, 568)
        Me.SplitContainer2.SplitterDistance = 436
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 8
        '
        'listVarsM1
        '
        Me.listVarsM1.BackColor = System.Drawing.Color.White
        Me.listVarsM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listVarsM1.Dock = System.Windows.Forms.DockStyle.Left
        Me.listVarsM1.FormattingEnabled = True
        Me.listVarsM1.Location = New System.Drawing.Point(0, 0)
        Me.listVarsM1.Name = "listVarsM1"
        Me.listVarsM1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.listVarsM1.Size = New System.Drawing.Size(295, 436)
        Me.listVarsM1.Sorted = True
        Me.listVarsM1.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.listGroupM1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.listAnalysisM1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(335, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(293, 436)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'listGroupM1
        '
        Me.listGroupM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listGroupM1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listGroupM1.FormattingEnabled = True
        Me.listGroupM1.Location = New System.Drawing.Point(0, 238)
        Me.listGroupM1.Margin = New System.Windows.Forms.Padding(0)
        Me.listGroupM1.Name = "listGroupM1"
        Me.listGroupM1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.listGroupM1.Size = New System.Drawing.Size(293, 198)
        Me.listGroupM1.TabIndex = 1
        '
        'listAnalysisM1
        '
        Me.listAnalysisM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listAnalysisM1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listAnalysisM1.FormattingEnabled = True
        Me.listAnalysisM1.Location = New System.Drawing.Point(0, 20)
        Me.listAnalysisM1.Margin = New System.Windows.Forms.Padding(0)
        Me.listAnalysisM1.Name = "listAnalysisM1"
        Me.listAnalysisM1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.listAnalysisM1.Size = New System.Drawing.Size(293, 198)
        Me.listAnalysisM1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(124, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Grouping Variable"
        '
        'btnOKM1
        '
        Me.btnOKM1.Location = New System.Drawing.Point(238, 7)
        Me.btnOKM1.Name = "btnOKM1"
        Me.btnOKM1.Size = New System.Drawing.Size(68, 28)
        Me.btnOKM1.TabIndex = 1
        Me.btnOKM1.Text = "&Process"
        Me.btnOKM1.UseVisualStyleBackColor = True
        '
        'btnResetM1
        '
        Me.btnResetM1.Location = New System.Drawing.Point(321, 7)
        Me.btnResetM1.Name = "btnResetM1"
        Me.btnResetM1.Size = New System.Drawing.Size(68, 28)
        Me.btnResetM1.TabIndex = 0
        Me.btnResetM1.Text = "Reset"
        Me.btnResetM1.UseVisualStyleBackColor = True
        '
        'btnAnalysisM1
        '
        Me.btnAnalysisM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnalysisM1.Image = Global.CWPlus.My.Resources.Resources.arrow_right__1_
        Me.btnAnalysisM1.Location = New System.Drawing.Point(303, 77)
        Me.btnAnalysisM1.Name = "btnAnalysisM1"
        Me.btnAnalysisM1.Size = New System.Drawing.Size(39, 29)
        Me.btnAnalysisM1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnAnalysisM1.TabIndex = 8
        Me.btnAnalysisM1.TabStop = False
        '
        'btnGroupM1
        '
        Me.btnGroupM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGroupM1.Image = Global.CWPlus.My.Resources.Resources.arrow_left__1_
        Me.btnGroupM1.Location = New System.Drawing.Point(301, 294)
        Me.btnGroupM1.Name = "btnGroupM1"
        Me.btnGroupM1.Size = New System.Drawing.Size(39, 29)
        Me.btnGroupM1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnGroupM1.TabIndex = 6
        Me.btnGroupM1.TabStop = False
        '
        'frmStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 568)
        Me.Controls.Add(Me.SplitContainer2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmStats"
        Me.Text = "Chart Info"
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.btnAnalysisM1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGroupM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnAnalysisM1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnGroupM1 As System.Windows.Forms.PictureBox
    Friend WithEvents listVarsM1 As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents listGroupM1 As System.Windows.Forms.ListBox
    Friend WithEvents listAnalysisM1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOKM1 As System.Windows.Forms.Button
    Friend WithEvents btnResetM1 As System.Windows.Forms.Button
End Class
