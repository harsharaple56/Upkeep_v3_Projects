Imports CWPlusBL.Master
Imports System.Xml

Public Class SaleAutoBill


#Region "Variables"

    Dim gblTaxPercentage As Double
    Dim Objpurchase As CWPlusBL.Master.Clspurchase
    Dim Objcocktail As CWPlusBL.Master.ClsAutobilling
    Dim objlicense As CWPlusBL.Master.Utitity
    Dim ObjAssignctcode As CWPlusBL.Master.AssignCocktailCode
    Dim ObjSale As ClsSale
    Dim objdt As DataTable
    Dim ds As DataSet
    Dim xmldoc As XmlDocument
    Dim xmldocBrand As XmlDocument
    Dim xmldocCocktail As XmlDocument
    Dim xmldocPermitHolder As XmlDocument
    Dim ArrPermitList As New ArrayList
    Dim ArrBillNo As New ArrayList
    'Dim gloBillNo As Integer
    Private CounterArr As New ArrayList
    Dim vBillNo As Integer
    ' Dim gloBillEndNo As Integer
    Dim TotalBill As Integer

    Dim IsUserChangedValue As Boolean = True

    Dim spegAmt As Double
    Dim spegAmtTotal As Double
    Dim LpegAmt As Double
    Dim LpegAmtTotal As Double
    Dim BottalpegAmt As Double
    Dim BottalpegAmtTotal As Double

    ''For BottalWise Variable

    Dim HiddenConsumptionQty As Integer
    Dim spegBottal As Double
    Dim spegBottalTotal As Double
    Dim LpegBottal As Double
    Dim LpegBottalTotal As Double
    Dim Bottalpeg As Double
    Dim BottalpegTotal As Double

    Dim gblBrandOpeningID As Double
    ''
    Property gblMlType As String

#End Region

#Region "Procedures"

    Public Sub ComboBindingTemplate(ByVal cmb As ComboBox, ByVal dt As DataTable, ByVal dispfield As String, ByVal valuefield As String)

        With cmb
            .DataSource = BindCombo(dt, valuefield, dispfield)
            .DisplayMember = dispfield
            .ValueMember = valuefield
        End With
    End Sub

    Public Sub BindBrand(ByVal BrandOpeningID As Double)
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable
            Objpurchase.BrandopeningID = BrandOpeningID
            Objpurchase.LicenseID = gblLicenseID
            objdt = Objpurchase.BindBrandOpening
            If Not objdt.Rows.Count > 0 Then
                Exit Sub
            End If
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

    Private Sub BindSize(ByVal brandid As Double)
        Objpurchase = New CWPlusBL.Master.Clspurchase
        ds = New DataSet
        Try

            Objpurchase.BrandID = cmbbrand.SelectedValue
            Objpurchase.LicenseID = gblLicenseID
            ds = Objpurchase.BindSizes
            cmbsize.DataSource = Nothing
            With cmbsize
                .DataSource = ds.Tables(0)
                .DisplayMember = "alias"
                .ValueMember = "CategorySizeLinkUpID"
                .Text = ""
                .SelectedValue = -1
            End With
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
    Public Sub BindTaxType()
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            ds = New DataSet

            Objpurchase.BrandID = cmbbrand.SelectedValue
            Objpurchase.LicenseID = gblLicenseID

            ds = Objpurchase.BindSizes
            With cmbtaxtype
                .DataSource = ds.Tables(1)
                .DisplayMember = "Taxtype"
                .ValueMember = "CategoryTaxId"
                .Text = ""
                .SelectedValue = -1
            End With
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
    Public Sub BindCocktail()
        Try
            ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
            Dim ObjDt As New DataTable
            ObjAssignctcode.LicenseID = gblLicenseID
            ObjDt = ObjAssignctcode.FetchCocktailCodeByLicenseWise
            ComboBindingTemplate(cmbCocktail, ObjDt, "CocktailName", "CocktailID")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjAssignctcode) Then
                ObjAssignctcode = Nothing
            End If
            If Not IsNothing(ds) Then
                ds = Nothing
            End If
        End Try
    End Sub

    Public Sub BindPermitName()
        Dim ObjDtPermitHolder As New ClsPermitHolderMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjDtPermitHolder.ExpireDate = Dtdate.Value
            ObjDtPermitHolder.PermitHolderID = lblid.Text

            ObjPriDt = ObjDtPermitHolder.FunFetchPermitHolderExpiryDate
            ComboBindingTemplate(cmbPermitName, ObjPriDt, "dispfield", "PermitHolderID")
            If ObjPriDt.Rows.Count > 0 Then
                For index = 1 To ObjPriDt.Rows.Count - 1
                    ArrPermitList.Add(ObjPriDt.Rows(index).Item("PermitHolderID").ToString())
                Next
            End If

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
        'grdPermitType.Columns("DefaultRole").Visible = False

    End Sub
    Public Sub ClrScr()
        grdBrand.Rows.Clear()
        grdCocktail.Rows.Clear()
        grdPermitName.Rows.Clear()
        Dtdate.Value = DateTime.Now
    End Sub
    Private Function Brandxmlcolumns() As DataTable
        Dim dtXML As New DataTable
        dtXML.Columns.Add("billno")
        dtXML.Columns.Add("BrandOpeningID")
        dtXML.Columns.Add("BottleQty")
        dtXML.Columns.Add("Bottlerate")
        dtXML.Columns.Add("Speg")
        dtXML.Columns.Add("SpegRate")
        dtXML.Columns.Add("Lpeg")
        dtXML.Columns.Add("LpegRate")
        dtXML.Columns.Add("CategorytaxID")
        dtXML.Columns.Add("Taxper")
        dtXML.Columns.Add("TotalAmount")
        Return dtXML
    End Function
    Private Function Cocktailxmlcolumns() As DataTable
        Dim dtXML As New DataTable
        dtXML.Columns.Add("billno")
        dtXML.Columns.Add("Cocktailid")
        dtXML.Columns.Add("Qty")
        dtXML.Columns.Add("Rate")
        dtXML.Columns.Add("CategoryTaxTypeId")
        dtXML.Columns.Add("TaxPercetage")
        dtXML.Columns.Add("cocktailtotal")
        Return dtXML
    End Function

    Private Function PermitHolderxmlcolumns() As DataTable
        Dim dtXML As New DataTable
        dtXML.Columns.Add("billno")
        dtXML.Columns.Add("permitholderid")
        Return dtXML
    End Function

    Public Sub FetchBrandType()
        Dim objBrandType As New ClsAutobilling
        Dim ObjPriDt As New DataTable
        Try
            objBrandType.BrandID = cmbBrand.SelectedValue
            objBrandType.LicenseID = gblLicenseID
            objBrandType.CategorySizeLinkID = cmbSize.SelectedValue
            ObjPriDt = objBrandType.FunFetchBrandQuntity()
            If ObjPriDt.Rows.Count > 0 Then
                lblbrandName.Text = ObjPriDt.Rows(0).Item("BrandStock").ToString()
                lblbrandName.Visible = True
            End If


        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
        End Try
    End Sub

#End Region



#Region "Form Load"

    Public Sub InitSales()
        lblbrandName.Visible = False

        BindBrand(0)
        BindCocktail()
        BindTaxType()
        BindPermitName()
        FetchCurrentBillNumber()
    End Sub

