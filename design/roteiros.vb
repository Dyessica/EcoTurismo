Imports MySql.Data.MySqlClient


Public Class roteiros


    Dim connectionString As String = "server=localhost;user id=root;password =vertrigo;database=tupinamba"


    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer = 0

        Dim queryString As String = "SELECT * FROM roteiros where RotCod='" & TextBox1.Text & "'"
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            connection.Open()
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Try
                If reader.HasRows Then

                    While reader.Read()

                        TextBox2.Text = reader.Item("RotLocal")
                        TextBox3.Text = reader.Item("RotAtrac")
                        TextBox4.Text = reader.Item("RotDura")
                        TextBox5.Text = reader.Item("RotValor")
                        TextBox6.Text = reader.Item("RotInclu")
                        TextBox7.Text = reader.Item("RotCrono")
                        TextBox8.Text = reader.Item("RotFunc")
                        TextBox9.Text = reader.Item("RotNome")
                        selecao()
                    End While
                Else
                    MessageBox.Show("Nada encontrado!")
                End If
            Finally

                reader.Close()
            End Try
        End Using
    End Sub
    Private Sub selecao()
        Dim queryString As String = "SELECT * FROM roteiros where RotCod='" & TextBox1.Text & "'"
        Using co As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, co)
            co.Open()
            Dim rr As MySqlDataReader = command.ExecuteReader()
            Try
                If rr.HasRows Then
                    While rr.Read()
                        Dim t As String
                        t = rr.Item("RotTipo")
                        Select Case t
                            Case "Trilhas/Trekking"
                                ListBox1.SetSelected(0, True)
                            Case "Camping's"
                                ListBox1.SetSelected(1, True)
                            Case "Cavernas e Grutas"
                                ListBox1.SetSelected(2, True)
                            Case "Praias"
                                ListBox1.SetSelected(3, True)
                            Case "Manguezais"
                                ListBox1.SetSelected(4, True)
                            Case "Fazendas e Sítios"
                                ListBox1.SetSelected(5, True)
                            Case "Zoológicos e Parques"
                                ListBox1.SetSelected(6, True)
                            Case "Museu de Ciências"
                                ListBox1.SetSelected(7, True)
                            Case "Aquários"
                                ListBox1.SetSelected(8, True)
                            Case "Ongs e Projetos"
                                ListBox1.SetSelected(9, True)
                            Case "Jardins Botânicos"
                                ListBox1.SetSelected(10, True)
                            Case "Turismo Étnico"
                                ListBox1.SetSelected(11, True)
                        End Select
                    End While
                End If
            Finally

                rr.Close()
            End Try
        End Using
    End Sub
    Private Sub roteiros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        codigo()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        home.Show()
        codigo()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Then
            MessageBox.Show("Preencha todos os campos!")
        ElseIf Not IsNumeric(TextBox1.Text) Then
            MessageBox.Show("O código deve ser numérico!")
        Else
            Dim queryString As String = "insert into roteiros(RotCod, RotLocal, RotAtrac,RotDura, RotValor,RotInclu, RotCrono,RotFunc, RotNome,RotTipo) values (@RotCod,@RotLocal,@RotAtrac,@RotDura,@RotValor,@RotInclu,@RotCrono,@RotFunc,@RotNome,@RotTipo)"
            Using connection As New MySqlConnection(connectionString)
                Dim command As New MySqlCommand(queryString, connection)
                Try
                    command.Parameters.AddWithValue("@RotCod", TextBox1.Text)
                    command.Parameters.AddWithValue("@RotLocal", TextBox2.Text)
                    command.Parameters.AddWithValue("@RotAtrac", TextBox3.Text)
                    command.Parameters.AddWithValue("@RotDura", TextBox4.Text)
                    command.Parameters.AddWithValue("@RotValor", TextBox5.Text)
                    command.Parameters.AddWithValue("@RotInclu", TextBox6.Text)
                    command.Parameters.AddWithValue("@RotCrono", TextBox7.Text)
                    command.Parameters.AddWithValue("@RotFunc", TextBox8.Text)
                    command.Parameters.AddWithValue("@RotNome", TextBox9.Text)
                    command.Parameters.AddWithValue("@RotTipo", ListBox1.SelectedItem)

                    connection.Open()
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Atenção!")
                Finally
                    connection.Close()
                End Try

                Button5.PerformClick()
            End Using
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim queryString As String = "delete from roteiros where RotCod ='" & TextBox1.Text & "'"
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            Try

                If MessageBox.Show("Confirmar exclusão?", "Permissão para deletar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show("Exclusão realizada")


                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro na exclusão")
            Finally
                connection.Close()
            End Try
            Button5.PerformClick()

        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim queryString As String = "Update roteiros set RotCod=@RotCod,RotLocal=@RotLocal,RotAtrac=@RotAtrac,RotDura=@RotDura,RotValor=@RotValor,RotInclu=@RotInclu,RotCrono=@RotCrono,RotFunc=@RotFunc,RotNome=@RotNome,RotTipo=@RotTipo where RotCod = '" & TextBox1.Text & "' "

        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)

            Try

                command.Parameters.AddWithValue("@RotCod", TextBox1.Text)
                command.Parameters.AddWithValue("@RotLocal", TextBox2.Text)
                command.Parameters.AddWithValue("@RotAtrac", TextBox3.Text)
                command.Parameters.AddWithValue("@RotDura", TextBox4.Text)
                command.Parameters.AddWithValue("@RotValor", TextBox5.Text)
                command.Parameters.AddWithValue("@RotInclu", TextBox6.Text)
                command.Parameters.AddWithValue("@RotCrono", TextBox7.Text)
                command.Parameters.AddWithValue("@RotFunc", TextBox8.Text)
                command.Parameters.AddWithValue("@RotNome", TextBox9.Text)
                command.Parameters.AddWithValue("@RotTipo", ListBox1.SelectedItem)

                connection.Open()
                command.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Atenção!")
            Finally
                connection.Close()
            End Try
            Button5.PerformClick()


        End Using
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        ListBox1.ClearSelected()

    End Sub

    Public Sub codigo()
        Dim qS As String = "select RotCod from roteiros"
        Using cn As New MySqlConnection(connectionString)
            Dim cm As New MySqlCommand(qS, cn)
            cn.Open()
            Dim reader As MySqlDataReader = cm.ExecuteReader()

            Try
                If reader.HasRows Then

                    While reader.Read()

                        TextBox1.Text = reader("RotCod") + 1
                    End While
                Else
                    TextBox1.Text = 1
                End If
            Finally

                reader.Close()
            End Try
        End Using
    End Sub

  
End Class