Public Class iAjouterHoraire
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noGest As Short
    Private hotel As Short
    Private numEmpl As Short

    Sub New(noEmpl As Short, noHotel As Short, maBd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        noGest = noEmpl
        hotel = noHotel
        bd = maBd

        Dim profGest = From el In bd.tblEmploye Where noGest = el.noEmpl Select el.codeProf
        Dim prof = profGest.Single.ToString()
        Dim res = From el In bd.tblEmploye Where el.codeProf = prof And el.noHotel = hotel And el.noEmpl <> noGest Select el

        cbEmploye.DataContext = res.ToList()
    End Sub

    Sub New(_noEmpl As Integer, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization
        InitializeComponent()
        bd = _bd
        numEmpl = _noEmpl

        Dim res = From el In bd.tblEmploye Where el.noEmpl = numEmpl Select el

        cbEmploye.DataContext = res.ToList()
        cbEmploye.SelectedIndex = 0
        cbEmploye.IsEnabled = False
    End Sub

    Private Sub btnRetour_Click(sender As Object, e As RoutedEventArgs) Handles btnRetour.Click
        Me.Close()
    End Sub

    Private Sub windowAjoutHoraire_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowAjoutHoraire.Closing
        If Me.Focusable Then
            Me.Owner.Close()
        Else
            Me.Owner.Show()
        End If
    End Sub

    Private Sub btnAjouterHor_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterHor.Click
        If cbEmploye.SelectedItem IsNot Nothing And cldHoraire.SelectedDate IsNot Nothing And cmbHeureDebutH.SelectedItem IsNot Nothing And cmbHeureDebutM.SelectedItem IsNot Nothing Then
            If cldHoraire.SelectedDates.Count > 1 Then
                For Each el As Date In cldHoraire.SelectedDates
                    Dim Horaire = New tblHoraire()
                    Horaire.noEmpl = Convert.ToInt16(cbEmploye.SelectedItem.noEmpl)
                    Horaire.dateHoraire = Format(el, "yyyy/MM/dd")
                    Horaire.heureDebut = TimeSpan.Parse(cmbHeureDebutH.SelectedItem.Content + ":" + cmbHeureDebutM.SelectedItem.Content)
                    Horaire.heureFin = TimeSpan.Parse(cmbHeureFinH.SelectedItem.Content + ":" + cmbHeureFinM.SelectedItem.Content)
                    bd.tblHoraire.Add(Horaire)
                    bd.SaveChanges()
                Next
            Else
                Dim Horaire = New tblHoraire()
                Horaire.noEmpl = Convert.ToInt16(cbEmploye.SelectedItem.noEmpl)
                Horaire.dateHoraire = Format(cldHoraire.SelectedDate(), "yyyy/MM/dd")
                Horaire.heureDebut = TimeSpan.Parse(cmbHeureDebutH.SelectedItem.Content + ":" + cmbHeureDebutM.SelectedItem.Content)
                Horaire.heureFin = TimeSpan.Parse(cmbHeureFinH.SelectedItem.Content + ":" + cmbHeureFinM.SelectedItem.Content)
                bd.tblHoraire.Add(Horaire)
                bd.SaveChanges()
                lblConfirmation.Content = "L'horaire est ajouté"
                lblConfirmation.Visibility = Windows.Visibility.Visible
            End If
        Else
            lblConfirmation.Content = "Des informations sont manquantes"
            lblConfirmation.Visibility = Windows.Visibility.Visible
        End If
    End Sub

    Private Sub cmbHeureDebutH_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbHeureDebutH.SelectionChanged
        Dim temp As Integer
        Dim Debut = cmbHeureDebutH.SelectedIndex()
        If Debut > 15 Then
            temp = Debut - 16
            cmbHeureFinH.SelectedIndex = temp
        End If
        cmbHeureFinH.SelectedIndex = Debut + 8
        cmbHeureDebutM.SelectedIndex = 0
    End Sub

    Private Sub cldHoraire_SelectedDatesChanged(sender As Object, e As SelectionChangedEventArgs) Handles cldHoraire.SelectedDatesChanged
        If cbEmploye.SelectedItem IsNot Nothing Then
            Dim numEmpl As Integer = cbEmploye.SelectedItem.noEmpl
            Dim dateSaisi = cldHoraire.SelectedDate
            Dim res = From el In bd.tblHoraire Where el.noEmpl = numEmpl And el.dateHoraire = dateSaisi Select el
            If res.ToList().Count <> 0 Then
                btnAjouterHor.IsEnabled = False
                cmbHeureDebutH.SelectedIndex = res.First.heureDebut.Hours
                cmbHeureDebutM.SelectedIndex = res.First.heureDebut.Minutes / 15
                cmbHeureFinH.SelectedIndex = res.First.heureFin.Hours
                cmbHeureFinM.SelectedIndex = res.First.heureFin.Minutes / 15
            Else
                btnAjouterHor.IsEnabled = True
                cmbHeureDebutH.SelectedIndex = -1
                cmbHeureDebutM.SelectedIndex = -1
                cmbHeureFinH.SelectedIndex = -1
                cmbHeureFinM.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub btnModifierHor_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierHor.Click
        If cbEmploye.SelectedItem IsNot Nothing And cldHoraire.SelectedDate IsNot Nothing And cmbHeureDebutH.SelectedItem IsNot Nothing And cmbHeureDebutM.SelectedItem IsNot Nothing Then
            Dim numeroEmpl As Integer = cbEmploye.SelectedItem.noEmpl
            Dim Horaire As tblHoraire
            If cldHoraire.SelectedDates.Count > 1 Then
                For Each sel As Date In cldHoraire.SelectedDates
                    Horaire = (From el In bd.tblHoraire Where el.noEmpl = numeroEmpl And el.dateHoraire = sel Select el).Single()
                    Horaire.heureDebut = TimeSpan.Parse(cmbHeureDebutH.SelectedItem.Content + ":" + cmbHeureDebutM.SelectedItem.Content)
                    Horaire.heureFin = TimeSpan.Parse(cmbHeureFinH.SelectedItem.Content + ":" + cmbHeureFinM.SelectedItem.Content)
                    bd.SaveChanges()
                Next
            Else
                Horaire = (From el In bd.tblHoraire Where el.noEmpl = numeroEmpl And el.dateHoraire = cldHoraire.SelectedDate Select el).Single()
                Horaire.heureDebut = TimeSpan.Parse(cmbHeureDebutH.SelectedItem.Content + ":" + cmbHeureDebutM.SelectedItem.Content)
                Horaire.heureFin = TimeSpan.Parse(cmbHeureFinH.SelectedItem.Content + ":" + cmbHeureFinM.SelectedItem.Content)
                bd.SaveChanges()
            End If
            lblConfirmation.Content = "L'horaire a été modifié"
            lblConfirmation.Visibility = Windows.Visibility.Visible
        End If

    End Sub

    Private Sub cmbHeureDebutM_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbHeureDebutM.SelectionChanged
        cmbHeureFinM.SelectedIndex = cmbHeureDebutM.SelectedIndex
    End Sub

    Private Sub btnFicheEmploye_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheEmploye.Click
        Dim fiche = New iFicheEmploye(bd)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub btnListeEmp_Click(sender As Object, e As RoutedEventArgs) Handles btnListeEmp.Click
        Dim lst = New iListeEmploye(noGest, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnListeCommande_Click(sender As Object, e As RoutedEventArgs) Handles btnListeCommande.Click
        Dim lst = New iListeCOmmande(noGest, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnCommuni_Click(sender As Object, e As RoutedEventArgs) Handles btnCommuni.Click
        Dim lst = New iCommunique(numEmpl, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub
End Class
