using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    private GameObject gc;

    private Text currentPlayerText;
    private GameObject currentPlayerPanel;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        if (gc.GetComponent<GameController>().activePlayer != null)
        {
            currentPlayerPanel = GameObject.Find("Canvas/CurrentPlayerPanel");
            currentPlayerPanel.GetComponent<Image>().color = gc.GetComponent<GameController>().activePlayer.color;

            currentPlayerText = (Text)GameObject.Find("Canvas/CurrentPlayerPanel/Text").GetComponent<Text>();
            currentPlayerText.text = gc.GetComponent<GameController>().activePlayer.name;
            if (gc.GetComponent<GameController>().activePlayer.color == Color.blue)
            {
                currentPlayerText.color = Color.white;
            }
            else
            {
                currentPlayerText.color = Color.black;
            }

            if (gc.GetComponent<GameController>().isPickingStates)
            {
                currentPlayerText = (Text)GameObject.Find("Canvas/CurrentStagePanel/Text").GetComponent<Text>();
                currentPlayerText.text = "Pick";
            }
            else if (gc.GetComponent<GameController>().isDeployingTroops)
            {
                currentPlayerText = (Text)GameObject.Find("Canvas/CurrentStagePanel/Text").GetComponent<Text>();
                currentPlayerText.text = "Troop Deployment (" + gc.GetComponent<GameController>().activePlayer.reinforcements.ToString() + ")";
            }
            else
            {
                Button endTurnButton = (Button)GameObject.Find("Canvas/StageButton").GetComponent<Button>();
                endTurnButton.interactable = true;

                Text endTurnButton_Text = (Text)GameObject.Find("Canvas/StageButton/Text").GetComponent<Text>();
                if (gc.GetComponent<GameController>().currentStage == 0)
                {
                    currentPlayerText = (Text)GameObject.Find("Canvas/CurrentStagePanel/Text").GetComponent<Text>();
                    currentPlayerText.text = "Reinforcements (" + gc.GetComponent<GameController>().activePlayer.reinforcements.ToString() + ")";

                    endTurnButton_Text.text = "Attack";
                }
                else if (gc.GetComponent<GameController>().currentStage == 1)
                {
                    currentPlayerText = (Text)GameObject.Find("Canvas/CurrentStagePanel/Text").GetComponent<Text>();
                    currentPlayerText.text = "Attack";

                    endTurnButton_Text.text = "Tactical";
                }
                else {
                    currentPlayerText = (Text)GameObject.Find("Canvas/CurrentStagePanel/Text").GetComponent<Text>();
                    currentPlayerText.text = "Tactical";

                    endTurnButton_Text.text = "End Turn";
                }
            }
        }
    }
}