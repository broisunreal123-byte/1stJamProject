using UnityEngine;

public class Character : MonoBehaviour
{
    
    [SerializeField] private float speed = 3.5f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * x * speed * Time.deltaTime);
    }
}
