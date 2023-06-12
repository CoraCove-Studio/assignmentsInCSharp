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

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // As the objects collide, they destroy each other
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
