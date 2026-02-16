using System.Collections.Generic;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    public string characterName;
    public int level;
    public int conScore;
    [Header("Input class and race in all lowercase")]
    public string characterClass;
    public string characterRace;
    public bool tough;
    public bool stout;
    public bool averaged;

    private int dice;
    private float hp = 0f;

    Dictionary<string, int> diceValues = new Dictionary<string, int>();
    Dictionary<int, int> conValues = new Dictionary<int, int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EstablishDictionaries();

        dice = diceValues[characterClass];

        if (averaged)
        {
            AveragedCalc();
            Debug.Log("HP (Averaged): " + hp);
        }
        else
        {
            RolledCalc();
            Debug.Log("HP (Rolled): " + hp);
        }
    }

    void AveragedCalc()
    {
        float expectedValue = (dice + 1) / 2f;

        for (int i = 0; i < level; i++)
        {
            hp += expectedValue;

            CheckStats();
        }
    }

    void RolledCalc()
    {
        for (int i = 0; i < level; i++)
        {
            hp += Random.Range(1, dice + 1);

            CheckStats();
        }
    }

    void CheckStats()
    {
        if (characterRace == "dwarf")
        {
            hp += 2f;
        }
        else if (characterRace == "orc" || characterRace == "goliath")
        {
            hp += 1f;
        }

        if (tough)
        {
            hp += 2f;
        }

        if (stout)
        {
            hp += 1f;
        }

        hp += conValues[conScore];
    }
    void EstablishDictionaries()
    {
        diceValues.Add("artificer", 8);
        diceValues.Add("barbarian", 12);
        diceValues.Add("bard", 8);
        diceValues.Add("cleric", 8);
        diceValues.Add("druid", 8);
        diceValues.Add("fighter", 10);
        diceValues.Add("monk", 8);
        diceValues.Add("ranger", 10);
        diceValues.Add("rogue", 8);
        diceValues.Add("paladin", 10);
        diceValues.Add("sorcerer", 6);
        diceValues.Add("wizard", 6);
        diceValues.Add("warlock", 8);

        conValues.Add(1, -5);
        conValues.Add(2, -4);
        conValues.Add(3, -4);
        conValues.Add(4, -3);
        conValues.Add(5, -3);
        conValues.Add(6, -2);
        conValues.Add(7, -2);
        conValues.Add(8, -1);
        conValues.Add(9, -1);
        conValues.Add(10, 0);
        conValues.Add(11, 0);
        conValues.Add(12, 1);
        conValues.Add(13, 1);
        conValues.Add(14, 2);
        conValues.Add(15, 2);
        conValues.Add(16, 3);
        conValues.Add(17, 3);
        conValues.Add(18, 4);
        conValues.Add(19, 4);
        conValues.Add(20, 5);
        conValues.Add(21, 5);
        conValues.Add(22, 6);
        conValues.Add(23, 6);
        conValues.Add(24, 7);
        conValues.Add(25, 7);
        conValues.Add(26, 8);
        conValues.Add(27, 8);
        conValues.Add(28, 9);
        conValues.Add(29, 9);
        conValues.Add(30, 10);
    }
}
