using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomPlacer : MonoBehaviour
{
    public int[] numObjects;
    public GameObject[] objectsToPlace;
    public GameObject parent;
    public List<GameObject> spawnedObjects;

    GameObject ground;
    Mesh groundMesh;


    void Awake()
    {
        ground = GameObject.Find("round platform");
        groundMesh = ground.GetComponent<MeshFilter>().mesh;

    }

    public void SpawnObjects()
    {
        ground = GameObject.Find("round platform");
        groundMesh = ground.GetComponent<MeshFilter>().sharedMesh;

        RemoveAllSpawnedObjects();
        for (int x = 0; x < objectsToPlace.Length; x++)
        {

            for (int y = 0; y < numObjects[x]; y++)
            {
                SphereCollider[] colliders;
                float xPos = Random.Range(-groundMesh.bounds.size.x * ground.transform.localScale.x / 3, groundMesh.bounds.size.x * ground.transform.localScale.x / 3);
                float zPos = Random.Range(-groundMesh.bounds.size.z * ground.transform.localScale.z / 3, groundMesh.bounds.size.z * ground.transform.localScale.z / 3);
                Vector3 spawnPoint = new Vector3(xPos, 0, zPos);


                GameObject spawno = Instantiate(objectsToPlace[x], spawnPoint, Quaternion.identity, parent.transform);
                spawnedObjects.Add(spawno);
                Vector3 randomRot = new Vector3(spawno.transform.rotation.x, Random.Range(0, 360), spawno.transform.rotation.z);

                spawno.transform.rotation = Quaternion.Euler(randomRot.x, randomRot.y, randomRot.z);
            }
        }
    }

    public void RemoveAllSpawnedObjects()
    {
        if (spawnedObjects != null)
        {

            for (int i = spawnedObjects.Count-1; i > -1; i--)
            {
                DestroyImmediate(spawnedObjects[i]);
                spawnedObjects.RemoveAt(i);
                
            }
            spawnedObjects = new List<GameObject>();
        }
    }

}
