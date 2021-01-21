Imports System.Data
Imports CWPlusBL.Master

Public Class FrmInterfaceFileSetUp

    Private Sub FrmInterfaceFileSetUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        BindDropDown()
        BindDate()
        FetchInterfaceFileSetUp()

        FetchPurchaseInterfaceFileSetUp()
        FetchTransferInterfaceFileSetUp()
    End Sub
    Public Sub BindDropDown()
        cmbFileType.Items.Add("Separator")
        cmbFileType.Items.Add("Xl Sheet")
        cmbFileType.SelectedText = "Separator"

        cmbPurFileType.Items.Add("Separator")
        cmbPurFileType.Items.Add("Xl Sheet")
        cmbPurFileType.SelectedText = "Separator"

        cmbTranFileType.Items.Add("Separator")
        cmbTranFileType.Items.Add("Xl Sheet")
        cmbTranFileType.SelectedText = "Separator"

    End Sub
    Public Sub BindDate()
        cmbFileNameDate.Items.Add("None")
        cmbFileNameDate.Items.Add("DDMMYY")
        cmbFileNameDate.Items.Add("DDMMYYYY")
        cmbFileNameDate.Items.Add("MMDDYY")
        cmbFileNameDate.Items.Add("MMDDYYYY")
        cmbFileNameDate.Items.Add("YYMMDD")
        cmbFileNameDate.Items.Add("YYYYMMDD")
        cmbFileNameDate.SelectedText = "None"

        cmbExpDtDesc.Items.Add("None")
        cmbExpDtDesc.Items.Add("DDMMYY")
        cmbExpDtDesc.Items.Add("DDMMYYYY")
        cmbExpDtDesc.Items.Add("MMDDYY")
        cmbExpDtDesc.Items.Add("MMDDYYYY")
        cmbExpDtDesc.Items.Add("YYMMDD")
        cmbExpDtDesc.Items.Add("YYYYMMDD")
        cmbExpDtDesc.SelectedText = "None"

        cmbPurFileNameDate.Items.Add("None")
        cmbPurFileNameDate.Items.Add("DDMMYY")
        cmbPurFileNameDate.Items.Add("DDMMYYYY")
        cmbPurFileNameDate.Items.Add("MMDDYY")
        cmbPurFileNameDate.Items.Add("MMDDYYYY")
        cmbPurFileNameDate.Items.Add("YYMMDD")
        cmbPurFileNameDate.Items.Add("YYYYMMDD")
        cmbPurFileNameDate.SelectedText = "None"

        cmbPurExpDtDesc.Items.Add("None")
        cmbPurExpDtDesc.Items.Add("DDMMYY")
        cmbPurExpDtDesc.Items.Add("DDMMYYYY")
        cmbPurExpDtDesc.Items.Add("MMDDYY")
        cmbPurExpDtDesc.Items.Add("MMDDYYYY")
        cmbPurExpDtDesc.Items.Add("YYMMDD")
        cmbPurExpDtDesc.Items.Add("YYYYMMDD")
        cmbPurExpDtDesc.SelectedText = "None"
    End Sub
    Public Sub BindExpDate()

    End Sub


    Public Sub FetchInterfaceFileSetUp()
        Dim ObjInterface As New ClsInterfaceFileSetUp
        Dim ObjPriDt As New DataTable
        Try
            ObjPriDt = ObjInterface.FunFetch()

            If ObjPriDt.Rows.Count > 0 Then
                cmbFileType.SelectedItem = ObjPriDt.Rows(0).Item("FileType")

                '                InterfaceFileID,FileType,InterfaceFileDesc,Symbol,FilePrefix,FileExtension,Date,LicenseCodeDef,LicenseCodeLength,LicenseCodePosition,
                'PositionBillNo,PositionCode,PositionQty,PositionRate,PositionPriceSequence,PermitHolderType,PermitHolderNo,PermitHolderName,PermitHolderExpDt
                '                PermitHolderExpDtDesc, FilePath, BackUpFilePath
                txtSymbol.Text = ObjPriDt.Rows(0).Item("Symbol")
                txtPrefix.Text = ObjPriDt.Rows(0).Item("FilePrefix")
                txtExtension.Text = ObjPriDt.Rows(0).Item("FileExtension")


                If rbtnManual.Checked = True Then
                    ObjInterface.Date1 = "Null"
                ElseIf rbtnFileName.Checked = True Then
                    ObjInterface.Date1 = cmbFileNameDate.SelectedItem
                End If
                If ObjPriDt.Rows(0).Item("Date") = "Null" Then
                    rbtnManual.Checked = True
                Else
                    rbtnFileName.Checked = True
                    cmbFileNameDate.SelectedItem = ObjPriDt.Rows(0).Item("Date")
                End If



                txtLicenseLength.Text = ObjPriDt.Rows(0).Item("LicenseCodeLength")
                txtLicensePosition.Text = ObjPriDt.Rows(0).Item("LicenseCodePosition")
                txtBillNo.Text = ObjPriDt.Rows(0).Item("PositionBillNo")
                txtCode.Text = ObjPriDt.Rows(0).Item("PositionCode")
                txtQty.Text = ObjPriDt.Rows(0).Item("PositionQty")
                txtRate.Text = ObjPriDt.Rows(0).Item("PositionRate")
                txtPriceSquence.Text = ObjPriDt.Rows(0).Item("PositionPriceSequence")
                txtPermitHolderNo.Text = ObjPriDt.Rows(0).Item("PermitHolderNo")
                txtPermitHolderName.Text = ObjPriDt.Rows(0).Item("PermitHolderName")
                txtPermitHolderExpDt.Text = ObjPriDt.Rows(0).Item("PermitHolderExpDt")
                txtFilePath.Text = ObjPriDt.Rows(0).Item("FilePath")
                txtBackUpFilePath.Text = ObjPriDt.Rows(0).Item("BackUpFilePath")
                cmbExpDtDesc.SelectedItem = ObjPriDt.Rows(0).Item("PermitHolderExpDtDesc")

                If ObjPriDt.Rows(0).Item("PermitHolderType") = 1 Then
                    rbtnInFilePermitHolder.Checked = True
                ElseIf ObjPriDt.Rows(0).Item("PermitHolderType") = 2 Then
                    rbtnAutoPermitHolder.Checked = True
                ElseIf ObjPriDt.Rows(0).Item("PermitHolderType") = 3 Then
                    rbtnPermitHolderNA.Checked = True
                End If

                If ObjPriDt.Rows(0).Item("LicenseCodeDef") = 1 Then
                    rbtnLicenseInFileName.Checked = True
                ElseIf ObjPriDt.Rows(0).Item("LicenseCodeDef") = 2 Then
                    rbtnLicenseInFile.Checked = True
                ElseIf ObjPriDt.Rows(0).Item("LicenseCodeDef") = 3 Then
                    rbtnFullName.Checked = True
                End If


                If ObjPriDt.Rows(0).Item("Date") = "" Then
                    rbtnManual.Checked = True
                ElseIf ObjPriDt.Rows(0).Item("Date") = "DDMMYYYY" Then
                    rbtnManual.Checked = True
                End If


            End If


        Catch ex As Exception
            Throw ex

        Finally
            If IsNothing(ObjInterface) = False Then
                ObjInterface = Nothing
            End If

            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try

    End Sub


    Public Function Save() As Boolean
        Save = False
        If Not GblBoolNew Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Interface File Setup")
            Exit Function
        End If
        Dim ObjInterface As New ClsInterfaceFileSetUp
        Dim ObjPriDt As New DataTable
        Try
            ObjInterface.FileType = cmbFileType.SelectedItem
            ObjInterface.Symbol = txtSymbol.Text
            ObjInterface.FilePrefix = Trim(txtPrefix.Text)
            ObjInterface.FileExtension = Trim(txtExtension.Text)
            If rbtnManual.Checked = True Then
                ObjInterface.Date1 = "Null"
            ElseIf rbtnFileName.Checked = True Then
                ObjInterface.Date1 = cmbFileNameDate.SelectedItem
            End If
            If rbtnLicenseInFileName.Checked = True Then
                ObjInterface.LicenseCodeDef = 1
            ElseIf rbtnLicenseInFile.Checked = True Then
                ObjInterface.LicenseCodeDef = 2
            ElseIf rbtnFullName.Checked = True Then
                ObjInterface.LicenseCodeDef = 3
            End If
            ObjInterface.LicenseCodeLength = txtLicenseLength.Text
            ObjInterface.LicenseCodePosition = txtLicensePosition.Text
            ObjInterface.PositionBillNo = txtBillNo.Text
            ObjInterface.PositionCode = txtCode.Text
            ObjInterface.PositionQty = txtQty.Text
            ObjInterface.PositionRate = txtRate.Text
            ObjInterface.PositionPriceSequence = IIf(Trim(txtPriceSquence.Text) = "", 0, Trim(txtPriceSquence.Text))
            If rbtnInFilePermitHolder.Checked = True Then
                ObjInterface.PermitHolderType = 1
            ElseIf rbtnAutoPermitHolder.Checked = True Then
                ObjInterface.PermitHolderType = 2
            ElseIf rbtnPermitHolderNA.Checked = True Then
                ObjInterface.PermitHolderType = 3
            End If
            ObjInterface.PermitHolderNo = IIf(txtPermitHolderNo.Text = "", 0, txtPermitHolderNo.Text)
            ObjInterface.PermitHolderName = txtPermitHolderName.Text
            ObjInterface.PermitHolderExpDt = txtPermitHolderExpDt.Text
            ObjInterface.PermitHolderExpDtDesc = cmbExpDtDesc.SelectedItem
            ObjInterface.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjInterface.FilePath = txtFilePath.Text
            ObjInterface.BackUpFilePath = txtBackUpFilePath.Text
            ObjInterface.UserName = gblUserName
            Save = ObjInterface.FunSave()
            MsgBox(ObjInterface.ErrorMsg)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjInterface) = False Then
                ObjInterface = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Function
    Private Sub btnFilePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilePath.Click
        If FBDFilePath.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFilePath.Text = FBDFilePath.SelectedPath
        End If

    End Sub

    Private Sub btnBackUpFilePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackUpFilePath.Click
        If FBDBAckUpFilePath.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtBackUpFilePath.Text = FBDBAckUpFilePath.SelectedPath
        End If

    End Sub

    Private Sub ofdBackUpFilePAth_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdBackUpFilePAth.FileOk

    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    'Private Sub txtBillNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBillNo.KeyPress, txtCode.KeyPress, txtQty.KeyPress, txtRate.KeyPress, txtPriceSquence.KeyPress, txtLicenseLength.KeyPress, txtLicensePosition.KeyPress, txtPermitHolderNo.KeyPress, txtSymbol.KeyPress
    '    If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
    '       Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
    '        e.Handled = True
    '    End If
    '    If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
    '        e.Handled = False
    '    End If
    'End Sub


