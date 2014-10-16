Public Class iRabais

    Private Sub btndeco_Click(sender As Object, e As RoutedEventArgs) Handles btndeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub windowRabais_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowRabais.Closing
        Me.Owner.Close()
    End Sub
End Class
