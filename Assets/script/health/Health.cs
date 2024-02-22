using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip dieSound;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    [Header("Enemy Coin")]
    [SerializeField] private int coin;

    public GameObject popupDamePrefab;

    public TMP_Text popUpText;
    private UIManager uIManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        uIManager = FindObjectOfType<UIManager>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (gameObject.CompareTag("enemy"))
        {
            popUpText.text = _damage.ToString();
            Instantiate(popupDamePrefab, transform.position, Quaternion.identity);
        }
        
        if (currentHealth > 0)
        {
            if (anim != null)
                anim.SetTrigger("hurt");
            //ifram
            SoundManager.instance.PlaySound(hurtSound, 0.7f);
            //popup dame

            // StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                if (anim != null)
                    anim.SetTrigger("die");

                // deactive all component
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                dead = true;
                if (gameObject.CompareTag("enemy"))
                {
                    CoinCounter.instance.increaseCoins(coin);
                }
                if (gameObject.CompareTag("Player") || gameObject.CompareTag("AllyTower"))
                {
                    uIManager.GameOver();
                    return;
                }
                if (gameObject.CompareTag("EnemyTower"))
                {
                    uIManager.Win();
                    return;
                }
                SoundManager.instance.PlaySound(dieSound, 1);

            }
        }

    }


    private void Deacivate()
    {
        gameObject.SetActive(false);
    }
}
