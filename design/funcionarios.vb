Imports MySql.Data.MySqlClient
Public Class funcionarios
    Dim connectionString As String = "server=localhost;user id=root;password =vertrigo;database=tupinamba"

    Private Sub TextBox5_GotFocus(sender As Object, e As EventArgs) Handles TextBox5.GotFocus
        endereco.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim queryString As String = "SELECT * FROM funcionario where FuncCPF='" & TextBox1.Text & "'"
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            connection.Open()
            Dim reader As MySqlDataReader = Command.ExecuteReader()
            Try
                If reader.HasRows Then

                    While reader.Read()

                        TextBox2.Text = reader.Item("FuncNome")
                        TextBox3.Text = reader.Item("FuncRG")
                        TextBox5.Text = reader.Item("FuncRes")
                        TextBox6.Text = reader.Item("FuncTel")
                        TextBox7.Text = reader.Item("FuncEmail")
                        TextBox8.Text = reader.Item("FuncArea")
                    End While
                Else
                    MessageBox.Show("Nada encontrado!")
                End If
            Finally

                reader.Close()
            End Try
        End Using
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        home.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
            MessageBox.Show("Preencha todos os campos!")
        ElseIf Not IsNumeric(TextBox1.Text) Or Not IsNumeric(TextBox5.Text) Or Not IsNumeric(TextBox6.Text) Or IsNumeric(TextBox2.Text) Then
            MessageBox.Show("Preencha os campos corretamente!")
        Else

            Dim queryString As String = "insert into funcionario(FuncCPF,FuncNome,FuncRG,FuncRes,FuncTel,FuncEmail,FuncArea) values (@FuncCPF,@FuncNome,@FuncRG,@FuncRes,@FuncTel,@FuncEmail,@FuncArea)"
            Using connection As New MySqlConnection(connectionString)
                Dim command As New MySqlCommand(queryString, connection)
                Try
                    command.Parameters.AddWithValue("@FuncCPF", TextBox1.Text)
                    command.Parameters.AddWithValue("@FuncNome", TextBox2.Text)
                    command.Parameters.AddWithValue("@FuncRG", TextBox3.Text)
                    command.Parameters.AddWithValue("@FuncRes", TextBox5.Text)
                    command.Parameters.AddWithValue("@FuncTel", TextBox6.Text)
                    command.Parameters.AddWithValue("@FuncEmail", TextBox7.Text)
                    command.Parameters.AddWithValue("@FuncArea", TextBox8.Text)



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
        Dim queryString As String = "Update funcionario set FuncCPF=@FuncCPF,FuncNome=@FuncNome,FuncRG=@FuncRG,FuncRes=@FuncRes,FuncEmail=@FuncEmail,FuncArea=@FuncArea,FuncTel=@FuncTel where FuncCPF = '" & TextBox1.Text & "' "

        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)

            Try

                command.Parameters.AddWithValue("@FuncCPF", TextBox1.Text)
                command.Parameters.AddWithValue("@FuncNome", TextBox2.Text)
                command.Parameters.AddWithValue("@FuncRG", TextBox3.Text)
                command.Parameters.AddWithValue("@FuncRes", TextBox5.Text)
                command.Parameters.AddWithValue("@FuncTel", TextBox6.Text)
                command.Parameters.AddWithValue("@FuncEmail", TextBox7.Text)
                command.Parameters.AddWithValue("@FuncArea", TextBox8.Text)

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
        Dim queryString As String = "delete from funcionario where FuncCPF ='" & TextBox1.Text & "'"
        Dim q As String = "delete from telefone where TelCod= '" & TextBox6.Text & "'"
        Dim s As String = "delete from residencia where ResCod= '" & TextBox5.Text & "'"
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            Dim c As New MySqlCommand(q, connection)
            Dim d As New MySqlCommand(s, connection)
        
            Try

                If MessageBox.Show("Confirmar exclusão?", "Permissão para deletar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    connection.Open()
                    command.ExecuteNonQuery()
                    c.ExecuteNonQuery()
                    d.ExecuteNonQuery()
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
    

    Private Sub TextBox6_GotFocus(sender As Object, e As EventArgs) Handles TextBox6.GotFocus
        telefone.Show()
        resi()
    End Sub

    Private Sub TextBox7_GotFocus(sender As Object, e As EventArgs) Handles TextBox7.GotFocus
        tele()
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

                        TextBox5.Text = reader("ResCod")
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

                        TextBox6.Text = reader("TelCod")
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