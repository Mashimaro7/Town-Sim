using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTime : MonoBehaviour
{
    static DateTime _dateTime;
    [Range(0,1)]
    public float timeOfDay;
    [SerializeField]
    int maxDayTime = 1200;

    int dayCount = 0;
    Transform sunLight;

    public static DateTime date
    {
        get
        {
            if (_dateTime != null)
            {
                return _dateTime;
            }
            else
            {
                _dateTime = new DateTime();
            }
            
            return _dateTime;
        }
    }

    void Awake()
    {
        _dateTime = this;
        sunLight = GameObject.Find("Directional Light").transform;
    }


    private void Update()
    {
        sunLight.transform.rotation = Quaternion.Euler((timeOfDay * 360) - 90, 170, 0);
        if (timeOfDay < 1)
        {
            timeOfDay += Time.deltaTime / maxDayTime;
        }
        else
        {
            timeOfDay = 0;
            dayCount++;
        }
    }

    private void OnValidate()
    {
        sunLight = GameObject.Find("Directional Light").transform;
        sunLight.transform.rotation = Quaternion.Euler((timeOfDay * 360) - 90, 170, 0);
    }

}
