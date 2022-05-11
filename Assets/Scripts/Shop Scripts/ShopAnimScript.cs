using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimScript : MonoBehaviour
{
    public Animator animator;
    private bool tracker = false;

    public void OpenCloseShop()
    {
        tracker = !tracker;
        animator.SetBool("ShopOpen", tracker);
    }
}
