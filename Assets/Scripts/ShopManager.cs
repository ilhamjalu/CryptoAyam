using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] List<GameObject> cages = new List<GameObject>();
    [SerializeField] List<GameObject> chickens = new List<GameObject>();
    [SerializeField] PlayerCoins playerCoins;

    [Header("Chicken Shop")]
    [SerializeField] Button chickenShopButton;
    [SerializeField] List<Sprite> chickenShopSprites;

    [Header("Cage Shop")]
    [SerializeField] Button cageShopButton;
    [SerializeField] List <Sprite> cageShopSprites;

    // Start is called before the first frame update
    void Start()
    {
        cageShopButton.onClick.AddListener(ShowCagePanel);
        chickenShopButton.onClick.AddListener(ShowChickenPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowCagePanel()
    {
        cageShopButton.GetComponent<Image>().sprite = cageShopSprites[1];
        chickenShopButton.GetComponent<Image>().sprite = chickenShopSprites[0];
    }

    void ShowChickenPanel()
    {
        cageShopButton.GetComponent<Image>().sprite = cageShopSprites[0];
        chickenShopButton.GetComponent<Image>().sprite = chickenShopSprites[1];
    }
}
