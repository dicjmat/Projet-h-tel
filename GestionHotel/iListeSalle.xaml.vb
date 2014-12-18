Public Class iListeSalle
    Private noHotel As Short
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noEmpl As Integer
    Dim item As String
    Dim p1 As Boolean
    Sub New(_noHotel As Short, _bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmpl As Integer)
        InitializeComponent()
        noHotel = _noHotel
        bd = _bd
        noEmpl = _noEmpl
        Dim res = From el In bd.tblLogin Where el.noEmpl = _noEmpl Select el

        If res.First.statut = "PATR" Then
            menuVente.Visibility = Windows.Visibility.Hidden
            menuVente.IsEnabled = False
        Else
            menu.Visibility = Windows.Visibility.Hidden
            menu.IsEnabled = False
        End If
    End Sub
    Private Sub windowListeSalle_Loaded(sender As Object, e As RoutedEventArgs) Handles windowListeSalle.Loaded
        Dim res = From el In bd.tblSalle Where el.noHotel = noHotel And el.codeTypeSalle = "REU" Select el
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
        Me.Owner.Show()
        Me.Close()

    End Sub

    Private Sub btnReservSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnReservSalle.Click
        If lstSalle.SelectedIndex <> -1 Then
            If dpDebutSalle.SelectedDate IsNot Nothing Then
                Dim numSalle = lstSalle.SelectedItem.noSalle
                Dim iReservSalle As New iListeClient(bd, noEmpl, noHotel, dpDebutSalle.SelectedDate, dpFinSalle.SelectedDate, lstSalle.SelectedItem.noSalle, True)
                iReservSalle.Owner = Me
                Me.Hide()
                iReservSalle.Show()
            Else
                MessageBox.Show("Veuillez sélectionner une date de début")
            End If
        Else
            MessageBox.Show("Veuillez sélectionner une salle")
        End If
    End Sub

    Private Sub dpDebutSalle_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles dpDebutSalle.SelectedDateChanged
        Dim dateDebut = dpDebutSalle.SelectedDate()
        Dim dateFin = Year(dateDebut).ToString() + "-" + Month(dateDebut).ToString() + "-" + (Day(dateDebut) + 1).ToString()
        dpFinSalle.SelectedDate = dateFin
    End Sub

    Private Sub dpFinSalle_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles dpFinSalle.SelectedDateChanged
        Dim dateDebut = dpDebutSalle.SelectedDate()
        If dpFinSalle.SelectedDate <= dateDebut Then
            MessageBox.Show("La date de fin doit être plus grande que la date de début", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
            dpFinSalle.SelectedDate = (Year(dateDebut).ToString() + "-" + Month(dateDebut).ToString() + "-" + (Day(dateDebut) + 1).ToString())
        End If
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim com = New iCommande(noEmpl, bd)
        com.Owner = Me.Owner
        com.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(bd, noHotel, noEmpl)
        fiche.Owner = Me.Owner
        fiche.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmployeComplet(bd, noEmpl, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjouterItem(item, bd)
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
        Dim inv = New iInventaireComplet(bd, noEmpl, noHotel)
        inv.Owner = Me.Owner
        inv.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_9(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionSalle(bd)
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
        Dim lst = New iListeCentrale(bd, noEmpl, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_12(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeHotel(bd, noEmpl, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_13(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(noHotel, bd, noEmpl)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjoutForf(p1, noHotel, bd)
        ajout.Owner = Me.Owner
        ajout.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim lst = New ListeForfait(noHotel, bd, noEmpl)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(noHotel, bd, noEmpl)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_14(sender As Object, e As RoutedEventArgs)
        Dim rab = New iRabais(noHotel, bd, noEmpl)
        rab.Owner = Me.Owner
        rab.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_15(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListePeriode(bd, noHotel, noEmpl)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub
End Class
