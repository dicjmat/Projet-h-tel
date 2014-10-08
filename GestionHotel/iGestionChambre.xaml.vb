Public Class iGestionChambre

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub windowGChambre_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowGChambre.Closing
        Me.Owner.Show()
    End Sub
End Class
