Public Class iAccueilVente
    Private Sub AppuieForfait()
        Dim Forfait = New iAjoutForf
        Forfait.Owner = Me
        Forfait.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub
    Private Sub AppuieRabais()
        Dim Rabais = New iRabais
        Rabais.Owner = Me
        Rabais.Show()
    End Sub
End Class
