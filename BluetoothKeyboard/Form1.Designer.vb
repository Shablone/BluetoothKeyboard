<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LstCom = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.TimerMouse = New System.Windows.Forms.Timer(Me.components)
        Me.LabelStatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkAscii = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'LstCom
        '
        Me.LstCom.FormattingEnabled = True
        Me.LstCom.Location = New System.Drawing.Point(10, 39)
        Me.LstCom.Name = "LstCom"
        Me.LstCom.Size = New System.Drawing.Size(170, 95)
        Me.LstCom.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Available ComPorts:"
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(46, 216)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(100, 20)
        Me.txtInput.TabIndex = 2
        '
        'txtInfo
        '
        Me.txtInfo.Enabled = False
        Me.txtInfo.Location = New System.Drawing.Point(414, 259)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.Size = New System.Drawing.Size(237, 82)
        Me.txtInfo.TabIndex = 3
        '
        'TimerMouse
        '
        Me.TimerMouse.Interval = 50
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.Location = New System.Drawing.Point(43, 300)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(116, 13)
        Me.LabelStatus.TabIndex = 5
        Me.LabelStatus.Text = "Live-Mode deactivated"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(411, 243)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Recognized keys in live mode"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(30, 338)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(378, 65)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "c) press right alt to read out the control over which the mouse is hovering." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   " &
    "  Its text gets send to the receiver"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "(establish connection on selection)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "a) Send content of textbox"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(152, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(215, 26)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Enter: send and clean textboxcontent" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Shift+Enter: send and persist textboxconten" &
    "t"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(216, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "3. Then choose how you want to send data."
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(30, 250)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(378, 63)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "b) toggle live-mode via right alt key" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    In live mode every key press/release a" &
    "nd mouseevent is transfered." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    This can be problematic if host and receiver u" &
    "se different keyboard-layouts"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(197, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(360, 95)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = resources.GetString("Label9.Text")
        '
        'chkAscii
        '
        Me.chkAscii.AutoSize = True
        Me.chkAscii.Location = New System.Drawing.Point(382, 216)
        Me.chkAscii.Name = "chkAscii"
        Me.chkAscii.Size = New System.Drawing.Size(162, 17)
        Me.chkAscii.TabIndex = 15
        Me.chkAscii.Text = "send via Numpad Ascii Code"
        Me.chkAscii.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 371)
        Me.Controls.Add(Me.chkAscii)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LabelStatus)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LstCom)
        Me.Name = "Form1"
        Me.Text = "BluetoothKeyboard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LstCom As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtInput As TextBox
    Friend WithEvents txtInfo As TextBox
    Friend WithEvents TimerMouse As Timer
    Friend WithEvents LabelStatus As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents chkAscii As CheckBox
End Class
