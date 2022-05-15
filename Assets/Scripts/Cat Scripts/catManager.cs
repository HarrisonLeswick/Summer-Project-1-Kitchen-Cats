using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catManager : MonoBehaviour
{
    public AutoCatBehaviour[] cats;
    public int autoCatCount = 0;

    private int maxCats;

    // Start is called before the first frame update
    void Start()
    {
        maxCats = cats.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewAutoCat()
    {
        cats[autoCatCount].isAsleep = false;
        cats[autoCatCount].breadStart();
        cats[autoCatCount].animator.SetBool("wasPurchased", true);
        autoCatCount++;


    }

    public bool CanPurchaseCat()
    {
        return (autoCatCount < maxCats);
    }
}
