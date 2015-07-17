Imports MySql.Data.MySqlClient

Public Class telefone
    Dim connectionString As String = "server=localhost;user id=root;password =vertrigo;database=tupinamba"
    Private Sub telefone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        codigo()
    End Sub
    Private Sub codigo()
        Dim qS As String = "select TelCod from telefone"
        Using cn As New MySqlConnection(connectionString)
            Dim cm As New MySqlCommand(qS, cn)
            cn.Open()
            Dim reader As MySqlDataReader = cm.ExecuteReader()

            Try
                If reader.HasRows Then

                    While reader.Read()

                        TextBox1.Text = reader("TelCod") + 1
                    End While
                Else
                    TextBox1.Text = 1
                End If
            Finally

                reader.Close()
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Preencha todos os campos!")
        ElseIf Not IsNumeric(TextBox1.Text) Or Not IsNumeric(TextBox2.Text) Or Not IsNumeric(TextBox3.Text) Or Not IsNumeric(TextBox4.Text) Then
            MessageBox.Show("Preencha somente números!")
        Else
            Dim queryString As String = "insert into telefone(TelCod,TelCel,TelResi,TelComercial) values (@TelCod,@TelCel,@TelResi,@TelComercial)"
            Using connection As New MySqlConnection(connectionString)
                Dim command As New MySqlCommand(queryString, connection)
                Try
                    command.Parameters.AddWithValue("@TelCod", TextBox1.Text)
                    command.Parameters.AddWithValue("@TelCel", TextBox2.Text)
                    command.Parameters.AddWithValue("@TelResi", TextBox3.Text)
                    command.Parameters.AddWithValue("@TelComercial", TextBox4.Text)





                    connection.Open()
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Atenção!")
                Finally
                    connection.Close()
                End Try

                Me.Close()
            End Using
        End If
    End Sub
End Class