Imports System.Data
Imports CWPlusBL.Master
Public Class FrmUserMaster
    
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
    End Sub
    Public Sub HideDefault()
        lblDefault.Visible = False
        chkDefault.Visible = False
    End Sub

    Private Sub InitScreen()

        HideDefault()
        Dim ObjDtUserName As New ClsUserMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjPriDt = ObjDtUserName.FunFetch
            grdUserName.DataSource = Nothing
            grdUserName.DataSource = ObjPriDt
            ClearScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtUserName) = False Then
                ObjDtUserName = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
        grdUserName.Columns("DefaultRole").Visible = False
    End Sub


    Private Sub FrmUserMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AssignRights(gblMenuDesc)
        InitScreen()
    End Sub
   
    Public Sub ClearScreen()
        lblErrorMsg.Visible = False
        lblUSerID.Text = 0
        lblUSerID.Visible = False
        txtUserName.Text = ""
        chkAdmin.Checked = False
        chkDefault.Checked = False
    End Sub
    Public Function Save() As Boolean
        Save = False
        If lblUSerID.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "User")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "User")
                Exit Function
            End If
        End If
        If txtUserName.Text = "" Then
            MsgBox("Please Enter User Name", MsgBoxStyle.Critical, "User")
            Exit Function
        End If

        Dim ObjDtUserName As New ClsUserMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjDtUserName.UserID = lblUSerID.Text

            ObjDtUserName.User = txtUserName.Text
            If chkAdmin.Checked = "True" Then
                ObjDtUserName.Administrator = 1
            Else
                ObjDtUserName.Administrator = 0
            End If

            If chkDefault.Checked = "True" Then
                ObjDtUserName.DefaultRole = 1
            Else
                ObjDtUserName.DefaultRole = 0

            End If

            ObjDtUserName.UserName = gblUserName
            Save = ObjDtUserName.FunSave()
            MsgBox(ObjDtUserName.ErrorMsg)

            InitScreen()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtUserName) = False Then
                ObjDtUserName = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Function


    Public Function FunDelete() As Boolean
        Dim ObjDtUserName As New ClsUserMaster
        FunDelete = False
        If lblUSerID.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "User")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "User")
                Exit Function
            End If
        End If
        If lblUSerID.Text = 0 Then
            MsgBox("Select UserName to delete", MsgBoxStyle.Information)
            Exit Function
        End If
        Try
            ObjDtUserName.UserID = lblUSerID.Text
            ObjDtUserName.UserName = gblUserName
            FunDelete = ObjDtUserName.FunDelete
            MsgBox(ObjDtUserName.ErrorMsg)
            ClearScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtUserName) Then
                ObjDtUserName = Nothing
            End If
        End Try

    End Function

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lblUSerID.Text = 0 Then
            MsgBox("Select UserName to delete", MsgBoxStyle.Information)
            Exit Sub
        End If
        FunDelete()
    End Sub

    Private Sub grdUserName_CellDoubleClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdUserName.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim ObjDtUserName As New ClsUserMaster
        Dim ObjPriDt As New DataTable
        Try

            lblUSerID.Text = grdUserName.Item("UserID", e.RowIndex).Value
            ObjDtUserName.UserID = lblUSerID.Text
            ObjPriDt = ObjDtUserName.FunFetch()
            If ObjPriDt.Rows.Count > 0 Then
                txtUserName.Text = ObjPriDt.Rows(0).Item("User")

                If ObjPriDt.Rows(0).Item("Administrator") = "True" Then
                    chkAdmin.Checked = True

                ElseIf ObjPriDt.Rows(0).Item("Administrator") = "False" Then
                    chkAdmin.Checked = False

                End If

                If ObjPriDt.Rows(0).Item("DefaultRole") = "True" Then
                    chkDefault.Checked = True

                ElseIf ObjPriDt.Rows(0).Item("DefaultRole") = "False" Then

                    chkDefault.Checked = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjDtUserName) = False Then
                ObjDtUserName = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjDtUserName = Nothing
            End If
        End Try
    End Sub

    'Private Sub btnSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    Save()
    'End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
      
        FunDelete()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    
End Class