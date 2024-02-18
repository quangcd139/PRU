using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoverment : MonoBehaviour
{
   
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;

    private Animator anim;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        anim.SetBool("move",false);
    }
    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        if (transform.localScale.x > 0){
            MoveInDirection(-1);
        }else if(transform.localScale.x < 0){
            MoveInDirection(1);
        }
    }
    private void MoveInDirection(int _direction){
        anim.SetBool("move",true);
        
        enemy.position = new Vector3(enemy.position.x+Time.deltaTime*_direction*speed,
        enemy.position.y,enemy.position.z);
    }

}
