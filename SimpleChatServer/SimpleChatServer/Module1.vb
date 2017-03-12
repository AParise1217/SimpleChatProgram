Imports System.Net.Sockets

Module Module1

    Sub Main()
        Dim serverSocket As New TcpListener(New Net.IPEndPoint(New Net.IPAddress({127, 0, 0, 1}), 8888))
        Dim clientSocket As TcpClient
        Dim counter As Integer = 0

        serverSocket.Start()
        MessageReceiver("Starting Server...")

        While (True)
            counter = counter + 1
            clientSocket = serverSocket.AcceptTcpClient()
            MessageReceiver("Client ID: " & counter & " has connected.")
            ''
            Dim client As New ClientHandler(clientSocket, counter)
        End While
        If (clientSocket IsNot Nothing) Then
            clientSocket.Close()
        End If
        serverSocket.Stop()
        MessageReceiver("Exiting Server...")
        Console.ReadLine()
    End Sub

    Sub MessageReceiver(ByVal message As String)
        message = message.Trim()
        Console.WriteLine(" >> " & message)
    End Sub



End Module
