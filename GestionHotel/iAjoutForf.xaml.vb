Public Class iAjoutForf
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private ajout As Boolean

    Sub New(p1 As Boolean)
        ' TODO: Complete member initialization 
        InitializeComponent()
        ajout = p1
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

        Dim res = From el In bd.tblTypeChambre Select el.nomTypeChambre
        cbTypeChambre.DataContext = res.ToList()
        cbTypeChambre.AllowDrop = True
    End Sub

    Private Sub AjouterForf_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterForf.Click
        Dim Forfait As New tblForfait
        Forfait.prixForfait = txtPrixForf.Text
        Forfait.descForfait = txtDescAct.Text
        Forfait.codeTypeChambre = cbTypeChambre.SelectedItem.codeTypeChambre
        If  Then

        End If

        Forfait.etatForfait

        bd.tblForfait.Add(Forfait)
        bd.SaveChanges()
        MessageBox.Show("Le forfait a été créé avec succès.")
    End Sub
End Class
