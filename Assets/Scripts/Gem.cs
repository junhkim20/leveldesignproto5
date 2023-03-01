using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 40f * Time.deltaTime, 0f, Space.Self);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Global.gemCount += 1; 
            if(GameObject.FindGameObjectsWithTag("Gem").Length == 1){
                BrokenVector.LowPolyFencePack.DoorController doorController = GameObject.FindGameObjectWithTag("Gate").GetComponent<BrokenVector.LowPolyFencePack.DoorController>();
                doorController.OpenDoor();
                doorController.GetComponent<AudioSource>().Play();
            }
            Object.Destroy(this.gameObject);
        }
    }
}
