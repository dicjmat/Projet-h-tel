Public Class iCommande
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
    End Sub
    Private Sub btnAjouterItemComm_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterItemComm.Click
        'Dim prix = From item In bd.tblItem
        'Where txtCodeItem.Text = item.codeItem And 
        'Select prix


    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub
End Class
