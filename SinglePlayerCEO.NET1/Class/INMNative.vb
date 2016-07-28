Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports SinglePlayerApartment.INMNative

Namespace INMNative

    Public Enum OfficeBlipSprite
        Office = 456
        OfficeForSale = 457
        Warehouse = 458
        WarehouseForSale = 459
    End Enum

    Public Class Office

        Private _cost, _interiorID As Integer
        Private _owner, _name, _desc, _savefile, _playermap, _ipl, _lastipl As String
        Private _officeblip As Blip
        Private _entrance, _save, _telin, _telout, _exit, _exit2, _exit3, _exit4, _wardrobe, _helipadent, _helipad, _camerapos, _camerarot, _interior, _oscamerapos, _oscamerarot As Vector3
        Private _camerafov, _wardrobeheading, _oscamerafov As Single
        Private _isatoffice, _enabled As Boolean

        Public Sub New(Name As String, Cost As Integer, Optional Description As String = "")
            _name = Name
            _cost = Cost
            _desc = Description
            _enabled = True
        End Sub

        Public Property Owner() As String
            Get
                Return _owner
            End Get
            Set(value As String)
                _owner = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _desc
            End Get
            Set(value As String)
                _desc = value
            End Set
        End Property

        Public Property Cost() As Integer
            Get
                Return _cost
            End Get
            Set(value As Integer)
                _cost = value
            End Set
        End Property

        Public Property OfficeBlip() As Blip
            Get
                Return _officeblip
            End Get
            Set(value As Blip)
                _officeblip = value
            End Set
        End Property

        Public Property Entrance() As Vector3
            Get
                Return _entrance
            End Get
            Set(value As Vector3)
                _entrance = value
            End Set
        End Property

        Public Property Save() As Vector3
            Get
                Return _save
            End Get
            Set(value As Vector3)
                _save = value
            End Set
        End Property

        Public Property TeleportInside() As Vector3
            Get
                Return _telin
            End Get
            Set(value As Vector3)
                _telin = value
            End Set
        End Property

        Public Property TeleportOutside() As Vector3
            Get
                Return _telout
            End Get
            Set(value As Vector3)
                _telout = value
            End Set
        End Property

        Public Property OfficeExit() As Vector3
            Get
                Return _exit
            End Get
            Set(value As Vector3)
                _exit = value
            End Set
        End Property

        Public Property OfficeExit2() As Vector3
            Get
                Return _exit2
            End Get
            Set(value As Vector3)
                _exit2 = value
            End Set
        End Property

        Public Property OfficeExit3() As Vector3
            Get
                Return _exit3
            End Get
            Set(value As Vector3)
                _exit3 = value
            End Set
        End Property

        Public Property OfficeExit4() As Vector3
            Get
                Return _exit4
            End Get
            Set(value As Vector3)
                _exit4 = value
            End Set
        End Property

        Public Property Wardrobe() As Vector3
            Get
                Return _wardrobe
            End Get
            Set(value As Vector3)
                _wardrobe = value
            End Set
        End Property

        Public Property WardrobeHeading() As Single
            Get
                Return _wardrobeheading
            End Get
            Set(value As Single)
                _wardrobeheading = value
            End Set
        End Property

        Public Property HelipadEntrance() As Vector3
            Get
                Return _helipadent
            End Get
            Set(value As Vector3)
                _helipadent = value
            End Set
        End Property

        Public Property Helipad() As Vector3
            Get
                Return _helipad
            End Get
            Set(value As Vector3)
                _helipad = value
            End Set
        End Property

        Public Property CameraPosition() As Vector3
            Get
                Return _camerapos
            End Get
            Set(value As Vector3)
                _camerapos = value
            End Set
        End Property

        Public Property CameraRotation() As Vector3
            Get
                Return _camerarot
            End Get
            Set(value As Vector3)
                _camerarot = value
            End Set
        End Property

        Public Property CameraFOV() As Single
            Get
                Return _camerafov
            End Get
            Set(value As Single)
                _camerafov = value
            End Set
        End Property

        Public ReadOnly Property HelipadDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, Helipad)
            End Get
        End Property

        Public ReadOnly Property WardrobeDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, Wardrobe)
            End Get
        End Property

        Public ReadOnly Property EntranceDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, Entrance)
            End Get
        End Property

        Public ReadOnly Property SaveDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, Save)
            End Get
        End Property

        Public ReadOnly Property ExitDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, OfficeExit)
            End Get
        End Property

        Public ReadOnly Property ExitDistance2() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, OfficeExit2)
            End Get
        End Property

        Public ReadOnly Property ExitDistance3() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, OfficeExit3)
            End Get
        End Property

        Public ReadOnly Property ExitDistance4() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, OfficeExit4)
            End Get
        End Property

        Public Property IsAtOffice() As Boolean
            Get
                Return _isatoffice
            End Get
            Set(value As Boolean)
                _isatoffice = value
            End Set
        End Property

        Public ReadOnly Property Position() As Vector3
            Get
                Return Entrance
            End Get
        End Property

        Public ReadOnly Property IsForSale() As Boolean
            Get
                If OfficeBlip.Sprite = OfficeBlipSprite.OfficeForSale Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Property Enabled() As Boolean
            Get
                Return _enabled
            End Get
            Set(value As Boolean)
                _enabled = value
            End Set
        End Property

        Public Property Interior() As Vector3
            Get
                Return _interior
            End Get
            Set(value As Vector3)
                _interior = value
            End Set
        End Property

        Public Property SaveFile() As String
            Get
                Return _savefile
            End Get
            Set(value As String)
                _savefile = value
            End Set
        End Property

        Public Property PlayerMap() As String
            Get
                Return _playermap
            End Get
            Set(value As String)
                _playermap = value
            End Set
        End Property

        Public Property IPL() As String
            Get
                Return _ipl
            End Get
            Set(value As String)
                _ipl = value
            End Set
        End Property

        Public Property LastIPL() As String
            Get
                Return _lastipl
            End Get
            Set(value As String)
                _lastipl = value
            End Set
        End Property

        Public Property OfficeStyleCameraPosition() As Vector3
            Get
                Return _oscamerapos
            End Get
            Set(value As Vector3)
                _oscamerapos = value
            End Set
        End Property

        Public Property OfficeStyleCameraRotation() As Vector3
            Get
                Return _oscamerarot
            End Get
            Set(value As Vector3)
                _oscamerarot = value
            End Set
        End Property

        Public Property OfficeStyleCameraFOV() As Single
            Get
                Return _oscamerafov
            End Get
            Set(value As Single)
                _oscamerafov = value
            End Set
        End Property

        Public Property InteriorID() As Integer
            Get
                Return _interiorID
            End Get
            Set(value As Integer)
                _interiorID = value
            End Set
        End Property

        Public Shared Function GetInteriorID(interior As Vector3) As Integer
            Return Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, interior.X, interior.Y, interior.Z)
        End Function

        Public Sub SetInteriorActive()
            Try
                Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, Interior.X, Interior.Y, Interior.Z)
                Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {intID})
                Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, intID, True)
                Native.Function.Call(Hash.DISABLE_INTERIOR, intID, False)
                'InteriorID = intID
                If Not intID = 0 AndAlso Not SinglePlayerApartment.SinglePlayerApartment.InteriorIDList.Contains(intID) Then SinglePlayerApartment.SinglePlayerApartment.InteriorIDList.Add(intID)
            Catch ex As Exception
                SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
            End Try
        End Sub

        Public Sub Create(Office As Office)
            Office.OfficeBlip = World.CreateBlip(Office.Entrance)
            If Office.Owner = "Michael" Then
                Office.OfficeBlip.Sprite = OfficeBlipSprite.Office
                Office.OfficeBlip.Color = INMBlipColor.Michael
                Office.OfficeBlip.IsShortRange = True
                Office.OfficeBlip.Name = Office.Name
            ElseIf Office.Owner = "Franklin" Then
                Office.OfficeBlip.Sprite = OfficeBlipSprite.Office
                Office.OfficeBlip.Color = INMBlipColor.Franklin
                Office.OfficeBlip.IsShortRange = True
                Office.OfficeBlip.Name = Office.Name
            ElseIf Office.Owner = "Trevor" Then
                Office.OfficeBlip.Sprite = OfficeBlipSprite.Office
                Office.OfficeBlip.Color = INMBlipColor.Trevor
                Office.OfficeBlip.IsShortRange = True
                Office.OfficeBlip.Name = Office.Name
            ElseIf Office.Owner = "Player3" Then
                Office.OfficeBlip.Sprite = OfficeBlipSprite.Office
                Office.OfficeBlip.Color = INMBlipColor.Yellow
                Office.OfficeBlip.IsShortRange = True
                Office.OfficeBlip.Name = Office.Name
            Else
                Office.OfficeBlip.Sprite = OfficeBlipSprite.OfficeForSale
                Office.OfficeBlip.Color = INMBlipColor.White
                Office.OfficeBlip.IsShortRange = True
                Office.OfficeBlip.Name = SinglePlayerOffice.OForSale
            End If
        End Sub
    End Class

    Public Class Warehouse

        Private _cost, _interiorID As Integer
        Private _owner, _name, _desc, _savefile, _playermap, _ipl, _lastipl, _wrhpath As String
        Private _wrhblip As Blip
        Private _entrance, _telin, _telout, _exit, _camerapos, _camerarot, _interior As Vector3
        Private _camerafov As Single
        Private _isatwarehouse, _enabled As Boolean

        Public Sub New(Name As String, Cost As Integer, Optional Description As String = "")
            _name = Name
            _cost = Cost
            _desc = Description
            _enabled = True
        End Sub

        Public Property Owner() As String
            Get
                Return _owner
            End Get
            Set(value As String)
                _owner = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _desc
            End Get
            Set(value As String)
                _desc = value
            End Set
        End Property

        Public Property Cost() As Integer
            Get
                Return _cost
            End Get
            Set(value As Integer)
                _cost = value
            End Set
        End Property

        Public Property WarehouseBlip() As Blip
            Get
                Return _wrhblip
            End Get
            Set(value As Blip)
                _wrhblip = value
            End Set
        End Property

        Public Property Entrance() As Vector3
            Get
                Return _entrance
            End Get
            Set(value As Vector3)
                _entrance = value
            End Set
        End Property

        Public Property TeleportInside() As Vector3
            Get
                Return _telin
            End Get
            Set(value As Vector3)
                _telin = value
            End Set
        End Property

        Public Property TeleportOutside() As Vector3
            Get
                Return _telout
            End Get
            Set(value As Vector3)
                _telout = value
            End Set
        End Property

        Public Property WarehouseExit() As Vector3
            Get
                Return _exit
            End Get
            Set(value As Vector3)
                _exit = value
            End Set
        End Property

        Public Property CameraPosition() As Vector3
            Get
                Return _camerapos
            End Get
            Set(value As Vector3)
                _camerapos = value
            End Set
        End Property

        Public Property CameraRotation() As Vector3
            Get
                Return _camerarot
            End Get
            Set(value As Vector3)
                _camerarot = value
            End Set
        End Property

        Public Property CameraFOV() As Single
            Get
                Return _camerafov
            End Get
            Set(value As Single)
                _camerafov = value
            End Set
        End Property

        Public ReadOnly Property EntranceDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, Entrance)
            End Get
        End Property

        Public ReadOnly Property ExitDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, WarehouseExit)
            End Get
        End Property

        Public Property IsAtWarehouse() As Boolean
            Get
                Return _isatwarehouse
            End Get
            Set(value As Boolean)
                _isatwarehouse = value
            End Set
        End Property

        Public ReadOnly Property Position() As Vector3
            Get
                Return Entrance
            End Get
        End Property

        Public ReadOnly Property IsForSale() As Boolean
            Get
                If WarehouseBlip.Sprite = OfficeBlipSprite.WarehouseForSale Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Property Enabled() As Boolean
            Get
                Return _enabled
            End Get
            Set(value As Boolean)
                _enabled = value
            End Set
        End Property

        Public Property WarehousePath() As String
            Get
                Return _wrhpath
            End Get
            Set(value As String)
                _wrhpath = value
            End Set
        End Property

        Public Property Interior() As Vector3
            Get
                Return _interior
            End Get
            Set(value As Vector3)
                _interior = value
            End Set
        End Property

        Public Property SaveFile() As String
            Get
                Return _savefile
            End Get
            Set(value As String)
                _savefile = value
            End Set
        End Property

        Public Property PlayerMap() As String
            Get
                Return _playermap
            End Get
            Set(value As String)
                _playermap = value
            End Set
        End Property

        Public Property IPL() As String
            Get
                Return _ipl
            End Get
            Set(value As String)
                _ipl = value
            End Set
        End Property

        Public Property LastIPL() As String
            Get
                Return _lastipl
            End Get
            Set(value As String)
                _lastipl = value
            End Set
        End Property

        Public Property InteriorID() As Integer
            Get
                Return _interiorID
            End Get
            Set(value As Integer)
                _interiorID = value
            End Set
        End Property

        Public Shared Function GetInteriorID(interior As Vector3) As Integer
            Return Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, interior.X, interior.Y, interior.Z)
        End Function

        Public Sub SetInteriorActive()
            Try
                Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, Interior.X, Interior.Y, Interior.Z)
                Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {intID})
                Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, intID, True)
                Native.Function.Call(Hash.DISABLE_INTERIOR, intID, False)
                'InteriorID = intID
                If Not intID = 0 AndAlso Not SinglePlayerApartment.SinglePlayerApartment.InteriorIDList.Contains(intID) Then SinglePlayerApartment.SinglePlayerApartment.InteriorIDList.Add(intID)
            Catch ex As Exception
                SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
            End Try
        End Sub

        Public Sub Create(Warehouse As Warehouse)
            Warehouse.WarehouseBlip = World.CreateBlip(Warehouse.Entrance)
            If Warehouse.Owner = "Michael" Then
                Warehouse.WarehouseBlip.Sprite = OfficeBlipSprite.Warehouse
                Warehouse.WarehouseBlip.Color = INMBlipColor.Michael
                Warehouse.WarehouseBlip.IsShortRange = True
                Warehouse.WarehouseBlip.Name = Warehouse.Name
            ElseIf Warehouse.Owner = "Franklin" Then
                Warehouse.WarehouseBlip.Sprite = OfficeBlipSprite.Warehouse
                Warehouse.WarehouseBlip.Color = INMBlipColor.Franklin
                Warehouse.WarehouseBlip.IsShortRange = True
                Warehouse.WarehouseBlip.Name = Warehouse.Name
            ElseIf Warehouse.Owner = "Trevor" Then
                Warehouse.WarehouseBlip.Sprite = OfficeBlipSprite.Warehouse
                Warehouse.WarehouseBlip.Color = INMBlipColor.Trevor
                Warehouse.WarehouseBlip.IsShortRange = True
                Warehouse.WarehouseBlip.Name = Warehouse.Name
            ElseIf Warehouse.Owner = "Player3" Then
                Warehouse.WarehouseBlip.Sprite = OfficeBlipSprite.Warehouse
                Warehouse.WarehouseBlip.Color = INMBlipColor.Yellow
                Warehouse.WarehouseBlip.IsShortRange = True
                Warehouse.WarehouseBlip.Name = Warehouse.Name
            Else
                Warehouse.WarehouseBlip.Sprite = OfficeBlipSprite.WarehouseForSale
                Warehouse.WarehouseBlip.Color = INMBlipColor.White
                Warehouse.WarehouseBlip.IsShortRange = True
                Warehouse.WarehouseBlip.Name = SinglePlayerOffice.WforSale
            End If
        End Sub

    End Class

End Namespace
