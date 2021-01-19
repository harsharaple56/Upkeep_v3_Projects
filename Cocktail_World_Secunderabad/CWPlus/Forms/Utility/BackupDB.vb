Imports System.Data.SqlClient

Public Class BackupDB

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim _DBName As String

    Sub MakeBackUp(DBName As String, DBPath As String)
        Try

            If DBPath.LastIndexOf("\") < DBPath.Length - 1 Then
                DBPath = DBPath & "\"
            End If

            con = New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString)
            cmd = New SqlCommand("Spr_DatabaseBackup", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@name", con.Database)
            cmd.Parameters.AddWithValue("@backupname", txtDBName.Text)
            cmd.Parameters.AddWithValue("@path", DBPath)
            Dim sp As SqlParameter = cmd.Parameters.Add("@outmsg", SqlDbType.VarChar, 100)
            sp.Direction = ParameterDirection.Output
            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox(sp.Value, MsgBoxStyle.Information, "Success")
            con.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        Dim fldlg As New FolderBrowserDialog
        fldlg.SelectedPath = "\\" & Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString.Split(";")(0).Split("=")(1).Split("\")(0) & "\"
        If fldlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtFileName.Text = fldlg.SelectedPath
        End If
    End Sub

    Private Sub btnBackup_Click(sender As System.Object, e As System.EventArgs) Handles btnBackup.Click
        If txtFileName.Text.ToLower.Contains(Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString.Split(";")(0).Split("=")(1).ToLower.Split("\")(0)) Then
            MakeBackUp(txtDBName.Text.Split("_")(0), Split(txtFileName.Text.ToLower, Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString.Split(";")(0).Split("=")(1).ToLower.Split("\")(0))(1).Remove(0, 1).Insert(1, ":") & "\")
        Else
            MakeBackUp(txtDBName.Text.Split("_")(0), txtFileName.Text.ToLower)
        End If
    End Sub

    Private Sub BackupDB_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtDBName.Text = Split(Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString.ToLower, "initial catalog")(1).Split(";")(0).Replace("=", "").ToUpper & "_" & Now.ToString("dd-MMM-yyyy") & ".bak"
    End Sub
End Class