Imports CWPlusBL

Public Class Sales

    Dim ObjQE As ClsQuickExcess

#Region "Functions"
    Dim AutoBillToggleStatus = False

    Public Sub ToggleAutoBillButtonColor()
        If AutoBillToggleStatus Then
            Dim cl(2) As System.Drawing.Color
            cl(0) = Color.Gray
            cl(1) = Color.WhiteSmoke
            cl(2) = Color.Gray
            Dim Pt(2) As Single
            Pt(0) = 0
            Pt(1) = 0.3
            Pt(2) = 1
            btnAutoBill.ColorFillBlend = New CButtonLib.cBlendItems(cl, Pt)
            AutoBillToggleStatus = False
        Else
            AutoBillToggleStatus = True
            Dim CBlendItems5 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
            Me.btnAutoBill.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            CBlendItems5.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(210, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(179, Byte), Integer))}
            CBlendItems5.iPoint = New Single() {0.0!, 0.5412186!, 1.0!}
            Me.btnAutoBill.ColorFillBlend = CBlendItems5
        End If
    End Sub

    Public Sub ShowAutoBillControls(Show As Boolean)
        ToggleAutoBillButtonColor()
        Show = AutoBillToggleStatus
        autoLine1.Visible = Show
        autoLine2.Visible = Show
        autoLine3.Visible = Show
        autoLine4.Visible = Show
        lblBillingTitle.Visible = Show
        btnAmount.Visible = Show
        btnConsumption.Visible = Show
    End Sub


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
        End With
    End Sub

    Private Function GetTPNo(Optional LicenseId As Double = 0) As DataTable
        ObjQE = New ClsQuickExcess
        ObjQE.PurchaseDate = GblPurchaseDate
        ObjQE.LicenseID = LicenseId
        GetTPNo = ObjQE.FetchTPNo
    End Function


    ''' <summary>
    ''' Bind The Purchasdate to GRID
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BindPurchaseDate(lic As Double)
        grdTpNoByLicenseNo.DataSource = GetTPNo(lic)
        grdTpNoByLicenseNo.Columns("PurchaseID").Visible = False
        grdTpNoByLicenseNo.Columns("LicenseID").Visible = False
        grdTpNoByLicenseNo.Columns("LicenseDesc").Visible = False

        'BIND TP NO FOR ALL LIC
        Dim ds As New DataSet
        Dim dtAll As DataTable = GetTPNo()
        Dim dv As New DataView
        dv = dtAll.DefaultView
        Dim dt As New DataTable
        dt = dv.ToTable(True, "LicenseID")
        For rCtr = 0 To dt.Rows.Count - 1
            dv.RowFilter = "LicenseID='" & dt.Rows(rCtr)(0) & "'"
            ds.Tables.Add(dv.ToTable("out" & rCtr))
            dv.RowFilter = ""
        Next

        SplitContainer2.Panel2.Controls.Clear() 'CLEAR ALL THE GRID CONTROLS

        For Each subdt As DataTable In ds.Tables
            If subdt.Rows(0)("LicenseID") = lic Then Continue For 'SKIP FOR THE SELECTED LICENSE 
            Dim grd As New DataGridView
            grd.DataSource = subdt
            grd.Width = SplitContainer2.Panel2.Width
            SplitContainer2.Panel2.Controls.Add(grd)
            grd.Columns("PurchaseID").Visible = False
            grd.Columns("LicenseID").Visible = False
            grd.Columns("LicenseDesc").Visible = False
            grd.Columns("TPNO").HeaderText = grd("LicenseDesc", 0).Value
            grd.BackgroundColor = Color.White
            grd.Dock = DockStyle.Top
            SetGridTheme(grd)
            SplitContainer2.Panel2.VerticalScroll.Visible = True
        Next

        'grdTpNoAllLicenseNo.DataSource =
        'grdTpNoAllLicenseNo.Columns("PurchaseID").Visible = False
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Me.lblid.Text = text1

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
        AddTheme(SplitContainer2.Panel1)
        'SetGridThemeForPurchase(grdpurchase1)
        SetGridTheme(grdTpNoByLicenseNo)
    End Sub

    Private Sub btnAutoBill_ClickButtonArea(Sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnAutoBill.ClickButtonArea
        ShowAutoBillControls(Show:=True)
    End Sub

    Private Sub Sales_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ShowAutoBillControls(Show:=False)
    End Sub

    Private Sub btnAmount_ClickButtonArea(Sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnAmount.ClickButtonArea
        Me.SaleAutoBill1.Visible = True
        Me.SaleAutoBill1.Dock = DockStyle.Fill
    End Sub
End Class
