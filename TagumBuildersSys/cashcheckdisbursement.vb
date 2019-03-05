Public Class cashcheckdisbursement

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadaccounttitles()
        showaddcashcheckdisbursement()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showdisbursementprinting()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        showdisbursementedit()
        loadaccounttitles()
        loaddisbursementvouchers()

        disbursementedit.ComboBox2.SelectedIndex = -1
        disbursementedit.TextBox1.Clear()
        disbursementedit.TextBox2.Clear()
        disbursementedit.TextBox3.Clear()
        disbursementedit.TextBox4.Clear()
        disbursementedit.TextBox5.Clear()
        disbursementedit.TextBox6.Clear()
        disbursementedit.TextBox7.Clear()
        disbursementedit.TextBox8.Clear()
        disbursementedit.TextBox9.Clear()
        disbursementedit.TextBox10.Clear()
        disbursementedit.TextBox11.Clear()
        disbursementedit.TextBox12.Clear()
        disbursementedit.TextBox13.Clear()
        disbursementedit.TextBox14.Clear()
    End Sub
End Class