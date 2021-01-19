Imports CWPlusBL.Master
Imports System.Data
Public Class FrmLicenseMst

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(GroupBox1)
    End Sub

    Private Sub FrmLicenseMst_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AssignRights(gblMenuDesc)
        BindForFL3Combo()
        FetchLicenseMstDetails()

    End Sub

#Region "Procedure"

    

    Public Function Save()
        Dim ObjLicense As New ClsLicenseMst
        Dim ObjPriDt As New DataTable
        Save = False

        Try
            If gblLicenseID = 0 Then
                If Not GblBoolNew Then
                    MsgBox("Access Denied", MsgBoxStyle.Information, "License")
                    Exit Function
                End If
            Else
                If Not GblBoolEdit Then
                    MsgBox("Access Denied", MsgBoxStyle.Information, "License")
                    Exit Function
                End If
            End If
            
            If txtlicenseNo.Text = "" Then
                MsgBox("Please isnsert LicenseNo")
                Exit Function
            ElseIf txtLicName.Text = "" Then
                MsgBox("Please isnsert LicenseName")
                Exit Function
            ElseIf chkIsRack.Checked And Not cmbForFL3.SelectedValue > 0 Then
                MsgBox("Please select For FL3")
                Exit Function
            End If

            ObjLicense.LicenseID = gblLicenseID

            ObjLicense.LicenseDesc = txtLicName.Text
            ObjLicense.LicenseNo = txtlicenseNo.Text
            ObjLicense.Add1 = txtAdd1.Text
            ObjLicense.Add2 = txtAdd2.Text
            ObjLicense.City = txtCity.Text
            ObjLicense.PinCode = txtPincode.Text
            ObjLicense.Telephone = txtPhone.Text
            ObjLicense.Email = txtEmail.Text

            ObjLicense.Bst = txtBst.Text
            ObjLicense.Cst = txtCst.Text
            If chkStore.Checked = True Then
                ObjLicense.Store = 1
            Else
                ObjLicense.Store = 0
            End If
            ObjLicense.IsRack = chkIsRack.Checked
            If chkIsRack.Checked Then
                ObjLicense.ForFL3ID = cmbForFL3.SelectedValue
            Else
                ObjLicense.ForFL3ID = 0
            End If
            ObjLicense.UserName = gblUserName
            Save = ObjLicense.FunSave()
            MsgBox(ObjLicense.ErrorMsg)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjLicense) = False Then
                ObjLicense = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Function

#End Region


    Sub BindForFL3Combo()
        Dim ObjLicense As New Utitity
        Dim ObjPriDt As New DataTable
        Try

            ObjPriDt = ObjLicense.FunFetchLicense()
            ComboBindingTemplate(cmbForFL3, ObjPriDt, "LicenseDesc", "LicenseID")
        Catch ex As Exception
            Throw ex
        Finally
            ObjLicense = Nothing
            ObjPriDt = Nothing
        End Try
      
    End Sub

    Public Sub FetchLicenseMstDetails()
        Dim ObjLicense As New Utitity
        Dim ObjPriDt As New DataTable
        Try
            If gblLicenseID = 0 Then
                Exit Sub
            Else
                ObjLicense.LicenseID = gblLicenseID
                ObjPriDt = ObjLicense.FunFetchLicense()

                If ObjPriDt.Rows.Count > 0 Then
                    txtLicName.Text = ObjPriDt.Rows(0).Item("LicenseDesc")
                    txtlicenseNo.Text = ObjPriDt.Rows(0).Item("LicenseNo")
                    txtAdd1.Text = ObjPriDt.Rows(0).Item("Add1")
                    txtAdd2.Text = ObjPriDt.Rows(0).Item("Add2")
                    txtCity.Text = ObjPriDt.Rows(0).Item("City")
                    txtPincode.Text = ObjPriDt.Rows(0).Item("Pincode")
                    txtPhone.Text = ObjPriDt.Rows(0).Item("Telephone")
                    txtEmail.Text = ObjPriDt.Rows(0).Item("Email")
                    txtBst.Text = ObjPriDt.Rows(0).Item("Bst")
                    txtCst.Text = ObjPriDt.Rows(0).Item("Cst")
                    If ObjPriDt.Rows(0).Item("Store") = True Then
                        chkStore.Checked = True
                    Else
                        chkStore.Checked = False
                    End If
                    chkIsRack.Checked = ObjPriDt.Rows(0).Item("IsRack")
                    If chkIsRack.Checked Then
                       
                        cmbForFL3.SelectedValue = ObjPriDt.Rows(0).Item("forFl3ID")
                    End If
                End If


                'grdLicenseMst.Rows.Add()
                'grdLicenseMst("Store", rwctr).Value = ObjPriDt.Rows(rwctr)("Store")
                'grdLicenseMst("FreezDate", rwctr).Value = ObjPriDt.Rows(rwctr)("FreezDate")

                'grdLicenseMst("LicenseID", rwctr).Value = ObjPriDt.Rows(rwctr)("LicenseID")
                'grdLicenseMst("LicenseDesc", rwctr).Value = ObjPriDt.Rows(rwctr)("LicenseDesc")
                'grdLicenseMst("LicenseNo", rwctr).Value = ObjPriDt.Rows(rwctr)("LicenseNo")
                'grdLicenseMst("Add1", rwctr).Value = ObjPriDt.Rows(rwctr)("Add1")
                'grdLicenseMst("Add2", rwctr).Value = ObjPriDt.Rows(rwctr)("Add2")
                'grdLicenseMst("City", rwctr).Value = ObjPriDt.Rows(rwctr)("City")
                'grdLicenseMst("Pincode", rwctr).Value = ObjPriDt.Rows(rwctr)("Pincode")
                'grdLicenseMst("Telephone", rwctr).Value = ObjPriDt.Rows(rwctr)("Telephone")
                'grdLicenseMst("Email", rwctr).Value = ObjPriDt.Rows(rwctr)("Email")
                'grdLicenseMst("Bst", rwctr).Value = ObjPriDt.Rows(rwctr)("Bst")
                'grdLicenseMst("Cst", rwctr).Value = ObjPriDt.Rows(rwctr)("Cst")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjLicense) = False Then
                ObjLicense = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click, imgSave.Click
        If Save() = True Then
            Me.Close()
            Dim frmForm2 As New FrmLicenseList()
            frmForm2.MdiParent = MDI
            frmForm2.Show()
            Exit Sub
        End If
    End Sub

    Private Sub chkIsRack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsRack.CheckedChanged
        If chkIsRack.Checked Then
            lblForFL3.Visible = True
            cmbForFL3.Visible = True
            chkStore.Checked = False
        Else
            lblForFL3.Visible = False
            cmbForFL3.Visible = False
        End If
    End Sub

    Private Sub chkStore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStore.CheckedChanged
        If chkStore.Checked Then
            chkIsRack.Checked = False

        End If
    End Sub
End Class