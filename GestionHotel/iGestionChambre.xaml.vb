Public Class iGestionChambre

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private hotel As Integer

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _hotel As Integer)
        InitializeComponent()
        bd = _bd
        hotel = _hotel

    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub
    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtNoChambre.Text <> "" And cbTypeChambre.SelectedIndex <> -1 Then
            Dim res = From ch In bd.tblSalle
                      Where txtNoChambre.Text = ch.noSalle And ch.noHotel = hotel
                      Select ch
            If res.Count = 0 Then
                Dim chambre = New tblSalle
                chambre.codeTypeSalle = cbTypeChambre.SelectedItem.codeTypeSalle
                chambre.noHotel = hotel
                chambre.noSalle = txtNoChambre.Text
                chambre.statutSalle = "LI"
                bd.tblSalle.Add(chambre)
                bd.SaveChanges()
                MessageBox.Show("La chambre a été ajoutée avec succès")
                Me.Close()
                Me.Owner.Activate()
            Else
                MessageBox.Show("Il existe déjà une chambre à ce numéro")
            End If


        Else
            MessageBox.Show("Veuillez sélectionner un type de chambre et assigner un numéro")
        End If
    End Sub

    Private Sub windowGChambre_Loaded(sender As Object, e As RoutedEventArgs) Handles windowGChambre.Loaded
        Dim typeChambre = From tych In bd.tblTypeSalle
                          Where tych.codeTypeSalle <> "REU"
                          Select tych

        cbTypeChambre.ItemsSource = typeChambre.ToList
    End Sub

End Class
