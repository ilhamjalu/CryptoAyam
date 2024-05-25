using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCoins : MonoBehaviour
{
    public int coins;
    [SerializeField] TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetCoinText();
    }

    void SetCoinText()
    {
        coinText.text = coins.ToString();
    }
}
