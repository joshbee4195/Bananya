using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public GameObject playerCounts;

    public GameObject main;

    public List<GameObject> OLDallCards; //6 of each cat, 4 mice
    public List<GameObject> allCards; //6 of each cat, 4 mice

    public List<GameObject> remainingCards;
    public List<GameObject> litterCards;

    public List<GameObject> player1Cards;
    public List<GameObject> player2Cards;
    public List<GameObject> player3Cards;
    public List<GameObject> player4Cards;


    //card displays
    public GameObject p1Cards;
    public GameObject p2Cards;
    public GameObject p3Cards;
    public GameObject p4Cards;

    //current card parents
    public GameObject p1CurrentCards;
    public GameObject p2CurrentCards;
    public GameObject p3CurrentCards;
    public GameObject p4CurrentCards;

    //   public List<List<GameObject>> playerCardLists;

    public int currentPlayerTurn; //1, 2, 3, 4


    public bool drawn; //current player drawn card

    public GameObject wonCard;

    public Card playedCard;

    public bool FromLitter;


    public Button litterBut;
    public GameObject litterCardCol;
    public Image litterIMG;
    public Button deckBut;

    public TextMeshProUGUI actionText;


    public float CardSpacing;

    public TextMeshProUGUI currentPlayerText;

    public bool Discard;

    public GameObject nextPlayerBut;


    public List<GameObject> transferCards;

    public GameObject mouseTransferCard;

    public GameObject pirateDisplay;

    public List<GameObject> stolenCards;


    public GameObject missTurn;
    public GameObject[] missTurnObjs;

    public int nextToSkip;


    public GameObject pickCardParent;
    public GameObject[] pickCardObjs;

    public GameObject litterCalico;
    public GameObject[] litterCalicoCards;

    public List<int> typesCollected;

    public GameObject gameover;
    public TextMeshProUGUI gameoverText;

    public GameObject litterCalicoHolder;

    // Start is called before the first frame update
    void Start()
    {
        // remainingCards = allCards;

        nextPlayerBut.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Player turn: " + currentPlayerTurn);

        if (litterCards.Count == 0 || drawn == true)
        {
            litterBut.interactable = false;
        }

        else if (litterCards.Count > 0 && drawn == false)
        {
            litterBut.interactable = true;
        }

        if (drawn == true)
        {
            deckBut.interactable = false;
        }

        else
        {
            deckBut.interactable = true;
        }

        currentPlayerText.SetText("Player " + currentPlayerTurn.ToString() + "'s turn");

        //display cards in playerCards

        //player1Cards sort linearly with gaps on X axis

        if (drawn == false)
        {
            for (int i = 0; i < player1Cards.Count; i++)
            {
                // player1Cards[i].transform.position = new Vector3(50, 0, 0);
                // player1Cards[i].transform.position = new Vector2(50, 0);

                player1Cards[i].GetComponent<Button>().interactable = false;
            }
        }

        else if (drawn == true && nextPlayerBut.GetComponent<Button>().IsInteractable() == false && currentPlayerTurn == 1)
        {
            if (!pirateDisplay.activeSelf && !litterCalico.activeSelf && !missTurn.activeSelf && !pickCardParent.activeSelf)
            {
                for (int i = 0; i < player1Cards.Count; i++)
                {

                    player1Cards[i].GetComponent<Button>().interactable = true;
                }
            }

        }


        if (drawn == false)
        {
            for (int i = 0; i < player2Cards.Count; i++)
            {
                // player1Cards[i].transform.position = new Vector3(50, 0, 0);
                // player1Cards[i].transform.position = new Vector2(50, 0);

                player2Cards[i].GetComponent<Button>().interactable = false;
            }
        }

        else if (drawn == true && nextPlayerBut.GetComponent<Button>().IsInteractable() == false && currentPlayerTurn == 2)
        {
            if (!pirateDisplay.activeSelf && !litterCalico.activeSelf && !missTurn.activeSelf && !pickCardParent.activeSelf)
            {
                for (int i = 0; i < player2Cards.Count; i++)
                {

                    player2Cards[i].GetComponent<Button>().interactable = true;
                }
            }

        }

        if (drawn == false)
        {
            for (int i = 0; i < player3Cards.Count; i++)
            {
                // player1Cards[i].transform.position = new Vector3(50, 0, 0);
                // player1Cards[i].transform.position = new Vector2(50, 0);

                player3Cards[i].GetComponent<Button>().interactable = false;
            }
        }

        else if (drawn == true && nextPlayerBut.GetComponent<Button>().IsInteractable() == false && currentPlayerTurn == 3)
        {
            if (!pirateDisplay.activeSelf && !litterCalico.activeSelf && !missTurn.activeSelf && !pickCardParent.activeSelf)
            {
                for (int i = 0; i < player3Cards.Count; i++)
                {

                    player3Cards[i].GetComponent<Button>().interactable = true;
                }
            }

        }

        if (drawn == false)
        {
            for (int i = 0; i < player4Cards.Count; i++)
            {
                // player1Cards[i].transform.position = new Vector3(50, 0, 0);
                // player1Cards[i].transform.position = new Vector2(50, 0);

                player4Cards[i].GetComponent<Button>().interactable = false;
            }
        }

        else if (drawn == true && nextPlayerBut.GetComponent<Button>().IsInteractable() == false && currentPlayerTurn == 4)
        {
            if (!pirateDisplay.activeSelf && !litterCalico.activeSelf && !missTurn.activeSelf && !pickCardParent.activeSelf)
            {
                for (int i = 0; i < player4Cards.Count; i++)
                {

                    player4Cards[i].GetComponent<Button>().interactable = true;
                }
            }
        }

        //display cards in playerCards

        //player1Cards sort linearly with gaps on X axis
        // arrange every frame here so dynamic lists update automatically.
        // If you prefer to call arrangement only when the hand changes, move this call to those places instead.


        //add for other players
        if (p1CurrentCards != null)
        {
            RectTransform parentRect = p1CurrentCards.GetComponent<RectTransform>();
            ArrangePlayerCards(player1Cards, parentRect);
        }

        if (p2CurrentCards != null)
        {
            RectTransform parentRect = p2CurrentCards.GetComponent<RectTransform>();
            ArrangePlayerCards(player2Cards, parentRect);
        }

        if (p3CurrentCards != null)
        {
            RectTransform parentRect = p3CurrentCards.GetComponent<RectTransform>();
            ArrangePlayerCards(player3Cards, parentRect);
        }

        if (p4CurrentCards != null)
        {
            RectTransform parentRect = p4CurrentCards.GetComponent<RectTransform>();
            ArrangePlayerCards(player4Cards, parentRect);
        }






        if (remainingCards.Count == 0)
        {
            ShuffleLitter();
        }


        if (currentPlayerTurn == nextToSkip)
        {
            Debug.Log("Turn skipped");
           // EndOfTurn();

            ChangePlayerTurn();
        }
    }

    // Arrange a list of UI cards evenly across the parent's width on the X axis.
    // - cards: list of card GameObjects (must have a RectTransform)
    // - parentRect: RectTransform of the container under the Canvas (used to get width and coordinate space)
    // - yOffset: optional anchored Y position for cards (keeps vertical position consistent)
    private void ArrangePlayerCards1(List<GameObject> cards, RectTransform parentRect, float yOffset = 0f)
    {
        if (cards == null || parentRect == null || cards.Count == 0)
        {
            Debug.Log("Not valid");
            return;
        }

        int count = cards.Count;

        // find a representative card width (assume all cards use same width)
        RectTransform firstCardRect = null;
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] == null) continue;
            firstCardRect = cards[i].GetComponent<RectTransform>();
            if (firstCardRect != null) break;
        }

        if (firstCardRect == null)
            return;

        float cardWidth = firstCardRect.rect.width;
        float parentWidth = parentRect.rect.width;

        // compute step (spacing between card centers)
        float step = 0f;
        if (count > 1)
        {
            // ideal step to fill entire parent width
            float idealStep = (parentWidth - cardWidth) / (count - 1);
            // optionally cap step using CardSpacing if > 0 (CardSpacing acts as maximum gap)
            float maxStep = (CardSpacing > 0f) ? CardSpacing : float.MaxValue;
            step = Mathf.Min(idealStep, maxStep);
        }
        else
        {
            step = 0f;
        }

        // compute used width and starting X to center the arrangement
        float usedWidth = step * (count - 1) + cardWidth;
        float startX = -usedWidth / 2f + cardWidth / 2f;

        for (int i = 0; i < count; i++)
        {
            GameObject go = cards[i];
            if (go == null) continue;

            RectTransform cardRect = go.GetComponent<RectTransform>();
            if (cardRect == null) continue;

            // ensure the card is parented to the container so anchoredPosition is relative to the parent
            if (cardRect.parent != parentRect)
                cardRect.SetParent(parentRect, false);

            // set anchored position (x centered across parent, y preserved or set by yOffset)
            float x = startX + i * step;
            Vector2 anchored = cardRect.anchoredPosition;
            anchored.x = x;
            anchored.y = yOffset;
            cardRect.anchoredPosition = anchored;

            // normalize scale to avoid inherited scaling issues
            cardRect.localScale = Vector3.one;
        }
    }

  
