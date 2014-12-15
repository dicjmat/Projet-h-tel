Public Class iListeFacture
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noEmpl As Integer
    Private noHotel As Integer
    Private note As tblNote

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmpl As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = _bd
        noEmpl = _noEmpl
        noHotel = _noHotel
        btnAjouterNote.Visibility = Windows.Visibility.Hidden
        btnAjouterNote.IsEnabled = False
    End Sub

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmpl As Integer, _noHotel As Integer, _Note As tblNote)
        InitializeComponent()
        bd = _bd
        noEmpl = _noEmpl
        noHotel = _noHotel
        note = _Note
        btnAjouterNote.Visibility = Windows.Visibility.Visible
        btnAjouterNote.IsEnabled = True
    End Sub

    Private Sub window_ListeFacture_Loaded(sender As Object, e As RoutedEventArgs) Handles window_ListeFacture.Loaded
        sourceFacture()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub btnAjouterFact_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterFact.Click
        Dim facture = New tblFacture()
        facture.dateFacture = Date.Today
        facture.etatFacture = "paspayé"
        facture.noHotel = noHotel
        bd.tblFacture.Add(facture)
        bd.SaveChanges()
        MessageBox.Show("Numéro de la nouvelle facture : " + facture.noFacture.ToString(), "Confirmation", MessageBoxButton.OK, MessageBoxImage.None)
        sourceFacture()
    End Sub

    Private Sub btnConsultFact_Click(sender As Object, e As RoutedEventArgs) Handles btnConsultFact.Click
        If dgListeFact.SelectedItem IsNot Nothing Then
            Dim factNote = New iFactureNote(bd, noEmpl, noHotel, dgListeFact.SelectedItem.noFacture)
            factNote.Owner = Me
            factNote.Show()
        Else
            MessageBox.Show("Veuillez choisir une facture", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnAjouterNote_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterNote.Click
        If dgListeFact.SelectedItem IsNot Nothing Then
            Dim facture = dgListeFact.SelectedItem.noFacture
            note.noFacture = facture
            note.etatNote = "Réglé"
            bd.SaveChanges()
        Else
            MessageBox.Show("Veuillez choisir une facture", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub sourceFacture()
        Dim res = From el In bd.tblFacture Where el.noHotel = noHotel Select el

        dgListeFact.ItemsSource = res.ToList()
    End Sub

    Private Sub window_ListeFacture_Activated(sender As Object, e As EventArgs) Handles window_ListeFacture.Activated
        sourceFacture()
    End Sub
End Class
