using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;


public class Spawnpoint : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnpointZombie;
    [SerializeField] private GameObject zombie;
    [SerializeField] private float zombieSpawnTime;
    
    [SerializeField] private TimeDuration time;
    void Start()
    {
        StartCoroutine(ZombieLoop());
        
    }

    IEnumerator ZombieLoop()
    {
        while (time.RemainingTime > 0)
        {
            float spawntime = zombieSpawnTime;
            if (time.RemainingTime <= 30)
            {
                spawntime = zombieSpawnTime / 4;
                Debug.Log(spawntime);
            }
            else if (time.RemainingTime <= 75)
            {
                spawntime = zombieSpawnTime / 2;
                Debug.Log(spawntime);
            }
            spawnZombie();
            yield return new WaitForSeconds(spawntime);
        }
    }
     




    public void spawnZombie()
    {
        int index = Random.Range(0, spawnpointZombie.Count);
        Transform point = spawnpointZombie[index];
        Instantiate(zombie, point.position, Quaternion.identity);
    }
    
}
