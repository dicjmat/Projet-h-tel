Public Class LierFournisseur

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private item As String

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _item As String)
        InitializeComponent()
        bd = _bd
        item = _item
    End Sub

    Private Sub window_LierFourni_Loaded(sender As Object, e As RoutedEventArgs) Handles window_LierFourni.Loaded
        Dim res = From el In bd.tblFournisseur Select el

        cbFourni.ItemsSource = res.ToList()
    End Sub

    Private Sub btnAjouterFour_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterFour.Click
        Dim fournisseur = New iAjoutFournisseur(bd)
        fournisseur.Owner = Me
        fournisseur.Show()
        Me.Hide()
    End Sub

    Private Sub btnLier_Click(sender As Object, e As RoutedEventArgs) Handles btnLier.Click
        If cbFourni.SelectedItem IsNot Nothing Then
            Try
                Dim catalgue = New tblCatalogue()
                catalgue.codeItem = item
                catalgue.noFournisseur = cbFourni.SelectedItem.noFournisseur
                Try
                    catalgue.prixItem = Replace(txtPrixItem.Text, ".", ",")
                Catch ex As Exception
                    MessageBox.Show("Veuillez saisir un montant valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error)
                    Exit Sub
                End Try
                bd.tblCatalogue.Add(catalgue)
                bd.SaveChanges()
                MessageBox.Show("Le fournisseur est maintenant lié à l'item", "Confirmation", MessageBoxButton.OK, MessageBoxImage.None)
            Catch exc As Exception
                MessageBox.Show("Le fournisseur et l'item sont déjà liés", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error)
            End Try
        Else
            MessageBox.Show("Veuillez sélectionner un fournisseur", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles btnQuitter.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub window_LierFourni_Activated(sender As Object, e As EventArgs) Handles window_LierFourni.Activated
        Dim res = From el In bd.tblFournisseur Select el

        cbFourni.ItemsSource = res.ToList()
    End Sub
End Class
