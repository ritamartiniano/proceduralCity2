using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_CityGeneration : MonoBehaviour
{
    [Tooltip("The buildings prefabs to instantiate. Maximum 4. 0 very rare, 1 uncommon, 2 common, 3 uncommon, 4 uncommon, 5 very rare.")]
    [SerializeField]
    private GameObject[] buildings;

    [Tooltip("The width of the map (Suggested: 10).")]
    [SerializeField]
    private int mapWidth = 10;

    [Tooltip("The height of the map (Suggested: 10).")]
    [SerializeField]
    private int mapHeight = 10;

    [Tooltip("The cube prefab. Used to destroy road tiles.")]
    [SerializeField]
    private GameObject go_CubeRoad;

    [Tooltip("The road tiles prefabs.")]
    [SerializeField]
    private GameObject go_RoadTile;

    //The spacing between buildings.
    private int buildingsSpacing = 5;

    [Tooltip("The perpendicular road tiles prefabs.")]
    [SerializeField]
    private GameObject go_PerpRoad;

    //A member used to input a rotation.
    private Vector3 v3_Rotation90;

    //A member used to store a rotation.
    private Quaternion q_Rotation90;

    //A member used to input a rotation.
    private Vector3 v3_Rotation180;

    //A member used to store a rotation.
    private Quaternion q_Rotation180;

    //The tree and bench prefabs.
    public GameObject tree, bench;

    // It calls a coroutine to tidy up after the cube has destroyed the road tiles, sets a rotation, generates seeds and compares them.
    void Start()
    {
        StartCoroutine("DestroyUnparentedTiles");

        v3_Rotation90 = new Vector3(0, 90, 0);
        q_Rotation90.eulerAngles = v3_Rotation90;

        float fl_SeedRoadRow1 = Random.Range(0, mapWidth);
        float fl_SeedRoadColumn1 = Random.Range(0, mapHeight);
        float fl_SeedRoadRow2 = Random.Range(0, mapWidth);
        float fl_SeedRoadColumn2 = Random.Range(0, mapHeight);
        float fl_Seed = Random.Range(0, 100);

        //If the seeds are the same...
        if (fl_SeedRoadColumn1 == fl_SeedRoadColumn2)
        {
            //If the seed is between 0 and the rounded down map height...
            if (fl_SeedRoadColumn1 >= 0 && fl_SeedRoadColumn1 <= Mathf.Ceil(mapHeight / 2))
            {
                //Add 2 to the seed.
                fl_SeedRoadColumn2 = +2;
            }

            //Otherwise, if is between the rounded up map height and the maximum map height...
            else if (fl_SeedRoadColumn1 >= Mathf.Floor(mapHeight / 2) && fl_SeedRoadColumn1 <= mapHeight)
            {
                //Subtract 2 from the seed.
                fl_SeedRoadColumn2 = -2;
            }
        }

        //See above, but for row instead of column.
        if (fl_SeedRoadRow1 == fl_SeedRoadRow2)
        {
            if (fl_SeedRoadRow1 >= 0 && fl_SeedRoadRow1 <= Mathf.Ceil(mapHeight / 2))
            {
                fl_SeedRoadRow2 = +2;
            }

            else if (fl_SeedRoadRow1 >= Mathf.Floor(mapHeight / 2) && fl_SeedRoadRow1 <= mapHeight)
            {
                fl_SeedRoadRow2 = -2;
            }
        }

        //Generates the map iterating each position of a matrix.
        for (int y = 0; y < mapHeight; y++)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                //Generating perlin noise to instantiate the buildings, trees and benches.
                int result = (int)(Mathf.PerlinNoise(i / 10.0f + fl_Seed, y / 10.0f + fl_Seed) * 10);
                Vector3 pos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                //The seeds will instantiate perpendicular roads.
                if (i == fl_SeedRoadRow1 || i == fl_SeedRoadRow2)
                {
                    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    StartCoroutine("SpawnRoadPerpHor", pos);
                }

                if (y == fl_SeedRoadColumn1 || y == fl_SeedRoadColumn2)
                {
                    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    StartCoroutine("SpawnRoadPerpVer", pos);
                }

                //Depending on the result, different game elements will be instantiated.
                if (result < 2)
                {
                    v3_Rotation180 = new Vector3(0, Random.Range(15, -15), 0);
                    q_Rotation180.eulerAngles = v3_Rotation180;
                   

                    GameObject go_Temp = Instantiate(buildings[0], pos, Quaternion.identity);

                    // Instantiate the trees and benches. 
                    Instantiate(bench, pos + new Vector3(Random.Range(-0.5f, -1.5f), 0, Random.Range(-0.5f, -1.5f)), q_Rotation180);

                    Instantiate(tree, pos + new Vector3(Random.Range(0.5f, 1.5f), 0, Random.Range(0.5f, 1.5f)), q_Rotation180);

                    //66.7% ROADS
                    //int in_Temp = Random.Range(0, 2);

                    //if (in_Temp > 0)
                    //{
                    //    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    //    StartCoroutine("SpawnRoad", pos);
                    //}

                    //Generates perlin noise to generate the road tiles.
                    int in_Road = (int)(Mathf.PerlinNoise(i / 10.0f + fl_Seed, y / 10.0f + fl_Seed) * 10);
                    Vector3 v3_RoadPos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                    if (4.5 < in_Road && in_Road < 6)
                    {
                        Instantiate(go_CubeRoad, pos, Quaternion.identity);
                        StartCoroutine("SpawnRoad", pos);
                    }
                }

                else if (result < 4)
                {
                    v3_Rotation180 = new Vector3(0, Random.Range(15, -15), 0);
                    q_Rotation180.eulerAngles = v3_Rotation180;

                    GameObject go_Temp = Instantiate(buildings[1], pos, q_Rotation180);
                   

                    //66.7% ROADS - A deprecated way of generating road tiles.
                    //int in_Temp = Random.Range(0, 2);

                    //if (in_Temp > 0)
                    //{
                    //    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    //    StartCoroutine("SpawnRoad", pos);
                    //}


                    //PERLIN NOISE ROADS
                    int in_Road = (int)(Mathf.PerlinNoise(i / 10.0f + fl_Seed, y / 10.0f + fl_Seed) * 10);
                    Vector3 v3_RoadPos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                    if (4.5 < in_Road && in_Road < 6)
                    {
                        Instantiate(go_CubeRoad, pos, Quaternion.identity);
                        StartCoroutine("SpawnRoad", pos);
                    }
                }

                else if (result < 6)
                {
                    v3_Rotation180 = new Vector3(0, Random.Range(15, -15), 0);
                    q_Rotation180.eulerAngles = v3_Rotation180;

                    GameObject go_Temp = Instantiate(buildings[2], pos, q_Rotation180);
                 

                    //66.7% ROADS
                    //int in_Temp = Random.Range(0, 2);

                    //if (in_Temp > 0)
                    //{
                    //    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    //    StartCoroutine("SpawnRoad", pos);
                    //}

                    //PERLIN NOISE ROADS
                    int in_Road = (int)(Mathf.PerlinNoise(i / 10.0f + fl_Seed, y / 10.0f + fl_Seed) * 10);
                    Vector3 v3_RoadPos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                    if (4.5 < in_Road && in_Road < 6)
                    {
                        Instantiate(go_CubeRoad, pos, Quaternion.identity);
                        StartCoroutine("SpawnRoad", pos);
                    }
                }

                else if (result < 8)
                {
                    v3_Rotation180 = new Vector3(0, Random.Range(15, -15), 0);
                    q_Rotation180.eulerAngles = v3_Rotation180;

                    GameObject go_Temp = Instantiate(buildings[3], pos, q_Rotation180);
                    
                    

                    //66.7% ROADS
                    //int in_Temp = Random.Range(0, 2);

                    //if (in_Temp > 0)
                    //{
                    //    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    //    StartCoroutine("SpawnRoad", pos);
                    //}

                    //PERLIN NOISE ROADS
                    int in_Road = (int)(Mathf.PerlinNoise(i / 10.0f + fl_Seed, y / 10.0f + fl_Seed) * 10);
                    Vector3 v3_RoadPos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                    if (4.5f < in_Road && in_Road < 6)
                    {
                        Instantiate(go_CubeRoad, pos, Quaternion.identity);
                        StartCoroutine("SpawnRoad", pos);
                    }
                }

                else if (result < 10)
                {
                    v3_Rotation180 = new Vector3(0, Random.Range(15, -15), 0);
                    q_Rotation180.eulerAngles = v3_Rotation180;

                    GameObject go_Temp = Instantiate(buildings[4], pos, Quaternion.identity);

                    // Rita
                    Instantiate(bench, pos + new Vector3(Random.Range(-0.5f, -1.5f), 0, Random.Range(-0.5f, -1.5f)), q_Rotation180);

                    Instantiate(tree, pos + new Vector3(Random.Range(0.5f, 1.5f), 0, Random.Range(0.5f, 1.5f)), q_Rotation180);

                    //66.7% ROADS
                    //int in_Temp = Random.Range(0, 2);

                    //if (in_Temp > 0)
                    //{
                    //    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    //    StartCoroutine("SpawnRoad", pos);
                    //}

                    //PERLIN NOISE ROADS
                    int in_Road = (int)(Mathf.PerlinNoise(i / 10.0f + fl_Seed, y / 10.0f + fl_Seed) * 10);
                    Vector3 v3_RoadPos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                    if (4.5 < in_Road && in_Road < 6)
                    {
                        Instantiate(go_CubeRoad, pos, Quaternion.identity);
                        StartCoroutine("SpawnRoad", pos);
                    }

                }
            }
        }
    }

    //Coroutine to spawn the road tiles.
    private IEnumerator SpawnRoad(Vector3 v3_Coroutine)
    {
        yield return new WaitForSeconds(0.2f);

        GameObject go_Temp = Instantiate(go_RoadTile, v3_Coroutine, q_Rotation90);

        go_Temp.transform.position += new Vector3(0, -0.002f, 0);

        yield return null;
    }

    //Coroutine to instantiate the vertical perperndicular road tiles.
    private IEnumerator SpawnRoadPerpVer(Vector3 v3_PerpendicularHorRoad)
    {
        yield return new WaitForSeconds(0.2f);

        Instantiate(go_PerpRoad, v3_PerpendicularHorRoad, Quaternion.identity);

        yield return null;
    }

    //Coroutine to instantiate the horizontal perpendicular road tiles.
    private IEnumerator SpawnRoadPerpHor(Vector3 v3_PerpendicularVerRoad)
    {
        yield return new WaitForSeconds(0.2f);

        GameObject go_Temp = Instantiate(go_PerpRoad, v3_PerpendicularVerRoad, q_Rotation90);

        go_Temp.transform.position += new Vector3(0, -0.001f, 0);

        yield return null;
    }

    //Coroutine to destroy the unparented road tiles.
    private IEnumerator DestroyUnparentedTiles()
    {
        yield return new WaitForSeconds(0.9f);

        GameObject[] go_Temps = GameObject.FindGameObjectsWithTag("RoadTile");

        foreach (GameObject i in go_Temps)
        {
            if (i.transform.parent == null && i.transform.childCount == 0)
            {
                Destroy(i);
            }
        }

        yield return null;
    }
}
