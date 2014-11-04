﻿Public Class iFicheEmploye
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private numEmpl As Integer
    Private noGest As Short
    Private hotel As Short


    Sub New(noEmpl As Short, noHotel As Short, _numEmpl As Integer, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        numEmpl = _numEmpl
        bd = _bd
        btnModifier.Visibility = Windows.Visibility.Visible
        btnAjouterItem.Visibility = Windows.Visibility.Hidden
    End Sub

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = _bd
        btnModifier.Visibility = Windows.Visibility.Hidden
        btnAjouterItem.Visibility = Windows.Visibility.Visible
    End Sub

    Private Sub windowFicheEmploye_Loaded(sender As Object, e As RoutedEventArgs) Handles windowFicheEmploye.Loaded
        cmbProvince.IsEnabled = False
        cmbCdVille.IsEnabled = False
        Dim pays = From pa In bd.tblPays Select pa
        Dim hotel = From el In bd.tblHotel Select el
        Dim profession = From el In bd.tblProfession Select el
        cmbPays.ItemsSource = pays.ToList()
        cmbNoHot.ItemsSource = hotel.ToList()
        cmbCdProf.ItemsSource = profession.ToList()
        If numEmpl <> 0 Then
            Dim res = From el In bd.tblEmploye Where el.noEmpl = numEmpl Select el
            Me.DataContext = res.ToList()
            Dim i = 0
            For Each el In cmbPays.Items
                If el.codePays = res.First.tblVille.tblProvince.codePays Then
                    cmbPays.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
            For Each el In cmbProvince.Items
                If el.codeProv = res.First.codeProv Then
                    cmbProvince.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
            For Each el In cmbCdVille.Items
                If el.codeVille = res.First.codeVille Then
                    cmbCdVille.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
            i = 0
            For Each el In cmbNoHot.Items
                If el.noHotel = res.First.noHotel Then
                    cmbNoHot.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
            i = 0
            For Each el In cmbCdProf.Items
                If el.codeProf = res.First.codeProf Then
                    cmbCdProf.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
        End If
    End Sub
    Private Sub btnCreer_Click(sender As Object, e As RoutedEventArgs)
        Dim Employe = New tblEmploye()
        If txtNomEmp.Text = "" Or txtPrenomEmp.Text = "" Or txtTellEmp.Text = "" Or txtAdrEmp.Text = "" Or txtNASEmp.Text = "" Or txtSalaireEmp.Text = "" Then
            Employe.nomEmpl = txtNomEmp.Text
            Employe.prenEmpl = txtPrenomEmp.Text
            Employe.noTelEmpl = txtTellEmp.Text

            If txtCellEmp.Text <> "   -   -    " Then
                Employe.noCellEmpl = txtCellEmp.Text
            End If

            Employe.adrEmpl = txtAdrEmp.Text
            Employe.NAS = txtNASEmp.Text
            Employe.dateEmbauche = DPEmbaucheEmp.Text

            If txtHrsEmp.Text <> "" Then
                Employe.hrtravail = txtHrsEmp.Text
            End If

            If txtVacEmp.Text <> "" Then
                Employe.joursVac = txtVacEmp.Text
            End If

            If txtFerieEmp.Text <> "" Then
                Employe.joursFerie = txtFerieEmp.Text
            End If

            If txtMaladieEmp.Text <> "" Then
                Employe.joursMal = txtMaladieEmp.Text
            End If

            Employe.salaire = txtSalaireEmp.Text
            If cmbCdVille.SelectedIndex <> -1 Then
                Employe.codeVille = cmbCdVille.SelectedItem.codeVille
                If cmbCdProf.SelectedIndex <> -1 Then
                    Employe.codeProf = cmbCdProf.SelectedItem.codeProf
                    If cmbNoHot.SelectedIndex <> -1 Then
                        Employe.noHotel = cmbNoHot.SelectedItem.noHotel
                        bd.tblEmploye.Add(Employe)
                        bd.SaveChanges()
                    Else
                        MessageBox.Show("Veuillez choisir un hôtel")
                    End If

                Else
                    MessageBox.Show("Veuillez choisir une profession")
                End If
            Else
                MessageBox.Show("Veuillez choisir une ville")
            End If
            MessageBox.Show("L'employé a été créé avec succès.")
        Else
            MessageBox.Show("Un des champs obligatoires n'a pas été rempli")
        End If


    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Dim lol = txtCellEmp.Text
        Me.Owner.Close()
        Me.Close()
        'Dim listeemploye As iListeEmploye
        'listeemploye = New iListeEmploye()
        'listeemploye.Close()
    End Sub
    Private Sub btnAnnuler_Click(sender As Object, e As RoutedEventArgs)
        windowFicheEmploye.Close()
    End Sub

    Private Sub btnAjoutHoraire_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutHoraire.Click
        Dim Horaire = New iAjouterHoraire(numEmpl, bd)
        Horaire.Owner = Me
        Horaire.Show()
        Me.Hide()
    End Sub


    Private Sub cmbPays_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbPays.SelectionChanged
        remplirProv()
    End Sub

    Private Sub remplirProv()
        If cmbPays.SelectedIndex <> -1 Then
            cmbProvince.IsEnabled = True
            Dim sPays As String = cmbPays.SelectedItem.codePays
            Dim province = From pro In bd.tblProvince Where pro.codePays = sPays Select pro

            cmbProvince.ItemsSource = province.ToList
        End If
    End Sub

    Private Sub remplirVille()
        If cmbProvince.SelectedIndex <> -1 Then
            cmbCdVille.IsEnabled = True
            Dim sProv As String = cmbProvince.SelectedItem.codeProv
            Dim ville = From vi In bd.tblVille Where vi.codeProv = sProv Select vi
            cmbCdVille.ItemsSource = ville.ToList
        End If
    End Sub

    Private Sub cmbProvince_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbProvince.SelectionChanged
        remplirVille()
    End Sub
    Private Sub btnListeEmpGest_Click(sender As Object, e As RoutedEventArgs) Handles btnListeEmpGest.Click
        Dim lst = New iListeEmploye(noGest, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnListeCommandeGest_Click(sender As Object, e As RoutedEventArgs) Handles btnListeCommandeGest.Click
        Dim lst = New iListeCOmmande(noGest, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs)
        'Dim employe = From 
    End Sub
End Class
