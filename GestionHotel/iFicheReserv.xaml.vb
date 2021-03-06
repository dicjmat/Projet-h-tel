﻿Public Class iFicheReserv
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noEmp As Integer
    Private noHotel As Integer
    Private noReserv As Integer

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = maBD
        noEmp = _noEmp
        noHotel = _noHotel
    End Sub

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer, _noReserv As Integer)
        InitializeComponent()
        bd = _bd
        noEmp = _noEmp
        noHotel = _noHotel
        noReserv = _noReserv

        Dim res = From el In bd.tblReservation Where el.noReservation = noReserv Select el

        window_FicheReserv.DataContext = res.ToList()
    End Sub
    Private Sub btnAjoutCli_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheCli.Click
        Dim ajout = New iAjoutCliReserv(noEmp, noHotel, bd)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub
    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim check = New iCheck_in_out(bd, noEmp, noHotel)
        check.Owner = Me.Owner
        check.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim facture = New iFacture(bd, noEmp, noHotel)
        facture.Owner = Me.Owner
        facture.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeClient(bd, noHotel, noEmp)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim reserv = New iFaireReservationChambre(bd, noEmp, noHotel)
        reserv.Owner = Me.Owner
        reserv.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim ficheR = New iFicheReserv(bd, noEmp, noHotel)
        ficheR.Owner = Me.Owner
        ficheR.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim ficheRF = New iFicheReservFacture(bd, noEmp, noHotel)
        ficheRF.Owner = Me.Owner
        ficheRF.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim Cli = New iAjoutCliReserv(noEmp, noHotel, bd)
        Cli.Owner = Me.Owner
        Cli.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeReservComplet(bd, noEmp, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub
End Class
