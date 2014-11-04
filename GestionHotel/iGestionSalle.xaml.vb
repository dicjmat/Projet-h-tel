Public Class iGestionSalle

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim res As tblSalle
    Private numSalle As Integer

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = maBd
        btnAjouter.Visibility = Windows.Visibility.Visible
        btnAjouter.IsEnabled = True
        btnModifier.Visibility = Windows.Visibility.Hidden
        btnModifier.IsEnabled = False
    End Sub

    Sub New(_numSalle As Integer, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        numSalle = _numSalle
        bd = _bd

        res = From el In bd.tblSalle Where el.noSalle = numSalle Select el
        txtNomSalle.Text = res.nomSalle
        txtDescSalle.Text = res.descSalle
        txtNbPlaceSalle.Text = res.nbPlace
        cbNoHotel.SelectedValue = res.noHotel
        cbNoHotel.IsEnabled = False

        btnAjouter.Visibility = Windows.Visibility.Hidden
        btnAjouter.IsEnabled = False
        btnModifier.Visibility = Windows.Visibility.Visible
        btnModifier.IsEnabled = True
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtDescSalle.Text <> "" And txtNbPlaceSalle.Text <> "" And txtNomSalle.Text <> "" And cbNoHotel.SelectedIndex <> -1 Then
            Dim Salle = New tblSalle()
            Salle.nomSalle = txtNomSalle.Text
            Salle.descSalle = txtDescSalle.Text
            Salle.nbPlace = txtNbPlaceSalle.Text
            Salle.noHotel = cbNoHotel.SelectedValue
            bd.tblSalle.Add(Salle)
            bd.SaveChanges()
            MessageBox.Show("La salle a bien été ajouté", "Confirmation", MessageBoxButton.OK)
        Else
            MessageBox.Show("Des informations sont manquantes", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles btnModifier.Click
        If txtDescSalle.Text <> "" And txtNbPlaceSalle.Text <> "" And txtNomSalle.Text <> "" And cbNoHotel.SelectedIndex <> -1 Then
            res.nomSalle = txtNomSalle.Text
            res.descSalle = txtDescSalle.Text
            res.nbPlace = txtNbPlaceSalle.Text
            res.noHotel = cbNoHotel.SelectedValue
            bd.SaveChanges()
            MessageBox.Show("La salle a bien été modifié", "Confirmation", MessageBoxButton.OK)
        Else
            MessageBox.Show("Des informations sont manquantes", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Sub
End Class