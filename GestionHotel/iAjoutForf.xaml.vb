﻿Public Class iAjoutForf
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities

    Private Sub windowAjoutForf_Loaded(sender As Object, e As RoutedEventArgs) Handles windowAjoutForf.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities

        Dim res = From el In bd.tblTypeChambre Select el.nomTypeChambre
        lstTypeChambre.DataContext = res.ToList()
        lstTypeChambre.AllowDrop = True
        lstTypeChambreC.AllowDrop = True
    End Sub
    Private Sub AjouterForf_Click(sender As Object, e As RoutedEventArgs) Handles AjouterForf.Click
        Dim Forfait As New tblForfait
        Forfait.prixForfait = txtPrixForf.Text
        Forfait.descForfait = txtDescAct.Text

        bd.tblForfait.Add(Forfait)
        bd.SaveChanges()
        MessageBox.Show("Le forfait a été créé avec succès.")
    End Sub

    Private Sub lstTypeChambre_MouseDown(sender As Object, e As MouseButtonEventArgs)

    End Sub
End Class
