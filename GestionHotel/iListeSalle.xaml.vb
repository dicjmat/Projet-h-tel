Public Class iListeSalle
    Private noHotel As Short
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noEmpl As Integer
    Sub New(_noHotel As Short, _bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmpl As Integer)
        InitializeComponent()
        noHotel = _noHotel
        bd = _bd
        noEmpl = _noEmpl
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
End Class
