Public Class frmproduk

    Private Sub frmproduk_Load(sender As System.Object, e As System.EventArgs)
        reload()
    End Sub
    Private Sub reload()
        Oproduk.getAllData(DataGridView1)
    End Sub

    Private Sub TampilProduk()
        txtKodeProduk.Text = Oproduk.kode_produk
        txtNamaProduk.Text = Oproduk.nama_produk
        txtHarga.Text = Oproduk.harga
    End Sub
    Private Sub SimpanDataProduk()
        Oproduk.kode_produk = txtKodeProduk.Text
        Oproduk.nama_produk = txtNamaProduk.Text
        Oproduk.harga = txtHarga.Text
        Oproduk.Simpan()
        reload()
        If (Oproduk.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (Oproduk.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        clearentry()
    End Sub

    Private Sub clearentry()
        txtKodeProduk.Clear()
        txtNamaProduk.Clear()
        txtHarga.Clear()
        txtKodeProduk.Focus()
        txtBayar.Clear()
        txtKembalian.Clear()
    End Sub

    Private Sub txtKodeProduk_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            Oproduk.Cariproduk(txtKodeProduk.Text)
            If (Produk_baru = False) Then
                TampilProduk()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs)
        clearentry()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs)
        If (txtKodeProduk.Text <> "" And txtNamaProduk.Text <> "") Then
            SimpanDataProduk()
            clearentry()
            reload()
        Else
            MessageBox.Show("Kode tidak boleh kosong!")
        End If
    End Sub

    Private Sub btnBayar_Click(sender As System.Object, e As System.EventArgs) Handles btnBayar.Click
        txtKembalian.Text = CDec(txtBayar.Text) - CDec(txtHarga.Text)
    End Sub

    Private Sub frmproduk_Load_1(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub

    Private Sub txtKodeProduk_KeyDown1(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtKodeProduk.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Oproduk.Cariproduk(txtKodeProduk.Text)
            If (Produk_baru = False) Then
                TampilProduk()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub btnClear_Click_1(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        clearentry()
    End Sub

    Private Sub btnSave_Click_1(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If (txtKodeProduk.Text <> "" And txtNamaProduk.Text <> "") Then
            SimpanDataProduk()
            clearentry()
            reload()
        Else
            MessageBox.Show("Kode tidak boleh kosong!")
        End If
    End Sub
End Class