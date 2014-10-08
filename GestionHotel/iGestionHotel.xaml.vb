Public Class iGestionHotel

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub windowGHotel_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowGHotel.Closing
        Me.Owner.Show()
    End Sub
End Class
