//////////////////////////////////////////////
//Assignment/Lab/Project: Guess My Number Assignment
//Name: Rachel Huggins
//Section: 2023SP.SGD.213.2172
//Instructor: Brian Sowers
//Date: 01/16/2023
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations; // dont know how this loaded in here - but this happened on its own
using UnityEngine.SceneManagement;

public class GuessingGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageToPlayersText; //can edit text to player here
    [SerializeField] TMP_InputField playerGuess; //took me a second to figure this one out
    [SerializeField] int computersNumber; // randoms the computers number to be guessed
    [SerializeField] int amountOfPlayerGuesses; //amout of guesses allowed by player
    [SerializeField] Button guessButton; //references the guessing button to press when play inputs text
    [SerializeField] Button playAgainButton; //references the play again feature
    [SerializeField] Button quitButton; //quits application when pressed


    //the tutorial i used copypasta link: https://www.youtube.com/watch?v=baZMU4Bx0zs 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() //what happens when you hit the start button
    {
        messageToPlayersText.text = "I have picked a anumber between 1 and 100." + "\n" + "Can you guess it?" +
            "\n" + "Type your guess in the box below and click the guess button.";
        computersNumber = Random.Range(1, 101); //leaving at 101 to be inclusive of 100
    }

    public void GetGuess() //the code with the basic guessing functions
    {
        amountOfPlayerGuesses--;
        string playerGuessString = playerGuess.text;
        int playerGuessInt = System.Convert.ToInt32(playerGuessString); //need to ask about in class, followed a video tutorial that didn't explain this
        if (playerGuessInt > computersNumber)
        {
            messageToPlayersText.text = "Too high." + "\n" + "Guess again.";
        }
        else if (playerGuessInt < computersNumber)
        {
            messageToPlayersText.text = "Too low." + "\n" + "Guess again.";
        }
        else
        {
            messageToPlayersText.text = "You guessed it!" + "\n" + "You only had " + amountOfPlayerGuesses + " guesses left!";
            GameOver();
        }

        if (amountOfPlayerGuesses <= 0 && playerGuessInt != computersNumber)
        {
            messageToPlayersText.text = "***WHAMMY LOSING NOISES***" + "\n" + "The correct number was: " + computersNumber +
                "\n" + "Want to play again?";
            GameOver();
        }
    }


    void GameOver() //learned how to put buttons atop other buttons to keep the UI nice and organized - i liked the way the tutorial showed this feature
    {
        playerGuess.gameObject.SetActive(false);
        guessButton.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void PlayAgainButton() //allows you to play the game again
    {
        SceneManager.LoadScene("GuessMyNumberGame");
    }

    public void QuitGameButton() //quits application upon clicking of button
    {
        Application.Quit();
    }
    
}
