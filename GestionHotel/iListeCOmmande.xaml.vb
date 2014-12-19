Public Class iListeCOmmande
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim lstAffichage As New List(Of Object)
    Private _noHotel As Short
    Private _noEmpl As Short


    Sub New(noEmpl As Short, noHotel As Short, maBd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        _noEmpl = noEmpl
        _noHotel = noHotel
        bd = maBd
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        requete()
    End Sub

    Private Sub txtRComm_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRComm.TextChanged
        requete()
    End Sub

    Private Sub dgCommande_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgCommande.SelectionChanged
        If dgCommande.SelectedIndex <> -1 Then
            Dim commande As Integer = dgCommande.SelectedItem.noCommande
            Dim ligne = From LiCo In bd.tblLigneCommande
                        Where LiCo.noCommande = commande
                        Select LiCo
            For Each el In ligne.ToList()
                'Dim affichage = New With {.nomFournisseur = el.tblCommande.tblFournisseur.nomFournisseur _
                '                            , .quantite = el.quantite _
                '                            , .prixLigne = el.prixUnitaire * el.quantite _
                '                            , .nomItem = el.tblItem.nomItem _
                '                            , .codeItem = el.codeItem}
                Dim affichage = New With {.nomFournisseur = el.tblCommande.tblFournisseur.nomFournisseur _
                            , .quantite = el.quantite _
                            , .prixLigne = el.prixUnitaire * el.quantite _
                            , .nomItem = el.tblItem.nomItem _
                            , .codeItem = el.codeItem}
                lstAffichage.Add(affichage)
            Next
            dgLigneCommande.ItemsSource = lstAffichage.ToList
            lstAffichage.Clear()
        End If
    End Sub

    Private Sub btnAjouterComm_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterComm.Click
        Dim iComman = New iCommande(_noEmpl, bd)
        iComman.Owner = Me
        iComman.Show()
    End Sub

    Private Sub requete()
        Dim res = (From Co In bd.tblCommande
                  Join Em In bd.tblEmploye On Co.noEmpl Equals Em.noEmpl
                  Join LiCo In bd.tblLigneCommande On Co.noCommande Equals LiCo.noCommande
                  Join Fo In bd.tblFournisseur On Co.noFournisseur Equals Fo.noFournisseur
                  Where _noHotel = Em.noHotel And (Em.nomEmpl.StartsWith(txtRComm.Text) Or Co.dateCommande.ToString.StartsWith(txtRComm.Text) Or Co.etatCommande.StartsWith(txtRComm.Text))
                  Select Co.noCommande, Co.dateCommande, Co.etatCommande, Co.prixCommande, Em.nomEmpl, Em.prenEmpl, Fo.nomFournisseur).Distinct

        dgCommande.ItemsSource = res.ToList()
    End Sub

    Private Sub Window_Activated(sender As Object, e As EventArgs)
        requete()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(bd, _noHotel, _noEmpl)
        fiche.Owner = Me.Owner
        fiche.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmploye(_noEmpl, _noHotel, bd)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim horaire = New iAjouterHoraire(_noEmpl, _noHotel, bd)
        horaire.Owner = Me.Owner
        horaire.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCOmmande(_noEmpl, _noHotel, bd)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim lst = New iCommunique(_noEmpl, _noHotel, bd)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub
End Class
