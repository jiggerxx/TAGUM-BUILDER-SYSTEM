Public Class addaccounttitle

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox8.Text.Count <> 0 Then
            Try
                checkstate()
                dbconn.Open()

                With cmd
                    .Connection = dbconn
                    .CommandText = "INSERT INTO accountingtitles (accounttitle) VALUES('" & TextBox8.Text & "')"
                    .ExecuteNonQuery()
                    MessageBox.Show("Account Title " + TextBox8.Text + " is added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox8.Clear()
                End With
            Catch ex As Exception
                MessageBox.Show("Account Title Not Added! " + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            dbconn.Close()
            dbconn.Dispose()

            loadaccounttitles()
        End If
        
    End Sub
End Class