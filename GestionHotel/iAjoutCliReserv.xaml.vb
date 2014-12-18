Public Class iAjoutCliReserv
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noClient As String
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim reserv As tblReservation

    Sub New(_noEmp As Integer, _noHotel As Integer, maBD As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        btnModifier.Visibility = System.Windows.Visibility.Hidden
        noEmp = _noEmp
        noHotel = _noHotel
        bd = maBD
    End Sub

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _reserv As tblReservation)
        InitializeComponent()
        bd = maBD
        reserv = _reserv
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
            txtAdrCli.Text = res.Single.adrClient
            txtCelCli.Text = res.Single.noCellClient
            txtCodeExp.Text = res.Single.dateExpiration
            txtCommCli.Text = res.Single.commentaire
            txtNoCarteCredit.Text = res.Single.noCarteCredit
            txtNomCli.Text = res.Single.nomClient
            txtPrenCli.Text = res.Single.prenClient
            txtTelCli.Text = res.Single.noTelClient
            'txtCPCli.Text = res.Single.codePostalClient
            txtEmailCli.Text = res.Single.emailClient
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
        ElseIf reserv IsNot Nothing Then
            Dim cli = reserv.tblDemandeur
            txtAdrCli.Text = cli.adrDemandeur
            txtCelCli.Text = cli.noCellDemandeur
            txtCodeExp.Text = cli.dateExpiration
            txtCommCli.Text = cli.commentaire
            txtNoCarteCredit.Text = cli.noCarteCredit
            txtNomCli.Text = cli.nomDemandeur
            txtPrenCli.Text = cli.prenDemandeur
            txtTelCli.Text = cli.noTelDemandeur
            txtCPCli.Text = cli.codePostalDemandeur
            txtEmailCli.Text = cli.emailDemandeur
            Dim i = 0
            For Each el In cbCodePays.Items
                If el.codePays = cli.tblVille.tblProvince.codePays Then
                    cbCodePays.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
            i = 0
            For Each el In cbCodeProv.Items
                If el.codeProv = cli.codeProv Then
                    cbCodeProv.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
            i = 0
            For Each el In cbCodeVille.Items
                If el.codeVille = cli.codeVille Then
                    cbCodeVille.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
            i = 0
            For Each el In cbTypeCarte.Items
                If el.typeCarteCredit = cli.typeCarteCredit Then
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
            client.codePostalClient = txtCPCli.Text.Trim
            client.emailClient = txtEmailCli.Text.Trim
            client.noCarteCredit = txtNoCarteCredit.Text
            client.typeCarteCredit = cbTypeCarte.SelectedItem.typeCarteCredit
            client.dateExpiration = txtCodeExp.Text
            client.codeVille = cbCodeVille.SelectedItem.codeVille
            client.codeProv = cbCodeProv.SelectedItem.codeProv
            client.commentaire = txtCommCli.Text.Trim
            bd.tblClient.Add(client)
            bd.SaveChanges()
            MessageBox.Show("Le client a été ajouté avec succès.")
            If reserv IsNot Nothing Then
                reserv.noClient = client.noClient
                bd.tblDemandeur.Remove(reserv.tblDemandeur)
                bd.SaveChanges()
                Me.Owner.Owner.Hide()
                Me.Owner.Owner.Show()
                Me.Owner.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Veuillez remplir tous les champs.")
        End Try
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub
    'Private Sub btnFicheC_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheC.Click
    '    Dim fiche = New iAjoutCliReserv(noEmp, noHotel, bd)
    '    fiche.Owner = Me
    '    fiche.Show()
    'End Sub

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

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim check = New iCheck_in_out(bd, noEmp, noHotel)
        check.Owner = Me
        check.Show()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim facture = New iFacture(bd, noEmp, noHotel)
        facture.Owner = Me
        facture.Show()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeClient
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim reserv = New iFaireReservationChambre(bd, noEmp, noHotel)
        reserv.Owner = Me
        reserv.Show()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim ficheR = New iFicheReserv(bd, noEmp, noHotel)
        ficheR.Owner = Me
        ficheR.Show()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim ficheRF = New iFicheReservFacture(bd, noEmp, noHotel)
        ficheRF.Owner = Me
        ficheRF.Show()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeReservComplet(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub
End Class
