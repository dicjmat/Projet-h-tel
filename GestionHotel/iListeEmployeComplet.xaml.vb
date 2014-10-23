Public Class iListeEmployeComplet
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization 
        InitializeComponent()
        bd = _bd
    End Sub

    Private Sub btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles btnAjout.Click
        Dim emp = New iFicheEmploye(bd)
        emp.Owner = Me
        emp.Show()
        Me.Hide()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub window_lstEmployeComplet_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstEmployeComplet.Loaded
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

            'el.noEmpl, el.nomEmpl, el.prenEmpl, el.codeProf
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
            Dim iEmploye As New iFicheEmploye(numEmpl, bd)
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
End Class
