using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetupController : MonoBehaviour {

    private GameObject gc;

    private AudioSource myaudio;
    public AudioClip submitSound;
    public AudioClip cancelSound;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("GameController");
        myaudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    #region "Player Name Changed"

    public void player1_NameChanged()
    {
        myaudio.PlayOneShot(submitSound);
        InputField playerName = (InputField)transform.FindChild("Players/Player1/Name").GetComponent<InputField>();
        if (playerName.text != "")
        {
            gc.GetComponent<GameController>().Players[0].name = playerName.text;
        }
        else
        {
            gc.GetComponent<GameController>().Players[0].name = "Player 1";
        }
    }

    public void player2_NameChanged()
    {
        myaudio.PlayOneShot(submitSound);
        InputField playerName = (InputField)transform.FindChild("Players/Player2/Name").GetComponent<InputField>();
        if (playerName.text != "")
        {
            gc.GetComponent<GameController>().Players[1].name = playerName.text;
        }
        else
        {
            gc.GetComponent<GameController>().Players[1].name = "Player 2";
        }
    }

    public void player3_NameChanged()
    {
        myaudio.PlayOneShot(submitSound);
        InputField playerName = (InputField)transform.FindChild("Players/Player3/Name").GetComponent<InputField>();
        if (playerName.text != "")
        {
            gc.GetComponent<GameController>().Players[2].name = playerName.text;
        }
        else
        {
            gc.GetComponent<GameController>().Players[2].name = "Player 3";
        }
    }

    public void player4_NameChanged()
    {
        myaudio.PlayOneShot(submitSound);
        InputField playerName = (InputField)transform.FindChild("Players/Player4/Name").GetComponent<InputField>();
        if (playerName.text != "")
        {
            gc.GetComponent<GameController>().Players[3].name = playerName.text;
        }
        else
        {
            gc.GetComponent<GameController>().Players[3].name = "Player 4";
        }
    }

    public void player5_NameChanged()
    {
        myaudio.PlayOneShot(submitSound);
        InputField playerName = (InputField)transform.FindChild("Players/Player5/Name").GetComponent<InputField>();
        if (playerName.text != "")
        {
            gc.GetComponent<GameController>().Players[4].name = playerName.text;
        }
        else
        {
            gc.GetComponent<GameController>().Players[4].name = "Player 5";
        }
    }

    public void player6_NameChanged()
    {
        myaudio.PlayOneShot(submitSound);
        InputField playerName = (InputField)transform.FindChild("Players/Player6/Name").GetComponent<InputField>();
        if (playerName.text != "")
        {
            gc.GetComponent<GameController>().Players[5].name = playerName.text;
        }
        else
        {
            gc.GetComponent<GameController>().Players[5].name = "Player 6";
        }
    }

    public void player7_NameChanged()
    {
        myaudio.PlayOneShot(submitSound);
        InputField playerName = (InputField)transform.FindChild("Players/Player7/Name").GetComponent<InputField>();
        if (playerName.text != "")
        {
            gc.GetComponent<GameController>().Players[6].name = playerName.text;
        }
        else
        {
            gc.GetComponent<GameController>().Players[6].name = "Player 7";
        }
    }

    public void player8_NameChanged()
    {
        myaudio.PlayOneShot(submitSound);
        InputField playerName = (InputField)transform.FindChild("Players/Player8/Name").GetComponent<InputField>();
        if (playerName.text != "")
        {
            gc.GetComponent<GameController>().Players[7].name = playerName.text;
        }
        else
        {
            gc.GetComponent<GameController>().Players[7].name = "Player 8";
        }
    }

    #endregion

    public void addPlayer()
    {
        myaudio.PlayOneShot(submitSound);

        int i = gc.GetComponent<GameController>().Players.Count + 1;
        if (i == 3)
        {
            Player p = new Player("Player " + i.ToString(), Player.playerType.Human, Color.green);
            gc.GetComponent<GameController>().Players.Add(p);

            Button addPlayerButton = (Button)transform.FindChild("Players/RemovePlayerButton").GetComponent<Button>();
            addPlayerButton.interactable = true;

            GameObject player3Panel = transform.FindChild("Players/Player3").gameObject;
            player3Panel.SetActive(true);
        }
        else if (i == 4)
        {
            Player p = new Player("Player " + i.ToString(), Player.playerType.Human, Color.yellow);
            gc.GetComponent<GameController>().Players.Add(p);
            GameObject player4Panel = transform.FindChild("Players/Player4").gameObject;
            player4Panel.SetActive(true);
        }
        else if (i == 5)
        {
            Player p = new Player("Player " + i.ToString(), Player.playerType.Human, Color.grey);
            gc.GetComponent<GameController>().Players.Add(p);
            GameObject player5Panel = transform.FindChild("Players/Player5").gameObject;
            player5Panel.SetActive(true);
        }
        else if (i == 6)
        {
            Player p = new Player("Player " + i.ToString(), Player.playerType.Human, Color.cyan);
            gc.GetComponent<GameController>().Players.Add(p);
            GameObject player6Panel = transform.FindChild("Players/Player6").gameObject;
            player6Panel.SetActive(true);
        }
        else if (i == 7)
        {
            Player p = new Player("Player " + i.ToString(), Player.playerType.Human, Color.magenta);
            gc.GetComponent<GameController>().Players.Add(p);
            GameObject player7Panel = transform.FindChild("Players/Player7").gameObject;
            player7Panel.SetActive(true);
        }
        else if (i == 8)
        {
            Player p = new Player("Player " + i.ToString(), Player.playerType.Human, Color.grey);
            gc.GetComponent<GameController>().Players.Add(p);
            GameObject player8Panel = transform.FindChild("Players/Player8").gameObject;
            player8Panel.SetActive(true);
        }

        if (i == 8)
        {
            Button addPlayerButton = (Button)transform.FindChild("Players/AddPlayerButton").GetComponent<Button>();
            addPlayerButton.interactable = false;
        }
    }

    public void removePlayer()
    {
        myaudio.PlayOneShot(submitSound);

        gc.GetComponent<GameController>().Players.RemoveAt(gc.GetComponent<GameController>().Players.Count - 1);

        int i = gc.GetComponent<GameController>().Players.Count + 1;
        if (i == 3)
        {
            GameObject player3Panel = transform.FindChild("Players/Player3").gameObject;
            player3Panel.SetActive(false);
        }
        else if (i == 4)
        {
            GameObject player4Panel = transform.FindChild("Players/Player4").gameObject;
            player4Panel.SetActive(false);
        }
        else if (i == 5)
        {
            GameObject player5Panel = transform.FindChild("Players/Player5").gameObject;
            player5Panel.SetActive(false);
        }
        else if (i == 6)
        {
            GameObject player6Panel = transform.FindChild("Players/Player6").gameObject;
            player6Panel.SetActive(false);
        }
        else if (i == 7)
        {
            GameObject player7Panel = transform.FindChild("Players/Player7").gameObject;
            player7Panel.SetActive(false);
        }
        else if (i == 8)
        {
            GameObject player8Panel = transform.FindChild("Players/Player8").gameObject;
            player8Panel.SetActive(false);

            Button addPlayerButton = (Button)transform.FindChild("Players/AddPlayerButton").GetComponent<Button>();
            addPlayerButton.interactable = true;
        }

        if (i == 3)
        {
            Button removePlayerButton = (Button)transform.FindChild("Players/RemovePlayerButton").GetComponent<Button>();
            removePlayerButton.interactable = false;
        }
    }

    public void changeStartMode()
    {
        Dropdown startModeDropDown = (Dropdown)transform.FindChild("GameMode/StartModePanel/StartMode").GetComponent<Dropdown>();
        Text startModeText = (Text)transform.FindChild("GameMode/StartModePanel/Text").GetComponent<Text>();
        if (startModeDropDown.value == 0)
        {
            gc.GetComponent<GameController>().selectedStartMode = GameController.StartMode.LandRun;
            startModeText.text = "Players take turns picking territories until there are none left.";
        }
        else if (startModeDropDown.value == 1)
        {
            gc.GetComponent<GameController>().selectedStartMode = GameController.StartMode.Expansion;
            startModeText.text = "Players pick one territory apiece to start with.";
        }
        else if (startModeDropDown.value == 2)
        {
            gc.GetComponent<GameController>().selectedStartMode = GameController.StartMode.Random;
            startModeText.text = "Pick territories at random";
        }
    }

    public void changeWinMode()
    {
        Debug.Log("Test!");
    }

    public void startGame()
    {
        myaudio.PlayOneShot(submitSound);
        SceneManager.LoadScene("World");
    }
}