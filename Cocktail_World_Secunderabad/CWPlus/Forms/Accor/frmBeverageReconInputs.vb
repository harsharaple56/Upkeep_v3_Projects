Public Class frmBeverageReconInputs
    Dim ObjBevRec As CWPlusBL.Accor.ClsBeverageReconComment
    Dim ObjBevInp As CWPlusBL.Accor.ClsBeverageReconInputs
    Dim ObjDt As DataTable

    Dim ObjPriDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"
    Private Sub ClrScreen()
        DtBusinessDate.Value = Format(Now.Date, "dd-MMM-yyyy")
        drpCostCenter.SelectedValue = 0
        txtQuantity.Text = 0
        lblid.Text = 0
        lblArticleNo.Text = "Article No"
        txtValue.Text = 0
        txtArticleName.Text = ""
        chkBreakage.Checked = False
    End Sub

    Private Sub InitScreen()
        Try
            ObjBevInp = New CWPlusBL.Accor.ClsBeverageReconInputs
            ObjDt = New DataTable
            ObjBevInp.FromDate = Format(DtFromDate.Value, "dd-MMM-yyyy")
            ObjBevInp.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")
            ObjBevInp.Article = LTrim(RTrim(txtSearchByArticle.Text))
            If (ObjBevInp.FromDate > ObjBevInp.ToDate) Then
                MsgBox("From Date Should be Smaller than To Date")
            Else

                ObjDt = ObjBevInp.FunFetch
                grdBevRecon.DataSource = Nothing
                grdBevRecon.DataSource = ObjDt
                grdBevRecon.Columns("Idn").Visible = False
                grdBevRecon.AutoResizeColumns()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjBevInp) Then
                ObjBevInp = Nothing
            End If
        End Try

    End Sub

    Public Function Save() As Boolean
        Save = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "DRRSale")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "DRRSale")
                Exit Function
            End If
        End If
        If txtQuantity.Text = "" Then
            MsgBox("Enter comment", MsgBoxStyle.Information, "DRRSale")
            Exit Function
        End If
        If drpCostCenter.SelectedValue = 0 Then
            MsgBox("Select cost center", MsgBoxStyle.Information, "DRRSale")
            Exit Function
        End If
        
        Try
            ObjBevInp = New CWPlusBL.Accor.ClsBeverageReconInputs
            ObjBevInp.Idn = lblid.Text
            ObjBevInp.BusinessDate = Format(DtBusinessDate.Value, "dd-MMM-yyyy")
            ObjBevInp.ItemId = lblArticleID.Text
            ObjBevInp.ItemName = txtArticleName.Text
            ObjBevInp.ItemNo = lblArticleNo.Text
            ObjBevInp.CostCenterId = drpCostCenter.SelectedValue
            ObjBevInp.CostCenterName = drpCostCenter.Text
            ObjBevInp.Quantity = txtQuantity.Text
            ObjBevInp.Value = txtValue.Text
            ObjBevInp.Breakage = chkBreakage.Checked
            ObjBevInp.UserName = gblUserName
            Save = ObjBevInp.FunSave
            MsgBox(ObjBevInp.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjBevInp) Then
                ObjBevInp = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If lblid.Text = 0 Then
            MsgBox("Select record to delete", MsgBoxStyle.Critical, "DRRSale")
            Exit Function
        End If
        Try
            ObjBevInp = New CWPlusBL.Accor.ClsBeverageReconInputs
            ObjBevInp.Idn = lblid.Text
            ObjBevInp.UserName = gblUserName
            FunDelete = ObjBevInp.FunDelete
            MsgBox(ObjBevInp.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjBevInp) Then
                ObjBevInp = Nothing
            End If
        End Try
    End Function

#End Region

    Private Sub FrmSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        ClrScreen()
        'InitScreen()
        BindCostCenters()
        'BindArticles()
    End Sub

    Private Sub BindCostCenters()
        Try
            ObjPriDt = New DataTable
            ObjBevRec = New CWPlusBL.Accor.ClsBeverageReconComment
            ObjPriDt = ObjBevRec.FunFetchCostCenter
            ComboBindingTemplate(drpCostCenter, ObjPriDt, "CostCenterName", "CostCenterId")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjBevRec = Nothing
        End Try
    End Sub

    'Private Sub BindArticles()
    '    Try
    '        ObjPriDt = New DataTable
    '        ObjBevRec = New CWPlusBL.Accor.ClsBeverageReconComment
    '        'ObjPriDt = ObjBevRec.FunFetchMCItems(0)
    '        ComboBindingTemplate(drpArticles, ObjPriDt, "item_name", "item_id")
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        ObjPriDt = Nothing
    '        ObjBevRec = Nothing
    '    End Try
    'End Sub

    'Private Sub drpArticles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not TypeOf (drpArticles.SelectedValue) Is Decimal Then
    '        Exit Sub
    '    End If
    '    BindArticlesNo(drpArticles.SelectedValue)
    'End Sub

    Private Sub BindArticlesNo(ByVal ItemId As Double)
        Try
            ObjPriDt = New DataTable
            ObjBevRec = New CWPlusBL.Accor.ClsBeverageReconComment
            'ObjPriDt = ObjBevRec.FunFetchMCItems(ItemId)
            lblArticleNo.Text = ObjPriDt.Rows(0)("itemno")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjBevRec = Nothing
        End Try
    End Sub


    Private Sub grdsize_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBevRecon.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdBevRecon("Idn", e.RowIndex).Value
        DtBusinessDate.Value = grdBevRecon("Date", e.RowIndex).Value
        drpCostCenter.SelectedValue = grdBevRecon("CostCenterId", e.RowIndex).Value
        lblArticleID.Text = grdBevRecon("ItemId", e.RowIndex).Value
        txtArticleName.Text = grdBevRecon("ItemName", e.RowIndex).Value
        lblArticleNo.Text = grdBevRecon("ItemNo", e.RowIndex).Value
        txtQuantity.Text = grdBevRecon("Quantity", e.RowIndex).Value
        txtValue.Text = grdBevRecon("Value", e.RowIndex).Value
        chkBreakage.Checked = grdBevRecon("IsBreakage", e.RowIndex).Value
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
        FunDelete()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub imgNew_Click(sender As System.Object, e As System.EventArgs) Handles imgNew.Click
        ClrScreen()
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        InitScreen()
    End Sub

    Private Sub btnSeach_Click(sender As System.Object, e As System.EventArgs) Handles btnSeach.Click
        GblFormName = Me.Name
        frmSearchArticle.StartPosition = FormStartPosition.CenterScreen
        frmSearchArticle.Show()
    End Sub
End Class