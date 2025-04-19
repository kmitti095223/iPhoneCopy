Imports System.IO
Imports MediaDevices

Public Class MainForm

    ' 中断処理のためのフラグ
    Private isStopped As Boolean = False

    ' 処理件数のカウント用変数
    Private skipCount As Integer      ' スキップされたファイル数
    Private copyCount As Integer      ' コピーされたファイル数
    Private retryCount As Integer     ' リトライ回数
    Private errorCount As Integer     ' エラー件数
    Private completedFolderCount As Integer ' 処理済みフォルダ数

    ' フォーム読み込み時に設定ファイルから出力先フォルダを読み込む
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtOutputRoot.Text = IniFile.GetString("設定", "OutputFolder", "C:\Temp")
        SetLabel()
    End Sub

    ' フォームが閉じるときに出力フォルダパスを保存する
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        IniFile.SetString("設定", "OutputFolder", txtOutputRoot.Text)
    End Sub

    ' [保存] ボタンがクリックされたときの処理
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        isStopped = False

        ' 出力フォルダパスを保存
        IniFile.SetString("設定", "OutputFolder", txtOutputRoot.Text)

        ' UI制御
        txtOutputRoot.Enabled = False
        btnSave.Enabled = False
        btnStop.Enabled = True
        btnExit.Enabled = False
        Refresh()

        ' 出力パスの末尾の \ を削除
        If txtOutputRoot.Text.EndsWith("\") Then
            txtOutputRoot.Text = txtOutputRoot.Text.TrimEnd("\"c)
        End If

        ' メイン処理ループ
        While True
            completedFolderCount = 0
            Dim resultCode As Integer = Exec(txtOutputRoot.Text)
            Select Case resultCode
                Case 0
                    MsgBox("中断しました。", vbInformation)
                    Exit While
                Case 1
                    MsgBox("写真の保存が完了しました！！", vbInformation)
                    Exit While
                Case -1
                    ' エラー → リトライ
                    retryCount += 1
                    skipCount = 0
                    errorCount = 0
                    Continue While
                Case -2
                    ' iPhone が見つからなかった
                    Exit While
                Case Else
                    Debug.Assert(False)
            End Select
        End While

        ' UI を元に戻す
        txtOutputRoot.Enabled = True
        btnSave.Enabled = True
        btnStop.Enabled = False
        btnExit.Enabled = True
    End Sub

    ' [終了] ボタン
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    ' [中止] ボタン
    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        isStopped = True
        IniFile.SetString("設定", "OutputFolder", txtOutputRoot.Text)
    End Sub

    ' iPhoneから写真を取得・保存するメイン関数
    Function Exec(ByVal outputRoot As String) As Integer
        Dim devices As IEnumerable(Of MediaDevice) = MediaDevice.GetDevices()
        Dim connectedDevice As MediaDevice = Nothing
        Dim hasNoFiles As Boolean = True
        Dim hasError As Boolean = False
        Dim hasFolderError As Boolean = False
        Dim fileCountInFolder As Integer = 0

        ' iPhoneデバイスを検索
        For Each device In devices
            If device.FriendlyName.Contains("iPhone") Then
                connectedDevice = device
                Exit For
            End If
        Next

        ' iPhoneが見つからなかった場合
        If connectedDevice Is Nothing Then
            MsgBox("iPhoneが見つかりませんでした。" & vbCrLf & "iPhoneが正しく接続され、エクスプローラで写真を表示できることを確認してください。", vbExclamation)
            Return -2
        End If

        ' デバイスに接続
        Dim stopwatch As New Stopwatch()
        stopwatch.Start()
        connectedDevice.Connect()

        Dim photoDirs
        Try
            photoDirs = connectedDevice.GetDirectories("\Internal Storage")
        Catch ex As Exception
            connectedDevice.Disconnect()
            MsgBox("iPhoneが見つかりませんでした。" & vbCrLf & "iPhoneが正しく接続され、エクスプローラで写真を表示できることを確認してください。", vbExclamation)
            Return -2
        End Try

        Try
            For Each photoDir In photoDirs
                Dim files = connectedDevice.EnumerateFiles(photoDir, "*.*").Where(Function(f) True)

                hasFolderError = False
                fileCountInFolder = 0

                ' 既に処理済みのフォルダならスキップ
                If IniFile.GetString("完了", photoDir, "0") <> "0" Then
                    completedFolderCount += 1
                    SetLabel()
                    Continue For
                End If

                For Each filePath In files
                    hasNoFiles = False
                    fileCountInFolder += 1

                    StatusStrip1.Items(0).Text = ""
                    StatusStrip1.Items(1).Text = filePath

                    SetLabel()
                    If stopwatch.ElapsedMilliseconds > 1000 Then
                        stopwatch.Restart()
                        Application.DoEvents()
                        If isStopped Then
                            Return 0
                        End If
                    End If

                    If filePath = (photoDir & "\") Then
                        Continue For
                    End If

                    ' ファイル情報を取得
                    Dim sourceFileInfo = connectedDevice.GetFileInfo(filePath)
                    Dim dateTaken = If(sourceFileInfo.CreationTime, DateTime.Now)

                    ' 保存先のフォルダを構築
                    Dim yearFolder = dateTaken.ToString("yyyy") & "年"
                    Dim monthFolder = dateTaken.ToString("MM") & "月"
                    Dim folderPath = Path.Combine(outputRoot, yearFolder, monthFolder)
                    Directory.CreateDirectory(folderPath)

                    ' 保存先ファイルパスを構築
                    Dim destinationPath = Path.Combine(folderPath, Path.GetFileName(filePath))

                    ' 既に同名ファイルが存在するか確認
                    If File.Exists(destinationPath) Then
                        Dim destinationFileInfo = New FileInfo(destinationPath)
                        Dim destinationFileSize = destinationFileInfo.Length
                        Dim sourceFileSize = sourceFileInfo.Length

                        ' ファイルサイズが異なる、もしくは保存失敗した残骸なら削除
                        If (destinationFileSize = 0) OrElse (destinationFileSize <> sourceFileSize) Then
                            File.Delete(destinationPath)
                        Else
                            StatusStrip1.Items(0).Text = "スキップ"
                            StatusStrip1.Refresh()
                            skipCount += 1
                            Continue For
                        End If
                    End If

                    ' ダウンロード処理
                    Try
                        StatusStrip1.Items(0).Text = "保存中"
                        StatusStrip1.Refresh()
                        connectedDevice.DownloadFile(filePath, destinationPath)

                        ' 保存したファイルのタイムスタンプを設定
                        Dim destinationFileInfo As New FileInfo(destinationPath)
                        destinationFileInfo.CreationTime = dateTaken
                        destinationFileInfo.LastWriteTime = dateTaken

                        copyCount += 1
                        StatusStrip1.Items(0).Text = "保存完了"
                        StatusStrip1.Refresh()
                        SetLabel()
                    Catch
                        ' ダウンロード中にエラー発生
                        errorCount += 1
                        hasError = True
                        hasFolderError = True
                        Try
                            File.Delete(destinationPath)
                        Catch
                        End Try
                        Exit For
                    End Try
                Next

                ' フォルダ単位で正常完了したら完了記録
                completedFolderCount += 1
                If Not hasFolderError Then
                    Dim today As String = DateTime.Now.ToString("yyyyMM")
                    If Not photoDir.Contains(today) Then
                        IniFile.SetString("完了", photoDir, fileCountInFolder.ToString)
                    End If
                End If
            Next
        Catch ex As Exception
            ' 通信エラーなど
            errorCount += 1
            connectedDevice.Disconnect()
            Return -1
        End Try

        connectedDevice.Disconnect()

        If hasNoFiles Then
            MsgBox("iPhoneが見つかりませんでした。" & vbCrLf & "iPhoneが正しく接続され、エクスプローラで写真を表示できることを確認してください。", vbExclamation)
            Return -2
        End If

        ' 結果コードを返却
        If hasError Then
            Return -1
        Else
            Return 1
        End If
    End Function

    ' 各種ラベルに値をセットする
    Sub SetLabel()
        lblSave.Text = completedFolderCount.ToString("#,0") & " 件"
        lblSkip.Text = skipCount.ToString("#,0") & " 件"
        lblCopy.Text = copyCount.ToString("#,0") & " 件"
        lblRetry.Text = retryCount.ToString("#,0") & " 回"
        lblError.Text = errorCount.ToString("#,0") & " 回"
        Refresh()
    End Sub

End Class
