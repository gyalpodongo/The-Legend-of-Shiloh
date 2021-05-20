using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Manages HeartContainers
public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    //Initialize all the sprites we'll need
    public Sprite fullHeart; 
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers; // how many total hearts we have
    public FloatValue playerCurrentHealth; //the current player's health

    // Start is called before the first frame update
    void Start()
    {
        InitHearts(); //start full health
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitHearts()
    {
        for(int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true); //show the hearts
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RuntimeValue / 2; //Get decimal amount of full hearts player have (e.g. 1, 1.5)
        print(tempHealth);
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            if (i <= tempHealth-1)
            {
                //Full Heart
                hearts[i].sprite = fullHeart;

            } else if (i >= tempHealth)
            {
                //Empty Heart
                hearts[i].sprite = emptyHeart;

            } else
            {
                //Half Heart
                hearts[i].sprite = halfFullHeart;
            }
        }
    }
}
