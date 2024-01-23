Imports System.Data
Imports System.Data.SqlClient


Public Class Registration
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (IsFormValid()) Then
            qry = "Insert into UserLogin values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox2.Text & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
            If (logincorrect) Then

                MsgBox("ACCOUNT CREATED SUCCESFULLY", MsgBoxStyle.Information)
                CLR()
                Me.Close()
            Else
                MsgBox("ERROR RECORD NOT SAVED", MsgBoxStyle.Critical)

            End If

        End If
    End Sub

    Private Sub CLR()
        TextBox4.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox1.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Function IsFormValid() As Boolean
        If (TextBox4.Text.Trim() = String.Empty) Then
            MsgBox("PASSWORD IS REQUIRED", MsgBoxStyle.Critical)
            TextBox4.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox1.Clear()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1

            Return False
        End If
        If (TextBox2.Text.Trim() = String.Empty) Then
            MsgBox("LAST NAME IS REQUIRED", MsgBoxStyle.Critical)
            TextBox4.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox1.Clear()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1


            Return False
        End If
        If (TextBox3.Text.Trim() = String.Empty) Then
            MsgBox("USERNAME IS REQUIRED", MsgBoxStyle.Critical)
            TextBox4.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox1.Clear()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1


            Return False
        End If
        If (TextBox1.Text.Trim() = String.Empty) Then
            MsgBox("FIRST NAME IS REQUIRED", MsgBoxStyle.Critical)
            TextBox4.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox1.Clear()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1

            Return False
        End If
        If (ComboBox1.SelectedIndex = -1) Then
            MsgBox("POSITION IS REQUIRED", MsgBoxStyle.Critical)
            'TextBox4.Clear()
            'TextBox2.Clear()
            'TextBox3.Clear()
            'TextBox1.Clear()
            'ComboBox1.SelectedIndex = -1
            'ComboBox2.SelectedIndex = -1

            Return False
        End If
        If (ComboBox2.SelectedIndex = -1) Then
            MsgBox("USER TYPE IS REQUIRED", MsgBoxStyle.Critical)
            'TextBox4.Clear()
            'TextBox2.Clear()
            'TextBox3.Clear()
            'TextBox1.Clear()
            'ComboBox1.SelectedIndex = -1
            'ComboBox2.SelectedIndex = -1

            Return False
        End If

        Return True
    End Function
End Class