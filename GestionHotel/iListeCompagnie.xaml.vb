Public Class iListeCompagnie

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noEmp As Short
    Private noHotel As Short

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities, noEmploye As Short, _noHotel As Short)
        InitializeComponent()
        bd = maBd
        noEmp = noEmploye
        noHotel = _noHotel
        requete()
    End Sub

    Private Sub btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles btnAjout.Click
        Dim comp = New iFicheCompagnie(bd)
        comp.Owner = Me
        comp.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub btnModif_Click(sender As Object, e As RoutedEventArgs) Handles btnModif.Click
        If dgCompagnie.SelectedIndex <> -1 Then
            Dim comp = New iFicheCompagnie(bd, dgCompagnie.SelectedItem.noCompagnie)
            comp.Owner = Me
            comp.Show()
        Else
            MessageBox.Show("Vous devez sélectionnez une compagnie")
        End If
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmployeComplet(bd, noEmp, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjouterItem(bd, noEmp, noHotel)
        ajout.Owner = Me.Owner
        ajout.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjoutFournisseur(bd)
        ajout.Owner = Me.Owner
        ajout.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_8(sender As Object, e As RoutedEventArgs)
        Dim inv = New iInventaireComplet(bd, noEmp, noHotel)
        inv.Owner = Me.Owner
        inv.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_9(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionSalle(bd, noHotel)
        gest.Owner = Me.Owner
        gest.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_10(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionHotel(bd)
        gest.Owner = Me.Owner
        gest.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_11(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCentrale(bd, noEmp, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_12(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeHotel(bd, noEmp, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_13(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeReservComplet(bd, noEmp, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub

    Private Sub requete()
        Dim res = From co In bd.tblCompagnie
                  Where co.respCompagnie.StartsWith(txtRecherche.Text) Or co.nomCompagnie.StartsWith(txtRecherche.Text) Or co.noCompagnie.ToString.StartsWith(txtRecherche.Text) Or co.noTelCompagnie.StartsWith(txtRecherche.Text)
                  Select co

        dgCompagnie.ItemsSource = res.ToList
    End Sub
End Class
