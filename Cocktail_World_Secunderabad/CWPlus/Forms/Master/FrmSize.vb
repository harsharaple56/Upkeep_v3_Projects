Public Class FrmSize
    Dim ObjSize As CWPlusBL.Master.ClsSize
    Dim ObjDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"
    Private Sub ClrScreen()
        txtsize.Clear()
        lblid.Text = 0
    End Sub

    Private Sub InitScreen()
        Try
            ObjSize = New CWPlusBL.Master.ClsSize
            ObjDt = New DataTable
            ObjDt = ObjSize.FunFetch
            grdsize.DataSource = Nothing
            grdsize.DataSource = ObjDt
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjSize) Then
                ObjSize = Nothing
            End If
        End Try
        grdsize.Columns("SizeID").Visible = False
    End Sub
    
    Public Function Save() As Boolean
        Save = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Size")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Size")
                Exit Function
            End If
        End If
        If txtsize.Text = "" Then
            MsgBox("Enter Size Name", MsgBoxStyle.Critical, "Size")
            Exit Function
        End If
        Try
            ObjSize = New CWPlusBL.Master.ClsSize
            ObjSize.SizeID = lblid.Text
            ObjSize.Sizedesc = txtsize.Text
            ObjSize.UserName = gblUserName
            Save = ObjSize.FunSave
            MsgBox(ObjSize.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjSize) Then
                ObjSize = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If lblid.Text = 0 Then
            MsgBox("Select Size to delete", MsgBoxStyle.Critical, "Size")
            Exit Function
        End If
        Try
            ObjSize = New CWPlusBL.Master.ClsSize
            ObjSize.SizeID = lblid.Text
            ObjSize.UserName = gblUserName
            FunDelete = ObjSize.FunDelete
            MsgBox(ObjSize.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjSize) Then
                ObjSize = Nothing
            End If
        End Try
    End Function

#End Region
    Private Sub FrmSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        InitScreen()
    End Sub
    Private Sub grdsize_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdsize.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdsize("SizeID", e.RowIndex).Value
        txtsize.Text = grdsize("SizeDesc", e.RowIndex).Value
    End Sub
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Save()
    End Sub
    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'FunDelete()
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
End Class