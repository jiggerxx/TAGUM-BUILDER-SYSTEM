Public Class addpettycash
    Public pettycashArray(100, 1) As String
    Public pettycounter As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim particulars As String = TextBox6.Text
        Dim amount As String = TextBox7.Text
        Dim totalamounts As Double = 0

        If TextBox7.Text.Count = 0 Then
            amount = 0
        End If

        If TextBox6.Text.Count <> 0 Then
            pettycashArray(pettycounter, 0) = particulars
            pettycashArray(pettycounter, 1) = amount

            DataGridView1.Rows.Clear()

            For x As Integer = 0 To pettycounter
                DataGridView1.Rows.Add(New String() {pettycashArray(x, 0), pettycashArray(x, 1)})
                totalamounts = totalamounts + pettycashArray(x, 1)
            Next

            TextBox9.Text = totalamounts

            TextBox6.Clear()
            TextBox7.Clear()
            TextBox5.ReadOnly = False
            TextBox8.ReadOnly = False

            pettycounter = pettycounter + 1
        Else
            MessageBox.Show("Particulars Must Not Be Empty!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        Dim delindex As Integer = e.Row.Index
        Dim totalamounts As Double = 0

        For a As Integer = delindex To pettycounter - 1
            pettycashArray(a, 0) = pettycashArray(a + 1, 0)
            pettycashArray(a, 1) = pettycashArray(a + 1, 1)
        Next

        pettycounter = pettycounter - 1

        For x As Integer = 0 To pettycounter
            totalamounts = totalamounts + pettycashArray(x, 1)
        Next

        TextBox9.Text = totalamounts
        TextBox5.Text = 0
        TextBox8.Text = 0

        If pettycounter = 0 Then
            TextBox5.ReadOnly = True
            TextBox8.ReadOnly = True
        End If

    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8)
        If (e.KeyChar.ToString = ".") And (TextBox7.Text.Contains(e.KeyChar.ToString)) Then
            e.Handled = True
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim paidto As String = TextBox1.Text
        Dim address As String = TextBox2.Text
        Dim refnumber As String = TextBox3.Text
        Dim datee As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim approvedby As String = TextBox10.Text
        Dim recievedby As String = TextBox11.Text
        Dim totalamount As Double = 0
        Dim accounttitlekey As String = ""
        Dim civamount As Double = TextBox5.Text
        Dim cibamount As Double = TextBox8.Text
        Dim purpose As String = TextBox4.Text

        Try
            accounttitlekey = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key
        Catch ex As Exception
            accounttitlekey = ""
        End Try

        For x As Integer = 0 To -1
            totalamount = totalamount + pettycashArray(x, 1)
        Next

        If TextBox1.Text.Count <> 0 And TextBox2.Text.Count <> 0 And TextBox3.Text.Count <> 0 And TextBox4.Text.Count <> 0 And TextBox5.Text.Count <> 0 And TextBox8.Text.Count <> 0 And TextBox10.Text.Count <> 0 And TextBox11.Text.Count <> 0 Then
            If pettycounter <> 0 Then
                Try
                    checkstate()
                    dbconn.Open()

                    With cmd
                        .Connection = dbconn
                        .CommandText = "INSERT INTO pettycash (referencenum,date,address,paidto,approvedby,recievedby,total,accounttitleID,civamount,cibamount,purpose) VALUES('" & refnumber & "','" & datee & "','" & address & "','" & paidto & "','" & approvedby & "','" & recievedby & "','" & totalamount & "','" & accounttitlekey & "', '" & civamount & "', '" & cibamount & "','" & purpose & "')"
                        .ExecuteNonQuery()
                        MessageBox.Show("Petty Cash: #" + refnumber + " is added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        TextBox5.Clear()
                        TextBox6.Clear()
                        TextBox7.Clear()
                        TextBox8.Clear()
                        TextBox10.Clear()
                        TextBox11.Clear()
                    End With
                Catch ex As Exception
                    MessageBox.Show("Petty Cash Not Added! " + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dbconn.Close()
                dbconn.Dispose()

                For x As Integer = 0 To pettycounter - 1
                    Try
                        checkstate()
                        dbconn.Open()

                        With cmd
                            .Connection = dbconn
                            .CommandText = "INSERT INTO pettycashitems (referencenum,particulars,amount) VALUES('" & refnumber & "','" & pettycashArray(x, 0) & "','" & pettycashArray(x, 1) & "')"
                            .ExecuteNonQuery()
                        End With


                    Catch ex As Exception
                        MessageBox.Show("Petty Cash Items Not Added! " + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    dbconn.Close()
                    dbconn.Dispose()
                Next

                pettycounter = 0

                DataGridView1.Rows.Clear()

                printpettycash.datafrom = refnumber
                printpettycash.ShowDialog()
            Else
                MessageBox.Show("Particulars must not be empty!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("All important information must not be empty!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        addaccounttitle.ShowDialog()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8)
        If (e.KeyChar.ToString = ".") And (TextBox5.Text.Contains(e.KeyChar.ToString)) Then
            e.Handled = True
            Exit Sub
        End If
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8)
        If (e.KeyChar.ToString = ".") And (TextBox8.Text.Contains(e.KeyChar.ToString)) Then
            e.Handled = True
            Exit Sub
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

        Dim civamount As Double
        Dim cibamount As Double
        Dim total As Double

        If TextBox5.Text.Count <> 0 Then
            civamount = TextBox5.Text
        Else
            civamount = 0
        End If

        If TextBox9.Text.Count <> 0 Then
            total = TextBox9.Text
        Else
            total = 0
        End If

        cibamount = total - civamount

        TextBox8.Text = cibamount

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Dim civamount As Double
        Dim cibamount As Double
        Dim total As Double

        If TextBox8.Text.Count <> 0 Then
            cibamount = TextBox8.Text
        Else
            cibamount = 0
        End If

        If TextBox9.Text.Count <> 0 Then
            total = TextBox9.Text
        Else
            total = 0
        End If

        civamount = total - cibamount

        TextBox5.Text = civamount
    End Sub
End Class