//////////////////////////////////////////////////////
// Assignment/Lab/Project: Methods Assignment
//Name: Rachel Huggins
//Section: 2022FA.SGD.113.2175
//Instructor: Brian Sowers
// Date: 10/20/2022
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Methods : MonoBehaviour
{
    //calling a public game object to get ahold of prefab
    //i wanted to just use a tag to avoid doing this because i felt the whole point of the assignment
    //was to learn how not to call things in the public class
    //but this was the only way to do the task without the object trying to be instantiated to be null

    public GameObject pickupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Line 67 Method being called here
        DisplayGreeting();
        
        //Line 97 Method being called here
        Add(1, 2);

        //work for Multiply Method question 3 from Method Assignment.docx
        float multipleRangeLowestIndex = 5.0f;
        float multipleRangeHighestIndex = 10.0f;

        float randomFirstNumberInsert = Random.Range(multipleRangeLowestIndex, multipleRangeHighestIndex);
        float randomSecondNumberInsert = Random.Range(multipleRangeLowestIndex, multipleRangeHighestIndex);

        //Line 106 Method being called here
        Multiply(randomFirstNumberInsert, randomSecondNumberInsert);

        //Line 115 Method being called here
        Debug.Log(GetDifference(10, 3));

        //Line 123 Method being called here 
        Debug.Log(GetQuotient(randomFirstNumberInsert, randomSecondNumberInsert));

        //Line 132 Method being called here
        float numOneFloat = Random.Range(multipleRangeLowestIndex, multipleRangeHighestIndex);
        float numTwoFloat = Random.Range(multipleRangeLowestIndex, multipleRangeHighestIndex);
        float numThreeFloat = Random.Range(multipleRangeLowestIndex, multipleRangeHighestIndex);
        
        float average = GetAverage(numOneFloat, numTwoFloat, numThreeFloat);
        Debug.Log("The average of " + numOneFloat.ToString() + ", " + numTwoFloat.ToString() + ", and " + numThreeFloat.ToString() + " is " + average.ToString() + ".");

        //Line 147 Method being called here
        GeneratePickup(1.0f, 3.0f);
        GeneratePickup(-2.1f, 2.2f);
        GeneratePickup(-1.4f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Defining a method named DisplayGreetings() to display one random message in the console out of 5, and display it in the 
    // Start() - no parameters
    
    void DisplayGreeting()
    {
        // creating a random integer range for a case switch to display a random message based on a different number generated
        int minIndex = 1;
        int maxIndex = 6;

        int randomMessageRange = Random.Range(minIndex, maxIndex);

        switch (randomMessageRange)
        {
            case 1:
                Debug.Log("What's kickin', Chicken?");
                break;
            case 2:
                Debug.Log("Howdy and smiley day to you!");
                break;
            case 3:
                Debug.Log("‘Ello, gov'nor!");
                break;
            case 4:
                Debug.Log("Hello, my name is Inigo Montoya.");
                break;
            case 5:
                Debug.Log("*Obi-Wan Kenobi voice* Hello there! --- GENERAL KENOBI!");
                break;
        }
    }

    // define a method named Add() that takes two integer parameters and displays the sum in the console - values are 
    // of my choice
    int Add(int numberOne, int numberTwo)
    {
        int sum = numberOne + numberTwo;
        Debug.Log(sum);
        return sum;
    }

    // define a method named Multiply() that takes two float parameters, multiplies them and displays the product in
    // the console - in the Start() is where Multiply() should have random floats inserted
    float Multiply(float firstMultiple, float secondMultiple)
    {
        float productOfRandomMultiples = firstMultiple * secondMultiple;
        Debug.Log(productOfRandomMultiples);
        return productOfRandomMultiples;
    }

    // defining a method named GetDifference() that takes two integer parameters - values are of my choice
    // display the return in Start()
    int GetDifference(int baseNumber, int numberDoingSubtraction)
    {
        int difference = baseNumber - numberDoingSubtraction;
        return difference;
    }

    // defining a method named GetQuotient() that takes two float parameters and returns a quotient
    // GetQuotient() is displayed in Start() w/ two values of my choice 
    float GetQuotient(float dividend, float divisor)
    {
        float quotient = dividend / divisor;
        return quotient;
    }

    // defining a method named GetAverage() that takes three float parameters and returns the average
    // In Start() call GetAverage() method with values of your choice
    // Display the value retured in a statement like: "The average of " + float1.ToString() + ", " + float2.ToString() + ", and " + float3.ToString() + "is " + average.ToString() + "."
    float GetAverage(float numberOne, float numberTwo, float numberThree)
    {
        float sum = numberOne + numberTwo + numberThree;
        float average = sum / 3;
        return average;
    }

    //Method designed to instantiate cube prefabs assigned in the inspector
    //what i don't understand is I tried using a tag and I got the error message
    // ArgumentException: The Thing You Want To Instantiate Is Null.
    //I thought that when you make a prefab, your supposed to clone it so you don't mess with the original prefab
    //Like if i were to say, destroy object, would i just use the tag to get a copy of the prefab to destroy the clone
    //leaving the original alone. also, i tried to just use the tag to get the object, and it kept coming up null
    //can you just use a tag to find an object without having to make it public in the inspector?

    void GeneratePickup(float xIntercept, float zIntercept)
    {
        Vector3 randomPosition = new Vector3(xIntercept, 0, zIntercept);
        Instantiate(pickupPrefab, randomPosition, Quaternion.identity);       

    }

}


