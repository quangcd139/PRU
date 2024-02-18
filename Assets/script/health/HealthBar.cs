using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start() {
        totalHealthBar.fillAmount = playHealth.currentHealth / 100;
    }
    private void Update()
    {
        currentHealthBar.fillAmount = playHealth.currentHealth / 100;
    }
}
