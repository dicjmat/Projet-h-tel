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

Partial Public Class tblReservation
    Public Property noReservation As Integer
    Public Property dateDebutSejour As Date
    Public Property dateFinSejour As Date
    Public Property dateReserv As Date
    Public Property prixReserv As Nullable(Of Decimal)
    Public Property commentaire As String
    Public Property noSalle As Short
    Public Property noHotel As Byte
    Public Property noClient As Nullable(Of Integer)
    Public Property noDemandeur As Nullable(Of Integer)
    Public Property noEmpl As Nullable(Of Short)
    Public Property noForfait As Nullable(Of Byte)
    Public Property noRabais As Nullable(Of Byte)

    Public Overridable Property tblEmploye As tblEmploye
    Public Overridable Property tblClient As tblClient
    Public Overridable Property tblDemandeur As tblDemandeur
    Public Overridable Property tblForfait As tblForfait
    Public Overridable Property tblNote As ICollection(Of tblNote) = New HashSet(Of tblNote)
    Public Overridable Property tblRabais As tblRabais
    Public Overridable Property tblSalle As tblSalle

End Class
