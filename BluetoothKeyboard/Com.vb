Module Com
    Dim Port As IO.Ports.SerialPort = Nothing

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

    Public Sub SendKey(ByVal i As Byte, ByVal press As Boolean)
        If Port Is Nothing Then Exit Sub
        Const char_p As Char = "p"
        Const char_r As Char = "r"
        Try
            If press Then
                sendbyte_raw(Convert.ToByte(char_p), True)
            Else
                sendbyte_raw(Convert.ToByte(char_r), True)
            End If
            sendbyte_raw(i, True)
        Catch ex As Exception
            ClosePort()
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub sendbyte_raw(ByVal i As Byte, ByVal do_encrypt As Boolean)
        If Port Is Nothing Then Exit Sub
        Dim i_original As Byte = i
        Try
            '170 und 43 sind Funktionschars und müssen neu generiert werden
            Dim wiederholen As Boolean = True
            While wiederholen
                If do_encrypt Then i = Encrypt(i)
                If i = 170 Or i = 43 Then
                    If do_encrypt Then wiederholen = True Else wiederholen = False
                    Dim databyte As Byte() = BitConverter.GetBytes(170)
                    Port.Write(databyte, 0, 1)
                    Debug.WriteLine(i_original & "  " & i)
                Else
                    wiederholen = False
                    Dim databyte As Byte() = BitConverter.GetBytes(i)
                    Port.Write(databyte, 0, 1)
                    Debug.WriteLine(i_original & "  " & i)
                End If
            End While
        Catch ex As Exception
            ClosePort()
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub sendStr(ByVal str As String)
        If Port Is Nothing Then Exit Sub
        Try
            For Each zeichen As Char In str
                sendbyte_raw(Convert.ToByte(zeichen), True)
            Next
        Catch ex As Exception
            ClosePort()
            MsgBox(ex.ToString)
        End Try

    End Sub


End Module
