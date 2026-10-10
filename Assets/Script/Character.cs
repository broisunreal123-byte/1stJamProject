using Unity.Mathematics;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private float speed = 3.5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firepoint;
    
    private float facingDirection = 1f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * x * speed * Time.deltaTime);
        if (x != 0) facingDirection = x;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }
    private void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(facingDirection);
        Destroy(bullet, 3f);
    }
}
