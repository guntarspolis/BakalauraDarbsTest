using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientLogic : NetworkBehaviour {

    private GameViewObjectLocator locator;
    public GameObject cardPrefab;

    void Start()
    {
        locator = GameObject.FindGameObjectWithTag("GameView").GetComponent<GameViewObjectLocator>();
    }


    [ClientRpc]
    public void RpcSendCardToPlayers(int a, string b, int c)
    {

        var card = (GameObject)Instantiate(cardPrefab);

        var loc = card.GetComponent<CardLocator>();
        Text t = loc.cardText.GetComponent<Text>();
        t.text = b;

        if (isLocalPlayer)
        {
            card.transform.SetParent(locator.OwnHand.transform);
            DraggableCard dC = card.GetComponent<DraggableCard>();
            dC.cardIsMine = true;
        }

        else
        {
            Text[] cardData = card.GetComponentsInChildren<Text>();

            foreach (var data in cardData)
            {
                data.text = "Unknown";
            }

            DraggableCard dC = card.GetComponent<DraggableCard>();
            dC.cardIsMine = false;

            card.transform.SetParent(locator.OpponentHand.transform);
        }
    }


    [ClientRpc]
    public void RpcPlayCardFromHandToField(int cardIndex, int boardIndex)
    {
        if (isLocalPlayer)
        {
            var card = locator.OwnHand.transform.GetChild(cardIndex);
            card.transform.SetParent(locator.OwnField.transform);
        }

        else
        {
            var card = locator.OpponentHand.transform.GetChild(cardIndex);
            card.transform.SetParent(locator.OpponentField.transform);
        }
    }
}
