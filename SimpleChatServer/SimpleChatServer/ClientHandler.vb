Imports System.Net.Sockets

Public Class ClientHandler
    Dim clientSocket As TcpClient
    Dim clientID As String

    Public Sub New(ByVal clientSocket As TcpClient, ByVal clientID As String)
        Me.clientID = clientID
        Me.clientSocket = clientSocket
        Dim thread As Threading.Thread = New Threading.Thread(AddressOf chatThread)
        thread.Start()
    End Sub

    Private Sub chatThread()
        Dim requestCount As Integer = 0
        Dim dataReceived As String

        While (True)
            Try
                requestCount = requestCount + 1
                Dim networkStream As NetworkStream = clientSocket.GetStream()
                Dim inStream(clientSocket.ReceiveBufferSize) As Byte
                networkStream.Read(inStream, 0, inStream.Length)
                dataReceived = System.Text.Encoding.ASCII.GetString(inStream)
                dataReceived = dataReceived.Substring(0, dataReceived.IndexOf("$"))
                MessageReceiver("Client " + clientID + ": " + dataReceived)

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End While
    End Sub
End Class
