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
        float seed = Random.Range(0, 100);
        for(int y = 0; y < mapHeight;y++)
        {
            for(int i = 0;i < mapWidth; i++)
            { 
               mapGrid[i,y] = (int)(Mathf.PerlinNoise(i / 10.0f + seed, y / 10.0f + seed) * 10);
            }
        }
        //x is the random start position on the x axis to build street
        int x = 0;
        for(int n = 0;n < 50; n++)
        {
            for(int h = 0; h<mapHeight;h++)
            {   //assign -1 accross the height of the map 50 times
                mapGrid[x, h] = -1;
            }
            //determines how big the roads are and where the next road will occur
            x += Random.Range(2, 7);
            //stop if x is greater that the size of the map
            if (x >= mapWidth) break;
        }
        //z is the random start position on the z axis to build street
        int z = 0;
        for(int n =0; n <10;n++)
        {
            for(int w=0;w<mapWidth;w++)
            { //determine if across the width of the map  the position is already -1  
                if (mapGrid[w, z] == -1)
                    //if yes - 3 is assigned to this position, which means there is the roads cross 
                    mapGrid[w, z] = -3;
                else
                    //if not continue to draw the road, assigning the value of -2 to the positions
                    mapGrid[w, z] = -2;
            }
            //determines how wide the roads are and where the next road will occur
            z += Random.Range(2, 20);
            if (z >= mapHeight) break;
        }
        
        for(int y=0; y<mapHeight;y++)
        {
            for(int i = 0; i<mapWidth;i++)
            {   //result stores the perlin noise values
                int result = mapGrid[i, y];
                //set position for the building to instantiate
                Vector3 pos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing);
                if (result == -3)
                    //the value inside the array is -3 which means there is a crossroad between the roads along x and z
                    Instantiate(crossroad, pos, crossroad.transform.rotation);
                else if (result == -2)
                    //the value inside the array is -2 which means there is a road along the z axis to be created
                    Instantiate(xStreets, pos, xStreets.transform.rotation);
                else if (result ==  -1)
                    //the value inside the array is -1 which means there is a road along the x axis to be created
                    Instantiate(zstreets, pos, zstreets.transform.rotation);
                else if (result < 2)
                {
                    GameObject go = Instantiate(buildings[0], pos, Quaternion.identity);
                    //pick a random position accross each grass tile 
                    Vector3 spawnPosition = go.transform.position + new Vector3(Random.Range(-go.transform.localScale.x/2, go.transform.localScale.x/2),0, (Random.Range(-go.transform.localScale.z / 2, go.transform.localScale.z/ 2)));
                    float pickPrefabforPark = Random.Range(0, 2);
                    //pick random game object to spawn on the  park area
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


