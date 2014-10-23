Public Class iListeHotel
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization
        InitializeComponent()
        bd = maBd
    End Sub

    Private Sub window_lstHotel_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstHotel.Loaded
        Dim res = From Ho In bd.tblHotel
                  Join Vi In bd.tblVille On Ho.codeVille Equals Vi.codeVille
                  Select Ho.noHotel, Ho.nomHotel, Vi.nomVille

        dgHotel.ItemsSource = res.ToList()
    End Sub

    Private Sub window_lstHotel_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_lstHotel.Closing
        Me.Owner.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub dgHotel_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgHotel.SelectionChanged
        If dgHotel.SelectedIndex <> -1 Then
            Dim noHotel As Integer = dgHotel.SelectedItem.noHotel
            Dim res = From Ch In bd.tblChambre
                              Join TyCh In bd.tblTypeChambre On Ch.codeTypeChambre Equals TyCh.codeTypeChambre
                              Where Ch.noHotel = noHotel
                              Select Ch.noChambre, TyCh.nomTypeChambre

            dgChambre.ItemsSource = res.ToList()
        End If

    End Sub

    Private Sub btnAjouterHotel_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterHotel.Click
        Dim Ghotel = New iGestionHotel(bd)
        Ghotel.Owner = Me
        Ghotel.Show()
    End Sub

    Private Sub btnAjouterChambre_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterChambre.Click
        Dim Gchambre = New iGestionChambre(bd)
        Gchambre.Owner = Me
        Gchambre.Show()
    End Sub
End Class
