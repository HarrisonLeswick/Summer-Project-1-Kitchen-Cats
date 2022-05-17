using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SalamiDrop : MonoBehaviour, IDropHandler
{
    public AutoCatBehaviour cat;
    private GameObject[] salamiHold;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        cat.hasSalami = true;
        salamiHold = GameObject.FindGameObjectsWithTag("Salami Prime");
        if (salamiHold[0] != null)
        {
            Destroy(salamiHold[0]);
        }
        
    }
}
