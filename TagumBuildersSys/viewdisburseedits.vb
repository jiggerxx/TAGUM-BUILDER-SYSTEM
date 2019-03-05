Public Class viewdisburseedits1

    Public pendingeditsdisburseArray(1000, 15) As String
    Private pendingdisburseitemsArray(100, 2) As String

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Dim x As Integer = 0
        Dim grid = DirectCast(sender, DataGridView)

        If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            If grid.Columns(e.ColumnIndex).Name = "Approvebtn" Then

                Try
                    checkstate()
                    dbconn.Open()
                    With cmd
                        .Connection = dbconn
                        .CommandText = "UPDATE cashcheckdisbursement SET paidto = '" & pendingeditsdisburseArray(e.RowIndex, 2) & "',address = '" & pendingeditsdisburseArray(e.RowIndex, 3) & "',date = '" & pendingeditsdisburseArray(e.RowIndex, 4) & "',purpose = '" & pendingeditsdisburseArray(e.RowIndex, 5) & "',accounttitleID = '" & pendingeditsdisburseArray(e.RowIndex, 15) & "',civamount = '" & pendingeditsdisburseArray(e.RowIndex, 7) & "',cibamount = '" & pendingeditsdisburseArray(e.RowIndex, 8) & "',disbursetotal = '" & pendingeditsdisburseArray(e.RowIndex, 9) & "',totalinwords = '" & pendingeditsdisburseArray(e.RowIndex, 10) & "',checknumber = '" & pendingeditsdisburseArray(e.RowIndex, 11) & "',checkdate = '" & pendingeditsdisburseArray(e.RowIndex, 12) & "',approvedby = '" & pendingeditsdisburseArray(e.RowIndex, 13) & "',receivedby = '" & pendingeditsdisburseArray(e.RowIndex, 14) & "' WHERE vouchernum ='" & pendingeditsdisburseArray(e.RowIndex, 1) & "'"
                        .ExecuteNonQuery()

                    End With
                Catch ex As Exception
                    MessageBox.Show("Error1!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dbconn.Close()
                dbconn.Dispose()

                Try
                    checkstate()
                    dbconn.Open()

                    With cmd
                        .Connection = dbconn
                        .CommandText = "SELECT * FROM disburseeditsitems WHERE vouchernum = '" & pendingeditsdisburseArray(e.RowIndex, 1) & "'"
                        dr = cmd.ExecuteReader

                        While dr.Read

                            pendingdisburseitemsArray(x, 0) = dr.Item("invoicenum")
                            pendingdisburseitemsArray(x, 1) = dr.Item("particulars")
                            pendingdisburseitemsArray(x, 2) = dr.Item("amount")

                            x = x + 1
                        End While
                    End With

                Catch ex As Exception
                    MessageBox.Show("Error2!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dbconn.Close()
                dbconn.Dispose()

                Try
                    checkstate()
                    dbconn.Open()
                    With cmd
                        .Connection = dbconn
                        .CommandText = "DELETE FROM cashcheckdisbursementitems WHERE vouchernum ='" & pendingeditsdisburseArray(e.RowIndex, 1) & "'"
                        .ExecuteNonQuery()

                    End With
                Catch ex As Exception
                    MessageBox.Show("Error3!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                dbconn.Close()
                dbconn.Dispose()

                For a As Integer = 0 To x - 1
                    Try
                        checkstate()
                        dbconn.Open()
                        With cmd
                            .Connection = dbconn
                            .CommandText = "INSERT INTO cashcheckdisbursementitems (vouchernum,invoicenum,particulars,amount) VALUES ('" & pendingeditsdisburseArray(e.RowIndex, 1) & "','" & pendingdisburseitemsArray(a, 0) & "','" & pendingdisburseitemsArray(a, 1) & "','" & pendingdisburseitemsArray(a, 2) & "')"
                            .ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        MessageBox.Show("Error4!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    dbconn.Close()
                    dbconn.Dispose()
                Next

                Try
                    checkstate()
                    dbconn.Open()
                    With cmd
                        .Connection = dbconn
                        .CommandText = "DELETE FROM disburseedits WHERE vouchernum ='" & pendingeditsdisburseArray(e.RowIndex, 1) & "'"
                        .ExecuteNonQuery()

                    End With
                Catch ex As Exception
                    MessageBox.Show("Error5!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dbconn.Close()
                dbconn.Dispose()

                Try
                    checkstate()
                    dbconn.Open()
                    With cmd
                        .Connection = dbconn
                        .CommandText = "DELETE FROM disburseeditsitems WHERE vouchernum ='" & pendingeditsdisburseArray(e.RowIndex, 1) & "'"
                        .ExecuteNonQuery()

                    End With
                Catch ex As Exception
                    MessageBox.Show("Error6!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dbconn.Close()
                dbconn.Dispose()

                loadpendingdisburseedits()
            ElseIf grid.Columns(e.ColumnIndex).Name = "Declinebtn" Then
                Try
                    checkstate()
                    dbconn.Open()
                    With cmd
                        .Connection = dbconn
                        .CommandText = "DELETE FROM disburseedits WHERE vouchernum ='" & pendingeditsdisburseArray(e.RowIndex, 1) & "'"
                        .ExecuteNonQuery()

                    End With
                Catch ex As Exception
                    MessageBox.Show("Error7!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dbconn.Close()
                dbconn.Dispose()

                Try
                    checkstate()
                    dbconn.Open()
                    With cmd
                        .Connection = dbconn
                        .CommandText = "DELETE FROM disburseeditsitems WHERE vouchernum ='" & pendingeditsdisburseArray(e.RowIndex, 1) & "'"
                        .ExecuteNonQuery()

                    End With
                Catch ex As Exception
                    MessageBox.Show("Error8!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dbconn.Close()
                dbconn.Dispose()

                loadpendingdisburseedits()

            ElseIf grid.Columns(e.ColumnIndex).Name = "ViewItemsBtn" Then
                disburseitemsviewer.datafrom = pendingeditsdisburseArray(e.RowIndex, 1)
                disburseitemsviewer.ShowDialog()
            End If
        End If
    End Sub
End Class