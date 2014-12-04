Public Class iCommunique
    Private _noHotel As Short
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities
    Private _noEmpl As Short

    Sub New(noEmpl As Short, noHotel As Short, _maBd As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization
        InitializeComponent()
        _noEmpl = noEmpl
        _noHotel = noHotel
        maBd = _maBd
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub

    Private Sub requete()
        Dim res = From el In maBd.tblCommunique
                  Where _noHotel = el.noHotel And (el.titreCommunique.StartsWith(txtRecherche.Text) Or el.etatCommunique.StartsWith(txtRecherche.Text))
                  Select el

        dgCommuni.ItemsSource = res.ToList
    End Sub

    Private Sub Window_Activated(sender As Object, e As EventArgs)
        requete()
    End Sub

    Private Sub dgCommuni_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgCommuni.SelectionChanged
        If dgCommuni.SelectedIndex <> -1 Then
            txtCommuni.Text = dgCommuni.SelectedItem.contCommunique
        End If
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub btnSupprimerCommuni_Click(sender As Object, e As RoutedEventArgs) Handles btnSupprimerCommuni.Click
        If dgCommuni.SelectedIndex <> 0 Then
            Dim noCommu As Integer = dgCommuni.SelectedItem.noCommunique
            Dim res = From co In maBd.tblCommunique
                      Where co.noCommunique = noCommu
                      Select co
            maBd.tblCommunique.Remove(res.Single)
            Dim maxi = From commu In maBd.tblCommunique
                       Select commu.noCommunique
            maBd.SaveChanges()
            maBd.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Personnel.tblCommunique',RESEED," + maxi.ToList.Last.ToString + ")")
            maBd.SaveChanges()
            requete()
            txtCommuni.Text = ""
            MessageBox.Show("Le communiqué a bien été supprimé")
        Else
            MessageBox.Show("Veuillez choisir le communiqué que vous voulez supprimer")
        End If
    End Sub

    Private Sub btnAjouterCommuni_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterCommuni.Click
        Dim ajoutCommu = New iAjouterCommunique(maBd, _noHotel)
        ajoutCommu.Owner = Me
        ajoutCommu.ShowDialog()
    End Sub

    Private Sub btnModifierCommuni_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierCommuni.Click
        If dgCommuni.SelectedIndex <> -1 Then
            Dim ajoutCommu = New iAjouterCommunique(maBd, _noHotel, dgCommuni.SelectedItem.noCommunique)
            ajoutCommu.Owner = Me
            ajoutCommu.ShowDialog()
        Else
            MessageBox.Show("Veuillez choisir le communiqué que vous désirez modifier")
        End If

    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(maBd)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim horaire = New iAjouterHoraire(_noEmpl, _noHotel, maBd)
        horaire.Owner = Me
        horaire.Show()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmploye(_noEmpl, _noHotel, maBd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim com = New iListeCOmmande(_noEmpl, _noHotel, maBd)
        com.Owner = Me
        com.Show()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim com = New iCommunique(_noEmpl, _noHotel, maBd)
        com.Owner = Me
        com.Show()
    End Sub
End Class
