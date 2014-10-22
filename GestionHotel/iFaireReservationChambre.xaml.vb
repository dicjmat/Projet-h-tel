Public Class iFaireReservation
    Private noEmpl As Short
    Private noHotel As Short
    Dim typeChambre As String
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Sub New(p1 As Short, p2 As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        noEmpl = p1
        noHotel = p2
    End Sub
    Private Sub window_FaireReserv_Loaded(sender As Object, e As RoutedEventArgs) Handles window_FaireReserv.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities

        Dim res = From el In bd.tblTypeChambre Select el
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub btnReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnReserv.Click
        Dim chambre As New tblReservationChambre
        chambre.commentaire = txtCommReser.Text
        chambre.noEmpl = noEmpl
        chambre.noHotel = noHotel


        bd.tblReservationChambre.Add(chambre)
        bd.SaveChanges()
        MessageBox.Show("La réservation de la chambre a été fait avec succès.")
    End Sub


End Class
