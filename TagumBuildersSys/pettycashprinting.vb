Public Class pettycashprinting

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        pettycashprintbyday.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pettycashprintbymonth.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        pettycashprintbyrangey.ShowDialog()
    End Sub
End Class