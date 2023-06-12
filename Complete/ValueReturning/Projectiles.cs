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

public class Projectiles : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward, Space.Self);
    }
}
