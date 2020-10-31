using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class PartyData
{
    static PlayerActor[] playerParty = new PlayerActor[4];
    static PlayerActor leader;
    static Sprite leaderSprite;
    static uint money;
    static List<GenericItem> inventory;

    public static PlayerActor[] PlayerParty { get => playerParty; set => playerParty = value; }
    public static PlayerActor Leader { get => leader; set => leader = value; }
    public static Sprite LeaderSprite { get => leader.GetComponent<Sprite>();}
    public static uint Money { get => money; set => money = value; }
    public static List<GenericItem> Inventory { get => inventory; set => inventory = value; }

    static GenericItem useItem(GenericItem item)
    {
        return null;
    }

}
