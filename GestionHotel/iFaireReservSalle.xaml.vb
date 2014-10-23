Public Class iFaireReservSalle

    Private bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = _bd
    End Sub

    Private Sub window_ReservSalle_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_ReservSalle.Closing
        Me.Owner.Show()
    End Sub
End Class
