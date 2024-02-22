using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillOne : MonoBehaviour
{
    [SerializeField] private float skillCountDown;
    [SerializeField] private Transform skillPoint;
    [SerializeField] private GameObject skill;
    [SerializeField] private AudioClip skillSound;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)
         && cooldownTimer > skillCountDown
         && playerMovement.canAttack())
        //  && playerMovement.canAttack())
        {
            Skill();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Skill()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        SoundManager.instance.PlaySound(skillSound,1);
        skill.transform.position = skillPoint.position;
        skill.GetComponent<ProjectTile>()
        .SetDirection(Mathf.Sign(transform.localScale.x));
        // Activate any other logic related to skill activation here

    }
}
