Imports System.Data.SqlClient
Imports System.Configuration

Public Class ExecuteScript
    Private Sub TextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBrowse.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBrowse.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Sub ExecuteScript()
        Try
            Dim CS As String = ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString
            Dim builder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder(CS)
            Dim serverName As String = builder.DataSource
            Dim dbName As String = builder.InitialCatalog
            Dim UserName As String = builder.UserID
            Dim password As String = builder.Password
            Dim path As String = Application.StartupPath & "\CWPlus_DB.sql"

            If IO.File.Exists(txtBrowse.Text) Then
                MessageBox.Show("Executing sql script file this may take few minutes !", "::CWPlus:: Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Dim Proc As New Process
                Dim argument As String = " /k osql -S " & serverName & " -U " & UserName & " -P " & password & " -d " & dbName & " -i " & txtBrowse.Text & ""
                Proc.StartInfo.FileName = "cmd.exe"
                Proc.StartInfo.Arguments = argument
                Proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                Proc.StartInfo.CreateNoWindow = True
                Proc.Start()
                'Dim sqlcon As New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString)
                'Dim objServer As New Microsoft.SqlServer.Management.Smo.Server(New Microsoft.SqlServer.Management.Common.ServerConnection(sqlcon))
                'objServer.ConnectionContext.ExecuteNonQuery(IO.File.ReadAllText(txtBrowse.Text))
                MsgBox("Script Executed Successfully", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExec.Click
        Try
            ExecuteScript()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
        End Try
    End Sub
End Class