//////////////////////////////////////////////////////
// Assignment/Lab/Project: UI Assignment
//Name: Rachel Huggins
//Section: 2022FA.SGD.113.2175
//Instructor: Brian Sowers
// Date: 10/13/2022
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CubeManager : MonoBehaviour
{
    // Declaring 3 private class scoped variables for later use in this script. Variables as listed from UserInterfaceAssignment.docx

    private Vector3 randomPos;
    private Vector3 randomScale;
    private Color randomColor;
    public TextMeshProUGUI actionCounterText;
    [SerializeField]
    private int actionCounter = 0;
    //private int actionCounterIndex;
    public GameObject changingCube;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Defining a random position method that assigns an actual Vector3 to "randomPos" as declared in -public class- to give cube a random position
    void RandomPosition()
    {
        // Assigning floats within the giving range to randomize an x value and a z value within a Vector3 coordinate; and having a constant value of 2.0 for y
        float minRandomValue = 0.0f;
        float maxRandomValue = 3.0f;
        float constantYValue = 2.0f;

        float xInput = Random.Range(minRandomValue, maxRandomValue);
        float zInput = Random.Range(minRandomValue, maxRandomValue);

        randomPos = new Vector3(xInput, constantYValue, zInput);

        //actionCounterText.text = $"Action Counter: {actionCounter}";

    }

    // Defining a random scale method that assigns an actual Vector3 to "randomScale" as declared in -public class- to give cube a random scale
    void RandomScale()
    {
        // Assigning floats within the giving range to randomize the x, y and z unit values of size - and to be the inputs with a Vector3, each element randomized
        float minScaleValue = 0.1f;
        float maxScaleValue = 3.0f;

        float xUnitSize = Random.Range(minScaleValue, maxScaleValue);
        float yUnitSize = Random.Range(minScaleValue, maxScaleValue);
        float zUnitSize = Random.Range(minScaleValue, maxScaleValue);

        randomScale = new Vector3(xUnitSize, yUnitSize, zUnitSize);

        //actionCounterText.text = $"Action Counter: {actionCounter}";

    }

    // Defining a random color method that assigns an actual color to "randomColor" out of 5 possible colors to our cube
    void RandomColor()
    {
        // Creating a random integer number range to randomly change the colors of a cube using a switch statement
        int minInclusive = 1;
        int maxExclusive = 6;

        int randomColorRange = Random.Range(minInclusive, maxExclusive);

        switch (randomColorRange)
        {
            case 1:
                randomColor = Color.green;
                break;
            case 2:
                randomColor = Color.red;
                break;
            case 3:
                randomColor = Color.magenta;
                break;
            case 4:
                randomColor = Color.yellow;
                break;
            case 5:
                randomColor = Color.black;
                break;
        }

        //actionCounterText.text = $"Action Counter: {actionCounter}";

    }

    // Defining a method to connect "Random Position Button" to make the position of the cube move upon clicking the button
    public void OnClickRandomPositionButton()
    {
        //int actionCounterIndex = actionCounter + actionCounter;
        RandomPosition();
        changingCube.transform.position = randomPos;
        //actionCounter++;
        WhenButtonClicked();
    }

    // Defining a method to connect "Random Scale Button" to make the scale of the cube change upon clicking the button
    public void OnClickRandomScaleButton()
    {
        //int actionCounterIndex = actionCounter + actionCounter;
        RandomScale();
        changingCube.transform.localScale = randomScale;
        //actionCounter++;
        WhenButtonClicked();
    }

    // Defining a method to connect "Random Color Button" to make the color of the cube change upon clicking the button
    public void OnClickRandomColorButton()
    {
        //int actionCounterIndex = actionCounter + actionCounter;
        RandomColor();
        changingCube.GetComponent<Renderer>().material.color = randomColor;
        //GetComponent<Renderer>().material.color = randomColor;
        //actionCounter++;
        WhenButtonClicked();

    }

    // Defining a method to connect "Reset Button" to make scene reset after clicking the button
    public void OnClickResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Defining a method to connect "Quit Button" to quit the application upon clicking the button
    public void OnClickQuitButton()
    {
       Application.Quit();
    }

    // Testing a method to change the action counter score when a button is clicked
    void WhenButtonClicked()
    {
        int actionCounterIndex = actionCounter++;
        actionCounterText.text = "Action Counter: " + actionCounterIndex.ToString();
    }
}
