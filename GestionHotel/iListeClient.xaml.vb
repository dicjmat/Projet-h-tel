Public Class iListeClient
    Private noEmpl As Short
    Private noHotel As Short

    Dim bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, noEmploye As Short, nHotel As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        bd = maBD
        noEmpl = noEmploye
        noHotel = nHotel
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        requete()
    End Sub
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub txtRCli_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRCli.TextChanged

    End Sub

    Private Sub requete()
        Dim res = From el In bd.tblClient
        Select el
        dgClient.ItemsSource = res.ToList

    End Sub


    Private Sub btnReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnReserv.Click
   
    End Sub
End Class
