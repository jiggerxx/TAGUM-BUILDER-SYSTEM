Public Class searchemployee
    Dim rowclicked As Integer = 0

    Private Sub Button4_Click(sender As Object, e As EventArgs)


        grid.Rows.Clear()
        dbconn.Close()
        Try

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT CONCAT(employ_lname,', ',employ_fname) as 'name',employ_id,employ_position FROM employees WHERE employ_lname LIKE '" & TextBox1.Text & "%'"
                dr = cmd.ExecuteReader

                While dr.Read

                    grid.Rows.Add(dr.Item("employ_id"), dr.Item("name"), dr.Item("employ_position"))
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            loadgridemp()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        addEmployeeForm.Show()
    End Sub

    Private Sub search_Click(sender As Object, e As EventArgs) Handles search.Click
        grid.Rows.Clear()
        dbconn.Close()
        Try

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT CONCAT(employ_lname,', ',employ_fname) as 'name',employ_id,employ_position FROM employees WHERE employ_lname LIKE '" & TextBox1.Text & "%'"
                dr = cmd.ExecuteReader

                While dr.Read

                    grid.Rows.Add(dr.Item("employ_id"), dr.Item("name"), dr.Item("employ_position"))
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()
    End Sub

    Private Sub grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellContentClick

    End Sub

    Private Sub grid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellDoubleClick
        Main.Enabled = True
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            rowclicked = e.RowIndex
        End If

        employeesform.TextBox2.Text = grid.Rows(rowclicked).Cells(0).Value
        showemployeeinfo()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub searchemployee_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Main.Enabled = True
    End Sub
End Class