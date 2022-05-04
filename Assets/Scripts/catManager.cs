using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catManager : MonoBehaviour
{
    public autoCatBehaviour[] cats;
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
        cats[autoCatCount].catState = autoCatBehaviour.CatState.Active;
        autoCatCount++;
        
    }

    public bool CanPurchaseCat()
    {
        return (autoCatCount < maxCats);
    }
}
