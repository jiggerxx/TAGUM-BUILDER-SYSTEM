Imports MySql.Data.MySqlClient
Imports System.IO

Public Class VerificationForm
    Inherits AMS
    Dim con As New MySqlConnection("Server=127.0.0.1; Port=3306; User id=root;Password=;Database=ams")
    Dim Command As MySqlCommand
    Private Template As DPFP.Template
    Private Verificator As DPFP.Verification.Verification
    Public Sub Verify(ByVal template As DPFP.Template)
        Me.Template = template
        ShowDialog()
    End Sub
    Protected Overrides Sub Init()
        MyBase.Init()
        MyBase.Text = "Fingerprint Verification"
        Verificator = New DPFP.Verification.Verification()
        UpdateStatus(0)
    End Sub
    Protected Overrides Sub Process(ByVal Sample As DPFP.Sample)
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Dim MySqlConnection As New MySqlConnection("Server=127.0.0.1; Port=3306; User id=root;Password=;Database=ams")
        MyBase.Process(Sample)
        Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification)
        con.Open()
        Dim Sda As New MySqlDataAdapter("SELECT * FROM students WHERE template IS NOT NULL", con)
        Dim Dt As New DataTable("students")
        Dim Dr As DataRow
        Sda.Fill(Dt)
        Dim result As DPFP.Verification.Verification.Result = New DPFP.Verification.Verification.Result()
        For Each Dr In Dt.Rows
            Dim fbyte As Byte() = Nothing
            fbyte = Dr("template")
            Dim temp As New DPFP.Template
            temp.DeSerialize(fbyte)
            If Not features Is Nothing Then
                Verificator.Verify(features, temp, result)
                If result.Verified Then
                    MakeReport("The fingerprint was VERIFIED.")
                    Dim imagename As String = (Dr("picture").ToString)
                    My.Computer.Audio.Play("C:\Users\Pixe\Downloads\Compressed\DMMSU - Attendance Monitoring System\DMMSU - Attendance Monitoring System\client\fscan\fscan\sound\109662__grunz__success.wav")
                    Label4.Text = (Dr("id").ToString)
                    Label3.Text = (Dr("firstname").ToString.ToUpper) + " " + (Dr("surname").ToString.ToUpper)
                    PictureBox6.Image = Image.FromFile("C:\xampp\htdocs\ams\public\img\Studentimage\" + imagename)
                    createlog()
                    Exit For
                Else
                    Label3.Text = "Student Name "
                    Label4.Text = "Student ID"
                    Label8.Text = ""
                    Label11.Text = ""
                    Label14.Text = ""
                    Label17.Text = ""
                    Label20.Text = ""
                    Label23.Text = ""
                    Label27.Text = ""
                    Label22.Text = ""
                    Label19.Text = ""
                    Label16.Text = ""
                    Label13.Text = ""
                    Label10.Text = ""
                    PictureBox6.Image = Nothing
                    My.Computer.Audio.Play("C:\Users\Pixe\Downloads\Compressed\DMMSU - Attendance Monitoring System\DMMSU - Attendance Monitoring System\client\fscan\fscan\sound\error.wav")
                    PictureBox8.Image = Image.FromFile("C:\Users\Pixe\Downloads\Compressed\DMMSU - Attendance Monitoring System\DMMSU - Attendance Monitoring System\client\fscan\fscan\img\error.png")
                End If
            End If
        Next
        con.Close()
        con.Dispose()
    End Sub
    Sub createlog()
        Dim time As String = DateTime.Now.ToString("hh:mm tt")
        Dim loggedate As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim dt As New DataTable
        Dim CreateCommand As MySqlCommand = con.CreateCommand
        Dim da As New MySqlDataAdapter("SELECT * FROM student_att where stud_id = '" & Label4.Text & "' AND date = '" & loggedate & "' ", con)
        da.Fill(dt)
        Try
            Dim hours As String = DateTime.Now.ToString("hh")
            Dim minutes As String = DateTime.Now.ToString("mm tt")
            Dim exacthour As String
            exacthour = hours + ":" + minutes
            If Not da Is Nothing Then
                If (dt.Rows.Count = 1) Then
                    Dim logcount As String = dt.Rows(0)("log").ToString()
                    Dim fines As String = dt.Rows(0)("fines").ToString()
                    Dim calcfines As String
                    calcfines = fines / logcount
                    fines = fines - calcfines
                    Dim sublog As String = (logcount - 1)
                    If Not sublog = "-1" Then
                        If (dt.Rows(0)("first_time_in").ToString = "") Then
                            CreateCommand.CommandText = "UPDATE student_att SET log = '" & sublog & "',first_time_in ='" & exacthour & "',fines = '" & fines & "' WHERE stud_id = '" & Label4.Text & "' AND date ='" & loggedate & "' "
                            CreateCommand.ExecuteNonQuery()
                            CreateCommand.Dispose()
                        ElseIf (dt.Rows(0)("first_time_out").ToString = "") Then
                            Dim str = (dt.Rows(0)("first_time_in").ToString)
                            Dim subhour = str.Substring(0, 2)
                            If subhour = hours Then
                                MsgBox("You Connot Log out at the same time")
                            Else
                                CreateCommand.CommandText = "UPDATE student_att SET log = '" & sublog & "',first_time_out ='" & exacthour & "',fines = '" & fines & "' WHERE stud_id = '" & Label4.Text & "' AND date ='" & loggedate & "' "
                                CreateCommand.ExecuteNonQuery()
                                CreateCommand.Dispose()
                            End If
                        ElseIf (dt.Rows(0)("second_time_in").ToString = "") Then
                            CreateCommand.CommandText = "UPDATE student_att SET log = '" & sublog & "',second_time_in ='" & exacthour & "',fines = '" & fines & "' WHERE stud_id = '" & Label4.Text & "' AND date ='" & loggedate & "' "
                            CreateCommand.ExecuteNonQuery()
                            CreateCommand.Dispose()
                        ElseIf (dt.Rows(0)("second_time_out").ToString = "") Then
                            Dim str = (dt.Rows(0)("first_time_in").ToString)
                            Dim subhour = str.Substring(0, 2)

                            If subhour = hours Then
                                MsgBox("You Connot Log out at the same time")
                            Else
                                CreateCommand.CommandText = "UPDATE student_att SET log = '" & sublog & "',second_time_out ='" & exacthour & "',fines = '" & fines & "'  WHERE stud_id = '" & Label4.Text & "' AND date ='" & loggedate & "' "
                                CreateCommand.ExecuteNonQuery()
                                CreateCommand.Dispose()
                            End If
                        ElseIf (dt.Rows(0)("third_time_in").ToString = "") Then
                            CreateCommand.CommandText = "UPDATE student_att SET log = '" & sublog & "',third_time_in ='" & exacthour & "',fines = '" & fines & "'  WHERE stud_id = '" & Label4.Text & "' AND date ='" & loggedate & "' "
                            CreateCommand.ExecuteNonQuery()
                            CreateCommand.Dispose()
                        ElseIf (dt.Rows(0)("third_time_out").ToString = "") Then
                            Dim str = (dt.Rows(0)("first_time_in").ToString)
                            Dim subhour = str.Substring(0, 2)
                            If subhour = hours Then
                                MsgBox("You Connot Log out at the same time")
                            Else
                                CreateCommand.CommandText = "UPDATE student_att SET log = '" & sublog & "',third_time_out ='" & exacthour & "',fines = '" & fines & "'  WHERE stud_id = '" & Label4.Text & "' AND date ='" & loggedate & "' "
                                CreateCommand.ExecuteNonQuery()
                                CreateCommand.Dispose()
                            End If
                        Else
                            MsgBox("You connot Log in and out at the same time")
                        End If
                    Else
                        MsgBox("You have successfuly logged all the required logs")
                    End If
                End If
            End If
        Catch ex As Exception
        Finally
            showlogs()
            PictureBox8.Image = Image.FromFile("C:\Users\n3far10us\Desktop\NASTY\DMMSU\client\fscan\fscan\img\success.png")
        End Try
    End Sub

    Protected Sub UpdateStatus(ByVal FAR As Integer)
        ' Show "False accept rate" value
        SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR))
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'VerificationForm
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1226, 743)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "VerificationForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub OnTemplate(ByVal template)
        Invoke(New FunctionCall(AddressOf _OnTemplate), template)
    End Sub

    Private Sub _OnTemplate(ByVal template)
        Me.Template = template
    End Sub

    Private Sub VerificationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim timeCheck As String = DateTime.Now.ToString("hh")
        Dim minutesCheck As String = DateTime.Now.ToString("mm")
    End Sub
End Class