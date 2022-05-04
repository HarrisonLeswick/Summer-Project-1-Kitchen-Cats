using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{

    public int bread = 0;
    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        text.text = "Bread: " + bread.ToString();

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("space key was pressed");
            Debug.Log(bread);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            AddBread(10);
            Debug.Log(bread);
        }

    }

    public void AddBread(int amount)
    {
        bread += amount;
    }
}
