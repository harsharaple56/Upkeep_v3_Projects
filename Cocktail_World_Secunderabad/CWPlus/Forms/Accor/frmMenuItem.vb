Imports CWPlusBL.Accor
Public Class frmMenuItem
    Dim ObjMenuItem As ClsMenuItem

    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"
    Private Sub ClrScreen()
        txtItemName.Clear()
        txtItemCode.Clear()
        drpRevenueCenter.SelectedValue = 0
        lblid.Text = 0
    End Sub

    Private Sub InitScreen()
        Try
            ObjMenuItem = New ClsMenuItem
            ObjPriDt = New DataTable
            ObjPriDt = ObjMenuItem.FunFetch
            grdDiscount.DataSource = Nothing
            grdDiscount.DataSource = ObjPriDt
            grdDiscount.Columns("MenuItemID").Visible = False
            grdDiscount.Columns("RevenueCenterID").Visible = False
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjPriDt) Then
                ObjPriDt = Nothing
            End If
            If Not IsNothing(ObjMenuItem) Then
                ObjMenuItem = Nothing
            End If
        End Try

    End Sub
    Private Sub BindRevenueCenters()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjPriDt = ObjCls.FunFetchRevenueCenters()
            ComboBindingTemplate(drpRevenueCenter, ObjPriDt, "revenuecentername", "revenuecenterid")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub
    Public Function Save() As Boolean
        Save = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Menu Item")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Menu Item")
                Exit Function
            End If
        End If
        If txtItemName.Text = "" Then
            MsgBox("Enter Item Name", MsgBoxStyle.Information, "Menu Item")
            Exit Function
        ElseIf txtItemCode.Text = "" Then
            MsgBox("Enter Item Code", MsgBoxStyle.Information, "Menu Item")
            Exit Function
        ElseIf Not drpRevenueCenter.SelectedValue > 0 Then
            MsgBox("Select revenue Center", MsgBoxStyle.Information, "Menu Item")
            Exit Function
        End If
        Try
            ObjMenuItem = New ClsMenuItem
            ObjMenuItem.MenuItemID = lblid.Text
            ObjMenuItem.ItemCode = txtItemCode.Text
            ObjMenuItem.ItemName = txtItemName.Text
            ObjMenuItem.RevenueCenterID = drpRevenueCenter.SelectedValue
            ObjMenuItem.UserName = gblUserName
            Save = ObjMenuItem.FunSave
            MsgBox(ObjMenuItem.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjMenuItem) Then
                ObjMenuItem = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If lblid.Text = 0 Then
            MsgBox("Select .Discount to delete", MsgBoxStyle.Critical, "Menu Item")
            Exit Function
        End If
        Try
            ObjMenuItem = New ClsMenuItem
            ObjMenuItem.MenuItemID = lblid.Text
            ObjMenuItem.UserName = gblUserName
            FunDelete = ObjMenuItem.FunDelete
            MsgBox(ObjMenuItem.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjMenuItem) Then
                ObjMenuItem = Nothing
            End If
        End Try
    End Function

#End Region
    Private Sub FrmSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        BindRevenueCenters()
        InitScreen()
    End Sub

    Private Sub grdsize_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDiscount.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdDiscount("MenuItemID", e.RowIndex).Value
        txtItemName.Text = grdDiscount("ItemName", e.RowIndex).Value
        txtItemCode.Text = grdDiscount("ItemCode", e.RowIndex).Value
        drpRevenueCenter.SelectedValue = grdDiscount("RevenueCenterID", e.RowIndex).Value
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