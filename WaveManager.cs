using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject BasicEnemy;
    public Transform player;

    int basicCounter = 0;
    public int basicTimer = 50;

    void Start()
    {
        basicCounter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        basicCounter++;
        if (basicCounter > basicTimer)
        {
            SpawnBasic(BasicEnemy);
            basicCounter = 0;
        }
    }

    void SpawnBasic(GameObject enemy)
    {
        Instantiate(enemy, new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0), Quaternion.identity);
        //Instantiate(BasicEnemy, new Vector3(Random.Range(-30, 30) + player.transform.position.x, Random.Range(-30, 30) + player.transform.position.y, 0), Quaternion.identity);
    }
}
