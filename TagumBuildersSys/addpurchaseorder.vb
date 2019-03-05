Public Class addpurchaseorder

    Public posArray(100, 4) As String
    Public poscounter As Integer = 0

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim referencenum As String = TextBox3.Text
        Dim dateadd As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim purpose As String = purposetxt.Text
        Dim businessname As String = ComboBox2.Text
        Dim address As String = RichTextBox1.Text
        'Dim destination As String = RichTextBox2.Text
        Dim requestingsite As String = TextBox9.Text
        Dim checkedby As String = TextBox10.Text
        Dim approvedby As String = TextBox11.Text
        Dim accounttitlekey As String
        Dim cibamount As Double = TextBox12.Text
        Dim civamount As Double = TextBox13.Text
        Dim totalamount As Double = TextBox8.Text

        Try
            accounttitlekey = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key
        Catch ex As Exception
            accounttitlekey = ""
        End Try
        If DataGridView1.RowCount <> 0 Then
            'If RichTextBox1.Text.Count <> 0 And RichTextBox2.Text.Count <> 0 And purposetxt.Text.Count <> 0 And bussinessname.Text.Count <> 0 And TextBox3.Text.Count <> 0 And TextBox8.Text.Count <> 0 And TextBox9.Text.Count <> 0 And TextBox10.Text.Count <> 0 And TextBox11.Text.Count <> 0 And TextBox12.Text.Count <> 0 And TextBox13.Text.Count <> 0 And accounttitlekey <> "" Then
            If poscounter <> 0 Then
                Try
                    checkstate()
                    dbconn.Open()

                    With cmd
                        .Connection = dbconn
                        .CommandText = "INSERT INTO purchaseorders (referencenum,date,purpose,businessname,address,destination,requestingsites,checkedby,approvedby,civamount,cibamount,accounttitleID,purchasetotal) VALUES('" & referencenum & "','" & dateadd & "','" & purpose & "','" & businessname & "','" & address & "',NULL,'" & requestingsite & "','" & checkedby & "','" & approvedby & "','" & civamount & "','" & cibamount & "','" & accounttitlekey & "','" & totalamount & "')"
                        .ExecuteNonQuery()
                        MessageBox.Show("Purchase Order: #" + referencenum + " is added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        purposetxt.Clear()
                        bussinessname.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        TextBox5.Clear()
                        TextBox6.Clear()
                        TextBox7.Clear()
                        TextBox8.Clear()
                        TextBox9.Clear()
                        TextBox10.Clear()
                        TextBox11.Clear()
                        TextBox12.Clear()
                        TextBox13.Clear()
                        RichTextBox1.Clear()
                        'RichTextBox2.Clear()
                        ComboBox1.SelectedIndex = -1
                        loadponum()
                    End With
                Catch ex As Exception
                    MessageBox.Show("Purchase Order Not Added! " + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dbconn.Close()
                dbconn.Dispose()

                For x As Integer = 0 To poscounter - 1
                    Try
                        checkstate()
                        dbconn.Open()

                        With cmd
                            .Connection = dbconn
                            .CommandText = "INSERT INTO purchaseordersitems (referencenum,qty,unit,particulars,price,amount) VALUES('" & referencenum & "','" & posArray(x, 0) & "','" & posArray(x, 1) & "','" & posArray(x, 2) & "','" & posArray(x, 3) & "','" & posArray(x, 4) & "')"
                            .ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        MessageBox.Show("Purchase Order Items Not Added! " + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    dbconn.Close()
                    dbconn.Dispose()
                Next

                poscounter = 0
                DataGridView1.Rows.Clear()

                printpurchaseorders.datafrom = referencenum
                printpurchaseorders.ShowDialog()
            Else
                MessageBox.Show("Particulars must not be empty!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Particulars must not be empty!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim quantity As Integer
        Dim unit As String = TextBox5.Text
        Dim particulars As String = TextBox6.Text
        Dim price As Double
        Dim total As Double

        If TextBox4.Text <> "" Then
            quantity = TextBox4.Text
        Else
            quantity = 0
        End If

        If TextBox7.Text <> "" Then
            price = TextBox7.Text
        Else
            price = 0
        End If

        If particulars <> "" Then
            posArray(poscounter, 0) = quantity
            posArray(poscounter, 1) = unit
            posArray(poscounter, 2) = particulars
            posArray(poscounter, 3) = price
            posArray(poscounter, 4) = quantity * price

            poscounter = poscounter + 1

            DataGridView1.Rows.Clear()

            For x As Integer = 0 To poscounter - 1
                DataGridView1.Rows.Add(New String() {posArray(x, 0), posArray(x, 1), posArray(x, 2), posArray(x, 3), posArray(x, 4)})
                total = total + posArray(x, 4)
            Next

            TextBox8.Text = total
            TextBox12.ReadOnly = False
            TextBox13.ReadOnly = False
            TextBox12.Text = 0
            TextBox13.Text = 0

            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
        Else
            MessageBox.Show("Particulars must not be empty", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8)
        If (e.KeyChar.ToString = ".") And (TextBox7.Text.Contains(e.KeyChar.ToString)) Then
            e.Handled = True
            Exit Sub
        End If
    End Sub

    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        Dim delindex As Integer = e.Row.Index

        For a As Integer = delindex To poscounter - 1

            posArray(a, 0) = posArray(a + 1, 0)
            posArray(a, 1) = posArray(a + 1, 1)
            posArray(a, 2) = posArray(a + 1, 2)
            posArray(a, 3) = posArray(a + 1, 3)
            posArray(a, 4) = posArray(a + 1, 4)

        Next

        poscounter = poscounter - 1
        TextBox12.Text = 0
        TextBox13.Text = 0

        If poscounter = 0 Then
            TextBox12.ReadOnly = True
            TextBox13.ReadOnly = True
        End If
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        Dim civamount As Double
        Dim cibamount As Double
        Dim total As Double

        If TextBox13.Text.Count <> 0 Then
            civamount = TextBox13.Text
        Else
            civamount = 0
        End If

        If TextBox8.Text.Count <> 0 Then
            total = TextBox8.Text
        Else
            total = 0
        End If

        cibamount = total - civamount

        TextBox12.Text = cibamount
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        Dim civamount As Double
        Dim cibamount As Double
        Dim total As Double

        If TextBox12.Text.Count <> 0 Then
            cibamount = TextBox12.Text
        Else
            cibamount = 0
        End If

        If TextBox8.Text.Count <> 0 Then
            total = TextBox8.Text
        Else
            total = 0
        End If

        civamount = total - cibamount

        TextBox13.Text = civamount
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        addaccounttitle.ShowDialog()
    End Sub
End Class