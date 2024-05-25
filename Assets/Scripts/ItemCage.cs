using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCage : ItemScript
{
    // Start is called before the first frame update
    void Start()
    {
        InitializeObject();
        buttonBuy.onClick.AddListener(BuyItemButton);
    }

    // Update is called once per frame
    void Update()
    {
        ActivateButtonBuy();

    }

    public override void ItemSold()
    {
        base.ItemSold();

        spawnManager.SpawnCage();
    }

    public override void BuyItemButton()
    {
        base.BuyItemButton();

        confirmBuy.onClick.AddListener(ItemSold);
        Debug.Log("Buy Cage");
    }
}
