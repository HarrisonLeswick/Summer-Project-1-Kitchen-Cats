using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberSpawner : MonoBehaviour
{
    public catManager autoCats;
    public GameObject cucumberPrefab;
    private float x = 0.0F;
    private float y = 0.0F;
    private AutoCatBehaviour chosenCat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
        //make this SPICIER
        if (Input.GetKeyDown(KeyCode.H))
        {
            if(autoCats.autoCatCount > 0)
            {
                PickCatToScare();
            }
           
        }
    }

    public void CreateCucumber()
    {
        GameObject newCucumber = Instantiate(
            cucumberPrefab, 
            new Vector2(x, y),
            Quaternion.identity,
            transform);
        newCucumber.name = "Cucumber";
        newCucumber.GetComponent<CucumberManager>().targetCat = chosenCat;
  
    }

    //spook the cat
    public void PickCatToScare()
    {
        int catsChecked = 0;
        int max = autoCats.autoCatCount;
        
        chosenCat = autoCats.cats[Random.Range(0, max)].GetComponent<AutoCatBehaviour>();
        while (chosenCat.beenCucumbered && catsChecked < max)
        {
            chosenCat = autoCats.cats[Random.Range(0, max)].GetComponent<AutoCatBehaviour>();
            catsChecked++;
        }
        
        if (!chosenCat.beenCucumbered)
        {
            chosenCat.beenCucumbered = true;
            x = (chosenCat.transform.position.x);
            y = (chosenCat.transform.position.y - 0.5F);
            CreateCucumber();
        }
        
    }



}
