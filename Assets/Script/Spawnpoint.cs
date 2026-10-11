using UnityEngine;
using System.Collections.Generic;


public class Spawnpoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnpointLeaf;
    [SerializeField] private List<Transform> spawnpointZombie;
    [SerializeField] private GameObject leaf;
    [SerializeField] private GameObject zombie;
    [SerializeField] private float spawnTime = 2f;
    void Start()
    {
        InvokeRepeating("spawnZombie", 1f, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void spawnZombie()
    {
        int index = Random.Range(0, spawnpointZombie.Count);
        Transform point = spawnpointZombie[index];
        Instantiate(zombie, point.position, Quaternion.identity);
    }
}
