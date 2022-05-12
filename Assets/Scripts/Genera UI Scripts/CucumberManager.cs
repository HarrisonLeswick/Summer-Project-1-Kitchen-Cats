using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberManager : MonoBehaviour
{
    public AutoCatBehaviour targetCat;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteCucumber()
    {
        targetCat.beenCucumbered = false;
        Destroy(this.gameObject);
    }
}
