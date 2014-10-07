Public Class iAjouterHoraire
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noGest As Short
    Private hotel As Short
    Sub New(_noGestionnaire As Short)
        InitializeComponent()

    End Sub
    Sub New(_noGestionnaire As Short, _noHotel As Short)
        InitializeComponent()
        noGest = _noGestionnaire
        hotel = _noHotel
    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim profGest = From el In bd.tblEmploye Where noGest = el.noEmpl Select el.codeProf
        Dim prof = profGest.Single.ToString()
        Dim res = From el In bd.tblEmploye Where el.codeProf = prof And el.noHotel = hotel Select el

        cbEmploye.DataContext = res.ToList()
    End Sub

    Private Sub btnRetour_Click(sender As Object, e As RoutedEventArgs) Handles btnRetour.Click
        Me.Focusable = False
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
        If cbEmploye.SelectedItem IsNot DBNull.Value And cldHoraire.SelectedDate IsNot Nothing And cmbHeureDebut.SelectedItem IsNot DBNull.Value Then
            Dim Horaire = New tblHoraire()
            Horaire.noEmpl = Convert.ToInt16(cbEmploye.SelectedItem.noEmpl)
            Horaire.dateHoraire = Format(cldHoraire.SelectedDate(), "yyyy/MM/dd")
            Horaire.heureDebut = Convert.ToTime(Replace(cmbHeureDebut.SelectedItem.Content, "h", ":"))
            Horaire.heureFin = Convert.ToDateTime(Replace(cmbHeureFin.SelectedItem.Content, "h", ":"))
            bd.tblHoraire.Add(Horaire)
            bd.SaveChanges()
            lblConfirmation.Content = "L'horaire est ajouté"
            lblConfirmation.Visibility = Windows.Visibility.Visible
        Else
            lblConfirmation.Content = "Des informations sont manquantes"
            lblConfirmation.Visibility = Windows.Visibility.Visible
        End If
    End Sub

    Private Sub cmbHeureDebut_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbHeureDebut.SelectionChanged
        Dim temp As Integer
        Dim Debut = cmbHeureDebut.SelectedIndex()
        If Debut > 15 Then
            temp = Debut - 16
            cmbHeureFin.SelectedIndex = temp
        End If
        cmbHeureFin.SelectedIndex = Debut + 8
    End Sub

    Private Sub cldHoraire_SelectedDatesChanged(sender As Object, e As SelectionChangedEventArgs) Handles cldHoraire.SelectedDatesChanged

    End Sub

    Private Sub btnModifierHor_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierHor.Click

    End Sub
End Class
