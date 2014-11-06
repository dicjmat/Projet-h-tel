Public Class iInventaire

    Private _noHotel As Short
    Dim maBD As P2014_Equipe2_GestionHôtelièreEntities
    Private _noEmpl As Short

    Sub New(noEmpl As Short, noHotel As Short, _maBd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        _noEmpl = noEmpl
        _noHotel = noHotel
        maBd = _maBd
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim res = From item In maBD.tblItem Join el In maBD.tblInventaire On el.codeItem Equals item.codeItem
                  Where el.noHotel = _noHotel
                  Select el.codeItem, item.nomItem, el.Quantite, item.descItem, el.quantiteMin
        lstInventaire.ItemsSource = creerAffichage(res)
        Me.Owner.Hide()
    End Sub

    Private Sub txtCodeItem_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtCodeItem.TextChanged
        Dim res = From item In maBD.tblItem Join el In maBD.tblInventaire On el.codeItem Equals item.codeItem
                  Where el.noHotel = _noHotel And (item.codeItem.StartsWith(txtCodeItem.Text) Or item.nomItem.StartsWith(txtCodeItem.Text))
                  Select el.codeItem, item.nomItem, el.Quantite, item.descItem, el.quantiteMin
        lstInventaire.ItemsSource = creerAffichage(res.ToList)
    End Sub


    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub btnAjoutItem_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutItem.Click
        Dim iItem = New iAjouterItem(maBD)
        iItem.Owner = Me
        iItem.Show()
    End Sub

    Private Sub btnCommander_Click(sender As Object, e As RoutedEventArgs) Handles btnCommander.Click
        Dim iComman = New iCommande(_noEmpl, maBD)
        iComman.Owner = Me
        iComman.Show()
    End Sub

    Private Function creerAffichage(res)
        Dim lstAffichage As New List(Of Object)
        Dim Affichage
        For Each el In res
            Dim Stock As Boolean = False
            If el.Quantite < el.quantiteMin Then
                Stock = True
            End If
            Affichage = New With {.codeItem = el.codeItem _
                                , .nomItem = el.nomItem _
                                , .Quantite = el.Quantite _
                                , .stock = Stock _
                                , .descItem = el.descItem}
            lstAffichage.Add(Affichage)
        Next
        Return lstAffichage
    End Function

    Private Sub btnCommandeGerant_Click(sender As Object, e As RoutedEventArgs) Handles btnCommandeGerant.Click

    End Sub

    Private Sub btnAjoutFourniGerant_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutFourniGerant.Click

    End Sub

    Private Sub btnAjoutItemGerant_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutItemGerant.Click

    End Sub

    Private Sub btnCommande_Click(sender As Object, e As RoutedEventArgs) Handles btnCommande.Click

    End Sub

    Private Sub btnAjoutFourni_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutFourni.Click

    End Sub

    Private Sub btnAjouterItem_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterItem.Click

    End Sub

    Private Sub btnFicheEmp_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheEmp.Click

    End Sub

    Private Sub btnGSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnGSalle.Click

    End Sub

    Private Sub btnGChambre_Click(sender As Object, e As RoutedEventArgs) Handles btnGChambre.Click

    End Sub

    Private Sub btnGHotel_Click(sender As Object, e As RoutedEventArgs) Handles btnGHotel.Click

    End Sub

    Private Sub btnIComplet_Click(sender As Object, e As RoutedEventArgs) Handles btnIComplet.Click

    End Sub

    Private Sub btnLCentrale_Click(sender As Object, e As RoutedEventArgs) Handles btnLCentrale.Click

    End Sub

    Private Sub btnLEmpCentrale_Click(sender As Object, e As RoutedEventArgs) Handles btnLEmpCentrale.Click

    End Sub

    Private Sub btnLHotel_Click(sender As Object, e As RoutedEventArgs) Handles btnLHotel.Click

    End Sub

    Private Sub btnLSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnLSalle.Click

    End Sub
End Class
