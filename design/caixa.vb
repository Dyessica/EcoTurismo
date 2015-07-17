Imports MySql.Data.MySqlClient


Public Class caixa
    Dim connectionString As String = "server=localhost;user id=root;password =vertrigo;database=tupinamba"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        home.Show()
        codigofc()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Preencha todos os campos!")
        ElseIf Not IsNumeric(TextBox1.Text) Or Not IsNumeric(TextBox2.Text) Or Not IsNumeric(TextBox3.Text) Or Not IsDate(TextBox4.Text) Then
            MessageBox.Show("Preencha os campos de forma correta!")
        Else
            Try

                If MessageBox.Show("Confirma os dados?", "Permissão para salvar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                    Dim queryString As String = "insert into FluxoCaixa(FluCod,FluGanho,FluGasto,FluData) values (@FluCod,@FluGanho,@FluGasto,@FluData)"
                    Using connection As New MySqlConnection(connectionString)
                        Dim command As New MySqlCommand(queryString, connection)
                        Try
                            command.Parameters.AddWithValue("@Flucod", TextBox1.Text)
                            command.Parameters.AddWithValue("@FluGanho", TextBox2.Text)
                            command.Parameters.AddWithValue("@FluGasto", TextBox3.Text)
                            command.Parameters.AddWithValue("@FluData", TextBox4.Text)



                            connection.Open()
                            command.ExecuteNonQuery()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Atenção!")
                        Finally
                            connection.Close()
                        End Try

                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                    End Using

                    MessageBox.Show("Salvo com sucesso")


                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro ao salvar")
           
            End Try


        End If
    End Sub


    Private Sub caixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        codigofc()
    End Sub
    Public Sub codigofc()
        Dim qS As String = "select FluCod from FluxoCaixa"
        Using cn As New MySqlConnection(connectionString)
            Dim cm As New MySqlCommand(qS, cn)
            cn.Open()
            Dim reader As MySqlDataReader = cm.ExecuteReader()
            If reader.HasRows Then
                Try


                    While reader.Read()

                        TextBox1.Text = reader("FluCod") + 1
                    End While

                Finally

                    reader.Close()
                End Try
            Else
                TextBox1.Text = 1
            End If

        End Using
    End Sub
End Class