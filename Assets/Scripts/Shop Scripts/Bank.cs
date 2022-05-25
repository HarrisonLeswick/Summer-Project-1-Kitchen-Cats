using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{

    public float bread = 0;
    public float displayedBread = 0;
    public TextMeshProUGUI text;
    public AudioSource[] breadSounds;
    private int soundRange;

    // Start is called before the first frame update
    void Start()
    {
        soundRange = breadSounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        displayedBread = bread;
        displayedBread = Mathf.FloorToInt(displayedBread);
        text.text = "Bread: " + displayedBread.ToString();
    }

    public void AddBread(float amount)
    {
        bread += amount;
    }

    public AudioSource GetBreadSound()
    {
        return breadSounds[Random.Range(0, soundRange)];
    }

}
