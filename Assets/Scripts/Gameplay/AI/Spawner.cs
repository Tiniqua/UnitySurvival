using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    [SerializeField] private float minTime = 5;
    [SerializeField] private float maxTime = 10;

    [SerializeField] private Transform Player;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;


    private float timeDelta = 0;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Assert(enemyPrefab[2] != false, "Enemy prefab unassigned");
        timeDelta = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        // Whilst timeDelta is above zero, we minus the time between the last update calls then check timeDelta again
        // if it is below zero we know the correct time has passed and we spawn an enemy from one of four random spawn
        // points. We then reset timeDelta to a random value.
        if (timeDelta > 0)
        {
            timeDelta -= Time.deltaTime;
            if(timeDelta <= 0)
            {
                int randomPoint = Random.Range(0, spawnPoints.Length);
                
                Vector3 pos = spawnPoints[randomPoint].position;
                GameObject enemy = Spawn(pos);
                //enemy.GetComponent<GnomeoAIController>().SetTarget(Player);

                timeDelta = Random.Range(minTime, maxTime);
            }
        }
    }

    public GameObject Spawn(Vector3 pos)
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Length);

        return (GameObject)Instantiate(enemyPrefab[randomEnemy], pos, Quaternion.identity);
    }
}
