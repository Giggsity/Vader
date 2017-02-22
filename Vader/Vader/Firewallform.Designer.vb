<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Firewallform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Firewallform))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Register Number: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Store Number: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(194, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(194, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Label1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(37, 129)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 55)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Drop"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(149, 129)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 55)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Raise"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(16, 18)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(37, 17)
        Me.RadioButton1.TabIndex = 18
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "80"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(112, 18)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(37, 17)
        Me.RadioButton2.TabIndex = 19
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "90"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 41)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Firewall Model"
        '
        'Firewallform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(284, 196)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Firewallform"
        Me.Text = "Firewall"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
End Class
