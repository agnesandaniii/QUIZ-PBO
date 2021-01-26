Public Class Form1

    Private Sub ButtonItem14_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem14.Click
        If (menu_produk = False) Then
            BikinMenu(cldProduk, TabControl1, "Produk")
            menu_produk = True
        Else
            x = getTabIndex(TabControl1, "Produk")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub ButtonItem15_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem15.Click
        If (menu_layanan = False) Then
            BikinMenu(cldLayanan, TabControl1, "Layanan")
            menu_layanan = True
        Else
            x = getTabIndex(TabControl1, "Layanan")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub TabControl1_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TabControl1.ControlAdded
        TabControl1.SelectedTabIndex = TotalTab - 1
    End Sub

    Private Sub TabControl1_TabItemClose(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripActionEventArgs) Handles TabControl1.TabItemClose
        Dim itemToRemove As DevComponents.DotNetBar.TabItem = TabControl1.SelectedTab
        If (TotalTab > 2) Then
            TotalTab = TotalTab - 1
        Else
            TotalTab = 0
        End If


        TabControl1.Tabs.Remove(itemToRemove)
        TabControl1.Controls.Remove(itemToRemove.AttachedControl)
        TabControl1.RecalcLayout()


        If (itemToRemove.ToString = "Layanan") Then
            menu_layanan = False
        ElseIf (itemToRemove.ToString = "Produk") Then
            menu_produk = False
        Else

        End If
    End Sub

    Private Sub TabControl1_TabItemOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabItemOpen
        If (TotalTab = 0) Then
            TotalTab = TotalTab + 2
        Else
            TotalTab = TotalTab + 1
        End If
    End Sub

    Private Sub RibbonPanel1_Click(sender As System.Object, e As System.EventArgs) Handles RibbonPanel1.Click

    End Sub
End Class
