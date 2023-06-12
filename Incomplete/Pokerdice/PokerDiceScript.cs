//////////////////////////////////////////////
//Assignment/Lab/Project: Poker Dice Assignment
//Name: Rachel Huggins
//Section: 2023SP.SGD.213.2172
//Instructor: Brian Sowers
//Date: 01/16/2023
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PokerDiceScript : MonoBehaviour
{
    [Header("Buttons")] //catergory for buttons
    [SerializeField] Button playButton;
    [SerializeField] Button rollButton;
    [SerializeField] Button showHandButton;
    [SerializeField] Button playAgainButton;
    [SerializeField] Button quitButton;
    
    [Header("Text Fields")] //catergory for text fields that are changed/set to false
    [SerializeField] TextMeshProUGUI gameMessageText;
    [SerializeField] TextMeshProUGUI rulesGameText;
   
    [SerializeField] TextMeshProUGUI playerDiceOneText;
    [SerializeField] TextMeshProUGUI playerDiceTwoText;
    [SerializeField] TextMeshProUGUI playerDiceThreeText;
    [SerializeField] TextMeshProUGUI playerDiceFourText;
    [SerializeField] TextMeshProUGUI playerDiceFiveText;
    
    [SerializeField] TextMeshProUGUI computerDiceOneText;
    [SerializeField] TextMeshProUGUI computerDiceTwoText;
    [SerializeField] TextMeshProUGUI computerDiceThreeText;
    [SerializeField] TextMeshProUGUI computerDiceFourText;
    [SerializeField] TextMeshProUGUI computerDiceFiveText;

    [Header("Panels To Activate")] //setting computer dice to be visible
    [SerializeField] GameObject computerDiceReveal;

    [Header("Interactables")] //category for integers to see if they work in the inspector window
    [SerializeField] int numberOfRolls;


    //text fields to strings variable set up
    string playerDiceOneToString;
    string playerDiceTwoToString;
    string playerDiceThreeToString;
    string playerDiceFourToString;
    string playerDiceFiveToString;

    string computerDiceOneToString;
    string computerDiceTwoToString;
    string computerDiceThreeToString;
    string computerDiceFourToString;
    string computerDiceFiveToString;


    //array(s) of dice
    string[] diceRolled = new string[5]; //{ playerDiceOneToString, playerDiceTwoToString, playerDiceThreeToString, playerDiceFourToString, playerDiceFiveToString };
    string[] computerDiceRolled = new string[5]; //computers dice
    string[] amountOnDiceRolled = new string[6];
    //list(s) of player dice

    //integers for rules to reference
    string rolledOne = "1";
    string rolledTwo = "2";
    string rolledThree = "3";
    string rolledFour = "4";
    string rolledFive = "5";
    string rolledSix = "6";


    //bools for comparison
    bool onePairPlayer = false;
    bool twoPairPlayer = false;
    bool threeOfAKindPlayer = false;
    bool fourOfAKindPlayer = false;
    bool fiveOfAKindPlayer = false;
    bool fullHousePlayer = false;

    bool onePairComputer = false ;
    bool twoPairComputer = false;
    bool threeOfAKindComputer = false;
    bool fourOfAKindComputer = false;
    bool fiveOfAKindComputer = false ;
    bool fullHouseComputer = false;

    private void Start() //initializing necessary meaning to arrays
    {
        diceRolled[0] = playerDiceOneToString; //player dice 1
        diceRolled[1] = playerDiceTwoToString; //player dice 2
        diceRolled[2] = playerDiceThreeToString; //player dice 3
        diceRolled[3] = playerDiceFourToString; //player dice 4
        diceRolled[4] = playerDiceFiveToString; //player dice 5

        computerDiceRolled[0] = computerDiceOneToString; //computer dice 1
        computerDiceRolled[1] = computerDiceTwoToString; //computer dice 2
        computerDiceRolled[2] = computerDiceThreeToString; //computer dice 3
        computerDiceRolled[3] = computerDiceFourToString; //computer dice 4
        computerDiceRolled[4] = computerDiceFiveToString; //computer dice 5

        amountOnDiceRolled[0] = rolledOne;
        amountOnDiceRolled[1] = rolledTwo;
        amountOnDiceRolled[2] = rolledThree;
        amountOnDiceRolled[3] = rolledFour;
        amountOnDiceRolled[4] = rolledFive;
        amountOnDiceRolled[5] = rolledSix;

        string nothing = "";
        gameMessageText.text = nothing;
    }

    void PlayerOnePair() //seeing if the player has a pair
    {
        string pair = "I see a pair!";

        for (int diceNumberIndex = 0; diceNumberIndex < diceRolled.Length; diceNumberIndex++)
        {
            for (int diceAmountIndex = 0; diceAmountIndex < amountOnDiceRolled.Length; diceAmountIndex++)
            {
                if (diceRolled[diceNumberIndex] == diceRolled[0] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex]) //seeing if the 1st dice matches any other
                {
                    gameMessageText.SetText(pair);
                    onePairPlayer = true;
                    Debug.Log("1");
                }

                if (diceRolled[diceNumberIndex] == diceRolled[1] && diceRolled[1] == amountOnDiceRolled[diceAmountIndex]) //seeing if the 2nd dice matching any other
                {
                    gameMessageText.SetText(pair);
                    onePairPlayer = true;
                    Debug.Log("3");
                }

                if (diceRolled[diceNumberIndex] == diceRolled[2] && diceRolled[2] == amountOnDiceRolled[diceAmountIndex]) //seeing if the 3rd dice matching any other
                {
                    gameMessageText.SetText(pair);
                    onePairPlayer = true;
                    Debug.Log("5");
                }

                if (diceRolled[diceNumberIndex] == diceRolled[3] && diceRolled[3] == amountOnDiceRolled[diceAmountIndex]) //seeing if the 4th dice matchings any other
                {
                    gameMessageText.SetText(pair);
                    onePairPlayer = true;
                    Debug.Log("7");
                }

                if (diceRolled[diceNumberIndex] == diceRolled[4] && diceRolled[4] == amountOnDiceRolled[diceAmountIndex]) //seeing if the 5th dice matching any other
                {
                    gameMessageText.SetText(pair);
                    onePairPlayer = true;
                    Debug.Log("9");
                }
            }
        }
    }

    void ComputerOnePair() //seeing if the computer has a pair
    {
        for (int diceNumberIndex = 0; diceNumberIndex < computerDiceRolled.Length; diceNumberIndex++)
        {
            for (int diceAmountIndex = 0; diceAmountIndex < amountOnDiceRolled.Length; diceAmountIndex++)
            {
                if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[0] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                //seeing if the 1st dice rolled by the computer matches any other
                {
                    onePairComputer = true;
                }

                if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[1] && computerDiceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                //seeing if the 2nd dice rolled by the computer matches any other
                {
                    onePairComputer= true;
                }

                if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[2] && computerDiceRolled[2] == amountOnDiceRolled[diceAmountIndex])
                //seeing if the 3rd dice rolled by the computer matches any other
                {
                    onePairComputer = true;
                }

                if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[3] && computerDiceRolled[3] == amountOnDiceRolled[diceAmountIndex])
                //seeing if the 4th dice rolled by the computer matches any other
                {
                    onePairComputer = true;
                }

                if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[4] && computerDiceRolled[4] == amountOnDiceRolled[diceAmountIndex])
                //seeing if the 5th dice rolled by the computer matches any other
                {
                    onePairComputer = true;
                }
            }
        }
    }

    void PlayerTwoPair() //seeing if the player has two pairs
    {
        string twoPair = "I see Two Pairs!";

        for (int diceNumberIndex = 0; diceNumberIndex < diceRolled.Length; diceNumberIndex++)
        {
            for (int diceAmountIndex = 0; diceAmountIndex < amountOnDiceRolled.Length; diceAmountIndex++)
            {
                if (diceRolled[diceNumberIndex] == diceRolled[0] && diceRolled[diceNumberIndex] == diceRolled[1])
                {
                    if (diceRolled[0] == amountOnDiceRolled[diceAmountIndex] && diceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 1st die and the 2nd die match any other dice to form two pairs
                    {
                        gameMessageText.text = twoPair;
                        twoPairPlayer = true;
                    }
                }


                else if (diceRolled[diceNumberIndex] == diceRolled[0] && diceRolled[diceNumberIndex] == diceRolled[2])
                {
                    if (diceRolled[0] == amountOnDiceRolled[diceAmountIndex] && diceRolled[2] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 1st die and the 3rd die match any other dice to form two pairs
                    {
                        gameMessageText.text = twoPair;
                        twoPairPlayer = true;
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[0] && diceRolled[diceNumberIndex] == diceRolled[3])
                {
                    if (diceRolled[0] == amountOnDiceRolled[diceAmountIndex] && diceRolled[3] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the the 1st die and the 4th die match any other dice to form two pair
                    {
                        gameMessageText.text = twoPair;
                        twoPairPlayer = true;
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[0] && diceRolled[diceNumberIndex] == diceRolled[4])
                {
                    if (diceRolled[0] == amountOnDiceRolled[diceAmountIndex] && diceRolled[4] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 1st die and the 5th die match any other dice to form two pair
                    {
                        gameMessageText.text = twoPair;
                        twoPairPlayer = true;
                    }
                }
                else if (diceRolled[diceNumberIndex] == diceRolled[1] && diceRolled[diceNumberIndex] == diceRolled[2])
                {
                    if (diceRolled[1] == amountOnDiceRolled[diceAmountIndex] && diceRolled[2] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 2nd die and the 3rd die match any other die to form two pairs
                    {
                        gameMessageText.text = twoPair;
                        twoPairPlayer = true;
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[1] && diceRolled[diceNumberIndex] == diceRolled[3])
                {
                    if (diceRolled[1] == amountOnDiceRolled[diceAmountIndex] && diceRolled[3] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 2nd die and the 4th die match any other dice to form two pairs
                    {
                        gameMessageText.text = twoPair;
                        twoPairPlayer = true;
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[1] && diceRolled[diceNumberIndex] == diceRolled[4])
                {
                    if (diceRolled[1] == amountOnDiceRolled[diceAmountIndex] && diceRolled[4] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 2nd die and the 5th die match any other dice to form two pairs
                    {
                        gameMessageText.text = twoPair;
                        twoPairPlayer = true;
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[2] && diceRolled[diceNumberIndex] == diceRolled[3])
                {
                    if (diceRolled[2] == amountOnDiceRolled[diceAmountIndex] && diceRolled[3] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 3rd die and the 4th die match any other dice to form two pairs
                    {
                        gameMessageText.text = twoPair;
                        twoPairPlayer = true;
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[2] && diceRolled[diceNumberIndex] == diceRolled[4])
                {
                    if (diceRolled[2] == amountOnDiceRolled[diceAmountIndex] && diceRolled[4] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 3rd die and the 5th die match any other dice to form two pairs
                    {
                        gameMessageText.text = twoPair;
                        twoPairPlayer = true;
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[3] && diceRolled[diceNumberIndex] == diceRolled[4])
                {
                    if (diceRolled[3] == amountOnDiceRolled[diceAmountIndex] && diceRolled[4] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 4th die and the 5th die match any other dice to form two pairs
                    {
                        gameMessageText.text = twoPair;
                        twoPairPlayer = true;
                    }
                }
            }
        }
    }

    void ComputerTwoPair() //seeing if the computer has two pair
    {
        for (int diceNumberIndex = 0; diceNumberIndex < diceRolled.Length; diceNumberIndex++)
        {
            for (int diceAmountIndex = 0; diceAmountIndex < amountOnDiceRolled.Length; diceAmountIndex++)
            {
                if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[0] && computerDiceRolled[diceNumberIndex] == computerDiceRolled[1])
                {
                    if (computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex] && computerDiceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 1st die and the 2nd die match any other dice to form two pairs
                    {
                        twoPairComputer = true;
                    }
                }


                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[0] && computerDiceRolled[diceNumberIndex] == computerDiceRolled[2])
                {
                    if (computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex] && computerDiceRolled[2] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 1st die and the 3rd die match any other dice to form two pairs
                    {
                        twoPairComputer = true;
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[0] && computerDiceRolled[diceNumberIndex] == computerDiceRolled[3])
                {
                    if (computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex] && computerDiceRolled[3] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the the 1st die and the 4th die match any other dice to form two pair
                    {
                        twoPairComputer = true;
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[0] && computerDiceRolled[diceNumberIndex] == computerDiceRolled[4])
                {
                    if (computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex] && computerDiceRolled[4] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 1st die and the 5th die match any other dice to form two pair
                    {
                        twoPairComputer = true;
                    }
                }
                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[1] && computerDiceRolled[diceNumberIndex] == computerDiceRolled[2])
                {
                    if (computerDiceRolled[1] == amountOnDiceRolled[diceAmountIndex] && computerDiceRolled[2] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 2nd die and the 3rd die match any other die to form two pairs
                    {
                        twoPairComputer = true;
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[1] && computerDiceRolled[diceNumberIndex] == computerDiceRolled[3])
                {
                    if (computerDiceRolled[1] == amountOnDiceRolled[diceAmountIndex] && computerDiceRolled[3] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 2nd die and the 4th die match any other dice to form two pairs
                    {
                        twoPairComputer = true;
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[1] && computerDiceRolled[diceNumberIndex] == computerDiceRolled[4])
                {
                    if (computerDiceRolled[1] == amountOnDiceRolled[diceAmountIndex] && computerDiceRolled[4] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 2nd die and the 5th die match any other dice to form two pairs
                    {
                        twoPairComputer = true;
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[2] && computerDiceRolled[diceNumberIndex] == computerDiceRolled[3])
                {
                    if (computerDiceRolled[2] == amountOnDiceRolled[diceAmountIndex] && computerDiceRolled[3] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 3rd die and the 4th die match any other dice to form two pairs
                    {
                        twoPairComputer = true;
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[2] && computerDiceRolled[diceNumberIndex] == computerDiceRolled[4])
                {
                    if (computerDiceRolled[2] == amountOnDiceRolled[diceAmountIndex] && computerDiceRolled[4] == amountOnDiceRolled[diceAmountIndex])
                    //seeing if the 3rd die and the 5th die match any other dice to form two pairs
                    {
                        twoPairComputer = true;
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[3] && computerDiceRolled[diceNumberIndex] == computerDiceRolled[4])
                {
                    if (computerDiceRolled[3] == amountOnDiceRolled[diceAmountIndex] && computerDiceRolled[4] == amountOnDiceRolled[diceAmountIndex])
                    ////seeing if the 4th die and the 5th die match any other dice to form two pairs
                    {
                        twoPairComputer = true;
                    }
                }
            }
        }
    }

    void PlayerThreeOfAKind()
    {
        string threeKinds = "I see three of a kind!";

        for (int diceNumberIndex = 0; diceNumberIndex < diceRolled.Length; diceNumberIndex++)
        {
            for (int diceAmountIndex = 0; diceAmountIndex < amountOnDiceRolled.Length; diceAmountIndex++)
            {
                if (diceRolled[diceNumberIndex] == diceRolled[0] && diceRolled[0] == diceRolled[1])
                {
                    if (diceRolled[1] == diceRolled[2] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing player 1st, 2nd and 3rd dice to see if they make three of a kind
                    {
                        gameMessageText.text = threeKinds;
                        threeOfAKindPlayer = true;
                    }
                    else if (diceRolled[1] == diceRolled[3] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing player 1st, 2nd and 4th dice to see if they make three of a kind
                    {
                        gameMessageText.text = threeKinds;
                        threeOfAKindPlayer = true;
                    }
                    else if (diceRolled[1] == diceRolled[4] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing player 1st, 2nd and 5th dice to see if they make three of a kind
                    {
                        gameMessageText.text = threeKinds;
                        threeOfAKindPlayer = true;
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[1] && diceRolled[1] == diceRolled[2])
                {
                    if (diceRolled[2] == diceRolled[3] && diceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    //comparing player 2nd, 3rd and 4th dice to see if they make three of a kind
                    {
                        gameMessageText.text = threeKinds;
                        threeOfAKindPlayer = true;
                    }
                    else if (diceRolled[2] == diceRolled[4] && diceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    //comparing player 2nd, 3rd and 5th dice to see if they make three of a kind
                    {
                        gameMessageText.text =  threeKinds;
                        threeOfAKindPlayer = true;
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[2] && diceRolled[2] == diceRolled[3])
                {
                    if (diceRolled[3] == diceRolled[4] && diceRolled[2] == amountOnDiceRolled[diceAmountIndex])
                    //comparing player 3rd, 4th and 5th dice to see if they make three of a kind
                    {
                        gameMessageText.text = threeKinds;
                        threeOfAKindPlayer = true;
                    }
                }
            }
        }
    } //seeing if the player has three of a kind

    void ComputerThreeOfAKind() //seeing if the computer has three of a kind
    {
        for (int diceNumberIndex = 0; diceNumberIndex < diceRolled.Length; diceNumberIndex++)
        {
            for (int diceAmountIndex = 0; diceAmountIndex < amountOnDiceRolled.Length; diceAmountIndex++)
            {
                if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[0] && computerDiceRolled[0] == computerDiceRolled[1])
                {
                    if (computerDiceRolled[1] == computerDiceRolled[2] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing computer dice 1st, 2nd and 3rd to see if they make three of a kind
                    {
                        threeOfAKindComputer = true;
                    }
                    else if (computerDiceRolled[1] == computerDiceRolled[3] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing computer dice 1st, 2nd and 4th to see if they make three of a kind
                    {
                        threeOfAKindComputer = true;
                    }
                    else if (computerDiceRolled[1] == computerDiceRolled[4] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing computer dice 1st, 2nd and 5th to see if they make three of a kind
                    {
                        threeOfAKindComputer = true;
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[1] && computerDiceRolled[1] == computerDiceRolled[2])
                {
                    if (computerDiceRolled[2] == computerDiceRolled[3] && computerDiceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    //comparing computer dice 2nd, 3rd and 4th to see if they make three of a kind
                    {
                        threeOfAKindComputer = true;
                    }
                    else if (computerDiceRolled[2] == computerDiceRolled[4] && computerDiceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    //comparing computer dice 2nd, 3rd and 5th to see if they make three of a kind
                    {
                        threeOfAKindComputer = true;
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[2] && computerDiceRolled[2] == computerDiceRolled[3])
                {
                    if (computerDiceRolled[3] == computerDiceRolled[4] && computerDiceRolled[2] == amountOnDiceRolled[diceAmountIndex])
                    //comparing computer dice 3rd, 4th and 5th to see if they make three of a kind
                    {
                        threeOfAKindComputer = true;
                    }
                }
            }
        }
    }

    void PlayerFullHouse() //seeing if the player has a full house
    {
        string hasFullHouse = "I see a Full House!";

        for (int diceNumberIndex = 0; diceNumberIndex < diceRolled.Length; diceNumberIndex++)
        {
            for (int diceAmountIndex = 0; diceAmountIndex < amountOnDiceRolled.Length; diceAmountIndex++)
            {
                if (diceRolled[diceNumberIndex] == diceRolled[0] && diceRolled[0] == diceRolled[1])
                {
                    if (diceRolled[1] == diceRolled[2] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing player dice 1st, 2nd and 3rd to see if they make three of a kind
                    {
                        if (diceRolled[3] == diceRolled[4])
                        //comparing if dice 4th and 5th make a pair to form a full house
                        {
                            gameMessageText.text = hasFullHouse;
                            fullHousePlayer = true;
                        }
                    }
                    else if (diceRolled[1] == diceRolled[3] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing to see if dice 1st, 2nd and 4th make a three of a kind
                    {
                        if (diceRolled[2] == diceRolled[4])
                        //comparing to see if dice 3rd and 5th make a pair to form a full house
                        {
                            gameMessageText.text = hasFullHouse;
                            fullHousePlayer = true;
                        }
                    }
                    else if (diceRolled[1] == diceRolled[4] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing to see if dice 1st, 2nd and 5th make three of a kind
                    {
                        if (diceRolled[2] == diceRolled[3])
                        //comparing to see if dice 3rd and 4th for a pair to form a full house
                        {
                            gameMessageText.text = hasFullHouse;
                            fullHousePlayer = true;
                        }
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[1] && diceRolled[1] == diceRolled[2])
                {
                    if (diceRolled[2] == diceRolled[3] && diceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    //comparing to see if dice 2nd, 3rd, and 4th make three of a kind
                    {
                        if (diceRolled[0] == diceRolled[4])
                        //comparing to see if 1st and 5th dice make a pair to form a full house
                        {
                            gameMessageText.text = hasFullHouse;
                            fullHousePlayer = true;
                        }
                    }
                    else if (diceRolled[2] == diceRolled[4] && diceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    //comparing to see if dice 2nd, 3rd and 5th make three of a kind
                    {
                        if (diceRolled[0] == diceRolled[3])
                        //compairing to see if dice 1st and 4th make a pair to form a full house
                        {
                            gameMessageText.text = hasFullHouse;
                            fullHousePlayer = true;
                        }
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[2] && diceRolled[2] == diceRolled[3])
                //comparing if dice 3rd, 4th and 5th make three of kind
                {
                    if (diceRolled[3] == diceRolled[4] && diceRolled[2] == amountOnDiceRolled[diceAmountIndex])
                    //compairing to see if dice 1st and 2nd make a pair to form a full house
                    {
                        if (diceRolled[1] == diceRolled[0])
                        {
                                gameMessageText.text = hasFullHouse;
                                fullHousePlayer = true;
                        }
                    }
                }
            }
        }
    }

    void ComputerFullHouse() //seeing if the computer has a full house
    {
        for (int diceNumberIndex = 0; diceNumberIndex < diceRolled.Length; diceNumberIndex++)
        {
            for (int diceAmountIndex = 0; diceAmountIndex < amountOnDiceRolled.Length; diceAmountIndex++)
            {
                if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[0] && computerDiceRolled[0] == computerDiceRolled[1])
                {
                    if (computerDiceRolled[1] == computerDiceRolled[2] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing to see if dice 1, 2 and 3 make three of a kind
                    {
                        if (computerDiceRolled[3] == computerDiceRolled[4])
                        //comparing to see if dice 4 and 5 make a pair to form a full house
                        {
                            fullHouseComputer = true;
                        }
                    }
                    else if (computerDiceRolled[1] == computerDiceRolled[3] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing dice 1, 2, and 4 to see if they make three of kind
                    {
                        if (computerDiceRolled[2] == computerDiceRolled[4])
                        //comparing dice 3 and 5 to see if they make a pair to form a full house
                        {
                            fullHouseComputer = true;
                        }
                    }
                    else if (computerDiceRolled[1] == computerDiceRolled[4] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    //comparing dice 1, 2, and 5 to see if they make three of kind
                    {
                        if (computerDiceRolled[2] == computerDiceRolled[3])
                        //comparing dice 3 and 4 to see if they make a pair to form a full house
                        {
                            fullHouseComputer = true;
                        }

                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[1] && diceRolled[1] == diceRolled[2])
                {
                    if (computerDiceRolled[2] == computerDiceRolled[3] && computerDiceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    //comparing dice 2, 3, and 4 to see if they form three of a kind
                    {
                        if (computerDiceRolled[0] == computerDiceRolled[4])
                        //comparind dice 1 and 5 to see if they form a pair to make a full house
                        {
                            fullHouseComputer = true;
                        }
                    }
                    else if (computerDiceRolled[2] == computerDiceRolled[4] && computerDiceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    //comparing dice 2, 3, and 5 to see if they form three of a kind
                    {
                        if (computerDiceRolled[0] == computerDiceRolled[3])
                        //comparing dice 1 and 4 if they make a pair to form a full house
                        {
                            fullHouseComputer = true;
                        }
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[2] && computerDiceRolled[2] == computerDiceRolled[3])
                {
                    if (computerDiceRolled[3] == computerDiceRolled[4] && computerDiceRolled[2] == amountOnDiceRolled[diceAmountIndex])
                    //comparind dice 3, 4 and 5 to see if they make three of kind
                    {
                        if (computerDiceRolled[1] == computerDiceRolled[0])
                        //comparing dice 1 and 2 to see if they make a pair to form a full house
                        {
                            fullHouseComputer = true;
                        }
                    }
                }
            }
        }
    }

    void PlayerFourOfAKind() //seeing if the player has four of a kind in hand
    {
        string hasFour = "I see a Four of a Kind!";

        for (int diceNumberIndex = 0; diceNumberIndex < diceRolled.Length; diceNumberIndex++)
        {
            for (int diceAmountIndex = 0; diceAmountIndex < amountOnDiceRolled.Length; diceAmountIndex++)
            {
                if (diceRolled[diceNumberIndex] == diceRolled[0] && diceRolled[0] == diceRolled[1])
                {
                    if (diceRolled[1] == diceRolled[2] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    {
                        if (diceRolled[3] == diceRolled[0])
                        //comparing dice 1, 2, 3, and 4 to see if they make four of a kind
                        {
                            gameMessageText.text = hasFour;
                            fourOfAKindPlayer = true;
                        }
                    }
                    else if (diceRolled[1] == diceRolled[2] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    {
                        if (diceRolled[4] == diceRolled[0])
                        //comparing dice 1, 2, 3, 5 to see if they make four of a kind
                        {
                            gameMessageText.text = hasFour;
                            fourOfAKindPlayer = true;
                        }
                    }

                    else if (diceRolled[1] == diceRolled[3] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    {
                        if (diceRolled[4] == diceRolled[0])
                        //comparing dice 1, 2, 4 and 5 to see if they make four of a kind
                        {
                            gameMessageText.text = hasFour;
                            fourOfAKindPlayer = true;
                        }
                    }
                }

                else if (diceRolled[diceNumberIndex] == diceRolled[0] && diceRolled[0] == diceRolled[2])
                {
                    if (diceRolled[2] == diceRolled[3] && diceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    {
                        if (diceRolled[4] == diceRolled[0])
                        //comparing dice 1, 3, 4 and 5 to see if they make four of a kind
                        {
                            gameMessageText.text = hasFour;
                            fourOfAKindPlayer = true;
                        }
                    }
                }
                else if (diceRolled[diceNumberIndex] == diceRolled[1] && diceRolled[1] == diceRolled[2])
                {
                    if (diceRolled[2] == diceRolled[3] && diceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    {
                        if (diceRolled[4] == diceRolled[1])
                        //comparing dice 2, 3, 4 and 5 to see if they make four of a kind
                        {
                            gameMessageText.text = hasFour;
                            fourOfAKindPlayer = true;
                        }
                    }
                }

            }
        }
    }

    void ComputerFourOfAKind() //seeing if the computer has four of kind in hand
    {
        for (int diceNumberIndex = 0; diceNumberIndex < diceRolled.Length; diceNumberIndex++)
        {
            for (int diceAmountIndex = 0; diceAmountIndex < amountOnDiceRolled.Length; diceAmountIndex++)
            {
                if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[0] && computerDiceRolled[0] == computerDiceRolled[1])
                {
                    if (computerDiceRolled[1] == computerDiceRolled[2] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    {
                        if (computerDiceRolled[3] == computerDiceRolled[0])
                        //comparing dice 1, 2, 3 and 4 to see if they make four of a kind
                        {
                            fourOfAKindComputer |= true;
                        }
                    }
                    else if (computerDiceRolled[1] == computerDiceRolled[2] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    {
                        if (computerDiceRolled[4] == computerDiceRolled[0])
                        //comparing dice 1, 2, 3, and 5 to see if they make four of a kind
                        {
                            fourOfAKindComputer = true;
                        }
                    }

                    else if (computerDiceRolled[1] == computerDiceRolled[3] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    {
                        if (computerDiceRolled[4] == computerDiceRolled[0])
                        //comparing dice 1, 2, 4 and 5 to see if they make four of a kind
                        {
                            fourOfAKindComputer = true;
                        }
                    }
                }

                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[0] && computerDiceRolled[0] == computerDiceRolled[2])
                {
                    if (computerDiceRolled[2] == computerDiceRolled[3] && computerDiceRolled[0] == amountOnDiceRolled[diceAmountIndex])
                    {
                        if (computerDiceRolled[4] == computerDiceRolled[0])
                        //comparing dice 1, 3, 4, and 5 to find to they make four of a kind
                        {
                            fourOfAKindComputer = true;
                        }
                    }
                }
                else if (computerDiceRolled[diceNumberIndex] == computerDiceRolled[1] && computerDiceRolled[1] == computerDiceRolled[2])
                {
                    if (computerDiceRolled[2] == computerDiceRolled[3] && computerDiceRolled[1] == amountOnDiceRolled[diceAmountIndex])
                    {
                        if (computerDiceRolled[4] == computerDiceRolled[1])
                        //comparing dice 2, 3, 4 and 5 to find if they make four of kind
                        {
                            fourOfAKindComputer = true;
                        }
                    }
                }
            }
        }
    }

    void PlayerFiveOfAKind() //seeing if the player has five of a kind in hand
    {
        string hasFive = "I see Five of a Kind!";
        for (int diceRollIndex = 0; diceRollIndex < diceRolled.Length; diceRollIndex++) 
        {
            if (diceRolled[diceRollIndex] == diceRolled[0] && diceRolled[0] == diceRolled[1] && diceRolled[1] == diceRolled[2] && diceRolled[2] == diceRolled[3] && diceRolled[3] == diceRolled[4])
            {
                gameMessageText.text = hasFive;
                fiveOfAKindPlayer = true;
            }
        }
    }

    void ComputerFiveOfAKind() //seeing if the computer has five of a kind
    {
        for (int diceRollIndex = 0; diceRollIndex < computerDiceRolled.Length; diceRollIndex++)
        {
            if (computerDiceRolled[diceRollIndex] == computerDiceRolled[0] && computerDiceRolled[0] == computerDiceRolled[1] && computerDiceRolled[1] == computerDiceRolled[2] && computerDiceRolled[2] == computerDiceRolled[3] && computerDiceRolled[3] == computerDiceRolled[4])
            {
                fiveOfAKindComputer = true;
            }
        }
    }

    void ComparingComputerRollsToPlayerRolls() //this compares dice hands between computer to player
    {
        //comparing one pair
        if (onePairPlayer == onePairComputer && onePairPlayer == true)
        {
            gameMessageText.text = "We have a tie!";
        }
        else if (onePairPlayer != onePairComputer && onePairPlayer == false)
        {
            gameMessageText.text = "The Computer won with One Pair!";
        }
        else if (onePairPlayer != onePairComputer && onePairPlayer == true)
        {
            gameMessageText.text = "The Player won with One Pair";
        }

        //comparing two pair
        if (twoPairPlayer == twoPairComputer && twoPairPlayer == true)
        {
            gameMessageText.text = "We have a tie!";
        }
        else if (twoPairPlayer != twoPairComputer && twoPairPlayer == false)
        {
            gameMessageText.text = "The Computer won with Two Pair!";
        }
        else if (twoPairPlayer != twoPairComputer && twoPairPlayer == true)
        {
            gameMessageText.text = "The Player won with Two Pair";
        }

        //comparing three of a kind
        if (threeOfAKindPlayer == threeOfAKindComputer && threeOfAKindPlayer == true)
        {
            gameMessageText.text = "We have a tie!";
        }
        else if (threeOfAKindPlayer != threeOfAKindComputer && threeOfAKindPlayer == false)
        {
            gameMessageText.text = "The Computer won with Three of a Kind!";
        }
        else if (threeOfAKindPlayer != threeOfAKindComputer && threeOfAKindPlayer == true)
        {
            gameMessageText.text = "The Player won with Three of a Kind";
        }

        //comparing four of a kind
        if (fourOfAKindPlayer == fourOfAKindComputer && fourOfAKindPlayer == true)
        {
            gameMessageText.text = "We have a tie!";
        }
        else if (fourOfAKindPlayer != fourOfAKindComputer && fourOfAKindPlayer == false)
        {
            gameMessageText.text = "The Computer won with Four of a Kind!";
        }
        else if (fourOfAKindPlayer != fourOfAKindComputer && fourOfAKindComputer == true)
        {
            gameMessageText.text = "The Player won with Four of a Kind";
        }

        //comparing five of a kind
        if (fiveOfAKindPlayer == fiveOfAKindComputer && fiveOfAKindPlayer == true)
        {
            gameMessageText.text = "We have a tie!";
        }
        else if (fiveOfAKindPlayer != fiveOfAKindComputer && fiveOfAKindPlayer == false)
        {
            gameMessageText.text = "The Computer won with Five of a Kind!";
        }
        else if (fiveOfAKindPlayer != fiveOfAKindComputer && fiveOfAKindPlayer == true)
        {
            gameMessageText.text = "The Player won with Five of a Kind";
        }
         

        //comparaing a full house
        if (fullHousePlayer == fullHouseComputer && fullHousePlayer == true)
        {
            gameMessageText.text = "We have a tie!";
        }
        else if (fullHousePlayer != fullHouseComputer && fullHousePlayer == false)
        {
            gameMessageText.text = "The Computer won with a Full House!";
        }
        else if (fullHousePlayer != fullHouseComputer && fullHousePlayer == true)
        {
            gameMessageText.text = "The Player won with a Full House!";
        }
 
    }

    int DiceRoll()//int inclusive to the number 6 to display for dice instead of dots, cause I'm not that gifted yet
    {
        int diceRollToNumber = Random.Range(1, 7); 
        return diceRollToNumber;

    }

    string DiceRollToString() //returns the DiceRoll() to a string
    {
        string diceValue = DiceRoll().ToString();
        return diceValue;
    }
 
    
    public void RollOnPressed()
    {
        //gameMessageText.gameObject.SetActive(true); //setting the new textbox to active //troubleshooting why the new text isn't displaying
        numberOfRolls--;

        gameMessageText.text = "Lets Roll!";

        //player numbers
        playerDiceOneText.text = DiceRollToString();
        playerDiceOneToString = playerDiceOneText.text;
        
        playerDiceTwoText.text = DiceRollToString();
        playerDiceTwoToString = playerDiceTwoText.text;

        playerDiceThreeText.text = DiceRollToString();
        playerDiceThreeToString = playerDiceThreeText.text;

        playerDiceFourText.text = DiceRollToString();
        playerDiceFourToString = playerDiceFourText.text;

        playerDiceFiveText.text = DiceRollToString();
        playerDiceFiveToString = playerDiceFiveText.text;

        
        //computer numbers, not displayed until the reveal
        computerDiceOneText.text = DiceRollToString();
        computerDiceOneToString = computerDiceOneText.text;

        computerDiceTwoText.text = DiceRollToString();
        computerDiceTwoToString = computerDiceTwoText.text;

        computerDiceThreeText.text = DiceRollToString();
        computerDiceThreeToString = computerDiceThreeText.text;

        computerDiceFourText.text = DiceRollToString();
        computerDiceFourToString = computerDiceFourText.text;

        computerDiceFiveText.text = DiceRollToString();
        computerDiceFiveToString = computerDiceFiveText.text;

        PlayerOnePair();
        ComputerOnePair();
        PlayerTwoPair();
        ComputerTwoPair();
        PlayerThreeOfAKind();
        ComputerThreeOfAKind();
        PlayerFourOfAKind();
        ComputerFourOfAKind();
        PlayerFiveOfAKind();
        ComputerFiveOfAKind();
        PlayerFullHouse();
        ComputerFullHouse();

        

        //when number of rolls = 0
        if (numberOfRolls == 0)
        {
            rollButton.gameObject.SetActive(false);
            showHandButton.gameObject.SetActive(true);
        }

    } //what happens when the player rolls the dice

    public void ShowHandOnPressed() //reveal button
    {
        SetActive();
        ComparingComputerRollsToPlayerRolls();
    }

    void SetActive() //setting active necessary game regions
    {
        playAgainButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        computerDiceReveal.gameObject.SetActive(true);
    }

    public void PlayAgainOnPressed() //replay button
    {
        SceneManager.LoadScene("PokerDiceGame");
    }

    public void QuitOnPressed() //quit application
    {
        Application.Quit();
    }
}
