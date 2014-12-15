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

    Private Sub btnSauvegarder_Click(sender As Object, e As RoutedEventArgs) Handles btnSauvegarder.Click
        Dim Contenu As tblChecklist
        Dim coche = dgCheckList.Columns.Item(1)
        Dim dateAjout = Date.Today
        Dim i = 0
        For Each el In dgCheckList.Items
            Contenu = New tblChecklist()
            Contenu.dateSaisit = dateAjout
            Contenu.noSalle = cbSalle.SelectedValue.noChambre()
            Contenu.noHotel = noHotel
            'If = True Then
            '    Contenu.statut = "oui"
            'Else
            '    Contenu.statut = "non"
            'End If
            Contenu.commentaire = el.
            Contenu.codeItem = el.codeItem
            Contenu.noEmpl = noEmploye
            BD.tblChecklist.Add(Contenu)
            BD.SaveChanges()
        Next (el)
    End Sub

    Private Sub btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles btnAjout.Click

    End Sub

    Private Sub dgCheckList_CellEditEnding(sender As Object, e As DataGridCellEditEndingEventArgs) Handles dgCheckList.CellEditEnding
        Dim checkList = New tblChecklist()
        checkList.dateSaisit = Date.Now
        checkList.codeItem = dgCheckList.SelectedItem.codeItem
        checkList.noSalle = cbSalle.SelectedItem.noSalle
        checkList.noHotel = noHotel
        checkList.noEmpl = noEmploye
        'checkList.commentaire = dgCheckList.CurrentCell
    End Sub
End Class
