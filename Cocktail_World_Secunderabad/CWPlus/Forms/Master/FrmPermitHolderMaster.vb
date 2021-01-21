Imports System.Data
Imports CWPlusBL.Master

Public Class FrmPermitHolderMaster
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
    End Sub
    

    Public Sub BindDropDown()
        Dim ObjDtPermitType As New ClsPermitTypeMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjPriDt = ObjDtPermitType.FunFetch
            cmbPermitType.DataSource = Nothing
            ComboBindingTemplate(cmbPermitType, ObjPriDt, "PermitDesc", "PermitTypeID")
           
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtPermitType) Then
                ObjDtPermitType = Nothing
            End If
            If Not IsNothing(ObjPriDt) Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub
    Public Sub ClearScreen()
        txtExpiredate.Text = ""
        txtPermitHolderName.Text = ""
        txtPermitNumber.Text = ""
        lblPermitHolderID.Text = 0
        lblPermitHolderID.Visible = False
        lblErrorMsg.Visible = False

    End Sub
    Public Sub initScreen()
        Dim ObjDtPermitHolder As New ClsPermitHolderMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjPriDt = ObjDtPermitHolder.FunFetch
            grdPermitHolder.DataSource = Nothing
            grdPermitHolder.DataSource = ObjPriDt
            grdPermitHolder.Columns("PermitExpireDate").Width = 140
            grdPermitHolder.Columns("PermitHolderNumber").Width = 140
            grdPermitHolder.Columns("PermitHolderName").Width = 140
            grdPermitHolder.Columns("PermitDesc").Width = 140

            grdPermitHolder.Columns("PermitExpireDate").HeaderText = "Permit Expire Date"
            grdPermitHolder.Columns("PermitHolderNumber").HeaderText = "Permit Holder Number"
            grdPermitHolder.Columns("PermitHolderName").HeaderText = "Permit Holder Name"
            grdPermitHolder.Columns("PermitDesc").HeaderText = "Permit Type"

            grdPermitHolder.Columns("PermitHolderID").Visible = False
            grdPermitHolder.Columns("PermitTypeID").Visible = False
            grdPermitHolder.Columns("dispfield").Visible = False

            lblCount.Text = "Number of Permit Holders: " & ObjPriDt.Rows.Count
            ClearScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtPermitHolder) = False Then
                ObjDtPermitHolder = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try

       
    End Sub
    Public Function Save() As Boolean
        Save = False

        If txtPermitHolderName.Text = "" Then
            MsgBox("Please Insert Permit Name")
            Exit Function
        End If
        If txtPermitNumber.Text = "" Then
            MsgBox("Please Insert Permit Number")
            Exit Function
        End If
        Dim ObjDtPermitHolder As New ClsPermitHolderMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjDtPermitHolder.PermitHolderID = lblPermitHolderID.Text
            ObjDtPermitHolder.PermitHolderNumber = txtPermitNumber.Text
            ObjDtPermitHolder.PermitHolderName = txtPermitHolderName.Text
            If chkLifeTime.Checked = True Then
                ObjDtPermitHolder.ExpireDate = "1/1/1900"
            Else
                ObjDtPermitHolder.ExpireDate = txtExpiredate.Text
            End If
            ObjDtPermitHolder.PermitTypeID = cmbPermitType.SelectedValue.ToString()
            ObjDtPermitHolder.UserName = gblUserName
            Save = ObjDtPermitHolder.FunSave()
            lblErrorMsg.Text = ObjDtPermitHolder.ErrorMsg
            Validation()
            initScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtPermitHolder) = False Then
                ObjDtPermitHolder = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Function

    Public Sub Validation()
        If lblErrorMsg.Text = "Permit Number Already exists" Then
            MsgBox("Permit Number Already exists")
            Exit Sub
        End If
    End Sub
    Public Function FunDelete() As Boolean
        Dim ObjDtPermitHolder As New ClsPermitHolderMaster
        FunDelete = False
        If Not GblBoolEdit Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Permit Holder")
            Exit Function
        End If
        If lblPermitHolderID.Text = 0 Then
            MsgBox("Select Permit Holder to delete", MsgBoxStyle.Information)
            Exit Function
        End If
        Try
            ObjDtPermitHolder.PermitHolderID = lblPermitHolderID.Text
            ObjDtPermitHolder.UserName = gblUserName

            FunDelete = ObjDtPermitHolder.FunDelete
            MsgBox(ObjDtPermitHolder.ErrorMsg)
            ClearScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtPermitHolder) Then
                ObjDtPermitHolder = Nothing
            End If
        End Try

    End Function

    Private Sub FrmPermitHolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        BindDropDown()
        initScreen()

        grdPermitHolder.Columns("dispfield").HeaderText = "Permit Holder Name"
        grdPermitHolder.Columns("PermitExpireDate").Width = 140
        grdPermitHolder.Columns("PermitHolderNumber").Width = 140
        grdPermitHolder.Columns("PermitHolderName").Width = 140
        grdPermitHolder.Columns("PermitDesc").Width = 140
        grdPermitHolder.Columns("dispfield").Visible = False
    End Sub

  
    Private Sub grdPermitHolder_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPermitHolder.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub
        cmbPermitType.SelectedValue = grdPermitHolder("PermitTypeID", e.RowIndex).Value
        lblPermitHolderID.Text = grdPermitHolder("PermitHolderID", e.RowIndex).Value
        txtPermitNumber.Text = grdPermitHolder("PermitHolderNumber", e.RowIndex).Value
        txtPermitHolderName.Text = grdPermitHolder("PermitHolderName", e.RowIndex).Value
        If (grdPermitHolder("PermitExpireDate", e.RowIndex).Value) = Trim("Life Time") Then
            chkLifeTime.Checked = True

        Else
            chkLifeTime.Checked = False
            txtExpiredate.Text = grdPermitHolder("PermitExpireDate", e.RowIndex).Value
        End If
    End Sub

    Private Sub chkLifeTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLifeTime.CheckedChanged
        If chkLifeTime.Checked = True Then
            txtExpiredate.Visible = False
            lblPermitExpireDate.Visible = False
        Else
            lblPermitExpireDate.Visible = True
            txtExpiredate.Visible = True
        End If
    End Sub

    Public Sub SaveCheck()
        If lblPermitHolderID.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Permit Holder")
                Exit Sub
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Permit Holder")
                Exit Sub
            End If
        End If
        If txtPermitHolderName.Text = "" Then
            MsgBox("Please Insert Permit Name")
            Exit Sub
        End If
        If txtPermitNumber.Text = "" Then
            MsgBox("Please Insert Permit Number")
            Exit Sub
        End If
        If Save() = True Then
            BindDropDown()
            initScreen()

        Else
            initScreen()
            Exit Sub

        End If
        initScreen()
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

    Private Sub txtPermitNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPermitNumber.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
           Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
    End Sub
End Class