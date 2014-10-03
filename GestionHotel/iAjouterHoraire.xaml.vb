﻿Public Class iAjouterHoraire
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noGest As Short
    Private hotel As Short
    Sub New(_noGestionnaire As Short)
        InitializeComponent()

    End Sub
    Sub New(_noGestionnaire As Short, _noHotel As Short)
        InitializeComponent()
        noGest = _noGestionnaire
        hotel = _noHotel
    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim profGest = From el In bd.tblEmploye Where noGest = el.noEmpl Select el.codeProf
        Dim prof = profGest.Single.ToString()
        Dim res = From el In bd.tblEmploye Where el.codeProf = prof And el.noHotel = hotel Select el

        cbEmploye.DataContext = res.ToList()
    End Sub

    Private Sub btnRetour_Click(sender As Object, e As RoutedEventArgs) Handles btnRetour.Click
        Me.Focusable = False
        Me.Close()
    End Sub

    Private Sub windowAjoutHoraire_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowAjoutHoraire.Closing
        If Me.Focusable Then
            Me.Owner.Close()
        Else
            Me.Owner.Show()
        End If
    End Sub
End Class
