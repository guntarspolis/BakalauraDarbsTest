using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading;
using System.Collections.Generic;

public class DrawCardButton : NetworkBehaviour {

    public GameObject cardPrefab;

    public void DrawNewCard()
    {
        GameObject[] bothPlayerInstaces = GameObject.FindGameObjectsWithTag("Player");
        foreach (var singleInstance in bothPlayerInstaces)
        {
            ServerLogic sOperator = singleInstance.GetComponent<ServerLogic>();
            if (sOperator.isLocalPlayer)
            {
                sOperator.ActivateHeroPower();
            }
        }
        //if (serverOperator == null)
        //{
        //    serverOperator = GameObject.FindGameObjectsWithTag("ServerManager");
        //}

        //serverOperator.ActivateHeroPower();

       // GameObject cardObject = (GameObject)Instantiate(cardPrefab);
      //  cardObject.transform.SetParent(locator.OwnHand.transform);

    }

}
