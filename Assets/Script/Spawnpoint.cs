using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Spawnpoint : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnpointLeaf;
    [SerializeField] private List<Transform> spawnpointZombie;
    [SerializeField] private GameObject leaf;
    [SerializeField] private GameObject zombie;
    [SerializeField] private float zombieSpawnTime = 3f;
    [SerializeField] private float leafSpawnTime = 10f;
    void Start()
    {
        InvokeRepeating("spawnZombie", 1f, zombieSpawnTime);
        InvokeRepeating("spawnLeaf", 3f, leafSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        TimeDuration time = GetComponent<TimeDuration>();
        if (time.RemainingTime <= 50)
        {
            
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
