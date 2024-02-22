using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coinText;

    public int currentCoins = 1000;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coinText.text = currentCoins.ToString();
    }

    public void increaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = currentCoins.ToString();
    }

}
