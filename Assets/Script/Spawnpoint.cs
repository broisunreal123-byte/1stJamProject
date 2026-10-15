using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;


public class Spawnpoint : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnpointLeaf;
    [SerializeField] private List<Transform> spawnpointZombie;
    [SerializeField] private GameObject leaf;
    [SerializeField] private GameObject zombie;
    [SerializeField] private float zombieSpawnTime;
    [SerializeField] private float leafSpawnTime;
    [SerializeField] private TimeDuration time;
    void Start()
    {
        StartCoroutine(SpawnStuff());
    }

    IEnumerator SpawnStuff()
    {
        while (time.RemainingTime > 0)
        {
            float spawntime = zombieSpawnTime;
            if (time.RemainingTime <= 80)
            {
                spawntime = zombieSpawnTime / 3;
                Debug.Log(spawntime);
            }
            else if (time.RemainingTime <= 90)
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
    public void spawnLeaf()
    {
        int index = Random.Range(0, spawnpointLeaf.Count);
        Transform point = spawnpointLeaf[index];
        Instantiate(leaf, point.position, Quaternion.identity);
        Debug.Log("The leaf spawned");
    }
}
