Imports MySql.Data.MySqlClient
Public Class contratos

    Dim connectionString As String = "server=localhost;user id=root;password =vertrigo;database=tupinamba"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        home.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim queryString As String = "SELECT * FROM contratos where ContC='" & TextBox1.Text & "'"
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            connection.Open()
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Try
                If reader.HasRows Then


                    While reader.Read()

                        TextBox2.Text = reader.Item("ContNome")
                        TextBox3.Text = reader.Item("ContEnd")
                        TextBox4.Text = reader.Item("ContTel")
                        TextBox6.Text = reader.Item("ContTipo")
                    End While

                Else
                    MessageBox.Show("Nada encontrado!")
                End If
            Finally

                reader.Close()
            End Try
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox6.Text = "" Then
            MessageBox.Show("Preencha todos os campos!")
        ElseIf Not IsNumeric(TextBox1.Text) Or IsNumeric(TextBox2.Text) Or Not IsNumeric(TextBox3.Text) Or Not IsNumeric(TextBox4.Text) Or IsNumeric(TextBox6.Text) Then
            MessageBox.Show("Preencha os campos corretamente!")
        Else
            Dim queryString As String = "insert into contratos(ContC,ContTipo,ContNome,ContEnd, ContTel) values (@ContC,@ContTipo,@ContNome,@ContEnd, @ContTel)"
            Using connection As New MySqlConnection(connectionString)
                Dim command As New MySqlCommand(queryString, connection)
                Try
                    command.Parameters.AddWithValue("@ContC", TextBox1.Text)
                    command.Parameters.AddWithValue("@ContNome", TextBox2.Text)
                    command.Parameters.AddWithValue("@ContEnd", TextBox3.Text)
                    command.Parameters.AddWithValue("@ContTel", TextBox4.Text)
                    command.Parameters.AddWithValue("@ContTipo", TextBox6.Text)




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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim queryString As String = "Update contratos set ContC=@ContC,ContTipo=@ContTipo,ContNome=@ContNome,ContEnd=@ContEnd,ContTel=@ContTel where ContC = '" & TextBox1.Text & "' "

        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)

            Try

                command.Parameters.AddWithValue("@ContC", TextBox1.Text)
                command.Parameters.AddWithValue("@ContNome", TextBox2.Text)
                command.Parameters.AddWithValue("@ContEnd", TextBox3.Text)
                command.Parameters.AddWithValue("@ContTel", TextBox4.Text)
                command.Parameters.AddWithValue("@ContTipo", TextBox6.Text)


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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim queryString As String = "delete from contratos where ContC ='" & TextBox1.Text & "'"
        Dim queryS As String = "delete from residencia where ResCod ='" & TextBox3.Text & "'"
        Dim qString As String = "delete from telefone where TelCod ='" & TextBox4.Text & "'"
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            Dim com As New MySqlCommand(queryS, connection)
            Dim mand As New MySqlCommand(qString, connection)
            Try

                If MessageBox.Show("Confirmar exclusão?", "Permissão para deletar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    connection.Open()
                    command.ExecuteNonQuery()
                    com.ExecuteNonQuery()
                    mand.ExecuteNonQuery()

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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
    End Sub


    Private Sub TextBox3_GotFocus(sender As Object, e As EventArgs) Handles TextBox3.GotFocus
        endereco.Show()
    End Sub

    Private Sub TextBox4_GotFocus(sender As Object, e As EventArgs) Handles TextBox4.GotFocus
        telefone.Show()
        resi()
    End Sub
    Private Sub resi()

        Dim qS As String = "select ResCod from Residencia"
        Using cn As New MySqlConnection(connectionString)
            Dim cm As New MySqlCommand(qS, cn)
            cn.Open()
            Dim reader As MySqlDataReader = cm.ExecuteReader()

            Try
                If reader.HasRows Then

                    While reader.Read()

                        TextBox3.Text = reader("ResCod")
                    End While
                Else
                    TextBox1.Text = 1
                End If
            Finally

                reader.Close()
            End Try
        End Using
    End Sub
    Private Sub tele()
        Dim qS As String = "select TelCod from telefone"
        Using cn As New MySqlConnection(connectionString)
            Dim cm As New MySqlCommand(qS, cn)
            cn.Open()
            Dim reader As MySqlDataReader = cm.ExecuteReader()

            Try
                If reader.HasRows Then

                    While reader.Read()

                        TextBox4.Text = reader("TelCod")
                    End While
                Else
                    TextBox1.Text = 1
                End If
            Finally

                reader.Close()
            End Try
        End Using
    End Sub

    Private Sub TextBox5_GotFocus(sender As Object, e As EventArgs)
        tele()
    End Sub

End Class