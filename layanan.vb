Public Class layanan
    Public mycommand As New System.Data.SqlClient.SqlCommand
    Public myadapter As New System.Data.SqlClient.SqlDataAdapter
    Public mydata As New DataTable
    Dim strsql As String
    Dim info As String
    Private _idlayanan As System.Int32
    Private _kode_layanan As System.String
    Private _nama_layanan As System.String
    Private _harga As System.Int32
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_layanan()
        Get
            Return _kode_layanan
        End Get
        Set(ByVal value)
            _kode_layanan = value
        End Set
    End Property
    Public Property nama_layanan()
        Get
            Return _nama_layanan
        End Get
        Set(ByVal value)
            _nama_layanan = value
        End Set
    End Property
    Public Property harga()
        Get
            Return _harga
        End Get
        Set(ByVal value)
            _harga = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (layanan_baru = True) Then
            strsql = "Insert into layanan(kode_layanan,nama_layanan,harga) values ('" & _kode_layanan & "','" & _nama_layanan & "','" & _harga & "')"
            info = "INSERT"
        Else
            strsql = "update layanan set kode_layanan='" & _kode_layanan & "', nama_layanan='" & _nama_layanan & "', harga='" & _harga & "' where kode_layanan='" & _kode_layanan & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub Carilayanan(ByVal skode_layanan As String)
        DBConnect()
        strsql = "SELECT * FROM layanan WHERE kode_layanan='" & skode_layanan & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            layanan_baru = False
            DR.Read()
            kode_layanan = Convert.ToString((DR("kode_layanan")))
            nama_layanan = Convert.ToString((DR("nama_layanan")))
            harga = Convert.ToString((DR("harga")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            layanan_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal skode_layanan As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM layanan WHERE kode_layanan='" & skode_layanan & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM layanan"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub

End Class
