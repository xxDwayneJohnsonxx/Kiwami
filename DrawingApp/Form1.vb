Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim w As Integer
    Dim Type As String


    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub

    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_Previous IsNot Nothing Then
            Dim l As New Line(PictureBox1.Image, m_Previous, e.Location)
            l.Pen = New Pen(c, w)
            m_shapes.Add(l)
            Dim d As Object

            If Type = "Line" Then
                d = New Line(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
                d.xspeed = xspeedTrackBar.Value
            End If
            If Type = "Rectangle" Then
                d = New Rect(PictureBox1.Image, m_Previous, e.Location)
                d.fill = CheckBox1.Checked
                d.color1 = Button20.BackColor
                d.color2 = Button21.BackColor
                d.Pen = New Pen(c, w)
                d.h = 10
                d.w = 5
            End If
            If Type = "Arc" Then
                d = New Arc(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If Type = "circle" Then
                d = New circle(PictureBox1.Image, m_Previous, e.Location)
                d.fill = CheckBox1.Checked
                d.color1 = Button20.BackColor
                d.color2 = Button21.BackColor
                d.Pen = New Pen(c, w)
            End If
            If Type = "Pie" Then
                d = New Pie(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If Type = "Pentagon" Then
                d = New Pentagon(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If Type = "n-gon" Then
                d = New n_gon(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
                d.sides = TrackBar2.Value
                d.radius = TrackBar3.Value
            End If
            If Type = "Picture" Then
                d = New PBox(PictureBox1.Image, m_Previous, e.Location)
                d.w = TrackBar4.Value
                d.h = TrackBar4.Value
                d.picture = PictureBox2.Image
            End If

            m_shapes.Add(d)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        End If
    End Sub


    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If

    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw()
        Next
        If CheckBox2.Checked Then
            Refresh()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        Button1.BackColor = c

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        c = sender.backcolor
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        c = sender.backcolor
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        w = TrackBar1.Value
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        c = sender.backcolor
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        c = sender.backcolor
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        c = sender.backcolor
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        c = sender.backcolor
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        c = sender.backcolor
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        c = sender.backcolor
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
        End Using
        PictureBox1.Image = bmp

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Type = "Line"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Type = "Rectangle"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Type = "circle"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Type = "Pie"
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Type = "Arc"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        SaveFileDialog1.Showdialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        PictureBox1.Image.Save(SaveFileDialog1.FileName)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Type = "Pentagon"
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Type = "n-gon"
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Type = "Picture"
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.Black)
        End Using
        PictureBox1.Image = bmp
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox2.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        sender.backcolor = c
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        sender.backcolor = c
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.Red)
        End Using
        PictureBox1.Image = bmp
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        OpenFileDialog2.ShowDialog()
        PictureBox1.Load(OpenFileDialog2.FileName)

    End Sub
End Class