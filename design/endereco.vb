Imports MySql.Data.MySqlClient

Public Class endereco
    Dim connectionString As String = "server=localhost;user id=root;password =vertrigo;database=tupinamba"
    Private Sub endereco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        codigo()
    End Sub
    Public Sub codigo()
        Dim qS As String = "select ResCod from residencia"
        Using cn As New MySqlConnection(connectionString)
            Dim cm As New MySqlCommand(qS, cn)
            cn.Open()
            Dim reader As MySqlDataReader = cm.ExecuteReader()

            Try
                If reader.HasRows Then

                    While reader.Read()

                        TextBox1.Text = reader("ResCod") + 1
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
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
            MessageBox.Show("Preencha todos os campos!")
        ElseIf Not IsNumeric(TextBox1.Text) Or Not IsNumeric(TextBox8.Text) Then
            MessageBox.Show("Preencha os campos corretamente!")
        Else

            Dim queryString As String = "insert into residencia(ResCod,ResNumero,ResRua,ResCompl,ResBairro,ResCidade,ResEstado,ResCEP) values (@ResCod,@ResNumero,@ResRua,@ResCompl,@ResBairro,@ResCidade,@ResEstado,@ResCEP)"
            Using connection As New MySqlConnection(connectionString)
                Dim command As New MySqlCommand(queryString, connection)
                Try
                    command.Parameters.AddWithValue("@ResCod", TextBox1.Text)
                    command.Parameters.AddWithValue("@ResNumero", TextBox2.Text)
                    command.Parameters.AddWithValue("@ResRua", TextBox3.Text)
                    command.Parameters.AddWithValue("@ResCompl", TextBox4.Text)
                    command.Parameters.AddWithValue("@ResBairro", TextBox5.Text)
                    command.Parameters.AddWithValue("@ResCidade", TextBox6.Text)
                    command.Parameters.AddWithValue("@ResEstado", TextBox7.Text)
                    command.Parameters.AddWithValue("@ResCEP", TextBox8.Text)




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