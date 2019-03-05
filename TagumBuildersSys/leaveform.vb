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

 
    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        duration()
    End Sub

    Sub duration()
        Dim date1 As String = DateTimePicker1.Value.ToString("yyyy/MM/dd")
        Dim date2 As String = DateTimePicker1.Value.ToString("yyyy/MM/dd")

        Dim differ As Integer = DateDiff(DateInterval.Day, CDate(date1), CDate(date2))

        If differ <= 0 Then
            noofdays.Text = 0
        Else
            noofdays.Text = differ
        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        duration()
    End Sub
End Class