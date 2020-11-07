using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyData : ScriptableObject
{
    [SerializeField] static PlayerActor[] playerParty = new PlayerActor[4];
    [SerializeField] static PlayerActor leader;
    [SerializeField] static Sprite leaderSprite;
    [SerializeField] static uint money;
    [SerializeField] static List<GenericItem> inventory;

    public static PlayerActor[] PlayerParty { get => playerParty; set => playerParty = value; }
    public static PlayerActor Leader { get => leader; set => leader = value; }
    public static Sprite LeaderSprite { get => leaderSprite;}
    public static uint Money { get => money; set => money = value; }
    public static List<GenericItem> Inventory { get => inventory; set => inventory = value; }

    static GenericItem useItem(GenericItem item)
    {
        return null;
    }
}
