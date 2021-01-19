Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml


Public Class Frm_LicenseTransfer

    Private Sub Frm_LicenseTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindLicense()
    End Sub

    Private Sub chkLicenseName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLicenseName.SelectedIndexChanged
        Try
            If chkLicenseName.SelectedIndex = 0 Then
                For rctr = 1 To chkLicenseName.Items.Count - 1
                    chkLicenseName.SetItemChecked(rctr, chkLicenseName.GetItemChecked(0))

                Next
            End If
            'FetchMDILicenseChecked(Me.chkLicenseName, 0)
        Catch ex As Exception
            Throw ex
        End Try
       
    End Sub



    Public Sub BindLicense()
        Dim objlicense As New CWPlusBL.Master.clsMultipleLicenase
        Dim objDt As New DataTable
        Try
            objlicense.LicenseID = MDI.cmbLicenseName.SelectedValue
            objDt = objlicense.FunFetch
            Dim tmpDt As New DataTable
            tmpDt = objDt.Copy

            Dim chkDt As New DataTable
            chkDt = objDt.Copy
            Dim dr As DataRow
            dr = chkDt.NewRow
            dr("LicenseDesc") = "Select All"
            dr("LicenseID") = 0
            chkDt.Rows.InsertAt(dr, 0)

            With chkLicenseName
                .DataSource = chkDt
                .DisplayMember = "LicenseDesc"
                .ValueMember = "LicenseID"
            End With

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(objlicense) Then
                objlicense = Nothing
            End If
            If Not IsNothing(objDt) Then
                objDt = Nothing
            End If
        End Try


    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FetchMDILicenseChecked(Me.chkLicenseName, 0)
        save()
        'For cntr = 0 To gblArrMDICheckedLicense.Count - 1
        '    XmlElt = xmldoc.CreateElement("License")
        '    XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cntr))
        '    xmldoc.DocumentElement.Item("AllLicense").AppendChild(XmlElt)
        'Next
    End Sub

    Private Function GenerateXML() As XmlDocument


        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Transaction><LicenseMaster></LicenseMaster></Transaction>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
        For cntr = 0 To chkLicenseName.CheckedItems.Count - 1
            If DirectCast(chkLicenseName.CheckedItems(cntr), System.Data.DataRowView).Row.ItemArray(0) = 0 Then Continue For
            XmlElt = xmldoc.CreateElement("License")
            XmlElt.SetAttribute("LicenseID", DirectCast(chkLicenseName.CheckedItems(cntr), System.Data.DataRowView).Row.ItemArray(0))
            xmldoc.DocumentElement.Item("LicenseMaster").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function


    Public Function save() As Boolean
        save = False
        Dim ObjLicense As New clsMultipleLicenase
        Dim ObjDt As New DataTable
        Try
            ObjLicense.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjLicense.ArrLicenseParameterId = GenerateXML()

            If chkBrandOpening.Checked = True Then
                ObjLicense.Brandopening = 1
            Else
                ObjLicense.Brandopening = 0
            End If

            If chkAssignBrandCode.Checked = True Then
                ObjLicense.AssignBrandCode = 1
            Else
                ObjLicense.AssignBrandCode = 0
            End If
            If chkCocktail.Checked = True Then
                ObjLicense.Cocktail = 1
            Else
                ObjLicense.Cocktail = 0
            End If

            If chkCocktailCode.Checked = True Then
                ObjLicense.CocktailCode = 1
            Else
                ObjLicense.CocktailCode = 0
            End If

            If chkMMSCode.Checked = True Then
                ObjLicense.MMSCode = 1
            Else
                ObjLicense.MMSCode = 0
            End If

            ObjLicense.UserName = gblUserName

            save = ObjLicense.FunSave()
            MsgBox(ObjLicense.ErrorMsg)



        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjLicense) = False Then
                ObjLicense = Nothing
            End If

            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing

            End If

        End Try


    End Function


    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        If MDI.cmbLicenseName.SelectedValue = 0 Then
            MsgBox("Please Select License")
            Exit Sub
        End If

        If chkAssignBrandCode.Checked = False And chkBrandOpening.Checked = False And chkCocktail.Checked = False And chkCocktailCode.Checked = False And chkMMSCode.Checked = False Then
            MsgBox("Please select Any Item")
            Exit Sub
        End If

        'FetchMDILicenseChecked(Me.chkLicenseName, 0)

        If Not chkLicenseName.CheckedItems.Count > 0 Then
            MsgBox("Please Select License")
            Exit Sub
        End If
        save()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
End Class