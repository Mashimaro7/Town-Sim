using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTerrain : MonoBehaviour
{
    [SerializeField]
    int width = 256;
    [SerializeField]
    int height = 256;
    [SerializeField]
    float scale = 20f;

    float offsetX = 100f, offsetY = 100f;
    private void Start()
    {
        GenerateTerrain();
    }

    Texture2D GetTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color colour1 = CalculateColour(x, y);
                texture.SetPixel(x, y, colour1);
            }
        }

        texture.Apply();
        return texture;
    }

    Color CalculateColour(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        if (sample > 1)
        {
            sample = 1;
        }
        return new Color(Mathf.Clamp(sample, .5f, .1f), Mathf.Clamp(sample, .5f, 1f), Mathf.Clamp01(sample + .25f));
    }

    public void GenerateTerrain()
    {
        offsetX = Random.Range(-99999f, 99999f);
        offsetY = Random.Range(-99999f, 99999f);
        Renderer renderer = GetComponent<Renderer>();
        renderer.sharedMaterial.mainTexture = GetTexture();
    }

    private void OnValidate()
    {
        GenerateTerrain();
    }
}
