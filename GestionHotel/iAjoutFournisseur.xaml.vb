Public Class iAjoutFournisseur
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities
    Private _bd As P2014_Equipe2_GestionHôtelièreEntities
    Private _item As String
    Private _noHotel As Integer

    Sub New(bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        maBd = bd
    End Sub

    Sub New(bd As P2014_Equipe2_GestionHôtelièreEntities, item As String)
        InitializeComponent()
        maBd = bd
        _item = item
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
        Me.Owner.Show()
    End Sub

    Private Sub btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirmer.Click
        Dim fournisseur = New tblFournisseur
        fournisseur.nomFournisseur = txtNomFourni.Text
        fournisseur.adrFournisseur = txtAdrFourni.Text
        fournisseur.CPFournisseur = txtcodePostFourni.Text
        fournisseur.noTelFournisseur = txtnoTelFourni.Text
        fournisseur.respFournisseur = txtRespFourni.Text
        fournisseur.codeVille = cbVilleFourni.SelectedItem.codeVille
        fournisseur.codeProv = cbVilleFourni.SelectedItem.codeProv
        maBd.tblFournisseur.Add(fournisseur)
        maBd.SaveChanges()
        MessageBox.Show("Le fournisseur a bien été ajouté")
    End Sub

    Private Sub windowAjoutFournisseur_Loaded(sender As Object, e As RoutedEventArgs) Handles windowAjoutFournisseur.Loaded
        Dim res = From Vi In maBd.tblVille
                  Select Vi
        cbVilleFourni.DataContext = res.ToList
    End Sub


    Private Sub windowAjoutFournisseur_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowAjoutFournisseur.Closing
        Me.Owner.Show()
    End Sub
End Class
