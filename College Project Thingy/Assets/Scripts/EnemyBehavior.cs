using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{   
    public Transform player;
    public List<Transform> locations;

    private int locationIndex= 0;
    private NavMeshAgent agent;


    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("lil dude").transform;

    }

    // Update is called once per frame
    void Update()
    {
       if(agent.remainingDistance < 0.2f && !agent.pathPending)
       {


            MoveToNextPatrolLocation();

       }
    }

 void InitalizePatrolRoute()
    {
        foreach( Transform child in locations)
        {
            locations.Add(child);
        }

    }

        void MoveToNextPatrolLocation()
        {
            if(locations.Count == 0)
            {
                return;
            }
            agent.destination = locations[locationIndex].position;
            locationIndex = (locationIndex + 1) % locations.Count;
        }


         void OnTriggerEnter(Collider other)
        {
            if(other.name == "lil dude")
            {
                agent.destination = player.position;
                Debug.Log("ATTACK!!!");
                {
                    Debug.Log("IDK");
                }
        } 
         void OnTriggerEnter(Collider other)
        {
            if(other.name == "lil dude")
            {
                Debug.Log("Resume patrol");
            }
        }  
        
         
    }
}
