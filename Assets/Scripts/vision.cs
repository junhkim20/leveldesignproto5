using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vision : MonoBehaviour
{
    patrol parentPatrol;
    void Start()
    {
        parentPatrol = GetComponentInParent<patrol>();
    }

    void OnTriggerEnter(Collider other)
    {
        print("triggered");
        if(other.tag == "Player"){
            parentPatrol.seePlayer();
        }
    }
}
