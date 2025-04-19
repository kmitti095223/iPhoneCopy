Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class IniFile

    Private Shared Function GetFilePath()
        ' 実行ファイル名を基にINIファイル名を生成
        Dim exeFilePath As String = Application.ExecutablePath
        Return Path.ChangeExtension(exeFilePath, ".ini")
    End Function

    ' INIファイルから値を取得する
    Public Shared Function GetString(section As String, key As String, defaultValue As String) As String
        Dim result As New StringBuilder(255)
        GetPrivateProfileString(section, key, defaultValue, result, result.Capacity, GetFilePath)
        Return result.ToString()
    End Function

    ' INIファイルに値を書き込む
    Public Shared Sub SetString(section As String, key As String, value As String)
        WritePrivateProfileString(section, key, value, GetFilePath)
    End Sub

    ' Windows API: GetPrivateProfileString
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetPrivateProfileString(
lpAppName As String,
lpKeyName As String,
lpDefault As String,
lpReturnedString As StringBuilder,
nSize As Integer,
lpFileName As String) As Integer
    End Function

    ' Windows API: WritePrivateProfileString
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function WritePrivateProfileString(
lpAppName As String,
lpKeyName As String,
lpString As String,
lpFileName As String) As Boolean
    End Function
End Class
