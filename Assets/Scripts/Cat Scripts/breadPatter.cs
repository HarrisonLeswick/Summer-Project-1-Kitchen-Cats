using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breadPatter : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource patSound;
    public Sprite bodySprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Bank bank;
    private bool leftPat = true;
    private int patCooldown = 0;
    public int value;
    private ParticleSystem breadParticles;

    private void Start()
    {
        breadParticles = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        if (patCooldown == 0)
        {
            returnToNormal();
        }
        patCooldown--;
    }
    private void OnMouseDown()
    {
        if (leftPat == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
            leftPat = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
            leftPat = true;
        }
        patCooldown = 600;
        bank.AddBread(value);

        patSound = bank.GetBreadSound();
        patSound.Play();

        breadParticles.Play();
    }

    private void returnToNormal()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = bodySprite;
        leftPat = true;
        breadParticles.Stop();
    }

}
