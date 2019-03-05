Public Class disbursementedit

    Private editdisburseArray(100, 2) As String
    Private disbursecounter As Integer
    Private selectednavoucher As String
    Private selectedaccounttitle As String


    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim selectedvoucher As String

        Try
            selectedvoucher = DirectCast(ComboBox2.SelectedItem, KeyValuePair(Of String, String)).Key
            selectednavoucher = DirectCast(ComboBox2.SelectedItem, KeyValuePair(Of String, String)).Value
        Catch ex As Exception
            selectedvoucher = ""
            selectednavoucher = ""
        End Try

        DataGridView1.Rows.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = ""
        disbursecounter = 0

        Try
            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT cashcheckdisbursement.*,accountingtitles.*,cashcheckdisbursementitems.* FROM cashcheckdisbursement LEFT JOIN accountingtitles ON cashcheckdisbursement.accounttitleID = accountingtitles.idai LEFT JOIN cashcheckdisbursementitems ON cashcheckdisbursement.vouchernum = cashcheckdisbursementitems.vouchernum WHERE cashcheckdisbursement.idai = '" & selectedvoucher & "'"
                dr = cmd.ExecuteReader

                While dr.Read
                    DateTimePicker1.Value = dr.Item("date")
                    TextBox1.Text = dr.Item("paidto")
                    TextBox2.Text = dr.Item("address")
                    TextBox4.Text = dr.Item("purpose")

                    TextBox3.Text = dr.Item("accounttitleID")
                    ComboBox1.SelectedText = dr.Item("accounttitle")

                    editdisburseArray(disbursecounter, 0) = dr.Item("invoicenum")
                    editdisburseArray(disbursecounter, 1) = dr.Item("particulars")
                    editdisburseArray(disbursecounter, 2) = dr.Item("amount")

                    DataGridView1.Rows.Add(editdisburseArray(disbursecounter, 0), editdisburseArray(disbursecounter, 1), editdisburseArray(disbursecounter, 2))

                    TextBox14.Text = dr.Item("totalinwords")
                    TextBox5.Text = dr.Item("civamount")
                    TextBox8.Text = dr.Item("civamount")
                    TextBox9.Text = dr.Item("disbursetotal")
                    TextBox13.Text = dr.Item("checknumber")
                    DateTimePicker2.Value = dr.Item("checkdate")
                    TextBox10.Text = dr.Item("approvedby")
                    TextBox11.Text = dr.Item("receivedby")

                    disbursecounter = disbursecounter + 1
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + vbNewLine + "Voucher Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        dbconn.Close()
        dbconn.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim paidto As String = TextBox1.Text
        Dim address As String = TextBox2.Text
        Dim datee As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim approvedby As String = TextBox10.Text
        Dim receivedby As String = TextBox11.Text
        Dim totalamount As Double = 0
        Dim civamount As Double = TextBox5.Text
        Dim cibamount As Double = TextBox8.Text
        Dim purpose As String = TextBox4.Text
        Dim checkdate As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Dim checknum As String = TextBox13.Text
        Dim totalinwords As String = TextBox14.Text

        selectedaccounttitle = TextBox3.Text

        For x As Integer = 0 To disbursecounter
            totalamount = totalamount + editdisburseArray(x, 2)
        Next

        If TextBox1.Text.Count <> 0 And TextBox2.Text.Count <> 0 And selectednavoucher <> "" And TextBox4.Text.Count <> 0 And TextBox5.Text.Count <> 0 And TextBox8.Text.Count <> 0 And TextBox10.Text.Count <> 0 And TextBox11.Text.Count <> 0 Then
            If disbursecounter <> 0 Then
                Try
                    checkstate()
                    dbconn.Open()

                    With cmd
                        .Connection = dbconn
                        .CommandText = "INSERT INTO disburseedits (vouchernum,paidto,address,date,purpose,accounttitleID,civamount,cibamount,disbursetotal,totalinwords,checknumber,checkdate,approvedby,receivedby) VALUES('" & selectednavoucher & "','" & paidto & "','" & address & "','" & datee & "','" & purpose & "','" & selectedaccounttitle & "','" & civamount & "','" & cibamount & "', '" & totalamount & "','" & totalinwords & "', '" & checknum & "','" & checkdate & "','" & approvedby & "','" & receivedby & "')"
                        .ExecuteNonQuery()
                        MessageBox.Show("Cash/Check Disbursement Voucher #" + vbNewLine + selectednavoucher + " edit is added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                      
                    End With
                Catch ex As Exception
                    MessageBox.Show("Cash/Check Disbursement Voucher Not Added! " + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dbconn.Close()
                dbconn.Dispose()

                For x As Integer = 0 To disbursecounter - 1
                    Try
                        checkstate()
                        dbconn.Open()

                        With cmd
                            .Connection = dbconn
                            .CommandText = "INSERT INTO disburseeditsitems (vouchernum,invoicenum,particulars,amount) VALUES('" & selectednavoucher & "','" & editdisburseArray(x, 0) & "','" & editdisburseArray(x, 1) & "','" & editdisburseArray(x, 2) & "')"
                            .ExecuteNonQuery()
                        End With


                    Catch ex As Exception
                        MessageBox.Show("Cash/Check Disbursement Voucher Edit Not Added! " + vbNewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    dbconn.Close()
                    dbconn.Dispose()
                Next

                disbursecounter = 0

                DataGridView1.Rows.Clear()
                loaddisbursementvouchers()

                ComboBox2.SelectedIndex = -1
                TextBox1.Clear()
                TextBox2.Clear()
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
                TextBox14.Clear()
            Else
                MessageBox.Show("Particulars must not be empty!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("All important information must not be empty!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            TextBox3.Text = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim totalamounts As Double = 0

        editdisburseArray(disbursecounter, 0) = TextBox12.Text
        editdisburseArray(disbursecounter, 1) = TextBox6.Text
        editdisburseArray(disbursecounter, 2) = TextBox7.Text

        disbursecounter = disbursecounter + 1

        DataGridView1.Rows.Clear()

        For a As Integer = 0 To disbursecounter - 1
            DataGridView1.Rows.Add(editdisburseArray(a, 0), editdisburseArray(a, 1), editdisburseArray(a, 2))
            totalamounts = totalamounts + editdisburseArray(a, 2)
        Next

        TextBox9.Text = totalamounts

        TextBox12.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
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
        Dim totalamounts As Double = 0

        For a As Integer = delindex To disbursecounter - 1
            editdisburseArray(a, 0) = editdisburseArray(a + 1, 0)
            editdisburseArray(a, 1) = editdisburseArray(a + 1, 1)
            editdisburseArray(a, 2) = editdisburseArray(a + 1, 2)
        Next

        disbursecounter = disbursecounter - 1

        For x As Integer = 0 To disbursecounter
            totalamounts = totalamounts + editdisburseArray(x, 2)
        Next

        TextBox9.Text = totalamounts
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