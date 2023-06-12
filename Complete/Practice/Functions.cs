using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Display whether 15 is even or odd (spoiler, it's odd)
        DisplayEvenOrOdd(15);

        int someRandomNumber = Random.Range(0, 100);
        DisplayEvenOrOdd(someRandomNumber);
    }

    // Update is called once per frame
    void Update()
    {
        int someRandomNumber = Random.Range(0, 100);
        DisplayEvenOrOdd(someRandomNumber);
    }

    // Write a method that displays whether a number is even or odd
    void DisplayEvenOrOdd(int number)
    {
        if (number % 2 == 0)
        {
            Debug.Log("even");
        }
        else
        {
            Debug.Log("odd");
        }
    }

    // Write a method that takes 3 numbers and displays (num1 + num2) / num3
    void RunSomeMath()



}



