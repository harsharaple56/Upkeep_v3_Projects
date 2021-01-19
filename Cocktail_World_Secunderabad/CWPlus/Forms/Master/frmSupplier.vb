Imports System.Windows

Public Class frmSupplier
    Dim ObjSupplier As CWPlusBL.Master.ClsSupplier
    Dim ObjDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(GroupBox1)
    End Sub


#Region "Procedures"
    Private Sub ClrScreen()
        lblID.Text = 0
        txtAddress.Clear()
        txtCity.Clear()
        txtEmail.Clear()
        txtPincode.Clear()
        txtSupplierName.Clear()
        txtTelephone.Clear()
        txtCode.Clear()
    End Sub

    Private Sub InitScreen()
        Try
            ObjSupplier = New CWPlusBL.Master.ClsSupplier
            ObjDt = New DataTable
            ObjDt = ObjSupplier.FunFetch
            grdSupplier.DataSource = Nothing
            grdSupplier.DataSource = ObjDt
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjSupplier) Then
                ObjSupplier = Nothing
            End If
        End Try
        grdSupplier.Columns("SupplierId").Visible = False
    End Sub

    Public Function Save() As Boolean
        Save = False
        If lblID.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Supplier")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Supplier")
                Exit Function
            End If
        End If
        If txtSupplierName.Text = "" Then
            MsgBox("Enter Supplier Name", MsgBoxStyle.Critical, "Supplier")
            Exit Function
            'ElseIf Not txtEmail.Text.Contains("@") Then
            '    MsgBox("Invalid email format", MsgBoxStyle.Critical, "Supplier")
            '    Exit Function

        End If
        Try
            ObjSupplier = New CWPlusBL.Master.ClsSupplier
            ObjSupplier.SupplierID = lblID.Text
            ObjSupplier.SupplierName = txtSupplierName.Text
            ObjSupplier.Address = txtAddress.Text
            ObjSupplier.City = txtCity.Text
            ObjSupplier.Telephone = txtTelephone.Text
            ObjSupplier.Email = txtEmail.Text
            ObjSupplier.Pincode = txtPincode.Text
            ObjSupplier.Code = txtCode.Text
            ObjSupplier.UserName = gblUserName
            Save = ObjSupplier.FunSave
            MsgBox(ObjSupplier.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjSupplier) Then
                ObjSupplier = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If Not GblBoolDelete Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Supplier")
        End If
        If lblID.Text = 0 Then
            MsgBox("Select Supplier to delete", MsgBoxStyle.Critical, "Supplier")
            Exit Function
        End If
        Try
            ObjSupplier = New CWPlusBL.Master.ClsSupplier
            ObjSupplier.SupplierID = lblID.Text
            ObjSupplier.UserName = gblUserName
            FunDelete = ObjSupplier.FunDelete
            MsgBox(ObjSupplier.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjSupplier) Then
                ObjSupplier = Nothing
            End If
        End Try
    End Function

#End Region

    Private Sub frmSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        InitScreen()

    End Sub
    Private Sub grdSupplier_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSupplier.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblID.Text = grdSupplier("Supplierid", e.RowIndex).Value
        txtAddress.Text = grdSupplier("address", e.RowIndex).Value
        txtCity.Text = grdSupplier("city", e.RowIndex).Value
        txtEmail.Text = grdSupplier("email", e.RowIndex).Value
        txtPincode.Text = grdSupplier("pincode", e.RowIndex).Value
        txtSupplierName.Text = grdSupplier("suppliername", e.RowIndex).Value
        txtTelephone.Text = grdSupplier("telephone", e.RowIndex).Value
        txtCode.Text = grdSupplier("suppliercode", e.RowIndex).Value
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
    
    
    Private Sub txtEmail_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmail.Validating
        Dim rEMail As New System.Text.RegularExpressions.Regex("^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
        If txtEmail.Text.Length > 0 Then
            If Not rEMail.IsMatch(txtEmail.Text) Then
                MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtEmail.SelectAll()
                e.Cancel = True
            End If
        End If
    End Sub
End Class