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
            Dim Str As String = txtInput.Text '.Substring(0, txtInput.Text.Length)
            If Not e.Shift Then
                txtInput.Text = ""
            End If
            If chkAscii.Checked Then
                sendAscii(Str)
            Else
                Com.sendStr("S" & Str & Chr(1))
            End If


        End If
    End Sub

    Private Sub sendAscii(ByVal Str As String)
        Const char_p As Char = "p"
        Const char_r As Char = "r"
        Dim unicode As System.Text.UnicodeEncoding = New System.Text.UnicodeEncoding()

        For Each c As Char In Str
            Com.SendByteRaw(Convert.ToByte(char_p), True) 'press Alt
            Com.SendByteRaw(130, True)
            Com.SendKey(234)    'Num 0
            Dim charVal As Integer = Asc(c)
            Dim charValStr As String = charVal.ToString()
            For Each dec_c In charValStr
                Select Case dec_c
                    Case "1"
                        Com.SendKey(225)
                    Case "2"
                        Com.SendKey(226)
                    Case "3"
                        Com.SendKey(227)
                    Case "4"
                        Com.SendKey(228)
                    Case "5"
                        Com.SendKey(229)
                    Case "6"
                        Com.SendKey(230)
                    Case "7"
                        Com.SendKey(231)
                    Case "8"
                        Com.SendKey(232)
                    Case "9"
                        Com.SendKey(233)
                    Case "0"
                        Com.SendKey(234)
                End Select
            Next
            Com.SendByteRaw(Convert.ToByte(char_r), True) 'release Alt
            Com.SendByteRaw(130, True)
        Next
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

End Class