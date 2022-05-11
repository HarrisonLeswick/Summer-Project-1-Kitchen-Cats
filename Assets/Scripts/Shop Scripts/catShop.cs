using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class catShop : MonoBehaviour
{
    public breadPatter patter;
    public Bank breadBank;
    private int catPrice = 300;
    private int upgradePrice = 2;
    public catManager cats;
    public TextMeshProUGUI purchaseText;
    public TextMeshProUGUI upgradeText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyCat()
    {
        if(breadBank.bread >= catPrice && cats.CanPurchaseCat())
        {
            breadBank.bread -= catPrice;
            print("Cat Purchased :3");

            cats.NewAutoCat();
            catPrice *= 3;

            if (!cats.CanPurchaseCat())
            {
                purchaseText.text = ":3";
            }
            else
            {
                purchaseText.text = "Hire " + (cats.cats[cats.autoCatCount].catName) + ":\n" + catPrice.ToString();
            }
        }
    }

    public void UpgradeCat()
    {
        if(breadBank.bread >= upgradePrice)
        {
            breadBank.bread -= upgradePrice;
            patter.value *= 2;
            upgradePrice *= upgradePrice;

            upgradeText.text = "UPGRADE:\n" + upgradePrice.ToString();
        }
    }
}
