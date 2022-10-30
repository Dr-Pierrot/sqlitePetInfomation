Imports System.Data.SQLite
Public Class Form1
    Dim lv As New ListViewItem
    Dim selected As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Items.Clear()
        With ListView1
            .FullRowSelect = True
            .View = View.Details
            .GridLines = True
            .Columns.Add("ID", 40)
            .Columns.Add("Pet Name", 100)
            .Columns.Add("Species", 100)
            .Columns.Add("Breed", 100)
            .Columns.Add("Gender", 100)
            .Columns.Add("Color", 100)
        End With
        Call poplis()
        Call clearall()
        Call distxtbox()

    End Sub
    Private Sub poplis()
        ListView1.Items.Clear()

        opencon()
        sql = "select * from tblpet"
        cmd = New SQLiteCommand(sql, cn)
        dr = cmd.ExecuteReader

        While dr.Read = True
            lv = New ListViewItem(dr("id").ToString)
            lv.SubItems.Add(dr("name"))
            lv.SubItems.Add(dr("species"))
            lv.SubItems.Add(dr("breed"))
            lv.SubItems.Add(dr("gender"))
            lv.SubItems.Add(dr("color"))
            ListView1.Items.Add(lv)
        End While
        cn.Close()
    End Sub
    'this button will save the record
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        opencon()
        sql = "insert into tblpet(id,name,species,breed,gender,color) values('" & txtId.Text & "','" & txtName.Text & "','" & txtSpecies.Text & "','" & txtBreed.Text & "','" & cmbGender.Text & "','" & txtColor.Text & "')"
        cmd = New SQLiteCommand(sql, cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        Call poplis()
        Call savemode()
        Call clearall()
        Call distxtbox()

    End Sub

    Private Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
        opencon()
        sql = "update tblpet set name = '" & txtName.Text & "', species = '" & txtSpecies.Text & "',breed = '" & txtBreed.Text & "',gender = '" & cmbGender.Text & "', color = '" & txtColor.Text & "' where id = '" & selected & "'"
        cmd = New SQLiteCommand(sql, cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        Call poplis()
        Call savemode()
        Call clearall()
        Call distxtbox()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call cancelmode()
        Call distxtbox()
        Call clearall()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Call opencon()
        sql = "delete from tblpet where id = '" & selected & "'"
        cmd = New SQLiteCommand(sql, cn)
        cmd.ExecuteNonQuery()
        cn.Clone()
        Call poplis()
        Call clearall()
        Call distxtbox()
        Call deletemode()



    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Call editmode()
        Call enatxtbox()
        txtId.Enabled = False

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call addmode()
        Call clearall()
        Call enatxtbox()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim i As Integer
        For i = 0 To ListView1.SelectedItems.Count - 1
            selected = ListView1.SelectedItems.Item(i).Text
        Next
        opencon()
        sql = "select * from tblpet where id = '" & selected & "'"
        cmd = New SQLiteCommand(sql, cn)
        dr = cmd.ExecuteReader

        While dr.Read() = True
            txtId.Text = dr("id").ToString
            txtName.Text = dr("name")
            txtSpecies.Text = dr("species")
            txtBreed.Text = dr("breed")
            cmbGender.Text = dr("gender")
            txtColor.Text = dr("color")
        End While
        cn.Close()
        Call selectmode()

    End Sub
End Class
