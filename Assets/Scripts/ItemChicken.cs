using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChicken : ItemScript
{
    public int indexChicken;
    public GameObject chickenPanel;

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

        spawnManager.SpawnChicken(indexChicken);
        chickenPanel.SetActive(true);
    }

    public override void BuyItemButton()
    {
        base.BuyItemButton();

        confirmBuy.onClick.AddListener(ItemSold);
        Debug.Log("Buy Chicken");
    }
}
