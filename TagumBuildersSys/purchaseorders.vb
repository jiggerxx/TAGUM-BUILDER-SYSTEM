Public Class purchaseorders

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        showaddpurchaseorders()
        loadaccounttitles()
        loadpobiz()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showpurchaseprinting()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        viewreceipt.Show()
        Main.Enabled = False
    End Sub


End Class