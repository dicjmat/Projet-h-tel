Public Class iGestionSalle

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim res As tblSalle
    Private numSalle As Integer

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = maBd
        Dim res = From el In bd.tblHotel Select el
        cbNomHotel.ItemsSource = res.ToList()
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
        txtNoSalle.Text = res.noSalle
        txtNomSalle.Text = res.nomSalle
        txtDescSalle.Text = res.descSalle
        txtNbPlaceSalle.Text = res.nbPlace
        cbNomHotel.SelectedValue = res.tblHotel.nomHotel
        cbNomHotel.IsEnabled = False

        btnAjouter.Visibility = Windows.Visibility.Hidden
        btnAjouter.IsEnabled = False
        btnModifier.Visibility = Windows.Visibility.Visible
        btnModifier.IsEnabled = True
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtDescSalle.Text <> "" And txtNbPlaceSalle.Text <> "" And txtNomSalle.Text <> "" And cbNomHotel.SelectedIndex <> -1 Then
            Dim Salle = New tblSalle()
            Salle.noSalle = txtNoSalle.Text
            Salle.nomSalle = txtNomSalle.Text
            Salle.descSalle = txtDescSalle.Text
            Salle.nbPlace = txtNbPlaceSalle.Text
            Salle.noHotel = cbNomHotel.SelectedItem.noHotel
            Salle.statutSalle = "Libre"
            Salle.codeTypeSalle = "REU"
            bd.tblSalle.Add(Salle)
            bd.SaveChanges()
            MessageBox.Show("La salle a bien été ajouté", "Confirmation", MessageBoxButton.OK)
        Else
            MessageBox.Show("Des informations sont manquantes", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles btnModifier.Click
        If txtDescSalle.Text <> "" And txtNbPlaceSalle.Text <> "" And txtNomSalle.Text <> "" And cbNomHotel.SelectedIndex <> -1 Then
            res.nomSalle = txtNomSalle.Text
            res.descSalle = txtDescSalle.Text
            res.nbPlace = txtNbPlaceSalle.Text
            res.noHotel = cbNomHotel.SelectedItem.noHotel
            bd.SaveChanges()
            MessageBox.Show("La salle a bien été modifié", "Confirmation", MessageBoxButton.OK)
        Else
            MessageBox.Show("Des informations sont manquantes", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Sub
End Class