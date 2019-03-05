Public Class cashcheckdisbursementprinting

    Private Sub cashcheckdisbursementprinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        disbursementbyday.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        disbursementbymonth.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        disbursementbyrange.ShowDialog()
    End Sub
End Class