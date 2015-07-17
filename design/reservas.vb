Imports MySql.Data.MySqlClient
Public Class reservas
    Dim t, tt As String
    Dim r As String
    Dim connectionString As String = "server=localhost;user id=root;password =vertrigo;database=tupinamba"
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        home.Show()
        codigor()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim queryString As String = "SELECT * FROM reserva where ReseCod='" & TextBox1.Text & "'"
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            connection.Open()
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Try
                If reader.HasRows Then

                    While reader.Read()

                        cliente()
                        TextBox6.Text = reader.Item("ReseAdu")
                        TextBox7.Text = reader.Item("ReseCri")
                        TextBox8.Text = reader.Item("ReseDiar")
                        TextBox9.Text = reader.Item("ResePassag")
                        TextBox10.Text = reader.Item("ReseAdic")
                        TextBox11.Text = reader.Item("ReseObs")
                        TextBox12.Text = reader.Item("ReseData")

                        ComboBox2.Text = reader.Item("ResePerfil")
                        ComboBox3.Text = reader.Item("ReseHospe")
                        ComboBox4.Text = reader.Item("ReseTransp")
                        ComboBox5.Text = reader.Item("ReseSeguro")
                        ComboBox6.Text = reader.Item("ReseAlim")
                        ComboBox7.Text = reader.Item("ResePaga")
                        ComboBox8.Text = reader.Item("ReseFPreco")

                    End While
                Else
                    MessageBox.Show("Nada encontrado!")
                End If
            Finally

                reader.Close()
            End Try
        End Using
    End Sub
    Private Sub cliente()
        Dim queryString As String = "SELECT * FROM cliente where CliCPF='" & TextBox13.Text & "'"

        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            connection.Open()
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Try
                While reader.Read()

                    TextBox2.Text = reader.Item("CliNome")
                    TextBox3.Text = reader.Item("CliEmail")
                    TextBox13.Text = reader.Item("CliCPF")
                    TextBox4.Text = reader.Item("CliTR")
                    TextBox5.Text = reader.Item("CliTel")
                    ComboBox1.Text = reader.Item("CliRot")
                    TextBox1.Text = reader.Item("CliDet")
                    
                End While
            Finally

                reader.Close()
            End Try
        End Using
    End Sub
    
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = "" Or TextBox13.Text = "" Then
            MessageBox.Show("Preencha todos os campos de texto!")
        ElseIf Not IsNumeric(TextBox1.Text) Or Not IsNumeric(TextBox13.Text) Or Not IsNumeric(TextBox4.Text) Or Not IsNumeric(TextBox5.Text) Or Not IsDate(TextBox12.Text) Or IsNumeric(TextBox2.Text) Then
            MessageBox.Show("Preencha os campos corretamente!")
        Else

            Dim queryString As String = "insert into reserva(ReseCod,ReseData,ReseAdu,ReseCri,ReseHospe,ReseDiar,ReseTransp,ResePassag,ReseSeguro,ReseAlim,ResePaga,ReseFPreco,ReseAdic,ReseObs,ResePerfil) values (@ReseCod,@ReseData,@ReseAdu,@ReseCri,@ReseHospe,@ReseDiar,@ReseTransp,@ResePassag,@ReseSeguro,@ReseAlim,@ResePaga,@ReseFPreco,@ReseAdic,@ReseObs,@ResePerfil)"
            Using connection As New MySqlConnection(connectionString)
                Dim command As New MySqlCommand(queryString, connection)


                Try


                    ccliente()
                    command.Parameters.AddWithValue("@ReseCod", TextBox1.Text)
                    command.Parameters.AddWithValue("@ReseData", TextBox12.Text)
                    command.Parameters.AddWithValue("@ReseAdu", TextBox6.Text)
                    command.Parameters.AddWithValue("@ReseCri", TextBox7.Text)
                    command.Parameters.AddWithValue("@ReseHospe", ComboBox3.SelectedItem)
                    command.Parameters.AddWithValue("@ReseDiar", TextBox8.Text)
                    command.Parameters.AddWithValue("@ReseTransp", ComboBox4.SelectedItem)
                    command.Parameters.AddWithValue("@ResePassag", TextBox9.Text)
                    command.Parameters.AddWithValue("@ReseSeguro", ComboBox5.SelectedItem)
                    command.Parameters.AddWithValue("@ReseAlim", ComboBox6.SelectedItem)
                    command.Parameters.AddWithValue("@ResePaga", ComboBox7.SelectedItem)
                    command.Parameters.AddWithValue("@ReseFPreco", ComboBox8.SelectedItem)
                    command.Parameters.AddWithValue("@ReseAdic", TextBox10.Text)
                    command.Parameters.AddWithValue("@ReseObs", TextBox11.Text)
                    command.Parameters.AddWithValue("@ResePerfil", ComboBox2.SelectedItem)

                    connection.Open()

                    command.ExecuteNonQuery()


                Finally

                    connection.Close()
                End Try

            End Using
        End If
    End Sub
    Private Sub ccliente()

        Dim queryString As String = "insert into cliente(CliCPF,CliNome,CliEmail,CliTel,CliTR,CliRot,CliDet) values (@CliCPF,@CliNome,@CliEmail,@CliTel,@CliTR,@CliRot,@CliDet)"
        Using connection As New MySqlConnection(connectionString)
            Dim ccli As New MySqlCommand(queryString, connection)


            Try



                ccli.Parameters.AddWithValue("@CliCPF", TextBox13.Text)
                ccli.Parameters.AddWithValue("@CliNome", TextBox2.Text)
                ccli.Parameters.AddWithValue("@CliEmail", TextBox3.Text)
                ccli.Parameters.AddWithValue("@CliTel", TextBox5.Text)
                ccli.Parameters.AddWithValue("@CliTR", TextBox4.Text)
                ccli.Parameters.AddWithValue("@CliRot", ComboBox1.SelectedItem)
                ccli.Parameters.AddWithValue("@CliDet", TextBox1.Text)
                connection.Open()
                ccli.ExecuteNonQuery()
            Finally

                connection.Close()
            End Try

        End Using
    End Sub
    


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim queryString As String = "delete from reserva where ReseCod ='" & TextBox1.Text & "'"
        Dim qu As String = "delete from cliente where CliCPF ='" & TextBox13.Text & "'"
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            Dim d As New MySqlCommand(qu, connection)
            Try

                If MessageBox.Show("Confirmar exclusão?", "Permissão para deletar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    connection.Open()
                    command.ExecuteNonQuery()
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim queryString As String = "Update reserva set ReseCod=@ReseCod,ReseData=@ReseData,ReseAdu=@ReseAdu,ReseCri=@ReseCri,ReseHospe=@ReseHospe,ReseDiar=@ReseDiar,ReseTransp=@ReseTransp,ResePassag=@ResePassag,ReseSeguro=@ReseSeguro,ReseAlim=@ReseAlim,ResePaga=@ResePaga,ReseFPreco=@ReseFPreco,ReseAdic=@ReseAdic,ReseObs=@ReseObs,ResePerfil=@ResePerfil where ReseCod = '" & TextBox1.Text & "' "

        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)

            Try
                acliente()
                command.Parameters.AddWithValue("@ReseCod", TextBox1.Text)
                command.Parameters.AddWithValue("@ReseData", TextBox12.Text)
                command.Parameters.AddWithValue("@ReseAdu", TextBox6.Text)
                command.Parameters.AddWithValue("@ReseCri", TextBox7.Text)
                command.Parameters.AddWithValue("@ReseHospe", TextBox5.Text)
                command.Parameters.AddWithValue("@ReseDiar", TextBox8.Text)
                command.Parameters.AddWithValue("@ReseTransp", TextBox1.Text)
                command.Parameters.AddWithValue("@ResePassag", TextBox9.Text)
                command.Parameters.AddWithValue("@ReseSeguro", TextBox3.Text)
                command.Parameters.AddWithValue("@ReseAlim", TextBox4.Text)
                command.Parameters.AddWithValue("@ResePaga", TextBox5.Text)
                command.Parameters.AddWithValue("@ReseFPreco", TextBox6.Text)
                command.Parameters.AddWithValue("@ReseAdic", TextBox10.Text)
                command.Parameters.AddWithValue("@ReseObs", TextBox11.Text)
                command.Parameters.AddWithValue("@ResePerfil", TextBox5.Text)

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
    Private Sub acliente()

        Dim queryString As String = "Update cliente set CliCPF=@CliCPF,CliNome=@CliNome,CliEmail=@CliEmail,CliRot=@CliRot,CliDet=@CliDet,CliTel=@CliTel,CliTR=@CliTR "
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            connection.Open()
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Try



                command.Parameters.AddWithValue("@CliCPF", TextBox13.Text)
                command.Parameters.AddWithValue("@CliNome", TextBox2.Text)
                command.Parameters.AddWithValue("@CliEmail", TextBox3.Text)
                command.Parameters.AddWithValue("@CliRot", ComboBox1.SelectedItem)
                command.Parameters.AddWithValue("@CliDet", TextBox1.Text)
                command.Parameters.AddWithValue("@CliTel", TextBox5.Text)
                command.Parameters.AddWithValue("@CliTR", TextBox4.Text)

            Finally

                reader.Close()
            End Try

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
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        ComboBox1.Text = "Tipo de Roteiro"
        ComboBox2.Text = "Perfil de Roteiro"
        ComboBox3.Text = "Hospedagem"
        ComboBox4.Text = "Transporte"
        ComboBox5.Text = "Seguro de Viagem"
        ComboBox6.Text = "Alimentação"
        ComboBox7.Text = "Formas de pagamento"
        ComboBox8.Text = "Faixa de preço"
    End Sub

    Public Sub codigor()
        Dim qS As String = "select ReseCod from reserva"
        Using cn As New MySqlConnection(connectionString)
            Dim cm As New MySqlCommand(qS, cn)
            cn.Open()
            Dim reader As MySqlDataReader = cm.ExecuteReader()

            Try
                If reader.HasRows Then
                    While reader.Read()

                        TextBox1.Text = reader("ReseCod") + 1
                    End While

                Else
                    TextBox1.Text = 1
                End If

            Finally

                reader.Close()
            End Try
        End Using
    End Sub

    Private Sub reservas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        codigor()

    End Sub
   
End Class