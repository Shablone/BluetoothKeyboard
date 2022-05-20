Module getSel

    'Reads the control in windows, over which the mouse is hoverhing and gets its textcontent

    Private Declare Function GetWindowThreadProcessId Lib "User32" (ByVal hWnd As IntPtr, ByVal ProcessID As Integer) As Integer
    Private Declare Function GetGUIThreadInfo Lib "User32" (ByVal ThreadID As Integer, ByRef Info As InfoStruct) As Boolean
    Private Declare Function GetForegroundWindow Lib "User32" () As IntPtr
    Private Declare Function SendMessageA Lib "User32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer


    Private Const MOD_ALT As UInteger = 1
    Private Const MOD_CONTROL As UInteger = 2
    Private Const MOD_SHIFT As UInteger = 4
    Private Const VK_b As UInteger = 66
    Private Const EM_GETSEL As Integer = &HB0
    Private Const WM_HOTKEY As Integer = &H312
    Private Const WM_GETTEXT As Integer = &HD
    Private Const WM_GETTEXTLENGTH As Integer = &HE

    Public Function PutTextInClipboard() As String
        Dim ParentHandle As IntPtr = GetForegroundWindow
        If ParentHandle <> IntPtr.Zero Then
            Dim RightControl As IntPtr = SelectTheRightControl(ParentHandle)
            If Not RightControl = IntPtr.Zero Then
                Dim S As Selection = GetSelection(RightControl)
                If S.End <> S.Start Then
                    Return (GetTheText(RightControl, S))
                End If
            End If
        End If
        Return ""
    End Function

    Private Function SelectTheRightControl(ByVal hWnd As IntPtr) As IntPtr
        Dim ThreadID As Integer = GetWindowThreadProcessId(hWnd, Nothing)
        Dim InfoStructure As New InfoStruct
        Dim i As Integer = IntPtr.Size
        InfoStructure.cbSize = 24 + 6 * i
        If GetGUIThreadInfo(ThreadID, InfoStructure) Then
            Return InfoStructure.Caret
        End If
    End Function

    Private Function GetTheText(ByVal hWnd As IntPtr, ByVal Sel As Selection) As String
        Dim TxtLength As Integer = SendMessageA(hWnd, WM_GETTEXTLENGTH, Nothing, Nothing)
        Dim Ptr As IntPtr = Runtime.InteropServices.Marshal.AllocHGlobal(TxtLength + 1)
        Dim LengthCopied As Integer = SendMessageA(hWnd, WM_GETTEXT, CType(TxtLength + 1, IntPtr), Ptr)
        Dim ByteTxt(LengthCopied) As Byte
        Runtime.InteropServices.Marshal.Copy(Ptr, ByteTxt, 0, LengthCopied)
        Runtime.InteropServices.Marshal.FreeHGlobal(Ptr)
        Dim Txt As String = New String(ByteTxt.Select(Function(b) Chr(b)).ToArray)
        Return Txt.Substring(Sel.Start, Sel.End - Sel.Start)
    End Function

    Private Function GetSelection(ByVal hWnd As IntPtr) As Selection
        Dim Result As Integer = SendMessageA(hWnd, EM_GETSEL, Nothing, Nothing)
        Dim Sel As New Selection
        Sel.Start = Result And &HFFFF
        Sel.End = Result >> 16
        Return Sel
    End Function

    Private Structure Selection
        Public Start As Integer
        Public [End] As Integer
    End Structure

    Private Structure InfoStruct
        Public cbSize As Integer
        Public flag As Integer
        Public Active As IntPtr
        Public Focus As IntPtr
        Public Capture As IntPtr
        Public Menu As IntPtr
        Public Move As IntPtr
        Public Caret As IntPtr
        Public CaretRect As Rectangle
    End Structure
End Module
