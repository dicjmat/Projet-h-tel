Public Class iFicheCompagnie

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noComp As Integer

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, p2 As Integer)
        InitializeComponent()
        bd = _bd
        noComp = p2
        btnModifier.Visibility = Windows.Visibility.Visible
        btnCreer.Visibility = Windows.Visibility.Hidden
        Dim res As tblCompagnie = (From co In bd.tblCompagnie
                  Where co.noCompagnie = noComp
                  Select co).Single
        txtNomCie.Text = res.nomCompagnie
        txtTellCie.Text = res.noTelCompagnie
        txtCellCie.Text = res.noCellCompagnie
        txtNomRespCie.Text = res.respCompagnie
        txtComCie.Text = res.commentaire
        txtAdresse.Text = res.adrCompagnie

        Dim pays = From pa In bd.tblPays
                   Select pa

        cbPays.ItemsSource = pays.ToList
        Dim paysComp = From pa In bd.tblPays
                       Where pa.codePays = res.tblVille.tblProvince.codePays
           Select pa
        cbPays.SelectedItem = paysComp.Single
        Dim prov = From pro In bd.tblProvince
                   Where pro.codeProv = res.codeProv

        cbProvince.SelectedItem = prov.Single
        Dim ville = From vi In bd.tblVille
                    Where vi.codeVille = res.codeVille

        cbVille.SelectedItem = ville.Single
    End Sub

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = _bd
        btnModifier.Visibility = Windows.Visibility.Hidden
        btnCreer.Visibility = Windows.Visibility.Visible
        Dim pays = From pa In bd.tblPays
           Select pa

        cbPays.ItemsSource = pays.ToList
    End Sub

    Private Sub btnCreer_Click(sender As Object, e As RoutedEventArgs) Handles btnCreer.Click
        Dim comp = New tblCompagnie
        If txtNomCie.Text <> "" And txtTellCie.Text <> "   -   -    " And cbVille.SelectedIndex <> -1 And txtAdresse.Text <> "" Then
            comp.nomCompagnie = txtNomCie.Text
            comp.adrCompagnie = txtAdresse.Text
            comp.noTelCompagnie = txtTellCie.Text
            If txtCellCie.Text <> "   -   -    " Then
                comp.noCellCompagnie = txtCellCie.Text
            End If
            comp.respCompagnie = txtNomRespCie.Text
            comp.commentaire = txtComCie.Text
            comp.codeProv = cbProvince.SelectedItem.codeProv
            comp.codeVille = cbVille.SelectedItem.codeVille
            bd.tblCompagnie.Add(comp)
            bd.SaveChanges()
            MessageBox.Show("La compagnie a été créée avec succès")
            Me.Owner.Hide()
            Me.Owner.Show()
            Me.Close()
        Else
            MessageBox.Show("Il manque des informations essentielles")
        End If
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles btnModifier.Click
        Dim comp As tblCompagnie = (From co In bd.tblCompagnie
                                   Where co.noCompagnie = noComp
                                   Select co).Single
        If txtNomCie.Text <> "" And txtTellCie.Text <> "   -   -    " And cbVille.SelectedIndex <> -1 And txtAdresse.Text <> "" Then
            comp.nomCompagnie = txtNomCie.Text
            comp.adrCompagnie = txtAdresse.Text
            comp.noTelCompagnie = txtTellCie.Text
            comp.noCellCompagnie = txtCellCie.Text
            comp.respCompagnie = txtNomRespCie.Text
            comp.commentaire = txtComCie.Text
            comp.codeProv = cbProvince.SelectedItem.codeProv
            comp.codeVille = cbVille.SelectedItem.codeVille
            bd.SaveChanges()
            MessageBox.Show("La compagnie a été modifiée avec succès")
            Me.Owner.Hide()
            Me.Owner.Show()
            Me.Close()
        Else
            MessageBox.Show("Il manque des informations essentielles")
        End If

    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub cbPays_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbPays.SelectionChanged
        If cbPays.SelectedIndex <> -1 Then
            Dim pays As String = cbPays.SelectedItem.codePays
            Dim prov = From pro In bd.tblProvince
                       Where pro.codePays = pays
                       Select pro

            cbProvince.ItemsSource = prov.ToList
        End If
    End Sub

    Private Sub cbProvince_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbProvince.SelectionChanged
        If cbProvince.SelectedIndex <> -1 Then
            Dim province As String = cbProvince.SelectedItem.codeProv
            Dim ville = From vi In bd.tblVille
                        Where vi.codeProv = province
                       Select vi

            cbVille.ItemsSource = ville.ToList
        End If
    End Sub
End Class
