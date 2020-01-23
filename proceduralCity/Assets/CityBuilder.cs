using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilder : MonoBehaviour
{
    
    public GameObject[] buildings;
    public int mapWidth = 20;
    public int mapHeight = 20;
    int buildingsSpacing = 5;
    
    void Start()
    {
        float seed = Random.Range(0,100);
        for(int y = 0; y < mapHeight;y++)
        {
            for(int i = 0;i < mapWidth; i++)
            {
                int result = (int) (Mathf.PerlinNoise(i/10.0f + seed ,y/10.0f +seed) * 10);
                Vector3 pos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing);
                if (result < 2)
                    Instantiate(buildings[0], pos, Quaternion.identity);
                else if (result<4)
                    Instantiate(buildings[1], pos, Quaternion.identity);
                else if (result < 6)
                    Instantiate(buildings[2], pos, Quaternion.identity);
                else if (result < 8)
                    Instantiate(buildings[3], pos, Quaternion.identity);
                else if (result < 10)
                    Instantiate(buildings[4], pos , Quaternion.Euler(0,-90,0));

            }
        }
    }

   
}
