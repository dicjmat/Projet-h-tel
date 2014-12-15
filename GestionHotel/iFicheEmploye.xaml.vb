Imports System.Text.RegularExpressions

Public Class iFicheEmploye
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private numEmpl As Integer
    Private noGest As Short
    Private hotel As Short

    Sub New(_noGest As Short, noHotel As Short, _numEmpl As Integer, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        numEmpl = _numEmpl
        bd = _bd
        noGest = _noGest
        hotel = noHotel
        Dim res = From el In bd.tblLogin Where el.noEmpl = noGest Select el

        btnModifier.Visibility = Windows.Visibility.Visible

        If res.First.statut = "GEST" Then
            menu.Visibility = Windows.Visibility.Hidden
            menu.IsEnabled = False
        Else
            menuGest.Visibility = Windows.Visibility.Hidden
            menuGest.IsEnabled = False
        End If

        txtNASEmp.IsEnabled = False
    End Sub

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noHotel As Integer, _noGest As Integer)
        InitializeComponent()
        bd = _bd
        noGest = _noGest
        hotel = _noHotel
        Dim res = From el In bd.tblLogin Where el.noEmpl = noGest Select el
        btnModifier.Visibility = Windows.Visibility.Hidden
        txtNASEmp.IsEnabled = True

        If res.First.statut = "GEST" Then
            menu.Visibility = Windows.Visibility.Hidden
            menu.IsEnabled = False
        Else
            menuGest.Visibility = Windows.Visibility.Hidden
            menuGest.IsEnabled = False
        End If
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

        Dim ress = From el In bd.tblLogin Where el.noEmpl = numEmpl Select el

        If ress.First.statut = "GEST" Then
            menu.Visibility = Windows.Visibility.Hidden
            menu.IsEnabled = False
        Else
            menuGest.Visibility = Windows.Visibility.Hidden
            menuGest.IsEnabled = False
        End If


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
        Dim regNASCanada As Regex = New Regex("^[0-9]{3}[, -]?[0-9]{3}[, -]?[0-9]{3}$")
        If Not (txtNomEmp.Text = "" Or txtPrenomEmp.Text = "" Or txtTellEmp.Text = "" Or txtAdrEmp.Text = "" Or regNASCanada.IsMatch("txtNasEmp.Text") Or txtSalaireEmp.Text = "") Then
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
                Employe.codeProv = cmbProvince.SelectedItem.codeProv
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

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
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
    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs)
        Dim employe = From em In bd.tblEmploye
                      Where em.noEmpl = numEmpl
                      Select em

        If Not (txtNomEmp.Text = "" Or txtPrenomEmp.Text = "" Or txtTellEmp.Text = "" Or txtAdrEmp.Text = "" Or txtNASEmp.Text = "" Or txtSalaireEmp.Text = "") Then
            employe.Single.nomEmpl = txtNomEmp.Text
            employe.Single.prenEmpl = txtPrenomEmp.Text
            employe.Single.noTelEmpl = txtTellEmp.Text

            If txtCellEmp.Text <> "   -   -    " Then
                employe.Single.noCellEmpl = txtCellEmp.Text
            End If

            employe.Single.adrEmpl = txtAdrEmp.Text
            employe.Single.dateEmbauche = DPEmbaucheEmp.Text

            If txtHrsEmp.Text <> "" Then
                employe.Single.hrtravail = txtHrsEmp.Text
            End If

            If txtVacEmp.Text <> "" Then
                employe.Single.joursVac = txtVacEmp.Text
            End If

            If txtFerieEmp.Text <> "" Then
                employe.Single.joursFerie = txtFerieEmp.Text
            End If

            If txtMaladieEmp.Text <> "" Then
                employe.Single.joursMal = txtMaladieEmp.Text
            End If

            employe.Single.salaire = txtSalaireEmp.Text
            If cmbCdVille.SelectedIndex <> -1 Then
                employe.Single.codeVille = cmbCdVille.SelectedItem.codeVille
                employe.Single.codeProv = cmbProvince.SelectedItem.codeProv
                If cmbCdProf.SelectedIndex <> -1 Then
                    employe.Single.codeProf = cmbCdProf.SelectedItem.codeProf
                    If cmbNoHot.SelectedIndex <> -1 Then
                        employe.Single.noHotel = cmbNoHot.SelectedItem.noHotel
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
            MessageBox.Show("L'employé a été modifié avec succès.")
        Else
            MessageBox.Show("Un des champs obligatoires n'a pas été rempli")
        End If
    End Sub
    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(bd, hotel, noGest)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmploye(noGest, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim horaire = New iAjouterHoraire(numEmpl, hotel, bd)
        horaire.Owner = Me
        horaire.Show()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCOmmande(noGest, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim lst = New iCommunique(numEmpl, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(bd, hotel, noGest)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmploye(noGest, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim horaire = New iAjouterHoraire(numEmpl, hotel, bd)
        horaire.Owner = Me
        horaire.Show()
    End Sub

    Private Sub MenuItem_Click_8(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmploye(noGest, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_9(sender As Object, e As RoutedEventArgs)
        Dim com = New iCommande(numEmpl, bd)
        com.Owner = Me
        com.Show()
    End Sub

    Private Sub MenuItem_Click_10(sender As Object, e As RoutedEventArgs)
        Dim lst = New iCommunique(numEmpl, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_11(sender As Object, e As RoutedEventArgs)
        Dim item = New iAjouterItem(bd, numEmpl, hotel)
        item.Owner = Me
        item.Show()
    End Sub

    Private Sub MenuItem_Click_12(sender As Object, e As RoutedEventArgs)
        Dim fourni = New iAjoutFournisseur(bd)
        fourni.Owner = Me
        fourni.Show()
    End Sub

    Private Sub MenuItem_Click_13(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionSalle(bd)
        gest.Owner = Me
        gest.Show()
    End Sub

    Private Sub MenuItem_Click_14(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionChambre(bd, hotel)
        gest.Owner = Me
        gest.Show()
    End Sub

    Private Sub MenuItem_Click_15(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionHotel(bd)
        gest.Owner = Me
        gest.Show()
    End Sub

    Private Sub MenuItem_Click_16(sender As Object, e As RoutedEventArgs)
        Dim inv = New iInventaireComplet(bd, numEmpl, hotel)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub MenuItem_Click_17(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCentrale(bd, numEmpl, hotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_18(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmployeComplet(bd, numEmpl, hotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_19(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeHotel(bd, numEmpl, hotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_20(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(hotel, bd, numEmpl)
        lst.Owner = Me
        lst.Show()
    End Sub
End Class
