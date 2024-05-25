using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    [SerializeField] public int price;
    [SerializeField] public Button buttonBuy;
    [SerializeField] public GameObject objectToSpawn;
    [SerializeField] public SpawnManager spawnManager;
    [SerializeField] public Button confirmBuy;

    [SerializeField] PlayerCoins playerCoins;
    [SerializeField] TextMeshProUGUI priceText;

    public void InitializeObject()
    {
        spawnManager = FindAnyObjectByType<SpawnManager>();

        playerCoins = FindAnyObjectByType<PlayerCoins>();

        buttonBuy = gameObject.GetComponentInChildren<Button>();

        //buttonBuy.onClick.AddListener(ItemSold);

        priceText = GameObject.Find("Coin Text").GetComponent<TextMeshProUGUI>();

        priceText.text += price;
    }

    public virtual void ItemSold()
    {
        playerCoins.coins -= price;
    }

    public virtual void BuyItemButton()
    {
        confirmBuy.onClick.RemoveAllListeners();
    }

    public void ActivateButtonBuy()
    {
        if (CanBuy(price))
        {
            buttonBuy.interactable = true;
        }
        else
        {
            buttonBuy.interactable = false;
        }
    }

    bool CanBuy(int itemPrice)
    {
        if (playerCoins.coins > itemPrice)
        {
            return true;
        }
        return false;
    }
}
