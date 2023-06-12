//////////////////////////////////////////////////////
// Assignment/Lab/Project: Unit 2 Unity Lesson Assignment
//Name: Rachel Huggins
//Section: 2022FA.SGD.113.2175
//Instructor: Brian Sowers
// Date: 09/21/2022
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the food forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
