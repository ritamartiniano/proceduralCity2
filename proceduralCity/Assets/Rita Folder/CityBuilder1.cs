using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilder1 : MonoBehaviour
{
    
    public GameObject[] buildings;
    public int mapWidth = 20;
    public int mapHeight = 20;
    public GameObject crossroad;
    public GameObject xStreets;
    public GameObject zstreets;
    public GameObject stoneGround;
    int buildingsSpacing = 10;
    int[,] mapGrid;
    public GameObject tree, bench;
    // Start is called before the first frame update
    void Start()
    {
        mapGrid = new int[mapWidth, mapHeight];
        float seed = Random.Range(0,100);
        float roadSeed = Random.Range(0, 100);
        for(int y = 0; y < mapHeight;y++)
        {
            for(int i = 0;i < mapWidth; i++)
            { 
               mapGrid[i,y] = (int)(Mathf.PerlinNoise(i / 10.0f + seed, y / 10.0f + seed) * 10);
            }
        }

        int x = 0;
        for(int n = 0;n < 50; n++)
        {
            for(int h = 0; h<mapHeight;h++)
            {
                mapGrid[x, h] = -1;
            }
            x += Random.Range(3, 3);
            if (x >= mapWidth) break;
        }
        int z = 0;
        for(int n =0; n<10;n++)
        {
            for(int w=0;w<mapWidth;w++)
            {
                if (mapGrid[w, z] == -1)
                    mapGrid[w, z] = -3;
                else
                    mapGrid[w, z] = -2;
            }
            z += Random.Range(2, 20);
            if (z >= mapHeight) break;
        }
        for(int y=0; y<mapHeight;y++)
        {
            for(int i = 0; i<mapWidth;i++)
            {
                int result = mapGrid[i, y];
                Vector3 pos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing);
                if (result < -2)
                    Instantiate(crossroad, pos, crossroad.transform.rotation);
                else if (result < -1)
                    Instantiate(xStreets, pos, xStreets.transform.rotation);
                else if (result < 0)
                    Instantiate(zstreets, pos, zstreets.transform.rotation);
                else if (result < 2)
                {
                    GameObject go = Instantiate(buildings[0], pos, Quaternion.identity);
                    Vector3 spawnPosition = go.transform.position + new Vector3(Random.Range(-go.transform.localScale.x/2, go.transform.localScale.x/2),0, (Random.Range(-go.transform.localScale.z / 2, go.transform.localScale.z/ 2)));
                    float pickPrefabforPark = Random.Range(0, 2);
                    if (pickPrefabforPark == 1 )
                    {
                        Instantiate(bench, spawnPosition, Quaternion.identity);
                    }
                    else if (pickPrefabforPark == 2 || pickPrefabforPark == 0)
                    {
                        Instantiate(tree, spawnPosition, Quaternion.identity);
                    }
                }
                else if (result < 4)
                {
                    Instantiate(buildings[1], pos, Quaternion.identity);

                }
                else if (result < 6)
                {
                    Instantiate(buildings[2], pos, Quaternion.identity);
                   
                }
                else if (result < 8)
                {
                    Instantiate(buildings[3], pos, Quaternion.identity);
                  
                }
                else if (result < 10)
                {
                    Instantiate(buildings[4], pos, Quaternion.Euler(0, -90, 0));
                  
                }
            }
        }
    }

}


