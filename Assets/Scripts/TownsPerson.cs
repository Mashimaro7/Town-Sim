using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TownsPerson : MonoBehaviour
{
    [LabeledArray(typeof(NeedLabels)),Range(0f, 100f),SerializeField]
    float[] needs, needDrainRates;

    float money = 50;

    int needIndex, needsLength;
    [SerializeField]
    int needLevelToSatisfy;

    int storeToVisitIndex;

    public int[] likes;
    [SerializeField]
    float timerSet = 5;
    float timer = 5;
   
    public TextMeshProUGUI hungerText, thirstText;

    TownspersonData townspersonData;

    TownspersonMovement movement;

    private void Start()
    {
        needsLength = needs.Length;
        movement = GetComponent<TownspersonMovement>();
    }

    void Update()
    {


     if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = timerSet;
            DrainStats();
        }

        hungerText.text = "Hunger: " + needs[0].ToString("F0");
        thirstText.text = "Thirst: " + needs[1].ToString("F0");
    }

    void GoToStore(int storeType)
    {
        movement.ChangeState(States.HeadingToLocation);
        movement.Move(BuildingDatabase.instance.FindNearestStore(transform,BuildingDatabase.instance.foodLocations));
                   
    }

    void DrainStats()
    {
        for (int i = 0; i < needs.Length; i++)
        {
            if (needs[i] > 0)
            {
                needs[i] -= (Time.deltaTime * needDrainRates[i]);
                print(Time.deltaTime * needDrainRates[i]);
            }
             if (needs[i] < 0)
            {
                needs[i] = 0;
            }
        }
        if(needs[GetLowestNeed()] < needLevelToSatisfy)
        {
            
        }
    }

    int GetLowestNeed()
    {
        int lowestStat = 100;
        for (int i = 0; i < needs.Length; i++)
        {
            if (needs[i] < lowestStat)
            {
                lowestStat = i;
            }
        }
        return lowestStat;
    }

    private void OnValidate()
    {

    }

}
