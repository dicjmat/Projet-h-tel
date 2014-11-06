Public Class iAjoutCliReserv
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noClient As String
    Dim noEmp As Integer
    Dim noHotel As Integer
    Sub New(_noEmp As Integer, _noHotel As Integer, maBD As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        btnModifier.Visibility = System.Windows.Visibility.Hidden
        noEmp = _noEmp
        noHotel = _noHotel
        bd = maBD
    End Sub

    Sub New(vente As Boolean)
        InitializeComponent()
        Menu.Visibility = Windows.Visibility.Hidden
    End Sub

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noClient As String, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = maBD
        noEmp = _noEmp
        noHotel = _noHotel
        noClient = _noClient
        btnAjouterCli.Visibility = System.Windows.Visibility.Hidden
    End Sub
    Private Sub window_AjoutCliReserv_Loaded(sender As Object, e As RoutedEventArgs) Handles window_AjoutCliReserv.Loaded
        cbCodeProv.IsEnabled = False
        cbCodeVille.IsEnabled = False
        Dim pays = From pa In bd.tblPays Select pa
        cbCodePays.ItemsSource = pays.ToList()
        Dim cred = From cli In bd.tblClient
                  Group cli By cli.typeCarteCredit Into Group
                  Select Group.FirstOrDefault()
        cbTypeCarte.ItemsSource = cred.ToList()
        If noClient <> 0 Then
            Dim res = From el In bd.tblClient Where el.noClient = noClient Select el
            Me.DataContext = res.ToList()
            Dim i = 0
            For Each el In cbCodePays.Items
                If el.codePays = res.First.tblVille.tblProvince.codePays Then
                    cbCodePays.SelectedIndex = i
                    Exit For
                    End If
                i = i + 1
            Next
            i = 0
            For Each el In cbCodeProv.Items
                If el.codeProv = res.First.codeProv Then
                    cbCodeProv.SelectedIndex = i
                    Exit For
                    End If
                i = i + 1
            Next
            i = 0
            For Each el In cbCodeVille.Items
                If el.codeVille = res.First.codeVille Then
                    cbCodeVille.SelectedIndex = i
                    Exit For
                    End If
                i = i + 1
            Next
            i = 0
            For Each el In cbTypeCarte.Items
                If el.typeCarteCredit = res.First.typeCarteCredit Then
                    cbTypeCarte.SelectedIndex = i
                    Exit For
                    End If
                i = i + 1
            Next
            End If
    End Sub

    Private Sub btnAjouterCli_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterCli.Click
        Try
            Dim client As New tblClient
            client.nomClient = txtNomCli.Text.Trim
            client.prenClient = txtPrenCli.Text.Trim
            client.noTelClient = txtTelCli.Text
            client.noCellClient = txtCelCli.Text
            client.adrClient = txtAdrCli.Text.Trim
            client.noCarteCredit = txtNoCarteCredit.Text
            client.typeCarteCredit = cbTypeCarte.SelectedItem.typeCarteCredit
            client.dateExpiration = txtCodeExp.Text
            client.codeVille = cbCodeVille.SelectedItem.codeVille
            client.commentaire = txtCommCli.Text.Trim
            bd.tblClient.Add(client)
            bd.SaveChanges()
            MessageBox.Show("Le client a été ajouté avec succès.")
        Catch ex As Exception
            MessageBox.Show("Veuillez remplir tous les champs.")
        End Try


    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Dim reserv = New iFaireReservationChambre(bd, noEmp, noHotel)
        reserv.Owner = Me
        reserv.Show()
        Me.Close()
    End Sub
    Private Sub btnCheck_Click(sender As Object, e As RoutedEventArgs) Handles btnCheck.Click
        Dim check = New iCheck_in_out(bd, noEmp, noHotel)
        check.Owner = Me
        check.Show()
    End Sub

    Private Sub btnReservC_Click(sender As Object, e As RoutedEventArgs) Handles btnReservC.Click
        Dim reserv = New iFaireReservationChambre(bd, noEmp, noHotel)
        reserv.Owner = Me
        reserv.Show()
    End Sub

    Private Sub btnFact_Click(sender As Object, e As RoutedEventArgs) Handles btnFact.Click
        Dim facture = New iFacture(bd, noEmp, noHotel)
        facture.Owner = Me
        facture.Show()
    End Sub

    Private Sub btnFicheC_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheC.Click
        Dim fiche = New iAjoutCliReserv(noEmp, noHotel, bd)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub btnFicheReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReserv.Click
        Dim ficheR = New iFicheReserv(bd, noEmp, noHotel)
        ficheR.Owner = Me
        ficheR.Show()
    End Sub

    Private Sub btnFicheReservF_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReservF.Click
        Dim ficheRF = New iFicheReservFacture(bd, noEmp, noHotel)
        ficheRF.Owner = Me
        ficheRF.Show()
    End Sub

    Private Sub btnListeCli_Click(sender As Object, e As RoutedEventArgs) Handles btnListeCli.Click
        Dim lst = New iListeClient
        lst.owner = Me
        lst.Show()
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles btnModifier.Click
        Try
            Dim client As New tblClient
            client.noClient = noClient
            client.nomClient = txtNomCli.Text.Trim
            client.prenClient = txtPrenCli.Text.Trim
            client.noTelClient = txtTelCli.Text
            client.noCellClient = txtCelCli.Text
            client.adrClient = txtAdrCli.Text.Trim
            client.noCarteCredit = txtNoCarteCredit.Text
            client.typeCarteCredit = cbTypeCarte.SelectedItem.typeCarteCredit
            client.dateExpiration = txtCodeExp.Text
            client.codeVille = cbCodeVille.SelectedItem.codeVille
            client.commentaire = txtCommCli.Text.Trim
            bd.SaveChanges()
            MessageBox.Show("Le client a été modifié avec succès.")
        Catch ex As Exception
            MessageBox.Show("Veuillez remplir tous les champs.")
        End Try
    End Sub

    Private Sub cbCodePays_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbCodePays.SelectionChanged
        If cbCodePays.SelectedIndex <> -1 Then
            cbCodeProv.IsEnabled = True
            Dim sPays As String = cbCodePays.SelectedItem.codePays
            Dim province = From pro In bd.tblProvince Where pro.codePays = sPays Select pro
            cbCodeProv.ItemsSource = province.ToList
        End If
    End Sub

    Private Sub cbCodeProv_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbCodeProv.SelectionChanged
        If cbCodeProv.SelectedIndex <> -1 Then
            cbCodeVille.IsEnabled = True
            Dim sProv As String = cbCodeProv.SelectedItem.codeProv
            Dim ville = From vi In bd.tblVille Where vi.codeProv = sProv Select vi
            cbCodeVille.ItemsSource = ville.ToList
        End If
    End Sub
End Class
