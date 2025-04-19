<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
	Inherits System.Windows.Forms.Form

	'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

	'Windows フォーム デザイナーで必要です。
	Private components As System.ComponentModel.IContainer

	'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
	'Windows フォーム デザイナーを使用して変更できます。  
	'コード エディターを使って変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtOutputRoot = New System.Windows.Forms.TextBox()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.btnStop = New System.Windows.Forms.Button()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.lblSave = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.lblSkip = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.lblCopy = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.lblRetry = New System.Windows.Forms.Label()
		Me.lblError = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.StatusStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(24, 21)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(190, 12)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "iPhoneの写真をパソコンにコピーします。"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(24, 66)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(47, 12)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "保存先："
		'
		'txtOutputRoot
		'
		Me.txtOutputRoot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtOutputRoot.Location = New System.Drawing.Point(77, 63)
		Me.txtOutputRoot.Name = "txtOutputRoot"
		Me.txtOutputRoot.Size = New System.Drawing.Size(355, 19)
		Me.txtOutputRoot.TabIndex = 4
		'
		'btnSave
		'
		Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnSave.Location = New System.Drawing.Point(125, 186)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(98, 26)
		Me.btnSave.TabIndex = 5
		Me.btnSave.Text = "実行"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'btnExit
		'
		Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnExit.Location = New System.Drawing.Point(333, 186)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(98, 26)
		Me.btnExit.TabIndex = 7
		Me.btnExit.Text = "終了"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(24, 38)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(235, 12)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "保存先を入力して「実行」ボタンを押してください。"
		'
		'btnStop
		'
		Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnStop.Enabled = False
		Me.btnStop.Location = New System.Drawing.Point(229, 186)
		Me.btnStop.Name = "btnStop"
		Me.btnStop.Size = New System.Drawing.Size(98, 26)
		Me.btnStop.TabIndex = 6
		Me.btnStop.Text = "中断"
		Me.btnStop.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(50, 110)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(100, 12)
		Me.Label6.TabIndex = 8
		Me.Label6.Text = "処理完了フォルダ数"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblSave
		'
		Me.lblSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblSave.Location = New System.Drawing.Point(167, 107)
		Me.lblSave.Name = "lblSave"
		Me.lblSave.Size = New System.Drawing.Size(79, 19)
		Me.lblSave.TabIndex = 8
		Me.lblSave.Text = "1,234,5678 件"
		Me.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(50, 155)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(86, 12)
		Me.Label8.TabIndex = 8
		Me.Label8.Text = "スキップファイル数"
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblSkip
		'
		Me.lblSkip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblSkip.Location = New System.Drawing.Point(167, 152)
		Me.lblSkip.Name = "lblSkip"
		Me.lblSkip.Size = New System.Drawing.Size(79, 19)
		Me.lblSkip.TabIndex = 8
		Me.lblSkip.Text = "1,234,5678 件"
		Me.lblSkip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Location = New System.Drawing.Point(50, 132)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(102, 12)
		Me.Label10.TabIndex = 8
		Me.Label10.Text = "コピー成功ファイル数"
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblCopy
		'
		Me.lblCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblCopy.Location = New System.Drawing.Point(167, 129)
		Me.lblCopy.Name = "lblCopy"
		Me.lblCopy.Size = New System.Drawing.Size(79, 19)
		Me.lblCopy.TabIndex = 8
		Me.lblCopy.Text = "1,234,5678 件"
		Me.lblCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(285, 110)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(61, 12)
		Me.Label5.TabIndex = 8
		Me.Label5.Text = "リトライ回数"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblRetry
		'
		Me.lblRetry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblRetry.Location = New System.Drawing.Point(352, 107)
		Me.lblRetry.Name = "lblRetry"
		Me.lblRetry.Size = New System.Drawing.Size(79, 19)
		Me.lblRetry.TabIndex = 8
		Me.lblRetry.Text = "回"
		Me.lblRetry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblError
		'
		Me.lblError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblError.Location = New System.Drawing.Point(353, 129)
		Me.lblError.Name = "lblError"
		Me.lblError.Size = New System.Drawing.Size(79, 19)
		Me.lblError.TabIndex = 8
		Me.lblError.Text = "回"
		Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'label7
		'
		Me.label7.AutoSize = True
		Me.label7.Location = New System.Drawing.Point(285, 132)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(44, 12)
		Me.label7.TabIndex = 8
		Me.label7.Text = "エラー数"
		Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 223)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(443, 22)
		Me.StatusStrip1.TabIndex = 9
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.AutoSize = False
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(55, 17)
		'
		'ToolStripStatusLabel2
		'
		Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
		Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
		'
		'MainForm
		'
		Me.AcceptButton = Me.btnSave
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnExit
		Me.ClientSize = New System.Drawing.Size(443, 245)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.lblCopy)
		Me.Controls.Add(Me.Label10)
		Me.Controls.Add(Me.lblSkip)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.lblError)
		Me.Controls.Add(Me.lblRetry)
		Me.Controls.Add(Me.lblSave)
		Me.Controls.Add(Me.label7)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnStop)
		Me.Controls.Add(Me.btnSave)
		Me.Controls.Add(Me.txtOutputRoot)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label1)
		Me.MaximizeBox = False
		Me.Name = "MainForm"
		Me.Text = "iPhone写真コピー"
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents txtOutputRoot As TextBox
	Friend WithEvents btnSave As Button
	Friend WithEvents btnExit As Button
	Friend WithEvents Label3 As Label
	Friend WithEvents btnStop As Button
	Friend WithEvents Label6 As Label
	Friend WithEvents lblSave As Label
	Friend WithEvents Label8 As Label
	Friend WithEvents lblSkip As Label
	Friend WithEvents Label10 As Label
	Friend WithEvents lblCopy As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents lblRetry As Label
	Friend WithEvents lblError As Label
	Friend WithEvents label7 As Label
	Friend WithEvents StatusStrip1 As StatusStrip
	Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
	Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
End Class
