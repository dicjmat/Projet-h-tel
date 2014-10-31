Public Class iGestionHotel

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private _noHotel As Short
    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, noHotel As Short)
        'modifier
        InitializeComponent()
        bd = _bd
        _noHotel = noHotel
        Dim pays = From pa In bd.tblPays
           Select pa

        cbPays.ItemsSource = pays.ToList

        btnAjouter.Visibility = Windows.Visibility.Hidden
        btnAjouter.IsEnabled = False
        btnModifier.Visibility = Windows.Visibility.Visible
        btnModifier.IsEnabled = True
        Dim hotel = From ho In bd.tblHotel
                    Where ho.noHotel = _noHotel
                    Select ho

        txtNomHotel.Text = hotel.Single.nomHotel
        txtAdrHotel.Text = hotel.Single.adrHotel
        txtTelHotel.Text = hotel.Single.noTelHotel
        noTelRes.Text = hotel.Single.noTelReserv
        txtNoteleC.Text = hotel.Single.noTelecopieur
        txtCodePostHo.Text = hotel.Single.codePostal

        For Each el In cbPays.Items
            If el.codePays = hotel.Single.tblVille.tblProvince.codePays Then
                cbPays.SelectedItem = el
                Exit For
            End If
        Next

        For Each el In cbProvince.Items
            If el.codeProv = hotel.Single.tblVille.codeProv Then
                cbProvince.SelectedItem = el
                Exit For
            End If
        Next

        For Each el In cbCodeVille.Items
            If el.codeVille = hotel.Single.codeVille Then
                cbCodeVille.SelectedItem = el
                Exit For
            End If
        Next
    End Sub

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = _bd

        cbProvince.IsEnabled = False
        cbCodeVille.IsEnabled = False
        btnAjouter.Visibility = Windows.Visibility.Visible
        btnAjouter.IsEnabled = True
        btnModifier.Visibility = Windows.Visibility.Hidden
        btnModifier.IsEnabled = False
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub windowGHotel_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowGHotel.Closing
        Me.Owner.Show()
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtNomHotel.Text <> "" And txtAdrHotel.Text <> "" And txtTelHotel.Text <> "" And noTelRes.Text <> "" And txtNoteleC.Text <> "" And txtCodePostHo.Text <> "" Then
            If cbPays.SelectedIndex <> -1 Then
                If cbProvince.SelectedIndex <> -1 Then
                    If cbCodeVille.SelectedIndex <> -1 Then
                        Dim hotel = New tblHotel
                        hotel.adrHotel = txtAdrHotel.Text
                        hotel.codePostal = txtCodePostHo.Text
                        hotel.codeVille = cbCodeVille.SelectedItem.codeVille
                        hotel.nomHotel = txtNomHotel.Text
                        hotel.noTelecopieur = txtNoteleC.Text
                        hotel.noTelHotel = txtTelHotel.Text
                        hotel.noTelReserv = noTelRes.Text
                        'hotel.codeProv = cbProvince.SelectedItem.codeProv
                        bd.tblHotel.Add(hotel)
                        bd.SaveChanges()
                        MessageBox.Show("L'hôtel a bien été créé")
                    Else
                        MessageBox.Show("Veuillez entrer une ville")
                    End If
                Else
                    MessageBox.Show("Veuillez choisir une province")
                End If

            Else
                MessageBox.Show("Veuillez choisir un pays")
            End If

        Else
            MessageBox.Show("Un des champs texte n'a pas été remplis")
        End If

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

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles btnModifier.Click
        If txtNomHotel.Text <> "" And txtAdrHotel.Text <> "" And txtTelHotel.Text <> "" And noTelRes.Text <> "" And txtNoteleC.Text <> "" And txtCodePostHo.Text <> "" Then
            If cbPays.SelectedIndex <> -1 Then
                If cbProvince.SelectedIndex <> -1 Then
                    If cbCodeVille.SelectedIndex <> -1 Then
                        Dim hotel = From ho In bd.tblHotel
                                    Where ho.noHotel = _noHotel
                                    Select ho
                        hotel.Single.adrHotel = txtAdrHotel.Text
                        hotel.Single.codePostal = txtCodePostHo.Text
                        hotel.Single.codeVille = cbCodeVille.SelectedItem.codeVille
                        hotel.Single.nomHotel = txtNomHotel.Text
                        hotel.Single.noTelecopieur = txtNoteleC.Text
                        hotel.Single.noTelHotel = txtTelHotel.Text
                        hotel.Single.noTelReserv = noTelRes.Text
                        'hotel.Single.codeProv = cbProvince.SelectedItem.codeProv
                        bd.SaveChanges()
                        MessageBox.Show("L'hôtel a bien été modifié")
                    Else
                        MessageBox.Show("Veuillez entrer une ville")
                    End If
                Else
                    MessageBox.Show("Veuillez choisir une province")
                End If

            Else
                MessageBox.Show("Veuillez choisir un pays")
            End If

        Else
            MessageBox.Show("Un des champs texte n'a pas été remplis")
        End If
    End Sub
End Class
