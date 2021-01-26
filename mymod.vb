Imports DevComponents.DotNetBar
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Module mymod
    Public cldProduk As New frmproduk()
    Public cldLayanan As New frmlayanan()

    Public mycommand As New System.Data.SqlClient.SqlCommand
    Public myadapter As New System.Data.SqlClient.SqlDataAdapter
    Public mydata As New DataTable
    Public DR As System.Data.SqlClient.SqlDataReader
    Public SQL As String
    Public conn As New SqlConnection
    Public cn As New connection

    Public menu_produk As Boolean
    Public menu_layanan As Boolean

    Public user_baru As Boolean
    Public oUser As New user

    Public login_valid As Boolean

    Public TotalTab As Integer = 0
    Public x As Integer

    Public Produk_baru As Boolean
    Public Oproduk As New produk

    Public layanan_baru As Boolean
    Public Olayanan As New layanan

    Public Function getTabIndex(ByVal mytab As TabControl, ByVal sCari As String)
        Dim i As Integer
        For i = 0 To TotalTab - 1
            If (mytab.Tabs(i).Text = sCari) Then

                Exit For
            End If
        Next
        getTabIndex = i
    End Function

    Public Sub DBConnect()
        cn.DataSource = "USER-PC\SQLEXPRESS"
        cn.DatabaseName = "salonagnes"
        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub

    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

    Public Sub BikinMenu(ByVal Child As Form, ByVal mytab As TabControl, ByVal sTitle As String)

        Dim newTab As DevComponents.DotNetBar.TabItem = mytab.CreateTab(sTitle)
        Dim panel As DevComponents.DotNetBar.TabControlPanel = DirectCast(newTab.AttachedControl, Panel)


        Child.TopLevel = False
        Child.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Child.Dock = DockStyle.Fill
        Child.Show()
        panel.Controls.Add(Child)
    End Sub
End Module
