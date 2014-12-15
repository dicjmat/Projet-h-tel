Public Class iListeHotel
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = maBd
        noEmp = _noEmp
        noHotel = _noHotel
    End Sub

    Private Sub window_lstHotel_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstHotel.Loaded
        Me.Owner.Hide()
        requeteHotel()
    End Sub

    Private Sub window_lstHotel_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_lstHotel.Closing
        Me.Owner.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub dgHotel_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgHotel.SelectionChanged
        If dgHotel.SelectedIndex <> -1 Then
            requeteChambre()
        End If

    End Sub

    Private Sub btnAjouterHotel_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterHotel.Click
        Dim Ghotel = New iGestionHotel(bd)
        Ghotel.Owner = Me
        Ghotel.Show()
        requeteHotel()
    End Sub

    Private Sub btnAjouterChambre_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterChambre.Click
        If dgHotel.SelectedIndex <> -1 Then
            Dim Gchambre = New iGestionChambre(bd, dgHotel.SelectedItem.noHotel)
            Gchambre.Owner = Me
            Gchambre.Show()
        Else
            MessageBox.Show("Veuillez choisir un hôtel")
        End If


    End Sub

    Private Sub btnModifierHotel_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierHotel.Click
        If dgHotel.SelectedIndex <> -1 Then
            Dim Ghotel = New iGestionHotel(bd, dgHotel.SelectedItem.noHotel)
            Ghotel.Owner = Me
            Ghotel.Show()
            requeteHotel()
        Else
            MessageBox.Show("Veuillez sélectionner un hôtel")
        End If



    End Sub

    Private Sub btnSupprimerChambre_Click(sender As Object, e As RoutedEventArgs) Handles btnSupprimerChambre.Click
        If dgChambre.SelectedIndex <> -1 Then
            Dim noHotel As Integer = dgHotel.SelectedItem.noHotel
            Dim chambre As Integer = dgChambre.SelectedItem.noSalle
            Dim supprimer = From ch In bd.tblSalle
                            Where ch.noSalle = chambre And ch.noHotel = noHotel
                            Select ch

            bd.tblSalle.Remove(supprimer.Single)
            bd.SaveChanges()
            MessageBox.Show("La chambre a bien été supprimée")
            requeteChambre()
        Else
            MessageBox.Show("Veuillez choisir une chambre")
        End If


    End Sub

    Private Sub requeteHotel()
        Dim res = From Ho In bd.tblHotel
          Join Vi In bd.tblVille On Ho.codeVille Equals Vi.codeVille
          Select Ho.noHotel, Ho.nomHotel, Vi.nomVille

        dgHotel.ItemsSource = res.ToList()
    End Sub

    Private Sub requeteChambre()
        Dim noHotel As Integer = dgHotel.SelectedItem.noHotel
        Dim res = From Ch In bd.tblSalle
                  Join TyCh In bd.tblTypeSalle On Ch.codeTypeSalle Equals TyCh.codeTypeSalle
                  Where Ch.noHotel = noHotel And Ch.codeTypeSalle <> "REU"
                  Select Ch.noSalle, TyCh.nomTypeSalle

        dgChambre.ItemsSource = res.ToList()
    End Sub

    Private Sub window_lstHotel_Activated(sender As Object, e As EventArgs) Handles window_lstHotel.Activated
        requeteChambre()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim inv = New iInventaire(noEmp, noHotel, bd)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim fourni = New iAjoutFournisseur(bd)
        fourni.Owner = Me
        fourni.Show()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim com = New iCommande(noEmp, bd)
        com.Owner = Me
        com.Show()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim inv = New iInventaireComplet(bd, noEmp, noHotel)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim salle = New iGestionSalle(bd)
        salle.Owner = Me
        salle.Show()
    End Sub

    Private Sub MenuItem_Click_8(sender As Object, e As RoutedEventArgs)
        Dim hotel = New iGestionHotel(bd)
        hotel.Owner = Me
        hotel.Show()
    End Sub

    Private Sub MenuItem_Click_9(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(bd)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub MenuItem_Click_10(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCentrale(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_11(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmployeComplet(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_12(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_13(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeHotel(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub
End Class
