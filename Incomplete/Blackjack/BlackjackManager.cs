//////////////////////////////////////////////
//Assignment/Lab/Project: Blackjack Assignment
//Name: Rachel Huggins
//Section: 2023SP.SGD.213.2172
//Instructor: Brian Sowers
//Date: 03/06/2023
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlackjackManager : MonoBehaviour
{
    [SerializeField] string sceneToReload;

    [SerializeField] Sprite[] cards; // 0-12 Ace-King Club // 13-25 Ace-King Spade // 26-38 Ace-King Diamond // 39-51 Ace-King Heart // 52 Back of Card
    [SerializeField] GameObject[] playerHandDisplay; // to change display of specific card spot
    [SerializeField] GameObject[] computerHandDisplay; // to change display of specific card spot

    [SerializeField] TextMeshProUGUI housePointTextBox;
    [SerializeField] TextMeshProUGUI playerPointTextBox;

    
    int[] deckDeal = new int[52]; // used to shuffle deck
    int[] pointValueOfCard = new int[52] { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, };

    int cardToFlip;
    int hitClickCount = 0;

    bool hitOneActive = false;
    bool hitTwoActive = false;
    bool hitThreeActive = false;

    ComputerPlayer houseHand;
    HumanPlayer hand;

    // Start is called before the first frame update
    void Start()
    {
        houseHand.CardValue1 = DealRandomFirstCardToHouse();
        houseHand.CardValue2 = DealRandomSecondCardToHouse();
        houseHand.CardValue3 = 0;
        houseHand.CardValue4 = 0;
        houseHand.CardValue5 = 0;

        hand.CardValue1 = DealRandomFirstCardForHumans();
        hand.CardValue2 = DealRandomSecondCardForHumans();
        hand.CardValue3 = 0;
        hand.CardValue4 = 0;
        hand.CardValue5 = 0;

        houseHand = new ComputerPlayer(houseHand.CardValue1, houseHand.CardValue2, houseHand.CardValue3, houseHand.CardValue4, houseHand.CardValue5);
        hand = new HumanPlayer(hand.CardValue1, hand.CardValue2, hand.CardValue3, hand.CardValue4, hand.CardValue5);

        houseHand.HandValue = houseHand.CardValue1 + houseHand.CardValue2;
        hand.HandValue = hand.CardValue1 + hand.CardValue2;
    }

    // Update is called once per frame
    void Update()
    {
        houseHand = new ComputerPlayer(houseHand.CardValue1, houseHand.CardValue2, houseHand.CardValue3, houseHand.CardValue4, houseHand.CardValue5);
        hand = new HumanPlayer(hand.CardValue1, hand.CardValue2, hand.CardValue3, hand.CardValue4, hand.CardValue5);

        //keeping up with the text boxes of scores
        housePointTextBox.text = houseHand.HandValue.ToString();
        playerPointTextBox.text = hand.HandValue.ToString();

        //keeping track of the hits -- this has potential to break but im unsure how to fix it
        if (hitClickCount == 1 && hitOneActive == false)
        {
            hand.HandValue = hand.HandValue + hand.CardValue3;
            
            houseHand.CardValue3 = IfHouseHitsForThirdCard();
            houseHand.HandValue = houseHand.HandValue + houseHand.CardValue3;
        }

        if (hitClickCount == 2 && hitTwoActive == false)
        {
            hand.HandValue = hand.HandValue + hand.CardValue4;

            houseHand.CardValue4 = IfHouseHitsForFourthCard();
            houseHand.HandValue = houseHand.HandValue + houseHand.CardValue4;
        }

        if (hitClickCount == 3 && hitThreeActive == false)
        {
            hand.HandValue = hand.HandValue + hand.CardValue5;

            houseHand.CardValue4 = IfHouseHitsForLastCard();
            houseHand.HandValue = houseHand.HandValue + houseHand.CardValue5;

            //changing the card value of the first card
            computerHandDisplay[0].GetComponentInChildren<Image>().sprite = cards[cardToFlip];
        }

    }

    //handling the random cards for the house (first card) should still be a 
    int DealRandomFirstCardToHouse()
    {
        int randomIndex = Random.Range(0, deckDeal.Length);
        cardToFlip = randomIndex;
        computerHandDisplay[0].GetComponentInChildren<Image>().sprite = cards[52];
        deckDeal[randomIndex] = 1;
        houseHand.CardValue1 = pointValueOfCard[randomIndex];
        return houseHand.CardValue1;
    }

    int DealRandomSecondCardToHouse()
    {
        int randomIndex = Random.Range(0, deckDeal.Length);
        computerHandDisplay[1].GetComponentInChildren<Image>().sprite = cards[randomIndex];

        if (computerHandDisplay[1].GetComponentInChildren<Image>().sprite == computerHandDisplay[0].GetComponentInChildren<Image>().sprite && deckDeal[randomIndex] == 1)
        {
            int newRandomIndex = Random.Range(0, deckDeal.Length);
            computerHandDisplay[1].GetComponentInChildren<Image>().sprite = cards[newRandomIndex];
            deckDeal[newRandomIndex] = 1;
            houseHand.CardValue2 = pointValueOfCard[newRandomIndex];
            return houseHand.CardValue2;
        }

        deckDeal[randomIndex] = 1;
        houseHand.CardValue2 = pointValueOfCard[randomIndex];
        return houseHand.CardValue2;
    }

    int IfHouseHitsForThirdCard()
    {
        if (houseHand.HandValue < 17) // the house hits for an additional card until their hand value is 17 or greater
        {
            int randomIndex = Random.Range(0, deckDeal.Length);
            computerHandDisplay[2].GetComponentInChildren<Image>().sprite = cards[randomIndex];

            //this if statement is if the the card is the same as the ones previous
            if (computerHandDisplay[2].GetComponentInChildren<Image>().sprite == computerHandDisplay[1].GetComponentInChildren<Image>().sprite && deckDeal[randomIndex] == 1)
            {
                int newRandomIndex = Random.Range(0, deckDeal.Length);
                computerHandDisplay[2].GetComponentInChildren<Image>().sprite = cards[newRandomIndex];
                deckDeal[newRandomIndex] = 1;
                houseHand.CardValue3 = pointValueOfCard[newRandomIndex];
                houseHand.HandValue = houseHand.HandValue + houseHand.CardValue3;
                return houseHand.HandValue; //returns the new hand value to be called later
            }
            deckDeal[randomIndex] = 1;
            houseHand.CardValue3 = pointValueOfCard[randomIndex];
            houseHand.HandValue = houseHand.HandValue + houseHand.CardValue3;
            return houseHand.HandValue; //returns the hand value if the card isn't repeated originally
        }
        else
        {
            return houseHand.HandValue; //returns the hand value if the value is already 17+ with the original two cards in hand
        }
    }

    int IfHouseHitsForFourthCard()
    {
        if (houseHand.HandValue < 17) // the house hits for an additional card until their hand value is 17 or greater
        {
            int randomIndex = Random.Range(0, deckDeal.Length);
            computerHandDisplay[3].GetComponentInChildren<Image>().sprite = cards[randomIndex];

            //this if statement is if the the card is the same as the ones previous
            if (computerHandDisplay[3].GetComponentInChildren<Image>().sprite == computerHandDisplay[2].GetComponentInChildren<Image>().sprite && deckDeal[randomIndex] == 1)
            {
                int newRandomIndex = Random.Range(0, deckDeal.Length);
                computerHandDisplay[3].GetComponentInChildren<Image>().sprite = cards[newRandomIndex];
                deckDeal[newRandomIndex] = 1;
                houseHand.CardValue4 = pointValueOfCard[newRandomIndex];
                houseHand.HandValue = houseHand.HandValue + houseHand.CardValue4;
                return houseHand.HandValue; //returns the new hand value to be called later
            }
            deckDeal[randomIndex] = 1;
            houseHand.CardValue4 = pointValueOfCard[randomIndex];
            houseHand.HandValue = houseHand.HandValue + houseHand.CardValue4;
            return houseHand.HandValue; //returns the hand value if the card isn't repeated originally
        }
        else
        {
            return houseHand.HandValue; //returns the hand value if the value is already 17+ with the original two cards in hand + the third card
        }
    }

    int IfHouseHitsForLastCard()
    {
        if (houseHand.HandValue < 17) // the house hits for an additional card until their hand value is 17 or greater
        {
            int randomIndex = Random.Range(0, deckDeal.Length);
            computerHandDisplay[4].GetComponentInChildren<Image>().sprite = cards[randomIndex];

            //this if statement is if the the card is the same as the ones previous
            if (computerHandDisplay[4].GetComponentInChildren<Image>().sprite == computerHandDisplay[3].GetComponentInChildren<Image>().sprite && deckDeal[randomIndex] == 1)
            {
                int newRandomIndex = Random.Range(0, deckDeal.Length);
                computerHandDisplay[4].GetComponentInChildren<Image>().sprite = cards[newRandomIndex];
                deckDeal[newRandomIndex] = 1;
                houseHand.CardValue5 = pointValueOfCard[newRandomIndex];
                houseHand.HandValue = houseHand.HandValue + houseHand.CardValue5;
                return houseHand.HandValue; //returns the new hand value to be called later
            }
            deckDeal[randomIndex] = 1;
            houseHand.CardValue5 = pointValueOfCard[randomIndex];
            houseHand.HandValue = houseHand.HandValue + houseHand.CardValue5;
            return houseHand.HandValue; //returns the hand value if the card isn't repeated originally
        }
        else
        {
            return houseHand.HandValue; //all card slots are filled at this point, so its all or nothing
        }
    }

    //handling humann blackjack hands
    int DealRandomFirstCardForHumans()
    {
        int randomIndex = Random.Range(0, deckDeal.Length);
        playerHandDisplay[0].GetComponentInChildren<Image>().sprite = cards[randomIndex];
        hand.CardValue1 = pointValueOfCard[randomIndex];

        if (hand.CardValue1 == houseHand.CardValue1 && deckDeal[randomIndex] == 1) //have to write this if statement like this because of how i set up the sprites to change upon reveal
        {
            int newRandomIndex = Random.Range(0, deckDeal.Length);
            playerHandDisplay[0].GetComponentInChildren<Image>().sprite = cards[newRandomIndex];
            deckDeal[newRandomIndex] = 1;
            hand.CardValue1 = pointValueOfCard[newRandomIndex];
            return hand.CardValue1;
        }

        deckDeal[randomIndex] = 1;
        hand.CardValue1 = pointValueOfCard[randomIndex];
        return hand.CardValue1;
    }

    int DealRandomSecondCardForHumans()
    {
        int randomIndex = Random.Range(0, deckDeal.Length);
        playerHandDisplay[1].GetComponentInChildren<Image>().sprite = cards[randomIndex];

        if (playerHandDisplay[1].GetComponentInChildren<Image>().sprite == playerHandDisplay[0].GetComponentInChildren<Image>().sprite && deckDeal[randomIndex] == 1)
        {
            int newRandomIndex = Random.Range(0, deckDeal.Length);
            computerHandDisplay[1].GetComponentInChildren<Image>().sprite = cards[newRandomIndex];
            deckDeal[newRandomIndex] = 1;
            return pointValueOfCard[newRandomIndex];
        }

        deckDeal[randomIndex] = 1;
        return pointValueOfCard[randomIndex];
    }

    public void HitOnCLick() //to change the value and add a card if player hits the deck for a card to attempt to beat the house
    {
        hitClickCount++;
        //changes the third card slot
        if (playerHandDisplay[2].GetComponentInChildren<Image>().sprite == null)
        {
            int randomIndex = Random.Range(0, deckDeal.Length);
            playerHandDisplay[2].GetComponentInChildren<Image>().sprite = cards[randomIndex];

            if (playerHandDisplay[2].GetComponentInChildren<Image>().sprite == playerHandDisplay[1].GetComponentInChildren<Image>().sprite && deckDeal[randomIndex] == 1)
            {
                int newRandomIndex = Random.Range(0, deckDeal.Length);
                playerHandDisplay[2].GetComponentInChildren<Image>().sprite = cards[newRandomIndex];
                deckDeal[newRandomIndex] = 1;
                hand.CardValue3 = pointValueOfCard[newRandomIndex];
                hitOneActive = true;
            }

            deckDeal[randomIndex] = 1;
            hand.CardValue3 = pointValueOfCard[randomIndex];
            hitOneActive = true;
        }

        //changes the fourth card slot
        if (playerHandDisplay[2].GetComponentInChildren<Image>().sprite != null && playerHandDisplay[3].GetComponentInChildren<Image>().sprite == null)
        {
            int randomIndex = Random.Range(0, deckDeal.Length);
            playerHandDisplay[3].GetComponentInChildren<Image>().sprite = cards[randomIndex];

            if (playerHandDisplay[3].GetComponentInChildren<Image>().sprite == playerHandDisplay[2].GetComponentInChildren<Image>().sprite && deckDeal[randomIndex] == 1)
            {
                int newRandomIndex = Random.Range(0, deckDeal.Length);
                playerHandDisplay[3].GetComponentInChildren<Image>().sprite = cards[newRandomIndex];
                deckDeal[newRandomIndex] = 1;
                hand.CardValue4 = pointValueOfCard[newRandomIndex];
                hitTwoActive = true;
            }

            deckDeal[randomIndex] = 1;
            hand.CardValue4 = pointValueOfCard[randomIndex];
            hitTwoActive = true;
            houseHand.CardValue4 = IfHouseHitsForFourthCard();
        }

        //changes the last card slot
        if (playerHandDisplay[3].GetComponentInChildren<Image>().sprite != null && playerHandDisplay[4].GetComponentInChildren<Image>().sprite == null)
        {
            int randomIndex = Random.Range(0, deckDeal.Length);
            playerHandDisplay[3].GetComponentInChildren<Image>().sprite = cards[randomIndex];

            if (playerHandDisplay[4].GetComponentInChildren<Image>().sprite == playerHandDisplay[3].GetComponentInChildren<Image>().sprite && deckDeal[randomIndex] == 1)
            {
                int newRandomIndex = Random.Range(0, deckDeal.Length);
                playerHandDisplay[4].GetComponentInChildren<Image>().sprite = cards[newRandomIndex];
                deckDeal[newRandomIndex] = 1;
                hand.CardValue5 = pointValueOfCard[newRandomIndex];
                hitThreeActive = true;
            }

            deckDeal[randomIndex] = 1;
            hand.CardValue5 = pointValueOfCard[randomIndex];
            hitThreeActive = true;
            houseHand.CardValue5 = IfHouseHitsForLastCard();
        }
    }

    void CheckingForAces(int moreThanOneAce)
    {

    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

}
