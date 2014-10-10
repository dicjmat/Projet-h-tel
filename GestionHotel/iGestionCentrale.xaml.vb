Public Class iGestionCentrale

    Private Sub btnListeCentrale_Click(sender As Object, e As RoutedEventArgs) Handles btnListeCentrale.Click
        Dim liste = New iListeCentrale()
        liste.Owner = Me
        liste.Show()
        Me.Hide()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub
End Class
