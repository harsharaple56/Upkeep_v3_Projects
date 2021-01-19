'[+][13/12/2019][Ajay Prajapati]
Imports CWPlusBL.Master
'[-][13/12/2019][Ajay Prajapati]

Public Class FrmPurchasedetail
    Dim objpurchasedet As CWPlusBL.Master.Clspurchase
    Dim objdt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(GroupBox1)
    End Sub
#Region "Procedure"
    Public Sub Bindgrid()
        Try
            objpurchasedet = New CWPlusBL.Master.Clspurchase
            objdt = New DataTable


            objpurchasedet.LicenseID = MDI.cmbLicenseName.SelectedValue
            objpurchasedet.PurchaseID = lblid.Text
            If Chkdatewise.Checked Then
                ' objpurchasedet.Purchasedate = Dtdate.Text
                objpurchasedet.FromDate = Dtdate.Value
                objpurchasedet.ToDate = dtTodate.Value
            Else
                'objpurchasedet.FromDate = "1-1-1900"
                'objpurchasedet.ToDate = "1-1-1900"
                objpurchasedet.FromDate = "1-1-1900"
                objpurchasedet.ToDate = "1-1-1900"
            End If
            objpurchasedet.TPno = txtTpno.Text
            objpurchasedet.InvoiceNo = txtInvoiceNo.Text
            objdt = objpurchasedet.FunFetch()

            grdpurchasedetail.DataSource = objdt
            grdpurchasedetail.Columns("discount").Visible = False
            grdpurchasedetail.Columns("discountper").Visible = False
            grdpurchasedetail.Columns("otherchargetype").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(objpurchasedet) Then
                objpurchasedet = Nothing
            End If
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
        End Try
    End Sub

#End Region
    Private Sub FrmPurchasedetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        Bindgrid()
        grdpurchasedetail.Columns("purchaseId").Visible = False
        grdpurchasedetail.Columns("LicenseId").Visible = False
        grdpurchasedetail.Columns("ForLicenseId").Visible = False
        grdpurchasedetail.Columns("PurchaseDate").Width = 130
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim parentNod As New TreeNode("master")
        'Dim childNod As New TreeNode("purmst")
        'parentNod.Nodes.Add(childNod)
        'OpenForm(childNod)
        'Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Bindgrid()
    End Sub

    Private Sub grdpurchasedetail_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdpurchasedetail.CellDoubleClick
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' FunDelete()
    End Sub
    Public Function FunDelete() As Boolean
        FunDelete = False
        Try
            objpurchasedet = New CWPlusBL.Master.Clspurchase
            objpurchasedet.PurchaseID = lblid.Text
            objpurchasedet.UserName = gblUserName
            FunDelete = objpurchasedet.FunDelete
            MsgBox(objpurchasedet.ErrorMsg)
            Bindgrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(objpurchasedet) Then
                objpurchasedet = Nothing
            End If
        End Try
    End Function

    Private Sub grdpurchasedetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdpurchasedetail.CellContentClick

        '[+][13/12/2019][Ajay Prajapati]
        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Then
            Dim BillDate As Date
            Dim VarianceCount As Integer
            BillDate = Date.Parse(grdpurchasedetail.Item(6, e.RowIndex).Value)
            Dim ObjSaler As New ClsSale
            Dim ObjCheckVariance As New DataTable
            ObjSaler.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjSaler.BillDate = BillDate
            ObjSaler.TransactionType = "P" 'Purchase
            ObjCheckVariance = ObjSaler.FunCheckVariance()
            If (ObjCheckVariance.Rows.Count > 0) Then
                VarianceCount = Convert.ToInt32(ObjCheckVariance.Rows(0)("VarianceCount"))
            End If

            If (VarianceCount > 0) Then
                MsgBox("Can not modify the Purchase since Variance done", MsgBoxStyle.OkOnly, "Purchase")
                Exit Sub
            End If
        End If
        '[-][13/12/2019][Ajay Prajapati]



        If e.ColumnIndex = 0 Then
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Purchase")
                Exit Sub
            End If
            Dim frmForm2 As New FrmpurchaseMst()
            frmForm2.PurchaseID = grdpurchasedetail.Item(2, e.RowIndex).Value


            'Added By Mohammed on 29-March-2019 Starts
            If IsDBNull(grdpurchasedetail.Item(6, e.RowIndex).Value) = False Then
                frmForm2.Dtdate.Text = grdpurchasedetail.Item(6, e.RowIndex).Value
            Else
                frmForm2.Dtdate.Text = Date.Today
            End If
            If IsDBNull(grdpurchasedetail.Item(3, e.RowIndex).Value) = False Then
                frmForm2.txttpno.Text = grdpurchasedetail.Item(3, e.RowIndex).Value
            Else
                frmForm2.txttpno.Text = ""
            End If
            If IsDBNull(grdpurchasedetail.Item(4, e.RowIndex).Value) = False Then

                frmForm2.txtGRNForCode.Text = grdpurchasedetail.Item(4, e.RowIndex).Value
            Else
                frmForm2.txtGRNForCode.Text = ""
            End If
            If IsDBNull(grdpurchasedetail.Item(5, e.RowIndex).Value) = False Then

                frmForm2.txtInvoiceno.Text = grdpurchasedetail.Item(5, e.RowIndex).Value
            Else
                frmForm2.txtInvoiceno.Text = ""
            End If

            'Added By Mohammed on 29-March-2019 Ends

            'Commented By Mohammed on 29-March-2019 Starts

            'If IsDBNull(grdpurchasedetail.Item(5, e.RowIndex).Value) = False Then
            '    frmForm2.Dtdate.Text = grdpurchasedetail.Item(5, e.RowIndex).Value
            'Else
            '    frmForm2.Dtdate.Text = Date.Today
            'End If
            'If IsDBNull(grdpurchasedetail.Item(3, e.RowIndex).Value) = False Then
            '    frmForm2.txttpno.Text = grdpurchasedetail.Item(3, e.RowIndex).Value
            'Else
            '    frmForm2.txttpno.Text = ""
            'End If
            'If IsDBNull(grdpurchasedetail.Item(4, e.RowIndex).Value) = False Then

            '    frmForm2.txtInvoiceno.Text = grdpurchasedetail.Item(4, e.RowIndex).Value
            'Else
            '    frmForm2.txtInvoiceno.Text = ""
            'End If

            'Commented By Mohammed on 29-March-2019 Ends


            frmForm2.MdiParent = MDI
            frmForm2.Show()
            frmForm2.WindowState = FormWindowState.Maximized
            'Me.Close()
        ElseIf e.ColumnIndex = 1 Then
            If Not GblBoolDelete Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Purchase")
                Exit Sub
            End If
            Dim Ans As String = MsgBox("Are You Sure Want To Remove", MsgBoxStyle.YesNo, "Remove")
            If Ans = vbNo Then
                Exit Sub
            End If
            objpurchasedet = New CWPlusBL.Master.Clspurchase
            objpurchasedet.PurchaseID = grdpurchasedetail.Item(2, e.RowIndex).Value
            objpurchasedet.UserName = gblUserName
            Dim str As String = objpurchasedet.FunDelete
            MsgBox(objpurchasedet.ErrorMsg)
            Bindgrid()
        End If
    End Sub



    Private Sub imgNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgNew.Click
        Dim parentNod As New TreeNode("master")
        Dim childNod As New TreeNode("purmst")
        childNod.Tag = "Purchase"
        parentNod.Nodes.Add(childNod)
        OpenForm(childNod)
        'Me.Close()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
End Class