using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoCatBehaviour : MonoBehaviour
{
    public enum CatState
    {
        Active,
        Salami,
        Afraid
    }

    public Animator animator;
    public bool isAsleep = true;
    public CatState catState = CatState.Active;
    public string catName;
    public int breadPerPat;

    public Bank breadBank;

    // Start is called before the first frame update
    void Start()
    {
        StartupDebug();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAsleep) { UpdateCatState(); }

        if(catState == CatState.Active && !isAsleep)
        {
            AutoBreadPat();
        }else if(catState == CatState.Salami)
        {
            AutoSalami();
        }

        AnimateAutoCat();

    }

    
    //delete this
    void StartupDebug()
    {
         switch (catState)
         {
            case CatState.Active:
                print(catName + ((!isAsleep) ? " is ready to slap bread!" : " is sleepy..."));
                break;
            case CatState.Salami:
                print(catName + " IS FUELED BY THE POWER OF SALAMI!!!");
                break;
            default:
                print(catName + " is SpookedTM!");
                break;
         }
    }

    void UpdateCatState()
    {
        if (Input.GetKeyDown(KeyCode.R) && catState != CatState.Active)//replace with normal state condition
        {
            catState = CatState.Active;
            print(catName + " is slapping bread!");
        }
        else if (Input.GetKeyDown(KeyCode.E) && catState != CatState.Salami)//replace with salami condition
        {
            catState = CatState.Salami;
            print(catName + " is FUELED BY THE POWER OF SALAMI!!!!!!!");
        }
        else if (Input.GetKeyDown(KeyCode.F) && catState != CatState.Afraid)//replace with cucumber condition
        {
            catState = CatState.Afraid;
            print(catName + " is SpookedTM!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag(other.tag))
        {
            Debug.Log("ahahahha");
        }
    }

    void AutoBreadPat()
    {
        breadBank.AddBread(breadPerPat * Time.deltaTime);
    }

    void AutoSalami()
    {
        breadBank.AddBread(breadPerPat * 2);
    }


    public void AnimateAutoCat()
    {
        if(animator.GetInteger("States") != (int)catState)
        {
            animator.SetInteger("States", (int)catState);
        }
    }
}
