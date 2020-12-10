using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TownsPerson : MonoBehaviour
{
    public float hunger = 100, thirst = 100, happiness = 50, money = 50,social = 100,energy = 100;
    const float valueMax = 100;
    int storeToVisitIndex;
    float timer = 1;

    public float hungerRate = 2, thirstRate = 3, energyRate = 1, socialRate = 1;
    public TextMeshProUGUI hungerText, thirstText;

    public Transform[] storeFronts;

    TownspersonMovement movement;

    private void Start()
    {
        movement = GetComponent<TownspersonMovement>();   
    }

    void Update()
    {
        hungerText.text = "Hunger: " + hunger.ToString("F0");
        thirstText.text = "Thirst: " + thirst.ToString("F0");

        if (hunger > 0)
        {
            hunger -= Time.deltaTime * 2;
        }

        else
        {
            hunger = 0;
        }

        if (thirst > 0)
        {
            thirst -= Time.deltaTime * 3;
        }

        else
        {
            thirst = 0;
        }
     
        if(hunger < 50 && money > 10)
        {
            GoToStore(0);
        }
    }

    void GoToStore(int storeType)
    {
        movement.ChangeState(States.HeadingToLocation);
        movement.Move(storeFronts[storeType].position);
                   
    }
}
