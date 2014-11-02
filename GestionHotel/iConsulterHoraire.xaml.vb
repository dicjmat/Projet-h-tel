Public Class iConsulterHoraire

    Private _numEmpl As Integer
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noGest As Short

    Sub New(maBd As P2014_Equipe2_GestionHôtelièreEntities, _noGest As Short)
        InitializeComponent()
        bd = maBd
        noGest = _noGest
        requete()
        remplirNom()
    End Sub

    Sub New(numEmpl As Object, maBd As P2014_Equipe2_GestionHôtelièreEntities, _noGest As Short)
        InitializeComponent()
        _numEmpl = numEmpl
        bd = maBd
        noGest = _noGest
        requete()
        remplirNom()
    End Sub


    Private Sub requete()
        If cbNomEmp.SelectedIndex <> -1 Then
            Dim nEmpl As Integer = cbNomEmp.SelectedItem.noEmpl
            Dim res = From ho In bd.tblHoraire
                      Where ho.noEmpl = nEmpl And ho.dateHoraire.ToString.StartsWith(txtRecherche.Text)
                      Select ho.heureDebut, ho.heureFin, dateHoraire = ho.dateHoraire.ToString.Substring(0, 10)

            dgHoraire.ItemsSource = res.ToList
        End If
    End Sub

    Private Sub remplirNom()
        Dim empl = From em In bd.tblEmploye Where em.noEmpl = noGest Select em
        Dim hotel As Integer = empl.Single.noHotel
        Dim prof As String = empl.Single.codeProf


        Dim res = From em In bd.tblEmploye
                  Where em.noHotel = hotel And em.codeProf = prof
                  Select nomEmpl = em.prenEmpl & " " & em.nomEmpl, em.noEmpl

        cbNomEmp.ItemsSource = res.ToList
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
        Me.Owner.Show()
    End Sub

    Private Sub cbNomEmp_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbNomEmp.SelectionChanged
        If cbNomEmp.SelectedIndex <> -1 Then
            requete()
        End If
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub
End Class
