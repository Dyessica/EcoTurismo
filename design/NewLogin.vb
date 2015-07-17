Imports MySql.Data.MySqlClient
Public Class NewLogin
    Dim connectionString As String = "server=localhost;user id=root;password =vertrigo;database=tupinamba"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsNumeric(TextBox1.Text) Then
            MessageBox.Show("Preencha CPF corretamente!")
        ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MessageBox.Show("Preencha todos os campos!")
        Else
            Try

                If MessageBox.Show("Confirma os dados?", "Permissão para salvar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim qS As String = "SELECT SCPF FROM Senha"
                    Using connection As New MySqlConnection(connectionString)
                        Dim command As New MySqlCommand(qS, connection)
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Try
                            If reader.HasRows Then

                                While reader.Read()

                                    qS = reader.Item("SCPF")

                                End While
                            Else
                                MessageBox.Show("Nada encontrado!")
                            End If
                        Finally

                            reader.Close()
                        End Try
                        If qS = TextBox1.Text Then
                            Dim queryString As String = "Update Senha set SUsu=@SUsu,SSen=@SSen,SCPF=@SCPF"

                            Using cn As New MySqlConnection(connectionString)
                                Dim cd As New MySqlCommand(queryString, connection)
                                Try
                                    cd.Parameters.AddWithValue("@SCPF", TextBox1.Text)
                                    cd.Parameters.AddWithValue("@SUsu", TextBox2.Text)
                                    cd.Parameters.AddWithValue("@SSen", TextBox3.Text)

                                    cn.Open()
                                    cd.ExecuteNonQuery()


                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Atenção!")
                                Finally
                                    cn.Close()
                                End Try
                                TextBox1.Clear()
                                TextBox2.Clear()
                                TextBox3.Clear()
                                Me.Hide()

                            End Using

                        Else
                            MessageBox.Show("CPF errado.")
                        End If
                        connection.Close()
                    End Using
                End If
                            MessageBox.Show("Salvo com sucesso")




            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro ao salvar")

            End Try
        End If


    End Sub
End Class