Public Class iCheckList

    Private noEmploye As Short
    Private noHotel As Short
    Private BD As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmploye As Short, nHotel As Short)
        InitializeComponent()
        BD = maBD
        noEmploye = _noEmploye
        noHotel = nHotel
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim res = From el In BD.tblSalle Where el.noHotel = noHotel Select el

        cbSalle.DataContext = res.ToList()
    End Sub

    Private Sub btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles btnQuitter.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub cbSalle_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbSalle.SelectionChanged
        remplirCheckList()
    End Sub

    Private Sub btnSauvegarder_Click(sender As Object, e As RoutedEventArgs) Handles btnSauvegarder.Click
        Dim Contenu As tblChecklist
        Dim dateAjout = Date.Today
        For Each el In dgCheckList.Items
            Contenu = New tblChecklist()
            Contenu.dateSaisit = dateAjout
            Contenu.noSalle = cbSalle.SelectedValue.noSalle
            Contenu.noHotel = noHotel
            Contenu.codeItem = el.codeItem
            Contenu.noEmpl = noEmploye
            Contenu.statut = "OUI"
            BD.tblChecklist.Add(Contenu)
            'BD.SaveChanges()
        Next (el)
    End Sub

    Private Sub btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles btnAjout.Click
        If cbSalle.SelectedItem IsNot Nothing Then
            Dim item = New iInventaire(noEmploye, noHotel, BD, cbSalle.SelectedValue.noSalle)
            item.Owner = Me
            item.Show()
        Else
            MessageBox.Show("Veuillez sélectionner une salle", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim bri = New iGestionBris(BD, noHotel, noEmploye)
        bri.Owner = Me
        bri.Show()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim check = New iCheckList(BD, noEmploye, noHotel)
        check.Owner = Me.Owner
        check.Show()
        Me.Close()
    End Sub

    Private Sub windowCheckList_Activated(sender As Object, e As EventArgs) Handles windowCheckList.Activated
        remplirCheckList()
    End Sub

    Private Sub remplirCheckList()
        Dim salle = Convert.ToInt16(cbSalle.SelectedValue.noSalle())
        Dim check = From el In BD.tblChecklist Where el.noSalle = salle And el.noHotel = noHotel Order By el.dateSaisit Descending Select el
        If check.ToList IsNot Nothing Then
            Dim dernDate = check.First.dateSaisit
            Dim last = From el In BD.tblChecklist Where el.dateSaisit = dernDate Select el

            dgCheckList.ItemsSource = last.ToList()
        Else
            Dim typeSalle = From el In BD.tblSalle Where el.noSalle = salle And el.noHotel = noHotel Select el.codeTypeSalle
            Dim codeType = typeSalle.First.ToString()
            Dim res = From el In BD.tblItem Join comp In BD.tblGabarit On comp.codeItem Equals el.codeItem Where comp.codeTypeSalle = codeType Select el

            dgCheckList.DataContext = res.ToList()
        End If
    End Sub

    Private Sub btnBris_Click(sender As Object, e As RoutedEventArgs) Handles btnBris.Click
        If dgCheckList.SelectedItem IsNot Nothing Then
            Dim bris = New tblBris()
            bris.codeItem = dgCheckList.SelectedItem.codeItem
            bris.dateBris = Date.Today
            bris.noHotel = noHotel
            bris.noSalle = cbSalle.SelectedValue.noSalle
            bris.etatBris = "Brisé"
            BD.tblBris.Add(bris)
            BD.SaveChanges()
            MessageBox.Show("La bris a été ajouté", "Confirmation", MessageBoxButton.OK)
        Else
            MessageBox.Show("Veuillez sélectionner un item", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnRetire_Click(sender As Object, e As RoutedEventArgs) Handles btnRetire.Click
        If dgCheckList.SelectedItem IsNot Nothing Then
            BD.tblChecklist.Remove(dgCheckList.SelectedItem)
            BD.SaveChanges()
            windowCheckList.OnActivated(e)
        Else
            MessageBox.Show("Veuillez sélectionner un item", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub
End Class
