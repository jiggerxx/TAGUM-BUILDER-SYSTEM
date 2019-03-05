Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class viewreceipt

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim dept As String = TextBox1.Text

        Dim sql As String = "SELECT COUNT(referencenum) as 'flags' FROM purchaseorders WHERE referencenum = '" & TextBox1.Text & "'"
        Dim cmd As New MySqlCommand(sql, dbconn)
        Dim dr As MySqlDataReader
        Dim tf As Boolean = False
        Try
            checkstate()
            dbconn.Open()


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read
                If CInt(dr.Item("flags")) <> 0 Then
                    tf = True
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        Finally
            dbconn.Close()
        End Try

        If tf = False Then
            MsgBox("Receipt not found.")
        Else
            loadreceipt()
        End If
    End Sub

    Sub loadreceipt()
        Try
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT purchaseorders.*,purchaseordersitems.*,accountingtitles.* FROM purchaseorders LEFT JOIN purchaseordersitems ON purchaseorders.referencenum = purchaseordersitems.referencenum LEFT JOIN accountingtitles ON purchaseorders.accounttitleID = accountingtitles.idai WHERE purchaseorders.referencenum = '" & TextBox1.Text & "'"
                dr = cmd.ExecuteReader
                DataGridView1.Rows.Clear()
                While dr.Read
                    transacnumber.Text = dr.Item("referencenum")
                    transacdate.Text = dr.Item("date")
                    purpose.Text = dr.Item("purpose")
                    custname.Text = dr.Item("businessname")
                    address.Text = dr.Item("address")

                    DataGridView1.Rows.Add(New String() {dr.Item("qty"), dr.Item("unit"), dr.Item("particulars"), dr.Item("price")})
                End While
            End With

            DataGridView1.Columns(2).Width = 225
            DataGridView1.Columns(0).Width = 100
        Catch

        End Try


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Main.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub
End Class
