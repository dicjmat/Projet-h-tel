Public Class iFicheClient
    Dim db As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        db = maBD
        noEmp = _noEmp
        noHotel = _noHotel

    End Sub
    Private Sub windowFicheCli_Loaded(sender As Object, e As RoutedEventArgs) Handles windowFicheCli.Loaded
        db = New P2014_Equipe2_GestionHôtelièreEntities
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        'Sauvegarder
        Dim Client = New tblClient
        Client.nomClient = txtNomCli.Text
        Client.prenClient = txtPrenCli.Text
        Client.noTelClient = txtNoTellCli.Text
        Client.noCellClient = txtNoCellCli.Text
        Client.adrClient = txtAdrCli.Text
        Client.noCarteCredit = txtCarteCreditCli.Text
        Client.typeCarteCredit = cbTypeCarte.SelectedItem
        Client.dateExpiration = txtCodeExp.Text
        Client.codeVille = cbCodeVille.SelectedItem
        Client.commentaire = txtCommCli.Text
        db.tblClient.Add(Client)
        db.SaveChanges()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Dim reserv = New iFaireReservationChambre(db, noEmp, noHotel)
        reserv.Owner = Me
        reserv.Show()
        Me.Close()
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As RoutedEventArgs) Handles btnCheck.Click
        Dim check = New iCheck_in_out(db, noEmp, noHotel)
        check.Owner = Me
        check.Show()
    End Sub

    Private Sub btnReservC_Click(sender As Object, e As RoutedEventArgs) Handles btnReservC.Click
        Dim reserv = New iFaireReservationChambre(db, noEmp, noHotel)
        reserv.Owner = Me
        reserv.Show()
    End Sub

    Private Sub btnFact_Click(sender As Object, e As RoutedEventArgs) Handles btnFact.Click
        Dim facture = New iFacture(db, noEmp, noHotel)
        facture.Owner = Me
        facture.Show()
    End Sub

    Private Sub btnAjouterCli_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterCli.Click
        Dim ajout = New iAjoutCliReserv(noHotel, noEmp, db)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub btnFicheReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReserv.Click
        Dim ficheR = New iFicheReserv(db, noEmp, noHotel)
        ficheR.Owner = Me
        ficheR.Show()
    End Sub

    Private Sub btnFicheReservF_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReservF.Click
        Dim ficheRF = New iFicheReservFacture(db, noEmp, noHotel)
        ficheRF.Owner = Me
        ficheRF.Show()
    End Sub

    Private Sub btnListeCli_Click(sender As Object, e As RoutedEventArgs) Handles btnListeCli.Click
        Dim lst = New iListeClient
        lst.owner = Me
        lst.Show()
    End Sub
End Class
