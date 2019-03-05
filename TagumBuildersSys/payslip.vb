Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class payslip

    Dim con As New MySqlConnection("Server=localhost;User id=root;Password=;Database=tgdb")

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dsConn As New MySqlConnection(conn)
        Dim dsDA As New MySqlDataAdapter
        Dim rd As CrystalDecisions.CrystalReports.Engine.ReportDocument

        Try

            Dim p As New DataSet

            dsConn.Open()

            Dim strSQL As String = ""

            'strSQL = "SELECT cashcheckdisbursement.*,cashcheckdisbursementitems.*,accountingtitles.* FROM cashcheckdisbursement LEFT JOIN cashcheckdisbursementitems ON cashcheckdisbursement.vouchernum = cashcheckdisbursementitems.vouchernum LEFT JOIN accountingtitles ON cashcheckdisbursement.accounttitleID = accountingtitles.idai WHERE cashcheckdisbursement.vouchernum = '" & datafrom & "'"
            strSQL = "SELECT * FROM payroll_done WHERE emp_id = '" & TextBox1.Text & "'"
            dsDA.SelectCommand = New MySqlCommand(strSQL, dsConn)
            dsDA.Fill(p, "payroll")

            rd = New printpayslip
            rd.SetDataSource(p)

            reportviewer.CrystalReportViewer1.ReportSource = rd
            reportviewer.ShowDialog()
            reportviewer.Dispose()

            dsConn.Close()
            dsConn.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub payslip_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CreateCommand As MySqlCommand = con.CreateCommand
        Dim da As New MySqlDataAdapter("SELECT * FROM employees where employ_id = '" & TextBox1.Text & "'", con)
        Dim dt As New DataTable

        da.Fill(dt)


        If dt.Rows(0) Is Nothing Then
            MsgBox("No such user.")

        Else
            MsgBox("Employee found!")
            MsgBox(dt.Rows(0)("employ_lname").ToString)
            Button2.Enabled = True
        End If
    End Sub
End Class