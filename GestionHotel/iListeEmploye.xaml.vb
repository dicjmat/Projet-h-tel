Public Class iListeEmploye

    Private Sub btnAjouterEmploye_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterEmploye.Click
        Dim iEmploye As New iFicheEmploye
        iEmploye.Owner = Me
        Me.Hide()
        iEmploye.Show()
    End Sub
End Class
