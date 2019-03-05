' NOTE: This form is a base for the EnrollmentForm and the VerificationForm,
'	All changes in the CaptureForm will be reflected in all its derived forms.
Imports MySql.Data.MySqlClient
Public Class AMS
    Implements DPFP.Capture.EventHandler

    Private Capturer As DPFP.Capture.Capture
    Dim [mybase] As String

    Protected Overridable Sub Init()
        Try
            Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.

            If (Not Capturer Is Nothing) Then
                Capturer.EventHandler = Me                              ' Subscribe for capturing events.
            Else
                SetPrompt("Can't initiate capture operation!")
            End If
        Catch ex As Exception
            MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Protected Overridable Sub Process(ByVal Sample As DPFP.Sample)
        DrawPicture(ConvertSampleToBitmap(Sample))
    End Sub

    Protected Function ConvertSampleToBitmap(ByVal Sample As DPFP.Sample) As Bitmap
        Dim convertor As New DPFP.Capture.SampleConversion()  ' Create a sample convertor.
        Dim bitmap As Bitmap = Nothing              ' TODO: the size doesn't matter
        convertor.ConvertToPicture(Sample, bitmap)        ' TODO: return bitmap as a result
        Return bitmap
    End Function

    Protected Function ExtractFeatures(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
        Dim extractor As New DPFP.Processing.FeatureExtraction()    ' Create a feature extractor
        Dim feedback As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
        Dim features As New DPFP.FeatureSet()
        extractor.CreateFeatureSet(Sample, Purpose, feedback, features) ' TODO: return features as a result?
        If (feedback = DPFP.Capture.CaptureFeedback.Good) Then
            Return features
        Else
            Return Nothing
        End If
    End Function

    Protected Sub StartCapture()
        If (Not Capturer Is Nothing) Then
            Try
                Capturer.StartCapture()
                SetPrompt("Using the fingerprint reader, scan your fingerprint.")
            Catch ex As Exception
                SetPrompt("Can't initiate capture!")
            End Try
        End If
    End Sub

    Protected Sub StopCapture()
        If (Not Capturer Is Nothing) Then
            Try
                Capturer.StopCapture()
            Catch ex As Exception
                SetPrompt("Can't terminate capture!")
            End Try
        End If
    End Sub

    Private Sub CaptureForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim con As New MySqlConnection("Server=127.0.0.1; Port=3306; User id=root;Password=;Database=ams")
        Init()
        StartCapture()
        Timer1.Enabled = True
        Label25.Text = Date.Now.ToString("ddddddddddddddddd, MMMMMMMMMMMMMMM dd yyyy")
        AcceptButton = Button1
        Dim cmd As New MySqlCommand
        Dim filterday As String = Date.Now.ToString("yyyy-MM-dd")
        Try
            con.Open()
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter("SELECT * FROM events WHERE event_date = '" & filterday & "' ", con)
            da.Fill(dt)
            If Not da Is Nothing Then
                Label6.Text = dt.Rows(0)("event_time").ToString()
                Label9.Text = dt.Rows(0)("fines").ToString()
                Label29.Text = dt.Rows(0)("id").ToString()
            Else '<------ data checking ends here
            End If
        Catch ex As Exception
        Finally
            con.Dispose()
        End Try

    End Sub

    Private Sub CaptureForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        StopCapture()
    End Sub

    Sub OnComplete(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
        MakeReport("The fingerprint sample was captured.")
        SetPrompt("Scan the same fingerprint again.")
        Process(Sample)
    End Sub

    Sub OnFingerGone(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone
        MakeReport("The finger was removed from the fingerprint reader.")
    End Sub

    Sub OnFingerTouch(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
        MakeReport("The fingerprint reader was touched.")
    End Sub

    Sub OnReaderConnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
        MakeReport("The fingerprint reader was connected.")
    End Sub

    Sub OnReaderDisconnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
        MakeReport("The fingerprint reader was disconnected.")
    End Sub

    Sub OnSampleQuality(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality
        If CaptureFeedback = DPFP.Capture.CaptureFeedback.Good Then
            MakeReport("The quality of the fingerprint sample is good.")
        Else
            MakeReport("The quality of the fingerprint sample is poor.")
        End If
    End Sub

    Protected Sub SetStatus(ByVal status)
        Invoke(New FunctionCall(AddressOf _SetStatus), status)
    End Sub

    Private Sub _SetStatus(ByVal status)
        StatusLine.Text = status
    End Sub

    Protected Sub SetPrompt(ByVal text)
        Invoke(New FunctionCall(AddressOf _SetPrompt), text)
    End Sub

    Private Sub _SetPrompt(ByVal text)

    End Sub

    Protected Sub MakeReport(ByVal status)
        Invoke(New FunctionCall(AddressOf _MakeReport), status)
    End Sub

    Private Sub _MakeReport(ByVal status)
        StatusText.AppendText(status + Chr(13) + Chr(10))
    End Sub

    Protected Sub DrawPicture(ByVal bmp)
        Invoke(New FunctionCall(AddressOf _DrawPicture), bmp)
    End Sub

    Private Sub _DrawPicture(ByVal bmp)
        Picture.Image = New Bitmap(bmp, Picture.Size)
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label54.Text = TimeOfDay
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        clear()
    End Sub
    Sub showlogs()
        Dim con As New MySqlConnection("Server=127.0.0.1; Port=3306; User id=root;Password=;Database=ams")
        Try
            con.Open()
            Dim loggedday As String = Date.Now.ToString("yyyy-MM-dd")
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter("SELECT * FROM student_att WHERE stud_id = '" & Label4.Text & "' AND date ='" & loggedday & "'  ", con)

            da.Fill(dt)
            If Not da Is Nothing Then
                Label8.Text = dt.Rows(0)("first_time_in").ToString()
                Label27.Text = dt.Rows(0)("first_time_out").ToString()

                Label11.Text = dt.Rows(0)("second_time_in").ToString()
                Label22.Text = dt.Rows(0)("second_time_out").ToString()

                Label14.Text = dt.Rows(0)("third_time_in").ToString()
                Label19.Text = dt.Rows(0)("third_time_out").ToString()


                'reserve slots
                Label20.Text = ""
                Label13.Text = ""
                Label23.Text = ""
                Label10.Text = ""
            Else
                clear()
            End If
        Catch ex As Exception
        Finally
            con.Dispose()
        End Try
    End Sub
    Sub clear()
        StatusText.Text = Nothing
        Picture.Image = Nothing
        PictureBox8.Image = Nothing
        PictureBox6.Image = Nothing
        Label3.Text = "Student Name "
        Label4.Text = "Student ID"
        Label8.Text = ""
        Label11.Text = ""
        Label14.Text = ""
        Label20.Text = ""
        Label23.Text = ""
        Label27.Text = ""
        Label22.Text = ""
        Label19.Text = ""
        Label13.Text = ""
        Label10.Text = ""

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub StatusText_TextChanged(sender As Object, e As EventArgs) Handles StatusText.TextChanged

    End Sub
End Class