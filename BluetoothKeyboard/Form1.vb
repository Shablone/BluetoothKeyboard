Public Class Form1

    Private Declare Function GetAsyncKeyState Lib "user32" Alias "GetAsyncKeyState" (ByVal vKey As Keys) As Int16
    Private WithEvents kbHook As New KeyboardHook
    Private WithEvents KeyHandling As New KeyHandling

    'Com Ports
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Com Ports anzeigen
        LstCom.Items.AddRange(My.Computer.Ports.SerialPortNames.ToArray)


        Dim cm As New ContextMenu
        txtInput.ContextMenu = cm
        ReadConfig()

    End Sub

    Private Sub LstCom_SelectedValueChanged(sender As Object, e As EventArgs) Handles LstCom.SelectedValueChanged
        If LstCom.SelectedIndex = -1 Then Exit Sub
        Com.SelectPort(LstCom.SelectedItem)
        SaveConfig()
        txtInput.Select()
    End Sub

    'save/load selected Com Port
    Private Sub ReadConfig()
        Try
            If LstCom.Items.Count = 0 Then Exit Sub
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\config.ini") Then
                Dim port As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\config.ini")
                For x As Integer = 0 To LstCom.Items.Count - 1
                    If LstCom.Items(x) = port Then LstCom.SetSelected(x, True)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveConfig()
        Try
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\config.ini", LstCom.SelectedItem, False)
        Catch ex As Exception

        End Try
    End Sub



    'Hooken
    Private Sub RStrg() Handles kbHook.RStrg
        toggleActivation()
    End Sub

    Private InputAktiv As Boolean = False
    Private Sub toggleActivation()
        InputAktiv = Not InputAktiv
        kbHook.Activated = InputAktiv
        TimerMouse.Enabled = InputAktiv
        If InputAktiv Then
            Me.BringToFront()
            Me.Activate()
            txtInput.Focus()
            LabelStatus.Text = "Live-Mode activated"
            LabelStatus.Font = New Font(LabelStatus.Font, FontStyle.Bold Or FontStyle.Underline)
        Else
            LabelStatus.Text = "Live-Mode deactivated"
            LabelStatus.Font = New Font(LabelStatus.Font, FontStyle.Regular Or FontStyle.Underline)
        End If
    End Sub




    'send txtbox on Enter
    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles txtInput.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim Str As String = txtInput.Text.Substring(0, txtInput.Text.Length)
            If Not e.Shift Then
                txtInput.Text = ""
            End If
            Com.sendStr("S" & Str & Chr(1))
        End If
    End Sub

    'send mouseclicks
    Private Sub TextBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles txtInput.MouseDown
        If InputAktiv Then
            Select Case e.Button
                Case MouseButtons.Left
                    Com.sendStr("Ml")
                Case MouseButtons.Middle
                    Com.sendStr("Mm")
                Case MouseButtons.Right
                    Com.sendStr("Mr")
            End Select
        End If
    End Sub

    Private Sub TextBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles txtInput.MouseUp
        If InputAktiv Then
            Select Case e.Button
                Case MouseButtons.Left
                    Com.sendStr("ML")
                Case MouseButtons.Middle
                    Com.sendStr("MM")
                Case MouseButtons.Right
                    Com.sendStr("MR")
            End Select
        End If
    End Sub

    'handle mouse movements
    Dim pos As Point
    Private Sub TimerMouse_Tick(sender As Object, e As EventArgs) Handles TimerMouse.Tick
        Dim diff As Point = Cursor.Position - pos
        If diff.X <> 0 Or diff.Y <> 0 Then
            Cursor.Position = pos
            Com.sendStr("MX" & diff.X & "Y" & diff.Y & "M")
        End If
    End Sub

    Private Sub Form1_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        pos = PointToScreen(txtInput.Location)
        pos.X += txtInput.Width / 2
        pos.Y += txtInput.Height / 2
    End Sub

    'send keys on live mode
    Private Sub kbHook_KeyDown(ByVal Key As System.Windows.Forms.Keys) Handles kbHook.KeyDown
        Com.SendKey(KeyHandling.keyTrans(Key), True)
        txtInfo.AppendText(Key.ToString & vbCrLf)
    End Sub
    Private Sub kbHook_KeyUp(ByVal Key As System.Windows.Forms.Keys) Handles kbHook.KeyUp
        Com.SendKey(KeyHandling.keyTrans(Key), False)
    End Sub
    Private Sub NichtUnterstützt(ByVal key As Keys)
        txtInfo.AppendText("Zeichen nicht unterstützt:" & key & vbCrLf)
    End Sub

    'send control handle text from attribute
    Private Sub RAlt() Handles kbHook.RAlt
        Dim Str As String = getSel.PutTextInClipboard
        Com.sendStr("S" & Str & Chr(1))
    End Sub


    'testing
    Private Sub test_Click(sender As Object, e As EventArgs) Handles test.Click
        Const char_p As Char = "p"
        Const char_r As Char = "r"
        Com.sendbyte_raw(Convert.ToByte(char_p), True)
        Com.sendbyte_raw(130, True)

        Com.sendbyte_raw(Convert.ToByte(char_p), True)
        Com.sendbyte_raw(81, True)
        Com.sendbyte_raw(Convert.ToByte(char_r), True)
        Com.sendbyte_raw(81, True)


        Com.sendbyte_raw(Convert.ToByte(char_r), True)
        Com.sendbyte_raw(130, True)
    End Sub

    Private Sub test2_Click(sender As Object, e As EventArgs) Handles test2.Click
        Com.sendbyte_raw(170, False)
        Com.sendbyte_raw(170, False)
        Com.sendbyte_raw(170, False)
        Com.sendbyte_raw(170, False)
        Com.sendbyte_raw(170, False)
        Com.sendbyte_raw(170, False)
        Com.sendbyte_raw(170, False)
        Com.sendbyte_raw(170, False)
        Com.sendbyte_raw(170, False)
        Com.sendbyte_raw(170, False)
        Com.sendbyte_raw(0, False)
        Com.sendbyte_raw(0, False)
        Com.sendbyte_raw(0, False)
        Com.sendbyte_raw(0, False)
        Com.sendbyte_raw(0, False)
        Com.sendbyte_raw(0, False)
        Com.sendbyte_raw(0, False)
        Com.sendbyte_raw(0, False)
        Com.sendbyte_raw(0, False)
        Com.sendbyte_raw(0, False)
    End Sub

End Class
