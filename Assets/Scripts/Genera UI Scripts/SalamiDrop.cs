using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SalamiDrop : MonoBehaviour, IDropHandler
{
    public AutoCatBehaviour cat;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        cat.catState = AutoCatBehaviour.CatState.Salami;
    }
}
