﻿Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim w As Integer
    Public Property Pen As Pen
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point
    Public Sub New(i As Image, a As Point, b As Point)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b

    End Sub

    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub

    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_Previous IsNot Nothing Then
            Dim l As New Line(PictureBox1.Image, m_Previous, e.Location)
            l.Pen = New Pen(c, w)
            m_shapes.Add(l)
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
        For Each s As Line In m_shapes
            s.Draw()
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
End Class
