using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private NavMeshAgent navAgent;
    

    [SerializeField]
    private Transform[] patrolTarget;
    private int currentTarget = 0;
    private Transform player;
    private AudioClip deathSound;
    private float volume = 1;
    AudioSource audio;


    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(patrolTarget[currentTarget].position);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var rayDirection = player.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit))
        {
            float dotProduct = Vector3.Dot(transform.forward, rayDirection);


            if (hit.transform == player && dotProduct > 0)
            {
                navAgent.SetDestination(player.position);
            }
            else
            {
                //navAgent.SetDestination(patrolTarget[currentTarget].position);
                if (navAgent.remainingDistance <= 0)
                {
                    currentTarget++;

                    if (currentTarget >= patrolTarget.Length)
                        currentTarget = 0;

                    navAgent.SetDestination(patrolTarget[currentTarget].position);
                }
            }    
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
    }
}
