Public Class iAjouterCommunique

    Private maBd As P2014_Equipe2_GestionHôtelièreEntities
    Private _noHotel As Short
    Private noCommu As Integer

    Sub New(_maBd As P2014_Equipe2_GestionHôtelièreEntities, noHotel As Short)
        InitializeComponent()
        maBd = _maBd
        _noHotel = noHotel
        btnModifier.Visibility = Windows.Visibility.Hidden
    End Sub

    Sub New(_maBd As P2014_Equipe2_GestionHôtelièreEntities, noHotel As Short, p3 As Integer)
        InitializeComponent()
        maBd = _maBd
        _noHotel = noHotel
        noCommu = p3
        btnAjouter.Visibility = Windows.Visibility.Hidden
        Dim commu = From co In maBd.tblCommunique Where _noHotel = co.noHotel Select co

        txtNomCommunique.Text = commu.Single.titreCommunique
        txtTexteCommunique.Text = commu.Single.contCommunique
        If commu.Single.etatCommunique = "actif" Then
            chkStatutCommunique.IsChecked = True
        Else
            chkStatutCommunique.IsChecked = False
        End If
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtNomCommunique.Text <> "" And txtTexteCommunique.Text <> "" Then
            Dim commu = New tblCommunique
            commu.noHotel = _noHotel
            commu.titreCommunique = txtNomCommunique.Text
            commu.contCommunique = txtTexteCommunique.Text
            If chkStatutCommunique.IsChecked Then
                commu.etatCommunique = "actif"
            Else
                commu.etatCommunique = "inactif"
            End If
            maBd.tblCommunique.Add(commu)
            maBd.SaveChanges()
            MessageBox.Show("Le communiqué a bien été ajouté")
            Me.Close()
        End If


    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles btnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles btnModifier.Click
        Dim commu = From co In maBd.tblCommunique Where _noHotel = co.noHotel Select co

        If txtNomCommunique.Text <> "" And txtTexteCommunique.Text <> "" Then
            commu.Single.titreCommunique = txtNomCommunique.Text
            commu.Single.contCommunique = txtTexteCommunique.Text
            If chkStatutCommunique.IsChecked Then
                commu.Single.etatCommunique = "actif"
            Else
                commu.Single.etatCommunique = "inactif"
            End If
            maBd.SaveChanges()
            MessageBox.Show("Le communiqué a bien été modifié")
            Me.Close()
        End If
    End Sub
End Class
