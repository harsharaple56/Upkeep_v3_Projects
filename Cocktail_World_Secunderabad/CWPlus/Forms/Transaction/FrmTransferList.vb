Imports System.Data
Imports CWPlusBL.Master



Public Class FrmTransferList

    Private Sub FrmTransferList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)


        FetchTransferHeadDetails()
        lblTransferHeadID.Visible = False
    End Sub
    Property TransferHeadID As Double = 0
    Public Sub FetchTransferHeadDetails()
        Dim ObjTransferHead As New ClsTransfer
        Dim ObjPriDt As New DataTable
        Try

            ObjTransferHead.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjTransferHead.TransferHeadID = lblTransferHeadID.Text
            ObjTransferHead.TPNo = txtTPNo.Text
            ObjTransferHead.InviceNo = txtInvoiceNo.Text

            If chkTransferDate.Checked Then
                ' ObjTransferHead.TransferDate = dtToDate.Text
                ObjTransferHead.FromDate = dtFromDate.Text
                ObjTransferHead.ToDate = dtToDate.Text
            Else
                'ObjTransferHead.TransferDate = "1-1-1900"
                ObjTransferHead.FromDate = "1-1-1900"
                ObjTransferHead.ToDate = "1-1-1900"
            End If

            ' ObjTransferHead.TransferDate = dtTransferDate.Text
            ObjPriDt = ObjTransferHead.FunFetch
            grdTransferList.DataSource = Nothing
            grdTransferList.DataSource = ObjPriDt

            grdTransferList.Columns("licenseid").Visible = False
            grdTransferList.Columns("forlicenseid").Visible = False
            grdTransferList.Columns("transferheadid").Visible = False

        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjTransferHead) = False Then
                ObjTransferHead = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FetchTransferHeadDetails()
    End Sub

    Private Sub btnNewTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim NewTransfer As New FrmTransfer
        'NewTransfer.Show()


        'Dim parentNod As New TreeNode("master")
        'Dim childNod As New TreeNode("transfer")
        'parentNod.Nodes.Add(childNod)
        'OpenForm(childNod)
        'Me.Close()
    End Sub

   
    Private Sub grdTransferList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTransferList.CellContentClick

        '[+][13/12/2019][Ajay Prajapati]
        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Then
            Dim BillDate As Date
            Dim VarianceCount As Integer
            BillDate = Date.Parse(grdTransferList.Item(3, e.RowIndex).Value)
            Dim ObjSaler As New ClsSale
            Dim ObjCheckVariance As New DataTable
            ObjSaler.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjSaler.BillDate = BillDate
            ObjSaler.TransactionType = "T" 'Transfer
            ObjCheckVariance = ObjSaler.FunCheckVariance()
            If (ObjCheckVariance.Rows.Count > 0) Then
                VarianceCount = Convert.ToInt32(ObjCheckVariance.Rows(0)("VarianceCount"))
            End If

            If (VarianceCount > 0) Then
                MsgBox("Can not modify the Transfer since Variance done", MsgBoxStyle.OkOnly, "Transfer")
                Exit Sub
            End If

        End If
        '[-][13/12/2019][Ajay Prajapati]


        If e.ColumnIndex = 0 Then
            Dim frmForm2 As New FrmTransfer()
            frmForm2.TransferHeadID = grdTransferList.Item(2, e.RowIndex).Value
            frmForm2.txtFLIV.Text = IIf(IsDBNull(grdTransferList.Item(8, e.RowIndex).Value), "", grdTransferList.Item(8, e.RowIndex).Value)
            frmForm2.txtInvoiceNo.Text = grdTransferList.Item(5, e.RowIndex).Value
            frmForm2.txtTransferHeadTPNo.Text = grdTransferList.Item(5, e.RowIndex).Value
            frmForm2.dtpTransferHead.Value = grdTransferList.Item(3, e.RowIndex).Value

            frmForm2.MdiParent = MDI
            frmForm2.Show()
            frmForm2.WindowState = FormWindowState.Maximized
            'Me.Close()
        ElseIf e.ColumnIndex = 1 Then

            If Not GblBoolDelete Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Transfer")
                Exit Sub
            End If
            Dim Ans As String = MsgBox("Are You Sure Want To Remove", MsgBoxStyle.YesNo, "Remove")
            If Ans = vbNo Then
                Exit Sub
            End If
            Dim objSale As New ClsTransfer
            objSale.TransferHeadID = grdTransferList.Item(2, e.RowIndex).Value
            objSale.UserName = gblUserName
            Dim str As String = objSale.FunDelete
            MsgBox(objSale.ErrorMsg)
            FetchTransferHeadDetails()
        End If      

    End Sub

    Private Sub imgNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgNew.Click
        Dim parentNod As New TreeNode("master")
        Dim childNod As New TreeNode("transfermst")
        childNod.Tag = "Transfer"
        parentNod.Nodes.Add(childNod)
        OpenForm(childNod)
        'Me.Close()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub



End Class