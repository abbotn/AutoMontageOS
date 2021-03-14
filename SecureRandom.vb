Imports System.Security.Cryptography
Public Class SecureRandom
    Inherits RandomNumberGenerator

    Private ReadOnly rng As RandomNumberGenerator = New RNGCryptoServiceProvider()

    Public Function [Next]() As Integer
        Dim data = New Byte(3) {}
        rng.GetBytes(data)
        Return BitConverter.ToInt32(data, 0) And (Integer.MaxValue - 1)
    End Function

    Public Function [Next](ByVal maxValue As Integer) As Integer
        Return [Next](0, maxValue)
    End Function

    Public Function [Next](ByVal minValue As Integer, ByVal maxValue As Integer) As Integer
        If minValue > maxValue Then
            Throw New ArgumentOutOfRangeException()
        End If

        Return CInt(Math.Floor((minValue + (CDbl(maxValue) - minValue) * NextDouble())))
    End Function

    Public Function NextDouble() As Double
        Dim data = New Byte(3) {}
        rng.GetBytes(data)
        Dim randUint = BitConverter.ToUInt32(data, 0)
        Return randUint / (UInteger.MaxValue + 1.0)
    End Function

    Public Overrides Sub GetBytes(ByVal data As Byte())
        rng.GetBytes(data)
    End Sub

    Public Overrides Sub GetNonZeroBytes(ByVal data As Byte())
        rng.GetNonZeroBytes(data)
    End Sub
End Class
