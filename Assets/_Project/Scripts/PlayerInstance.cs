using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerInstance : NetworkBehaviour {

    public GameObject cardPrefab;

    public void Start()
    {

    }

    /// <summary>
    /// Player asks for card from server
    /// </summary>
    public void DrawCardButton()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        CmdDrawCard();
    }

    /// <summary>
    /// Command draws a card in server
    /// </summary>
    [Command]
    public void CmdDrawCard()
    {
        GameObject cardObject = (GameObject)Instantiate(cardPrefab);

        //TODO: Identify client and save card
 
        NetworkServer.Spawn(cardObject);
        RpcSendCardToPlayers(cardObject);

    }

    // Sends card data to clients
    [ClientRpc]
    public void RpcSendCardToPlayers(GameObject cardObject)
    {

        if (isLocalPlayer)
        {
            cardObject.transform.SetParent(GameObject.FindGameObjectWithTag("OwnHand").transform);
        }

        else
        {
            Text[] cardData = cardObject.GetComponentsInChildren<Text>();
            foreach (var data in cardData)
            {
                data.text = "Unknown";
            }
            cardObject.transform.SetParent(GameObject.FindGameObjectWithTag("OpponentHand").transform);
        }
    }

}
