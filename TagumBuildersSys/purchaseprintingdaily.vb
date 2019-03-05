Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class purchaseprintingdaily

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dsConn As New MySqlConnection(conn)
        Dim dsDA As New MySqlDataAdapter
        Dim rd As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim selecteddate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")

        Try

            Dim d As New DataSet

            dsConn.Open()

            Dim strSQL As String = ""

            strSQL = "SELECT '" & selecteddate & "' as maxdate,(SELECT SUM(purchasetotal) FROM purchaseorders WHERE purchaseorders.date = '" & selecteddate & "')as total,purchaseorders.*,purchaseordersitems.*,accountingtitles.* FROM purchaseorders LEFT JOIN purchaseordersitems ON purchaseorders.referencenum = purchaseordersitems.referencenum LEFT JOIN accountingtitles ON purchaseorders.accounttitleID = accountingtitles.idai WHERE purchaseorders.date = '" & selecteddate & "'"
            dsDA.SelectCommand = New MySqlCommand(strSQL, dsConn)
            dsDA.Fill(d, "purchaseorder")

            rd = New purchaseprintingdaily2
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