Imports MySql.Data.MySqlClient

Module VBFunctions
    Public Function showemployeeinfo()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = employeesform.Panel1
        Main.Panel2.Controls.Add(panelo)

        Return Nothing
    End Function
    Public Function showpendingeditdisburse()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = viewdisburseedits1.Panel1
        Main.Panel2.Controls.Add(panelo)

        Return Nothing
    End Function
    Public Function showdisbursementedit()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = disbursementedit.Panel1
        Main.Panel2.Controls.Add(panelo)

        Return Nothing
    End Function
    Public Function showdisbursementprinting()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = cashcheckdisbursementprinting.Panel1
        Main.Panel2.Controls.Add(panelo)

        Return Nothing
    End Function
    Public Function showaddcashcheckdisbursement()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = addcashcheckdisbursement.Panel1
        Main.Panel2.Controls.Add(panelo)

        Return Nothing
    End Function
    Public Function showcashcheckdisbursement()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = cashcheckdisbursement.Panel1
        Main.Panel2.Controls.Add(panelo)

        Return Nothing
    End Function
    Public Function showpurchaseprinting()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = purchaseprinting.Panel1
        Main.Panel2.Controls.Add(panelo)

        Return Nothing
    End Function
    Public Function showpettycashprinting()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = pettycashprinting.Panel1
        Main.Panel2.Controls.Add(panelo)

        Return Nothing
    End Function
    Public Function showaddpettycash()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = addpettycash.Panel1
        Main.Panel2.Controls.Add(panelo)

        Return Nothing
    End Function
    Public Function showpettycash()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = pettycash.Panel1
        Main.Panel2.Controls.Add(panelo)

        Return Nothing
    End Function
    Public Function showpurchaseorders()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = purchaseorders.Panel1
        Main.Panel2.Controls.Add(panelo)
        Return Nothing
    End Function
    Public Function showaddpurchaseorders()
        Dim panelo As New Panel

        Main.Panel2.Controls.Clear()
        panelo = addpurchaseorder.Panel1
        Main.Panel2.Controls.Add(panelo)

        loadponum()
        Return Nothing
    End Function

End Module
