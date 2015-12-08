using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using System;

public class ServerLogic : NetworkBehaviour
{
    public GameObject cardPrefab;
    ClientLogic clientLogic;
    List<GameState> allGames;

    void Start()
    {
        clientLogic = GetComponentInParent<ClientLogic>();
        allGames = new List<GameState>();
    }

    public void ActivateHeroPower()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        CmdActivateHeroPower();
    }

    public void PlayCardFromHandToField(int cardIndex, int boardIndex)
    {
        CmdPlayCardFromHandToField(cardIndex, boardIndex);
    }

    /// <summary>
    /// Command draws a card in server
    /// </summary>
    [Command]
    public void CmdActivateHeroPower()
    {
        Card card = new Card { id = 1, name = DateTime.Now.Ticks.GetHashCode().ToString(), owner = 1 };

        clientLogic.RpcSendCardToPlayers(card.id, card.name, card.owner);

        //GameObject cardObject = (GameObject)Instantiate(cardPrefab);
        //NetworkServer.Spawn(cardObject);
        //clientLogic.RpcSendCardToPlayers(cardObject);
    }

    /// <summary>
    /// Command draws a card in server
    /// </summary>
    [Command]
    public void CmdPlayCardFromHandToField(int cardIndex, int boardIndex)
    {
        //drop card in server logic

        //if all good
        clientLogic.RpcPlayCardFromHandToField(cardIndex, boardIndex);

        //GameObject cardObject = (GameObject)Instantiate(cardPrefab);
        //NetworkServer.Spawn(cardObject);
        //clientLogic.RpcSendCardToPlayers(cardObject);
    }

}


public enum HeroTypes
{
    Warrior,
    Mage,
    Rogue,
    Hunter
}

public class Card
{
    public int id { get; set; }
    public string name { get; set; }
    public int owner { get; set; }
}

public class Player
{
    List<Card> handCards { get; set; }
    List<Card> boardCards { get; set; }
    public HeroTypes Hero { get; set; }
    public int HeroHealth { get; set; }
    public int playerId { get; set; }
    public int playerClientId { get; set; }
    public string playerName { get; set; }

}

public class GameState
{
    public Player PlayerOne { get; set; }
    public Player PlayerTwo { get; set; }
    public bool isPlayerOneTurn { get; set; }
    public int TimeLeftThisTurn { get; set; }
    public bool isOver { get; set; }

}