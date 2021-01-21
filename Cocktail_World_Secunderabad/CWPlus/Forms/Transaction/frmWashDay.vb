Imports CWPlusBL.Master
Public Class frmWashDay

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnWash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWash.Click
        'If (MDI.cmbLicenseName.Text = "") Then
        '    MsgBox("Select License Name", MsgBoxStyle.Critical, "Wash Day")
        '    MDI.cmbLicenseName.Focus()
        '    Exit Sub
        'End If
       
        If MDI.cmbLicenseName.SelectedValue = 0 Then
            MsgBox("Select License Name", MsgBoxStyle.Critical, "Wash Day")
            Exit Sub
            'ElseIf chkSale.Checked = False Then
            '    MsgBox("Select Sale", MsgBoxStyle.Critical, "Wash Day")
            '    Exit Sub
        End If



        If chkTransfer.Checked = True And cmbLicense.SelectedValue = 0 Then
            MsgBox("Select For License Name", MsgBoxStyle.Critical, "Wash Day")
            Exit Sub
        ElseIf chkTransfer.Checked = False And cmbLicense.SelectedValue <> 0 Then
            MsgBox("Select Sale OR Transfer", MsgBoxStyle.Critical, "Wash Day")
            Exit Sub
        End If


        Dim objSale As New ClsSale
        Try
            objSale.LicenseID = MDI.cmbLicenseName.SelectedValue
            objSale.FromDate = dtpFrom.Value
            objSale.ToDate = dtpTo.Value
            objSale.forLicenseID = cmbLicense.SelectedValue
            objSale.FunWashDay(chkPurchase.Checked, chkSale.Checked, chkTransfer.Checked)
            MsgBox(objSale.ErrorMsg)
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objSale) Then
                objSale = Nothing
            End If
        End Try

    End Sub

    Private Sub frmWashDay_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmbLicense.Visible = False
        lblLicenseID.Visible = False
        BindLicenseForTransfer()
    End Sub

    Public Sub BindLicenseForTransfer()
        Dim ObjLicense As New Utitity
        Dim objdt As New DataTable
        Try
            ObjLicense.LicenseID = MDI.cmbLicenseName.SelectedValue
            objdt = ObjLicense.FunFetchLicenseForTransferWise

            ComboBindingTemplate(cmbLicense, objdt, "LicenseDesc", "LicenseID")
            'cmbAgainst.SelectedItem = "General"
            cmbLicense.SelectedValue = 0
            If objdt.Rows.Count = 2 Then
                If objdt.Rows(1)("IsSelected") Then
                    cmbLicense.SelectedValue = objdt.Rows(1)("LicenseID")
                    'cmbAgainst.SelectedItem = "TP"
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjLicense) Then
                ObjLicense = Nothing
            End If
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
        End Try
    End Sub

    Private Sub chkTransfer_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTransfer.CheckedChanged
        Select Case (chkTransfer.CheckState)
            Case CheckState.Checked
                cmbLicense.SelectedValue = 0
                cmbLicense.Visible = True
                lblLicenseID.Visible = True
                chkSale.Checked = False
            Case CheckState.Unchecked
                cmbLicense.Visible = False
                lblLicenseID.Visible = False
            Case CheckState.Indeterminate
                ' Code for indeterminate state.  
        End Select
    End Sub

    Private Sub chkSale_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSale.CheckedChanged
        Select Case (chkSale.CheckState)
            Case CheckState.Checked
                chkTransfer.Checked = False
        End Select
    End Sub
End Class