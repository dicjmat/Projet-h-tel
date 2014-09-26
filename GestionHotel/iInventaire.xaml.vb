Public Class iInventaire

    Private _p2 As Short
    Dim maBD As P2014_Equipe2_GestionHôtelièreEntities
    Sub New(p2 As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        _p2 = p2
    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        maBD = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From item In maBD.tblItem Join el In maBD.tblInventaire On el.codeItem Equals item.codeItem Where el.noHotel = _p2 Select el.codeItem, item.nomItem, el.Quantite, item.descItem
        lstInventaire.ItemsSource = res.ToList
    End Sub

    Private Sub txtCodeItem_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtCodeItem.TextChanged
        Dim res = From item In maBD.tblItem Join el In maBD.tblInventaire On el.codeItem Equals item.codeItem Where el.noHotel = _p2 And item.codeItem.StartsWith(txtCodeItem.Text) Select el.codeItem, item.nomItem, el.Quantite, item.descItem
        lstInventaire.ItemsSource = res.ToList
    End Sub


    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub
End Class
