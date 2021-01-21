Public Class frmDRRSale
    Dim ObjDRRSale As CWPlusBL.Accor.ClsDRRSale
    Dim ObjCls As CWPlusBL.Accor.ClsReports
    Dim ObjDt As DataTable

    Dim ObjPriDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"
    Private Sub ClrScreen()
        DtBusinessDate.Value = Format(Now.Date, "dd-MMM-yyyy")
        drpRevenueCenter.SelectedValue = 0
        txtFoodTransfer.Text = ""
        txtBevTransfer.Text = ""

        lblid.Text = 0
    End Sub

    Private Sub InitScreen()
        Try
            ObjDRRSale = New CWPlusBL.Accor.ClsDRRSale
            ObjDt = New DataTable
            ObjDRRSale.Businessdate = Format(DtBusinessDate.Value, "dd-MMM-yyyy")
            ObjDt = ObjDRRSale.FunFetch
            grdDRRSale.DataSource = Nothing
            grdDRRSale.DataSource = ObjDt
            grdDRRSale.Columns("DRRId").Visible = False
            grdDRRSale.Columns("RevenueCenterId").Visible = False
            'ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjDRRSale) Then
                ObjDRRSale = Nothing
            End If
        End Try

    End Sub

    Public Function Save() As Boolean
        Save = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "DRRSale")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "DRRSale")
                Exit Function
            End If
        End If

        Try
            ObjDRRSale = New CWPlusBL.Accor.ClsDRRSale
            ObjDRRSale.DRRId = lblid.Text
            ObjDRRSale.RevenueCenterId = drpRevenueCenter.SelectedValue
            ObjDRRSale.RevenueCenterName = drpRevenueCenter.Text
            ObjDRRSale.Businessdate = Format(DtBusinessDate.Value, "dd-MMM-yyyy")
            ObjDRRSale.Covers = 0

            ObjDRRSale.FoodTransferAmount = IIf(Trim(txtFoodTransfer.Text) = "", 0, Trim(txtFoodTransfer.Text))
            ObjDRRSale.BevTransferAmount = IIf(Trim(txtBevTransfer.Text) = "", 0, Trim(txtBevTransfer.Text))
            ObjDRRSale.BeverageToFood = IIf(Trim(txtBevtofood.Text) = "", 0, Trim(txtBevtofood.Text))
            ObjDRRSale.UserName = gblUserName
            Save = ObjDRRSale.FunSave
            MsgBox(ObjDRRSale.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjDRRSale) Then
                ObjDRRSale = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If lblid.Text = 0 Then
            MsgBox("Select record to delete", MsgBoxStyle.Critical, "DRRSale")
            Exit Function
        End If
        Try
            ObjDRRSale = New CWPlusBL.Accor.ClsDRRSale
            ObjDRRSale.DRRId = lblid.Text
            ObjDRRSale.UserName = gblUserName
            FunDelete = ObjDRRSale.FunDelete
            MsgBox(ObjDRRSale.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDRRSale) Then
                ObjDRRSale = Nothing
            End If
        End Try
    End Function

#End Region

    Private Sub FrmSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        ClrScreen()
        InitScreen()
        BindRevenueCenters()
    End Sub

    Private Sub BindRevenueCenters()
        Try
            ObjPriDt = New DataTable
            ObjCls = New CWPlusBL.Accor.ClsReports
            ObjPriDt = ObjCls.FunFetchRevenueCenters()
            ComboBindingTemplate(drpRevenueCenter, ObjPriDt, "revenuecentername", "revenuecenterid")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub grdsize_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDRRSale.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdDRRSale("DRRId", e.RowIndex).Value
        drpRevenueCenter.SelectedValue = grdDRRSale("RevenueCenterId", e.RowIndex).Value

        txtFoodTransfer.Text = grdDRRSale("FoodTransferAmount", e.RowIndex).Value
        txtBevTransfer.Text = grdDRRSale("BevTransferAmount", e.RowIndex).Value
        txtBevtofood.Text = grdDRRSale("BeverageToFood", e.RowIndex).Value

        DtBusinessDate.Value = grdDRRSale("Businessdate", e.RowIndex).Value

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

    Private Sub DtBusinessDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DtBusinessDate.ValueChanged
        InitScreen()
    End Sub

    Private Sub imgNew_Click(sender As System.Object, e As System.EventArgs) Handles imgNew.Click
        ClrScreen()
    End Sub

    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(DtBusinessDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "'"
        GenerateReport("drrsale", "proc#" & "spr_fetchdrrreport" & "#" & StrParam & "#100")
    End Sub

End Class