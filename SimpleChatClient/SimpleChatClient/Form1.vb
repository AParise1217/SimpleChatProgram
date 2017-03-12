Imports System.Net.Sockets

Public Class Form1
    Dim clientSocket As System.Net.Sockets.TcpClient

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clientSocket = New TcpClient()
        clientSocket.Connect(New Net.IPEndPoint(New Net.IPAddress({127, 0, 0, 1}), 8888))
        Label_connStatus.Text = "Connected"
    End Sub

    Private Sub sendMessage(ByVal message As String)
        Dim serverStream As NetworkStream = clientSocket.GetStream
        Dim outputStream As Byte() = System.Text.Encoding.ASCII.GetBytes(message + "$")
        serverStream.Write(outputStream, 0, outputStream.Length)
        serverStream.Flush()
    End Sub

    Private Sub Button_sendMessage_Click(sender As Object, e As EventArgs) Handles Button_sendMessage.Click
        If (TextBox1.Text IsNot "") Then
            sendMessage(TextBox1.Text)
        End If
        TextBox1.Text = ""
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
