using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SalamiDrop : MonoBehaviour, IDropHandler
{
    public AutoCatBehaviour cat;
    public AudioSource salamiSound;
    private GameObject[] salamiHold;
    public void OnDrop(PointerEventData eventData)
    {
        salamiHold = GameObject.FindGameObjectsWithTag("Salami Prime");

        if (salamiHold.Length > 0)
        {
            cat.hasSalami = true;
            cat.salamiTimer = 30;
            Destroy(salamiHold[0]);

            salamiSound.Play();
        }
        


    }
}
