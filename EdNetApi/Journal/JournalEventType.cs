// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournalEventType.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal
{
    using System.ComponentModel;

    public enum JournalEventType
    {
        [Description("Unknown - journal entry failed to parse")]
        UnknownValue = -1,

        [Description("File header")]
        Fileheader = 0,

        [Description("Triggered on the hour every hour")]
        GamePlayed,

        [Description("Triggered when OCR analysis of a mission is completed")]
        MissionAnalyzed,

        [Description("Triggers at startup, when loading from main menu")]
        Cargo,

        [Description("Triggers if you should ever reset your game")]
        ClearSavedGame,

        [Description("Triggers at startup, when loading from main menu")]
        Loadout,

        [Description("Triggers at startup, when loading from main menu into game")]
        Materials,

        [Description("Triggers when creating a new commander")]
        NewCommander,

        [Description("Triggers at startup, when loading from main menu into game")]
        LoadGame,

        [Description("Triggers at startup, when loading the saved game file")]
        Passengers,

        [Description("Triggers at startup")]
        Progress,

        [Description("Triggers at startup")]
        Rank,

        [Description("Triggers when landing at landing pad in a space station, outpost, or surface settlement")]
        Docked,

        [Description("Triggers when the player cancels a docking request")]
        DockingCancelled,

        [Description("Triggers when the station denies a docking request")]
        DockingDenied,

        [Description("Triggers when a docking request is granted")]
        DockingGranted,

        [Description("Triggers when the player requests docking at a station")]
        DockingRequested,

        [Description("Triggers when a docking request has timed out")]
        DockingTimeout,

        [Description("Triggers when jumping from one star system to another")]
        FsdJump,

        [Description("Triggers when taking off from planet surface")]
        Liftoff,

        [Description("Triggers at startup, or when being resurrected at a station")]
        Location,

        [Description("Triggers at the start of a Hyperspace or Supercruise jump (start of countdown)")]
        StartJump,

        [Description("Triggers when entering supercruise from normal space")]
        SupercruiseEntry,

        [Description("Triggers when leaving supercruise for normal space")]
        SupercruiseExit,

        [Description("Triggers when landing on a planet surface")]
        Touchdown,

        [Description("Triggers when liftoff from a landing pad in a station, outpost or settlement")]
        Undocked,

        [Description("Triggers when player is awarded a bounty for a kill")]
        Bounty,

        [Description("Triggers when the player has been rewarded for a capital ship combat")]
        CapShipBond,

        [Description("Triggers when player was killed")]
        Died,

        [Description("Triggers when player has escaped interdiction")]
        EscapeInterdiction,

        [Description("Triggers when player rewarded for taking part in a combat zone")]
        FactionKillBond,

        [Description("Triggers when taking damage due to overheating")]
        HeatDamage,

        [Description("Triggers when heat exceeds 100%")]
        HeatWarning,

        [Description("Triggers when hull health drops below a threshold (20% steps)")]
        HullDamage,

        [Description("Triggers when player was interdicted by player or npc")]
        Interdicted,

        [Description("Triggers when player has (attempted to) interdict another player or npc")]
        Interdiction,

        [Description("Triggers when this player has killed another player")]
        PvpKill,

        [Description("Triggers when shields are disabled in combat, or recharged")]
        ShieldState,

        [Description("Triggers when basic or detailed discovery scan of a star, planet or moon")]
        Scan,

        [Description("Triggers when whenever materials are collected")]
        MaterialCollected,

        [Description("Triggers if materials are discarded")]
        MaterialDiscarded,

        [Description("Triggers when a new material is discovered")]
        MaterialDiscovered,

        [Description("Triggers when scanning  a navigation beacon, before the scan data for all the bodies in the system is written into the journal")]
        NavBeaconScan,

        [Description("Triggers when buying system data via the galaxy map")]
        BuyExplorationData,

        [Description("Triggers when selling exploration data in Cartographics")]
        SellExplorationData,

        [Description("Triggers when a screen snapshot is saved")]
        Screenshot,

        [Description("Triggers when buying trade data in the galaxy map")]
        BuyTradeData,

        [Description("Triggers when scooping cargo from space or planet surface")]
        CollectCargo,

        [Description("")]
        EjectCargo,

        [Description("Triggers when purchasing goods in the market")]
        MarketBuy,

        [Description("Triggers when selling goods in the market")]
        MarketSell,

        [Description("Triggers when mining fragments are converted unto a unit of cargo by refinery")]
        MiningRefined,

        [Description("Triggers when purchasing ammunition")]
        BuyAmmo,

        [Description("Triggers when purchasing drones")]
        BuyDrones,

        [Description("Triggers when checking the status of a community goal")]
        CommunityGoal,

        [Description("Triggers when opting out of a community goal")]
        CommunityGoalDiscard,

        [Description("Triggers when signing up to a community goal")]
        CommunityGoalJoin,

        [Description("Triggers when receiving a reward for a community goal")]
        CommunityGoalReward,

        [Description("Triggers when changing the task assignment of a member of crew")]
        CrewAssign,

        [Description("Triggers when dismissing a member of crew")]
        CrewFire,

        [Description("Triggers when engaging a new member of crew")]
        CrewHire,

        [Description("Triggers when applying an engineer’s upgrade to a module")]
        EngineerApply,

        [Description("Triggers when offering items cash or bounties to an Engineer to gain access")]
        EngineerContribution,

        [Description("Triggers when requesting an engineer upgrade")]
        EngineerCraft,

        [Description("Triggers when a player increases their access to an engineer")]
        EngineerProgress,

        [Description("Triggers when requesting a module is transferred from storage at another station")]
        FetchRemoteModule,

        [Description("Triggers when putting multiple modules into storage")]
        MassModuleStore,

        [Description("Triggers when a mission has been abandoned")]
        MissionAbandoned,

        [Description("Triggers when starting a mission")]
        MissionAccepted,

        [Description("Triggers when a mission is completed")]
        MissionCompleted,

        [Description("Triggers when a mission has failed")]
        MissionFailed,

        [Description("Triggers when a mission is updated with a new destination")]
        MissionRedirected,

        [Description("Triggers when buying a module in outfitting")]
        ModuleBuy,

        [Description("Triggers when fetching a previously stored module")]
        ModuleRetrieve,

        [Description("Triggers when selling a module in outfitting")]
        ModuleSell,

        [Description("Triggers when selling a module in storage at another station")]
        ModuleSellRemote,

        [Description("Triggers when storing a module in Outfitting")]
        ModuleStore,

        [Description("Triggers when moving a module to a different slot on the ship")]
        ModuleSwap,

        [Description("Triggers when paying fines")]
        PayFines,

        [Description("Triggers when paying legacy fines")]
        PayLegacyFines,

        [Description("Triggers when claiming payment for combat bounties and bonds")]
        RedeemVoucher,

        [Description("Triggers when refuelling (full tank)")]
        RefuelAll,

        [Description("Triggers when refuelling (10%)")]
        RefuelPartial,

        [Description("Triggers when repairing the ship")]
        Repair,

        [Description("Triggers when repairing everything")]
        RepairAll,

        [Description("Triggers when purchasing an SRV or Fighter")]
        RestockVehicle,

        [Description("Triggers when contributing materials to a \"research\" community goal")]
        ScientificResearch,

        [Description("Triggers when delivering items to a Search and Rescue contact")]
        SearchAndRescue,

        [Description("Triggers when selling unwanted drones back to the market")]
        SellDrones,

        [Description("Triggers when selling a stored ship to raise funds when on insurance/rebuy screen")]
        SellShipOnRebuy,

        [Description("Triggers when assigning a name to the ship in Starport Services")]
        SetUserShipName,

        [Description("Triggers when buying a new ship in the shipyard")]
        ShipyardBuy,

        [Description("Triggers when after a new ship has been purchased")]
        ShipyardNew,

        [Description("Triggers when selling a ship stored in the shipyard")]
        ShipyardSell,

        [Description("Triggers when requesting a ship at another station be transported to this station")]
        ShipyardTransfer,

        [Description("Triggers when switching to another ship already stored at this station")]
        ShipyardSwap,

        [Description("Triggers when collecting powerplay commodities for delivery")]
        PowerplayCollect,

        [Description("Triggers when a player defects from one power to another")]
        PowerplayDefect,

        [Description("Triggers when delivering powerplay commodities")]
        PowerplayDeliver,

        [Description("Triggers when paying to fast-track allocation of commodities")]
        PowerplayFastTrack,

        [Description("Triggers when joining up with a power")]
        PowerplayJoin,

        [Description("Triggers when leaving a power")]
        PowerplayLeave,

        [Description("Triggers when receiving salary payment from a power")]
        PowerplaySalary,

        [Description("Triggers when voting for a system expansion")]
        PowerplayVote,

        [Description("Triggers when receiving payment for powerplay combat")]
        PowerplayVoucher,

        [Description("Triggers when repairing modules using the Auto Field Maintenance Unit (AFMU)")]
        AfmuRepairs,

        [Description("Triggers when approaching a planetary settlement")]
        ApproachSettlement,

        [Description("Triggers when in a crew on someone else's ship, player switched crew role")]
        ChangeCrewRole,

        [Description("Triggers when cockpit canopy is breached")]
        CockpitBreached,

        [Description("Triggers when a crime is recorded against the player")]
        CommitCrime,

        [Description("Triggers if the journal file grows to 500k lines, we write this event, close the file, and start a new one")]
        Continued,

        [Description("Triggers when in multicrew, in Helm player's log, when a crew member launches a fighter")]
        CrewLaunchFighter,

        [Description("Triggers when another player joins your ship's crew")]
        CrewMemberJoins,

        [Description("Triggers when another player leaves your ship's crew")]
        CrewMemberQuits,

        [Description("Triggers when in Multicrew, Helm's log, when another crew player changes role")]
        CrewMemberRoleChange,

        [Description("Triggers when scanning a data link")]
        DatalinkScan,

        [Description("Triggers when scanning a datalink generates a reward")]
        DatalinkVoucher,

        [Description("Triggers when scanning some types of data links")]
        DataScanned,

        [Description("Triggers when docking a fighter back with the mothership")]
        DockFighter,

        [Description("Triggers when docking an SRV with the ship")]
        DockSrv,

        [Description("Triggers when the captain in multicrew disbands the crew")]
        EndCrewSession,

        [Description("Triggers when scooping fuel from a star")]
        FuelScoop,

        [Description("Triggers when receiving information about a change in a friend's status")]
        Friends,

        [Description("Triggers when enough material has been collected from a solar jet code (at a white dwarf or neutron star) for a jump boost")]
        JetConeBoost,

        [Description("Triggers when passing through the jet code from a white dwarf or neutron star has caused damage to a ship module")]
        JetConeDamage,

        [Description("Triggers when you join another player ship's crew")]
        JoinACrew,

        [Description("Triggers when you force another player to leave your ship's crew")]
        KickCrewMember,

        [Description("Triggers when launching a fighter")]
        LaunchFighter,

        [Description("Triggers when deploying the SRV from a ship onto planet surface")]
        LaunchSrv,

        [Description("Triggers when the game music 'mood' changes")]
        Music,

        [Description("Triggers when the player’s rank increases")]
        Promotion,

        [Description("Triggers when you leave another player ship's crew")]
        QuitACrew,

        [Description("Triggers when the ‘reboot repair’ function is used")]
        RebootRepair,

        [Description("Triggers when a text message is received from another player or npc")]
        ReceiveText,

        [Description("Triggers when the player's ship has been repaired by a repair drone")]
        RepairDrone,

        [Description("Triggers when the player restarts after death")]
        Resurrect,

        [Description("Triggers when the player's ship has been scanned")]
        Scanned,

        [Description("Triggers when the ‘self destruct’ function is used")]
        SelfDestruct,

        [Description("Triggers when a text message is sent to another player")]
        SendText,

        [Description("Triggers when synthesis is used to repair or rearm")]
        Synthesis,

        [Description("Triggers when dropping from Supercruise at a USS")]
        UssDrop,

        [Description("Triggers when switching control between the main ship and a fighter")]
        VehicleSwitch,

        [Description("Triggers when another player has joined the wing")]
        WingAdd,

        [Description("Triggers when the player is invited to a wing")]
        WingInvite,

        [Description("Triggers when this player has joined a wing")]
        WingJoin,

        [Description("Triggers when this player has left a wing")]
        WingLeave,
    }
}
