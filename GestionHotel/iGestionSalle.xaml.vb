Public Class iGestionSalle

    Private bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization
        InitializeComponent()
        bd = maBd
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Show()
        Me.Close()
    End Sub
End Class
