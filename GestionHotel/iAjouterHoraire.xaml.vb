Public Class iAjouterHoraire
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Sub New(_noEmploye As Short)
        InitializeComponent()
        'noEmploye = _noEmploye
    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities

    End Sub
End Class
