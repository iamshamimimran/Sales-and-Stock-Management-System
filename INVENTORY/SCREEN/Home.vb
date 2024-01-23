Public Class Homepage

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AddStock.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Loginform.Show()
        Me.Close()

    End Sub

    Private Sub Homepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loggedIn.Text = My.Forms.Loginform.LoginUser
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Registration.Show()

    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SellItem.Show()
        Me.Hide()
    End Sub

    Private Sub loggedIn_Click(sender As Object, e As EventArgs) Handles loggedIn.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SaleInfo.Show()

    End Sub

    'Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    'End Sub
End Class