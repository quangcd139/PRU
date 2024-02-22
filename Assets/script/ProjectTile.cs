using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectTile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damageAmount;
    private float direction;
    private bool hit;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float lifeTime;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 1.3) Deacivate();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        hit = true;
        boxCollider.enabled = false;
        if (anim != null)
            anim.SetTrigger("explore");


        Health enemyHealth = other.GetComponent<Health>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damageAmount);
        }


    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX,
        transform.localScale.y, transform.localScale.z);
    }



    private void Deacivate()
    {
        gameObject.SetActive(false);
    }
}
