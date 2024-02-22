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
    private bool invulnerable;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        popUpText.text = _damage.ToString();
        Instantiate(popupDamePrefab, gameObject.transform.position, Quaternion.identity);

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
                SoundManager.instance.PlaySound(dieSound, 1);
            }
        }

    }


    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }
    private void Deacivate()
    {
        gameObject.SetActive(false);
    }
}
