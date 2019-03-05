
Public Class Main

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        showpurchaseorders()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        showpettycash()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        showcashcheckdisbursement()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        showpendingeditdisburse()
        loadpendingdisburseedits()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'attendanceform.Show()
        ' Me.Hide()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        payslip.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        loadgridemp()
        searchemployee.Show()
        Me.Enabled = False
        'showemployeeinfo()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Form1.loginpassword.Clear()
        Form1.loginusername.Clear()
        Form1.Show()
        Me.Hide()
    End Sub
End Class
