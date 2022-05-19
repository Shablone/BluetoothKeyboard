Module Encryption

    Private Schlüssel(,) As Integer =
        {{136, 16, 158, 235, 11, 193, 182, 89, 207, 224},
{13, 46, 233, 193, 178, 164, 5, 208, 49, 65},
{84, 59, 62, 229, 192, 38, 178, 188, 189, 234},
{2, 8, 195, 233, 127, 4, 80, 189, 96, 62},
{113, 76, 111, 67, 42, 61, 75, 67, 103, 32},
{196, 143, 93, 222, 39, 93, 36, 182, 192, 9},
{166, 172, 139, 0, 235, 34, 249, 123, 166, 124},
{127, 214, 34, 118, 43, 164, 213, 121, 104, 241},
{54, 118, 218, 84, 157, 236, 216, 5, 222, 95},
{251, 92, 33, 178, 63, 100, 43, 100, 118, 201}}

    Private Index() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}


    '170 und 43 sind Funktionschars und müssen neu generiert werden
    Public Function Encrypt(ByVal val As Integer) As Integer
        For x = 0 To Index.Length - 1
            val = val Xor Schlüssel(x, Index(x))
        Next
        'Debug.WriteLine(val)
        CountUp()
        Return val
    End Function

    Private Sub CountUp()
        Index(0) += 1
        For x = 0 To Index.Length - 1 - 1
            If Index(x) = Schlüssel.GetLength(1) Then
                Index(x) = 0
                Index(x + 1) += 1
            End If
        Next
        If Index(Index.Length - 1) = Schlüssel.GetLength(1) Then
            Index(Index.Length - 1) = 0
        End If
    End Sub




End Module
