using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDatabase : MonoBehaviour
{
    public List<Sprite> cardHolders = new List<Sprite>();

    public static List<BaseCard> deckCursedlist = new List<BaseCard>();   //Global information to abstract from
    public static List<BaseCard> deckInfernallist = new List<BaseCard>();   //Global information to abstract from
    public static List<BaseCard> deckDivinelist = new List<BaseCard>();   //Global information to abstract from

    //Card: ID, Name, Cost, Sacrifice, Attack, Defense, Description, Cardtype, FactionType
    private void Awake()
    {
        CursedDeckData();
        InfernalDeckData();
        DivineDeckData();
    }

    private void CursedDeckData()
    {
        deckCursedlist.Add(new BaseCard(0, "None", 0, 0, 0, 0, "None", "None", "None", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/None")));
        deckCursedlist.Add(new BaseCard(1, "Croax", 1, 2, 1, 3, "This is a Human", "Creature", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/Croax")));
        deckCursedlist.Add(new BaseCard(2, "Deathknight", 1, 2, 1, 3, "This is a Human", "Timer", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/Deathknight")));
        deckCursedlist.Add(new BaseCard(3, "Flameskull", 1, 2, 1, 3, "This is a Human", "Timer", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/Flameskull")));
        deckCursedlist.Add(new BaseCard(4, "Brain Jar", 1, 2, 1, 3, "This is a Human", "Magic", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/BrainInJar")));
        deckCursedlist.Add(new BaseCard(5, "Banshee", 1, 2, 1, 3, "This is a Human", "Creature", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/Banshee")));
        deckCursedlist.Add(new BaseCard(6, "Clay Golem", 1, 2, 1, 3, "This is a Human", "Timer", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/ClayGolem")));
        deckCursedlist.Add(new BaseCard(7, "Ghost", 1, 2, 1, 3, "This is a Human", "Creature", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/Ghost")));
        deckCursedlist.Add(new BaseCard(8, "Ghoul", 1, 2, 1, 3, "This is a Human", "Timer", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/Ghoul")));
        deckCursedlist.Add(new BaseCard(9, "Harpy", 1, 2, 1, 3, "This is a Human", "Timer", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/Harpy")));
        deckCursedlist.Add(new BaseCard(10, "Raven", 1, 2, 1, 3, "This is a Human", "Magic", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/Raven")));
        deckCursedlist.Add(new BaseCard(11, "Reaper", 1, 2, 1, 3, "This is a Human", "Creature", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/Reaper")));
        deckCursedlist.Add(new BaseCard(12, "Skeleton", 1, 2, 1, 3, "This is a Human", "Timer", "Cursed", cardHolders[0], Resources.Load<Sprite>("Cursed_Images/Skeleton")));
    }

    private void InfernalDeckData()
    {
        deckInfernallist.Add(new BaseCard(0, "None", 0, 0, 0, 0, "None", "None", "None", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/None")));
        deckInfernallist.Add(new BaseCard(1, "Balor", 1, 2, 1, 3, "This is a Human", "Creature", "Infernal", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/Balor")));
        deckInfernallist.Add(new BaseCard(2, "Black D.", 1, 2, 1, 3, "This is a Human", "Timer", "Infernal", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/Blackdragon")));
        deckInfernallist.Add(new BaseCard(3, "Bonedevil", 1, 2, 1, 3, "This is a Human", "Timer", "Infernal", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/Bonedevil")));
        deckInfernallist.Add(new BaseCard(4, "Chasme", 1, 2, 1, 3, "This is a Human", "Magic", "Infernal", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/Chasme")));
        deckInfernallist.Add(new BaseCard(5, "Chimera", 1, 2, 1, 3, "This is a Human", "Creature", "Infernal", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/Chimera")));
        deckInfernallist.Add(new BaseCard(6, "Hellhound", 1, 2, 1, 3, "This is a Human", "Timer", "Infernal", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/Hellhound")));
        deckInfernallist.Add(new BaseCard(7, "HelmedHorror", 1, 2, 1, 3, "This is a Human", "Creature", "Infernal", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/HelmedHorror")));
        deckInfernallist.Add(new BaseCard(8, "Imp", 1, 2, 1, 3, "This is a Human", "Timer", "Infernal", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/Imp")));
        deckInfernallist.Add(new BaseCard(9, "Nalfeshnee", 1, 2, 1, 3, "This is a Human", "Timer", "Infernal", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/Nalfeshnee")));
        deckInfernallist.Add(new BaseCard(10, "Pitfiend", 1, 2, 1, 3, "This is a Human", "Magic", "Infernal", cardHolders[1], Resources.Load<Sprite>("Infernal_Images/Pitfiend")));
    }

    private void DivineDeckData()
    {
        deckDivinelist.Add(new BaseCard(0, "None", 0, 0, 0, 0, "None", "None", "None", cardHolders[2], Resources.Load<Sprite>("Divine_Images/None")));
        deckDivinelist.Add(new BaseCard(1, "Angelic", 3, 2, 2, 3, "This is a Human", "Creature", "Divine", cardHolders[2], Resources.Load<Sprite>("Divine_Images/Angelicwarrior")));
        deckDivinelist.Add(new BaseCard(2, "Azer", 1, 2, 1, 2, "This is a Human", "Timer", "Divine", cardHolders[2], Resources.Load<Sprite>("Divine_Images/Azer")));
        deckDivinelist.Add(new BaseCard(3, "Angel Health", 4, 2, 2, 5, "This is a Human", "Timer", "Divine", cardHolders[2], Resources.Load<Sprite>("Divine_Images/Angelofhealth")));
        deckDivinelist.Add(new BaseCard(4, "Deva", 2, 2, 2, 2, "This is a Human", "Creature", "Divine", cardHolders[2], Resources.Load<Sprite>("Divine_Images/Deva")));
        deckDivinelist.Add(new BaseCard(5, "Cleric", 1, 2, 1, 1, "This is a Human", "Creature", "Divine", cardHolders[2], Resources.Load<Sprite>("Divine_Images/Inspiringcleric")));
        deckDivinelist.Add(new BaseCard(6, "Planetar", 4, 2, 4, 4, "This is a Human", "Timer", "Divine", cardHolders[2], Resources.Load<Sprite>("Divine_Images/Planetar")));
        deckDivinelist.Add(new BaseCard(7, "Priest", 1, 3, 1, 1, "This is a Human", "Creature", "Divine", cardHolders[2], Resources.Load<Sprite>("Divine_Images/Priest")));
        deckDivinelist.Add(new BaseCard(8, "Silver D.", 5, 4, 4, 5, "This is a Human", "Timer", "Divine", cardHolders[2], Resources.Load<Sprite>("Divine_Images/SilverDragon")));
        deckDivinelist.Add(new BaseCard(9, "Unicorn", 1, 1, 1, 1, "This is a Human", "Timer", "Divine", cardHolders[2], Resources.Load<Sprite>("Divine_Images/Unicorn")));
        deckDivinelist.Add(new BaseCard(10, "Unicorn Rider", 2, 3, 2, 3, "This is a Human", "Creature", "Divine", cardHolders[2], Resources.Load<Sprite>("Divine_Images/UnicornRider")));
    }
}