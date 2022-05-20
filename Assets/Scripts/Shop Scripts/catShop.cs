using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class catShop : MonoBehaviour
{
    public breadPatter patter;
    public Bank breadBank;
    public catManager cats;
    public StickerStuff stickerSpawner;
    public SalamiStuff salamiSpawner;
    public AudioSource purchaseSound;
    
    private int catPrice = 300;
    private int upgradePrice = 2;
    private int stickerPrice = 5;
    private int salamiPrice = 32;

    private float countdownTimer = 0;
    private float displayCountdown;

    private bool noMoreStickers = false;
    
    public TextMeshProUGUI purchaseText;
    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI stickerText;
    public TextMeshProUGUI salamiText;


    void Update()
    {
        if(countdownTimer > 0.0F)
        {
            countdownTimer -= Time.deltaTime;
            UpdateSalamiText();
        }

        if(displayCountdown < 0.0F)
        {
            salamiText.text = "Buy Salami:\n" + salamiPrice.ToString();
        }
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

            purchaseSound.Play();
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

            purchaseSound.Play();
        }
    }

    public void BuySticker()
    {
        if (breadBank.bread >= stickerPrice && (!noMoreStickers))
        {
            breadBank.bread -= stickerPrice;
            stickerText.text = "Buy Sticker:\n" + stickerPrice.ToString();
            stickerSpawner.PickSticker();

            purchaseSound.Play();


            if (stickerSpawner.allStickersUsed)
            {
                noMoreStickers = true;
                stickerText.text = "that's a lot\nof stickers :3";
                //summon bread bank audio
            }
        }
    }

    public void BuySalami()
    {
        if (breadBank.bread >= stickerPrice && countdownTimer <= 0.0F)
        {
            breadBank.bread -= salamiPrice;
            salamiText.text = "Buy Salami:\n" + salamiPrice.ToString();
            salamiSpawner.SpawnSalami();

            countdownTimer = 60.0F;

            purchaseSound.Play();
        }
    }

    private void UpdateSalamiText()
    {
        displayCountdown = Mathf.FloorToInt(countdownTimer);
        salamiText.text = "Please wait...\n" + displayCountdown.ToString();
    }


}
