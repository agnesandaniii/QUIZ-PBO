Public Class frmlayanan

    Private Sub layanan_Load(sender As System.Object, e As System.EventArgs)
        reload()
    End Sub
    Private Sub reload()
        Olayanan.getAllData(DataGridView1)
    End Sub


    Private Sub Tampillayanan()
        txtKodeLayanan.Text = Olayanan.kode_layanan
        txtNamaLayanan.Text = Olayanan.nama_layanan
        txtHarga.Text = Olayanan.harga
    End Sub
    Private Sub SimpanDataLayanan()
        Olayanan.kode_layanan = txtKodeLayanan.Text
        Olayanan.nama_layanan = txtNamaLayanan.Text
        Olayanan.harga = txtHarga.Text
        Olayanan.Simpan()
        reload()
        If (Olayanan.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (Olayanan.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        clearentry()
    End Sub

    Private Sub clearentry()
        txtKodeLayanan.Clear()
        txtNamaLayanan.Clear()
        txtHarga.Clear()
        txtKodeLayanan.Focus()
        txtBayar.Clear()
        txtKembalian.Clear()
    End Sub

    Private Sub txtKodeLayanan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtKodeLayanan.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Olayanan.Carilayanan(txtKodeLayanan.Text)
            If (layanan_baru = False) Then
                Tampillayanan()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub btnBayar_Click(sender As System.Object, e As System.EventArgs) Handles btnBayar.Click
        txtKembalian.Text = CDec(txtBayar.Text) - CDec(txtHarga.Text)
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        clearentry()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If (txtKodeLayanan.Text <> "" And txtNamaLayanan.Text <> "") Then
            SimpanDataLayanan()
            clearentry()
            reload()
        Else
            MessageBox.Show("Kode tidak boleh kosong!")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub frmlayanan_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub
End Class