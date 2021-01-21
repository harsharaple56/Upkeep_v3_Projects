Imports System.Data
Imports CWPlusBL.Master
Public Class FrnSaleList

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(Sale)
    End Sub

    Private Sub FrnSaleList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        chkSale.Checked = True
        FetchSaleList()
        lblSaleID.Visible = False
        '  grdSaleList.Columns("billId").Visible = False


    End Sub
    Public Function FunDelete() As Boolean
        Dim ObjSale As New ClsSale
        Dim Objdt As New DataTable
        FunDelete = False
        Try
            ObjSale.BillID = lblSaleID.Text
            ObjSale.UserName = gblUserName
            'FunDelete = ObjSale.FunDelete
            MsgBox(ObjSale.ErrorMsg)

        Catch ex As Exception
            Throw ex
            If IsNothing(ObjSale) = False Then
                ObjSale = Nothing
            End If
            If IsNothing(Objdt) = False Then
                Objdt = Nothing
            End If

        End Try
    End Function

    Public Sub FetchSaleList()
        Dim ObjSalerHead As New ClsSale
        Dim ObjPriDt As New DataTable
        Try

            ObjSalerHead.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjSalerHead.BillID = lblSaleID.Text
            ObjSalerHead.BillNo = txtBillno.Text

            If chkSale.Checked = True Then
                '  ObjSalerHead.BillDate = dtToDate.Text
                ObjSalerHead.FromDate = dtFromDate.Value
                ObjSalerHead.ToDate = dtToDate.Value


            Else
                ObjSalerHead.FromDate = "1-1-1900"
                ObjSalerHead.ToDate = "1-1-1900"
            End If


            ObjPriDt = ObjSalerHead.FunFetch()
            grdSaleList.DataSource = ObjPriDt
            grdSaleList.Columns("billid").Visible = False
            grdSaleList.Columns("licenseid").Visible = False

            grdSaleList.Columns("LicenseCode").Visible = False
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjSalerHead) = False Then
                ObjSalerHead = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If

        End Try
        grdSaleList.Visible = True
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FetchSaleList()
    End Sub

    'Private Sub btnNewSale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewSale.Click
    '    'Dim ObjNewSale As New FrmSaleMst
    '    'ObjNewSale.Show()

    '    Dim parentnode As New TreeNode("master")
    '    Dim childnode As New TreeNode("sale")
    '    parentnode.Nodes.Add(childnode)
    '    OpenForm(childnode)
    '    Me.Close()
    'End Sub

    Private Sub grdSaleList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSaleList.CellContentClick
        '[+][13/12/2019][Ajay Prajapati]
        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Then
            Dim BillDate As Date
            Dim VarianceCount As Integer
            BillDate = Date.Parse(grdSaleList.Item(4, e.RowIndex).Value)
            Dim ObjSaler As New ClsSale
            Dim ObjCheckVariance As New DataTable
            ObjSaler.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjSaler.BillDate = BillDate
            ObjSaler.TransactionType = "S" 'Sale
            ObjCheckVariance = ObjSaler.FunCheckVariance()
            If (ObjCheckVariance.Rows.Count > 0) Then
                VarianceCount = Convert.ToInt32(ObjCheckVariance.Rows(0)("VarianceCount"))
            End If

            If (VarianceCount > 0) Then
                MsgBox("Can not modify the sale since Variance done", MsgBoxStyle.OkOnly, "Remove")

                Exit Sub
            End If

        End If
        '[-][13/12/2019][Ajay Prajapati]
        If e.ColumnIndex = 0 Then

            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Sale")
                Exit Sub
            End If
            Dim frmForm2 As New FrmSaleMst()
            frmForm2.BillID = grdSaleList.Item(2, e.RowIndex).Value
            frmForm2.Dtdate.Text = ""
            frmForm2.txtBillno.Text = ""

            frmForm2.MdiParent = MDI
            frmForm2.Show()
            frmForm2.WindowState = FormWindowState.Maximized
            'Me.Close()
        ElseIf e.ColumnIndex = 1 Then
            If Not GblBoolDelete Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Sale")
                Exit Sub
            End If
            Dim Ans As String = MsgBox("Are You Sure Want To Remove", MsgBoxStyle.YesNo, "Remove")
            If Ans = vbNo Then
                Exit Sub
            End If
            Dim objSale As New ClsSale
            objSale.BillID = grdSaleList.Item(2, e.RowIndex).Value
            objSale.UserName = gblUserName
            Dim str As String = objSale.FunDelete
            MsgBox(objSale.ErrorMsg)
            FetchSaleList()
        End If


    End Sub

    Private Sub imgNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgNew.Click
        Dim parentnode As New TreeNode("master")
        Dim childnode As New TreeNode("salemst")
        childnode.Tag = "Sale"
        parentnode.Nodes.Add(childnode)
        OpenForm(childnode)
        'Me.Close()
    End Sub
    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
End Class