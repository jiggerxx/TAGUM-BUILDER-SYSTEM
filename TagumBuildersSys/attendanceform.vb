Imports MySql.Data.MySqlClient
Imports System.IO
'Imports DPFP.Processing.Enrollment

Delegate Sub FunctionCall(ByVal param)

Public Class attendanceform

    Dim con As New MySqlConnection("Server=127.0.0.1;User id=root;Password=;Database=tgdb")
    Private Template As DPFP.Template

    Private Sub attendanceform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Enroller As New attendanceEnrollmentForm()
        AddHandler Enroller.OnTemplate, AddressOf OnTemplate
        Enroller.ShowDialog()

        Try
            dbconn.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM students", con)
            Dim rdr As MySqlDataReader = cmd.ExecuteReader()
            Dim MemStream As IO.MemoryStream
            Dim fpBytes As Byte()
            While rdr.Read()
                fpBytes = rdr("template")
                MemStream = New IO.MemoryStream(fpBytes)
                Dim template As New DPFP.Template(MemStream)
                OnTemplate(template)
            End While
            con.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim save As New SaveFileDialog()
        Dim CreateCommand As MySqlCommand = con.CreateCommand
        Dim da As New MySqlDataAdapter("SELECT * FROM employees where employ_id = '" & TextBox1.Text & "'", con)
        Dim dt As New DataTable

        da.Fill(dt)
        If Not da Is Nothing Then

            If dt.Rows.Count <> 0 And (dt.Rows(0)("template").ToString = "") Then
                Dim fingerprintData As MemoryStream = New MemoryStream
                Template.Serialize(fingerprintData)
                fingerprintData.Position = 0
                Dim br As BinaryReader = New BinaryReader(fingerprintData)
                Dim bytes() As Byte = br.ReadBytes(CType(fingerprintData.Length, Int32))
                con.Open()
                Try
                    CreateCommand.Parameters.AddWithValue("@Pic", bytes)
                    CreateCommand.CommandText = "UPDATE employees SET template = @Pic WHERE employ_id = '" & TextBox1.Text & "'"
                    'Runs Query
                    CreateCommand.ExecuteNonQuery()
                    CreateCommand.Dispose()
                    MsgBox("FINGER PRINT SAVE SUCCESSFUL")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                con.Close()
            Else
                MsgBox("Finger Print Already Enrolled")
            End If
        End If
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
        Main.Show()
    End Sub

    Private Sub OnTemplate(ByVal template)
        Invoke(New FunctionCall(AddressOf _OnTemplate), template)
    End Sub

    Private Sub _OnTemplate(ByVal template)
        Me.Template = template

        SaveButton.Enabled = (Not template Is Nothing)
    End Sub

    Private Sub EnrollButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnrollButton.Click
        Dim Enroller As New attendanceEnrollmentForm()
        AddHandler Enroller.OnTemplate, AddressOf OnTemplate
        Enroller.ShowDialog()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class