using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{
    public Color[] colours;

    void Start()
    {
        int random = Random.Range(0, colours.Length);
        GetComponent<MeshRenderer>().material.color = colours[random];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