#End Region

    Public Function SaveAmountWise() As Boolean
        SaveAmountWise = False
        Try
            'vBillNo = 0
            If txtAmount.Text = "" Then
                MsgBox("Please insert Amount Range")
                Exit Function
            End If


            'If ValidateBillNo() = True Then
            '    Dim result1 As DialogResult = MessageBox.Show(TotalBill & ", " & "Bills will be Created ", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            '    If result1 = DialogResult.Yes Then
            If SaveBillv2() = True Then

            End If
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "CountBill For Brand And Cocktail"
    Private Sub CountvBillNoSPEG()
        Dim tmpDv As DataView
        Dim vRange As Integer
        Dim dt As New DataTable
        Try
            dt = grdBrand.ToDataTable("BrandGridView")
            tmpDv = dt.DefaultView
            tmpDv.Sort = "SpegRate"
            dt = tmpDv.ToTable
            vRange = txtAmount.Text
            For index = 0 To dt.Rows.Count - 1
                Dim vSum As Double = CDbl(dt.Rows(index)("SpegRate"))
                For inCtr = 2 To CInt(dt.Rows(index)("SpegQty"))
                    vSum += CDbl(dt.Rows(index)("SpegRate"))
                    If vSum > vRange Then
                        vBillNo += 1
                        vSum = CDbl(dt.Rows(index)("SpegRate"))
                    End If
                Next
                vBillNo += 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CountvBillNoLPEG()
        Dim tmpDv As DataView
        Dim vRange As Integer
        Dim dt As New DataTable
        Try
            dt = grdBrand.ToDataTable("BrandGridView")
            tmpDv = dt.DefaultView
            tmpDv.Sort = "Lpegrate"
            dt = tmpDv.ToTable
            vRange = txtAmount.Text
            For index = 0 To dt.Rows.Count - 1
                Dim vSum As Double = CDbl(dt.Rows(index)("Lpegrate"))
                For inCtr = 2 To CInt(dt.Rows(index)("LpegQty"))
                    vSum += CDbl(dt.Rows(index)("Lpegrate"))
                    If vSum > vRange Then
                        vBillNo += 1
                        vSum = CDbl(dt.Rows(index)("Lpegrate"))
                    End If
                Next
                vBillNo += 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CountvBillNoBottal()
        Dim tmpDv As DataView
        Dim vRange As Integer
        Dim dt As New DataTable
        Try
            dt = grdBrand.ToDataTable("BrandGridView")
            tmpDv = dt.DefaultView
            tmpDv.Sort = "Bottlerate"
            dt = tmpDv.ToTable
            vRange = txtAmount.Text
            For index = 0 To dt.Rows.Count - 1
                Dim vSum As Double = CDbl(dt.Rows(index)("Bottlerate"))
                For inCtr = 2 To CInt(dt.Rows(index)("BottleQty"))
                    vSum += CDbl(dt.Rows(index)("Bottlerate"))
                    If vSum > vRange Then
                        vBillNo += 1
                        vSum = CDbl(dt.Rows(index)("Bottlerate"))
                    End If
                Next
                vBillNo += 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CountvBillNoCocktail()
        Dim tmpDv As DataView
        Dim vRange As Integer
        Dim dt As New DataTable
        Try
            dt = grdCocktail.ToDataTable("BindCocktailGrid")
            tmpDv = dt.DefaultView
            tmpDv.Sort = "rate"
            dt = tmpDv.ToTable
            vRange = txtAmount.Text
            For index = 0 To dt.Rows.Count - 1
                Dim vSum As Double = CDbl(dt.Rows(index)("rate"))
                For inCtr = 2 To CInt(dt.Rows(index)("Qty"))
                    vSum += CDbl(dt.Rows(index)("rate"))
                    If vSum > vRange Then
                        vBillNo += 1
                        vSum = CDbl(dt.Rows(index)("rate"))
                    End If
                Next
                vBillNo += 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    Private Function ValidateBillNo() As Boolean
        ValidateBillNo = False
        '  Dim TotalBill As Integer
        Try
            CountvBillNoSPEG()
            CountvBillNoLPEG()
            CountvBillNoBottal()
            CountvBillNoCocktail()
            FetchCurrentBillNumber()
            TotalBill = (vBillNo - 1) - (gloBillNo + 1)
            If gloBillEndNo < TotalBill Then
                MsgBox("Please Increase Bill Range")
                ValidateBillNo = False
            Else
                ValidateBillNo = True
            End If
        Catch ex As Exception
            ValidateBillNo = False
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' This medthod is used to create XML document for Brand gridview for SPEG
    ''' </summary>
    ''' <remarks>SPEG only</remarks>
    ''' 
    Private Sub CreateBrandSPegXML()
        Dim tmpDv As DataView
        Dim dtXML As New DataTable
        Dim dtNew As DataTable
        'Dim vBillNo As Integer
        Dim vRange As Integer
        Dim dt As New DataTable
        Try
            'xmldocBrand = New XmlDocument
            'xmldocBrand.LoadXml("<Trans><Sale></Sale></Trans>")
            dt = grdBrand.ToDataTable("BrandGridView")
            tmpDv = dt.DefaultView
            tmpDv.Sort = "SpegRate"
            dt = tmpDv.ToTable
            ' vBillNo = gloBillNo + 1
            vRange = txtAmount.Text
            dtXML = Brandxmlcolumns()
            For index = 0 To dt.Rows.Count - 1
                If CInt(dt.Rows(index)("SpegQty")) = 0 Then
                    Continue For
                End If
                Dim vSum As Double = CDbl(dt.Rows(index)("SpegRate"))
                dtXML = New DataTable
                dtXML = Brandxmlcolumns()
                dtXML.Rows.Add(
                         vBillNo,
                         dt.Rows(index)("Brandid"),
                         0,
                         0,
                         dt.Rows(index)("SpegQty"),
                         vSum,
                         0,
                         0,
                         dt.Rows(index)("taxtypeid"),
                         dt.Rows(index)("taxper"),
                         dt.Rows(index)("total"))

                If dt.Rows(index)("SpegQty") = 1 Then
                    dtNew = New DataTable
                    dtNew = Brandxmlcolumns()
                    dtNew.Rows.Add(
                     dtXML.Rows(0)("billno"),
                     dtXML.Rows(0)("BrandOpeningID"),
                     dtXML.Rows(0)("BottleQty"),
                        dtXML.Rows(0)("Bottlerate"),
                     dtXML.Rows.Count,
                     dtXML.Rows(0)("SpegRate"),
                     dtXML.Rows(0)("Lpeg"),
                     dtXML.Rows(0)("Lpegrate"),
                     dtXML.Rows(0)("CategorytaxID"),
                     dtXML.Rows(0)("taxper"),
                     dtXML.Rows.Count * dtXML.Rows(0)("SpegRate"))
                    GenerateBrandXML(dtNew)
                    Continue For
                End If

                For inCtr = 2 To CInt(dt.Rows(index)("SpegQty"))
                    vSum += CDbl(dt.Rows(index)("SpegRate"))
                    If vSum > vRange Then

                        dtNew = New DataTable
                        dtNew = Brandxmlcolumns()
                        dtNew.Rows.Add(
                         dtXML.Rows(0)("billno"),
                         dtXML.Rows(0)("BrandOpeningID"),
                         dtXML.Rows(0)("BottleQty"),
                         dtXML.Rows(0)("Bottlerate"),
                         dtXML.Rows.Count,
                         dtXML.Rows(0)("SpegRate"),
                         dtXML.Rows(0)("Lpeg"),
                         dtXML.Rows(0)("Lpegrate"),
                         dtXML.Rows(0)("CategorytaxID"),
                         dtXML.Rows(0)("taxper"),
                         dtXML.Rows.Count * dtXML.Rows(0)("SpegRate"))
                        GenerateBrandXML(dtNew)
                        vBillNo += 1
                        dtXML = Brandxmlcolumns()
                        vSum = CDbl(dt.Rows(index)("SpegRate"))
                        dtXML.Rows.Add(
                         vBillNo,
                         dt.Rows(index)("Brandid"),
                        0,
                        0,
                         dt.Rows(index)("SpegQty"),
                         dt.Rows(index)("SpegRate"),
                         0,
                         0,
                         dt.Rows(index)("taxtypeid"),
                         dt.Rows(index)("taxper"),
                         dt.Rows(index)("total"))
                        If inCtr = CInt(dt.Rows(index)("SpegQty")) Then

                            dtNew = New DataTable
                            dtNew = Brandxmlcolumns()
                            dtNew.Rows.Add(
                             dtXML.Rows(0)("billno"),
                             dtXML.Rows(0)("BrandOpeningID"),
                             dtXML.Rows(0)("BottleQty"),
                             dtXML.Rows(0)("Bottlerate"),
                             dtXML.Rows.Count,
                             dtXML.Rows(0)("SpegRate"),
                             dtXML.Rows(0)("Lpeg"),
                             dtXML.Rows(0)("Lpegrate"),
                             dtXML.Rows(0)("CategorytaxID"),
                             dtXML.Rows(0)("taxper"),
                             dtXML.Rows.Count * dtXML.Rows(0)("SpegRate"))
                            GenerateBrandXML(dtNew)
                        End If
                    Else
                        dtXML.Rows.Add(
                         vBillNo,
                         dt.Rows(index)("Brandid"),
                         0,
                         0,
                         dt.Rows(index)("SpegQty"),
                         dt.Rows(index)("SpegRate"),
                         0,
                         0,
                         dt.Rows(index)("taxtypeid"),
                         dt.Rows(index)("taxper"),
                         dt.Rows(index)("total"))
                        If inCtr = CInt(dt.Rows(index)("SpegQty")) Then
                            dtNew = New DataTable
                            dtNew = Brandxmlcolumns()
                            dtNew.Rows.Add(
                             dtXML.Rows(0)("billno"),
                             dtXML.Rows(0)("BrandOpeningID"),
                             dtXML.Rows(0)("BottleQty"),
                             dtXML.Rows(0)("Bottlerate"),
                             dtXML.Rows.Count,
                             dtXML.Rows(0)("SpegRate"),
                             dtXML.Rows(0)("Lpeg"),
                             dtXML.Rows(0)("Lpegrate"),
                             dtXML.Rows(0)("CategorytaxID"),
                             dtXML.Rows(0)("taxper"),
                             dtXML.Rows.Count * dtXML.Rows(0)("SpegRate"))
                            GenerateBrandXML(dtNew)
                        End If
                    End If
                Next
                vBillNo += 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' This medthod is used to create XML document for Brand gridview for Bottle
    ''' </summary>
    ''' <remarks>Bottle only</remarks>
    Private Sub CreateBrandBottleXML()
        Dim tmpDv As DataView
        Dim dtXML As New DataTable
        Dim dtNew As DataTable
        'Dim vBillNo As Integer
        Dim vRange As Integer
        Dim dt As New DataTable
        Try
            'xmldocBrand = New XmlDocument
            'xmldocBrand.LoadXml("<Trans><Sale></Sale></Trans>")
            dt = grdBrand.ToDataTable("BrandGridView")
            tmpDv = dt.DefaultView
            tmpDv.Sort = "Bottlerate"
            dt = tmpDv.ToTable
            ' vBillNo = gloBillNo + 1
            vRange = txtAmount.Text
            dtXML = Brandxmlcolumns()
            For index = 0 To dt.Rows.Count - 1
                If CInt(dt.Rows(index)("BottleQty")) = 0 Then
                    Continue For
                End If
                Dim vSum As Double = CDbl(dt.Rows(index)("Bottlerate"))
                dtXML = New DataTable
                dtXML = Brandxmlcolumns()
                dtXML.Rows.Add(
                         vBillNo,
                         dt.Rows(index)("Brandid"),
                         dt.Rows(index)("BottleQty"),
                         vSum,
                         0,
                         0,
                         0,
                         0,
                         dt.Rows(index)("taxtypeid"),
                         dt.Rows(index)("taxper"),
                         dt.Rows(index)("total"))

                If dt.Rows(index)("BottleQty") = 1 Then
                    dtNew = New DataTable
                    dtNew = Brandxmlcolumns()
                    dtNew.Rows.Add(
                     dtXML.Rows(0)("billno"),
                     dtXML.Rows(0)("BrandOpeningID"),
                     dtXML.Rows.Count,
                     dtXML.Rows(0)("Bottlerate"),
                     dtXML.Rows(0)("Speg"),
                     dtXML.Rows(0)("SpegRate"),
                     dtXML.Rows(0)("Lpeg"),
                     dtXML.Rows(0)("Lpegrate"),
                     dtXML.Rows(0)("CategorytaxID"),
                     dtXML.Rows(0)("taxper"),
                     dtXML.Rows.Count * dtXML.Rows(0)("Bottlerate"))
                    GenerateBrandXML(dtNew)
                    Continue For
                End If

                For inCtr = 2 To CInt(dt.Rows(index)("BottleQty"))
                    vSum += CDbl(dt.Rows(index)("Bottlerate"))
                    If vSum > vRange Then

                        dtNew = New DataTable
                        dtNew = Brandxmlcolumns()
                        dtNew.Rows.Add(
                      dtXML.Rows(0)("billno"),
                      dtXML.Rows(0)("BrandOpeningID"),
                      dtXML.Rows.Count,
                      dtXML.Rows(0)("Bottlerate"),
                      dtXML.Rows(0)("Speg"),
                      dtXML.Rows(0)("SpegRate"),
                      dtXML.Rows(0)("Lpeg"),
                      dtXML.Rows(0)("Lpegrate"),
                      dtXML.Rows(0)("CategorytaxID"),
                      dtXML.Rows(0)("taxper"),
                      dtXML.Rows.Count * dtXML.Rows(0)("Bottlerate"))
                        GenerateBrandXML(dtNew)
                        vBillNo += 1
                        dtXML = Brandxmlcolumns()
                        vSum = CDbl(dt.Rows(index)("Bottlerate"))
                        dtXML.Rows.Add(
                         vBillNo,
                         dt.Rows(index)("Brandid"),
                         dt.Rows(index)("BottleQty"),
                         dt.Rows(index)("Bottlerate"),
                         0,
                         0,
                         0,
                         0,
                         dt.Rows(index)("taxtypeid"),
                         dt.Rows(index)("taxper"),
                         dt.Rows(index)("total"))
                        If inCtr = CInt(dt.Rows(index)("BottleQty")) Then

                            dtNew = New DataTable
                            dtNew = Brandxmlcolumns()
                            dtNew.Rows.Add(
                          dtXML.Rows(0)("billno"),
                          dtXML.Rows(0)("BrandOpeningID"),
                          dtXML.Rows.Count,
                          dtXML.Rows(0)("Bottlerate"),
                          dtXML.Rows(0)("Speg"),
                          dtXML.Rows(0)("SpegRate"),
                          dtXML.Rows(0)("Lpeg"),
                          dtXML.Rows(0)("Lpegrate"),
                          dtXML.Rows(0)("CategorytaxID"),
                          dtXML.Rows(0)("taxper"),
                          dtXML.Rows.Count * dtXML.Rows(0)("Bottlerate"))
                            GenerateBrandXML(dtNew)
                        End If
                    Else
                        dtXML.Rows.Add(
                         vBillNo,
                         dt.Rows(index)("Brandid"),
                         dt.Rows(index)("BottleQty"),
                         dt.Rows(index)("Bottlerate"),
                         0,
                         0,
                         0,
                         0,
                         dt.Rows(index)("taxtypeid"),
                         dt.Rows(index)("taxper"),
                         dt.Rows(index)("total"))
                        If inCtr = CInt(dt.Rows(index)("BottleQty")) Then
                            dtNew = New DataTable
                            dtNew = Brandxmlcolumns()
                            dtNew.Rows.Add(
                              dtXML.Rows(0)("billno"),
                              dtXML.Rows(0)("BrandOpeningID"),
                              dtXML.Rows.Count,
                              dtXML.Rows(0)("Bottlerate"),
                              dtXML.Rows(0)("Speg"),
                              dtXML.Rows(0)("SpegRate"),
                              dtXML.Rows(0)("Lpeg"),
                              dtXML.Rows(0)("Lpegrate"),
                              dtXML.Rows(0)("CategorytaxID"),
                              dtXML.Rows(0)("taxper"),
                              dtXML.Rows.Count * dtXML.Rows(0)("Bottlerate"))
                            GenerateBrandXML(dtNew)
                        End If
                    End If
                Next
                vBillNo += 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CreateBrandLPegXml()
        Dim tmpDv As DataView
        Dim dtXML As New DataTable
        Dim dtNew As DataTable
        'Dim vBillNo As Integer
        Dim vRange As Integer
        Dim dt As New DataTable
        Try
            'xmldocBrand = New XmlDocument
            'xmldocBrand.LoadXml("<Trans><Sale></Sale></Trans>")
            dt = grdBrand.ToDataTable("BrandGridView")
            tmpDv = dt.DefaultView
            tmpDv.Sort = "Lpegrate"
            dt = tmpDv.ToTable
            '  vBillNo = gloBillNo + 1
            vRange = txtAmount.Text
            dtXML = Brandxmlcolumns()
            For index = 0 To dt.Rows.Count - 1
                If CInt(dt.Rows(index)("LpegQty")) = 0 Then
                    Continue For
                End If
                Dim vSum As Double = CDbl(dt.Rows(index)("Lpegrate"))
                dtXML = New DataTable
                dtXML = Brandxmlcolumns()
                dtXML.Rows.Add(
                         vBillNo,
                         dt.Rows(index)("Brandid"),
                         0,
                         0,
                         0,
                         0,
                         dt.Rows(index)("LpegQty"),
                         vSum,
                         dt.Rows(index)("taxtypeid"),
                         dt.Rows(index)("taxper"),
                         dt.Rows(index)("total"))

                If dt.Rows(index)("LpegQty") = 1 Then
                    dtNew = New DataTable
                    dtNew = Brandxmlcolumns()
                    dtNew.Rows.Add(
                     dtXML.Rows(0)("billno"),
                     dtXML.Rows(0)("BrandOpeningID"),
                     dtXML.Rows(0)("BottleQty"),
                    dtXML.Rows(0)("Bottlerate"),
                     dtXML.Rows(0)("Speg"),
                     dtXML.Rows(0)("SpegRate"),
                     dtXML.Rows.Count,
                     dtXML.Rows(0)("Lpegrate"),
                     dtXML.Rows(0)("CategorytaxID"),
                     dtXML.Rows(0)("taxper"),
                     dtXML.Rows.Count * dtXML.Rows(0)("Bottlerate"))
                    GenerateBrandXML(dtNew)
                    Continue For
                End If

                For inCtr = 2 To CInt(dt.Rows(index)("LpegQty"))
                    vSum += CDbl(dt.Rows(index)("Lpegrate"))
                    If vSum > vRange Then

                        dtNew = New DataTable
                        dtNew = Brandxmlcolumns()
                        dtNew.Rows.Add(
                      dtXML.Rows(0)("billno"),
                     dtXML.Rows(0)("BrandOpeningID"),
                     dtXML.Rows(0)("BottleQty"),
                    dtXML.Rows(0)("Bottlerate"),
                     dtXML.Rows(0)("Speg"),
                     dtXML.Rows(0)("SpegRate"),
                     dtXML.Rows.Count,
                     dtXML.Rows(0)("Lpegrate"),
                     dtXML.Rows(0)("CategorytaxID"),
                     dtXML.Rows(0)("taxper"),
                      dtXML.Rows.Count * dtXML.Rows(0)("Lpegrate"))
                        GenerateBrandXML(dtNew)
                        vBillNo += 1
                        dtXML = Brandxmlcolumns()
                        vSum = CDbl(dt.Rows(index)("Lpegrate"))
                        dtXML.Rows.Add(
                         vBillNo,
                         dt.Rows(index)("Brandid"),
                         0,
                         0,
                         0,
                         0,
                         dt.Rows(index)("LpegQty"),
                         vSum,
                         dt.Rows(index)("taxtypeid"),
                         dt.Rows(index)("taxper"),
                         dt.Rows(index)("total"))
                        If inCtr = CInt(dt.Rows(index)("LPegQty")) Then

                            dtNew = New DataTable
                            dtNew = Brandxmlcolumns()
                            dtNew.Rows.Add(
                          dtXML.Rows(0)("billno"),
                          dtXML.Rows(0)("BrandOpeningID"),
                          dtXML.Rows.Count,
                          dtXML.Rows(0)("Bottlerate"),
                          dtXML.Rows(0)("Speg"),
                          dtXML.Rows(0)("SpegRate"),
                          dtXML.Rows(0)("Lpeg"),
                          dtXML.Rows(0)("Lpegrate"),
                          dtXML.Rows(0)("CategorytaxID"),
                          dtXML.Rows(0)("taxper"),
                          dtXML.Rows.Count * dtXML.Rows(0)("Bottlerate"))
                            GenerateBrandXML(dtNew)
                        End If
                    Else
                        dtXML.Rows.Add(
                         vBillNo,
                         dt.Rows(index)("Brandid"),
                         0,
                         0,
                         0,
                         0,
                         dt.Rows(index)("LpegQty"),
                         dt.Rows(index)("Lpegrate"),
                         dt.Rows(index)("taxtypeid"),
                         dt.Rows(index)("taxper"),
                         dt.Rows(index)("total"))
                        If inCtr = CInt(dt.Rows(index)("LpegQty")) Then
                            dtNew = New DataTable
                            dtNew = Brandxmlcolumns()
                            dtNew.Rows.Add(
                              dtXML.Rows(0)("billno"),
                              dtXML.Rows(0)("BrandOpeningID"),
                              dtXML.Rows(0)("BottleQty"),
                              dtXML.Rows(0)("Bottlerate"),
                              dtXML.Rows(0)("Speg"),
                              dtXML.Rows(0)("SpegRate"),
                              dtXML.Rows.Count,
                              dtXML.Rows(0)("Lpegrate"),
                              dtXML.Rows(0)("CategorytaxID"),
                              dtXML.Rows(0)("taxper"),
                              dtXML.Rows.Count * dtXML.Rows(0)("Lpegrate"))
                            GenerateBrandXML(dtNew)
                        End If
                    End If
                Next
                vBillNo += 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' This medthod is used to create XML document for cocktail gridview
    ''' </summary>
    ''' <remarks>cocktail SPEG</remarks>
    Private Sub CreateCocktailXML()
        Dim tmpDv As New DataView
        Dim dtXML As New DataTable
        Dim dtNew As New DataTable
        '  Dim vBillNo As Integer
        Dim vRange As Integer
        Dim dtCocktail As New DataTable
        Try

            dtCocktail = grdCocktail.ToDataTable("BindCocktailGrid")
            tmpDv = dtCocktail.DefaultView
            tmpDv.Sort = "rate"
            dtCocktail = tmpDv.ToTable
            dtXML = Cocktailxmlcolumns()
            ' vBillNo = gloBillNo + 1
            vRange = txtAmount.Text
            For index = 0 To dtCocktail.Rows.Count - 1
                Dim vSum As Double = CDbl(dtCocktail.Rows(index)("Rate"))
                dtXML = New DataTable
                dtXML = Cocktailxmlcolumns()
                dtXML.Rows.Add(
                         vBillNo,
                         dtCocktail.Rows(index)("Cocktailid"),
                         dtCocktail.Rows(index)("Qty"),
                         vSum,
                         0,
                         dtCocktail.Rows(index)("TaxPercetage"),
                         dtCocktail.Rows(index)("cocktailtotal"))

                If dtCocktail.Rows(index)("Qty") = 1 Then
                    dtNew = New DataTable
                    dtNew = Cocktailxmlcolumns()
                    dtNew.Rows.Add(
                     dtXML.Rows(0)("billno"),
                     dtXML.Rows(0)("Cocktailid"),
                     dtXML.Rows.Count,
                     dtXML.Rows(0)("Rate"),
                     dtXML.Rows(0)("CategoryTaxTypeId"),
                     dtXML.Rows(0)("TaxPercetage"),
                     dtXML.Rows.Count * dtXML.Rows(0)("Rate"))
                    GenerateCocktailXML(dtNew)
                    Continue For
                End If

                For inCtr = 2 To CInt(dtCocktail.Rows(index)("Qty"))
                    vSum += CDbl(dtCocktail.Rows(index)("rate"))
                    If vSum > vRange Then

                        dtNew = New DataTable
                        dtNew = Cocktailxmlcolumns()
                        dtNew.Rows.Add(
                         dtXML.Rows(0)("billno"),
                         dtXML.Rows(0)("Cocktailid"),
                         dtXML.Rows.Count,
                         dtXML.Rows(0)("Rate"),
                         dtXML.Rows(0)("CategoryTaxTypeId"),
                         dtXML.Rows(0)("TaxPercetage"),
                         dtXML.Rows.Count * dtXML.Rows(0)("Rate"))
                        GenerateCocktailXML(dtNew)
                        vBillNo += 1
                        dtXML = Cocktailxmlcolumns()
                        vSum = CDbl(dtCocktail.Rows(index)("Rate"))
                        dtXML.Rows.Add(
                         vBillNo,
                         dtCocktail.Rows(index)("Cocktailid"),
                         dtCocktail.Rows(index)("Qty"),
                         vSum,
                         0,
                         dtCocktail.Rows(index)("TaxPercetage"),
                         dtCocktail.Rows(index)("cocktailtotal"))
                        If inCtr = CInt(dtCocktail.Rows(index)("Qty")) Then

                            dtNew = New DataTable
                            dtNew = Cocktailxmlcolumns()
                            dtNew.Rows.Add(
                             dtXML.Rows(0)("billno"),
                             dtXML.Rows(0)("Cocktailid"),
                             dtXML.Rows.Count,
                             dtXML.Rows(0)("Rate"),
                             dtXML.Rows(0)("CategoryTaxTypeId"),
                             dtXML.Rows(0)("TaxPercetage"),
                             dtXML.Rows.Count * dtXML.Rows(0)("Rate"))
                            GenerateCocktailXML(dtNew)
                        End If
                    Else
                        dtXML.Rows.Add(
                         vBillNo,
                         dtCocktail.Rows(index)("Cocktailid"),
                         dtCocktail.Rows(index)("Qty"),
                         vSum,
                         0,
                         dtCocktail.Rows(index)("TaxPercetage"),
                         dtCocktail.Rows(index)("cocktailtotal"))
                        If inCtr = CInt(dtCocktail.Rows(index)("Qty")) Then
                            dtNew = New DataTable
                            dtNew = Cocktailxmlcolumns()
                            dtNew.Rows.Add(
                             dtXML.Rows(0)("billno"),
                             dtXML.Rows(0)("Cocktailid"),
                             dtXML.Rows.Count,
                             dtXML.Rows(0)("Rate"),
                             dtXML.Rows(0)("CategoryTaxTypeId"),
                             dtXML.Rows(0)("TaxPercetage"),
                             dtXML.Rows.Count * dtXML.Rows(0)("Rate"))
                            GenerateCocktailXML(dtNew)
                        End If
                    End If
                Next
                vBillNo += 1
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GeneratePermitHolder()
        ''''For Permit Holder'''''
        Dim rn As New Random()

        Dim dtXMLpermitholder As New DataTable
        dtXMLpermitholder = PermitHolderxmlcolumns()
        'For index = 0 To ArrBillNo.Count - 1
        '    Dim value As Integer = rn.Next(0, ArrPermitList.Count - 2)
        '    dtXMLpermitholder.Rows.Add(ArrBillNo(index), ArrPermitList(value))
        'Next


        For index = gloBillNo + 1 To vBillNo - 1

            For rctr = 1 To CInt(txtBottles.Text)
                Dim PermitValue As Integer = rn.Next(0, ArrPermitList.Count - 2)
                dtXMLpermitholder.Rows.Add(index, ArrPermitList(PermitValue))
            Next


        Next
        GeneratePermitXML(dtXMLpermitholder)
    End Sub

    Private Function SaveBillv2() As Boolean
        SaveBillv2 = False
        Dim ObjDtAutoBill As New ClsAutobilling
        Dim ObjPriDt As New DataTable
        Dim StrPriNeg As String = ""
        Try
            FetchCurrentBillNumber()
            vBillNo = gloBillNo + 1

            '-------------- Brand -------------------
            xmldocBrand = New XmlDocument
            xmldocBrand.LoadXml("<Trans><Sale></Sale></Trans>")
            '-------------- Brand SPEG()-------------------
            CreateBrandSPegXML()

            '-------------- Brand LPEG-------------------
            CreateBrandLPegXml()

            '-------------- Brand Bottle-------------------
            CreateBrandBottleXML()

            '-------------Cocktail-------------

            xmldocCocktail = New XmlDocument
            xmldocCocktail.LoadXml("<Trans><cocktailSale></cocktailSale></Trans>")
            CreateCocktailXML()

            '----------Permit Holder------------

            xmldocPermitHolder = New XmlDocument
            xmldocPermitHolder.LoadXml("<Trans><permitSale></permitSale></Trans>")
            GeneratePermitHolder()

            StrPriNeg = NegativeStock()
            If StrPriNeg <> "" Then
                MsgBox(StrPriNeg)
                Exit Function
            End If


            If gloBillEndNo < vBillNo - 1 Then
                MsgBox("Please Increase Bill Range")
                Exit Function
            Else

                Dim result1 As DialogResult = MessageBox.Show((vBillNo - 1) - (gloBillNo) & " Bills will be created ", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result1 = DialogResult.Yes Then
                    ObjDtAutoBill.AutoDate = Dtdate.Value
                    ObjDtAutoBill.LicenseID = gblLicenseID
                    ObjDtAutoBill.BrandXml = xmldocBrand
                    ObjDtAutoBill.CocktailXml = xmldocCocktail
                    ObjDtAutoBill.PermitHolderXml = xmldocPermitHolder
                    ObjDtAutoBill.UserName = gblUserName
                    SaveBillv2 = ObjDtAutoBill.FunSave()
                    MsgBox(ObjDtAutoBill.ErrorMsg)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function NegativeStock() As String
        NegativeStock = ""
        Dim ObjPriDt As New DataTable
        Dim ObjDtAutoBill As New ClsAutobilling
        Dim xmlGridBrand As New XmlDocument
        Dim xmlGridCocktail As New XmlDocument
        Try

            xmlGridBrand.LoadXml("<Trans><Sale></Sale></Trans>")
            Dim XmlElt As XmlElement = xmlGridBrand.CreateElement("Brand")
            For index = 0 To grdBrand.Rows.Count - 1

                XmlElt = xmlGridBrand.CreateElement("Brand")
                XmlElt.SetAttribute("billno", 0)
                XmlElt.SetAttribute("BrandOpeningID", grdBrand.Item("brandid", index).Value)
                XmlElt.SetAttribute("BottleQty", grdBrand.Item("BottleQty", index).Value)
                XmlElt.SetAttribute("Bottlerate", 0)
                XmlElt.SetAttribute("Speg", grdBrand.Item("Spegqty", index).Value)
                XmlElt.SetAttribute("SpegRate", 0)
                XmlElt.SetAttribute("Lpeg", grdBrand.Item("Lpegqty", index).Value)
                XmlElt.SetAttribute("LpegRate", 0)
                XmlElt.SetAttribute("CategorytaxID", 0)
                XmlElt.SetAttribute("Taxper", 0)
                XmlElt.SetAttribute("TotalAmount", 0)
                xmlGridBrand.DocumentElement.Item("Sale").AppendChild(XmlElt)
            Next

            xmlGridCocktail.LoadXml("<Trans><cocktailSale></cocktailSale></Trans>")
            XmlElt = xmlGridCocktail.CreateElement("Cocktail")
            For index = 0 To grdCocktail.Rows.Count - 1
                XmlElt = xmlGridCocktail.CreateElement("Cocktail")
                XmlElt.SetAttribute("billno", 0)
                XmlElt.SetAttribute("Cocktailid", grdCocktail.Item("Cocktailid", index).Value)
                XmlElt.SetAttribute("Qty", grdCocktail.Item("Qty", index).Value)
                XmlElt.SetAttribute("Rate", grdCocktail.Item("Rate", index).Value)
                XmlElt.SetAttribute("CategoryTaxTypeId", 0)
                XmlElt.SetAttribute("TaxPercetage", 0)
                XmlElt.SetAttribute("cocktailtotal", 0)
                xmlGridCocktail.DocumentElement.Item("cocktailSale").AppendChild(XmlElt)
            Next



            ObjDtAutoBill.LicenseID = gblLicenseID
            ObjDtAutoBill.BrandXml = xmlGridBrand
            ObjDtAutoBill.CocktailXml = xmlGridCocktail
            ObjPriDt = ObjDtAutoBill.FunFecthNegativeStock()
            If ObjPriDt.Rows.Count > 0 Then
                For IntDtCnt = 0 To ObjPriDt.Rows.Count - 1
                    NegativeStock += ObjPriDt.Rows(IntDtCnt)("branddesc") & " : " & ObjPriDt.Rows(IntDtCnt)("stock") & vbCrLf
                Next
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
            If IsNothing(ObjDtAutoBill) = False Then
                ObjDtAutoBill = Nothing
            End If
        End Try
    End Function

    Private Function GenerateXML(ByVal dt As DataTable) As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Trans><Sale></Sale></Trans>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Cocktail")
        For index = 0 To dt.Rows.Count - 1
            XmlElt = xmldoc.CreateElement("Cocktail")
            XmlElt.SetAttribute("Num", dt.Rows(index)(0))
            xmldoc.DocumentElement.Item("Sale").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function

    Public Sub FetchPermitNameDet(ByVal PermitHolderID As Double)
        Dim ObjDtPermitHolder As New ClsPermitHolderMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjDtPermitHolder.PermitHolderID = PermitHolderID
            ObjPriDt = ObjDtPermitHolder.FunFetch
            If ObjPriDt.Rows.Count > 0 Then
                grdPermitName.Rows.Add()
                Dim vCtr As Integer = grdPermitName.RowCount - 1
                grdPermitName.Item("PermitHolderID", vCtr).Value = PermitHolderID
                grdPermitName.Item("Permitname", vCtr).Value = ObjPriDt.Rows(0)("PermitHolderName")
                grdPermitName.Item("Permitno", vCtr).Value = ObjPriDt.Rows(0)("PermitHolderNumber")
                grdPermitName.Item("ExpDate", vCtr).Value = ObjPriDt.Rows(0)("PermitExpireDate")
                grdPermitName.Item("permittypeid", vCtr).Value = ObjPriDt.Rows(0)("permittypeid")
                grdPermitName.Item("permittype", vCtr).Value = ObjPriDt.Rows(0)("permitdesc")
            End If
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


    Public Function FetchBillCounter() As Integer
        FetchBillCounter = 0
        Dim ObjDtAutoBill As New ClsAutobilling
        Dim ObjPriDt As New DataTable
        Try
            Dim vRange As Double = txtAmount.Text
            Dim vCount As Double
            Dim dtXML As New DataTable
            dtXML = Brandxmlcolumns()
            Dim BillNo As Integer = 1
            Dim dtGrdNew As DataTable
            dtGrdNew = grdBrand.ToDataTable("BrandGridView")
            Dim tmpDv As DataView = dtGrdNew.DefaultView
            tmpDv.Sort = "total"
            dtGrdNew = tmpDv.ToTable
            For index = 0 To dtGrdNew.Rows.Count - 1
                vCount += dtGrdNew.Rows(index)("total")
                If vCount > vRange Then
                    'Ask for New Bill No
                    'GenerateBrandXML(dtXML)
                    'ArrBillNo.Add(BillNo).ToString()
                    'BillNo = BillNo + 1
                    FetchBillCounter = FetchBillCounter + 1
                    dtXML = New DataTable
                    dtXML = Brandxmlcolumns()
                    dtXML.Rows.Add(
                         BillNo,
                         dtGrdNew.Rows(index)("Brandid"),
                         dtGrdNew.Rows(index)("BottleQty"),
                         dtGrdNew.Rows(index)("Bottlerate"),
                         dtGrdNew.Rows(index)("SpegQty"),
                         dtGrdNew.Rows(index)("SpegRate"),
                         dtGrdNew.Rows(index)("LpegQty"),
                         dtGrdNew.Rows(index)("Lpegrate"),
                         dtGrdNew.Rows(index)("taxtypeid"),
                         dtGrdNew.Rows(index)("taxper"),
                         dtGrdNew.Rows(index)("total"))
                    vCount = dtGrdNew.Rows(index)(0)
                    If index = grdBrand.Rows.Count - 1 Then
                        'Ask for New Bill No
                        'GenerateBrandXML(dtXML)
                        'ArrBillNo.Add(BillNo).ToString()
                        'BillNo = BillNo + 1
                        FetchBillCounter = FetchBillCounter + 1
                    End If
                Else
                    dtXML.Rows.Add(
                        BillNo,
                       dtGrdNew.Rows(index)("Brandid"),
                        dtGrdNew.Rows(index)("BottleQty"),
                        dtGrdNew.Rows(index)("Bottlerate"),
                        dtGrdNew.Rows(index)("SpegQty"),
                        dtGrdNew.Rows(index)("SpegRate"),
                        dtGrdNew.Rows(index)("LpegQty"),
                        dtGrdNew.Rows(index)("Lpegrate"),
                        dtGrdNew.Rows(index)("taxtypeid"),
                        dtGrdNew.Rows(index)("taxper"),
                        dtGrdNew.Rows(index)("total"))
                    If index = grdBrand.Rows.Count - 1 Then
                        'Ask for New Bill No
                        'GenerateBrandXML(dtXML)
                        'ArrBillNo.Add(BillNo).ToString()
                        'BillNo = BillNo + 1
                        FetchBillCounter = FetchBillCounter + 1
                    End If
                End If
            Next




            Dim vRangeCocktail As Double = txtAmount.Text
            Dim vCountCocktail As Double
            Dim dtXMLCocktail As New DataTable
            dtXMLCocktail = Cocktailxmlcolumns()
            Dim BillNoCocktail As Integer = 1
            Dim dtGrdNewCocktail As DataTable
            dtGrdNewCocktail = grdCocktail.ToDataTable("BindCocktailGrid")
            Dim tmpDvCocktail As DataView = dtGrdNewCocktail.DefaultView
            tmpDvCocktail.Sort = "cocktailtotal"
            dtGrdNewCocktail = tmpDvCocktail.ToTable

            For index = 0 To dtGrdNewCocktail.Rows.Count - 1
                vCountCocktail += dtGrdNewCocktail.Rows(index)("cocktailtotal")
                If vCountCocktail > vRange Then
                    'Ask for New Bill No
                    'GenerateCocktailXML(dtXMLCocktail)
                    'ArrBillNo.Add(BillNo).ToString()
                    'BillNo = BillNo + 1
                    FetchBillCounter = FetchBillCounter + 1
                    dtXMLCocktail = New DataTable
                    dtXMLCocktail = Cocktailxmlcolumns()
                    dtXMLCocktail.Rows.Add(
                         BillNo,
                         dtGrdNewCocktail.Rows(index)("Cocktailid"),
                        dtGrdNewCocktail.Rows(index)("Qty"),
                        dtGrdNewCocktail.Rows(index)("Rate"),
                        0,
                        dtGrdNewCocktail.Rows(index)("TaxPercetage"),
                        dtGrdNewCocktail.Rows(index)("cocktailtotal"))
                    vCount = dtGrdNewCocktail.Rows(index)(0)
                    If index = grdCocktail.Rows.Count - 1 Then
                        'Ask for New Bill No
                        'GenerateCocktailXML(dtXMLCocktail)
                        'ArrBillNo.Add(BillNo).ToString()
                        'BillNo = BillNo + 1
                        FetchBillCounter = FetchBillCounter + 1
                    End If

                Else
                    dtXMLCocktail.Rows.Add(
                        BillNo,
                       dtGrdNewCocktail.Rows(index)("Cocktailid"),
                        dtGrdNewCocktail.Rows(index)("Qty"),
                        dtGrdNewCocktail.Rows(index)("Rate"),
                        0,
                        dtGrdNewCocktail.Rows(index)("TaxPercetage"),
                        dtGrdNewCocktail.Rows(index)("cocktailtotal"))

                    If index = grdCocktail.Rows.Count - 1 Then
                        'Ask for New Bill No
                        'GenerateCocktailXML(dtXMLCocktail)
                        'ArrBillNo.Add(BillNo).ToString()
                        'BillNo = BillNo + 1
                        FetchBillCounter = FetchBillCounter + 1
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function GenerateBrandXML(ByVal dtData As DataTable) As XmlDocument
        Dim XmlElt As XmlElement = xmldocBrand.CreateElement("Brand")
        For index = 0 To dtData.Rows.Count - 1

            XmlElt = xmldocBrand.CreateElement("Brand")

            XmlElt.SetAttribute("billno", dtData.Rows(index)("BillNo"))
            XmlElt.SetAttribute("BrandOpeningID", dtData.Rows(index)("BrandOpeningID"))
            XmlElt.SetAttribute("BottleQty", dtData.Rows(index)("BottleQty"))
            XmlElt.SetAttribute("Bottlerate", dtData.Rows(index)("Bottlerate"))
            XmlElt.SetAttribute("Speg", dtData.Rows(index)("Speg"))
            XmlElt.SetAttribute("SpegRate", dtData.Rows(index)("SpegRate"))
            XmlElt.SetAttribute("Lpeg", dtData.Rows(index)("Lpeg"))
            XmlElt.SetAttribute("LpegRate", dtData.Rows(index)("LpegRate"))

            'If cmbtaxType.Text = "" Then
            '    dtData.Rows(index)("CategorytaxID") = 0

            'End If
            XmlElt.SetAttribute("CategorytaxID", dtData.Rows(index)("CategorytaxID"))
            XmlElt.SetAttribute("Taxper", dtData.Rows(index)("Taxper"))
            XmlElt.SetAttribute("TotalAmount", dtData.Rows(index)("TotalAmount"))
            xmldocBrand.DocumentElement.Item("Sale").AppendChild(XmlElt)
        Next
        Return xmldocBrand
    End Function
    Private Function GenerateCocktailXML(ByVal dtData As DataTable) As XmlDocument

        Dim XmlElt As XmlElement = xmldocCocktail.CreateElement("Cocktail")
        For index = 0 To dtData.Rows.Count - 1
            XmlElt = xmldocCocktail.CreateElement("Cocktail")

            XmlElt.SetAttribute("billno", dtData.Rows(index)("BillNo"))
            XmlElt.SetAttribute("Cocktailid", dtData.Rows(index)("Cocktailid"))
            XmlElt.SetAttribute("Qty", dtData.Rows(index)("Qty"))
            XmlElt.SetAttribute("Rate", dtData.Rows(index)("Rate"))
            XmlElt.SetAttribute("CategoryTaxTypeId", 0)
            XmlElt.SetAttribute("TaxPercetage", dtData.Rows(index)("TaxPercetage"))

            XmlElt.SetAttribute("cocktailtotal", dtData.Rows(index)("cocktailtotal"))
            xmldocCocktail.DocumentElement.Item("cocktailSale").AppendChild(XmlElt)
        Next

        Return xmldocCocktail
    End Function

    Private Function GeneratePermitXML(ByVal dtdata As DataTable) As XmlDocument
        Dim XmlElt As XmlElement = xmldocPermitHolder.CreateElement("permit")
        For index = 0 To dtdata.Rows.Count - 1
            XmlElt = xmldocPermitHolder.CreateElement("permit")

            XmlElt.SetAttribute("billno", dtdata.Rows(index)("BillNo"))
            XmlElt.SetAttribute("permitholderid", dtdata.Rows(index)("permitholderid"))
            xmldocPermitHolder.DocumentElement.Item("permitSale").AppendChild(XmlElt)
        Next

        Return xmldocPermitHolder
    End Function

#Region "Grid events"

    '#############################3
    '   CALCULATE AMOUNT
    Public Sub CalculateAmount(ByVal RowIdx As Integer)
        spegAmt = (grdBrand.Item("SpegQty", RowIdx).Value * grdBrand.Item("SpegRate", RowIdx).Value) * ((grdBrand.Item("taxper", RowIdx).Value) / 100)
        spegAmtTotal = grdBrand.Item("SpegQty", RowIdx).Value * grdBrand.Item("SpegRate", RowIdx).Value + spegAmt
        LpegAmt = ((grdBrand.Item("LpegQty", RowIdx).Value * grdBrand.Item("Lpegrate", RowIdx).Value * grdBrand.Item("taxper", RowIdx).Value) / 100)
        LpegAmtTotal = grdBrand.Item("LpegQty", RowIdx).Value * grdBrand.Item("Lpegrate", RowIdx).Value + LpegAmt
        BottalpegAmt = ((grdBrand.Item("BottleQty", RowIdx).Value * grdBrand.Item("Bottlerate", RowIdx).Value * grdBrand.Item("taxper", RowIdx).Value) / 100)
        BottalpegAmtTotal = grdBrand.Item("BottleQty", RowIdx).Value * grdBrand.Item("Bottlerate", RowIdx).Value + BottalpegAmt
    End Sub
    '#################################6
    'Calculate Bottal

    Public Sub GenerateConsumptionwiseXML(ByVal curQty As Double, ByVal PermitQty As Double, ByVal rwIndx As Integer, ByVal Colname As String)
        Dim dtXML As New DataTable
        dtXML = Brandxmlcolumns()
        Dim vCtr As Integer = Math.Ceiling(curQty / PermitQty)
        Dim vSum As Double = curQty

        For index = 1 To vCtr
            Dim vAdd As Double = 0
            If vSum < PermitQty Then
                vAdd = vSum
            Else
                vAdd = PermitQty
            End If
            dtXML.Rows.Add(vBillNo, grdBrand.Item("BrandID", rwIndx).Value, 0, 0, 0, 0, 0, 0, grdBrand.Item("taxtypeid", rwIndx).Value, grdBrand.Item("taxper", rwIndx).Value, 0)
            If Colname = "sPegQty" Then
                dtXML.Rows(dtXML.Rows.Count - 1)("Speg") = vAdd
                dtXML.Rows(dtXML.Rows.Count - 1)("Spegrate") = grdBrand.Item("SpegRate", rwIndx).Value
                dtXML.Rows(dtXML.Rows.Count - 1)("totalamount") = vAdd * grdBrand.Item("SpegRate", rwIndx).Value
            ElseIf Colname = "lpegqty" Then
                dtXML.Rows(dtXML.Rows.Count - 1)("lPeg") = vAdd
                dtXML.Rows(dtXML.Rows.Count - 1)("lpegrate") = grdBrand.Item("lpegRate", rwIndx).Value
                dtXML.Rows(dtXML.Rows.Count - 1)("totalamount") = vAdd * grdBrand.Item("lpegRate", rwIndx).Value
            ElseIf Colname = "bottleqty" Then
                dtXML.Rows(dtXML.Rows.Count - 1)("bottleqty") = vAdd
                dtXML.Rows(dtXML.Rows.Count - 1)("bottlerate") = grdBrand.Item("bottlerate", rwIndx).Value
                dtXML.Rows(dtXML.Rows.Count - 1)("totalamount") = vAdd * grdBrand.Item("bottlerate", rwIndx).Value
            End If

            vBillNo += 1
            vSum -= PermitQty
        Next
        GenerateBrandXML(dtXML)
    End Sub


    Public Sub GenerateConsumptionwiseCocktailXML()
        Dim dtXML As New DataTable
        dtXML = Cocktailxmlcolumns()

        For index = 0 To grdCocktail.RowCount - 1

            For ctr = 0 To CInt(txtNoOfCocktail.Text - 1)
                dtXML.Rows.Add(
                           vBillNo,
                           grdCocktail.Item("Cocktailid", index + ctr).Value,
                          grdCocktail.Item("Qty", index + ctr).Value,
                           0,
                           0,
                         grdCocktail.Item("TaxPercetage", index + ctr).Value,
                         grdCocktail.Item("cocktailtotal", index + ctr).Value)
                If index = grdCocktail.RowCount - 1 Then
                    GoTo step1
                Else
                    index += ctr
                End If

            Next

            vBillNo += 1

        Next
step1:  GenerateCocktailXML(dtXML)
    End Sub

    Public Sub CalculateBottel()
        For rwctr = 0 To grdBrand.RowCount - 1
            If Not grdBrand.Item("spegqty", rwctr).Value = 0 Then
                If Not grdBrand.Item("spegpermitqty", rwctr).Value = 0 Then
                    GenerateConsumptionwiseXML(grdBrand.Item("spegqty", rwctr).Value, grdBrand.Item("spegpermitqty", rwctr).Value, rwctr, "sPegQty")
                Else
                    MsgBox("Permit Quantity is 0", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            If Not grdBrand.Item("lPegQty", rwctr).Value = 0 Then
                If Not grdBrand.Item("lpegpermitqty", rwctr).Value = 0 Then
                    GenerateConsumptionwiseXML(grdBrand.Item("lpegqty", rwctr).Value, grdBrand.Item("lpegpermitqty", rwctr).Value, rwctr, "lpegqty")
                Else
                    MsgBox("Permit Quantity is 0", MsgBoxStyle.Information)
                    Exit Sub
                End If
                End
            End If

            If Not grdBrand.Item("bottleqty", rwctr).Value = 0 Then
                If Not grdBrand.Item("bottlepermitqty", rwctr).Value = 0 Then
                    GenerateConsumptionwiseXML(grdBrand.Item("bottleqty", rwctr).Value, grdBrand.Item("bottlepermitqty", rwctr).Value, rwctr, "bottleqty")
                Else
                    MsgBox("Permit Quantity is 0", MsgBoxStyle.Information)
                    Exit Sub
                End If

            End If

        Next
    End Sub

    Private Sub grdBrand_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBrand.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        '  If RdAmount.Checked = True Then

        If IsUserChangedValue Then
            If e.ColumnIndex = 8 Or e.ColumnIndex = 10 Or e.ColumnIndex = 12 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 9 Or e.ColumnIndex = 11 Then
                CalculateAmount(e.RowIndex)
                IsUserChangedValue = False

                If e.ColumnIndex = 7 Or e.ColumnIndex = 8 Then
                    grdBrand.Item("spegpermitqty", e.RowIndex).Value = FetchBottalWiseConsuptionQty("sp", grdBrand.Item("BrandID", e.RowIndex).Value)
                End If
                If e.ColumnIndex = 9 Or e.ColumnIndex = 10 Then
                    grdBrand.Item("lpegpermitqty", e.RowIndex).Value = FetchBottalWiseConsuptionQty("lp", grdBrand.Item("BrandID", e.RowIndex).Value)
                End If
                If e.ColumnIndex = 11 Or e.ColumnIndex = 12 Then
                    grdBrand.Item("bottlepermitqty", e.RowIndex).Value = FetchBottalWiseConsuptionQty("b", grdBrand.Item("BrandID", e.RowIndex).Value)
                End If
            End If
        End If
        grdBrand.Item("Amt", e.RowIndex).Value = spegAmt + LpegAmt + BottalpegAmt
        grdBrand.Item("total", e.RowIndex).Value = spegAmtTotal + LpegAmtTotal + BottalpegAmtTotal
        IsUserChangedValue = True

        '  End If
    End Sub
    Private Sub grdCocktail_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCocktail.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = 4 Then
            grdCocktail.Item("Amount", e.RowIndex).Value = (grdCocktail.Item("taxpercetage", e.RowIndex).Value * grdCocktail.Item("rate", e.RowIndex).Value * grdCocktail.Item("qty", e.RowIndex).Value) / 100
            grdCocktail.Item("cocktailtotal", e.RowIndex).Value = grdCocktail.Item("Amount", e.RowIndex).Value + (grdCocktail.Item("rate", e.RowIndex).Value * grdCocktail.Item("qty", e.RowIndex).Value)
        End If
    End Sub

    Public Function FetchBottalWiseConsuptionQty(ByVal mlType As String, ByVal BrandOpID As Double) As Double
        FetchBottalWiseConsuptionQty = 0

        Dim ObjPriBottal As New Clspurchase
        Dim ObjPriDt As New DataTable
        Try
            ObjPriBottal.BrandopeningID = BrandOpID
            ObjPriBottal.MlType = mlType
            ObjPriDt = ObjPriBottal.FunFecthBottalWiseConsumption()
            If ObjPriDt.Rows.Count > 0 Then
                FetchBottalWiseConsuptionQty = ObjPriDt.Rows(0).Item("Qty")
            End If

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function
#End Region

#Region "Other control events"

    Private Sub RdBottle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBottle.CheckedChanged
        txtAmount.Visible = False
        txtBottles.Visible = True
        lblCocktailNumber.Visible = True
        txtNoOfCocktail.Visible = True

    End Sub

    Private Sub RdAmount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdAmount.CheckedChanged
        txtAmount.Visible = True
        txtBottles.Visible = False
        lblCocktailNumber.Visible = False
        txtNoOfCocktail.Visible = False
    End Sub

    Private Sub cmbBrand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrand.SelectedIndexChanged

        If Not TypeOf (cmbBrand.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        BindSize(cmbBrand.SelectedValue)
        BindTaxType()
        'FetchBrandType()

    End Sub

    Private Sub cmbSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSize.SelectedIndexChanged
        If Not TypeOf (cmbSize.SelectedValue) Is Decimal OrElse cmbSize.SelectedValue = 0 Then
            Exit Sub
        End If

        FetchBrandType()
    End Sub

    Private Sub Dtdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtdate.ValueChanged
        BindPermitName()
    End Sub

#End Region

#Region "Button click"






    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not TypeOf cmbBrand.SelectedValue Is Decimal Then
            Exit Sub
        End If
        If Not TypeOf cmbSize.SelectedValue Is Decimal Then
            Exit Sub
        End If
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable
            Objpurchase.BrandID = cmbBrand.SelectedValue
            Objpurchase.CategorySizeLinkID = cmbSize.SelectedValue
            objdt = Objpurchase.BindPurchaseRate
            If objdt.Rows.Count > 0 Then
                'If cmbtaxType.SelectedValue = 0 Then
                '    cmbtaxType.Text = Nothing

                'End If
                'If cmbtaxType.Text = Nothing Then
                '    cmbtaxType.Text = ""
                'End If
                gblBrandOpeningID = objdt.Rows(0).Item("BrandopeningId")



                If cmbtaxType.SelectedValue = 0 Then
                    grdBrand.Rows.Add(objdt.Rows(0).Item("BrandopeningId"), cmbBrand.Text, cmbSize.SelectedValue, cmbSize.Text, cmbtaxType.SelectedValue, "", gblTaxPercentage, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Else
                    grdBrand.Rows.Add(objdt.Rows(0).Item("BrandopeningId"), cmbBrand.Text, cmbSize.SelectedValue, cmbSize.Text, cmbtaxType.SelectedValue, cmbtaxType.Text, gblTaxPercentage, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                End If
            Else
                Exit Sub
            End If


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
        cmbBrand.Text = ""
        cmbBrand.SelectedValue = -1
        cmbSize.DataSource = Nothing
    End Sub

    Private Sub btnCocktailAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCocktailAdd.Click
        Objcocktail = New CWPlusBL.Master.ClsAutobilling
        objdt = New DataTable
        Objcocktail.CocktailId = cmbCocktail.SelectedValue
        Objcocktail.LicenseID = gblLicenseID
        objdt = Objcocktail.BindCocktailRate
        If objdt.Rows.Count > 0 Then
            grdCocktail.Rows.Add(cmbCocktail.SelectedValue, cmbCocktail.Text, 0, objdt.Rows(0)("Rate"), 0)
        Else
            Exit Sub
        End If

        cmbCocktail.Text = ""
        cmbCocktail.SelectedValue = -1
    End Sub

    Private Sub btnPermitAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPermitAdd.Click
        FetchPermitNameDet(cmbPermitName.SelectedValue)
    End Sub

    '  Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If RdAmount.Checked = True Then
    '        SaveAmountWise()
    '    Else
    '        SaveConsumptionWise()
    '    End If
    'End Sub
#End Region





    Private Function SaveConsumptionWise() As Boolean
        Dim ObjPriConsumptionWise As New ClsAutobilling
        Dim ObjPriDt As New DataTable
        SaveConsumptionWise = False
        Try

            If txtBottles.Text = "" Then
                MsgBox("Please insert Bottle")
                Exit Function
            Else

                FetchCurrentBillNumber()
                vBillNo = gloBillNo + 1

                xmldocBrand = New XmlDocument
                xmldocBrand.LoadXml("<Trans><Sale></Sale></Trans>")
                CalculateBottel()


                xmldocCocktail = New XmlDocument
                xmldocCocktail.LoadXml("<Trans><cocktailSale></cocktailSale></Trans>")
                GenerateConsumptionwiseCocktailXML()


                xmldocPermitHolder = New XmlDocument
                xmldocPermitHolder.LoadXml("<Trans><permitSale></permitSale></Trans>")
                GeneratePermitHolder()

                If gloBillEndNo < vBillNo - 1 Then
                    MsgBox("Please Increase Bill Range")
                    Exit Function
                Else

                    Dim result1 As DialogResult = MessageBox.Show(vBillNo - 1 & " Bills will be created ", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If result1 = DialogResult.Yes Then
                        ObjPriConsumptionWise.AutoDate = Dtdate.Value
                        ObjPriConsumptionWise.LicenseID = gblLicenseID
                        ObjPriConsumptionWise.BrandXml = xmldocBrand
                        ObjPriConsumptionWise.CocktailXml = xmldocCocktail
                        ObjPriConsumptionWise.PermitHolderXml = xmldocPermitHolder
                        ObjPriConsumptionWise.UserName = gblUserName
                        SaveConsumptionWise = ObjPriConsumptionWise.FunSave()
                        MsgBox(ObjPriConsumptionWise.ErrorMsg)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function



    Public Sub FetchCategoryTaxPercentage()
        If Not TypeOf cmbtaxType.SelectedValue Is Decimal Then
            Exit Sub
        End If
        Dim ObjPercentage As New ClsAutobilling
        Dim ObjDt As New DataTable
        Try
            ObjPercentage.CategoryTaxID = cmbtaxType.SelectedValue
            ObjDt = ObjPercentage.FunFecthTaxPercentage()
            If ObjDt.Rows.Count > 0 Then
                gblTaxPercentage = ObjDt.Rows(0).Item("Taxpercetage")
            End If
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    GenerateConsumptionwiseXML()
    'End Sub

    Private Sub cmbtaxType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtaxType.SelectedIndexChanged
        FetchCategoryTaxPercentage()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        'If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
        '    MsgBox("Please select license", vbInformation, "CWPlus")
        '    Exit Sub
        'End If

        Dim ObjPercentage As New ClsAutobilling
        Dim ObjDt As New DataTable
        Try
            ObjPercentage.LicenseID = gblLicenseID
            ObjDt = ObjPercentage.FunFecthBrandOpeningForExport()
            If ObjDt.Rows.Count > 0 Then

                Dim dlgSaveFile As New SaveFileDialog
                dlgSaveFile.DefaultExt = ".xls"
                dlgSaveFile.Filter = "Excel Files (*.xls) | *.xls"
                If dlgSaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim ObjExp As New ClsMsOffice
                    ObjExp.ExportToExcel(IO.Path.GetDirectoryName(dlgSaveFile.FileName), IO.Path.GetFileName(dlgSaveFile.FileName), ObjDt)
                    Dim dlgRes As DialogResult
                    dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If dlgRes = Windows.Forms.DialogResult.Yes Then
                        Process.Start(dlgSaveFile.FileName)

                    End If
                End If

            End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Public Function GetExcelSheetData(ByVal FileName As String) As DataTable
        Try
            Dim extension As String = IO.Path.GetExtension(FileName)
            If extension = ".xls" OrElse extension = ".xlsx" Then
                Dim db As New ExcelReader(FileName, True, False)
                GetExcelSheetData = db.GetWorksheet("Sheet1")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim DlgexcelFile As New OpenFileDialog

        If DlgexcelFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim dt As New DataTable
            Dim ObjOfc As New ExcelReader(DlgexcelFile.FileName, True, False)

            dt = GetExcelSheetData(DlgexcelFile.FileName)
            If dt.Rows.Count > 0 Then
                grdBrand.Rows.Clear()
                Dim ctr As Integer = 0
                For index = 0 To dt.Rows.Count - 1
                    If dt.Rows(index)("SpegQty") = 0 And dt.Rows(index)("lpegQty") = 0 And dt.Rows(index)("BottleQty") = 0 Then
                        Continue For
                    End If
                    grdBrand.Rows.Add()
                    grdBrand.Item("brandid", ctr).Value = dt.Rows(index)("brandopeningid")
                    grdBrand.Item("CategorySizeLinkUpID", ctr).Value = dt.Rows(index)("CategorySizeLinkUpID")
                    grdBrand.Item("brand", ctr).Value = dt.Rows(index)("branddesc")
                    grdBrand.Item("size", ctr).Value = dt.Rows(index)("size")
                    grdBrand.Item("taxper", ctr).Value = dt.Rows(index)("taxper")
                    grdBrand.Item("SpegQty", ctr).Value = dt.Rows(index)("SpegQty")
                    grdBrand.Item("SpegRate", ctr).Value = dt.Rows(index)("SpegRate")
                    grdBrand.Item("LpegQty", ctr).Value = dt.Rows(index)("LpegQty")
                    grdBrand.Item("LpegRate", ctr).Value = dt.Rows(index)("LpegRate")
                    grdBrand.Item("BottleQty", ctr).Value = dt.Rows(index)("BottleQty")
                    grdBrand.Item("BottleRate", ctr).Value = dt.Rows(index)("BottleRate")
                    ctr += 1
                Next

            End If
        End If
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        If RdAmount.Checked = True Then
            SaveAmountWise()
        Else
            SaveConsumptionWise()
        End If
    End Sub

End Class
