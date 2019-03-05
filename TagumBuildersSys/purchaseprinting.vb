Public Class purchaseprinting

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        purchaseprintingdaily.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        purchaseprintingmonthly.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        purchaseprintingrangey.ShowDialog()
    End Sub
End Class