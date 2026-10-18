using Unity.Mathematics;
using UnityEngine;

public class Hero : MonoBehaviour
{

    [SerializeField] private float speed = 3.5f;
    [SerializeField] private Animator animate;
    [SerializeField] private GameObject hitbox;


    private float facingDirection = 1f;

    // Update is called once per frame
    void Update()
    {
        handleMovement();

    }
    private void handleMovement()
    {
        float input = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * input * speed * Time.deltaTime);
        if (input != 0)
        {
            animate.SetBool("isRunning", true);
            facingDirection = input;
            transform.localScale = new Vector3(5*facingDirection, 5, 1);
        } else
        {
            animate.SetBool("isRunning", false);
        }
    }

}
