Public Class Form1

    ' ประกาศตัวแปรสำหรับการนับการกดปุ่ม
    Dim count As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' แสดงข้อความแบบ Popup หรือ Alert
        MessageBox.Show("Button clicked!")

        ' เพิ่มค่าตัวแปร count เมื่อปุ่มถูกกด
        count += 1

        ' แสดงจำนวนครั้งที่ปุ่มถูกกดใน Label
        Label1.Text = "Button Clicked: " & count & " times"

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
        Dim myForm As New Form()

        ' ตั้งค่าคุณสมบัติต่างๆ ของฟอร์ม
        myForm.Text = "Employee Form"    ' กำหนดชื่อฟอร์ม
        myForm.Width = 300               ' กำหนดความกว้าง
        myForm.Height = 200              ' กำหนดความสูง

        ' เพิ่มปุ่มลงในฟอร์ม
        Dim myButton As New Button()
        myButton.Text = "Click Me"
        myButton.Location = New Point(100, 50)

        ' กำหนดเหตุการณ์เมื่อปุ่มถูกกด
        AddHandler myButton.Click, AddressOf Button1_Click

        ' เพิ่มปุ่มลงในฟอร์ม
        myForm.Controls.Add(myButton)

        ' แสดงฟอร์ม
        myForm.ShowDialog()
    End Sub

End Class
