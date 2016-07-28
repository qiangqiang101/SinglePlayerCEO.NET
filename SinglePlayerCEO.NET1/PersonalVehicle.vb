Imports System.Drawing
Imports GTA
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports INMNativeUI
Imports SinglePlayerApartment.Resources
Imports GTA.Math
Imports SinglePlayerApartment.INMNative
Imports SinglePlayerApartment.Mechanic
Imports SinglePlayerCEO.SinglePlayerOffice

Public Class PersonalVehicle
    Inherits Script

    Public Sub New()

    End Sub

    Public Shared Sub Call_Mechanic()
        AS3 = ReadCfgValue("3ASowner", saveFileSPA)
        IW4 = ReadCfgValue("4IWowner", saveFileSPA)
        IW4HL = ReadCfgValue("4IWHLowner", saveFileSPA)
        DPH = ReadCfgValue("DPHwoner", saveFileSPA)
        DPHHL = ReadCfgValue("DPHHLowner", saveFileSPA)
        DT = ReadCfgValue("SSowner", saveFileSPA)
        ET = ReadCfgValue("ETowner", saveFileSPA)
        ETHL = ReadCfgValue("ETHLowner", saveFileSPA)
        RM = ReadCfgValue("RMowner", saveFileSPA)
        RMHL = ReadCfgValue("RMHLowner", saveFileSPA)
        TT = ReadCfgValue("TTowner", saveFileSPA)
        TTHL = ReadCfgValue("TTHLowner", saveFileSPA)
        WP = ReadCfgValue("WPowner", saveFileSPA)
        VB = ReadCfgValue("VPBowner", saveFileSPA)
        NC2044 = ReadCfgValue("2044NCowner", saveFileSPA)
        HA2862 = ReadCfgValue("2862HAowner", saveFileSPA)
        HA2868 = ReadCfgValue("2868HAowner", saveFileSPA)
        WO3655 = ReadCfgValue("3655WODowner", saveFileSPA)
        NC2045 = ReadCfgValue("2045NCowner", saveFileSPA)
        MR2117 = ReadCfgValue("2117MRowner", saveFileSPA)
        HA2874 = ReadCfgValue("2874HAowner", saveFileSPA)
        WD3677 = ReadCfgValue("3677WMDowner", saveFileSPA)
        MW2113 = ReadCfgValue("2113MWTowner", saveFileSPA)
        ETP1 = ReadCfgValue("ETP1owner", saveFileSPA)
        ETP2 = ReadCfgValue("ETP2owner", saveFileSPA)
        ETP3 = ReadCfgValue("ETP3owner", saveFileSPA)
        BCA = ReadCfgValue("BCAowner", saveFileSPA)
        BDP = ReadCfgValue("BDPowner", saveFileSPA)
        CA = ReadCfgValue("CAowner", saveFileSPA)
        HA = ReadCfgValue("HAowner", saveFileSPA)
        LLB0604 = ReadCfgValue("0604LLBowner", saveFileSPA)
        LLB2143 = ReadCfgValue("2143LLBowner", saveFileSPA)
        MR0184 = ReadCfgValue("0184MRowner", saveFileSPA)
        POWER = ReadCfgValue("PSowner", saveFileSPA)
        PD4401 = ReadCfgValue("4401PDowner", saveFileSPA)
        PD4584 = ReadCfgValue("4584PDowner", saveFileSPA)
        PPS = ReadCfgValue("PPSowner", saveFileSPA)
        SVS = ReadCfgValue("SVSowner", saveFileSPA)
        SMMD = ReadCfgValue("SMMowner", saveFileSPA)
        SRD0325 = ReadCfgValue("0325SRDowner", saveFileSPA)
        SA = ReadCfgValue("SAonwer", saveFileSPA)
        SR = ReadCfgValue("SRowner", saveFileSPA)
        TR = ReadCfgValue("TRowner", saveFileSPA)
        GA = ReadCfgValue("GAowner", saveFileSPA)
        PB = ReadCfgValue("PBowner", saveFileSPA)
        SRD0112 = ReadCfgValue("0112SRDowner", saveFileSPA)
        ZA = ReadCfgValue("ZAowner", saveFileSPA)

        ReadMenuItems()

        CreateMechanicMenu()
        CreateVehMenuApartments(AS3Menu, itemAS3, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\")
        CreateVehMenuApartments(DTMenu, itemDT, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\")
        CreateVehMenuApartments(ETMenu, itemET, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\")
        CreateVehMenuApartments(ETHLMenu, itemETHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\")
        CreateVehMenuApartments(IW4Menu, itemIW4, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\")
        CreateVehMenuApartments(IW4HLMenu, itemIW4HL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\")
        CreateVehMenuApartments(DPHMenu, itemDPH, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\")
        CreateVehMenuApartments(DPHHLMenu, itemDPHHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\")
        CreateVehMenuApartments(RMMenu, itemRM, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\")
        CreateVehMenuApartments(RMHLMenu, itemRMHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\")
        CreateVehMenuApartments(TTMenu, itemTT, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\")
        CreateVehMenuApartments(TTHLMenu, itemTTHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\")
        CreateVehMenuApartments(WPMenu, itemWP, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\")
        CreateVehMenuApartments(NC2044Menu, itemNC2044, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\")
        CreateVehMenuApartments(HA2862Menu, itemHA2862, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\")
        CreateVehMenuApartments(HA2868Menu, itemHA2868, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcrest_ave\")
        CreateVehMenuApartments(WO3655Menu, itemWO3655, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\")
        CreateVehMenuApartments(NC2045Menu, itemNC2045, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\")
        CreateVehMenuApartments(MR2117Menu, itemMR2117, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\")
        CreateVehMenuApartments(HA2874Menu, itemHA2874, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\")
        CreateVehMenuApartments(WD3677Menu, itemWD3677, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
        CreateVehMenuApartments(MW2113Menu, itemMW2113, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\")
        CreateVehMenuApartments(ETP1Menu, itemETP1, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\")
        CreateVehMenuApartments(ETP2Menu, itemETP2, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\")
        CreateVehMenuApartments(ETP3Menu, itemETP3, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\")
        CreateVehMenuApartments(BCAMenu, itemBCA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\bay_city_ave\")
        CreateVehMenuApartments(BDPMenu, itemBDP, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\blvd_del_perro\")
        CreateVehMenuApartments(CAMenu, itemCA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\cougar_ave\")
        CreateVehMenuApartments(HAMenu, itemHA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\hangman_ave\")
        CreateVehMenuApartments(LLB0604Menu, itemLLB0604, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0604_las_lagunas_blvd\")
        CreateVehMenuApartments(LLB2143Menu, itemLLB2143, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2143_las_lagunas_blvd\")
        CreateVehMenuApartments(MR0184Menu, itemMR0184, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0184_milton_road\")
        CreateVehMenuApartments(PowerMenu, itemPower, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\power_st\")
        CreateVehMenuApartments(PD4401Menu, itemPD4401, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4401_procopio_dr\")
        CreateVehMenuApartments(PD4584Menu, itemPD4584, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4584_procopio_dr\")
        CreateVehMenuApartments(ProsperityMenu, itemProsperity, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\prosperity_st\")
        CreateVehMenuApartments(SVSMenu, itemSVS, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\san_vitas_st\")
        CreateVehMenuApartments(SMMDMenu, itemSMMD, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\south_mo_milton_dr\")
        CreateVehMenuApartments(SRD0325Menu, itemSRD0325, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0325_south_rockford_dr\")
        CreateVehMenuApartments(SAMenu, itemSA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\spanish_ave\")
        CreateVehMenuApartments(SRMenu, itemSR, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\sustancia_rd\")
        CreateVehMenuApartments(TRMenu, itemTR, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\the_royale\")
        CreateVehMenuApartments6(VBMenu, itemVB, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\vespucci_blvd\")
        CreateVehMenuApartments6(GAMenu, itemGA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\grapeseed_ave\")
        CreateVehMenuApartments6(PBMenu, itemPB, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\paleto_blvd\")
        CreateVehMenuApartments6(SRD0112Menu, itemSRD0112, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0112_south_rockford_dr\")
        CreateVehMenuApartments6(ZAMenu, itemZA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\zancudo_ave\")

        MechanicMenu.Visible = Not MechanicMenu.Visible
    End Sub

    Public Shared Sub Call_Pegasus()
        Try
            Select Case SinglePlayerOffice.playerName
                Case "Michael"
                    CreateMPegasusMenu()
                    MichaelPegasusMenu.Visible = True
                Case "Franklin"
                    CreateFPegasusMenu()
                    FranklinPegasusMenu.Visible = True
                Case "Trevor"
                    CreateTPegasusMenu()
                    TrevorPegasusMenu.Visible = True
                Case "Player3"
                    CreatePPegasusMenu()
                    Player3PegasusMenu.Visible = True
            End Select
        Catch ex As Exception
            SinglePlayerApartment.logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

End Class