private void ArrangePlayerCards(List<GameObject> cards, RectTransform parentRect, float yOffset = 0f)
    {
        if (cards == null || parentRect == null || cards.Count == 0)
        {
           // Debug.Log("Not valid");
            return;
        }

        int count = cards.Count;

        // find a representative card width (assume all cards use same width)
        RectTransform firstCardRect = null;
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] == null) continue;
            firstCardRect = cards[i].GetComponent<RectTransform>();
            if (firstCardRect != null) break;
        }

        if (firstCardRect == null)
            return;

        float cardWidth = firstCardRect.rect.width;
        float parentWidth = parentRect.rect.width;

        // compute step (spacing between card centers)
        float step = 0f;
        if (count > 1)
        {
            // if CardSpacing > 0, use it as fixed spacing; otherwise compute ideal step to fill parent
            float idealStep = (parentWidth - cardWidth) / (count - 1);
            step = (CardSpacing > 0f) ? CardSpacing : idealStep;
        }
        else
        {
            step = 0f;
        }

        // compute used width and ensure content (parentRect) expands if needed for the scroll view
        float usedWidth = step * (count - 1) + cardWidth;
        if (usedWidth > parentWidth)
        {
            parentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, usedWidth);
            parentWidth = usedWidth; // keep values consistent for centering below
        }

        // compute starting X to center the arrangement in the parent
        float startX = -usedWidth / 2f + cardWidth / 2f;

        for (int i = 0; i < count; i++)
        {
            GameObject go = cards[i];
            if (go == null) continue;

            RectTransform cardRect = go.GetComponent<RectTransform>();
            if (cardRect == null) continue;

            // ensure the card is parented to the container so anchoredPosition is relative to the parent
            if (cardRect.parent != parentRect)
                cardRect.SetParent(parentRect, false);

            // set anchored position (x centered across parent, y preserved or set by yOffset)
            float x = startX + i * step;
            Vector2 anchored = cardRect.anchoredPosition;
            anchored.x = x;
            anchored.y = yOffset;
            cardRect.anchoredPosition = anchored;

            // normalize scale to avoid inherited scaling issues
            cardRect.localScale = Vector3.one;
        }
    }

    private void ArrangeCalicoCards(GameObject[] cards, RectTransform parentRect, float yOffset = 0f)
    {
        if (cards == null || parentRect == null || cards.Length == 0)
        {
            // Debug.Log("Not valid");
            return;
        }

        int count = cards.Length;

        // find a representative card width (assume all cards use same width)
        RectTransform firstCardRect = null;
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] == null) continue;
            firstCardRect = cards[i].GetComponent<RectTransform>();
            if (firstCardRect != null) break;
        }

        if (firstCardRect == null)
            return;

        float cardWidth = firstCardRect.rect.width;
        float parentWidth = parentRect.rect.width;

        // compute step (spacing between card centers)
        float step = 0f;
        if (count > 1)
        {
            // if CardSpacing > 0, use it as fixed spacing; otherwise compute ideal step to fill parent
            float idealStep = (parentWidth - cardWidth) / (count - 1);
            step = (CardSpacing > 0f) ? CardSpacing : idealStep;
        }
        else
        {
            step = 0f;
        }

        // compute used width and ensure content (parentRect) expands if needed for the scroll view
        float usedWidth = step * (count - 1) + cardWidth;
        if (usedWidth > parentWidth)
        {
            parentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, usedWidth);
            parentWidth = usedWidth; // keep values consistent for centering below
        }

        // compute starting X to center the arrangement in the parent
        float startX = -usedWidth / 2f + cardWidth / 2f;

        for (int i = 0; i < count; i++)
        {
            GameObject go = cards[i];
            if (go == null) continue;

            RectTransform cardRect = go.GetComponent<RectTransform>();
            if (cardRect == null) continue;

            // ensure the card is parented to the container so anchoredPosition is relative to the parent
            if (cardRect.parent != parentRect)
                cardRect.SetParent(parentRect, false);

            // set anchored position (x centered across parent, y preserved or set by yOffset)
            float x = startX + i * step;
            Vector2 anchored = cardRect.anchoredPosition;
            anchored.x = x;
            anchored.y = yOffset;
            cardRect.anchoredPosition = anchored;

            // normalize scale to avoid inherited scaling issues
            cardRect.localScale = Vector3.one;
        }
    }


    //initial card setup

    public void InitialCards()
    {
        for (int i = 0; i < 7; i++)
        {
            wonCard = remainingCards[UnityEngine.Random.Range(0, remainingCards.Count)];

            player1Cards.Add(wonCard);
            wonCard.transform.parent = p1CurrentCards.transform;
            remainingCards.Remove(wonCard);
        }


        for (int i = 0; i < 7; i++)
        {
            wonCard = remainingCards[UnityEngine.Random.Range(0, remainingCards.Count)];

            player2Cards.Add(wonCard);
            wonCard.transform.parent = p2CurrentCards.transform;

           // wonCard.transform.position = new Vector3(0, 0, 0);
            remainingCards.Remove(wonCard);
        }

        if (gen.playerCount > 2)
        {
            for (int i = 0; i < 7; i++)
            {
                wonCard = remainingCards[UnityEngine.Random.Range(0, remainingCards.Count)];

                player3Cards.Add(wonCard);
                wonCard.transform.parent = p3CurrentCards.transform;
                remainingCards.Remove(wonCard);
            }
        }

        if (gen.playerCount > 3)
        {
            for (int i = 0; i < 7; i++)
            {
                wonCard = remainingCards[UnityEngine.Random.Range(0, remainingCards.Count)];

                player4Cards.Add(wonCard);
                wonCard.transform.parent = p4CurrentCards.transform;
                remainingCards.Remove(wonCard);
            }
        }
    }

    //drawing cards

    public void DrawCard()
    {
        //give random card from remaining cards

        nextToSkip = 0;
        wonCard = remainingCards[UnityEngine.Random.Range(0, remainingCards.Count)];

        //add card to hand - depending on player

       // playerCardLists[currentPlayerTurn].Add(wonCard);
      GiveCard();

        remainingCards.Remove(wonCard);
        drawn = true;
    }

    //NOT USED? - OR FOR BUNCH?
    public void DrawCardAll() 
    {
        //give random card from remaining cards

        wonCard = remainingCards[UnityEngine.Random.Range(0, remainingCards.Count)];

        //add card to hand - depending on player

        // playerCardLists[currentPlayerTurn].Add(wonCard);
        GiveCard();

        remainingCards.Remove(wonCard);
        drawn = true;
    }

    public void LitterCard()
    {
        //give top card from litter box

        nextToSkip = 0;

        wonCard = litterCards[litterCards.Count-1];

        FromLitter = true;

        litterCards.Remove(wonCard);
        drawn = true;


    }


    public void GiveCard()
    {
        nextToSkip = 0;
       // actionText.SetText("");

        if (currentPlayerTurn == 1)
        {
            player1Cards.Add(wonCard);

            wonCard.transform.parent = p1CurrentCards.transform;
        }

        if (currentPlayerTurn == 2)
        {
            player2Cards.Add(wonCard);

            wonCard.transform.parent = p2CurrentCards.transform;
        }

        if (currentPlayerTurn == 3)
        {
            player3Cards.Add(wonCard);

            wonCard.transform.parent = p3CurrentCards.transform;
        }

        if (currentPlayerTurn == 4)
        {
            player4Cards.Add(wonCard);

            wonCard.transform.parent = p4CurrentCards.transform;
        }

        //display cards to play
       // ShowCards();

       // player4Cards.Add(wonCard);
       // wonCard.transform.parent = p4CurrentCards.transform;
      
    }


    //playing cards

    public void ShowCards()
    {
        if (currentPlayerTurn == 1)
        {
            p1Cards.SetActive(true);

            p2Cards.SetActive(false);
            p3Cards.SetActive(false);
            p4Cards.SetActive(false);
        }

        if (currentPlayerTurn == 2)
        {
            p2Cards.SetActive(true);

            p1Cards.SetActive(false);
            p3Cards.SetActive(false);
            p4Cards.SetActive(false);
        }

        if (currentPlayerTurn == 3)
        {
            p3Cards.SetActive(true);

            p1Cards.SetActive(false);
            p2Cards.SetActive(false);
            p4Cards.SetActive(false);
        }

        if (currentPlayerTurn == 4)
        {
            p4Cards.SetActive(true);

            p1Cards.SetActive(false);
            p2Cards.SetActive(false);
            p3Cards.SetActive(false);
        }
    }


    public void PlayCard()
    {
        //put card into Litter list
        litterCards.Add(playedCard.gameObject);

       // playedCard.gameObject.transform.parent = litterBut.gameObject.transform;
       // playedCard.gameObject.transform.position = litterBut.gameObject.transform.position;

        playedCard.gameObject.transform.parent = litterCardCol.transform;
        playedCard.gameObject.transform.position = litterCardCol.transform.position;

        //set card to not interactable - until can draw card
        playedCard.button.interactable = false;
        //change image of litter to last card

        GameObject cardOBJ = playedCard.gameObject;

       litterIMG.sprite = cardOBJ.GetComponent<Image>().sprite;


        //remove card from player list

        if (currentPlayerTurn == 1)
        {
            player1Cards.Remove(playedCard.gameObject);
        }

        if (currentPlayerTurn == 2)
        {
            player2Cards.Remove(playedCard.gameObject);
        }

        if (currentPlayerTurn == 3)
        {
            player3Cards.Remove(playedCard.gameObject);
        }

        if (currentPlayerTurn == 4)
        {
            player4Cards.Remove(playedCard.gameObject);
        }

        if (FromLitter)
        {
            GiveCard(); //but not immediately add to hand - only after played
        }

        // ChangePlayerTurn();

        if (Discard)
        {
            actionText.SetText("");
            EndOfTurn();

        }



        if (!Discard)
        {
            //do action
            ResolvePower();
        }

        if (Discard)
        {
            //turn Ended
         //   ChangePlayerTurn();
        }
    }

    public void EndOfTurn()
    {
        nextPlayerBut.GetComponent<Button>().interactable = true;


        //set cards not interactable

        for (int i = 0; i < player1Cards.Count; i++)
        {

            player1Cards[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < player2Cards.Count; i++)
        {

            player2Cards[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < player3Cards.Count; i++)
        {

            player3Cards[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < player4Cards.Count; i++)
        {

            player4Cards[i].GetComponent<Button>().interactable = false;
        }
    }

    public void ResolvePower()
    {
        //if 0, reg bananya, do nothing

        /*0 is bananya

        1 baby
        2 yako
        3 bunch
        4 calico
        5 daddy
        6 long haired
        7 pirate
        8 mackerel tabby
        9 tabby
        10 mouse
        */

        //working - reg, baby, bunch, daddy, mackerel, pirate, tabby, long hair

        //prob - yako, mouse

        //partial - long hair

        //to do - calico

        //4,


        if (playedCard.Type == 0)
        {
            EndOfTurn();
        }

        else if (playedCard.Type == 1) //first action - baby bananya - discard a card
        {
            actionText.SetText("Choose 1 card to discard");

            Discard = true;

        }

        else if (playedCard.Type == 2) //yako - switch hands
        {
            //if 2 players, swap
            //if more, need to rotate
            actionText.SetText("Swapped hands");
            //  List<GameObject> transferCards;

            if (gen.playerCount == 2)
            {
                transferCards = player1Cards;

                player1Cards = player2Cards;

                player2Cards = transferCards;
            }


            if (gen.playerCount == 3) //player 1 receive p3, player 3 receives p2, player 2 receives p1
            {
                transferCards = player1Cards;

                player1Cards = player3Cards;

                player3Cards = player2Cards;

                player2Cards = transferCards;
            }



            if (gen.playerCount == 4) //player 1 receive p4, player 4 receives p3, player 3 receives p2, player 2 receives p1
            {
                transferCards = player1Cards;

                player1Cards = player4Cards;

                player4Cards = player3Cards;

                player3Cards = player2Cards;

                player2Cards = transferCards;
            }



            //need to shift the parents

            for (int i = 0; i < player1Cards.Count; i++)
            {
                player1Cards[i].transform.parent = p1Cards.transform;
            }

            for (int i = 0; i < player2Cards.Count; i++)
            {
                player2Cards[i].transform.parent = p2Cards.transform;
            }

            for (int i = 0; i < player3Cards.Count; i++)
            {
                player3Cards[i].transform.parent = p3Cards.transform;
            }

            for (int i = 0; i < player4Cards.Count; i++)
            {
                player4Cards[i].transform.parent = p4Cards.transform;
            }

            EndOfTurn();
        }

        else if (playedCard.Type == 3) //bunch - all players get 1 card
        {
            //give card to each player
            actionText.SetText("Each player received 1 card");

            int origPTurn = currentPlayerTurn;

            for (int i = 0; i < gen.playerCount; i++)
            {
                currentPlayerTurn = i + 1;

                DrawCard();
            }

            currentPlayerTurn = origPTurn;

            EndOfTurn();

        }

        else if (playedCard.Type == 4) // calico - choose 1 from litter box
        {
            if (litterCards.Count > 1)
            {
                PickFromLitter();
                unInteractCards();
            }

            else
            {
                EndOfTurn();
            }
        }

        else if (playedCard.Type == 5) // player gets 1 card from draw deck
        {
            //give only current player 1 card

            actionText.SetText("Received 1 card");

            DrawCard();

            EndOfTurn();
        }

        else if (playedCard.Type == 6) //long hair - choose player to miss a turn
        {
            //if 2 player, don't need to pick? - same as go again



            //end turn and add another one to current player?

            missTurn.SetActive(true);


            MissTurn();

            actionText.SetText("Choose a player to miss their next turn");
            //currently always misses next person turn

            // currentPlayerTurn += 1;
            //  EndOfTurn();
        }

        else if (playedCard.Type == 7) //pirate - ask for specific type
        {
            //menu to choose type

            //then looks through each player hand and takes one of that type if has


            //show pirate display

            pirateDisplay.SetActive(true);

            actionText.SetText("Choose a card to ask other players for");

            //disable current player cards

            unInteractCards();
        }

        else if (playedCard.Type == 8) //mackerel tabby //go again
        {
            actionText.SetText("Have your turn again");
            //reset turn - like moving to next player but not change playerNum

            GoAgain();
        }

        else if (playedCard.Type == 9) //tabby - pick card from specific player's hand
        {
            actionText.SetText("Choose player to take a card from");

            PickCard();
        }

        else if (playedCard.Type == 10) //mouse - random card passed to right
        {

            actionText.SetText("Swapped 1 card with other players");
            //if 2 players, swap
            //if more, need to rotate

            //  List<GameObject> transferCards;

            if (gen.playerCount == 2)
            {
                // mouseTransferCard = player1Cards[0];

                mouseTransferCard = player1Cards[UnityEngine.Random.Range(0, player1Cards.Count)];

                player1Cards.Remove(mouseTransferCard);
                player2Cards.Add(mouseTransferCard);

                // player1Cards.Add(player2Cards[0]);

                GameObject transfer = player2Cards[UnityEngine.Random.Range(0, player2Cards.Count)];
                player1Cards.Add(transfer);
                player2Cards.Remove(transfer);
            }


            if (gen.playerCount == 3) //player 1 receive p2, player 3 receives p1, player 2 receives p3
            {
                // mouseTransferCard = player1Cards[0];
                mouseTransferCard = player1Cards[UnityEngine.Random.Range(0, player1Cards.Count)];


                player1Cards.Remove(mouseTransferCard);
                player3Cards.Add(mouseTransferCard);



                GameObject transfer = player2Cards[UnityEngine.Random.Range(0, player2Cards.Count)];
                player1Cards.Add(transfer);
                player2Cards.Remove(transfer);

                GameObject transfer2 = player3Cards[UnityEngine.Random.Range(0, player3Cards.Count)];
                player2Cards.Add(transfer2);
                player3Cards.Remove(transfer2);
            }



            if (gen.playerCount == 4) //player 1 receive p2, player 4 receives p1, player 2 receives p3, player 3 receives p4
            {
                // mouseTransferCard = player1Cards[0];
                mouseTransferCard = player1Cards[UnityEngine.Random.Range(0, player1Cards.Count)];

                player1Cards.Remove(mouseTransferCard);
                player4Cards.Add(mouseTransferCard);

                GameObject transfer = player2Cards[UnityEngine.Random.Range(0, player2Cards.Count)];
                player1Cards.Add(transfer);
                player2Cards.Remove(transfer);

                GameObject transfer2 = player3Cards[UnityEngine.Random.Range(0, player3Cards.Count)];
                player2Cards.Add(transfer2);
                player3Cards.Remove(transfer2);


                GameObject transfer3 = player4Cards[UnityEngine.Random.Range(0, player4Cards.Count)];
                player3Cards.Add(transfer3);
                player4Cards.Remove(transfer3);
            }



            //need to shift the parents

            for (int i = 0; i < player1Cards.Count; i++)
            {
                player1Cards[i].transform.parent = p1Cards.transform;
            }

            for (int i = 0; i < player2Cards.Count; i++)
            {
                player2Cards[i].transform.parent = p2Cards.transform;
            }

            for (int i = 0; i < player3Cards.Count; i++)
            {
                player3Cards[i].transform.parent = p3Cards.transform;
            }

            for (int i = 0; i < player4Cards.Count; i++)
            {
                player4Cards[i].transform.parent = p4Cards.transform;
            }

            EndOfTurn();
        }

        //else if... etc.


        //after this, turn over - next player

        //ChangePlayerTurn();


    }

    public void unInteractCards()   //for calico and pirate
    {
        for (int i = 0; i < player1Cards.Count;i++)
        {
            player1Cards[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < player2Cards.Count; i++)
        {
            player2Cards[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < player3Cards.Count; i++)
        {
            player3Cards[i].GetComponent<Button>().interactable = false;
        }


        for (int i = 0; i < player4Cards.Count; i++)
        {
            player4Cards[i].GetComponent<Button>().interactable = false;
        }
    }

    public void PickFromLitter()
    {
        //display all cards in litterbox - give player option to click one and add to collection

        //use scroll view?

        actionText.SetText("Choose a card from the litter box");
        //display card options

        litterCalico.SetActive(true);

        if (litterCalico != null)
        {
            RectTransform parentRect = litterCalicoHolder.GetComponent<RectTransform>();
            ArrangeCalicoCards(litterCalicoCards, parentRect);
        }


        for (int i = 0; i < litterCalicoCards.Length; i++)
        {
            //check if litter box contains, if does set active, if not set inactive

            Card cardCheck = litterCalicoCards[i].GetComponent<Card>();

            int typeCheck = cardCheck.Type;

            for (int j = 0; j < litterCards.Count; j++)
            {
                if (litterCards[j].gameObject.GetComponent<Card>().Type == typeCheck)
                {
                    //there is one of those cards in the litter box

                    litterCalicoCards[i].SetActive(true);

                    break;
                }
            }
        }
    }

    public void ChosenCardFromLitter(int cardType)
    {
        //when clicked

        //one of that card type taken from litter and added to player hand
        actionText.SetText("");

        for (int i = 0; i < litterCards.Count; i++)
        {
            if (litterCards[i].gameObject.GetComponent<Card>().Type == cardType)
            { 
                //give to player

                //add to player list
                //remove from litter list

                if (currentPlayerTurn == 1)
                {
                    player1Cards.Add(litterCards[i]);
                    litterCards.Remove(litterCards[i]);

                    litterCards[i].gameObject.transform.parent = p1CurrentCards.gameObject.transform;

                    litterCalico.SetActive(false);
                    EndOfTurn();
                }

                if (currentPlayerTurn == 2)
                {
                    player2Cards.Add(litterCards[i]);
                    litterCards.Remove(litterCards[i]);

                    litterCards[i].gameObject.transform.parent = p2CurrentCards.gameObject.transform;

                    litterCalico.SetActive(false);
                    EndOfTurn();
                }

                if (currentPlayerTurn == 3)
                {
                    player3Cards.Add(litterCards[i]);
                    litterCards.Remove(litterCards[i]);
                    litterCards[i].gameObject.transform.parent = p3CurrentCards.gameObject.transform;

                    litterCalico.SetActive(false);
                    EndOfTurn();

                }

                if (currentPlayerTurn == 4)
                {
                    player4Cards.Add(litterCards[i]);
                    litterCards.Remove(litterCards[i]);

                    litterCards[i].gameObject.transform.parent = p4CurrentCards.gameObject.transform;

                    litterCalico.SetActive(false);
                    EndOfTurn();

                }

                break;
            }
        }

        //reset calico display to all false
        for (int i = 0; i < litterCalicoCards.Length; i++)
        {
            litterCalicoCards[i].SetActive(false);
        }


        //parent align


            //end of turn
        
    }

    public void GoAgain()
    {
       
        drawn = false;
        FromLitter = false;

        wonCard = null;
        playedCard = null;
        Discard = false;

        //display cards to play
        //ShowCards();
    }


    public void PirateCard()
    {
        Card playedType = playedCard.GetComponent<Card>();

        int targetType = playedType.Type;

        // List<GameObject> stolenCards;

        actionText.SetText("");

        //take cards

        //check every players list for 1 of that type

        for (int i = 0; i < player1Cards.Count; i++)
        {
            Card current = player1Cards[i].GetComponent<Card>();
            
            if (current.Type == targetType)
            {
                stolenCards.Add(current.gameObject);
                break;
            }
        }

        for (int i = 0; i < player2Cards.Count; i++)
        {
            Card current = player2Cards[i].GetComponent<Card>();

            if (current.Type == targetType)
            {
                stolenCards.Add(current.gameObject);
                break;
            }
        }


        for (int i = 0; i < player3Cards.Count; i++)
        {
            Card current = player3Cards[i].GetComponent<Card>();

            if (current.Type == targetType)
            {
                stolenCards.Add(current.gameObject);
                break;
            }
        }


        for (int i = 0; i < player4Cards.Count; i++)
        {
            Card current = player4Cards[i].GetComponent<Card>();

            if (current.Type == targetType)
            {
                stolenCards.Add(current.gameObject);
                break;
            }
        }


        //add cards to hand
        if (currentPlayerTurn == 1)
        {
                player1Cards.AddRange(stolenCards);
        }

        if (currentPlayerTurn == 2)
        {
            player2Cards.AddRange(stolenCards);
        }

        if (currentPlayerTurn == 3)
        {
            player3Cards.AddRange(stolenCards);
        }

        if (currentPlayerTurn == 4)
        {
            player4Cards.AddRange(stolenCards);
        }


        //move objects

        //need to shift the parents

        for (int i = 0; i < player1Cards.Count; i++)
        {
            player1Cards[i].transform.parent = p1Cards.transform;
        }

        for (int i = 0; i < player2Cards.Count; i++)
        {
            player2Cards[i].transform.parent = p2Cards.transform;
        }

        for (int i = 0; i < player3Cards.Count; i++)
        {
            player3Cards[i].transform.parent = p3Cards.transform;
        }

        for (int i = 0; i < player4Cards.Count; i++)
        {
            player4Cards[i].transform.parent = p4Cards.transform;
        }

     
        //hide pirate display

        pirateDisplay.SetActive(false);

        EndOfTurn();
    }


    //pick from player

    public void PickCard()
    {

        pickCardParent.SetActive(true);

        if (gen.playerCount == 2)
        {
            pickCardObjs[2].SetActive(false);
            pickCardObjs[3].SetActive(false);
        }


        if (gen.playerCount == 3)
        {
            // missTurnObjs[2].SetActive(false);
            pickCardObjs[3].SetActive(false);
        }

        //set current player to false

        for (int i = 0; i < pickCardObjs.Length; i++)
        {
            if (currentPlayerTurn == i + 1)
            {
                pickCardObjs[i].GetComponent<Button>().interactable = false;
            }

            else
            {
                pickCardObjs[i].GetComponent<Button>().interactable = true;
            }
        }


       
    }

    //when pick card

    //take card from that player

    //add to current player

    //miss turn

    public void TakePlayer1Card()
    {
        actionText.SetText("");

        GameObject chosenCard = player1Cards[UnityEngine.Random.Range(0,player1Cards.Count - 1)];

        if (chosenCard != null)
        {
            if (currentPlayerTurn == 2)
            {
                player2Cards.Add(chosenCard);

                chosenCard.transform.parent = p2Cards.transform;

                player1Cards.Remove(chosenCard);
            }

            if (currentPlayerTurn == 3)
            {
                player3Cards.Add(chosenCard);

                chosenCard.transform.parent = p3Cards.transform;

                player1Cards.Remove(chosenCard);
            }

            if (currentPlayerTurn == 4)
            {
                player4Cards.Add(chosenCard);

                chosenCard.transform.parent = p4Cards.transform;

                player1Cards.Remove(chosenCard);
            }
        }

        pickCardParent.SetActive(false);
        EndOfTurn();
    }

    public void TakePlayer2Card()
    {
        actionText.SetText("");
        GameObject chosenCard = player2Cards[UnityEngine.Random.Range(0, player2Cards.Count - 1)];

        if (chosenCard != null)
        {
            if (currentPlayerTurn == 1)
            {
                player1Cards.Add(chosenCard);

                chosenCard.transform.parent = p1Cards.transform;

                player2Cards.Remove(chosenCard);
            }

            if (currentPlayerTurn == 3)
            {
                player3Cards.Add(chosenCard);

                chosenCard.transform.parent = p3Cards.transform;

                player2Cards.Remove(chosenCard);
            }

            if (currentPlayerTurn == 4)
            {
                player4Cards.Add(chosenCard);

                chosenCard.transform.parent = p4Cards.transform;

                player2Cards.Remove(chosenCard);
            }
        }

        pickCardParent.SetActive(false);
        EndOfTurn();
    }

    public void TakePlayer3Card()
    {
        actionText.SetText("");
        GameObject chosenCard = player3Cards[UnityEngine.Random.Range(0, player3Cards.Count - 1)];

        if (chosenCard != null)
        {
            if (currentPlayerTurn == 1)
            {
                player1Cards.Add(chosenCard);

                chosenCard.transform.parent = p1Cards.transform;

                player3Cards.Remove(chosenCard);
            }

            if (currentPlayerTurn == 2)
            {
                player2Cards.Add(chosenCard);

                chosenCard.transform.parent = p2Cards.transform;

                player3Cards.Remove(chosenCard);
            }

            if (currentPlayerTurn == 4)
            {
                player4Cards.Add(chosenCard);

                chosenCard.transform.parent = p4Cards.transform;

                player3Cards.Remove(chosenCard);
            }
        }

        pickCardParent.SetActive(false);
        EndOfTurn();
    }

    public void TakePlayer4Card()
    {
        actionText.SetText("");
        GameObject chosenCard = player4Cards[UnityEngine.Random.Range(0, player4Cards.Count - 1)];

        if (chosenCard != null)
        {
            if (currentPlayerTurn == 1)
            {
                player1Cards.Add(chosenCard);

                chosenCard.transform.parent = p1Cards.transform;

                player4Cards.Remove(chosenCard);
            }

            if (currentPlayerTurn == 3)
            {
                player3Cards.Add(chosenCard);

                chosenCard.transform.parent = p3Cards.transform;

                player4Cards.Remove(chosenCard);
            }

            if (currentPlayerTurn == 2)
            {
                player2Cards.Add(chosenCard);

                chosenCard.transform.parent = p2Cards.transform;

                player4Cards.Remove(chosenCard);
            }
        }

        pickCardParent.SetActive(false);
        EndOfTurn();
    }


    public void MissTurn()
    {
        //remove non played players

        if (gen.playerCount == 2)
        {
            missTurnObjs[2].SetActive(false);
            missTurnObjs[3].SetActive(false);
        }


        if (gen.playerCount == 3)
        {
           // missTurnObjs[2].SetActive(false);
            missTurnObjs[3].SetActive(false);
        }


        //set current player to false

        for (int i = 0; i < missTurnObjs.Length; i++)
        {
            if (currentPlayerTurn == i + 1)
            {
               // missTurnObjs[i].GetComponent<Button>().interactable = false;


                missTurnObjs[i].GetComponent<Button>().interactable = false;
            }

            else
            {
                missTurnObjs[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    //chosen miss turn button

    public void MissPlayer1Turn()
    {
        actionText.SetText("");
        //skips the turn of the player chosen

        nextToSkip = 1;

        missTurn.SetActive(false);
        EndOfTurn();
    }

    public void MissPlayer2Turn()
    {
        actionText.SetText("");
        //skips the turn of the player chosen

        nextToSkip = 2;

        missTurn.SetActive(false);
        EndOfTurn();
    }

    public void MissPlayer3Turn()
    {
        actionText.SetText("");
        //skips the turn of the player chosen

        nextToSkip = 3;

        missTurn.SetActive(false);
        EndOfTurn();
    }

    public void MissPlayer4Turn()
    {
        actionText.SetText("");
        //skips the turn of the player chosen
        nextToSkip = 4;

        missTurn.SetActive(false);
        EndOfTurn();

    }


    public void ReShuffleDeck()
    {
        if (remainingCards.Count == 0)
        {
            //shuffle litter box list

            // litterCards.

          
            //add litter box list to remaining cards
            //remove litter box list elements
            //move to draw deck parent
        }
    }


    // Fisher–Yates shuffle for List<GameObject>
    public void ShuffleList(List<GameObject> list)
    {
        if (list == null || list.Count <= 1) return;

        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1); // inclusive 0..i
            var tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }

    // convenience method to shuffle the litterCards
    public void ShuffleLitter()
    {
        ShuffleList(litterCards);

        remainingCards = litterCards;

        litterCards.Clear();


        for (int i = 0; i < remainingCards.Count;i++)
        {
            remainingCards[i].transform.parent = deckBut.gameObject.transform;

            remainingCards[i].gameObject.transform.position = deckBut.gameObject.transform.position;


            //set to is interactable

            remainingCards[i].GetComponent<Button>().interactable = true;
        }

    }


    public void nya() //when clicked
    {

        if (currentPlayerTurn == 1)
        {
            nyaCheck1();
        }

        else if (currentPlayerTurn == 2)
        {
            nyaCheck2();
        }

        else if (currentPlayerTurn == 3)
        {
            nyaCheck3();
        }

        else if (currentPlayerTurn == 4)
        {
            nyaCheck4();
        }
    }



    public void nyaCheck1()
    {
        //save types
        for (int i = 0; i < player1Cards.Count; i++)
        {
           typesCollected.Add(player1Cards[i].gameObject.GetComponent<Card>().Type);
        }

        //check types

        nyaContains(1);
    }

    public void nyaCheck2()
    {
        //save types
        for (int i = 0; i < player2Cards.Count; i++)
        {
            typesCollected.Add(player2Cards[i].gameObject.GetComponent<Card>().Type);
        }

        //check types

        nyaContains(2);
    }

    public void nyaCheck3()
    {

        //save types
        for (int i = 0; i < player3Cards.Count; i++)
        {
            typesCollected.Add(player3Cards[i].gameObject.GetComponent<Card>().Type);
        }

        //check types

        nyaContains(3);

    }

    public void nyaCheck4()
    {
        //save types
        for (int i = 0; i < player4Cards.Count; i++)
        {
            typesCollected.Add(player4Cards[i].gameObject.GetComponent<Card>().Type);
        }

        //check types

        nyaContains(4);
    }


    public void nyaContains(int player)
    {
        if (typesCollected.Contains(0) || typesCollected.Contains(1)) //reg or baby
        {
            Debug.Log("Nya checking");
        }

        if (typesCollected.Contains(0) && typesCollected.Contains(1) && typesCollected.Contains(2) && typesCollected.Contains(3) && typesCollected.Contains(4) && typesCollected.Contains(5) && typesCollected.Contains(6) && typesCollected.Contains(7) && typesCollected.Contains(8) && typesCollected.Contains(9))
        {
            //has all

            //display game over screen

            gameover.SetActive(true);


            gameoverText.SetText("Player " + player + " wins!");
        }

        else //doesn't have all
        {
            //randomly discards 2 cards

            //remove from player hand
            //add to litterbox
            //parent to litter

            if (player == 1)
            {
                if (player1Cards.Count >= 2)
                {
                    GameObject chosen1 = player1Cards[UnityEngine.Random.Range(0, player1Cards.Count)];

                    litterCards.Add(chosen1);
                    player1Cards.Remove(chosen1);

                    chosen1.transform.parent = litterCardCol.transform;
                    chosen1.transform.position = litterCardCol.transform.position;

                    litterIMG.sprite = chosen1.GetComponent<Image>().sprite;

                    GameObject chosen2 = player1Cards[UnityEngine.Random.Range(0, player1Cards.Count)];

                    litterCards.Add(chosen2);
                    player1Cards.Remove(chosen2);

                    chosen2.transform.parent = litterCardCol.transform;
                    chosen2.transform.position = litterCardCol.transform.position;

                    litterIMG.sprite = chosen2.GetComponent<Image>().sprite;
                }
            }

            if (player == 2)
            {

                if (player2Cards.Count >= 2)
                {
                    GameObject chosen1 = player2Cards[UnityEngine.Random.Range(0, player2Cards.Count)];

                    litterCards.Add(chosen1);
                    player2Cards.Remove(chosen1);

                    chosen1.transform.parent = litterCardCol.transform;
                    chosen1.transform.position = litterCardCol.transform.position;

                    GameObject chosen2 = player2Cards[UnityEngine.Random.Range(0, player2Cards.Count)];

                    litterCards.Add(chosen2);
                    player2Cards.Remove(chosen2);

                    chosen2.transform.parent = litterCardCol.transform;
                    chosen2.transform.position = litterCardCol.transform.position;

                    litterIMG.sprite = chosen2.GetComponent<Image>().sprite;
                }
            }

            if (player == 3)
            {
                if (player3Cards.Count >= 2)
                {
                    GameObject chosen1 = player3Cards[UnityEngine.Random.Range(0, player3Cards.Count)];

                    litterCards.Add(chosen1);
                    player3Cards.Remove(chosen1);

                    chosen1.transform.parent = litterCardCol.transform;
                    chosen1.transform.position = litterCardCol.transform.position;

                    GameObject chosen2 = player3Cards[UnityEngine.Random.Range(0, player3Cards.Count)];

                    litterCards.Add(chosen2);
                    player3Cards.Remove(chosen2);

                    chosen2.transform.parent = litterCardCol.transform;
                    chosen2.transform.position = litterCardCol.transform.position;

                    litterIMG.sprite = chosen2.GetComponent<Image>().sprite;
                }
            }
            if (player == 4)
            {
                if (player4Cards.Count >= 2)
                {
                    GameObject chosen1 = player4Cards[UnityEngine.Random.Range(0, player4Cards.Count)];

                    litterCards.Add(chosen1);
                    player4Cards.Remove(chosen1);

                    chosen1.transform.parent = litterCardCol.transform;
                    chosen1.transform.position = litterCardCol.transform.position;

                    GameObject chosen2 = player4Cards[UnityEngine.Random.Range(0, player4Cards.Count)];

                    litterCards.Add(chosen2);
                    player4Cards.Remove(chosen2);

                    chosen2.transform.parent = litterCardCol.transform;
                    chosen2.transform.position = litterCardCol.transform.position;

                    litterIMG.sprite = chosen2.GetComponent<Image>().sprite;
                }
            }

            typesCollected.Clear();
        }
    }


    //next turn

    public void ChangePlayerTurn()
    {
        if (currentPlayerTurn < gen.playerCount)
        {
            currentPlayerTurn++;
        }

        else
        {
            currentPlayerTurn = 1;
        }

        drawn = false;
        FromLitter = false;

        wonCard = null;
        playedCard = null;
        Discard = false;

       // nextToSkip = 0;

        //display cards to play
        ShowCards();

        nextPlayerBut.GetComponent<Button>().interactable = false;

        actionText.SetText("");

       
    }


    //starting game

    public void ChangeValue2()
    {
        gen.playerCount = 2;

        playerCounts.SetActive(false);

        main.SetActive(true);

        Debug.Log(gen.playerCount);

        InitialCards();

        //display cards to play
        ShowCards();
    }


    public void ChangeValue3()
    {
        gen.playerCount = 3;
        playerCounts.SetActive(false);

        main.SetActive(true);

        Debug.Log(gen.playerCount);

        InitialCards();

        //display cards to play
        ShowCards();
    }


    public void ChangeValue4()
    {
        gen.playerCount = 4;
        playerCounts.SetActive(false);

        main.SetActive(true);

        Debug.Log(gen.playerCount);

        InitialCards();

        //display cards to play
        ShowCards();
    }
}
