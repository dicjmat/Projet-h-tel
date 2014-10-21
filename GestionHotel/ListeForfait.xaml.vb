Public Class ListeForfait
    Dim bd As New P2014_Equipe2_GestionHôtelièreEntities
    Private _hotel As Short

    Sub New(hotel As Short)
        ' TODO: Complete member initialization
        InitializeComponent()
        _hotel = hotel
    End Sub

    Private Sub window_ListeForf_Loaded(sender As Object, e As RoutedEventArgs) Handles window_ListeForf.Loaded

    End Sub

    Private Sub window_ListeForf_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_ListeForf.Closing
        Me.Owner.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub requete()
    End Sub
End Class
