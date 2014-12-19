Public Class iGestionSalle

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim res As tblSalle
    Dim noHotel As Integer
    Private numSalle As Integer

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities, _noHotel As Integer)
        InitializeComponent()
        bd = maBd
        noHotel = _noHotel
        Dim res = From el In bd.tblHotel Select el
        'cbNomHotel.ItemsSource = res.ToList()
        btnAjouter.Visibility = Windows.Visibility.Visible
        btnAjouter.IsEnabled = True
        btnModifier.Visibility = Windows.Visibility.Hidden
        btnModifier.IsEnabled = False
    End Sub

    Sub New(_numSalle As Integer, _bd As P2014_Equipe2_GestionHôtelièreEntities, _noHotel As Integer)
        InitializeComponent()
        numSalle = _numSalle
        bd = _bd
        noHotel = _noHotel
        res = (From el In bd.tblSalle Where el.noSalle = numSalle Select el).Single
        txtNoSalle.Text = res.noSalle
        txtNoSalle.IsEnabled = False
        txtNomSalle.Text = res.nomSalle
        txtDescSalle.Text = res.descSalle
        txtNbPlaceSalle.Text = res.nbPlace
        'cbNomHotel.SelectedValue = res.tblHotel.nomHotel
        'cbNomHotel.IsEnabled = False

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
        If txtDescSalle.Text <> "" And txtNbPlaceSalle.Text <> "           " And txtNomSalle.Text <> "" And txtNoSalle.Text <> "       " Then
            Dim Salle = New tblSalle()
            Salle.noSalle = txtNoSalle.Text
            Salle.nomSalle = txtNomSalle.Text
            Salle.descSalle = txtDescSalle.Text
            Salle.nbPlace = txtNbPlaceSalle.Text
            Salle.noHotel = noHotel
            Salle.statutSalle = "Libre"
            Salle.codeTypeSalle = "REU"
            bd.tblSalle.Add(Salle)
            Try
                bd.SaveChanges()
            Catch ex As Exception
                MessageBox.Show("Le numéro de salle est déjà utilisé")
                Exit Sub
            End Try

            MessageBox.Show("La salle a bien été ajouté", "Confirmation", MessageBoxButton.OK)
        Else
            MessageBox.Show("Des informations sont manquantes", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles btnModifier.Click
        If txtDescSalle.Text <> "" And txtNbPlaceSalle.Text <> "" And txtNomSalle.Text <> "" Then
            res.nomSalle = txtNomSalle.Text
            res.descSalle = txtDescSalle.Text
            res.nbPlace = txtNbPlaceSalle.Text
            bd.SaveChanges()
            MessageBox.Show("La salle a bien été modifié", "Confirmation", MessageBoxButton.OK)
        Else
            MessageBox.Show("Des informations sont manquantes", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Sub
End Class