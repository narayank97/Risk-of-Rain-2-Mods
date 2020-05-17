using BepInEx;

using RoR2;

namespace kdawg
{
    [BepInDependency("com.bepis.r2api")]
    //Change these
    [BepInPlugin("com.kdawgMod.kdawgFirst", "First Mod Kdawg", "1.0.0")]
    public class MyModName : BaseUnityPlugin
    {
        public void Awake()
        {
            Chat.AddMessage("Loaded my Mod!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            On.EntityStates.Huntress.ArrowRain.OnEnter += (orig, self) =>
            {
                //code we want to run
                Chat.AddMessage("You used Huntress's Arrow Rain!");
                //call orig function -> orig
                //on object -> self
                orig(self);
            };
        }
    }
}