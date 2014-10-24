Public Class iAjoutForf
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private ajout As Boolean
    Private _hotel As Short
    Private _p1 As Boolean
    Private _p3 As Object

    Sub New(p1 As Boolean, hotel As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        ajout = p1
        _hotel = hotel
    End Sub

    Sub New(p1 As Boolean, hotel As Short, p3 As Object)
        ' TODO: Complete member initialization 
        _p1 = p1
        _hotel = hotel
        _p3 = p3
    End Sub

    Private Sub windowAjoutForf_Loaded(sender As Object, e As RoutedEventArgs) Handles windowAjoutForf.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
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

        Dim res = From tych In bd.tblTypeChambre
                  Join tycho In bd.tblTypeChambreHotel
                  On tycho.codeTypeChambre Equals tych.codeTypeChambre
                  Where tycho.noHotel = _hotel
                  Select tych
        cbTypeChambre.DataContext = res.ToList()
        cbTypeChambre.AllowDrop = True
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
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub btnModifierForf_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierForf.Click

    End Sub
End Class
