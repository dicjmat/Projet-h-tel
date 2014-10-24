Public Class iGestionChambre

    Private bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization 
        InitializeComponent()
        bd = maBd
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub windowGChambre_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowGChambre.Closing
        Me.Owner.Show()
    End Sub
End Class
