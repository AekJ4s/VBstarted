Imports System.Data.SqlClient

Public Class Form1

    ' ประกาศตัวแปรสำหรับการนับการกดปุ่ม
    Dim count As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' เรียกใช้ฟังก์ชันเพื่อแสดงฟอร์มใหม่
        FormEmployee()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' รีเซ็ตค่าตัวแปร count
        count = 0

        ' รีเซ็ตข้อความใน Label ให้กลับเป็นค่าเริ่มต้น
        Label1.Text = "Button Clicked: 0 times"
    End Sub

    Public Sub FormEmployee()
        ' ประกาศและสร้างออบเจกต์ฟอร์มใหม่
        Dim myForm As New EmployeeForm()

        ' แสดงฟอร์ม
        myForm.ShowDialog()
    End Sub

End Class

Public Class EmployeeForm
    Inherits Form

    Private nameTextBox As TextBox
    Private surnameTextBox As TextBox
    Private ageTextBox As TextBox
    Private submitButton As Button

    Public Sub New()
        ' ตั้งค่าคุณสมบัติต่างๆ ของฟอร์ม
        Me.Text = "Employee Form"
        Me.Width = 300
        Me.Height = 250

        ' สร้างและตั้งค่าช่องกรอกข้อมูล Name
        Dim nameLabel As New Label()
        nameLabel.Text = "Name:"
        nameLabel.Location = New Point(10, 20)
        nameLabel.AutoSize = True
        Me.Controls.Add(nameLabel)

        nameTextBox = New TextBox()
        nameTextBox.Location = New Point(100, 20)
        Me.Controls.Add(nameTextBox)

        ' สร้างและตั้งค่าช่องกรอกข้อมูล Surname
        Dim surnameLabel As New Label()
        surnameLabel.Text = "Surname:"
        surnameLabel.Location = New Point(10, 60)
        surnameLabel.AutoSize = True
        Me.Controls.Add(surnameLabel)

        surnameTextBox = New TextBox()
        surnameTextBox.Location = New Point(100, 60)
        Me.Controls.Add(surnameTextBox)

        ' สร้างและตั้งค่าช่องกรอกข้อมูล Age
        Dim ageLabel As New Label()
        ageLabel.Text = "Age:"
        ageLabel.Location = New Point(10, 100)
        ageLabel.AutoSize = True
        Me.Controls.Add(ageLabel)

        ageTextBox = New TextBox()
        ageTextBox.Location = New Point(100, 100)
        Me.Controls.Add(ageTextBox)

        ' สร้างและตั้งค่าปุ่ม Submit
        submitButton = New Button()
        submitButton.Text = "Submit"
        submitButton.Location = New Point(100, 140)
        AddHandler submitButton.Click, AddressOf SubmitButton_Click
        Me.Controls.Add(submitButton)
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs)
        ' ดึงข้อมูลจากช่องกรอกข้อมูล
        Dim name As String = nameTextBox.Text
        Dim surname As String = surnameTextBox.Text
        Dim age As String = ageTextBox.Text

        ' เชื่อมต่อกับฐานข้อมูล
        Dim connectionString As String = "Server=DESKTOP-3C87OGA;Database=VBstarted;User Id=Jasdakorn;Password=1150;"
        Dim query As String = "INSERT INTO Employee (Name, Surname, Age) VALUES (@Name, @Surname, @Age)"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Name", name)
            command.Parameters.AddWithValue("@Surname", surname)
            command.Parameters.AddWithValue("@Age", age)

            Try
                connection.Open()
                command.ExecuteNonQuery()
                MessageBox.Show("Data saved successfully!")
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using

        ' ปิดฟอร์มเมื่อปุ่ม Submit ถูกคลิก
        Me.Close()
    End Sub

End Class


