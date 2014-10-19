Public Class iListeClientReserv
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noEmpl As Short
    Private noHotel As Short
    Dim login As New iLogin
    Dim reserv As iFaireReservation
    Sub New(p1 As Short, p2 As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        noEmpl = p1
        noHotel = p2
    End Sub
    Private Sub window_ListCliReser_Loaded(sender As Object, e As RoutedEventArgs) Handles window_ListCliReser.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
    End Sub

    Private Sub btnReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnReserv.Click
        reserv = New iFaireReservation(noEmpl, noHotel)
        reserv.Owner = Me
        reserv.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Close()
        login.Show()
    End Sub

End Class
