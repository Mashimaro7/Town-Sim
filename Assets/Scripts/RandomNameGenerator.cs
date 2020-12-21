using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNameGenerator
{
    public string[] names = new string[] {"John","Jim","Jane","Jill" };

    static RandomNameGenerator _nameGen;

    public static RandomNameGenerator nameGen
    {
        get
        {
            if(_nameGen == null)
            {
                _nameGen = new RandomNameGenerator();
            }
            return _nameGen;
        }
    }
    

    
    string GetRandomName()
    {
        string randomName = names[Random.Range(0,names.Length)];

        return randomName;
    }

}
