using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catShop : MonoBehaviour
{

    public Bank breadBank;
    private int catPrice = 300;
    public catManager cats;

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
        }
    }
}
