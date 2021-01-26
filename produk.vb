Public Class produk
    Dim strsql As String
    Dim info As String
    Private _idproduk As System.Int32
    Private _kode_produk As System.String
    Private _nama_produk As System.String
    Private _harga As System.Int32
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_produk()
        Get
            Return _kode_produk
        End Get
        Set(ByVal value)
            _kode_produk = value
        End Set
    End Property
    Public Property nama_produk()
        Get
            Return _nama_produk
        End Get
        Set(ByVal value)
            _nama_produk = value
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
        If (produk_baru = True) Then
            strsql = "Insert into produk(kode_produk,nama_produk,harga) values ('" & _kode_produk & "','" & _nama_produk & "','" & _harga & "')"
            info = "INSERT"
        Else
            strsql = "update produk set kode_produk='" & _kode_produk & "', nama_produk='" & _nama_produk & "', harga='" & _harga & "' where kode_produk='" & _kode_produk & "'"
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
    Public Sub Cariproduk(ByVal skode_produk As String)
        DBConnect()
        strsql = "SELECT * FROM produk WHERE kode_produk='" & skode_produk & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            produk_baru = False
            DR.Read()
            kode_produk = Convert.ToString((DR("kode_produk")))
            nama_produk = Convert.ToString((DR("nama_produk")))
            harga = Convert.ToString((DR("harga")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            produk_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal skode_produk As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM produk WHERE kode_produk='" & skode_produk & "'"
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
            strsql = "SELECT * FROM produk"
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