#Region "Purchase interface"

    Private Sub FetchPurchaseInterfaceFileSetUp()
        Dim ObjFile As CWPlusBL.Master.ClsInterfaceFileSetUp
        Dim ObjPriDt As New DataTable
        Try
            ObjFile = New ClsInterfaceFileSetUp
            ObjPriDt = ObjFile.FunFetchInterfaceFilePurchaseSetUp
            If IsNothing(ObjPriDt) Then Exit Sub
            If ObjPriDt.Rows.Count > 0 Then
                txtPURBkpFilePath.Text = ObjPriDt.Rows(0)("BackupFilePath")
                txtPURFilePath.Text = ObjPriDt.Rows(0)("FilePath")
                txtPurPrefix.Text = ObjPriDt.Rows(0)("FilePrefix")
                txtPurExtn.Text = ObjPriDt.Rows(0)("FileExtension")


                txtPurchaseLength.Text = ObjPriDt.Rows(0).Item("LicenseCodeLength")                   'Added By RV on 29-March-2019
                txtLicencePurPosition.Text = ObjPriDt.Rows(0).Item("LicenseCodePosition")                   'Added By RV on 29-March-2019
                cmbPurFileType.SelectedItem = ObjPriDt.Rows(0)("FileType")
                txtPurSymbol.Text = ObjPriDt.Rows(0)("Symbol")
                txtPurLocNumber.Text = ObjPriDt.Rows(0)("PositionLocationNo")
                txtPurSupplierCode.Text = ObjPriDt.Rows(0)("PositionSupplierCode")
                txtPurTpno.Text = ObjPriDt.Rows(0)("PositionTPnumber")
                txtPurRRno.Text = ObjPriDt.Rows(0)("PostionRRnumber")
                txtPurItemCode.Text = ObjPriDt.Rows(0)("PostionItemCode")
                txtPurQuantity.Text = ObjPriDt.Rows(0)("PositionQuantity")
                txtPurRate.Text = ObjPriDt.Rows(0)("PositionRate")
                txtPurFreeQty.Text = ObjPriDt.Rows(0)("PositionFreeQty")

                If ObjPriDt.Rows(0).Item("LicenseCodeDef") = 1 Then
                    rbtnPurLicenseInFileName.Checked = True
                ElseIf ObjPriDt.Rows(0).Item("LicenseCodeDef") = 2 Then
                    rbtnPurLicenseInFile1.Checked = True
                ElseIf ObjPriDt.Rows(0).Item("LicenseCodeDef") = 3 Then
                    rbtnPurFullName.Checked = True
                End If

                '''''''''abhijeet start coding from here
            End If
        Catch ex As Exception
            Throw ex
        Finally
            ObjFile = Nothing
            ObjPriDt = Nothing
        End Try
    End Sub

#End Region

#Region "Transfer"

    Private Sub FetchTransferInterfaceFileSetUp()
        'Dim ObjFile As CWPlusBL.Master.ClsInterfaceFileSetUp
        'Dim ObjPriDt As New DataTable
        'Try
        '    ObjFile = New ClsInterfaceFileSetUp
        '    ObjPriDt = ObjFile.FunFetchInterfaceFileTransferSetUp
        '    If IsNothing(ObjPriDt) Then Exit Sub
        '    If ObjPriDt.Rows.Count > 0 Then
        '        txtTrnBkpFilePath.Text = ObjPriDt.Rows(0)("backupfilepath")
        '        txtTrnFilePath.Text = ObjPriDt.Rows(0)("FilePath")
        '        txtTrnPrefix.Text = ObjPriDt.Rows(0)("FilePrefix")
        '        txtTrnExtn.Text = ObjPriDt.Rows(0)("FileExtension")
        '    End If

        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    ObjFile = Nothing
        '    ObjPriDt = Nothing
        'End Try

        'SAMVEDNA'
        Dim ObjFile As CWPlusBL.Master.ClsInterfaceFileSetUp
        Dim ObjPriDt As New DataTable
        Try
            ObjFile = New ClsInterfaceFileSetUp
            ObjPriDt = ObjFile.FunFetchInterfaceFileTransferSetUp
            If IsNothing(ObjPriDt) Then Exit Sub
            If ObjPriDt.Rows.Count > 0 Then
                txtTrnBkpFilePath.Text = ObjPriDt.Rows(0)("BackupFilePath")
                txtTrnFilePath.Text = ObjPriDt.Rows(0)("FilePath")
                txtTrnPrefix.Text = ObjPriDt.Rows(0)("FilePrefix")
                txtTrnExtn.Text = ObjPriDt.Rows(0)("FileExtension")
                TxtTransLength.Text = ObjPriDt.Rows(0).Item("LicenseCodeLength")
                TxtTransPosition.Text = ObjPriDt.Rows(0).Item("LicenseCodePosition")
                cmbTranFileType.SelectedItem = ObjPriDt.Rows(0)("FileType")


                txtTranSymbol.Text = ObjPriDt.Rows(0)("Symbol")
                TxtTransFromLicenseNo.Text = ObjPriDt.Rows(0)("PositionFromLic")
                TxtTransToLicenseNo.Text = ObjPriDt.Rows(0)("PositionToLic")
                TxtTransTpNo.Text = ObjPriDt.Rows(0)("PositionTPnumber")
                TxtTransItemCode.Text = ObjPriDt.Rows(0)("PostionItemCode")
                TxtTransQty.Text = ObjPriDt.Rows(0)("PositionQuantity")
                TxtTransPrice.Text = ObjPriDt.Rows(0)("PositionRate")
                TxtTransFreeQty.Text = ObjPriDt.Rows(0)("PositionFreeQty")



                If ObjPriDt.Rows(0).Item("LicenseCodeDef") = 1 Then
                    rbtnTransLicenseInFileName.Checked = True
                ElseIf ObjPriDt.Rows(0).Item("LicenseCodeDef") = 2 Then
                    rbtnTransLicenseInFile1.Checked = True
                ElseIf ObjPriDt.Rows(0).Item("LicenseCodeDef") = 3 Then
                    rbtnTransFullName.Checked = True
                End If

            End If
        Catch ex As Exception
            Throw ex
        Finally
            ObjFile = Nothing
            ObjPriDt = Nothing
        End Try
    End Sub

#End Region

    Private Sub BtnPURSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnPURSave.Click
        If Not GblBoolNew Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Interface File Setup")
            Exit Sub
        End If
        Dim ObjInterface As New ClsInterfaceFileSetUp
        Dim ObjPriDt As New DataTable
        Try
            ObjInterface.PURFilePrefix = txtPurPrefix.Text
            ObjInterface.PURFileExtension = txtPurExtn.Text
            ObjInterface.PURFilePath = txtPURFilePath.Text
            ObjInterface.PURBackUpFilePath = txtPURBkpFilePath.Text
            ObjInterface.FileType = cmbPurFileType.SelectedItem
            ObjInterface.Symbol = txtPurSymbol.Text
            ObjInterface.LicenseCodeLength = txtPurchaseLength.Text
            ObjInterface.LicenseCodePosition = txtLicencePurPosition.Text

            If rbtnPurManual.Checked = True Then
                ObjInterface.Date1 = "Null"
            ElseIf rbtnFileName.Checked = True Then
                ObjInterface.Date1 = cmbFileNameDate.SelectedItem
            End If
            If rbtnPurLicenseInFileName.Checked = True Then
                ObjInterface.LicenseCodeDef = 1
            ElseIf rbtnPurLicenseInFile1.Checked = True Then
                ObjInterface.LicenseCodeDef = 2
            ElseIf rbtnPurFullName.Checked = True Then
                ObjInterface.LicenseCodeDef = 3
            End If


            ObjInterface.PositionLocationNumber = txtPurLocNumber.Text
            ObjInterface.PositionSupplierCode = txtPurSupplierCode.Text
            ObjInterface.PositionTPnumber = txtPurTpno.Text
            ObjInterface.PositionRRnumber = txtPurRRno.Text
            ObjInterface.PositionPurItemCode = txtPurItemCode.Text
            ObjInterface.PositionPurQuatity = txtPurQuantity.Text
            ObjInterface.PositionPurRate = txtPurRate.Text
            ObjInterface.positionPurFreeQty = txtPurFreeQty.Text

            ObjInterface.UserName = gblUserName
            ObjInterface.FunSaveInterfaceFilePurchaseSetup()
            MsgBox(ObjInterface.ErrorMsg)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjInterface) = False Then
                ObjInterface = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    'Private Sub BtnSaveTrn_Click(sender As System.Object, e As System.EventArgs) Handles BtnSaveTrn.Click
    '    If Not GblBoolNew Then
    '        MsgBox("Access Denied", MsgBoxStyle.Information, "Interface File Setup")
    '        Exit Sub
    '    End If
    '    Dim ObjInterface As New ClsInterfaceFileSetUp
    '    Dim ObjPriDt As New DataTable
    '    Try
    '        ObjInterface.TRNFilePrefix = txtTrnPrefix.Text
    '        ObjInterface.TRNFileExtension = txtTrnExtn.Text
    '        ObjInterface.TRNFilePath = txtTrnFilePath.Text
    '        ObjInterface.TRNBackUpFilePath = txtTrnBkpFilePath.Text
    '        ObjInterface.UserName = gblUserName
    '        ObjInterface.FunSaveInterfaceFileTransferSetup()
    '        MsgBox(ObjInterface.ErrorMsg)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        If IsNothing(ObjInterface) = False Then
    '            ObjInterface = Nothing
    '        End If
    '        If IsNothing(ObjPriDt) = False Then
    '            ObjPriDt = Nothing
    '        End If
    '    End Try
    'End Sub

    Private Sub BtnPURFilePath_Click(sender As System.Object, e As System.EventArgs) Handles BtnPURFilePath.Click
        If FBDBAckUpFilePath.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPURFilePath.Text = FBDBAckUpFilePath.SelectedPath
        End If
    End Sub

    Private Sub BtnPURBkpFilePath_Click(sender As System.Object, e As System.EventArgs) Handles BtnPURBkpFilePath.Click
        If FBDBAckUpFilePath.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPURBkpFilePath.Text = FBDBAckUpFilePath.SelectedPath
        End If
    End Sub

    Private Sub BtnTrnFilePath_Click(sender As System.Object, e As System.EventArgs) Handles BtnTrnFilePath.Click
        If FBDBAckUpFilePath.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtTrnFilePath.Text = FBDBAckUpFilePath.SelectedPath
        End If
    End Sub

    Private Sub BtnTrnBkpFilePath_Click(sender As System.Object, e As System.EventArgs) Handles BtnTrnBkpFilePath.Click
        If FBDBAckUpFilePath.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtTrnBkpFilePath.Text = FBDBAckUpFilePath.SelectedPath
        End If
    End Sub


    Private Sub cmbPurFileType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPurFileType.SelectedIndexChanged

    End Sub

    Private Sub GroupBox9_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox9.Enter

    End Sub

    Private Sub tabPurchase_Click(sender As System.Object, e As System.EventArgs) Handles tabPurchase.Click

    End Sub

    Private Sub GroupBox10_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox10.Enter

    End Sub

    Private Sub tabSale_Click(sender As System.Object, e As System.EventArgs) Handles tabSale.Click

    End Sub

    Private Sub BtnSaveTrn_Click(sender As System.Object, e As System.EventArgs) Handles BtnSaveTrn.Click
        If Not GblBoolNew Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Interface File Setup")
            Exit Sub
        End If
        Dim ObjInterface As New ClsInterfaceFileSetUp
        Dim ObjPriDt As New DataTable
        Try
            ObjInterface.TRNFilePrefix = txtTrnPrefix.Text
            ObjInterface.TRNFileExtension = txtTrnExtn.Text
            ObjInterface.TRNFilePath = txtTrnFilePath.Text
            ObjInterface.TRNBackUpFilePath = txtTrnBkpFilePath.Text
            ObjInterface.FileType = cmbTranFileType.SelectedItem
            ObjInterface.Symbol = txtTranSymbol.Text
            ObjInterface.LicenseCodeLength = TxtTransLength.Text
            ObjInterface.LicenseCodePosition = TxtTransPosition.Text

            If rbtnTranManual.Checked = True Then
                ObjInterface.Date1 = "Null"
            ElseIf rbtTranInFileDate.Checked = True Then
                ObjInterface.Date1 = cmbFileNameDate.SelectedItem
            End If
            If rbtnTransLicenseInFileName.Checked = True Then
                ObjInterface.LicenseCodeDef = 1
            ElseIf rbtnTransLicenseInFile1.Checked = True Then
                ObjInterface.LicenseCodeDef = 2
            ElseIf rbtnTransFullName.Checked = True Then
                ObjInterface.LicenseCodeDef = 3
            End If

            'SAM
            ObjInterface.PositionFromLic = TxtTransFromLicenseNo.Text
            ObjInterface.PositionToLic = TxtTransToLicenseNo.Text
            ObjInterface.PositionTPnumber = TxtTransTpNo.Text
            ObjInterface.PositionTRNItemCode = TxtTransItemCode.Text
            ObjInterface.PositionTRNQuatity = TxtTransQty.Text
            ObjInterface.PositionTRNRate = TxtTransPrice.Text
            ObjInterface.PositionTRNFreeQty = TxtTransFreeQty.Text

            ObjInterface.UserName = gblUserName
            ObjInterface.FunSaveInterfaceFileTransferSetup()
            MsgBox(ObjInterface.ErrorMsg)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjInterface) = False Then
                ObjInterface = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

End Class