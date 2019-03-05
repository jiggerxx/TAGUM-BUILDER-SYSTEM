Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class disbursementbymonth

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dsConn As New MySqlConnection(conn)
        Dim dsDA As New MySqlDataAdapter
        Dim rd As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim dateeemonth As String = DateTimePicker1.Value.Month
        Dim dateeeyear As String = DateTimePicker1.Value.Year
        Dim display As String = ""

        If dateeemonth = 1 Then
            display = "January " & dateeeyear
        ElseIf dateeemonth = 2 Then
            display = "February " & dateeeyear
        ElseIf dateeemonth = 3 Then
            display = "March " & dateeeyear
        ElseIf dateeemonth = 4 Then
            display = "April " & dateeeyear
        ElseIf dateeemonth = 5 Then
            display = "May " & dateeeyear
        ElseIf dateeemonth = 6 Then
            display = "June " & dateeeyear
        ElseIf dateeemonth = 7 Then
            display = "July " & dateeeyear
        ElseIf dateeemonth = 8 Then
            display = "August " & dateeeyear
        ElseIf dateeemonth = 9 Then
            display = "September " & dateeeyear
        ElseIf dateeemonth = 10 Then
            display = "October " & dateeeyear
        ElseIf dateeemonth = 11 Then
            display = "November " & dateeeyear
        ElseIf dateeemonth = 12 Then
            display = "December " & dateeeyear
        End If

        Try

            Dim d As New DataSet

            dsConn.Open()

            Dim strSQL As String = ""

            strSQL = "SELECT '" & display & "' as maxdate,cashcheckdisbursement.*,accountingtitles.*,(SELECT SUM(disbursetotal) FROM cashcheckdisbursement WHERE MONTH(cashcheckdisbursement.date) = '" & dateeemonth & "' AND YEAR(cashcheckdisbursement.date) = '" & dateeeyear & "') as totalamount FROM cashcheckdisbursement LEFT JOIN accountingtitles ON cashcheckdisbursement.accounttitleID = accountingtitles.idai WHERE MONTH(cashcheckdisbursement.date) = '" & dateeemonth & "' AND YEAR(cashcheckdisbursement.date) = '" & dateeeyear & "'"
            dsDA.SelectCommand = New MySqlCommand(strSQL, dsConn)
            dsDA.Fill(d, "disbursement")

            rd = New disbursementbymonth2
            rd.SetDataSource(d)

            reportviewer.CrystalReportViewer1.ReportSource = rd
            reportviewer.ShowDialog()
            reportviewer.Dispose()

            dsConn.Close()
            dsConn.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class