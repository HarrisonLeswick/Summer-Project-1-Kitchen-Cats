using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoCatBehaviour : MonoBehaviour
{
    public enum CatState
    {
        Asleep,
        Active,
        Afraid
    }

    public Animator animator;
    public CatState catState = CatState.Asleep;
    public string catName;
    public int breadPerPat;

    public Bank breadBank;

    // Start is called before the first frame update
    void Start()
    {
        switch (catState)
        {
            case CatState.Active:
                print(catName + " is ready to slap bread!");
                break;
            case CatState.Afraid:
                print(catName + " is SpookedTM!");
                break;
            default:
                print(catName + " is sleepy...");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (catState)
        {
            case CatState.Active:
                AutoBreadPat();
                break;
            case CatState.Afraid:
                AutoAfraid();
                break;
            default:
                AutoAsleep();
                break;
        }

    }

    void AutoAsleep()
    {
       
    }

    void AutoBreadPat()
    {
        breadBank.AddBread(breadPerPat);
    }

    void AutoAfraid()
    {
        
    }
}
