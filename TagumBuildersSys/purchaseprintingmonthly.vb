﻿Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class purchaseprintingmonthly

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

            strSQL = "SELECT '" & display & "' as maxdate,(SELECT SUM(purchasetotal) FROM purchaseorders WHERE MONTH(purchaseorders.date) = '" & dateeemonth & "' AND YEAR(purchaseorders.date) = '" & dateeeyear & "')as total,purchaseorders.*,purchaseordersitems.*,accountingtitles.* FROM purchaseorders LEFT JOIN purchaseordersitems ON purchaseorders.referencenum = purchaseordersitems.referencenum LEFT JOIN accountingtitles ON purchaseorders.accounttitleID = accountingtitles.idai WHERE MONTH(purchaseorders.date) = '" & dateeemonth & "' AND YEAR(purchaseorders.date) = '" & dateeeyear & "'"
            dsDA.SelectCommand = New MySqlCommand(strSQL, dsConn)
            dsDA.Fill(d, "purchaseorder")

            rd = New purchaseprintingmonthly2
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