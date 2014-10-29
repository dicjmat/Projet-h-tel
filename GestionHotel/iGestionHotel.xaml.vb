Public Class iGestionHotel

    Private bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = _bd
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub windowGHotel_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowGHotel.Closing
        Me.Owner.Show()
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click

    End Sub

    Private Sub windowGHotel_Loaded(sender As Object, e As RoutedEventArgs) Handles windowGHotel.Loaded
        cbProvince.IsEnabled = False
        cbCodeVille.IsEnabled = False
        Dim pays = From pa In bd.tblPays
                   Select pa

        cbPays.ItemsSource = pays.ToList
    End Sub

    Private Sub cbPays_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbPays.SelectionChanged
        If cbPays.SelectedIndex <> -1 Then
            cbProvince.IsEnabled = True
            Dim pays As String = cbPays.SelectedItem.codePays
            Dim province = From pro In bd.tblProvince
                           Where pro.codePays = pays
                           Select pro

            cbProvince.ItemsSource = province.ToList
        End If
    End Sub

    Private Sub cbProvince_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbProvince.SelectionChanged
        If cbProvince.SelectedIndex <> -1 Then
            cbCodeVille.IsEnabled = True
            Dim province As String = cbProvince.SelectedItem.codeProv
            Dim ville = From vo In bd.tblVille
                        Where vo.codeProv = province
                        Select vo

            cbCodeVille.ItemsSource = ville.ToList
        End If

    End Sub
End Class
