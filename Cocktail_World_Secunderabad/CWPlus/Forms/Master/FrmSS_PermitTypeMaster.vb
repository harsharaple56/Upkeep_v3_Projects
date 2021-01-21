Imports System.Data
Imports CWPlusBL.Master

Public Class FrmSS_PermitTypeMaster
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
    End Sub

    Public Sub ClearScreen()
        lblErrorMsg.Text = ""
        lblPermitTypeID.Text = 0
        txtPermitType.Clear()
        lblErrorMsg.Visible = False
        lblPermitTypeID.Visible = False


    End Sub
    Public Sub initScreen()

        Dim ObjDtPermitType As New ClsPermitTypeMaster
        Dim ObjPriDt As New DataTable
        Try

            ObjPriDt = ObjDtPermitType.FunFetch
            grdPermitType.DataSource = Nothing
            grdPermitType.DataSource = ObjPriDt
            ClearScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtPermitType) = False Then
                ObjDtPermitType = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
        grdPermitType.Columns("permitdesc").Width = 150
        grdPermitType.Columns("permitdesc").HeaderText = "Permit Type"
        grdPermitType.Columns("PermittypeId").Visible = False
    End Sub
    Private Sub FrmSS_PermitTypeMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        initScreen()

    End Sub
    Public Function Save() As Boolean
        Save = False

        If txtPermitType.Text = "" Then
            MsgBox("Enter Permit Type")
            Exit Function
        End If
        Dim ObjDtPermitType As New ClsPermitTypeMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjDtPermitType.PermitTypeID = lblPermitTypeID.Text
            ObjDtPermitType.PermitTypeDesc = txtPermitType.Text
            ObjDtPermitType.UserName = gblUserName

            Save = ObjDtPermitType.FunSave()
            MsgBox(ObjDtPermitType.ErrorMsg)
            Validation()
            initScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtPermitType) = False Then
                ObjDtPermitType = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try

    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If Not GblBoolDelete Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Permit Type")
            Exit Function
        End If
        If lblPermitTypeID.Text = 0 Then
            MsgBox("Select Permit Type to delete", MsgBoxStyle.Information)
            Exit Function
        End If
        If lblPermitTypeID.Text = 0 Then
            MsgBox("Select Permit Type to delete", MsgBoxStyle.Critical, "Permit Type")
            Exit Function
        End If
        Dim ObjDtPermitType As New ClsPermitTypeMaster
        Try
            ObjDtPermitType.PermitTypeID = lblPermitTypeID.Text
            ObjDtPermitType.UserName = gblUserName
            FunDelete = ObjDtPermitType.FunDelete
            MsgBox(ObjDtPermitType.ErrorMsg)
            ClearScreen()
            initScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtPermitType) Then
                ObjDtPermitType = Nothing
            End If
        End Try

    End Function

    Public Sub Validation()
        If lblErrorMsg.Text = "Permit Type Already exists" Then
            MsgBox("Permit Type Already exists")
        End If
    End Sub
    Private Sub grdPermitType_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPermitType.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblPermitTypeID.Text = grdPermitType("PermitTypeID", e.RowIndex).Value
        txtPermitType.Text = grdPermitType("PermitDesc", e.RowIndex).Value
    End Sub
    Private Sub btnSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If txtPermitType.Text = "" Then
        '    MsgBox("Enter Permit Type")
        '    Exit Sub
        'End If
        'If Save() = True Then
        '    initScreen()

        'Else
        '    If lblErrorMsg.Text = "Permit Type Already exists" Then
        '        MsgBox("Permit Type Already exists")

        '    End If
        'End If
    End Sub
    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If lblPermitTypeID.Text = 0 Then
        '    MsgBox("Select Permit Type to delete", MsgBoxStyle.Information)
        '    Exit Sub
        'End If
        'FunDelete()
    End Sub

    Public Sub SaveCheck()
        If lblPermitTypeID.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Permit Type")
                Exit Sub
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Permit Type")
                Exit Sub
            End If
        End If
        If txtPermitType.Text = "" Then
            MsgBox("Enter Permit Type")
            Exit Sub
        End If
        If Save() = True Then
            initScreen()

        Else
            If lblErrorMsg.Text = "Permit Type Already exists" Then
                MsgBox("Permit Type Already exists")

            End If
        End If
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        SaveCheck()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
       
        FunDelete()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
End Class