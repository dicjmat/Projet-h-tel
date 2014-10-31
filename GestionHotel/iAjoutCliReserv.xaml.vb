Public Class iAjoutCliReserv
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Sub New()
        ' TODO: Complete member initialization 
        InitializeComponent()
    End Sub
    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _nomClient As String, _prenClient As String, _noTel As String, _noCell As String, _adr As String, _noCarte As String, _type As String, _dateEx As String)
        ' TODO: Complete member initialization 
        InitializeComponent()
        bd = maBD
        txtNomCli.Text = _nomClient
        txtPrenCli.Text = _prenClient
        txtTelCli.Text = _noTel
        txtCelCli.Text = _noCell
        txtAdrCli.Text = _adr
        txtNoCarteCredit.Text = _noCarte
        txtCodeExp.Text = _dateEx
    End Sub
    Private Sub window_AjoutCliReserv_Loaded(sender As Object, e As RoutedEventArgs) Handles window_AjoutCliReserv.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From cli In bd.tblClient
             Group cli By cli.typeCarteCredit Into Group
             Select Group.FirstOrDefault()
        Dim res2 = From el In bd.tblVille Select el
        cbTypeCarte.DataContext = res.ToList()
        cbCodeVille.DataContext = res2.Distinct().ToList()
    End Sub

    Private Sub btnAjouterCli_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterCli.Click
        Dim client As New tblClient
        client.nomClient = txtNomCli.Text.Trim
        client.prenClient = txtPrenCli.Text.Trim
        client.noTelClient = txtTelCli.Text
        client.noCellClient = txtCelCli.Text
        client.adrClient = txtAdrCli.Text.Trim
        client.noCarteCredit = txtNoCarteCredit.Text
        client.typeCarteCredit = cbTypeCarte.SelectedItem.typeCarteCredit
        client.dateExpiration = txtCodeExp.Text
        client.codeVille = cbCodeVille.SelectedItem.codeVille
        client.commentaire = txtCommCli.Text.Trim
        bd.tblClient.Add(client)
        bd.SaveChanges()
        MessageBox.Show("Le client a été ajouté avec succès.")

    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub
End Class
