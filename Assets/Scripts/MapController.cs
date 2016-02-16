using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class MapController : MonoBehaviour {

    private GameObject gc;
    private GameObject es;
    private UnityEngine.EventSystems.EventSystem eso;

    private AudioSource myaudio;
    public AudioClip submitSound;
    public AudioClip cancelSound;

    public AudioClip rollSound;
    public AudioClip winRollSound;
    public AudioClip winBattleSound;

    public List<State> States = new List<State>();

    public int statesLeftToPick = 12;

    public GameObject fromState = null;
    public GameObject toState = null;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("GameController");
        es = GameObject.Find("EventSystem");
        eso = es.GetComponent<UnityEngine.EventSystems.EventSystem>();
        myaudio = GetComponent<AudioSource>();

        if (gc.GetComponent<GameController>().selectedStartMode == GameController.StartMode.Expansion)
        {
            statesLeftToPick = gc.GetComponent<GameController>().Players.Count;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void buttonClick()
    {
        if (gc.GetComponent<GameController>().isPickingStates)
        {
            GameObject statebutton = GameObject.Find("Canvas/States/Buttons/" + eso.currentSelectedGameObject.name);
            if (statebutton.GetComponent<Image>().color == Color.white)
            {
                myaudio.PlayOneShot(submitSound);
                GameObject stateimage = GameObject.Find("Canvas/States/Images/" + eso.currentSelectedGameObject.name);
                stateimage.GetComponent<Image>().color = gc.GetComponent<GameController>().activePlayer.color;
                eso.currentSelectedGameObject.GetComponent<Image>().color = gc.GetComponent<GameController>().activePlayer.color;
                GameObject statetext = GameObject.Find("Canvas/States/Buttons/" + eso.currentSelectedGameObject.name + "/Text");
                statetext.GetComponent<Text>().text = "1";
                eso.SetSelectedGameObject(null);

                if (gc.GetComponent<GameController>().activePlayerIndex == gc.GetComponent<GameController>().Players.Count -1)
                {
                    gc.GetComponent<GameController>().activePlayerIndex = 0;
                    gc.GetComponent<GameController>().activePlayer = gc.GetComponent<GameController>().Players[0];
                }
                else
                {
                    gc.GetComponent<GameController>().activePlayerIndex++;
                    gc.GetComponent<GameController>().activePlayer = gc.GetComponent<GameController>().Players[gc.GetComponent<GameController>().activePlayerIndex];
                }

                statesLeftToPick--;

                if (statesLeftToPick == 0)
                {
                    gc.GetComponent<GameController>().isPickingStates = false;
                    gc.GetComponent<GameController>().isDeployingTroops = true;
                }
            }
        }
        else if (gc.GetComponent<GameController>().isDeployingTroops)
        {
            if (eso.currentSelectedGameObject.GetComponent<Image>().color == gc.GetComponent<GameController>().activePlayer.color)
            {
                myaudio.PlayOneShot(submitSound);
                GameObject statetext = GameObject.Find("Canvas/States/Buttons/" + eso.currentSelectedGameObject.name + "/Text");
                int val = Convert.ToInt32(statetext.GetComponent<Text>().text);
                val++;
                statetext.GetComponent<Text>().text = val.ToString();
                gc.GetComponent<GameController>().activePlayer.reinforcements--;

                if (gc.GetComponent<GameController>().activePlayerIndex == gc.GetComponent<GameController>().Players.Count - 1)
                {
                    if (gc.GetComponent<GameController>().activePlayer.reinforcements == 0)
                    {
                        gc.GetComponent<GameController>().isDeployingTroops = false;
                        foreach (Player player in gc.GetComponent<GameController>().Players)
                        {
                            player.reinforcements = 5;
                        }
                    }
                    gc.GetComponent<GameController>().activePlayerIndex = 0;
                    gc.GetComponent<GameController>().activePlayer = gc.GetComponent<GameController>().Players[0];
                }
                else
                {
                    gc.GetComponent<GameController>().activePlayerIndex++;
                    gc.GetComponent<GameController>().activePlayer = gc.GetComponent<GameController>().Players[gc.GetComponent<GameController>().activePlayerIndex];
                }
            }
        }
        else
        {
            if (gc.GetComponent<GameController>().currentStage == 0)
            {
                if (eso.currentSelectedGameObject.GetComponent<Image>().color == gc.GetComponent<GameController>().activePlayer.color)
                {
                    myaudio.PlayOneShot(submitSound);
                    GameObject statetext = GameObject.Find("Canvas/States/Buttons/" + eso.currentSelectedGameObject.name + "/Text");
                    int val = Convert.ToInt32(statetext.GetComponent<Text>().text);
                    val++;
                    statetext.GetComponent<Text>().text = val.ToString();
                    gc.GetComponent<GameController>().activePlayer.reinforcements--;

                    if (gc.GetComponent<GameController>().activePlayer.reinforcements == 0)
                    {
                        gc.GetComponent<GameController>().currentStage++;
                        eso.SetSelectedGameObject(null);
                    }
                }
            }
            else if (gc.GetComponent<GameController>().currentStage == 1)
            {
                //TODO:Setup Attack Stage
                if (fromState == null)
                {
                    if (eso.currentSelectedGameObject.GetComponent<Image>().color == gc.GetComponent<GameController>().activePlayer.color)
                    {
                        GameObject statetext = GameObject.Find("Canvas/States/Buttons/" + eso.currentSelectedGameObject.name + "/Text");
                        int val = Convert.ToInt32(statetext.GetComponent<Text>().text);
                        if (val > 1)
                        {
                            fromState = GameObject.Find("Canvas/States/Buttons/" + eso.currentSelectedGameObject.name);
                        }
                    }
                }
                else
                {
                    if (eso.currentSelectedGameObject.GetComponent<Image>().color != gc.GetComponent<GameController>().activePlayer.color)
                    {
                        toState = GameObject.Find("Canvas/States/Buttons/" + eso.currentSelectedGameObject.name);
                    }
                }
                if (fromState != null && toState != null)
                {
                    GameObject rollPanel = GameObject.Find("Canvas/RollPanel");
                    GameObject p = rollPanel.transform.FindChild("Panel").gameObject;
                    p.SetActive(true);
                    GameObject tx = GameObject.Find("Canvas/RollPanel/Panel/AttackInfo");
                    tx.GetComponent<Text>().text = fromState.name + " > " + toState.name;
                }
                else
                {
                    GameObject rollPanel = GameObject.Find("Canvas/RollPanel");
                    GameObject p = rollPanel.transform.FindChild("Panel").gameObject;
                    p.SetActive(false);
                }
            }
            else
            {
                //clearButton_Click();
                //TODO: ^ Fix This
                if (fromState == null)
                {
                    if (eso.currentSelectedGameObject.GetComponent<Image>().color == gc.GetComponent<GameController>().activePlayer.color)
                    {
                        GameObject statetext = GameObject.Find("Canvas/States/Buttons/" + eso.currentSelectedGameObject.name + "/Text");
                        int val = Convert.ToInt32(statetext.GetComponent<Text>().text);
                        if (val > 1)
                        {
                            fromState = GameObject.Find("Canvas/States/Buttons/" + eso.currentSelectedGameObject.name);
                        }
                    }
                }
                else
                {
                    if (eso.currentSelectedGameObject.GetComponent<Image>().color == gc.GetComponent<GameController>().activePlayer.color)
                    {
                        toState = GameObject.Find("Canvas/States/Buttons/" + eso.currentSelectedGameObject.name);
                    }
                }
                if (fromState != null && toState != null)
                {
                    GameObject tacticalPanel = GameObject.Find("Canvas/TacticalPanel");
                    GameObject p = tacticalPanel.transform.FindChild("Panel").gameObject;
                    p.SetActive(true);
                    GameObject tx = GameObject.Find("Canvas/TacticalPanel/Panel/AttackInfo");
                    tx.GetComponent<Text>().text = fromState.name + " > " + toState.name;
                }
                else
                {
                    GameObject tacticalPanel = GameObject.Find("Canvas/TacticalPanel");
                    GameObject p = tacticalPanel.transform.FindChild("Panel").gameObject;
                    p.SetActive(false);
                }
            }
        }
    }

    public void clearButton_Click()
    {
        fromState = null;
        toState = null;
        GameObject rollPenal = GameObject.Find("Canvas/RollPanel");
        GameObject p = rollPenal.transform.FindChild("Panel").gameObject;
        p.SetActive(false);
    }

    public void rollButton_Click()
    {

        myaudio.PlayOneShot(rollSound);

        int attack = UnityEngine.Random.Range(1, 6);
        int defend = UnityEngine.Random.Range(1, 6);

        GameObject attacker = GameObject.Find("Canvas/RollPanel/Panel/NumbersPanel/Attacker");
        attacker.GetComponent<Text>().text = attack.ToString();
        GameObject defender = GameObject.Find("Canvas/RollPanel/Panel/NumbersPanel/Defender");
        defender.GetComponent<Text>().text = defend.ToString();

        if (attack != defend)
        {
            if (attack > defend)
            {
                myaudio.PlayOneShot(winRollSound);
                GameObject t = toState.transform.FindChild("Text").gameObject;
                int newAmount = Convert.ToInt32(t.GetComponent<Text>().text) - 1;
                t.GetComponent<Text>().text = newAmount.ToString();

                if (Convert.ToInt32(t.GetComponent<Text>().text) == 0)
                {
                    myaudio.PlayOneShot(winBattleSound);

                    GameObject stateimage = GameObject.Find("Canvas/States/Images/" + toState.name);
                    stateimage.GetComponent<Image>().color = gc.GetComponent<GameController>().activePlayer.color;
                    toState.GetComponent<Image>().color = gc.GetComponent<GameController>().activePlayer.color;
                    
                    t.GetComponent<Text>().text = "1";
                    GameObject t2 = fromState.transform.FindChild("Text").gameObject;
                    int leftAmount = Convert.ToInt32(t2.GetComponent<Text>().text) - 1;
                    t2.GetComponent<Text>().text = leftAmount.ToString();
                    clearButton_Click();
                }
            }
            else
            {
                GameObject t = fromState.transform.FindChild("Text").gameObject;
                int newAmount = Convert.ToInt32(t.GetComponent<Text>().text) - 1;
                t.GetComponent<Text>().text = newAmount.ToString();

                if (Convert.ToInt32(t.GetComponent<Text>().text) == 1)
                {
                    clearButton_Click();
                }
            }
        }
    }

    public void EndStage()
    {
        if (gc.GetComponent<GameController>().currentStage == 1)
        {
            clearButton_Click();
        }
        gc.GetComponent<GameController>().EndStage();
    }
}

public class State : IComparable<State>
{
    public string name;
    public int owener;
    public StateTypes type;

    public enum StateTypes
    {
        misc,
        gun,
        equippable,
        food,
        consumable,
        ammo
    }

    public State(string newName, StateTypes newType)
    {
        name = newName;
        type = newType;
    }

    //This method is required by the IComparable
    //interface. 
    public int CompareTo(State other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in type.
        return type - other.type;
    }
}