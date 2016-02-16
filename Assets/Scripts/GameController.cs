using UnityEngine;
using System;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public static GameController singleton;

    public Player activePlayer = null;
    public int activePlayerIndex = 0;
    public List<Player> Players = new List<Player>();

    public int selectedMap = 0;

    public StartMode selectedStartMode = StartMode.LandRun;
    public WinMode selectedWinMode = WinMode.DeathMatch;

    public Boolean isPickingStates = true;

    public Boolean isDeployingTroops = false;

    public int currentStage = 0;

    public int currentTurn = 1;

    public enum StartMode { LandRun, Expansion, Random }
    public enum ReinforcementMode { Fixed, BalanceOfPower, Random }
    public enum AdvantageMode { Neutral, Offence, Defence }
    public enum WinMode { DeathMatch, TeamDeathMatch, Capital, }

    void Awake()
    {
        if (singleton == null)
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        Players.Add(new Player("Player 1", Player.playerType.Human, Color.red));
        Players.Add(new Player("Player 2", Player.playerType.Human, Color.blue));
        //Players.Add(new Player("Player 3", Player.playerType.Human, Color.green));
        //Players.Add(new Player("Player 4", Player.playerType.Human, Color.yellow));

        activePlayer = Players[0];
        //if (Display.displays.Length > 1)
        //    Display.displays[1].Activate();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EndStage()
    {
        if (currentStage == 0 || currentStage == 1)
        {
            currentStage++;
        }
        else if (currentStage == 2)
        {
            currentStage = 0;
            EndTurn();
        }
    }

    void EndTurn()
    {
        if (activePlayerIndex == Players.Count - 1)
        {
            activePlayerIndex = 0;
            activePlayer = Players[0];
            foreach (Player player in Players)
            {
                player.reinforcements = 5;
            }

            currentTurn++;
        }
        else
        {
            activePlayerIndex++;
            activePlayer = Players[activePlayerIndex];
        }
    }
}

public class Player : IComparable<Player>
{
    public string name;
    public Color color;
    public playerType type;

    public int reinforcements = 3;

    public enum playerType { Human, Computer }

    public Player(string newName, playerType newType, Color newColor)
    {
        name = newName;
        type = newType;
        color = newColor;
    }

    //This method is required by the IComparable
    //interface. 
    public int CompareTo(Player other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in type.
        return type - other.type;
    }
}