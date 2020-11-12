using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

namespace BattleElements
{
    public static class PartyData
    {
        static PlayerActor[] playerParty = new PlayerActor[4];
        static PlayerActor[] playerFrontline = new PlayerActor[3];
        static PlayerActor[] playerBackline = new PlayerActor[3];
        static PlayerActor leader;
        static Sprite leaderSprite;
        static uint money;
        static List<GenericItem> inventory;

        public static PlayerActor[] PlayerParty { get => playerParty; set => playerParty = value; }
        public static PlayerActor Leader { get => leader; set => leader = value; }
        public static Sprite LeaderSprite { get => leaderSprite; }
        public static uint Money { get => money; set => money = value; }
        public static List<GenericItem> Inventory { get => inventory; }
        public static PlayerActor[] PlayerFrontline { get => playerFrontline; set => playerFrontline = value; }
        public static PlayerActor[] PlayerBackline { get => playerBackline; set => playerBackline = value; }

        static GenericItem useItem(GenericItem item)
        {
            return null;
        }

    }
}