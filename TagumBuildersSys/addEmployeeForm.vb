Imports MySql.Data.MySqlClient
Imports System.IO

Public Class addEmployeeForm

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            checkstate()
            dbconn.Open()

            Dim ms As New MemoryStream
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)

            Dim command As New MySqlCommand("INSERT INTO `employees`(`picture`) VALUES (@img) WHERE employ_id='" & TextBox8.Text & "'", dbconn)

            'command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = TextBoxName.Text
            'command.Parameters.Add("@ds", MySqlDbType.VarChar).Value = TextBoxDesc.Text
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = ms.ToArray()

            dbconn.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Image Inserted")

            Else
                MessageBox.Show("Image Not Inserted")
            End If

            dbconn.Close()


            checkstate()
            dbconn.Open()
            With cmd
                .Connection = dbconn
                .CommandText = "INSERT INTO employees VALUES(" & TextBox8.Text & ",'" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "',NULL)"
                .ExecuteNonQuery()
                MessageBox.Show("EMPLOYEE: " + TextBox1.Text + " " + TextBox3.Text + " " + TextBox2.Text + " is added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Controls.Clear()
                InitializeComponent()
                addEmployeeForm_Load(e, e)
            End With
        Catch ex As Exception
            MessageBox.Show("Employee Title Not Added! " + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub addEmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CreateCommand As MySqlCommand = dbconn.CreateCommand
        Dim da As New MySqlDataAdapter("SELECT * FROM employees ORDER BY employ_id DESC", dbconn)
        Dim dt As New DataTable

        da.Fill(dt)

        TextBox8.Text = Today.ToString("yyyyMMdd") & dt.Rows.Count() + 1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim opf As New OpenFileDialog

        opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"

        If opf.ShowDialog = DialogResult.OK Then

            PictureBox1.Image = Image.FromFile(opf.FileName)

        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            

            'Dim ms As New MemoryStream
            'PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)

            'Dim command As New MySqlCommand("INSERT INTO `employees`(`picture`) VALUES (@img)", dbconn)

            ''command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = TextBoxName.Text
            ''command.Parameters.Add("@ds", MySqlDbType.VarChar).Value = TextBoxDesc.Text
            'command.Parameters.Add("@img", MySqlDbType.LongBlob).Value = ms.ToArray()
            'dbconn.Close()
            'dbconn.Open()

            'If command.ExecuteNonQuery() = 1 Then
            '    MessageBox.Show("Image Inserted")

            'Else
            '    MessageBox.Show("Image Not Inserted")
            'End If

            'dbconn.Close()


            checkstate()
            dbconn.Open()
            With cmd
                .Connection = dbconn
                .CommandText = "INSERT INTO employees VALUES('" & TextBox8.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "',NULL,NULL)"
                .ExecuteNonQuery()
                MessageBox.Show("EMPLOYEE: " + TextBox1.Text + " " + TextBox3.Text + " " + TextBox2.Text + " is added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Me.Controls.Clear()
                'InitializeComponent()
                'addEmployeeForm_Load(e, e)
                loadgridemp()
            End With
        Catch ex As Exception
            MessageBox.Show("Employee Title Not Added! " + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class