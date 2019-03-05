Public Class disburseitemsviewer
    Public datafrom As String
    Private Sub disburseitemsviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            checkstate()
            dbconn.Open()

            DataGridView1.Rows.Clear()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM disburseeditsitems WHERE vouchernum = '" & datafrom & "'"
                dr = cmd.ExecuteReader

                While dr.Read
                    DataGridView1.Rows.Add(dr.Item("invoicenum"), dr.Item("particulars"), dr.Item("amount"))
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + vbNewLine + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()
    End Sub
End Class