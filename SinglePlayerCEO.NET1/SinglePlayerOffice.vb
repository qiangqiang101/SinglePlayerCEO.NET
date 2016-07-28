Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms

Public Class SinglePlayerOffice
    Inherits Script

    Public Shared player As Player
    Public Shared playerPed As Ped
    Public Shared playerInterior As Integer
    Public Shared playerCash, PlayerOfficeCash As Integer
    Public Shared playerName As String
    Public Shared playerHash As String
    Public Shared saveFile As String = Application.StartupPath & "\scripts\SinglePlayerCEO\MySave.cfg"
    Public Shared saveFileSPA As String = Application.StartupPath & "\scripts\SinglePlayerApartment\MySave.cfg"
    Public Shared settingFile As String = Application.StartupPath & "\scripts\SinglePlayerCEO\setting.cfg"
    Public Shared settingFileSPA As String = Application.StartupPath & "\scripts\SinglePlayerApartment\setting.cfg"
    Public Shared langFile As String = Application.StartupPath & "scripts\SinglePlayerCEO\Languages\" & Game.Language.ToString & ".cfg"
    Public Shared langFileSPA As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Languages\" & Game.Language.ToString & ".cfg"
    Public Shared playerMap As String
    Public Shared SmallWhLastLocationName As String = Nothing
    Public Shared MediumWhLastLocationName As String = Nothing
    Public Shared LargeWhLastLocationName As String = Nothing
    Public Shared hideHud As Boolean = False

    'Translate
    Public Shared OForSale, WforSale, OfficeOptions, ExitOffice, ExitOffice2, ExitOfficeViaVeh, ExitOfficeVehPgs, SellOffice, SellWarehouse, InsFundOffice, InsFundWarehouse, EnterOFfice, _ExitOffice, Decor As String
    Public Shared ExeRich, ExeCool, ExeContrast, OSpiClassical, OSpiVintage, OSpiWarms, PowBConservative, PowBPolished, PowBIce As String
    Public Shared SpeakAssist, PegasusCon, PersonalVeh, ExeAssService, OfficeDecor As String

    Public Sub New()
        Try
            player = Game.Player
            playerPed = Game.Player.Character
            playerHash = player.Character.Model.GetHashCode().ToString
            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            ElseIf playerHash = "1885233650" Or "-1667301416" Then
                playerName = "Player3"
            Else
                playerName = "None"
            End If
            If playerName = "Player3" Then
                playerCash = 1000000000
            Else
                playerCash = player.Money
            End If

            'New Language
            OForSale = ReadCfgValue("OfficeForSale", langFile)
            WforSale = ReadCfgValue("WarehouseForSale", langFile)

            AddHandler Tick, AddressOf OnTick

            LoadSettingFromCFG()
            'SinglePlayerApartment.SinglePlayerApartment.InteriorIDList.Add(INMNative.Warehouse.GetInteriorID(New Vector3(0, 0, 0)))
            'SinglePlayerApartment.SinglePlayerApartment.InteriorIDList.Add(INMNative.Warehouse.GetInteriorID(New Vector3(0, 0, 0)))
            'SinglePlayerApartment.SinglePlayerApartment.InteriorIDList.Add(INMNative.Warehouse.GetInteriorID(New Vector3(0, 0, 0)))
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadSettingFromCFG()
        Try
            My.Settings.MazeBankTower = ReadCfgValue("MazeBankTower", settingFile)
            My.Settings.MazeBankWest = ReadCfgValue("MazeBankWest", settingFile)
            My.Settings.LombankWest = ReadCfgValue("LombankWest", settingFile)
            My.Settings.ArcadiusBCenter = ReadCfgValue("ArcadiusBCenter", settingFile)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadPosition()
        Try
            Dim lastInterior As String = Nothing
            If playerName = "Michael" Then
                lastInterior = ReadCfgValue("MlastInterior", saveFileSPA)
            ElseIf playerName = "Franklin" Then
                lastInterior = ReadCfgValue("FlastInterior", saveFileSPA)
            ElseIf playerName = "Trevor" Then
                lastInterior = ReadCfgValue("TlastInterior", saveFileSPA)
            ElseIf playerName = "Player3" Then
                lastInterior = ReadCfgValue("3lastInterior", saveFileSPA)
            End If
            Select Case lastInterior
                Case "MazeBankTower"
                    SinglePlayerApartment.SinglePlayerApartment.SetInteriorActive2(MazeBankTower.Office.Interior.X, MazeBankTower.Office.Interior.Y, MazeBankTower.Office.Interior.Z)
                    SinglePlayerApartment.SinglePlayerApartment.ToggleIPL(ReadCfgValue("MBTipl", saveFile), MazeBankTower.Office.Interior)
                    Game.Player.Character.Position = New Vector3(MazeBankTower.Office.Entrance.X, MazeBankTower.Office.Entrance.Y, MazeBankTower.Office.Entrance.Z)
                    MazeBankTower.Office.IsAtOffice = True
            End Select
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            player = Game.Player
            playerPed = Game.Player.Character
            playerInterior = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_FROM_ENTITY, Game.Player.Character)
            playerHash = player.Character.Model.GetHashCode().ToString
            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            ElseIf playerHash = "1885233650" Or "-1667301416" Then
                playerName = "Player3"
            Else
                playerName = "None"
            End If
            If playerName = "Player3" Then
                playerCash = 1000000000
            Else
                playerCash = player.Money
            End If

            If hideHud Then
                Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
            End If

            If Not playerInterior = 0 AndAlso SinglePlayerApartment.SinglePlayerApartment.InteriorIDList.Contains(playerInterior) AndAlso Not Game.MissionFlag AndAlso Not player.WantedLevel > 0 Then
                SinglePlayerApartment.Resources.Disable_Switch_Characters()
                SinglePlayerApartment.Resources.Disable_Weapons()
                SinglePlayerApartment.Resources.Disable_Controls()
                If SinglePlayerApartment.Brain.RadioOn Then Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, True) Else Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, False)
                If SinglePlayerApartment.Brain.RadioOn Then Native.Function.Call(Hash.SET_MOBILE_PHONE_RADIO_STATE, True) Else Native.Function.Call(Hash.SET_MOBILE_PHONE_RADIO_STATE, False)
            ElseIf Not playerInterior = 0 AndAlso SinglePlayerApartment.SinglePlayerApartment.InteriorIDList.Contains(playerInterior) AndAlso Not Game.MissionFlag AndAlso player.WantedLevel > 0 Then
                SinglePlayerApartment.Resources.Disable_Switch_Characters()
            Else
                Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, False)
            End If
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

End Class
