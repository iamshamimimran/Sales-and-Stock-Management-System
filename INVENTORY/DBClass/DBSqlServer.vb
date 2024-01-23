Imports System.Data
Imports System.Data.SqlClient

Module DBSqlServer
    Public con As New SqlConnection("Data Source=DESKTOP-11MD488;Initial Catalog=INVENTORY;Integrated Security=True")
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public dt As New DataTable
    Public qry As String
    Public i As Integer

    Public Function SearchData(ByVal qry As String) As DataSet
        da = New SqlDataAdapter(qry, con)
        ds = New DataSet
        da.Fill(ds)
        Return ds

    End Function
    Public Function InsertData(ByVal qry As String) As Integer
        cmd = New SqlCommand(qry, con)
        con.Open()
        i = cmd.ExecuteNonQuery()
        con.Close()
        Return i

    End Function
End Module
