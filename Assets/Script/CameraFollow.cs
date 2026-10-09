using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private Vector3 offset = new Vector3(0f, 0f, -10f);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.position + offset;
    }
}
