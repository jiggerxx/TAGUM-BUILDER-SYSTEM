Imports MySql.Data.MySqlClient

Module DBfunctions

    Public dbconn As New MySqlConnection("server=192.168.2.6;userid=;password=;database=tgdb2")
    Public conn As String = "Data Source=localhost; Database=tgdb2; User ID =root; Password=;"
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader

    Public Function checkstate() As Boolean
        Try
            If dbconn.State = ConnectionState.Open Then
                dbconn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Database Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Public Sub loadponum()
        Dim CreateCommand As MySqlCommand = dbconn.CreateCommand
        Dim da As New MySqlDataAdapter("SELECT * FROM purchaseorders ORDER BY idai DESC", dbconn)
        Dim dt As New DataTable

        da.Fill(dt)
        addpurchaseorder.TextBox3.Text = Today.ToString("PO-yyyyMMdd") & dt.Rows.Count() + 1
    End Sub

    Public Sub loadgridemp()

        searchemployee.grid.Rows.Clear()
        dbconn.Close()
        Try

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT CONCAT(employ_lname,', ',employ_fname) as 'name',employ_id,employ_position FROM employees "
                dr = cmd.ExecuteReader

                While dr.Read

                    searchemployee.grid.Rows.Add(dr.Item("employ_id"), dr.Item("name"), dr.Item("employ_position"))
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()
    End Sub

    Public Function loadpendingdisburseedits()
        Dim disbursevouchersvalue As New Dictionary(Of String, String)()
        Dim disbursevouchersauto As New AutoCompleteStringCollection
        Dim tandf As Boolean = False
        Dim counterX As Integer = 0
        Try
            viewdisburseedits1.DataGridView1.Rows.Clear()

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT disburseedits.*,accountingtitles.* FROM disburseedits LEFT JOIN accountingtitles ON disburseedits.accounttitleID = accountingtitles.idai"
                dr = cmd.ExecuteReader

                While dr.Read
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 0) = dr.Item("idai")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 1) = dr.Item("vouchernum")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 2) = dr.Item("paidto")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 3) = dr.Item("address")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 4) = dr.GetDateTime("date").ToString("yyyy-MM-dd")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 5) = dr.Item("purpose")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 6) = dr.Item("accounttitle")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 15) = dr.Item("accounttitleID")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 7) = dr.Item("civamount")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 8) = dr.Item("cibamount")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 9) = dr.Item("disbursetotal")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 10) = dr.Item("totalinwords")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 11) = dr.Item("checknumber")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 12) = dr.GetDateTime("checkdate").ToString("yyyy-MM-dd")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 13) = dr.Item("approvedby")
                    viewdisburseedits1.pendingeditsdisburseArray(counterX, 14) = dr.Item("receivedby")

                    viewdisburseedits1.DataGridView1.Rows.Add(viewdisburseedits1.pendingeditsdisburseArray(counterX, 1), viewdisburseedits1.pendingeditsdisburseArray(counterX, 2), viewdisburseedits1.pendingeditsdisburseArray(counterX, 3), viewdisburseedits1.pendingeditsdisburseArray(counterX, 4), viewdisburseedits1.pendingeditsdisburseArray(counterX, 5), viewdisburseedits1.pendingeditsdisburseArray(counterX, 6), viewdisburseedits1.pendingeditsdisburseArray(counterX, 7), viewdisburseedits1.pendingeditsdisburseArray(counterX, 8), viewdisburseedits1.pendingeditsdisburseArray(counterX, 9), viewdisburseedits1.pendingeditsdisburseArray(counterX, 10), viewdisburseedits1.pendingeditsdisburseArray(counterX, 11), viewdisburseedits1.pendingeditsdisburseArray(counterX, 12), viewdisburseedits1.pendingeditsdisburseArray(counterX, 13), viewdisburseedits1.pendingeditsdisburseArray(counterX, 14), "View Particulars", "Approve", "Decline")

                    counterX = counterX + 1
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + vbNewLine + "Error in Load Edit Disbursements Voucher!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            MessageBox.Show("No Disbursements Voucher Edits! Please Add One First!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Nothing
    End Function
    Public Function loaddisbursementvouchers()
        Dim disbursevouchersvalue As New Dictionary(Of String, String)()
        Dim disbursevouchersauto As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try
            disbursementedit.ComboBox2.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT cashcheckdisbursement.*,disburseedits.* FROM cashcheckdisbursement LEFT JOIN disburseedits ON disburseedits.vouchernum = cashcheckdisbursement.vouchernum WHERE disburseedits.vouchernum IS NULL"
                dr = cmd.ExecuteReader

                While dr.Read

                    disbursevouchersvalue.Add(dr.Item("idai"), dr.Item("vouchernum"))
                    disbursevouchersauto.AddRange(New String() {dr.Item("vouchernum")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + vbNewLine + "Error in Load Disbursements Voucher!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try
                disbursementedit.ComboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
                disbursementedit.ComboBox2.AutoCompleteCustomSource = disbursevouchersauto
                disbursementedit.ComboBox2.DataSource = New BindingSource(disbursevouchersvalue, Nothing)
                disbursementedit.ComboBox2.DisplayMember = "Value"
                disbursementedit.ComboBox2.ValueMember = "Key"
                disbursementedit.ComboBox2.SelectedIndex = -1
            Catch ex As Exception
                MessageBox.Show(ex.ToString + vbNewLine + " Error in Disbursements Voucher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Disbursements Voucher Found! Please Add One First!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Nothing
    End Function
    Public Function loadaccounttitles()
        Dim accounttitlesvalue As New Dictionary(Of String, String)()
        Dim accounttitlesvalueauto As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try
            addpettycash.ComboBox1.DataSource = Nothing
            addpurchaseorder.ComboBox1.DataSource = Nothing
            addcashcheckdisbursement.ComboBox1.DataSource = Nothing
            disbursementedit.ComboBox1.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM accountingtitles"
                dr = cmd.ExecuteReader

                While dr.Read

                    accounttitlesvalue.Add(dr.Item("idai"), dr.Item("accounttitle"))
                    accounttitlesvalueauto.AddRange(New String() {dr.Item("accounttitle")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + vbNewLine + "Error in Load Account Titles!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try
                addpettycash.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                addpettycash.ComboBox1.AutoCompleteCustomSource = accounttitlesvalueauto
                addpettycash.ComboBox1.DataSource = New BindingSource(accounttitlesvalue, Nothing)
                addpettycash.ComboBox1.DisplayMember = "Value"
                addpettycash.ComboBox1.ValueMember = "Key"
                addpettycash.ComboBox1.SelectedIndex = -1

                addpurchaseorder.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                addpurchaseorder.ComboBox1.AutoCompleteCustomSource = accounttitlesvalueauto
                addpurchaseorder.ComboBox1.DataSource = New BindingSource(accounttitlesvalue, Nothing)
                addpurchaseorder.ComboBox1.DisplayMember = "Value"
                addpurchaseorder.ComboBox1.ValueMember = "Key"
                addpurchaseorder.ComboBox1.SelectedIndex = -1

                addcashcheckdisbursement.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                addcashcheckdisbursement.ComboBox1.AutoCompleteCustomSource = accounttitlesvalueauto
                addcashcheckdisbursement.ComboBox1.DataSource = New BindingSource(accounttitlesvalue, Nothing)
                addcashcheckdisbursement.ComboBox1.DisplayMember = "Value"
                addcashcheckdisbursement.ComboBox1.ValueMember = "Key"
                addcashcheckdisbursement.ComboBox1.SelectedIndex = -1

                disbursementedit.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                disbursementedit.ComboBox1.AutoCompleteCustomSource = accounttitlesvalueauto
                disbursementedit.ComboBox1.DataSource = New BindingSource(accounttitlesvalue, Nothing)
                disbursementedit.ComboBox1.DisplayMember = "Value"
                disbursementedit.ComboBox1.ValueMember = "Key"
                disbursementedit.ComboBox1.SelectedIndex = -1
            Catch ex As Exception
                MessageBox.Show(ex.ToString + vbNewLine + " Error in Load Account Titles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Account Titles Found! Please Add One First!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Nothing
    End Function

    Public Sub loadpobiz()

        Dim accounttitlesvalue As New Dictionary(Of String, String)()
        Dim accounttitlesvalueauto As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try
            addpurchaseorder.ComboBox2.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM purchaseorders ORDER BY businessname ASC "
                dr = cmd.ExecuteReader

                While dr.Read

                    accounttitlesvalue.Add(dr.Item("referencenum"), dr.Item("businessname"))
                    accounttitlesvalueauto.AddRange(New String() {dr.Item("businessname")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + vbNewLine + "Error in load names!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try
                addpurchaseorder.ComboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
                addpurchaseorder.ComboBox2.AutoCompleteCustomSource = accounttitlesvalueauto
                addpurchaseorder.ComboBox2.DataSource = New BindingSource(accounttitlesvalue, Nothing)
                addpurchaseorder.ComboBox2.DisplayMember = "Value"
                addpurchaseorder.ComboBox2.ValueMember = "Key"
                addpurchaseorder.ComboBox2.SelectedIndex = -1

            Catch ex As Exception
                MessageBox.Show(ex.ToString + vbNewLine + " Error in Load Account Titles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Account Titles Found! Please Add One First!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    
End Module
