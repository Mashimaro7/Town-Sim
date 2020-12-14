using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TownsPerson : MonoBehaviour
{
    [Range(0,100)]
    public float hunger = 100, thirst = 100, happiness = 50, money = 50,social = 100,energy = 100;

    int storeToVisitIndex;
    int myHome;
    float timer = 1;

    public float hungerRate = 2, thirstRate = 3, energyRate = 1, socialRate = 1, happyRate = 1;
    public TextMeshProUGUI hungerText, thirstText;

    public Transform[] storeFronts;

    TownspersonMovement movement;

    private void Start()
    {
        movement = GetComponent<TownspersonMovement>();   
    }

    void Update()
    {
        if(happiness > 0)
        {
            happiness -= happyRate * Time.deltaTime;
        }

        if (hunger > 0)
        {
            hunger -= Time.deltaTime * hungerRate;
        }
        else
        {

        }


        if (thirst > 0)
        {
            thirst -= Time.deltaTime * thirstRate;
        }

        else
        {

        }
     
        if(hunger < 50 && money > 10)
        {
            GoToStore(0);
        }

        hungerText.text = "Hunger: " + hunger.ToString("F0");
        thirstText.text = "Thirst: " + thirst.ToString("F0");
    }

    void GoToStore(int storeType)
    {
        movement.ChangeState(States.HeadingToLocation);
        movement.Move(BuildingDatabase.instance.FindNearestStore(transform,BuildingDatabase.instance.foodLocations));
                   
    }
}
