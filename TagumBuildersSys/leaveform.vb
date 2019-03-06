Imports MySql.Data.MySqlClient

Public Class leaveform

    Private Sub leaveform_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Main.Enabled = True
    End Sub

    Private Sub leaveform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        empname.Text = employeesform.TextBox5.Text & ", " & employeesform.TextBox3.Text & " " & employeesform.TextBox4.Text
        empid.Text = employeesform.TextBox2.Text

        Dim CreateCommand As MySqlCommand = dbconn.CreateCommand
        Dim da As New MySqlDataAdapter("SELECT * FROM leaveforms ", dbconn)
        Dim dt As New DataTable

        da.Fill(dt)
        formid.Text = "LF-" & Format(CInt(dt.Rows.Count()), "0000") + 1


        Dim d As New MySqlDataAdapter("SELECT * FROM employees where employ_id = '" & employeesform.TextBox2.Text & "'", dbconn)
        Dim table As New DataTable

        d.Fill(table)

        pos.Text = table.Rows(0)("employ_position").ToString()
        dept.Text = table.Rows(0)("department").ToString()
    End Sub


    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles dateofresume.ValueChanged
        Dim Borrow As DateTime = Convert.ToDateTime(dateofleave.Text)
        Dim Back As DateTime = Convert.ToDateTime(dateofresume.Text)

        Dim CountDays As TimeSpan = Back.Subtract(Borrow)
        Dim TotalDays = Convert.ToInt32(CountDays.Days)
        If Convert.ToInt32(CountDays.Days) >= 0 Then
            Label14.Text = TotalDays
        Else
            MsgBox("sample", MsgBoxStyle.Critical, "notice")

        End If
    End Sub


    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dateofleave.ValueChanged

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click



    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            checkstate()
            dbconn.Open()
            With cmd
                .Connection = dbconn
                .CommandText = "INSERT INTO leaveforms (@id, @emp_id, @dateofleave, @dateofresume, @prepby,@checkedby)VALUES(formid.Text ,empid.Text, dateofleave.Text ,dateofresume.Text, prepby.Text , checkedby.Text)"
                .ExecuteNonQuery()


            End With
        Catch ex As Exception
            MessageBox.Show("Not Save! " + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        dbconn.Close()
        dbconn.Dispose()


    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

    End Sub
End Class