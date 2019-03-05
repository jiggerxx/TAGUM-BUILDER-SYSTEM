Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class pettycashprintbyrangey

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
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

            strSQL = "SELECT '" & dateee1 & "' as mindate,'" & dateee2 & "' as maxdate,pettycash.*,accountingtitles.*,(SELECT SUM(total) FROM pettycash WHERE pettycash.date BETWEEN '" & dateee1 & "' AND  '" & dateee2 & "' ) as totalamount FROM pettycash LEFT JOIN accountingtitles ON pettycash.accounttitleID = accountingtitles.idai WHERE pettycash.date BETWEEN '" & dateee1 & "' AND  '" & dateee2 & "'"
            dsDA.SelectCommand = New MySqlCommand(strSQL, dsConn)
            dsDA.Fill(d, "pettycash")

            rd = New pettycashprintbyrange
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