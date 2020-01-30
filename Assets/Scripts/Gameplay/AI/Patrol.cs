using UnityEngine.AI;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Patrol : MonoBehaviour
{

    private enum EnemyState { PATROLLING, CHASING };
    private EnemyState state = EnemyState.PATROLLING;

    private NavMeshAgent navAgent;

    [SerializeField]
    private Transform[] patrolTargets;
    private int currentTarget = 0;

    public ThirdPersonCharacter character { get; private set; }
    private Transform player;
    public Transform target;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(patrolTargets[currentTarget].position);
        character = GetComponent<ThirdPersonCharacter>();
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
                state = EnemyState.CHASING;
              
            }
            else
            {
                state = EnemyState.PATROLLING;
                navAgent.SetDestination(patrolTargets[currentTarget].position);
            }
        }

        switch (state)
        {
            case EnemyState.PATROLLING:

                if (navAgent.remainingDistance <= 2)
                {
                    currentTarget++;

                    if (currentTarget >= patrolTargets.Length)
                        currentTarget = 0;

                    navAgent.SetDestination(patrolTargets[currentTarget].position);
                }

                break;

            case EnemyState.CHASING:

                navAgent.SetDestination(player.position);
                break;
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
