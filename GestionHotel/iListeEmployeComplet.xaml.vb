Public Class iListeEmployeComplet

    Private Sub btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles btnAjout.Click
        Dim emp = New iFicheEmploye
        emp.Owner = Me
        emp.Show()
        Me.Hide()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub
End Class
