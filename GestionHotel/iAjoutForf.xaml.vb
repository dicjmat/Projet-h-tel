Public Class iAjoutForf
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private ajout As Boolean
    Private _hotel As Short
    Private forfait As Integer

    Sub New(p1 As Boolean, hotel As Short)
        ' TODO: Complete member initialization 
        bd = New P2014_Equipe2_GestionHôtelièreEntities

        InitializeComponent()
        ajout = p1
        _hotel = hotel
        remplirTypeChambre()
    End Sub

    Sub New(p1 As Boolean, hotel As Short, p3 As Integer)
        ' TODO: Complete member initialization
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        InitializeComponent()
        ajout = p1
        _hotel = hotel
        forfait = p3
        remplirTypeChambre()
        Dim res = From fo In bd.tblForfait
                  Where fo.noForfait = forfait
                  Select fo
        If res.Single.etatForfait = "AC" Then
            ckActif.IsChecked = True
        Else
            ckActif.IsChecked = False
        End If

        txtNomForf.Text = res.Single.nomForfait
        txtDescAct.Text = res.Single.descForfait
        txtPrixForf.Text = res.Single.prixForfait
        For Each el In cbTypeChambre.Items
            If el.codeTypeChambre = res.Single.codeTypeChambre Then
                cbTypeChambre.SelectedItem = el
                Exit For
            End If
        Next
    End Sub

    Private Sub windowAjoutForf_Loaded(sender As Object, e As RoutedEventArgs) Handles windowAjoutForf.Loaded
        If ajout Then
            btnModifierForf.IsEnabled = False
            btnModifierForf.Visibility = Windows.Visibility.Hidden
            btnAjouterForf.IsEnabled = True
            btnAjouterForf.Visibility = Windows.Visibility.Visible
        Else
            btnModifierForf.IsEnabled = True
            btnModifierForf.Visibility = Windows.Visibility.Visible
            btnAjouterForf.IsEnabled = False
            btnAjouterForf.Visibility = Windows.Visibility.Hidden
        End If
    End Sub

    Private Sub AjouterForf_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterForf.Click
        Dim Forfait As New tblForfait
        If txtPrixForf.Text <> "" Or txtNomForf.Text <> "" Or txtDescAct.Text <> "" Then
            For Each el As Char In txtPrixForf.Text
                If el = "," Then
                    el = "."
                End If
            Next
            Forfait.prixForfait = txtPrixForf.Text
            Forfait.descForfait = txtDescAct.Text
            Forfait.codeTypeChambre = cbTypeChambre.SelectedItem.codeTypeChambre
            If ckActif.IsChecked Then
                Forfait.etatForfait = "AC"
            Else
                Forfait.etatForfait = "IN"
            End If
            Forfait.nomForfait = txtNomForf.Text
            Forfait.noHotel = _hotel
            bd.tblForfait.Add(Forfait)
            bd.SaveChanges()
            MessageBox.Show("Le forfait a été créé avec succès.")
        Else
            MessageBox.Show("Un des champs obligatoires n'a pas été rempli")
        End If
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub btnModifierForf_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierForf.Click
        Dim res = From fo In bd.tblForfait
                  Where fo.noForfait = forfait
                  Select fo
        If txtPrixForf.Text <> "" Or txtNomForf.Text <> "" Or txtDescAct.Text <> "" Then
            For Each el As Char In txtPrixForf.Text
                If el = "," Then
                    el = "."
                End If
            Next
            res.Single.prixForfait = txtPrixForf.Text
            res.Single.descForfait = txtDescAct.Text
            res.Single.codeTypeChambre = cbTypeChambre.SelectedItem.codeTypeChambre
            If ckActif.IsChecked Then
                res.Single.etatForfait = "AC"
            Else
                res.Single.etatForfait = "IN"
            End If
            res.Single.nomForfait = txtNomForf.Text
            bd.SaveChanges()
            MessageBox.Show("Le forfait a été créé avec succès.")
        Else
            MessageBox.Show("Un des champs obligatoires n'a pas été rempli")
        End If
    End Sub

    Private Sub remplirTypeChambre()
        Dim res = From tych In bd.tblTypeChambre
          Join tycho In bd.tblTypeChambreHotel
          On tycho.codeTypeChambre Equals tych.codeTypeChambre
          Where tycho.noHotel = _hotel
          Select tych
        cbTypeChambre.ItemsSource = res.ToList()
    End Sub
End Class
