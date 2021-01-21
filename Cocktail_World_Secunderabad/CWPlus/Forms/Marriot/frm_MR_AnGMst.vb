Public Class frm_MR_AnGMst
    Dim ObjDiscount As CWPlusBL.Marriot.ClsDiscount
    Dim ObjDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"
    Private Sub ClrScreen()
        txtDiscount.Text = ""
        lblid.Text = 0
        txtDeptCode.Text = ""
        drpEvalDepartment.SelectedValue = 0
        chkCredits.Checked = False
    End Sub

    Private Sub InitScreen()
        Try
            ObjDiscount = New CWPlusBL.Marriot.ClsDiscount
            ObjDt = New DataTable
            ObjDt = ObjDiscount.FunFetch
            grdDiscount.DataSource = Nothing
            grdDiscount.DataSource = ObjDt
            grdDiscount.Columns("DiscountID").Visible = False
            'grdDiscount.Columns("IsAngField").Visible = False
            'grdDiscount.Columns("IsCredit").Visible = False
            grdDiscount.Columns("DeptID").Visible = False
            grdDiscount.AutoResizeColumns()
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjDiscount) Then
                ObjDiscount = Nothing
            End If
        End Try

    End Sub

    Public Function Save() As Boolean
        Save = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Discount")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Discount")
                Exit Function
            End If
        End If
        If txtDiscount.Text = "" Then
            MsgBox("Enter Discount", MsgBoxStyle.Information, "Discount")
            Exit Function
        End If
        Try
            ObjDiscount = New CWPlusBL.Marriot.ClsDiscount
            ObjDiscount.DiscountID = lblid.Text
            ObjDiscount.Discount = txtDiscount.Text
            ObjDiscount.DeptId = drpEvalDepartment.SelectedValue
            ObjDiscount.Ang = chkAnG.Checked
            ObjDiscount.Credits = chkCredits.Checked
            ObjDiscount.DiscountCode = txtDeptCode.Text
            ObjDiscount.UserName = gblUserName
            Save = ObjDiscount.FunSave
            MsgBox(ObjDiscount.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjDiscount) Then
                ObjDiscount = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If lblid.Text = 0 Then
            MsgBox("Select .Discount to delete", MsgBoxStyle.Critical, "Discount")
            Exit Function
        End If
        Try
            ObjDiscount = New CWPlusBL.Marriot.ClsDiscount
            ObjDiscount.DiscountID = lblid.Text
            ObjDiscount.UserName = gblUserName
            FunDelete = ObjDiscount.FunDelete
            MsgBox(ObjDiscount.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDiscount) Then
                ObjDiscount = Nothing
            End If
        End Try
    End Function

#End Region
    Private Sub FrmSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        chkAnG.Checked = True
        InitScreen()
        BindDepartments()
    End Sub

    Private Sub BindDepartments()
        Dim ObjClsDept As CWPlusBL.Marriot.ClsMRDepartment
        Try
            ObjDt = New DataTable
            ObjClsDept = New CWPlusBL.Marriot.ClsMRDepartment
            ObjDt = ObjClsDept.FunFetch
            ComboBindingTemplate(drpEvalDepartment, ObjDt, "EvalDeptDesc", "EvalDeptId")
        Catch ex As Exception
            Throw ex
        Finally
            ObjDt = Nothing
            ObjClsDept = Nothing
        End Try
    End Sub

    Private Sub grdsize_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDiscount.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdDiscount("DiscountID", e.RowIndex).Value
        txtDiscount.Text = grdDiscount("A&GFields", e.RowIndex).Value
        txtDeptCode.Text = grdDiscount("Code", e.RowIndex).Value
        chkAnG.Checked = grdDiscount("IsAngField", e.RowIndex).Value
        chkCredits.Checked = grdDiscount("IsCredit", e.RowIndex).Value
        drpEvalDepartment.SelectedValue = grdDiscount("DeptID", e.RowIndex).Value

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

    Private Sub imgNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgNew.Click
        ClrScreen()
    End Sub


End Class