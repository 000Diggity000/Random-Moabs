using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Harmony;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Stats;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[assembly: MelonInfo(typeof(RandomMoabs.Main), "Random Moabs", "1.0.0", "Diggity")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace RandomMoabs
{
    public class Main : BloonsTD6Mod
    {



        public override void OnApplicationStart()
        {


            base.OnApplicationStart();
            MelonLogger.Msg("Random Moabs Loaded!");


        }



        [HarmonyPatch(typeof(TitleScreen), "Start")]
        public class Rounds
        {
            [HarmonyPostfix]
            public static void Postfix()
            {




                foreach (RoundSetModel roundModel in Game.instance.model.roundSets)
                {
                    string[] moabs = new string[] { "Moab", "Bfb", "Zomg", "Bad", "BadFortified", "Ddt" };
                    System.Random random = new System.Random();
                    int useMoab = random.Next(moabs.Length);
                    string pickMoab = moabs[useMoab];
                    roundModel.rounds[40 - 1].RemoveBloonGroup("Moab");
                    // Spawns the boss on the boss round
                    roundModel.rounds[40 - 1].AddBloonGroup(pickMoab, 1, 0, 60);
                    roundModel.rounds[40 - 1].groups[0].count = 1;

                    string[] moabs1 = new string[] { "Moab", "MoabFortified ", "Bfb", "BfbFortified", "Zomg", "ZomgFortified", "Ddt", "DdtFortified", "Bad", "BadFortified"};
                    int useMoab1 = random.Next(moabs1.Length);
                    string pickMoab1 = moabs[useMoab1];
                    roundModel.rounds[60 - 1].RemoveBloonGroup("Bfb");
                    // Spawns the boss on the boss round
                    roundModel.rounds[60 - 1].AddBloonGroup(pickMoab1, 1, 0, 60);

                    string[] moabs2 = new string[] { "Moab", "Bfb", "Zomg", "Bad", "BadFortified", "Ddt" };
                    int useMoab2 = random.Next(moabs2.Length);
                    string pickMoab2 = moabs[useMoab2];
                    roundModel.rounds[80 - 1].RemoveBloonGroup("Zomg");
                    // Spawns the boss on the boss round
                    roundModel.rounds[80 - 1].AddBloonGroup(pickMoab2, 1, 0, 60);

                    string[] moabs3 = new string[] { "Moab", "Bfb", "Zomg", "Bad", "BadFortified", "Ddt" };
                    int useMoab3 = random.Next(moabs3.Length);
                    string pickMoab3 = moabs[useMoab3];
                    roundModel.rounds[100 - 1].RemoveBloonGroup("Bad");
                    // Spawns the boss on the boss round
                    roundModel.rounds[100 - 1].AddBloonGroup(pickMoab3, 1, 0, 60);

                }


            }



        }


    }
}
