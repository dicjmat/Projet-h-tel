Public Class iInventaire

    Private _noHotel As Short
    Dim maBD As P2014_Equipe2_GestionHôtelièreEntities
    Private _noEmpl As Short
    Dim item As String
    Private noSalle As Integer

    Sub New(noEmpl As Short, noHotel As Short, _maBd As P2014_Equipe2_GestionHôtelièreEntities, _noSalle As Integer)
        InitializeComponent()
        _noEmpl = noEmpl
        _noHotel = noHotel
        maBD = _maBd
        noSalle = _noSalle
        btnCommander.IsEnabled = False
        btnCommander.Visibility = Windows.Visibility.Hidden
        btnAjoutItem.IsEnabled = False
        btnAjoutItem.Visibility = Windows.Visibility.Hidden
        menu.IsEnabled = False
        menu.Visibility = Windows.Visibility.Hidden
        menuGerant.IsEnabled = False
        menuGerant.Visibility = Windows.Visibility.Hidden
        btnLierItem.IsEnabled = False
        btnLierItem.Visibility = Windows.Visibility.Hidden
    End Sub

    Sub New(noEmpl As Short, noHotel As Short, _maBd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        _noEmpl = noEmpl
        _noHotel = noHotel
        maBD = _maBd
        Dim res = From el In maBD.tblLogin Where el.noEmpl = _noEmpl Select el

        If res.First.statut = "PATR" Then
            menu.Visibility = Windows.Visibility.Hidden
            menu.IsEnabled = False
        Else
            menuGerant.Visibility = Windows.Visibility.Hidden
            menuGerant.IsEnabled = False
        End If
        btnAjouterItemChk.IsEnabled = False
        btnAjouterItemChk.Visibility = Windows.Visibility.Hidden
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
        Dim iItem = New iAjouterItem(maBD, _noEmpl, _noHotel)
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

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim com = New iCommande(_noEmpl, maBD)
        com.Owner = Me
        com.Show()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjouterItem(item, maBD)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjoutFournisseur(maBD)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim com = New iCommande(_noEmpl, maBD)
        com.Owner = Me
        com.Show()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(maBD, _noHotel, _noEmpl)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmployeComplet(maBD, _noEmpl, _noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjouterItem(item, maBD)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjoutFournisseur(maBD)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub MenuItem_Click_8(sender As Object, e As RoutedEventArgs)
        Dim inv = New iInventaireComplet(maBD, _noEmpl, _noHotel)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub MenuItem_Click_9(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionSalle(maBD)
        gest.Owner = Me
        gest.Show()
    End Sub

    Private Sub MenuItem_Click_10(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionHotel(maBD)
        gest.Owner = Me
        gest.Show()
    End Sub

    Private Sub MenuItem_Click_11(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCentrale(maBD, _noEmpl, _noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_12(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeHotel(maBD, _noEmpl, _noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_13(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(_noHotel, maBD, _noEmpl)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnAjouterItemChk_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterItemChk.Click
        If lstInventaire.SelectedItem IsNot Nothing Then
            Dim check = New tblChecklist()
            check.codeItem = lstInventaire.SelectedItem.codeItem
            check.dateSaisit = DateAdd(DateInterval.Day, -1, Date.Today)
            check.noEmpl = _noEmpl
            check.noSalle = noSalle
            check.noHotel = _noHotel
            check.statut = "OUI"
            maBD.tblChecklist.Add(check)
            maBD.SaveChanges()
            Me.Owner.Hide()
            Me.Owner.Show()
            Me.Close()
        Else
            MessageBox.Show("Veuillez sélectionner un item", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub
End Class
