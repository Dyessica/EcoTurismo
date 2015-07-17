Imports MySql.Data.MySqlClient
Public Class login
    Dim connectionString As String = "server=localhost;user id=root;password =vertrigo;database=tupinamba"
    Dim usu, sen As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim queryString As String = "SELECT * FROM Senha"
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            connection.Open()
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Try
                If reader.HasRows Then

                    While reader.Read()

                        usu = reader.Item("SUsu")
                        sen = reader.Item("SSen")

                    End While
                Else
                    MessageBox.Show("Nada encontrado")
                End If
            Finally
                connection.Close()
                reader.Close()
            End Try
        End Using

        If TextBox1.Text = usu And TextBox2.Text = sen Then
            Me.Hide()
            home.Show()
            TextBox1.Select()
            TextBox1.Clear()
            TextBox2.Clear()
        Else
            MessageBox.Show("Usuário e/ou senha incorretos!")
        End If
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        NewLogin.Show()
    End Sub
End Class
