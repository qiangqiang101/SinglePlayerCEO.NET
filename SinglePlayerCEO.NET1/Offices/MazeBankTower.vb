Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms
Imports SinglePlayerCEO.SinglePlayerOffice
Imports INMNativeUI
Imports SinglePlayerApartment.Wardrobe
Imports SinglePlayerApartment.INMNative
Imports SinglePlayerApartment.Resources
Imports SinglePlayerCEO.INMNative

Public Class MazeBankTower
    Inherits Script

    Public Shared Office As Office
    Public Shared BuyMenu, ExitMenu, PersonnelMenu, StockMenu, DecorMenu, PegasusMenu, PersonalVehMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            Office = New Office("Maze Bank Tower", 8000000)
            Office.Name = ReadCfgValue("MBTName", langFile)
            Office.Description = ReadCfgValue("MBTDesc", langFile)
            Office.Owner = ReadCfgValue("MBTowner", saveFile)
            Office.Entrance = New Vector3(0, 0, 0)
            Office.Save = New Vector3(0, 0, 0)
            Office.TeleportInside = New Vector3(0, 0, 0)
            Office.TeleportOutside = New Vector3(0, 0, 0)
            Office.OfficeExit = New Vector3(0, 0, 0)
            Office.OfficeExit2 = New Vector3(0, 0, 0)
            Office.OfficeExit3 = New Vector3(0, 0, 0)
            Office.OfficeExit4 = New Vector3(0, 0, 0)
            Office.Wardrobe = New Vector3(0, 0, 0)
            Office.HelipadEntrance = New Vector3(0, 0, 0)
            Office.Helipad = New Vector3(0, 0, 0)
            Office.CameraPosition = New Vector3(0, 0, 0)
            Office.CameraRotation = New Vector3(0, 0, 0)
            Office.CameraFOV = 50.0
            Office.Interior = New Vector3(0, 0, 0)
            Office.WardrobeHeading = 0.0
            Office.IsAtOffice = False
            Office.SaveFile = "MBTowner"
            Office.PlayerMap = "MazeBankTower"
            Office.Enabled = True
            Office.InteriorID = Office.GetInteriorID(Office.Interior)
            SinglePlayerApartment.SinglePlayerApartment.InteriorIDList.Add(Office.InteriorID)

            If ReadCfgValue("MazeBankTower", settingFile) = "Enable" Then
                OfficeOptions = ReadCfgValue("OfficeOptions", langFile)
                ExitOffice = ReadCfgValue("ExitOffice", langFile)
                ExitOffice2 = ReadCfgValue("ExitToRoof", langFile)
                ExitOfficeViaVeh = ReadCfgValue("ExitViaVeh", langFile)
                ExitOfficeVehPgs = ReadCfgValue("ExitViaPgs", langFile)
                SellOffice = ReadCfgValue("SellOffice", langFile)
                OForSale = ReadCfgValue("OfficeForsale", langFile)
                InsFundOffice = ReadCfgValue("InsFundOffice", langFile)
                EnterOFfice = ReadCfgValue("EnterOffice", langFile)
                _ExitOffice = ReadCfgValue("ExitOfc", langFile)
                ExeRich = ReadCfgValue("ExeRich", langFile)
                ExeCool = ReadCfgValue("ExeCool", langFile)
                ExeContrast = ReadCfgValue("ExeContrast", langFile)
                OSpiClassical = ReadCfgValue("OSpiClassical", langFile)
                OSpiVintage = ReadCfgValue("OSpiVintage", langFile)
                OSpiWarms = ReadCfgValue("OSpiWarms", langFile)
                PowBConservative = ReadCfgValue("PowBConservative", langFile)
                PowBPolished = ReadCfgValue("PowBPolished", langFile)
                PowBIce = ReadCfgValue("PowBIce", langFile)
                SpeakAssist = ReadCfgValue("SpeakAssist", langFile)
                PegasusCon = ReadCfgValue("PegasusCon", langFile)
                PersonalVeh = ReadCfgValue("PersonalVeh", langFile)
                ExeAssService = ReadCfgValue("ExeAssService", langFile)
                OfficeDecor = ReadCfgValue("OfficeDecor", langFile)

                AddHandler Tick, AddressOf OnTick

                _menuPool = New MenuPool()
                CreateBuyMenu()
                CreateExitMenu()
                CreatePersonnelMenu()
                CreateStockMenu()
                CreateDecorMenu()
                CreatePegasusMenu()
                CreateVehicleMenu()

                AddHandler BuyMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler PersonnelMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler StockMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler DecorMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler PegasusMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler PersonalVehMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler BuyMenu.OnItemSelect, AddressOf BuyItemSelectHandler
                AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler PersonnelMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler StockMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler DecorMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler PegasusMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler PersonalVehMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler DecorMenu.OnIndexChange, AddressOf DecorMenuIndexChangeHandler
            End If
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateBuyMenu()
        Try
            BuyMenu = New UIMenu("", OfficeOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            BuyMenu.SetBannerType(Rectangle)
            _menuPool.Add(BuyMenu)
            Dim item As New UIMenuItem(Office.Name, Office.Description)
            With item
                If Office.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf office.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf office.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf office.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightLabel("$" & Office.Cost.ToString("N"))
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            BuyMenu.AddItem(item)
            BuyMenu.RefreshIndex()
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub RefreshMenu()
        BuyMenu.MenuItems.Clear()
        Dim item As New UIMenuItem(Office.Name, Office.Description)
        With item
            If Office.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf Office.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf Office.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf Office.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightLabel("$" & Office.Cost.ToString("N"))
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        BuyMenu.AddItem(item)
        BuyMenu.RefreshIndex()
    End Sub

    Public Shared Sub CreatePersonnelMenu()
        Try
            PersonnelMenu = New UIMenu("", ExeAssService, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            BuyMenu.SetBannerType(Rectangle)
            _menuPool.Add(PersonnelMenu)
            PersonnelMenu.AddItem(New UIMenuItem(PegasusCon))
            PersonnelMenu.AddItem(New UIMenuItem(PersonalVeh))
            PersonnelMenu.AddItem(New UIMenuItem(Decor))
            PersonnelMenu.AddItem(New UIMenuItem(SellOffice))
            PersonnelMenu.RefreshIndex()
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateDecorMenu()
        Try
            DecorMenu = New UIMenu("", OfficeDecor, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            BuyMenu.SetBannerType(Rectangle)
            _menuPool.Add(DecorMenu)
            DecorMenu.AddItem(New UIMenuItem(ExeRich))
            DecorMenu.AddItem(New UIMenuItem(ExeCool))
            DecorMenu.AddItem(New UIMenuItem(ExeContrast))
            DecorMenu.AddItem(New UIMenuItem(OSpiClassical))
            DecorMenu.AddItem(New UIMenuItem(OSpiVintage))
            DecorMenu.AddItem(New UIMenuItem(OSpiWarms))
            DecorMenu.AddItem(New UIMenuItem(PowBConservative))
            DecorMenu.AddItem(New UIMenuItem(PowBPolished))
            DecorMenu.AddItem(New UIMenuItem(PowBIce))
            DecorMenu.RefreshIndex()
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateExitMenu()
        Try
            ExitMenu = New UIMenu("", OfficeOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ExitMenu.SetBannerType(Rectangle)
            _menuPool.Add(ExitMenu)
            ExitMenu.AddItem(New UIMenuItem(ExitOfficeViaVeh))
            ExitMenu.AddItem(New UIMenuItem(ExitOfficeVehPgs))
            ExitMenu.AddItem(New UIMenuItem(ExitOffice))
            ExitMenu.AddItem(New UIMenuItem(ExitOffice2))
            ExitMenu.RefreshIndex()
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateMazeBankTower()
        Office.Create(Office)
    End Sub

    Public Sub MenuCloseHandler(sender As UIMenu)
        Try
            hideHud = False
            World.DestroyAllCameras()
            World.RenderingCamera = Nothing
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ExitOffice Then
                'Exit Office
                ExitMenu.Visible = False
                Wait(&H3E8)
                SinglePlayerApartment.Brain.TVOn = False
                Game.Player.Character.Position = Office.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf selectedItem.Text = ExitOffice2 Then
                'Exit Office to Rooftop
                ExitMenu.Visible = False
                PegasusMenu.Visible = True
            ElseIf selectedItem.Text = ExitOfficeViaVeh Then
                'Exit Office with Vehicle Menu
                ExitMenu.Visible = False
            ElseIf selectedItem.Text = ExitOfficeVehPgs Then
                'Exit Office with Pegasus Menu
                ExitMenu.Visible = False
            End If

            If selectedItem.Text = ExeRich Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBTipl", "ex_dt1_11_office_01a", saveFile)
                Office.IPL = "ex_dt1_11_office_01a"
                Wait(500)
                Game.FadeScreenIn(500)
                DecorMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = ExeCool Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBTipl", "ex_dt1_11_office_01b", saveFile)
                Office.IPL = "ex_dt1_11_office_01b"
                Wait(500)
                Game.FadeScreenIn(500)
                DecorMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = ExeContrast Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBTipl", "ex_dt1_11_office_01c", saveFile)
                Office.IPL = "ex_dt1_11_office_01c"
                Wait(500)
                Game.FadeScreenIn(500)
                DecorMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = OSpiClassical Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBTipl", "ex_dt1_11_office_02a", saveFile)
                Office.IPL = "ex_dt1_11_office_02a"
                Wait(500)
                Game.FadeScreenIn(500)
                DecorMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = OSpiVintage Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBTipl", "ex_dt1_11_office_02b", saveFile)
                Office.IPL = "ex_dt1_11_office_02b"
                Wait(500)
                Game.FadeScreenIn(500)
                DecorMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = OSpiWarms Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBTipl", "ex_dt1_11_office_02c", saveFile)
                Office.IPL = "ex_dt1_11_office_02c"
                Wait(500)
                Game.FadeScreenIn(500)
                DecorMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = PowBConservative Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBTipl", "ex_dt1_11_office_03a", saveFile)
                Office.IPL = "ex_dt1_11_office_03a"
                Wait(500)
                Game.FadeScreenIn(500)
                DecorMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = PowBPolished Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBTipl", "ex_dt1_11_office_03b", saveFile)
                Office.IPL = "ex_dt1_11_office_03b"
                Wait(500)
                Game.FadeScreenIn(500)
                DecorMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = PowBIce Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBTipl", "ex_dt1_11_office_03c", saveFile)
                Office.IPL = "ex_dt1_11_office_03c"
                Wait(500)
                Game.FadeScreenIn(500)
                DecorMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            End If

            If selectedItem.Text = PegasusCon Then
                'Pegasus
                PersonnelMenu.Visible = False
                PersonalVehicle.Call_Pegasus()
            ElseIf selectedItem.Text = PersonalVeh Then
                'Mechanic Menu in Office
                PersonnelMenu.Visible = False
                PersonalVehicle.Call_Mechanic()
            ElseIf selectedItem.Text = SellOffice Then
                'Sell Office
                PersonnelMenu.Visible = False
                WriteCfgValue(Office.SaveFile, "None", saveFile)
                SinglePlayerApartment.SinglePlayerApartment.SavePosition2()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SinglePlayerOffice.player.Money = (playerCash + Office.Cost)
                Office.Owner = "None"
                Office.OfficeBlip.Remove()
                CreateMazeBankTower()
                SinglePlayerApartment.Brain.TVOn = False
                Game.Player.Character.Position = Office.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
                RefreshMenu()
            ElseIf selectedItem.Text = Decor Then
                'Change Style Decoration
                PersonnelMenu.Visible = False
                DecorMenu.Visible = True
                Game.FadeScreenOut(500)
                Wait(500)
                World.RenderingCamera = World.CreateCamera(Office.OfficeStyleCameraPosition, Office.OfficeStyleCameraRotation, Office.OfficeStyleCameraFOV)
                hideHud = True
                Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub BuyItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = Office.Name AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso selectedItem.RightLabel = "$" & Office.Cost.ToString("N") AndAlso Office.Owner = "None" Then
                'Buy Office
                If playerCash > Office.Cost Then
                    WriteCfgValue(Office.SaveFile, playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Wait(&H3E8)
                    SinglePlayerOffice.player.Money = (playerCash - Office.Cost)
                    Office.Owner = playerName
                    Office.OfficeBlip.Remove()
                    CreateMazeBankTower()
                    Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & SinglePlayerApartment.SinglePlayerApartment.PropPurchased, "~w~" & Office.Name, Nothing)
                    If playerName = "Michael" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    ElseIf playerName = "Franklin" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    ElseIf playerName = "Trevor" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    ElseIf playerName = "Player3" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End If
                    selectedItem.SetRightLabel("")
                Else
                    If playerName = "Michael" Then
                        SinglePlayerApartment.SinglePlayerApartment.DisplayNotificationThisFrame(SinglePlayerApartment.SinglePlayerApartment.Maze, "", InsFundOffice, "CHAR_BANK_MAZE", True, SinglePlayerApartment.SinglePlayerApartment.IconType.RightJumpingArrow)
                    ElseIf playerName = "Franklin" Then
                        SinglePlayerApartment.SinglePlayerApartment.DisplayNotificationThisFrame(SinglePlayerApartment.SinglePlayerApartment.Fleeca, "", InsFundOffice, "CHAR_BANK_FLEECA", True, SinglePlayerApartment.SinglePlayerApartment.IconType.RightJumpingArrow)
                    ElseIf playerName = "Trevor" Then
                        SinglePlayerApartment.SinglePlayerApartment.DisplayNotificationThisFrame(SinglePlayerApartment.SinglePlayerApartment.BOL, "", InsFundOffice, "CHAR_BANK_BOL", True, SinglePlayerApartment.SinglePlayerApartment.IconType.RightJumpingArrow)
                    ElseIf playerName = "Player3" Then
                        SinglePlayerApartment.SinglePlayerApartment.DisplayNotificationThisFrame(SinglePlayerApartment.SinglePlayerApartment.Maze, "", InsFundOffice, "CHAR_BANK_MAZE", True, SinglePlayerApartment.SinglePlayerApartment.IconType.RightJumpingArrow)
                    End If
                End If
            ElseIf selectedItem.Text = Office.Name AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Office.Owner = playerName Then
                'Enter Office
                BuyMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
                Office.SetInteriorActive()
                Office.InteriorID = Office.GetInteriorID(Office.Interior)
                Game.FadeScreenOut(500)
                Wait(500)
                Game.Player.Character.Position = Office.TeleportInside
                Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If My.Settings.MazeBankTower = "Enable" Then
                'Enter Office
                If (Not BuyMenu.Visible AndAlso playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Office.EntranceDistance < 3.0 Then
                    SinglePlayerApartment.SinglePlayerApartment.DisplayHelpTextThisFrame(EnterOFfice & Office.Name)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        Game.FadeScreenOut(500)
                        Wait(500)
                        BuyMenu.Visible = True
                        World.RenderingCamera = World.CreateCamera(Office.CameraPosition, Office.CameraRotation, Office.CameraFOV)
                        hideHud = True
                        Wait(500)
                        Game.FadeScreenIn(500)
                    End If
                End If

                'Save Game
                If ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Office.Owner = playerName) AndAlso Office.SaveDistance < 3.0 Then
                    SinglePlayerApartment.SinglePlayerApartment.DisplayHelpTextThisFrame(SinglePlayerApartment.SinglePlayerApartment.SaveGame)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        playerMap = Office.PlayerMap
                        Game.FadeScreenOut(500)
                        Wait(&H3E8)
                        SinglePlayerApartment.SinglePlayerApartment.TimeLapse(8)
                        Game.ShowSaveMenu()
                        SinglePlayerApartment.SinglePlayerApartment.SavePosition()
                        Wait(500)
                        Game.FadeScreenIn(500)
                    End If
                End If

                'Exit Office
                If ((Not ExitMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Office.Owner = playerName) AndAlso Office.ExitDistance < 2.0 Then
                    SinglePlayerApartment.SinglePlayerApartment.DisplayHelpTextThisFrame(_ExitOffice & Office.Name)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenu.Visible = True
                    End If
                End If
                If ((Not ExitMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Office.Owner = playerName) AndAlso Office.ExitDistance2 < 2.0 Then
                    SinglePlayerApartment.SinglePlayerApartment.DisplayHelpTextThisFrame(_ExitOffice & Office.Name)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenu.Visible = True
                    End If
                End If
                If ((Not ExitMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Office.Owner = playerName) AndAlso Office.ExitDistance3 < 2.0 Then
                    SinglePlayerApartment.SinglePlayerApartment.DisplayHelpTextThisFrame(_ExitOffice & Office.Name)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenu.Visible = True
                    End If
                End If
                If ((Not ExitMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Office.Owner = playerName) AndAlso Office.ExitDistance4 < 2.0 Then
                    SinglePlayerApartment.SinglePlayerApartment.DisplayHelpTextThisFrame(_ExitOffice & Office.Name)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenu.Visible = True
                    End If
                End If

                'Wardrobe
                If ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Office.Owner = playerName) AndAlso Office.WardrobeDistance < 1.0 Then
                    SinglePlayerApartment.SinglePlayerApartment.DisplayHelpTextThisFrame(SinglePlayerApartment.SinglePlayerApartment.ChangeClothes)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        WardrobeVector = Office.Wardrobe
                        WardrobeHead = Office.WardrobeHeading
                        WardrobeScriptStatus = 0
                        If playerName = "Michael" Then
                            Player0W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Franklin" Then
                            Player1W.Visible = True
                            MakeACamera()
                        ElseIf playerName = “Trevor"
                            Player2W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Player3" Then
                            If playerHash = "1885233650" Then
                                Player3_MW.Visible = True
                                MakeACamera()
                            ElseIf playerHash = "-1667301416" Then
                                Player3_FW.Visible = True
                                MakeACamera()
                            End If
                        End If
                    End If
                End If

                Select Case playerInterior
                    Case Office.InteriorID
                        Office.IsAtOffice = True
                        HIDE_MAP_OBJECT_THIS_FRAME()
                    Case Else
                        Office.IsAtOffice = False
                End Select

                If Office.IsAtOffice Then
                    HIDE_MAP_OBJECT_THIS_FRAME()
                End If

                _menuPool.ProcessMenus()
            End If
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub HIDE_MAP_OBJECT_THIS_FRAME()
        Native.Function.Call(Hash._0x4B5CFC83122DF602)
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "dt1_11_dt1_tower"))
        Native.Function.Call(Hash._0x3669F1B198DCAA4F)
    End Sub

    Public Sub OnAborted() Handles MyBase.Aborted
        Try
            If Not Office.OfficeBlip Is Nothing Then Office.OfficeBlip.Remove()
        Catch ex As Exception
        End Try
    End Sub
End Class
