Public Class AddStock

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If (IsFormValid()) Then
            qry = "Insert into tblproductinfo values('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & My.Forms.Homepage.loggedIn.Text & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
            If (logincorrect) Then
                BindGD()
                MsgBox("STOCK ADDED SUCCESFULLY", MsgBoxStyle.Information)
                CLR()
            Else
                MsgBox("ERROR RECORD NOT SAVED", MsgBoxStyle.Critical)

            End If

        End If
    End Sub
    Private Function IsFormValid() As Boolean
        If (TextBox4.Text.Trim() = String.Empty) Then
            MsgBox("PRICE IS REQUIRED", MsgBoxStyle.Critical)
            TextBox4.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox5.Clear()

            Return False
        End If
        If (TextBox2.Text.Trim() = String.Empty) Then
            MsgBox("PRODUCT NAME IS REQUIRED", MsgBoxStyle.Critical)
            TextBox4.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox5.Clear()


            Return False
        End If
        If (TextBox3.Text.Trim() = String.Empty) Then
            MsgBox("DESC IS REQUIRED", MsgBoxStyle.Critical)
            TextBox4.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox5.Clear()


            Return False
        End If
        If (TextBox5.Text.Trim() = String.Empty) Then
            MsgBox("STOCK IS REQUIRED", MsgBoxStyle.Critical)
            TextBox4.Clear()
            TextBox2.Clear()
            TextBox3.Clear()

            Return False
        End If

        Return True
    End Function

    Public Sub BindGD()
        qry = "select * from tblproductinfo"
        ds = SearchData(qry)
        If (ds.Tables(0).Rows.Count > 0) Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            MsgBox("RECORD NOT FOUND", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub AddStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        BindGD()
        btnAdd.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
    End Sub
    Public Sub CLR()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        i = DataGridView1.CurrentRow.Index

        Me.TextBox1.Text = DataGridView1.Item(0, i).Value
        Me.TextBox2.Text = DataGridView1.Item(1, i).Value
        Me.TextBox3.Text = DataGridView1.Item(2, i).Value
        Me.TextBox4.Text = DataGridView1.Item(3, i).Value
        Me.TextBox5.Text = DataGridView1.Item(4, i).Value
        btnAdd.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True

    End Sub

    'Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
    '    TextBox1.Clear()
    '    TextBox2.Clear()
    '    TextBox3.Clear()
    '    TextBox4.Clear()
    '    TextBox5.Clear()

    'End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If (IsFormValid()) Then
            qry = "update TBLPRODUCTINFO set ProductName='" & TextBox2.Text & "', PrpductDesc='" & TextBox3.Text & "', ProductPrice= '" & TextBox4.Text & "', ProStock='" & TextBox5.Text & "'where ProID='" & Convert.ToInt32(TextBox1.Text) & "' "
            Dim isUpdateTrue As Boolean = Convert.ToBoolean(InsertData(qry))
            If (isUpdateTrue) Then
                BindGD()
                MsgBox("STOCK UPDATED SUCCESFULLY", MsgBoxStyle.Information)
                CLR()
            Else
                MsgBox("ERROR RECORD NOT UPDATED", MsgBoxStyle.Critical)

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CLR()

        TextBox2.Focus()
        btnAdd.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim result As Integer = MsgBox("DO YOU REALLY WANT TO DELETE RECORD", MsgBoxStyle.YesNo)
        If result = DialogResult.No Then
        ElseIf result = DialogResult.Yes Then
            If (IsFormValid2()) Then
                qry = "Delete from TBLPRODUCTINFO where ProID='" & Convert.ToInt32(TextBox1.Text) & "' "
                Dim wanttodelete As Boolean = Convert.ToBoolean(InsertData(qry))
                If (wanttodelete) Then
                    BindGD()
                    MsgBox("STOCK DELETED SUCCESFULLY", MsgBoxStyle.Information)
                    CLR()
                Else
                    MsgBox("ERROR RECORD NOT DELETED", MsgBoxStyle.Critical)

                End If
            End If
        End If
    End Sub

    Private Function IsFormValid2() As Boolean
        If (TextBox1.Text.Trim() = String.Empty) Then
            MsgBox("PRODUCT ID IS REQUIRED", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        qry = "SELECT * FROM TBLPRODUCTINFO WHERE ProID='" & Convert.ToInt32(TextBox6.Text) & "'"
        ds = SearchData(qry)
        If (ds.Tables(0).Rows.Count > 0) Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            MsgBox("RECORD NOT FOUND", MsgBoxStyle.Critical)

        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        TextBox7.Text = Now.ToShortTimeString
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox7.Text = TimeString
        TextBox8.Text = DateString
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox8.Text = Now.ToShortDateString
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        CLR()
        btnDelete.Enabled = False
        btnUpdate.Enabled = False

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Homepage.Show()
        Me.Hide()

    End Sub
End Class