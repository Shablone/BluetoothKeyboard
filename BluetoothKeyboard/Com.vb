Module Com
    Dim Port As IO.Ports.SerialPort = Nothing

    Const char_p As Char = "p"
    Const char_r As Char = "r"

    Public Sub ClosePort()
        If Port IsNot Nothing Then
            Try
                Port.Close()

            Catch ex As Exception

            Finally
                Port = Nothing
            End Try
        End If
    End Sub
    Public Sub SelectPort(ByVal str As String)
        ClosePort()

        Try
            Port = My.Computer.Ports.OpenSerialPort(str)
        Catch ex As Exception
            Try
                Port.Close()
            Catch ex2 As Exception

            End Try
            Port = Nothing
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub sendStr(ByVal str As String)
        For Each _char As Char In str
            SendByteRaw(Convert.ToByte(_char), True)
        Next
    End Sub
    Public Sub SendKey(ByVal Keyval As Byte)
        SendByteRaw(Convert.ToByte(char_p), True)
        SendByteRaw(Keyval, True)
        SendByteRaw(Convert.ToByte(char_r), True)
        SendByteRaw(Keyval, True)
    End Sub
    Public Sub SendKey(ByVal Keyval As Byte, ByVal press As Boolean)
        If press Then
            SendByteRaw(Convert.ToByte(char_p), True)
        Else
            SendByteRaw(Convert.ToByte(char_r), True)
        End If
        SendByteRaw(Keyval, True)
    End Sub

    Public Sub SendByteRaw(ByVal databyte As Byte, ByVal do_encrypt As Boolean)
        If Port Is Nothing Then Exit Sub
        Dim databyte_original As Byte = databyte
        Try
            'value 170 and 43 are special characters and need to be re-encrypted (170=special for app=nop, 43 is used by HC-06 and needs to be excluded)
            Dim DoAgain As Boolean = True
            While DoAgain
                If do_encrypt Then databyte = Encrypt(databyte)
                If databyte = 170 Or databyte = 43 Then
                    If do_encrypt Then DoAgain = True Else DoAgain = False
                    Dim databytes_converted As Byte() = BitConverter.GetBytes(170)
                    Port.Write(databytes_converted, 0, 1)
                    Debug.WriteLine(databyte_original & "  " & databyte)
                Else
                    DoAgain = False
                    Dim databytes_converted As Byte() = BitConverter.GetBytes(databyte)
                    Port.Write(databytes_converted, 0, 1)
                    Debug.WriteLine(Chr(databyte_original) & " " & databyte_original & "  " & databyte)
                End If
            End While
        Catch ex As Exception
            ClosePort()
            MsgBox(ex.ToString)
        End Try
    End Sub



End Module
