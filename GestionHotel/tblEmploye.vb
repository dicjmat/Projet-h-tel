'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré à partir d'un modèle.
'
'     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
'     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class tblEmploye
    Public Property noEmpl As Short
    Public Property nomEmpl As String
    Public Property prenEmpl As String
    Public Property noTelEmpl As String
    Public Property noCellEmpl As String
    Public Property adrEmpl As String
    Public Property codeVille As String
    Public Property codeProv As String
    Public Property NAS As String
    Public Property dateEmbauche As Date
    Public Property noHotel As Byte
    Public Property codeProf As String
    Public Property hrSemaine As Nullable(Of Byte)
    Public Property hrtravail As Nullable(Of Short)
    Public Property salaire As Decimal
    Public Property joursVac As Nullable(Of Byte)
    Public Property joursFerie As Nullable(Of Byte)
    Public Property joursMal As Nullable(Of Byte)
    Public Property codePostalEmploye As String
    Public Property emailEmploye As String

    Public Overridable Property tblChecklist As ICollection(Of tblChecklist) = New HashSet(Of tblChecklist)
    Public Overridable Property tblCommande As ICollection(Of tblCommande) = New HashSet(Of tblCommande)
    Public Overridable Property tblHotel As tblHotel
    Public Overridable Property tblVille As tblVille
    Public Overridable Property tblProfession As tblProfession
    Public Overridable Property tblHoraire As ICollection(Of tblHoraire) = New HashSet(Of tblHoraire)
    Public Overridable Property tblLogin As ICollection(Of tblLogin) = New HashSet(Of tblLogin)
    Public Overridable Property tblReservation As ICollection(Of tblReservation) = New HashSet(Of tblReservation)

End Class
