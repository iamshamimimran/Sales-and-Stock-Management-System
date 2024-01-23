Public Class Loginform

    Public LoginUser As String
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If (IsFormValid()) Then
            qry = "Select * from UserLogin where UserName='" & TextBox1.Text & "' and Password='" & TextBox2.Text & "' and UserType='" & ComboBox1.Text & "'"
            ds = SearchData(qry)
            If (ds.Tables(0).Rows.Count > 0) Then

                LoginUser = TextBox1.Text
                Homepage.Show()
                Me.Close()
            Else
                MsgBox("User name and password not correct", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Function IsFormValid() As Boolean
        If (TextBox1.Text.Trim() = String.Empty) Then
            MsgBox("User name is required", MsgBoxStyle.Critical)
            TextBox1.Clear()
            TextBox2.Clear()
            Return False
        End If
        If (TextBox2.Text.Trim() = String.Empty) Then
            MsgBox("Password is required", MsgBoxStyle.Critical)
            TextBox1.Clear()
            TextBox2.Clear()
            Return False
        End If
        If (ComboBox1.SelectedIndex = -1) Then
            MsgBox("User type is required", MsgBoxStyle.Critical)
            TextBox1.Clear()
            TextBox2.Clear()
            Return False
        End If

        Return True
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        btnLogin.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Registration.Show()

    End Sub
End Class