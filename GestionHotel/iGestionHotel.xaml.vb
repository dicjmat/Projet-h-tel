Public Class iGestionHotel

    Private bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization 
        InitializeComponent()
        bd = _bd
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub windowGHotel_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowGHotel.Closing
        Me.Owner.Show()
    End Sub
End Class
