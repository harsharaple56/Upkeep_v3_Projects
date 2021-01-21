Public Class Frm_MR_Department
    Dim ObjDept As CWPlusBL.Marriot.ClsMRDepartment
    Dim ObjDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"
    Private Sub ClrScreen()
        txtDepartment.Text = ""
        txtDeptCode.Text = ""
        lblid.Text = 0
    End Sub

    Private Sub InitScreen()
        Try
            ObjDept = New CWPlusBL.Marriot.ClsMRDepartment
            ObjDt = New DataTable
            ObjDt = ObjDept.FunFetch
            grdEvalDepartment.DataSource = Nothing
            grdEvalDepartment.DataSource = ObjDt
            grdEvalDepartment.Columns("EvalDeptId").Visible = False
            grdEvalDepartment.Columns("EvalDeptDesc").HeaderText = "Department"
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjDept) Then
                ObjDept = Nothing
            End If
        End Try

    End Sub

    Public Function Save() As Boolean
        Save = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Department")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Department")
                Exit Function
            End If
        End If
        If txtDepartment.Text = "" Then
            MsgBox("Enter Department", MsgBoxStyle.Information, "Department")
            Exit Function
        End If
        Try
            ObjDept = New CWPlusBL.Marriot.ClsMRDepartment
            ObjDept.EvalDepartmentId = lblid.Text
            ObjDept.MRDepartmentDesc = txtDepartment.Text
            ObjDept.MRDepartmentCode = txtDeptCode.Text
            ObjDept.UserName = gblUserName
            Save = ObjDept.FunSave
            MsgBox(ObjDept.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjDept) Then
                ObjDept = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If lblid.Text = 0 Then
            MsgBox("Select Designation to delete", MsgBoxStyle.Critical, "Designation")
            Exit Function
        End If
        Try
            ObjDept = New CWPlusBL.Marriot.ClsMRDepartment
            ObjDept.EvalDepartmentId = lblid.Text
            ObjDept.UserName = gblUserName
            FunDelete = ObjDept.FunDelete
            MsgBox(ObjDept.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDept) Then
                ObjDept = Nothing
            End If
        End Try
    End Function

#End Region
    Private Sub FrmSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        InitScreen()
    End Sub

    Private Sub grdsize_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdEvalDepartment.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdEvalDepartment("EvalDeptId", e.RowIndex).Value
        txtDepartment.Text = grdEvalDepartment("EvalDeptDesc", e.RowIndex).Value
        txtDeptCode.Text = grdEvalDepartment("Code", e.RowIndex).Value
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