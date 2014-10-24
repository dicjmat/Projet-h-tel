Public Class iGestionSalle

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private numSalle As Integer

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = maBd
    End Sub

    Sub New(_numSalle As Integer, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        numSalle = _numSalle
        bd = _bd
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Show()
        Me.Close()
    End Sub
End Class
