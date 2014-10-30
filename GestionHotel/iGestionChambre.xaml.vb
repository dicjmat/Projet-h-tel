Public Class iGestionChambre

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private hotel As Integer

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, p2 As Integer)
        InitializeComponent()
        bd = _bd
        hotel = p2
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub
    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtNoChambre.Text <> "" And cbTypeChambre.SelectedIndex <> -1 Then
            Dim res = From ch In bd.tblChambre
                      Where txtNoChambre.Text = ch.noChambre And ch.noHotel = hotel
                      Select ch
            If res.Count = 0 Then
                Dim chambre = New tblChambre
                chambre.codeTypeChambre = cbTypeChambre.SelectedItem.codeTypeChambre
                chambre.noHotel = hotel
                chambre.noChambre = txtNoChambre.Text
                chambre.statutChambre = "LI"
                bd.tblChambre.Add(chambre)
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
        Dim typeChambre = From tych In bd.tblTypeChambre
                          Join tychho In bd.tblTypeChambreHotel
                          On tych.codeTypeChambre Equals tychho.codeTypeChambre
                          Where tychho.noHotel = hotel
                          Select tych

        cbTypeChambre.ItemsSource = typeChambre.ToList
    End Sub
End Class
