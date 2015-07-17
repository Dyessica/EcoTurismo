Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.PowerPacks.Printing

Public Class relatorios
    Dim connectionString As String = "server=localhost;user id=root;password =vertrigo;database=tupinamba"

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        home.Show()
        Código.Items.Clear()
        Entrada.Items.Clear()
        Saída.Items.Clear()
        Data.Items.Clear()
        relatorio()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)

    End Sub

    Private Sub relatorios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        relatorio()


    End Sub
    Private Sub relatorio()
        Dim queryString As String = "SELECT * FROM FluxoCaixa"
        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(queryString, connection)
            connection.Open()
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Try
                If reader.HasRows Then


                    While reader.Read()
                        Código.Items.Add(reader.Item("FluCod"))
                        Entrada.Items.Add(reader.Item("FluGanho"))
                        Saída.Items.Add(reader.Item("FluGasto"))
                        Dim da As DateTime = reader.Item("FluData")
                        Data.Items.Add(da)


                    End While

                Else
                    MessageBox.Show("Nada encontrado!")
                End If
            Finally

                reader.Close()
            End Try
        End Using
    End Sub

End Class