Public Class Form1

    Dim dtTrigger As Date = DateAdd(DateInterval.Second, 180, Now)

    Private Sub StartLaunch()        
        Me.BackColor = Color.Red
        My.Computer.Audio.Play("rocket.wav")
        Fog(True)
        Lights(True)
    End Sub

    Private Sub StopLaunch()
        Me.BackColor = Color.Black
        My.Computer.Audio.Stop()
        Fog(False)
        Lights(False)
    End Sub

    Private Sub Fog(enable As Boolean)
        logStatus("Fog " & IIf(enable, "ON", "OFF"))
        If enable Then
            Shell("relay.exe BITFT open 2", AppWinStyle.Hide, True)
        Else
            Shell("relay.exe BITFT close 2", AppWinStyle.Hide, True)
        End If

     
    End Sub

    Private Sub Lights(enable As Boolean)
        logStatus("Flame " & IIf(enable, "ON", "OFF"))
        If enable Then
            Shell("relay.exe BITFT open 1", AppWinStyle.Hide, True)
        Else
            Shell("relay.exe BITFT close 1", AppWinStyle.Hide, True)
        End If

    End Sub


    Private Sub logStatus(status As String)
        Me.lbStatus.Items.Add(Format(Now, "HH:mm:ss") & " - " & status)
        Me.lbStatus.SelectedIndex = Me.lbStatus.Items.Count - 1
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim secondsUntilLaunch As Long = (Now - dtTrigger).TotalSeconds
        Static lastSeconds As Long
        If secondsUntilLaunch <> lastSeconds Then
            lastSeconds = secondsUntilLaunch


            Dim minutes As Long = 0
            Dim seconds As Long = 0

            If secondsUntilLaunch < 60 Then
                minutes = Math.Floor(Math.Abs(secondsUntilLaunch) / 60)
                seconds = Math.Abs(secondsUntilLaunch) - (minutes * 60)
            Else
                seconds = Math.Abs(secondsUntilLaunch)
            End If

            If minutes > 0 Then
                Me.Label1.Text = minutes & ":" & Format(seconds, "00")
            Else
                Me.Label1.Text = seconds
            End If

            If secondsUntilLaunch < -10 And (secondsUntilLaunch Mod 30) = -5 And cbEnableFuelVent.Checked Then
                logStatus("Vent Fuel")
                Fog(True)
                System.Threading.Thread.Sleep(250)
                Fog(False)
            End If

            If secondsUntilLaunch >= 0 Then
                'we're launching!
                Me.Label1.Text = "+" & Math.Abs(secondsUntilLaunch)

                Select Case secondsUntilLaunch
                    Case 0
                        logStatus("Auto Initiate Launch")
                        StartLaunch()
                    Case 5
                        logStatus("Auto Stop Fog")
                        Fog(False)
                    Case 20
                        logStatus("Auto Shutdown Launch")
                        dtTrigger = DateAdd(DateInterval.Second, Me.nudLaunchTime.Value, Now)
                        StopLaunch()
                End Select

            End If
        End If



    End Sub

    Private Sub btnSpeedUp_Click(sender As Object, e As EventArgs) Handles btnLaunchIn10.Click
        logStatus("Clock set to T-10")
        dtTrigger = DateAdd("s", 10, Now)
    End Sub

    Private Sub btn1Second_Click(sender As Object, e As EventArgs) Handles btn1Second.Click
        logStatus("Clock set to T-0")
        dtTrigger = DateAdd("s", 0, Now)
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If Me.btnPause.Text = "PAUSE" Then
            PauseResumeCountdown(True)
        Else
            PauseResumeCountdown(False)
        End If
    End Sub

    Private Sub btnResetCountdown_Click(sender As Object, e As EventArgs) Handles btnResetCountdown.Click
        dtTrigger = DateAdd(DateInterval.Minute, 3, Now)
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        logStatus("E-Stop")
        StopLaunch()
        dtTrigger = DateAdd(DateInterval.Second, Me.nudLaunchTime.Value, Now)
        PauseResumeCountdown(True)
        Me.Label1.ForeColor = Color.Red
        Me.Label1.Text = "-"
    End Sub

    Private Sub PauseResumeCountdown(pause As Boolean)
        If pause Then
            logStatus("Launch Paused")
            Me.Label1.ForeColor = Color.Yellow
            Me.btnPause.BackColor = Color.Green
            Me.Timer1.Enabled = False
            Me.btnPause.Text = "Resume"
        Else
            logStatus("Launch Resumed")
            Me.Label1.ForeColor = Color.White
            Me.Timer1.Enabled = True
            Me.btnPause.BackColor = Color.Yellow
            Me.btnPause.Text = "PAUSE"
        End If
    End Sub

    Private Sub lbStatus_DoubleClick(sender As Object, e As EventArgs) Handles lbStatus.DoubleClick
        Me.lbStatus.Items.Clear()
    End Sub

    Private Sub lbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbStatus.SelectedIndexChanged

    End Sub

    Private Sub tmrBlink_Tick(sender As Object, e As EventArgs) Handles tmrBlink.Tick

        Static oddEven As Boolean = False
        oddEven = Not oddEven

        If Me.Label1.ForeColor = Color.Yellow Then
            If oddEven Then
                Me.btnPause.BackColor = Color.DarkGreen
            Else
                Me.btnPause.BackColor = Color.Green
            End If
        ElseIf Me.Label1.ForeColor = Color.Red Then
            If oddEven Then
                Me.btnPause.BackColor = Color.DarkGreen
                Me.btnStop.BackColor = Color.DarkRed
            Else
                Me.btnPause.BackColor = Color.Green
                Me.btnStop.BackColor = Color.Red
            End If
        Else
            Me.btnPause.BackColor = Color.Yellow
            Me.btnStop.BackColor = Color.Red
        End If




    End Sub
End Class
