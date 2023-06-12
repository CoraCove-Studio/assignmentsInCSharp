using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /**float[] studentGrades = new float[3];

        studentGrades[0] = 90.0f;
        studentGrades[1] = 100.0f;
        studentGrades[2] = 50.0f;

        int zeroElement = 0;
        Debug.Log(studentGrades[zeroElement]);

        for (int i = 0; i < 3; i++)
        {
        Debug.Log(studentGrades[i]);
        }

        float[] studentGrades = new float[3] { 90, 100, 50 };
        string[] studentNames = new string[] { "Joe", "John", "Jonas" };

        for (int i = 0; i < studentNames.Length; i++)
        {
            Debug.Log(studentNames[i]);
        }
        Debug.Log(studentNames[studentNames.Length - 1]);
        // Debug.Log(studentNames[4]);

        for (int i = studentNames.Length - 1; i >= 0; i--)
        {
            Debug.Log(studentNames[i]);
        }

        string name = "Johnny";
        for (int i = 0; i < name.Length; i++)
        {
            Debug.Log(name[i]);
        }

        for (int i = 0; i < studentGrades.Length; i++)
        {
            studentGrades[i] = 0;
        }

        foreach (string studentName in studentNames)
        {
            Debug.Log(studentName);
        }/**/

        // tag "enemy"
        // Vector3 pos -granade\
        // all the enemies within 5 units of pos - apply damage
        //Vector3 collisionPosition = new Vector3 (15f, 0f, 12f);
        //GameObject[] allEnemies =GameObject.FindGameObjectsWithTag("Enemy");
        //foreach(GameObject enemy in allEnemies)
        //  float distance = Vector3.Distance(collisionPosition, enemy.transform.position);
        //  if (distance <= 5)
        //      Do Damage
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // write methods that returns the average of an array of floats
    float CalculateAverage(float[] numbers)
    {
        if (numbers.Length == 0)
        {
            return 0;
        }
        return CalculateSum(numbers) / numbers.Length;
    }

    float CalculateSum(float[] numbers)
    {
        float total = 0f;
        foreach (float number in numbers)
        {
            total += number;
        }
        return total;
    }

    // write a method that takes an array of strings and prints them in reverse
    void DisplayInReverse(string[] words)
    {
        for (int i = words.Length - 1; i >= 0; i--)
        {
            Debug.Log(words[i]);
        }
        //for (int i = 0; i < words.Length; i++)
        //{
            //Debug.Log(words[words.Length - 1 - i]);
        //}
    }

    // Write a method that returns a reversed string
    string ReverseString(string str)
    {
        string result = "";
        for (int i = str.Length - 1; i >= 0; i--)
        {
            result += str[i];
        }
        return result;
    }

    // write a method that determines if a given word is a palindrome
    bool IsPalindrome(string word)
    {
        return (word == ReverseString(word));
    }







}





