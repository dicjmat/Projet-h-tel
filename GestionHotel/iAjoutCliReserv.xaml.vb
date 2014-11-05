Public Class iAjoutCliReserv
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noClient As String
    Dim noEmp As Integer
    Dim noHotel As Integer
    Sub New(_noEmp As Integer, _noHotel As Integer)
        ' TODO: Complete member initialization 
        InitializeComponent()
        btnModifier.Visibility = System.Windows.Visibility.Hidden
        noEmp = _noEmp
        noHotel = _noHotel

    End Sub
    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _nomClient As String, _prenClient As String, _noTel As String, _noCell As String, _adr As String, _noCarte As String, _type As String, _dateEx As String, _noClient As String, _noEmp As Integer, _noHotel As Integer)
        ' TODO: Complete member initialization 
        InitializeComponent()
        bd = maBD
        noEmp = _noEmp
        noHotel = _noHotel
        noClient = _noClient
        txtNomCli.Text = _nomClient
        txtPrenCli.Text = _prenClient
        txtTelCli.Text = _noTel
        txtCelCli.Text = _noCell
        txtAdrCli.Text = _adr
        txtNoCarteCredit.Text = _noCarte
        cbTypeCarte.SelectedItem = _type
        txtCodeExp.Text = _dateEx
        btnAjouterCli.Visibility = System.Windows.Visibility.Hidden
    End Sub
    Private Sub window_AjoutCliReserv_Loaded(sender As Object, e As RoutedEventArgs) Handles window_AjoutCliReserv.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From cli In bd.tblClient
                  Group cli By cli.typeCarteCredit Into Group
                  Select Group.FirstOrDefault()
        Dim res2 = From el In bd.tblVille Select el

        cbTypeCarte.DataContext = res.ToList()
        cbCodeVille.DataContext = res2.Distinct().ToList()

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
        'Dim accueil = New iFaireReservation
        'accueil.Owner = Me
        'accueil.Show()
        Me.Close()
    End Sub
    Private Sub btnCheck_Click(sender As Object, e As RoutedEventArgs) Handles btnCheck.Click
        Dim check = New iCheck_in_out()
        check.Owner = Me
        check.Show()
    End Sub

    Private Sub btnReservC_Click(sender As Object, e As RoutedEventArgs) Handles btnReservC.Click
        Dim reserv = New iFaireReservation(bd, noEmp, noHotel)
        reserv.Owner = Me
        reserv.Show()
    End Sub

    Private Sub btnFact_Click(sender As Object, e As RoutedEventArgs) Handles btnFact.Click
        Dim facture = New iFacture
        facture.Owner = Me
        facture.Show()
    End Sub

    Private Sub btnFicheC_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheC.Click
        Dim fiche = New iFicheClient
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub btnFicheReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReserv.Click
        Dim ficheR = New iFicheReserv
        ficheR.Owner = Me
        ficheR.Show()
    End Sub

    Private Sub btnFicheReservF_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReservF.Click
        Dim ficheRF = New iFicheReservFacture
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
End Class
