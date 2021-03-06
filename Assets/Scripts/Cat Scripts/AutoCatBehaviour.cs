using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCatBehaviour : MonoBehaviour
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

    public bool beenCucumbered = false;
    public bool hasSalami = false;
    public AudioSource salamiEnd;

    public Bank breadBank;
    private ParticleSystem breadParticles;
    public float salamiTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartupDebug();
        breadParticles = GetComponentInChildren<ParticleSystem>();

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
        if (beenCucumbered)
        {
            if (catState != CatState.Afraid)
            {
                catState = CatState.Afraid;
                print(catName + " is Spooked!");
            }
        }else if (hasSalami)
        {
            if (catState != CatState.Salami)
            {
                catState = CatState.Salami;
                print(catName + " is FUELED BY SALAMI");
            }
        }else if (catState != CatState.Active)
        {
            catState = CatState.Active;
            print(catName + " exists i guess");
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
        breadBank.AddBread(breadPerPat * 2 * Time.deltaTime);
        if (salamiTimer <= 0)
        {
            hasSalami = false;
            catState = CatState.Active;
            salamiEnd.Play();
        }
        else 
        {
            salamiTimer -= Time.deltaTime;
        }

    }


    public void AnimateAutoCat()
    {
        if(animator.GetInteger("States") != (int)catState)
        {
            animator.SetInteger("States", (int)catState);
        }
    }

    public void breadStart()
    {
        breadParticles.Play();
    }

    public bool CanTakeSalami()
    {
        return ((isAsleep == false && catState == CatState.Active));
    }
}
