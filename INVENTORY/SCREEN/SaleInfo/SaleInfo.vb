Public Class SaleInfo
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub SaleInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        qry = "select * from prosale"
        ds = SearchData(qry)
        If (ds.Tables(0).Rows.Count > 0) Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            MsgBox("RECORD NOT FOUND", MsgBoxStyle.Critical)
        End If
    End Sub
End Class