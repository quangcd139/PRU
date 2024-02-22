using UnityEngine;

public class TowerDamage : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ally" && gameObject.tag=="enemy")
            collision.GetComponent<Health>().TakeDamage(damage);

        if (collision.tag == "enemy" && gameObject.tag=="ally")
            collision.GetComponent<Health>().TakeDamage(damage);

    }

}