using UnityEngine;
using System.Collections;

public class GameCardManager : MonoBehaviour {

    public GameObject handCardPrefab;
    public GameObject boardCardPrefab;


    private GameObject handCard;
    private GameObject boardCard;

    void Start ()
    {
        handCard = Instantiate(handCard);
        handCard.transform.SetParent(this.transform);
        boardCard = Instantiate(boardCard);
        boardCard.transform.SetParent(this.transform);

        handCard.SetActive(true);
        boardCard.SetActive(false);
    }
	
    /// <summary>
    /// Enables hand card model
    /// </summary>
    public void putInHand()
    {
        handCard.SetActive(true);
        boardCard.SetActive(false);
    }

    /// <summary>
    /// Enables board card model
    /// </summary>
    public void putOnBoard()
    {
        handCard.SetActive(false);
        boardCard.SetActive(true);
    }

}
