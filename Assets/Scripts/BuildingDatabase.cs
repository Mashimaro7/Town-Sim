using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDatabase : MonoBehaviour
{
    private static BuildingDatabase _instance;

    private void Awake()
    {
        _instance = this;
    }

    public List<Vector3> foodLocations = new List<Vector3>();

    private void Start()
    {
        List<Venue> locationsToSearch = new List<Venue>(FindObjectsOfType<Venue>());

        for (int i = 0; i < locationsToSearch.Count; i++)
        {
            if(locationsToSearch[i].venueIndex == 0)
            {
                foodLocations.Add(locationsToSearch[i].transform.Find("Building Entrance").position);
            }
        }

    }

    public static BuildingDatabase instance
    {
        get
        {
            if(_instance == null)
            {
                print("There's no building database, my man.");
            }
            return _instance;
        }
    }


    private void AddToList(Vector3 locationToAdd, List<Vector3> listToAddTo)
    {
        listToAddTo.Add(locationToAdd);
    }

    public Vector3 FindNearestStore(Transform startPoint,List<Vector3> listToSearch)
    {
        float dst = float.MaxValue;
        Vector3 storeToGoTo = Vector3.zero;

        for (int i = 0; i < listToSearch.Count; i++)
        {
            float currentSample = Vector3.Distance(startPoint.position, listToSearch[i]);
            
            if(currentSample < dst)
            {
                dst = currentSample;
                storeToGoTo = listToSearch[i];
            }
        }
        if(storeToGoTo != Vector3.zero)
        {
            return storeToGoTo;
        }
        return startPoint.position;
    }
}
