using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarTower : MonoBehaviour
{
    [SerializeField] private Health playHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start() {
        totalHealthBar.fillAmount = playHealth.currentHealth / 200;
    }
    private void Update()
    {
        currentHealthBar.fillAmount = playHealth.currentHealth / 200;
    }
}
