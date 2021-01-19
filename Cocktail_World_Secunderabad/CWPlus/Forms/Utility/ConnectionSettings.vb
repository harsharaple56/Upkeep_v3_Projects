Imports System.Data.SqlClient

Public Class ConnectionSettings
    Private Sub ConnectionSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim instance As System.Data.Sql.SqlDataSourceEnumerator = _
                   System.Data.Sql.SqlDataSourceEnumerator.Instance
            Dim dataTable As System.Data.DataTable = instance.GetDataSources()
            For rCtr = 0 To dataTable.Rows.Count - 1
                cmbServer.Items.Add(dataTable.Rows(rCtr)("ServerName") & IIf(IsDBNull(dataTable.Rows(rCtr)("InstanceName")), "", "\" & dataTable.Rows(rCtr)("InstanceName")))
            Next

            Dim con As New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString & ";connection timeout=5")
            Dim cmd As New SqlCommand("SELECT 1", con)
            cmd.CommandTimeout = 5
            con.Open()
            Dim result As Integer = cmd.ExecuteScalar
            con.Close()
        Catch ex As Exception
            'cmbServer.DisplayMember = ""
        End Try

    End Sub
    Dim strConnection As String
    Private Sub txtPass_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPass.LostFocus
        Try
            If Not String.IsNullOrEmpty(txtPass.Text) Then
                strConnection = "data source=" & cmbServer.Text & ";uid=" & txtUid.Text & ";pwd=" & txtPass.Text & ";initial catalog=master"
                Dim con As New SqlConnection(strConnection & "; connection timeout=5")
                Dim dap As New SqlDataAdapter("select name from sys.databases", con)
                dap.SelectCommand.CommandType = CommandType.Text
                Dim dt As New DataTable
                dap.Fill(dt)
                cmbDataBase.DataSource = dt
                cmbDataBase.Enabled = True
                cmbDataBase.DisplayMember = "name"
            End If
        Catch ex As Exception
            cmbDataBase.DataSource = Nothing
            MsgBox("Sql Server is not reachable !" & vbCrLf & "Please verify the settings....", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Sub ExecuteScript()
        If IO.File.Exists(txtBrowse.Text) Then
            MessageBox.Show("Executing sql script file this may take few minutes !", "::CWPlus:: Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim sqlcon As New SqlConnection("data source=" & cmbServer.Text & "; initial catalog=master;uid=" & txtUid.Text & "; pwd=" & txtPass.Text)
            Dim cmd As New SqlCommand("create Database " & cmbDataBase.Text, sqlcon)
            sqlcon.Open()
            cmd.ExecuteNonQuery()
            sqlcon.Close()
            Dim objServer As New Microsoft.SqlServer.Management.Smo.Server(New Microsoft.SqlServer.Management.Common.ServerConnection(sqlcon))
            objServer.ConnectionContext.ExecuteNonQuery("use " & cmbDataBase.Text & vbCrLf & IO.File.ReadAllText(txtBrowse.Text))
            MessageBox.Show("Script executed successfully !", "::CWPlus:: Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

   
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            ExecuteScript()

            Dim cnfig As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath)
            cnfig.ConnectionStrings.ConnectionStrings("StrSqlConn").ConnectionString = strConnection.Replace("master", cmbDataBase.Text)
            cnfig.Save(Configuration.ConfigurationSaveMode.Modified)
            If IsNothing(Application.OpenForms(MDI.Name)) Then
                MessageBox.Show("Configuration saved successfully!", "::CWPlus:: Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MDI.Show()
                Me.Close()
            Else
                If MessageBox.Show("Configuration saved successfully!" & vbCrLf & "connection string has been modified do you want to restart the application ?", "::CWPlus:: Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    Application.Restart()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "::CWPlus:: Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lnkAddNew_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAddNew.LinkClicked
        cmbDataBase.DataSource = Nothing
        cmbDataBase.DropDownStyle = ComboBoxStyle.DropDown
        Me.Height = 322
        txtBrowse.Visible = True

    End Sub

    Private Sub txtBrowse_Click(sender As System.Object, e As System.EventArgs) Handles txtBrowse.Click
        Dim objSave As New OpenFileDialog
        If objSave.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtBrowse.Text = objSave.FileName
        End If
    End Sub
End Class