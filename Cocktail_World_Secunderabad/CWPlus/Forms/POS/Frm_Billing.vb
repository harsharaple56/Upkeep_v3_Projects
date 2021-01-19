Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization

Public Class Frm_Billing

    Dim x As Integer
    Dim connstring As String = ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString
    '"Data Source=compel-sv\sql2012;Initial Catalog=WINESHOP;User ID=sa;Password=cocktail"
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim s As String

    Private Sub Frm_Billing_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.ToString() = "F1" Then
            x = x + 1
            txtQty.Text = x.ToString()
        End If
        If e.KeyCode.ToString() = "F2" Then
            If txtQty.Text = "1" Then
            Else
                x = x - 1
                txtQty.Text = x.ToString()
            End If
        End If
        If e.KeyCode.ToString() = "F5" Then
            addsale()
        End If
    End Sub

    Private Sub Frm_Billing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        s = Now.Date
        Reset()
        Me.KeyPreview = True
        x = Convert.ToInt32(txtQty.Text)
    End Sub

    Public Sub addsale()
        'DateTime dt = DateTime.ParseExact(date.Value.ToShortDateString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

        'string s = dt.ToString("dd-MMM-yyyy");


        If lblOPID.Text <> "0" Then

            Dim cmd As String = ("insert into tbl_WineShopSale (brandopeningid,Qty,Date) values (" & lblOPID.Text & "," & txtQty.Text & ",'" & s & "')")


            Using connection As New SqlConnection(connstring)
                connection.Open()
                Dim addSite As New SqlCommand(cmd, connection)
                addSite.ExecuteNonQuery()
                connection.Close()
            End Using

            MessageBox.Show("Save")
            reset()
        Else
            MessageBox.Show("add Code")
        End If
    End Sub

    Public Sub reset()
        grdBrands.DataSource = Nothing

        lblName.Text = ""
        lblName.Text = ""
        lblSize.Text = ""
        lblOPID.Text = "0"
        txtQty.Text = "1"
        txtBCode.Text = ""
        lblDate.Text = s
        txtBCode.Focus()
    End Sub

    'Private Sub txtBCode_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBCode.KeyPress
    '    If e.KeyChar = Convert.ToChar(Keys.[Return]) Then
    '        If txtBCode.Text = "" Then
    '            MessageBox.Show("Add Code")
    '        Else
    '            fetch()
    '        End If
    '    End If
    'End Sub

    Public Sub fetch()
        Dim cmd As String = "select distinct brandopeningid, Brand, Size from vw_FetchBrands where BrandCode like'%" & txtBCode.Text & "%'"

        Using connection As New SqlConnection(connstring)
            connection.Open()

            da = New SqlDataAdapter(cmd, connstring)
            ds = New DataSet()
            da.Fill(ds)

            grdBrands.DataSource = ds.Tables(0)
            grdBrands.Columns("brandopeningid").Visible = False
            grdBrands.AutoResizeColumns()

            'lblOPID.Text = ds.Tables(0).Rows(0)("brandopeningid").ToString()
            'lblName.Text = ds.Tables(0).Rows(0)("Brand").ToString()
            'lblSize.Text = ds.Tables(0).Rows(0)("Size").ToString()
            connection.Close()
        End Using
    End Sub

    Private Sub txtBCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBCode.TextChanged
        fetch()
    End Sub

    Private Sub grdBrands_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBrands.CellDoubleClick
        lblOPID.Text = grdBrands("brandopeningid", e.RowIndex).Value()
        lblName.Text = grdBrands("Brand", e.RowIndex).Value()
        lblSize.Text = grdBrands("Size", e.RowIndex).Value()
    End Sub

    Private Sub grdBrands_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBrands.CellEnter
        lblOPID.Text = grdBrands("brandopeningid", e.RowIndex).Value()
        lblName.Text = grdBrands("Brand", e.RowIndex).Value()
        lblSize.Text = grdBrands("Size", e.RowIndex).Value()
    End Sub
End Class