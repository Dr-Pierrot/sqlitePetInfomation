Imports System.Data.SQLite
Module Module1
    Public cn As New SQLiteConnection
    Public cmd As New SQLiteCommand
    Public dr As SQLiteDataReader
    Public sql As String

    Public Sub opencon()
        With cn
            If .State <> 0 Then .Close()

            .ConnectionString = "Data Source=" + Application.StartupPath + "\pet.db"
            .Open()

        End With
    End Sub

    Public Sub clearall()
        With Form1
            .txtId.Clear()
            .txtName.Clear()
            .txtSpecies.Clear()
            .txtBreed.Clear()
            .cmbGender.SelectedIndex = 0
            .txtColor.Clear()

        End With
    End Sub

    Public Sub enatxtbox()
        With Form1
            .txtId.Enabled = True
            .txtName.Enabled = True
            .txtSpecies.Enabled = True
            .txtBreed.Enabled = True
            .cmbGender.Enabled = True
            .txtColor.Enabled = True
        End With
    End Sub
    Public Sub distxtbox()
        With Form1
            .txtId.Enabled = False
            .txtName.Enabled = False
            .txtSpecies.Enabled = False
            .txtBreed.Enabled = False
            .cmbGender.Enabled = False
            .txtColor.Enabled = False
        End With
    End Sub

    Public Sub selectmode()
        With Form1
            .btnAdd.Enabled = False
            .btnEdit.Enabled = True
            .btnDelete.Enabled = True
            .btnClose.Enabled = False
            .btnSave.Enabled = False
            .btnSave2.Enabled = False
            .btnCancel.Enabled = True
            .btnSave.Visible = False
            .btnSave2.Visible = False
            .btnCancel.Visible = True
            .ListView1.Enabled = False
        End With
    End Sub
    Public Sub addmode()
        With Form1
            .btnAdd.Enabled = False
            .btnEdit.Enabled = False
            .btnDelete.Enabled = False
            .btnClose.Enabled = False
            .btnSave.Enabled = True
            .btnSave2.Enabled = False
            .btnCancel.Enabled = True
            .btnSave.Visible = True
            .btnSave2.Visible = False
            .btnCancel.Visible = True
            .ListView1.Enabled = False
        End With
    End Sub
    Public Sub savemode()
        With Form1
            .btnAdd.Enabled = True
            .btnEdit.Enabled = False
            .btnDelete.Enabled = False
            .btnClose.Enabled = True
            .btnSave.Enabled = False
            .btnSave2.Enabled = False
            .btnCancel.Enabled = False
            .btnSave.Visible = False
            .btnSave2.Visible = False
            .btnCancel.Visible = False
            .ListView1.Enabled = True
        End With
    End Sub
    Public Sub editmode()
        With Form1
            .btnAdd.Enabled = False
            .btnEdit.Enabled = True
            .btnDelete.Enabled = False
            .btnClose.Enabled = False
            .btnSave.Enabled = False
            .btnSave2.Enabled = True
            .btnCancel.Enabled = True
            .btnSave.Visible = False
            .btnSave2.Visible = True
            .btnCancel.Visible = True
            .ListView1.Enabled = False
        End With
    End Sub
    Public Sub deletemode()
        With Form1
            .btnAdd.Enabled = True
            .btnEdit.Enabled = False
            .btnDelete.Enabled = False
            .btnClose.Enabled = True
            .btnSave.Enabled = False
            .btnSave2.Enabled = False
            .btnCancel.Enabled = False
            .btnSave.Visible = False
            .btnSave2.Visible = False
            .btnCancel.Visible = False
            .ListView1.Enabled = True
        End With
    End Sub
    Public Sub cancelmode()
        With Form1
            .btnAdd.Enabled = True
            .btnEdit.Enabled = False
            .btnDelete.Enabled = False
            .btnClose.Enabled = True
            .btnSave.Enabled = False
            .btnSave2.Enabled = False
            .btnCancel.Enabled = False
            .btnSave.Visible = False
            .btnSave2.Visible = False
            .btnCancel.Visible = False
            .ListView1.Enabled = True
        End With
    End Sub
End Module
