﻿Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class disbursementbyrange

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dsConn As New MySqlConnection(conn)
        Dim dsDA As New MySqlDataAdapter
        Dim rd As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim dateee1 As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim dateee2 As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")

        Try

            Dim d As New DataSet

            dsConn.Open()

            Dim strSQL As String = ""

            strSQL = "SELECT '" & dateee2 & "' as maxdate,'" & dateee1 & "' as mindate,cashcheckdisbursement.*,accountingtitles.*,(SELECT SUM(disbursetotal) FROM cashcheckdisbursement WHERE cashcheckdisbursement.date BETWEEN '" & dateee1 & "' AND '" & dateee2 & "') as totalamount FROM cashcheckdisbursement LEFT JOIN accountingtitles ON cashcheckdisbursement.accounttitleID = accountingtitles.idai WHERE cashcheckdisbursement.date BETWEEN '" & dateee1 & "' AND '" & dateee2 & "'"
            dsDA.SelectCommand = New MySqlCommand(strSQL, dsConn)
            dsDA.Fill(d, "disbursement")

            rd = New disbursementbyrange2
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