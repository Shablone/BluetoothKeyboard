Public Class KeyHandling
    'Arduino uses other key values then the windows key dict


    Private KeyDic As New Dictionary(Of Keys, Byte)

    Public Shared Event NotSupported(ByVal key As Keys)

    Public Sub New()
        iniKeyDic()
    End Sub

    Private Sub iniKeyDic()

        KeyDic.Add(Keys.LControlKey, 128)
        KeyDic.Add(Keys.ControlKey, 128)
        KeyDic.Add(Keys.ShiftKey, 129)
        KeyDic.Add(Keys.LShiftKey, 129)
        KeyDic.Add(Keys.Alt, 130)
        KeyDic.Add(Keys.LMenu, 130)
        KeyDic.Add(Keys.Menu, 130)
        KeyDic.Add(Keys.RControlKey, 134)
        KeyDic.Add(Keys.RShiftKey, 133)
        KeyDic.Add(Keys.Up, 218)
        KeyDic.Add(Keys.Down, 217)
        KeyDic.Add(Keys.Right, 215)
        KeyDic.Add(Keys.Left, 216)
        KeyDic.Add(Keys.Tab, 179)
        KeyDic.Add(Keys.Back, 178)
        KeyDic.Add(Keys.Return, 176)
        KeyDic.Add(Keys.Escape, 177)
        KeyDic.Add(Keys.Insert, 209)
        KeyDic.Add(Keys.Delete, 212)
        KeyDic.Add(Keys.PageUp, 211)
        KeyDic.Add(Keys.PageDown, 214)
        KeyDic.Add(Keys.Home, 210)
        KeyDic.Add(Keys.End, 213)
        KeyDic.Add(Keys.F1, 194)
        KeyDic.Add(Keys.F2, 195)
        KeyDic.Add(Keys.F3, 196)
        KeyDic.Add(Keys.F4, 197)
        KeyDic.Add(Keys.F5, 198)
        KeyDic.Add(Keys.F6, 199)
        KeyDic.Add(Keys.F7, 200)
        KeyDic.Add(Keys.F8, 201)
        KeyDic.Add(Keys.F9, 202)
        KeyDic.Add(Keys.F10, 203)
        KeyDic.Add(Keys.F11, 204)
        KeyDic.Add(Keys.F12, 205)
    End Sub

    Public Function keyTrans(ByVal key As Byte) As Byte
        Debug.WriteLine("key:         " & key)
        If KeyDic.ContainsKey(key) Then
            Return KeyDic(key)
        ElseIf key >= Keys.D0 And key <= Keys.D9 Then
            Return key
        ElseIf key >= Keys.NumPad0 And key <= Keys.F12 Then
            Return key
        ElseIf key >= Keys.Oem1 And key <= Keys.Oem102 Then
            Return key
        ElseIf key = Keys.Space Then
            Return key
        ElseIf key >= Keys.A And key <= Keys.Z Then
            Return key + 32
        Else
            RaiseEvent NotSupported(key)
            Return 0

        End If
    End Function
End Class
