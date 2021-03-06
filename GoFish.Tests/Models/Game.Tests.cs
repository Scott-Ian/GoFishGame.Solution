using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoFish.Models;
using System.Collections.Generic;
using System;

namespace GoFish.Tests
{
  [TestClass]
  public class GameTests
  {
    [TestMethod]
    public void GameConstructor_CreatesInstanceOfGame_Game()
    {
      Game testGame = new Game();
      Assert.AreEqual(typeof(Game), testGame.GetType());
    }

    [TestMethod]
    public void GameConstructor_ContainsDeckOf52Cards_CardList()
    {
      Game testGame = new Game();
      Assert.AreEqual(52, testGame.GetDeck().Count);
    }

    [TestMethod]
    public void GamePlayerList_ContainsListOfPlayers_PlayerList()
    {
      Game testGame = new Game();
      Player player1 = new Player();
      Player player2 = new Player();
      testGame.AddPlayer(player1);
      testGame.AddPlayer(player2);
      List<Player> testList = new List<Player>{};
      testList.Add(player1);
      testList.Add(player2);

      CollectionAssert.AreEqual(testList, testGame.GetPlayerList());
    }

    [TestMethod]
    public void GamePlayerTurnTracker_IndexValueForCurrentPlayerTurn_PlayerTurnIndex()
    {
      Game testGame = new Game();
      Assert.AreEqual(0, testGame.CurrentPlayerTurn);
    }

    [TestMethod]
    public void DrawCard_AddsCardsToPlayersHand_Int()
    {
      Game testGame = new Game();
      Player player1 = new Player();
      testGame.AddPlayer(player1);

      Assert.AreEqual(5, player1.PlayerHand.Count);
    }
    
    [TestMethod]
    public void DrawCard_ReducesTotalDeckCount_Int()
    {
      Game testGame = new Game();
      Player player1 = new Player();
      testGame.AddPlayer(player1);

      Assert.AreEqual(47, testGame.GetDeck().Count);
    }

    [TestMethod]
    public void CheckForMatch_ReturnsTrueIfMatchFoundInOpponentHand_True()
    {
      Game testGame = new Game();
      Player player1 = new Player();
      Player player2 = new Player();
      testGame.AddPlayer(player1);
      testGame.AddPlayer(player2);
      string[] testCard = {"3", "hearts"};
      player2.PlayerHand.Add(testCard);
      
      Assert.AreEqual(true, testGame.CheckForMatch("3"));
    }

    [TestMethod]
    public void RemoveDuplicatesAddScore_RemovesDuplicateCardValuesFromHandAndAddsScore_0()
    {
      Game testGame = new Game();
      Player player1 = new Player();
      testGame.AddPlayer(player1);
      player1.PlayerHand.Clear();
      string[] testCard = {"3", "hearts"};
      string[] testCard2 = {"3", "diamonds"};
      player1.PlayerHand.Add(testCard);
      player1.PlayerHand.Add(testCard2);
      testGame.RemoveDuplicatesAddScore();
      Assert.AreEqual(0, player1.PlayerHand.Count);
    }
    
  }
}