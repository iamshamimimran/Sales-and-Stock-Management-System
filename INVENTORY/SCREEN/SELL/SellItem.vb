Public Class SellItem
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        qry = "SELECT * FROM TBLPRODUCTINFO WHERE ProductName='" & TextBox1.Text & "'and PrpductDesc='" & TextBox2.Text & "'"
        ds = SearchData(qry)
        If (ds.Tables(0).Rows.Count > 0) Then
            DataGridView1.DataSource = ds.Tables(0)

            i = DataGridView1.CurrentRow.Index

            Me.TextBox3.Text = DataGridView1.Item(0, i).Value
            Me.TextBox4.Text = DataGridView1.Item(1, i).Value
            Me.TextBox5.Text = DataGridView1.Item(2, i).Value
            Me.TextBox6.Text = DataGridView1.Item(3, i).Value
            Me.TextBox7.Text = DataGridView1.Item(4, i).Value
        Else
            MsgBox("RECORD NOT FOUND", MsgBoxStyle.Critical)

        End If
    End Sub


    Private Sub SellItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGD()
    End Sub
    Public Sub BindGD()
        qry = "select * from tblproductinfo"
        ds = SearchData(qry)
        If (ds.Tables(0).Rows.Count > 0) Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            MsgBox("RECORD NOT FOUND", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TextBox10_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox10.KeyUp
        Dim tot, rcash, num As Double
        rcash = Val(TextBox10.Text)
        tot = Val(TextBox9.Text)
        If rcash = tot Then

            TextBox11.Text = 0

        ElseIf rcash > tot Then
            num = rcash - tot
            TextBox11.Text = num.ToString()
        ElseIf rcash < tot Then
            num = rcash - tot
            TextBox11.Text = num.ToString()


        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        i = DataGridView1.CurrentRow.Index

        Me.TextBox3.Text = DataGridView1.Item(0, i).Value
        Me.TextBox4.Text = DataGridView1.Item(1, i).Value
        Me.TextBox5.Text = DataGridView1.Item(2, i).Value
        Me.TextBox6.Text = DataGridView1.Item(3, i).Value
        Me.TextBox7.Text = DataGridView1.Item(4, i).Value
    End Sub

    Private Sub TextBox8_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyUp
        'Dim mul As Integer
        Dim x, y, z As String
        x = Val(TextBox8.Text)
        y = Val(TextBox6.Text)
        'mul = Val(TextBox6.Text * TextBox6.Text)
        'TextBox9.Text = mul
        z = Val(x * y)
        TextBox9.Text = z

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (IsFormValid()) Then
            qry = "Insert into ProSale values('" & Convert.ToInt32(TextBox3.Text) & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox9.Text & "','" & TextBox6.Text & "','" & TextBox8.Text & "','" & My.Forms.Homepage.loggedIn.Text & "','" & ComboBox1.Text & "','" & DateAndTime.Now & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
            If (logincorrect) Then
                BindGD()
                MsgBox("PRODUCT SALE SUCCESFULLY", MsgBoxStyle.Information)
                Updatestock()

            Else
                MsgBox("ERROR", MsgBoxStyle.Critical)

            End If

        End If
    End Sub
    Public Sub Updatestock()

        Dim a As String
        a = Val(TextBox7.Text) - Val(TextBox8.Text)
        qry = "update TBLPRODUCTINFO set  ProStock='" & a & "'where ProID='" & Convert.ToInt32(TextBox3.Text) & "' "
        Dim isUpdateTrue As Boolean = Convert.ToBoolean(InsertData(qry))
        If (isUpdateTrue) Then
            BindGD()
            MsgBox("STOCK UPDATED SUCCESFULLY", MsgBoxStyle.Information)

        Else
            MsgBox("ERROR RECORD NOT UPDATED", MsgBoxStyle.Critical)

        End If

    End Sub
    Private Function IsFormValid() As Boolean
        If (TextBox8.Text.Trim() = String.Empty) Then
            MsgBox("UNIT IS REQUIRED", MsgBoxStyle.Critical)
            'TextBox4.Clear()
            'TextBox2.Clear()
            'TextBox3.Clear()
            'TextBox5.Clear()

            Return False
        End If
        'If (TextBox2.Text.Trim() = String.Empty) Then
        '    MsgBox("PRODUCT NAME IS REQUIRED", MsgBoxStyle.Critical)
        '    TextBox4.Clear()
        '    TextBox2.Clear()
        '    TextBox3.Clear()
        '    TextBox5.Clear()


        '    Return False
        'End If
        'If (TextBox3.Text.Trim() = String.Empty) Then
        '    MsgBox("DESC IS REQUIRED", MsgBoxStyle.Critical)
        '    TextBox4.Clear()
        '    TextBox2.Clear()
        '    TextBox3.Clear()
        '    TextBox5.Clear()


        '    Return False
        'End If
        'If (TextBox5.Text.Trim() = String.Empty) Then
        '    MsgBox("STOCK IS REQUIRED", MsgBoxStyle.Critical)
        '    TextBox4.Clear()
        '    TextBox2.Clear()
        '    TextBox3.Clear()

        '    Return False
        'End If

        Return True
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Homepage.Show()
        Me.Hide()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim disparcent As Double
        If ComboBox1.Text > 0 Then
            disparcent = Convert.ToDouble(Val(TextBox9.Text) * Val(ComboBox1.Text) / 100)
            TextBox9.Text = Val(TextBox9.Text) - disparcent.ToString()
            TextBox12.Text = disparcent.ToString()
        Else
            TextBox9.Text = Val(TextBox6.Text) * Val(TextBox8.Text).ToString()
            TextBox12.Clear()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        e.Graphics.DrawString("SALE AND INVENTORY STORE", New Font("Arial", 21, FontStyle.Bold), Brushes.Blue, New Point(200, 20))

        e.Graphics.DrawString("Techno City, Killing Road, Baridua 9th Mile", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(260, 50))

        e.Graphics.DrawString("Date:" + DateAndTime.Now, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(20, 70))

        e.Graphics.DrawString("...............................................................................................................................................................................................", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(20, 90))

        e.Graphics.DrawString("Item Description:", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(20, 110))

        e.Graphics.DrawString("Quantity:", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(300, 110))

        e.Graphics.DrawString("Price:", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(500, 110))

        e.Graphics.DrawString("Discount:", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(700, 110))

        e.Graphics.DrawString("..............................................................................................................................................................................................", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(20, 130))

        e.Graphics.DrawString(TextBox5.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(20, 160))

        e.Graphics.DrawString(TextBox8.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(300, 160))

        e.Graphics.DrawString("Rs: " + TextBox6.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(500, 160))

        e.Graphics.DrawString(ComboBox1.Text + " % ", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(700, 160))

        e.Graphics.DrawString("..............................................................................................................................................................................................", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(20, 180))

        e.Graphics.DrawString("Discount Amount: ", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(20, 300))

        e.Graphics.DrawString("Rs: " + TextBox12.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(700, 300))

        e.Graphics.DrawString("Total Amount: ", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(20, 320))

        e.Graphics.DrawString("Rs: " + TextBox9.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(700, 320))



        e.Graphics.DrawString("..............................................................................................................................................................................................", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, New Point(20, 500))
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class