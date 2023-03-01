using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPain : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            GetComponentInParent<patrol>().finish();
        }
    }
}
