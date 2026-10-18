using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float dmg;


    public void TakeDamage()
    {
        hp -= dmg;
    }
}
