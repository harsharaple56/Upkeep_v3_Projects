Public Class frmDesignation
    Dim ObjDesignaion As CWPlusBL.Accor.ClsDesignation
    Dim ObjDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"
    Private Sub ClrScreen()
        txtDesignation.Text = ""
        lblid.Text = 0
        drpEvalDepartment.SelectedValue = 0
    End Sub

    Private Sub InitScreen()
        Try
            ObjDesignaion = New CWPlusBL.Accor.ClsDesignation
            ObjDt = New DataTable
            ObjDt = ObjDesignaion.FunFetch
            grdDesignation.DataSource = Nothing
            grdDesignation.DataSource = ObjDt
            grdDesignation.Columns("DesignationId").Visible = False
            grdDesignation.Columns("EvalDeptId").Visible = False
            grdDesignation.Columns("DesignationDesc").HeaderText = "Designation"
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjDesignaion) Then
                ObjDesignaion = Nothing
            End If
        End Try

    End Sub

    Public Function Save() As Boolean
        Save = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Designation")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Designation")
                Exit Function
            End If
        End If
        If txtDesignation.Text = "" Then
            MsgBox("Enter Designation", MsgBoxStyle.Information, "Designation")
            Exit Function
        End If
        Try
            ObjDesignaion = New CWPlusBL.Accor.ClsDesignation
            ObjDesignaion.DesignationId = lblid.Text
            ObjDesignaion.DesignationDsec = txtDesignation.Text
            ObjDesignaion.EvalDepartmentId = drpEvalDepartment.SelectedValue
            ObjDesignaion.UserName = gblUserName
            Save = ObjDesignaion.FunSave
            MsgBox(ObjDesignaion.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjDesignaion) Then
                ObjDesignaion = Nothing
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
            ObjDesignaion = New CWPlusBL.Accor.ClsDesignation
            ObjDesignaion.DesignationId = lblid.Text
            ObjDesignaion.UserName = gblUserName
            FunDelete = ObjDesignaion.FunDelete
            MsgBox(ObjDesignaion.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDesignaion) Then
                ObjDesignaion = Nothing
            End If
        End Try
    End Function

#End Region


    Private Sub BindDepartments()
        Dim ObjClsDept As CWPlusBL.Accor.ClsEvalDepartment
        Try
            ObjDt = New DataTable
            ObjClsDept = New CWPlusBL.Accor.ClsEvalDepartment
            ObjDt = ObjClsDept.FunFetch
            ComboBindingTemplate(drpEvalDepartment, ObjDt, "EvalDeptDesc", "EvalDeptId")
        Catch ex As Exception
            Throw ex
        Finally
            ObjDt = Nothing
            ObjClsDept = Nothing
        End Try
    End Sub

    Private Sub FrmSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        BindDepartments()
        InitScreen()
    End Sub

    Private Sub grdsize_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDesignation.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdDesignation("DesignationId", e.RowIndex).Value
        txtDesignation.Text = grdDesignation("DesignationDesc", e.RowIndex).Value
        drpEvalDepartment.SelectedValue = grdDesignation("EvalDeptId", e.RowIndex).Value
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
End Class