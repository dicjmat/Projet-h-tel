Public Class iCommunique
    Private _noHotel As Short
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities
    Private _noEmpl As Short

    Sub New(noEmpl As Short, noHotel As Short, _maBd As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization
        InitializeComponent()
        _noEmpl = noEmpl
        _noHotel = noHotel
        maBd = _maBd
    End Sub

    Private Sub btnFicheEmploye_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheEmploye.Click
        Dim fiche = New iFicheEmploye(maBd)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub btnListeCommande_Click(sender As Object, e As RoutedEventArgs) Handles btnListeCommande.Click
        Dim com = New iListeCOmmande(_noEmpl, _noHotel, maBd)
        com.Owner = Me
        com.Show()
    End Sub

    Private Sub btnAjoutHoraire_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutHoraire.Click
        Dim horaire = New iAjouterHoraire(_noEmpl, _noHotel, maBd)
        horaire.Owner = Me
        horaire.Show()
    End Sub

    Private Sub btnLEmp_Click(sender As Object, e As RoutedEventArgs) Handles btnLEmp.Click
        Dim lst = New iListeEmploye(_noEmpl, _noHotel, maBd)
        lst.Owner = Me
        lst.Show()
    End Sub
End Class
