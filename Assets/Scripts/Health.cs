using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public AudioClip clipMusic;
    public AudioSource sourceAudio;
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    //Quando o script é ativado a vida de cada player é reset
    public void OnEnable()
    {
        currentHealth = maxHealth;
    }
    private void Start()
    {
        sourceAudio.clip = clipMusic;
    }

    public void TakeDamage(int amount)
    {
        sourceAudio.PlayOneShot(clipMusic);
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
           
        }
    }
   //TODO HEAL
}
