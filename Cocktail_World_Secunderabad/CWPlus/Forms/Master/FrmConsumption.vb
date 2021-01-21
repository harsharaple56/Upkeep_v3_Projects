Imports System.Data
Imports CWPlusBL.Master

Public Class FrmConsumption
    Dim chk As Boolean = False
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
    End Sub

    Private Sub FrmConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        lblConsumptionID.Visible = False
        BindCategory()
        FunFetch()
    End Sub
    Public Sub BindCategory()
        Dim ObjCategory As New ClsCategory
        Dim ObjDt As New DataTable
        Try
            ObjDt = ObjCategory.FunFetch
            cmbcategory.DataSource = Nothing
            ComboBindingTemplate(cmbcategory, ObjDt, "CategoryDesc", "CategoryID")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategory) Then
                ObjCategory = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub
    Public Sub ClearScreen()
        lblConsumptionID.Text = 0
        lblConsumptionID.Visible = False
    End Sub

    'Public Function BindComboSize(ByVal SrcData As DataTable, ByVal ValueField As String, ByVal DisplayField As String) As DataTable
    '    Dim dr As DataRow
    '    dr = SrcData.NewRow
    '    dr(DisplayField) = "Speg"
    '    dr(DisplayField) = "Lpeg"
    '    dr(ValueField) = "0"
    '    dr(ValueField) = "1"
    '    SrcData.Rows.InsertAt(dr, 0)
    '    SrcData.Rows.InsertAt(dr, 1)
    '    Return SrcData
    'End Function


    Public Sub BindSize()
        Dim ObjSize As New ClsCategorySizelinlup
        Dim ObjPridt As New DataTable
        
        Try
            ObjSize.CategoryID = cmbcategory.SelectedValue
            ObjSize.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjPridt = ObjSize.FunFetch
            ObjPridt.Rows.Add(-1, 0, "", 0, "", 0, "", "Speg", "", 0, "")
            ObjPridt.Rows.Add(-2, 0, "", 0, "", 0, "", "Lpeg", "", 0, "")
            cmbsize.DataSource = Nothing
            ComboBindingTemplate(cmbsize, ObjPridt, "Alias", "CategorySizeLinkID")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjSize) Then
                ObjSize = Nothing
            End If
            If Not IsNothing(ObjPridt) Then
                ObjPridt = Nothing
            End If
        End Try
    End Sub

    Public Function Save() As Boolean
        Save = False
        If lblConsumptionID.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Consumption")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Consumption")
                Exit Function
            End If
        End If
        If Not cmbcategory.SelectedValue > 0 Then
            MsgBox("Select category ", MsgBoxStyle.Critical, "Consumption")
            Exit Function
        ElseIf cmbsize.Text = "" Then
            MsgBox("Select Size ", MsgBoxStyle.Critical, "Consumption")
            Exit Function
        ElseIf txtQty.Text = "" Then
            MsgBox("Enter quantity", MsgBoxStyle.Critical, "Consumption")
            Exit Function
        End If
        Dim objConsumption As New ClsConsumptionMaster
        Dim ObjDt As New DataTable
        Try

            objConsumption.ConsumptionID = lblConsumptionID.Text
            objConsumption.CategoryID = cmbcategory.SelectedValue
            objConsumption.CategorySizeLinkID = cmbsize.SelectedValue

            If cmbsize.SelectedValue = -1 Then
                objConsumption.MlType = "Sp"
                objConsumption.DblPubCategorySizeLinkID = Nothing
            End If

            If cmbsize.SelectedValue = -2 Then
                objConsumption.MlType = "Lp"
                objConsumption.DblPubCategorySizeLinkID = Nothing
            End If

            objConsumption.Qty = txtQty.Text
            objConsumption.UserName = gblUserName
            Save = objConsumption.FunSave
            MsgBox(objConsumption.ErrorMsg)
            FunFetch()
            BindCategory()
            BindSize()

            txtQty.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(objConsumption) Then
                objConsumption = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try

    End Function

    Public Sub FunFetch()
        grdConsumption.Rows.Clear()
        Dim ObjPriConsumption As New ClsConsumptionMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjPriDt = ObjPriConsumption.FunFetch()
            For rwctr = 0 To ObjPriDt.Rows.Count - 1
                grdConsumption.Rows.Add()
                grdConsumption("consumptionID", rwctr).Value = ObjPriDt.Rows(rwctr)("consumptionID")
                grdConsumption("CategoryID", rwctr).Value = ObjPriDt.Rows(rwctr)("CategoryID")
                grdConsumption("CategoryDesc", rwctr).Value = ObjPriDt.Rows(rwctr)("CategoryDesc")
                grdConsumption("alias1", rwctr).Value = ObjPriDt.Rows(rwctr)("alias1")
                grdConsumption("CategorySizeLinkID", rwctr).Value = ObjPriDt.Rows(rwctr)("CategorySizeLinkID")
                grdConsumption("Qty", rwctr).Value = ObjPriDt.Rows(rwctr)("Qty")
                grdConsumption("Size", rwctr).Value = ObjPriDt.Rows(rwctr)("Size")
            Next
            grdConsumption.Columns("consumptionID").Visible = False
            grdConsumption.Columns("CategorySizeLinkID").Visible = False
            grdConsumption.Columns("alias1").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjPriConsumption) = False Then
                ObjPriConsumption = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Public Function FunDelete() As Boolean
        Dim ObjDtConsum As New ClsConsumptionMaster
        FunDelete = False
        If Not GblBoolDelete Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Consumption")
            Exit Function
        End If
        If lblConsumptionID.Text = 0 Then
            MsgBox("Select row to delete", MsgBoxStyle.Information)
            Exit Function
        End If
        Try
            ObjDtConsum.ConsumptionID = lblConsumptionID.Text
            ObjDtConsum.UserName = gblUserName
            FunDelete = ObjDtConsum.FunDelete
            MsgBox(ObjDtConsum.ErrorMsg)
            FunFetch()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtConsum) Then
                ObjDtConsum = Nothing
            End If
        End Try

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Save() = True Then
        '    FunFetch()
        '    BindCategory()
        '    BindSize()

        '    txtQty.Text = ""
        'End If

    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcategory.SelectedIndexChanged
        If TypeOf cmbcategory.SelectedValue Is Decimal Then
            BindSize()
        End If
    End Sub

    
    Private Sub grdConsumption_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdConsumption.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim ObjDtconsum As New ClsConsumptionMaster
        Dim ObjPriDt As New DataTable
        Try
            lblConsumptionID.Text = grdConsumption.Item("ConsumptionID", e.RowIndex).Value
            ObjDtconsum.ConsumptionID = lblConsumptionID.Text
            ObjPriDt = ObjDtconsum.FunFetch()

            If ObjPriDt.Rows.Count > 0 Then
                cmbcategory.SelectedValue = ObjPriDt.Rows(0).Item("categoryID")
                cmbsize.SelectedValue = ObjPriDt.Rows(0).Item("CategorySizeLinkID")
                txtQty.Text = ObjPriDt.Rows(0).Item("Qty")

            End If
          

        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjDtconsum) = False Then
                ObjDtconsum = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If lblConsumptionID.Text = 0 Then
        '    MsgBox("Select row to delete", MsgBoxStyle.Information)
        '    Exit Sub
        'End If
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

 
    Private Sub txtQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
          Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 56) Then
            e.Handled = True
        End If

        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
    End Sub
End Class