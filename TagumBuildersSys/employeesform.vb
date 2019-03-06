Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class employeesform

    Public dbconn As New MySqlConnection("server=192.168.2.5;userid=;password=;database=tgdb2")
    Public conn As String = "Data Source=localhost; Database=tgdb2; User ID =root; Password=;"
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        
    End Sub

   

    Private Sub employeesform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'loademp()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        addEmployeeForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        checkstate()
        dbconn.Close()
        dbconn.Open()
        Try
            cmd.CommandText = "UPDATE employees SET employ_fname = '" & TextBox3.Text & "',employ_mname ='" & TextBox4.Text & "',employ_lname ='" & TextBox5.Text & "',employ_position ='" & TextBox6.Text & "',employ_branch ='" & TextBox7.Text & "',employ_mrate ='" & TextBox8.Text & "',employ_mname ='" & TextBox9.Text & "' WHERE employ_id = '" & TextBox2.Text & "'"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            MsgBox("Employee: " + TextBox2.Text + "has been updated.")
        Catch ex As Exception
            MessageBox.Show("Employee ID# " + TextBox2.Text + " cannot be updated." + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Panel2.Enabled = True
        Button2.Enabled = True
        Button5.Visible = True
        Button5.Enabled = True
        BunifuFlatButton1.Visible = True
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim opf As New OpenFileDialog

        opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"

        If opf.ShowDialog = DialogResult.OK Then

            PictureBox1.Image = Image.FromFile(opf.FileName)

        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        loademp()
    End Sub

    Sub loademp()
        dbconn.Close()
        dbconn.Open()


        Dim command As New MySqlCommand("select * from employees where employ_id = '" & TextBox2.Text & "'", dbconn)


        Dim table As New DataTable()

        Dim adapter As New MySqlDataAdapter(command)

        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then

            MessageBox.Show("No Image For This Id")
        Else


            Dim img() As Byte

            img = table.Rows(0)(9)

            Dim ms As New MemoryStream(img)

            PictureBox1.Image = Image.FromStream(ms)

        End If

        Dim CreateCommand As MySqlCommand = dbconn.CreateCommand
        Dim da As New MySqlDataAdapter("SELECT * FROM employees where employ_id = '" & TextBox2.Text & "'", dbconn)
        Dim dt As New DataTable

        da.Fill(dt)

        If dt.Rows.Count = 0 Then
            MsgBox("Employee not found.")
        Else
            'TextBox2.Text = dt.Rows(0)("employ_id").ToString()
            TextBox3.Text = dt.Rows(0)("employ_fname").ToString()
            TextBox4.Text = dt.Rows(0)("employ_mname").ToString()
            TextBox5.Text = dt.Rows(0)("employ_lname").ToString()
            TextBox6.Text = dt.Rows(0)("employ_position").ToString()
            TextBox7.Text = dt.Rows(0)("employ_branch").ToString()
            TextBox8.Text = dt.Rows(0)("employ_mrate").ToString()
            TextBox9.Text = dt.Rows(0)("employ_drate").ToString()
        End If

        dbconn.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim CreateCommand As MySqlCommand = dbconn.CreateCommand
        checkstate()
        dbconn.Close()
        dbconn.Open()
        Try
            CreateCommand.CommandText = "UPDATE employees SET employ_fname = '" & TextBox3.Text & "',employ_mname ='" & TextBox4.Text & "',employ_lname ='" & TextBox5.Text & "',employ_position ='" & TextBox6.Text & "',employ_branch ='" & TextBox7.Text & "',employ_mrate ='" & TextBox8.Text & "',employ_drate ='" & TextBox9.Text & "' WHERE employ_id = '" & TextBox2.Text & "'"
            CreateCommand.ExecuteNonQuery()
            'CreateCommand.Dispose()
            MsgBox("Employee: " + TextBox2.Text + "has been updated.")
        Catch ex As Exception
            MessageBox.Show("Employee ID# " + TextBox2.Text + " cannot be updated." + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        leaveform.Show()
        Main.Enabled = False
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class