Imports Microsoft.VisualBasic

Namespace VirtualLabIS.Common.Global.Clases
    Public Class Usuarios
        Shared intUserID As Integer
        Shared strUserEmail As String
        Shared strUserName As String
        Shared strFullName As String
        Public strUserNameTest As String
        Shared strGroupId As String
        Shared strFirstName As String
        Shared strLastName As String


        Private intExpColumna_Id As Integer

        Public Property strUserName_Test() As String
            Get
                Return strUserNameTest
            End Get
            Set(ByVal value As String)
                strUserNameTest = value
            End Set
        End Property

        Public Shared Property User_Id() As Integer
            Get
                Return intUserID
            End Get
            Set(ByVal value As Integer)
                intUserID = value
            End Set
        End Property

        'Get the user mail 
        Public Shared Property User_Email() As String
            Get
                Return strUserEmail
            End Get
            Set(ByVal value As String)
                strUserEmail = value
            End Set
        End Property

        'Get the user name 
        Public Shared Property User_Name() As String
            Get
                Return strUserName
            End Get
            Set(ByVal value As String)
                strUserName = value
            End Set
        End Property

        'Get the Fullname of user
        Public Shared Property Full_Name() As String
            Get
                Return strFullName
            End Get
            Set(ByVal value As String)
                strFullName = value
            End Set
        End Property

        'Get the group id
        Public Shared Property Group_Id() As String
            Get
                Return strGroupId
            End Get
            Set(ByVal value As String)
                strGroupId = value
            End Set
        End Property

        'Get the first name
        Public Shared Property FirstName() As String
            Get
                Return strFirstName
            End Get
            Set(ByVal value As String)
                strFirstName = value
            End Set
        End Property

        'Get the last name
        Public Shared Property LastName() As String
            Get
                Return strLastName
            End Get
            Set(ByVal value As String)
                strLastName = value
            End Set
        End Property

    End Class
End Namespace
