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
        Me.LstCom = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.TimerMouse = New System.Windows.Forms.Timer(Me.components)
        Me.LabelStatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.test2 = New System.Windows.Forms.Button()
        Me.test = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LstCom
        '
        Me.LstCom.FormattingEnabled = True
        Me.LstCom.Location = New System.Drawing.Point(12, 44)
        Me.LstCom.Name = "LstCom"
        Me.LstCom.Size = New System.Drawing.Size(120, 95)
        Me.LstCom.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ComPorts:"
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(173, 222)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(100, 20)
        Me.txtInput.TabIndex = 2
        '
        'txtInfo
        '
        Me.txtInfo.Enabled = False
        Me.txtInfo.Location = New System.Drawing.Point(153, 44)
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
        Me.LabelStatus.Location = New System.Drawing.Point(34, 228)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(108, 13)
        Me.LabelStatus.TabIndex = 5
        Me.LabelStatus.Text = "Mausinput deaktiviert"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(169, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Info"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(378, 65)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Strg-Rechts drücken um Eingabe umzuschalten. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bei deaktivierter Eingabe: String " &
    "mit Enter senden" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Shift+Enter=Senden ohne Löschen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Alt Rechts = marktierten Text" &
    " aus aktivem Steuerelement senden"
        '
        'test2
        '
        Me.test2.Location = New System.Drawing.Point(324, 157)
        Me.test2.Name = "test2"
        Me.test2.Size = New System.Drawing.Size(75, 23)
        Me.test2.TabIndex = 8
        Me.test2.Text = "test2"
        Me.test2.UseVisualStyleBackColor = True
        '
        'test
        '
        Me.test.Location = New System.Drawing.Point(324, 128)
        Me.test.Name = "test"
        Me.test.Size = New System.Drawing.Size(75, 23)
        Me.test.TabIndex = 7
        Me.test.Text = "test"
        Me.test.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 250)
        Me.Controls.Add(Me.test2)
        Me.Controls.Add(Me.test)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LabelStatus)
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
    Friend WithEvents test2 As Button
    Friend WithEvents test As Button
End Class
