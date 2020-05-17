using BepInEx;
using R2API.Utils;
using RoR2;
using UnityEngine;
using RoR2.Stats;
using System.Text;
using RewiredConsts;

namespace kdawg
{
    [BepInDependency("com.bepis.r2api")]
    //Change these
    [BepInPlugin("com.kdawg.damageIndicator", "Damage Indicator", "1.0.0")]
    public class MyModName : BaseUnityPlugin
    {
        public CharacterBody CachedCharacterBody { get; set; }
        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();


        private void Update()
        {
            LocalUser localUser = LocalUserManager.GetFirstLocalUser();
            CachedCharacterBody = localUser.cachedBody;
            
        }


        public void Awake()
        {
            On.RoR2.CharacterBody.OnSprintStart += (orig, self) =>
            {
                  RunReport runReport = RunReport.Generate(Run.instance,GameResultType.Unknown);
                  RunReport.PlayerInfo playerInfo = null;

                  if (runReport.GetPlayerInfo(0).isLocalPlayer)
                  {
                      playerInfo = runReport.GetPlayerInfo(0);
                      Chat.AddMessage("Got player indo !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                  }
                  if (playerInfo != null)
                  {
                      StatDef statDef = (StatDef)typeof(StatDef).GetField("totalDamageDealt").GetValue(null);
                      sb2.AppendLine($"Damage dealt : {playerInfo.statSheet.GetStatDisplayValue(statDef)}");

                  }

                  Chat.AddMessage("Yo!");
                  Chat.AddMessage("Damage Done : " + sb2.ToString());
                orig(self);



            };
        }
    }
}