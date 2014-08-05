Imports System.Net
Imports System.IO
Public Class sesion

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cancelar.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles aceptar.Click
        Dim id As Integer
        Dim fecha As DateTime = Now
        '  Dim guarda As Integer

        Dim ip As System.Net.IPHostEntry
        ip = Dns.GetHostEntry(My.Computer.Name)
        Dim valorIp As String
        valorIp = ""
        For Each valor As IPAddress In ip.AddressList
            valorIp = valor.ToString()
        Next
        Label1.Text = My.Computer.Name
        'fecha.Now

        id = SesionTableAdapter.FillBy(Me.BasedatosDataSet.sesion, a.Text, b.Text)
        If id <> 0 Then
            Me.Visible = False
            MessageBox.Show("USUARIO ACEPTADO")
            Form1.Visible = True

        Else
            MessageBox.Show("USUARIO NO ACEPTADO")
        End If

        Me.IntentosTableAdapter1.InsertQuery(a.Text, fecha, My.Computer.Name)

    End Sub

    Private Sub sesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BasedatosDataSet.sesion' Puede moverla o quitarla según sea necesario.
        Me.SesionTableAdapter.Fill(Me.BasedatosDataSet.sesion)

    End Sub

    Private Sub SesionBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SesionBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BasedatosDataSet)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
'prueba de nueva edicion por github
