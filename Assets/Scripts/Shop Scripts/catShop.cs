using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class catShop : MonoBehaviour
{
    public breadPatter patter;
    public Bank breadBank;
    public StickerStuff stickerSpawner;
    public SalamiStuff salamiSpawner;
    private int catPrice = 300;
    private int upgradePrice = 2;
    private int stickerPrice = 5;
    private int salamiPrice = 32;
    public catManager cats;
    public TextMeshProUGUI purchaseText;
    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI stickerText;
    public TextMeshProUGUI salamiText;
   

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

    public void BuySticker()
    {
        if (breadBank.bread >= stickerPrice)
        {
            breadBank.bread -= stickerPrice;
            stickerText.text = "Buy Sticker:\n" + stickerPrice.ToString();
            stickerSpawner.SpawnSticker();
        }
    }

    public void BuySalami()
    {
        if (breadBank.bread >= stickerPrice)
        {
            breadBank.bread -= salamiPrice;
            salamiText.text = "Buy Salami:\n" + salamiPrice.ToString();
            salamiSpawner.SpawnSalami();
        }
    }

}
