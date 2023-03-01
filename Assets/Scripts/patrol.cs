using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class patrol : MonoBehaviour
{
    public Transform[] waypoints;
    NavMeshAgent agent;
    public int currentWaypoint = 0;
    public Transform player;
    bool playerSeen = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerSeen){            
            if (agent.remainingDistance < 0.5f)
            {
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                agent.destination = waypoints[currentWaypoint].position;
            }
        }
        else{
            seePlayer();
        }
    }

    public void seePlayer(){
        playerSeen = true;
        agent.destination = player.transform.position;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.position - player.position, out hit)){
            print(hit.collider.tag);
            if(hit.collider.tag == "Player"){
                print("player hit");
                agent.destination = player.transform.position;
                playerSeen = true;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){
            if(playerSeen){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            print("player hit");
        }
    }

    public void finish(){
        if(!playerSeen){
            Destroy(this.gameObject);
        }
    }
}
