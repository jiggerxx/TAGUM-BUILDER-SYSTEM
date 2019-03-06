<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class leaveform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(leaveform))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pos = New System.Windows.Forms.Label()
        Me.dept = New System.Windows.Forms.Label()
        Me.vl = New System.Windows.Forms.Label()
        Me.sl = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dateofleave = New System.Windows.Forms.DateTimePicker()
        Me.dateofresume = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.noofdays = New System.Windows.Forms.Label()
        Me.formid = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.reasons = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.empname = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.prepby = New System.Windows.Forms.TextBox()
        Me.checkedby = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.empid = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cachedprintcashcheckdisbursement21 = New TagumBuildersSys.Cachedprintcashcheckdisbursement2()
        Me.typeofleave = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(585, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "APPLICATION FORM OF ABSENCE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "APPICANT'S NAME:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "POSITION:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "DEPARTMENT:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(514, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 25)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "VL:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(516, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 25)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "SL:"
        '
        'pos
        '
        Me.pos.AutoSize = True
        Me.pos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pos.Location = New System.Drawing.Point(145, 100)
        Me.pos.Name = "pos"
        Me.pos.Size = New System.Drawing.Size(20, 25)
        Me.pos.TabIndex = 7
        Me.pos.Text = "-"
        '
        'dept
        '
        Me.dept.AutoSize = True
        Me.dept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dept.Location = New System.Drawing.Point(145, 122)
        Me.dept.Name = "dept"
        Me.dept.Size = New System.Drawing.Size(20, 25)
        Me.dept.TabIndex = 8
        Me.dept.Text = "-"
        '
        'vl
        '
        Me.vl.AutoSize = True
        Me.vl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vl.Location = New System.Drawing.Point(537, 59)
        Me.vl.Name = "vl"
        Me.vl.Size = New System.Drawing.Size(20, 25)
        Me.vl.TabIndex = 9
        Me.vl.Text = "-"
        '
        'sl
        '
        Me.sl.AutoSize = True
        Me.sl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sl.Location = New System.Drawing.Point(537, 100)
        Me.sl.Name = "sl"
        Me.sl.Size = New System.Drawing.Size(20, 25)
        Me.sl.TabIndex = 10
        Me.sl.Text = "-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(175, 25)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "DATE OF LEAVE:"
        '
        'dateofleave
        '
        Me.dateofleave.Location = New System.Drawing.Point(147, 147)
        Me.dateofleave.Name = "dateofleave"
        Me.dateofleave.Size = New System.Drawing.Size(234, 28)
        Me.dateofleave.TabIndex = 12
        '
        'dateofresume
        '
        Me.dateofresume.Location = New System.Drawing.Point(147, 177)
        Me.dateofresume.Name = "dateofresume"
        Me.dateofresume.Size = New System.Drawing.Size(234, 28)
        Me.dateofresume.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 182)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(194, 25)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "DATE OF RESUME:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 211)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(146, 25)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "NO. OF DAYS:"
        '
        'noofdays
        '
        Me.noofdays.AutoSize = True
        Me.noofdays.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.noofdays.Location = New System.Drawing.Point(104, 212)
        Me.noofdays.Name = "noofdays"
        Me.noofdays.Size = New System.Drawing.Size(20, 25)
        Me.noofdays.TabIndex = 16
        Me.noofdays.Text = "-"
        '
        'formid
        '
        Me.formid.AutoSize = True
        Me.formid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.formid.Location = New System.Drawing.Point(575, 23)
        Me.formid.Name = "formid"
        Me.formid.Size = New System.Drawing.Size(20, 25)
        Me.formid.TabIndex = 18
        Me.formid.Text = "-"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(514, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 25)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "FORM ID:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 257)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(326, 25)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "SPECIFY REASON OF ABSENCE:"
        '
        'reasons
        '
        Me.reasons.Location = New System.Drawing.Point(17, 277)
        Me.reasons.Name = "reasons"
        Me.reasons.Size = New System.Drawing.Size(629, 86)
        Me.reasons.TabIndex = 20
        Me.reasons.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 420)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 45)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'empname
        '
        Me.empname.AutoSize = True
        Me.empname.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empname.Location = New System.Drawing.Point(145, 57)
        Me.empname.Name = "empname"
        Me.empname.Size = New System.Drawing.Size(22, 29)
        Me.empname.TabIndex = 28
        Me.empname.Text = "-"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 377)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 22)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Prepared by:"
        '
        'prepby
        '
        Me.prepby.Location = New System.Drawing.Point(102, 374)
        Me.prepby.Name = "prepby"
        Me.prepby.Size = New System.Drawing.Size(153, 28)
        Me.prepby.TabIndex = 30
        '
        'checkedby
        '
        Me.checkedby.Location = New System.Drawing.Point(373, 374)
        Me.checkedby.Name = "checkedby"
        Me.checkedby.Size = New System.Drawing.Size(153, 28)
        Me.checkedby.TabIndex = 32
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(284, 377)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 22)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Checked by:"
        '
        'empid
        '
        Me.empid.AutoSize = True
        Me.empid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empid.Location = New System.Drawing.Point(145, 79)
        Me.empid.Name = "empid"
        Me.empid.Size = New System.Drawing.Size(20, 25)
        Me.empid.TabIndex = 34
        Me.empid.Text = "-"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 25)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "ID #:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(145, 211)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 25)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "0"
        '
        'typeofleave
        '
        Me.typeofleave.FormattingEnabled = True
        Me.typeofleave.Items.AddRange(New Object() {"SICK LEAVE", "EMERGENCY", "MATERNITY/PATERNITY", "VACATION", "OTHERS"})
        Me.typeofleave.Location = New System.Drawing.Point(521, 147)
        Me.typeofleave.Name = "typeofleave"
        Me.typeofleave.Size = New System.Drawing.Size(208, 30)
        Me.typeofleave.TabIndex = 36
        Me.typeofleave.Text = "Select Type of Leave"
        '
        'leaveform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 480)
        Me.Controls.Add(Me.typeofleave)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.empid)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.checkedby)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.prepby)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.empname)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.reasons)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.formid)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.noofdays)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dateofresume)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dateofleave)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.sl)
        Me.Controls.Add(Me.vl)
        Me.Controls.Add(Me.dept)
        Me.Controls.Add(Me.pos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "leaveform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LEAVE APPLICATION"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pos As System.Windows.Forms.Label
    Friend WithEvents dept As System.Windows.Forms.Label
    Friend WithEvents vl As System.Windows.Forms.Label
    Friend WithEvents sl As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dateofleave As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateofresume As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents noofdays As System.Windows.Forms.Label
    Friend WithEvents formid As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents reasons As System.Windows.Forms.RichTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents empname As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents prepby As System.Windows.Forms.TextBox
    Friend WithEvents checkedby As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents empid As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cachedprintcashcheckdisbursement21 As TagumBuildersSys.Cachedprintcashcheckdisbursement2
    Friend WithEvents typeofleave As System.Windows.Forms.ComboBox
End Class
