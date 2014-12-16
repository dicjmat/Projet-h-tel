Public Class iListeEmployeComplet
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim item As String

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = _bd
        noEmp = _noEmp
        noHotel = _noHotel
    End Sub

    Private Sub btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles btnAjout.Click
        Dim emp = New iFicheEmploye(bd, noHotel, noEmp)
        emp.Owner = Me
        emp.Show()
        Me.Hide()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub window_lstEmployeComplet_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstEmployeComplet.Loaded
        Me.Owner.Hide()
        Dim hotel = From ho In bd.tblHotel
                    Select ho
        cbHotel.DataContext = hotel.ToList
        requete()
    End Sub

    Private Sub requete()
        If cbHotel.SelectedIndex <> -1 Then
            Dim hotel As Integer = cbHotel.SelectedItem.noHotel
            Dim res = From el In bd.tblEmploye
                      Where el.noHotel = hotel And (el.noEmpl.ToString.StartsWith(txtRecherche.Text) Or (el.nomEmpl + " " + el.prenEmpl).StartsWith(txtRecherche.Text) Or (el.prenEmpl + " " + el.nomEmpl).StartsWith(txtRecherche.Text) Or el.codeProf.StartsWith(txtRecherche.Text))
                      Select el

            dgEmploye.ItemsSource = res.ToList()
        End If
    End Sub

    Private Sub cbHotel_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbHotel.SelectionChanged
        requete()
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub

    Private Sub btnModif_Click(sender As Object, e As RoutedEventArgs) Handles btnModif.Click
        If dgEmploye.SelectedIndex <> -1 Then
            Dim numEmpl = dgEmploye.SelectedItem.noEmpl
            Dim iEmploye As New iFicheEmploye(noEmp, noHotel, numEmpl, bd)
            iEmploye.Owner = Me
            Me.Hide()
            iEmploye.Show()
        Else
            MessageBox.Show("Veuillez sélectionner un employé")
        End If
    End Sub

    Private Sub window_lstEmployeComplet_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_lstEmployeComplet.Closing
        Me.Owner.Show()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmployeComplet(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjouterItem(bd, noEmp, noHotel)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjoutFournisseur(bd)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub MenuItem_Click_8(sender As Object, e As RoutedEventArgs)
        Dim inv = New iInventaireComplet(bd, noEmp, noHotel)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub MenuItem_Click_9(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionSalle(bd)
        gest.Owner = Me
        gest.Show()
    End Sub

    Private Sub MenuItem_Click_10(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionHotel(bd)
        gest.Owner = Me
        gest.Show()
    End Sub

    Private Sub MenuItem_Click_11(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCentrale(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_12(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeHotel(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_13(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeReservComplet(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub
End Class
