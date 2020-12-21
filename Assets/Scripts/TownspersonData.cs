using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownspersonData
{
    string name;
    int[] likes;
    List<int> relationships;
    int myHome;

    public TownspersonData(string name, int[] likes, List<int> relationships,int myHome)
    {
        this.name = name;
        this.likes = likes;
        this.relationships = relationships;
        this.myHome = myHome;
    }

}
