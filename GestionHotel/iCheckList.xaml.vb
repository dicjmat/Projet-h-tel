Public Class iCheckList

    Private noEmploye As Short
    Private noHotel As Short
    Private BD As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(_noEmploye As Short, _noHotel As Short)
        InitializeComponent()
        noEmploye = _noEmploye
        noHotel = _noHotel
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        BD = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From el In BD.tblChambre Where el.noHotel = noHotel Select el

        cbChambre.DataContext = res.ToList()
    End Sub

    Private Sub btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles btnQuitter.Click
        Me.Close()
    End Sub

    Private Sub cbChambre_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbChambre.SelectionChanged
        Dim chambre = Convert.ToInt16(cbChambre.SelectedValue.noChambre())
        Dim typeChambre = From el In BD.tblChambre Where el.noChambre = chambre And el.noHotel = noHotel Select el.codeTypeChambre
        Dim codeType = typeChambre.First.ToString()
        Dim res = From el In BD.tblItem Join comp In BD.tblGabarit On comp.codeItem Equals el.codeItem Where comp.codeTypeChambre = codeType Select el

        lbItem.DataContext = res.ToList()
    End Sub

    Private Sub btnSauvegarder_Click(sender As Object, e As RoutedEventArgs) Handles btnSauvegarder.Click
        Dim Contenu As tblChecklist
        Dim dateAjout = Date.Today
        Dim i = 0
        For Each el In lbItem.Items
            Contenu = New tblChecklist()
            Contenu.dateSaisit = dateAjout
            Contenu.noChambre = cbChambre.SelectedValue.noChambre()
            Contenu.noHotel = noHotel
            'If = True Then
            '    Contenu.statut = "oui"
            'Else
            '    Contenu.statut = "non"
            'End If
            Contenu.commentaire = el.txtComCheck.Text
            Contenu.codeItem = el.codeItem
            Contenu.noEmpl = noEmploye
            BD.tblChecklist.Add(Contenu)
            BD.SaveChanges()
        Next (el)
    End Sub
End Class
