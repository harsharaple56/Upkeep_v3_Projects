Public Class dlgReportSearch
    Dim Objpurchase As CWPlusBL.Master.Clspurchase
    Dim Objcategory As CWPlusBL.Master.ClsCategory
    Dim ObjAssignctcode As CWPlusBL.Master.AssignCocktailCode
    Dim ObjCategorySizeLnkUp As CWPlusBL.Master.ClsCategorySizelinlup
    Dim objdt As DataTable
    Public IntForm As Integer
    Public Sub BindBrand(ByVal BrandOpeningID As Double)
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable
            Objpurchase.BrandopeningID = BrandOpeningID
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            objdt = Objpurchase.BindBrandOpening
            ComboBindingTemplate(cmbBrand, objdt, "BrandDesc", "BrandID")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
        End Try
    End Sub

    Public Sub BindCategory()
        Try
            Objcategory = New CWPlusBL.Master.ClsCategory
            objdt = New DataTable
            objdt = Objcategory.FunFetch
            ComboBindingTemplate(cmbCategory, objdt, "Categorydesc", "CategoryID")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
            If Not IsNothing(Objcategory) Then
                Objcategory = Nothing
            End If
        End Try

    End Sub

    Private Sub BindSize(ByVal brandid As Double)
        Objpurchase = New CWPlusBL.Master.Clspurchase
        Dim ds As New DataSet
        Try

            Objpurchase.BrandID = cmbBrand.SelectedValue
            Objpurchase.LicenseID = MDI.cmbLicenseName.SelectedValue
            ds = Objpurchase.BindSizes
            ComboBindingTemplate(cmbSize, ds.Tables(0), "alias", "CategorySizeLinkUpID")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
        End Try

    End Sub

    Public Sub FetchCategorySizeLinkUp()
        Try
            ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
            ObjDt = New DataTable
            ObjCategorySizeLnkUp.CategoryID = cmbCategory.SelectedValue
            ObjCategorySizeLnkUp.LicenseID = MDI.cmbLicenseName.SelectedValue

            ObjDt = ObjCategorySizeLnkUp.FunFetch
            ComboBindingTemplate(cmbCategorySize, objdt, "alias", "CategorySizeLinkID")
            
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    Public Sub BindCocktail()
        Try
            ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
            Dim ObjDt As New DataTable
            ObjAssignctcode.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDt = ObjAssignctcode.FetchCocktailCodeByLicenseWise
            ComboBindingTemplate(cmbCocktail, ObjDt, "CocktailName", "CocktailID")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjAssignctcode) Then
                ObjAssignctcode = Nothing
            End If
        
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Function HandleText(ByVal cmb As ComboBox) As String
        HandleText = ""
        If Not cmb.SelectedValue = 0 Then
            HandleText = cmb.Text
        End If
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If IntForm = 1 Then
            FrmCocktailReport._Brand = HandleText(cmbBrand)
            FrmCocktailReport._Category = HandleText(cmbCategory)
            If Not cmbSize.SelectedValue = 0 Then
                FrmCocktailReport._Size = HandleText(cmbSize)
            Else
                FrmCocktailReport._Size = HandleText(cmbCategorySize)
            End If

            FrmCocktailReport._Cocktail = HandleText(cmbCocktail)
        ElseIf IntForm = 2 Then
            FrmTransferReport._Brand = HandleText(cmbBrand)
            FrmTransferReport._Category = HandleText(cmbCategory)
            If Not cmbSize.SelectedValue = 0 Then
                FrmTransferReport._Size = HandleText(cmbSize)
            Else
                FrmTransferReport._Size = HandleText(cmbCategorySize)
            End If

            FrmTransferReport._Cocktail = HandleText(cmbCocktail)
        ElseIf IntForm = 3 Then
            frmBrandwise_Monthly_._Brand = HandleText(cmbBrand)
            frmBrandwise_Monthly_._Category = HandleText(cmbCategory)
            If Not cmbSize.SelectedValue = 0 Then
                frmBrandwise_Monthly_._Size = HandleText(cmbSize)
            Else
                frmBrandwise_Monthly_._Size = HandleText(cmbCategorySize)
            End If

        End If
      
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dlgReportSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnOk
        BindBrand(0)
        BindCategory()
        BindCocktail()
    End Sub

    Private Sub cmbBrand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrand.SelectedIndexChanged
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf (cmbBrand.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        BindSize(cmbBrand.SelectedValue)
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf (cmbCategory.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        FetchCategorySizeLinkUp()
    End Sub
End Class