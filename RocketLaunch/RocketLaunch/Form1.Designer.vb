<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLaunchIn10 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbEnableFuelVent = New System.Windows.Forms.CheckBox()
        Me.lbStatus = New System.Windows.Forms.ListBox()
        Me.nudLaunchTime = New System.Windows.Forms.NumericUpDown()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnResetCountdown = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btn1Second = New System.Windows.Forms.Button()
        Me.tmrBlink = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.nudLaunchTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Courier New", 300.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(2204, 717)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLaunchIn10
        '
        Me.btnLaunchIn10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLaunchIn10.Location = New System.Drawing.Point(4, 12)
        Me.btnLaunchIn10.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnLaunchIn10.Name = "btnLaunchIn10"
        Me.btnLaunchIn10.Size = New System.Drawing.Size(126, 89)
        Me.btnLaunchIn10.TabIndex = 1
        Me.btnLaunchIn10.Text = "T-10"
        Me.btnLaunchIn10.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.cbEnableFuelVent)
        Me.Panel1.Controls.Add(Me.lbStatus)
        Me.Panel1.Controls.Add(Me.nudLaunchTime)
        Me.Panel1.Controls.Add(Me.btnStop)
        Me.Panel1.Controls.Add(Me.btnResetCountdown)
        Me.Panel1.Controls.Add(Me.btnPause)
        Me.Panel1.Controls.Add(Me.btn1Second)
        Me.Panel1.Controls.Add(Me.btnLaunchIn10)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 717)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(2204, 106)
        Me.Panel1.TabIndex = 2
        '
        'cbEnableFuelVent
        '
        Me.cbEnableFuelVent.AutoSize = True
        Me.cbEnableFuelVent.Location = New System.Drawing.Point(1017, 14)
        Me.cbEnableFuelVent.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbEnableFuelVent.Name = "cbEnableFuelVent"
        Me.cbEnableFuelVent.Size = New System.Drawing.Size(104, 24)
        Me.cbEnableFuelVent.TabIndex = 8
        Me.cbEnableFuelVent.Text = "Vent Fuel"
        Me.cbEnableFuelVent.UseVisualStyleBackColor = True
        '
        'lbStatus
        '
        Me.lbStatus.BackColor = System.Drawing.Color.Black
        Me.lbStatus.ForeColor = System.Drawing.Color.Lime
        Me.lbStatus.FormattingEnabled = True
        Me.lbStatus.ItemHeight = 20
        Me.lbStatus.Location = New System.Drawing.Point(462, 12)
        Me.lbStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(544, 84)
        Me.lbStatus.TabIndex = 7
        '
        'nudLaunchTime
        '
        Me.nudLaunchTime.Location = New System.Drawing.Point(274, 12)
        Me.nudLaunchTime.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudLaunchTime.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.nudLaunchTime.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudLaunchTime.Name = "nudLaunchTime"
        Me.nudLaunchTime.Size = New System.Drawing.Size(178, 26)
        Me.nudLaunchTime.TabIndex = 6
        Me.nudLaunchTime.Value = New Decimal(New Integer() {180, 0, 0, 0})
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.BackColor = System.Drawing.Color.Red
        Me.btnStop.Location = New System.Drawing.Point(1792, 12)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(406, 89)
        Me.btnStop.TabIndex = 5
        Me.btnStop.Text = "E-Stop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnResetCountdown
        '
        Me.btnResetCountdown.Location = New System.Drawing.Point(274, 52)
        Me.btnResetCountdown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnResetCountdown.Name = "btnResetCountdown"
        Me.btnResetCountdown.Size = New System.Drawing.Size(178, 49)
        Me.btnResetCountdown.TabIndex = 4
        Me.btnResetCountdown.Text = "Reset Countdown"
        Me.btnResetCountdown.UseVisualStyleBackColor = True
        '
        'btnPause
        '
        Me.btnPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPause.BackColor = System.Drawing.Color.Yellow
        Me.btnPause.Location = New System.Drawing.Point(1658, 12)
        Me.btnPause.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(126, 89)
        Me.btnPause.TabIndex = 3
        Me.btnPause.Text = "PAUSE"
        Me.btnPause.UseVisualStyleBackColor = False
        '
        'btn1Second
        '
        Me.btn1Second.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn1Second.Location = New System.Drawing.Point(140, 12)
        Me.btn1Second.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn1Second.Name = "btn1Second"
        Me.btn1Second.Size = New System.Drawing.Size(126, 89)
        Me.btn1Second.TabIndex = 2
        Me.btn1Second.Text = "T-0"
        Me.btn1Second.UseVisualStyleBackColor = False
        '
        'tmrBlink
        '
        Me.tmrBlink.Enabled = True
        Me.tmrBlink.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(2204, 823)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form1"
        Me.Text = "ACOB Rocket"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudLaunchTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLaunchIn10 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn1Second As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents btnResetCountdown As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents nudLaunchTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbStatus As System.Windows.Forms.ListBox
    Friend WithEvents cbEnableFuelVent As System.Windows.Forms.CheckBox
    Friend WithEvents tmrBlink As System.Windows.Forms.Timer

End Class
