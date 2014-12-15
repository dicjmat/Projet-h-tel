Public Class iConsulterHoraire

    Private _numEmpl As Integer
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noGest As Short
    Private nohotel As Integer

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities, _noGest As Short, _nohotel As Integer)
        InitializeComponent()
        bd = maBd
        noGest = _noGest
        nohotel = _nohotel
        requete()
        remplirNom()
        Dim res = From el In bd.tblLogin Where el.noEmpl = _numEmpl Select el

        If res.First.statut = "GEST" Then
            menu.Visibility = Windows.Visibility.Hidden
            menu.IsEnabled = False
        Else
            menuGerant.Visibility = Windows.Visibility.Hidden
            menuGerant.IsEnabled = False
        End If
    End Sub

    Sub New(numEmpl As Object, maBd As P2014_Equipe2_GestionHôtelièreEntities, _noGest As Short, _noHotel As Integer)
        InitializeComponent()
        _numEmpl = numEmpl
        nohotel = _noHotel
        bd = maBd
        noGest = _noGest
        requete()
        remplirNom()
        Dim res = From el In bd.tblLogin Where el.noEmpl = _numEmpl Select el

        If res.First.statut = "GEST" Then
            menu.Visibility = Windows.Visibility.Hidden
            menu.IsEnabled = False
        Else
            menuGerant.Visibility = Windows.Visibility.Hidden
            menuGerant.IsEnabled = False
        End If
    End Sub


    Private Sub requete()
        If cbNomEmp.SelectedIndex <> -1 Then
            Dim nEmpl As Integer = cbNomEmp.SelectedItem.noEmpl
            Dim res = From ho In bd.tblHoraire
                      Where ho.noEmpl = nEmpl And ho.dateHoraire.ToString.StartsWith(txtRecherche.Text)
                      Select ho.heureDebut, ho.heureFin, dateHoraire = ho.dateHoraire.ToString.Substring(0, 10)

            dgHoraire.ItemsSource = res.ToList
        End If
    End Sub

    Private Sub remplirNom()
        Dim empl = From em In bd.tblEmploye Where em.noEmpl = noGest Select em
        Dim hotel As Integer = empl.Single.noHotel
        Dim prof As String = empl.Single.codeProf


        Dim res = From em In bd.tblEmploye
                  Where em.noHotel = hotel And em.codeProf = prof
                  Select nomEmpl = em.prenEmpl & " " & em.nomEmpl, em.noEmpl

        cbNomEmp.ItemsSource = res.ToList
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
        Me.Owner.Show()
    End Sub

    Private Sub cbNomEmp_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbNomEmp.SelectionChanged
        If cbNomEmp.SelectedIndex <> -1 Then
            requete()
        End If
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjouterHoraire(_numEmpl, bd)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(bd)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmploye(_numEmpl, nohotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCOmmande(_numEmpl, nohotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjouterItem(bd, noGest, nohotel)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjoutFournisseur(bd)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim inv = New iInventaire(_numEmpl, nohotel, bd)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim com = New iCommande(_numEmpl, bd)
        com.Owner = Me
        com.Show()
    End Sub
End Class
