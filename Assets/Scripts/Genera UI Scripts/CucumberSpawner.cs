using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberSpawner : MonoBehaviour
{
    public catManager autoCats;
    public GameObject cucumberPrefab;
    public AudioSource scaredSound;

    private AutoCatBehaviour chosenCat;
    private int temp;
    private float countdown;
    private bool catsAreActive = false;

    private Vector2[] coords = { new Vector2(-299,-135), new Vector2(-351, 50), new Vector2(-6,139), new Vector2(343,50), new Vector2(288, -129) };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!catsAreActive)
        {
            if(autoCats.autoCatCount > 0)
            {
                catsAreActive = true;
                countdown = SetTimeTilCucumber();
            }
        }
        else
        {
            countdown -= Time.deltaTime;
            if(countdown <= 0)
            {
                PickCatToScare();
                countdown = SetTimeTilCucumber();
            }
        }
        
    }

    public void CreateCucumber()
    {
        GameObject newCucumber = Instantiate(
            cucumberPrefab, 
            new Vector3(0, 0, 0),
            Quaternion.identity,
            transform);
        newCucumber.name = "Cucumber";
        newCucumber.GetComponent<RectTransform>().anchoredPosition = coords[temp];
        newCucumber.GetComponent<CucumberManager>().targetCat = chosenCat;

        scaredSound.Play();
  
    }

    public float SetTimeTilCucumber()
    {
        float x = Random.Range(30.0F, 130.0F);
        print(x);
        return (x);
    }

    //spook the cat
    public void PickCatToScare()
    {
        int catsChecked = 0;
        int max = autoCats.autoCatCount;


        temp = Random.Range(0, max);

        chosenCat = autoCats.cats[temp].GetComponent<AutoCatBehaviour>();
        
        while (chosenCat.beenCucumbered && catsChecked < max)
        {
            temp = Random.Range(0, max);
            chosenCat = autoCats.cats[temp].GetComponent<AutoCatBehaviour>();
            catsChecked++;
        }
        
        if (!chosenCat.beenCucumbered)
        {
            chosenCat.beenCucumbered = true;
            CreateCucumber();
        }
        
    }



}
