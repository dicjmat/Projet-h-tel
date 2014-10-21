Public Class ListeForfait
    Dim bd As New P2014_Equipe2_GestionHôtelièreEntities
    Private _hotel As Short

    Sub New(hotel As Short)
        ' TODO: Complete member initialization
        InitializeComponent()
        _hotel = hotel
    End Sub

    Private Sub window_ListeForf_Loaded(sender As Object, e As RoutedEventArgs) Handles window_ListeForf.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        requete()
    End Sub

    Private Sub window_ListeForf_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_ListeForf.Closing
        Me.Owner.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub requete()
        Dim res = From fo In bd.tblForfait
                  Where fo.noHotel = _hotel
                  Select fo

        dgForfait.ItemsSource = res.ToList
    End Sub

    Private Sub btnAjoutForf_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutForf.Click
        Dim forfait = New iAjoutForf(True, _hotel)
        forfait.Owner = Me
        forfait.Show()
    End Sub

    Private Sub btnModifForf_Click(sender As Object, e As RoutedEventArgs) Handles btnModifForf.Click
        Dim forfait = New iAjoutForf(False, _hotel)
        forfait.Owner = Me
        forfait.Show()
    End Sub

    Private Sub window_ListeForf_Activated(sender As Object, e As EventArgs) Handles window_ListeForf.Activated
        requete()
    End Sub
End Class
