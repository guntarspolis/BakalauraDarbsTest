using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading;
using System.Collections.Generic;

public class DrawCardButton : MonoBehaviour {

    public GameObject cardPrefab;

    /// <summary>
    /// Method finds local game object and calls a player instance card draw method.
    /// </summary>
    public void DrawNewCard()
    {
        GameObject[] bothPlayerInstaces = GameObject.FindGameObjectsWithTag("Player");
        foreach (var singleInstance in bothPlayerInstaces)
        {
            NetworkBehaviour networkObject = singleInstance.GetComponent<NetworkBehaviour>();
            if(networkObject.isLocalPlayer)
            {
                PlayerInstance playerInstanceScript = singleInstance.GetComponent<PlayerInstance>();
                playerInstanceScript.DrawCardButton();
            }
        }
    }

}
