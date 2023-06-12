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

public class HumanPlayer : ParentPlayer
{
    // to calculate the card value
    public HumanPlayer(int card1, int card2, int card3, int card4, int card5)
    {
        CardValue1 = card1;
        CardValue2 = card2;
        CardValue3 = card3;
        CardValue4 = card4;
        CardValue5 = card5;
    }

}
