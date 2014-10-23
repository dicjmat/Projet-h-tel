Public Class iListeSalle
    Private noHotel As Short
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Sub New(_noHotel As Short, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        noHotel = _noHotel
        bd = _bd
    End Sub

    Private Sub btnAjouterSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterSalle.Click
        Dim iSalle As New iGestionSalle(bd)
        iSalle.Owner = Me
        Me.Hide()
        iSalle.ShowDialog()
    End Sub
End Class
