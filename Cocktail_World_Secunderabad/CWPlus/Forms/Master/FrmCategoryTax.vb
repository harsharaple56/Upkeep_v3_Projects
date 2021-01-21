Public Class FrmCategoryTax
    Dim objCategorytax As CWPlusBL.Master.ClscategoryTax
    Dim ObjCategory As CWPlusBL.Master.ClsCategory
    Dim ObjDt As DataTable
    Private Sub ClrScreen()
        lblid.Text = 0
        txttaxtype.Clear()
        txttaxperce.Clear()
        Cmbcategory.SelectedValue = -1
    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
    End Sub
    Private Sub InitScreen()
        Try
            objCategorytax = New CWPlusBL.Master.ClscategoryTax
            ObjDt = New DataTable
            ObjDt = objCategorytax.FunFetch
            grdcategorytax.DataSource = Nothing
            grdcategorytax.DataSource = ObjDt
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(Objcategory) Then
                Objcategory = Nothing
            End If
        End Try
        grdcategorytax.Columns("categoryID").Visible = False
        'grdcategorytax.Columns("categoryDesc").Visible = False
        grdcategorytax.Columns("categoryTaxID").Visible = False
        grdcategorytax.Columns("categoryDesc").Width = 140
        grdcategorytax.Columns("CategoryDesc").HeaderText = "Category"
        grdcategorytax.Columns("Taxpercetage").HeaderText = "Tax %"
    End Sub
    Private Sub BindCategory()
        Try
            ObjCategory = New CWPlusBL.Master.ClsCategory
            ObjDt = New DataTable
            ObjDt = ObjCategory.FunFetch

            Cmbcategory.DataSource = Nothing
            ComboBindingTemplate(Cmbcategory, ObjDt, "categorydesc", "categoryid")
           
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
    Public Function Save() As Boolean
        Save = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Category Tax")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Category Tax")
                Exit Function
            End If
        End If
        If Cmbcategory.SelectedValue = 0 Then
            MsgBox("Please Select Category", MsgBoxStyle.Critical, "Category Tax")
            Cmbcategory.Focus()
            Exit Function
        ElseIf txttaxtype.Text = "" Then
            MsgBox("Please Enter tax type", MsgBoxStyle.Critical, "Category Tax")
            Exit Function
        ElseIf txttaxperce.Text = "" Then
            MsgBox("Please Enter tax percentage", MsgBoxStyle.Critical, "Category Tax")
            Exit Function
        End If

        Try
            objCategorytax = New CWPlusBL.Master.ClscategoryTax
            objCategorytax.CategoryTaxID = lblid.Text
            objCategorytax.CategoryID = Cmbcategory.SelectedValue
            objCategorytax.Taxtype = txttaxtype.Text
            objCategorytax.TaxPercentage = txttaxperce.Text
            objCategorytax.UserName = gblUserName
            Save = objCategorytax.FunSave
            MsgBox(objCategorytax.ErrorMsg)
            InitScreen()
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(objCategorytax) Then
                ObjCategory = Nothing
            End If
        End Try
    End Function
    Public Function FunDelete() As Boolean
        FunDelete = False
        If Not GblBoolDelete Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Category Tax")
        End If
        If Cmbcategory.SelectedValue = 0 Then
            MsgBox("Select Category ")
            Exit Function
        End If
        Try
            objCategorytax = New CWPlusBL.Master.ClscategoryTax
            objCategorytax.CategoryTaxID = lblid.Text
            objCategorytax.UserName = gblUserName
            FunDelete = objCategorytax.FunDelete
            MsgBox(objCategorytax.ErrorMsg)
            InitScreen()
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(objCategorytax) Then
                objCategorytax = Nothing
            End If
        End Try

    End Function


    Private Sub FrmCategoryTax_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        BindCategory()
        InitScreen()
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Cmbcategory.SelectedValue = 0 Then
    '        MsgBox("Select Category ")
    '        Exit Sub
    '    End If
    '    Save()
    'End Sub

    Private Sub grdcategorytax_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        ' Dim dlgreport = MsgBox("Are You Sure Want To Delete It", MsgBoxStyle.YesNo)
        ' If dlgreport = DialogResult.Yes Then
        ' End If
    End Sub

    Private Sub grdcategorytax_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcategorytax.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdcategorytax("CategoryTaxID", e.RowIndex).Value
        txttaxtype.Text = grdcategorytax("taxtype", e.RowIndex).Value
        txttaxperce.Text = grdcategorytax("Taxpercetage", e.RowIndex).Value
        Cmbcategory.SelectedValue = grdcategorytax("CategoryId", e.RowIndex).Value
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Cmbcategory.SelectedValue = 0 Then
        '    MsgBox("Select Category ")
        '    Exit Sub
        'End If
        'FunDelete()
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click

        Save()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
      
        FunDelete()
    End Sub

    Private Sub txttaxperce_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttaxperce.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
           Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 56) Then
            e.Handled = True
        End If

        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If


    End Sub
End Class