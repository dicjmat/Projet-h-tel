Public Class iRabais
    Dim bd As New P2014_Equipe2_GestionHôtelièreEntities
    Private noHotel As Short

    Sub New(hotel As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        noHotel = hotel
    End Sub

    Private Sub btndeco_Click(sender As Object, e As RoutedEventArgs) Handles btndeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub AjoutRab_Click(sender As Object, e As RoutedEventArgs) Handles AjoutRab.Click
        Dim rabais As New tblRabais

        If cbTypeChambre.SelectedIndex <> -1 Then
            rabais.codeTypeChambre = cbTypeChambre.SelectedItem.codeTypeChambre
            rabais.tauxRabais = Convert.ToDecimal(numTaux.Value) / 100
            If chkActif.IsChecked Then
                rabais.etatRabais = "AC"
            Else
                rabais.etatRabais = "IN"
            End If
            bd.tblRabais.Add(rabais)
            bd.SaveChanges()
            requete()
            MessageBox.Show("Votre rabais a été ajouté")
        Else
            MessageBox.Show("Veuillez remplir les champs")
        End If
    End Sub

    Private Sub windowRabais_Loaded(sender As Object, e As RoutedEventArgs) Handles windowRabais.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Me.Owner.Hide()
        requete()
        Dim res = From tych In bd.tblTypeChambre
                  Join tychho In bd.tblTypeChambreHotel On tych.codeTypeChambre Equals tychho.codeTypeChambre
                  Where tychho.noHotel = noHotel
                  Select tych

        cbTypeChambre.DataContext = res.ToList
    End Sub

    Private Sub requete()
        Dim res = From ra In bd.tblRabais
                  Join tych In bd.tblTypeChambre On ra.codeTypeChambre Equals tych.codeTypeChambre
                  Join tychho In bd.tblTypeChambreHotel On tych.codeTypeChambre Equals tychho.codeTypeChambre
                  Where tychho.noHotel = noHotel
                  Select ra.etatRabais, ra.noRabais, ra.tauxRabais, tych.nomTypeChambre

        dgRabais.ItemsSource = res.ToList
    End Sub

    Private Sub SuppRab_Click(sender As Object, e As RoutedEventArgs) Handles SuppRab.Click
        If dgRabais.SelectedIndex <> -1 Then
            Dim nRabais As Integer = dgRabais.SelectedItem.noRabais
            Dim res = From ra In bd.tblRabais
                      Where ra.noRabais = nRabais
                      Select ra
            bd.tblRabais.Remove(res.Single)
            Dim maxi = From rab In bd.tblRabais
                       Select rab.noRabais
            bd.SaveChanges()
            bd.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Reservation.tblRabais',RESEED," + maxi.ToList.Last.ToString + ")")
            bd.SaveChanges()
            requete()
            MessageBox.Show("Le rabais a bien été supprimé")
        Else
            MessageBox.Show("Veuillez choisir le rabais que vous voulez supprimer")
        End If

    End Sub

    Private Sub dgRabais_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgRabais.SelectionChanged
        If dgRabais.SelectedIndex <> -1 Then
            Dim rabais As Integer = dgRabais.SelectedItem.noRabais
            Dim res = From ra In bd.tblRabais
                      Where rabais = ra.noRabais
                      Select ra

            For Each el In cbTypeChambre.Items
                If el.codeTypeChambre = res.Single.codeTypeChambre Then
                    cbTypeChambre.SelectedItem = el
                    Exit For
                End If
            Next
            If res.Single.etatRabais = "AC" Then
                chkActif.IsChecked = True
            Else
                chkActif.IsChecked = False
            End If
            numTaux.Value = res.Single.tauxRabais * 100
        End If

    End Sub

    Private Sub ModifcRab_Click(sender As Object, e As RoutedEventArgs) Handles ModifcRab.Click
        If dgRabais.SelectedIndex <> -1 Then
            Dim rabais As Integer = dgRabais.SelectedItem.noRabais
            Dim res = From ra In bd.tblRabais
                      Where rabais = ra.noRabais
                      Select ra

            res.Single.codeTypeChambre = cbTypeChambre.SelectedItem.codeTypeChambre
            If chkActif.IsChecked Then
                res.Single.etatRabais = "AC"
            Else
                res.Single.etatRabais = "IN"
            End If

            res.Single.tauxRabais = Convert.ToDecimal(numTaux.Value) / 100
            bd.SaveChanges()
            requete()
            MessageBox.Show("Le rabais a bien été modifié")
        Else
            MessageBox.Show("Veuillez sélectionner le rabais que vous voulez modifier")
        End If
    End Sub
End Class
