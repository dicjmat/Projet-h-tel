Public Class iListeSalle
    Private noHotel As Short
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Sub New(_noHotel As Short, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        noHotel = _noHotel
        bd = _bd
    End Sub
    Private Sub windowListeSalle_Loaded(sender As Object, e As RoutedEventArgs) Handles windowListeSalle.Loaded
        Dim res = From el In bd.tblSalle Where el.noHotel = noHotel Select el
        lstSalle.DataContext = res.ToList()
    End Sub
    Private Sub btnAjouterSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterSalle.Click
        Dim iSalle As New iGestionSalle(bd)
        iSalle.Owner = Me
        Me.Hide()
        iSalle.ShowDialog()
    End Sub

    Private Sub btnModifSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnModifSalle.Click
        If lstSalle.SelectedIndex <> -1 Then
            Dim numSalle = lstSalle.SelectedItem.noSalle
            Dim iSalle As New iGestionSalle(numSalle, bd)
            iSalle.Owner = Me
            Me.Hide()
            iSalle.ShowDialog()
        Else
            MessageBox.Show("Veuillez sélectionner une salle")
        End If
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub btnReservSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnReservSalle.Click
        If lstSalle.SelectedIndex <> -1 Then
            Dim numSalle = lstSalle.SelectedItem.noSalle
            Dim iReservSalle As New iFaireReservSalle(bd)
            iSalle.Owner = Me
            Me.Hide()
            iSalle.ShowDialog()
        Else
            MessageBox.Show("Veuillez sélectionner une salle")
        End If
    End Sub
End Class
