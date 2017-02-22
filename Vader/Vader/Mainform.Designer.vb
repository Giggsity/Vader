<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mainform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mainform))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(149, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(149, 53)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Store Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Register Number"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(34, 91)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(214, 46)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Close Fail"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(34, 143)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 25)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "PC"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(150, 143)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(99, 25)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Printers"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(33, 174)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(99, 25)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Firewall"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(149, 174)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(99, 25)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "Replacement"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Button6.Location = New System.Drawing.Point(257, 239)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(26, 20)
        Me.Button6.TabIndex = 0
        Me.Button6.TabStop = False
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(34, 205)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(214, 27)
        Me.Button7.TabIndex = 9
        Me.Button7.Text = "Contact Numbers"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Mainform"
        Me.Text = "Vader"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
End Class
