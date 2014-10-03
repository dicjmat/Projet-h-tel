Public Class iListeClient
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities

    End Sub
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Focusable = False
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub txtRCli_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRCli.TextChanged

    End Sub



End Class
