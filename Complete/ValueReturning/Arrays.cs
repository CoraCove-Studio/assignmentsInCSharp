//////////////////////////////////////////////////////
// Assignment/Lab/Project: Arrays Assignment
//Name: Rachel Huggins
//Section: 2022FA.SGD.113.2175
//Instructor: Brian Sowers
// Date: 10/27/2022
//////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Arrays : MonoBehaviour
{
    // Declaring a class-scoped variable of the type int named randomNumbers that has 10 elements
    int[] randomNumbers = new int[10];
    // declaring a prefab array to use in Shoot() method
    public GameObject[] projectiles;


    // Start is called before the first frame update
    void Start()
    {
        // here we are calling a method to fill private class variable randomNumbers with an index of integers from 1-100
        FillWithRandomNumbers(randomNumbers);
        // here we display that randomized array
        Debug.Log(DisplayArray(randomNumbers));
        // here we are seeing the largest value of that array
        Debug.Log("The largest value of randomNumbers array is " + GetLargestValue(randomNumbers));
        // here we are seeing in the array randoming generated the integerr 50
        ContainValue(50);
        //here we are calling a method that when a button is pressed instantiates a randomly selected projectile
        
       

    }

    // Update is called once per frame
    void Update()
    {
        //here we are calling a method that when a button is pressed instantiates a randomly selected projectile
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    // Defining a method that fills in 10 random elements into the array inclusive b/w 1-100
    void FillWithRandomNumbers(int[] integerArrayNumber)
    {
        for (int i = 0; i < 10; i++)
        {
            int randomRangeForRandomIntegers = Random.Range(0, 101);
            randomNumbers[i] = randomRangeForRandomIntegers;
        }
    }
    // here is the method written to display the randomized integers in the console
    string DisplayArray(int[] arrayToDisplay)
    {
        string randomNumbersToString = "";
        for (int i = 0; i < arrayToDisplay.Length; i++)
        {
            randomNumbersToString += arrayToDisplay[i] + " ";
        }
        return randomNumbersToString;
    }
    // here is the method written to find the largest value in the array
    int GetLargestValue(int[] sourceArray)
    {
        int largestValue = sourceArray[0];
        for (int i = 1; i < sourceArray.Length; i++)
        {
            if (sourceArray[i] > largestValue)
            {
                largestValue = sourceArray[i];
            }
        }
        return largestValue;
    }
    // here is a method that returns a bool value to find if a specifically selected integer was displayed in the array
    bool ContainValue(int valueInput)
    {
        for (int index = 0; index < randomNumbers.Length; index++)
        {
            if (valueInput == randomNumbers[index])
            {
                Debug.Log("The value of " + valueInput.ToString() + " was found in the array.");
                return true;
            }
        }
        Debug.Log("The value of " + valueInput.ToString() + " could not be found in this array.");
        return false;
    }
    // written here is a method that randomly instantiates a project from the array above
    void Shoot()
    {
        int indexForRandomPrefab = Random.Range(0, projectiles.Length);
        Instantiate(projectiles[indexForRandomPrefab]);

    }
    // wrote this method to clean up the start method so the update method didn't have an if statement in it
    // i thought it was good practice and was more clean
    //void WhenSpaceBarPressed()
    
        //if (Input.GetButtonDown("Fire1"))
        
            //Shoot();
}
