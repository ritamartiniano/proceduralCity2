using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_CityGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buildings;

    [SerializeField]
    private int mapWidth = 10;

    [SerializeField]
    private int mapHeight = 10;

    [SerializeField]
    private GameObject go_CubeRoad;

    [SerializeField]
    private GameObject go_RoadTile;

    private int buildingsSpacing = 5;

    [SerializeField]
    private GameObject go_PerpRoad;

    private Vector3 v3_Rotation90;

    private Quaternion q_Rotation90;

    private Vector3 v3_Rotation180;

    private Quaternion q_Rotation180;

    public GameObject tree, bench;

    // Start is called before the first frame update
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

        if (fl_SeedRoadColumn1 == fl_SeedRoadColumn2)
        {
            if (fl_SeedRoadColumn1 >= 0 && fl_SeedRoadColumn1 <= Mathf.Ceil(mapHeight / 2))
            {
                fl_SeedRoadColumn2 = +2;
            }

            else if (fl_SeedRoadColumn1 >= Mathf.Floor(mapHeight / 2) && fl_SeedRoadColumn1 <= mapHeight)
            {
                fl_SeedRoadColumn2 = -2;
            }
        }

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

        for (int y = 0; y < mapHeight; y++)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                int result = (int)(Mathf.PerlinNoise(i / 10.0f + fl_Seed, y / 10.0f + fl_Seed) * 10);
                Vector3 pos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

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

                if (result < 2)
                {
                    v3_Rotation180 = new Vector3(0, Random.Range(180, -180), 0);
                    q_Rotation180.eulerAngles = v3_Rotation180;
                   

                    GameObject go_Temp = Instantiate(buildings[0], pos, Quaternion.identity);

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

                else if (result < 4)
                {
                    v3_Rotation180 = new Vector3(0, Random.Range(180, -180), 0);
                    q_Rotation180.eulerAngles = v3_Rotation180;

                    GameObject go_Temp = Instantiate(buildings[1], pos, q_Rotation180);
                   

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

                else if (result < 6)
                {
                    v3_Rotation180 = new Vector3(0, Random.Range(180, -180), 0);
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
                    v3_Rotation180 = new Vector3(0, Random.Range(180, -180), 0);
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
                    v3_Rotation180 = new Vector3(0, Random.Range(180, -180), 0);
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

    private IEnumerator SpawnRoad(Vector3 v3_Coroutine)
    {
        yield return new WaitForSeconds(0.2f);

        GameObject go_Temp = Instantiate(go_RoadTile, v3_Coroutine, q_Rotation90);

        go_Temp.transform.position += new Vector3(0, -0.002f, 0);

        yield return null;
    }

    private IEnumerator SpawnRoadPerpVer(Vector3 v3_PerpendicularHorRoad)
    {
        yield return new WaitForSeconds(0.2f);

        Instantiate(go_PerpRoad, v3_PerpendicularHorRoad, Quaternion.identity);

        yield return null;
    }

    private IEnumerator SpawnRoadPerpHor(Vector3 v3_PerpendicularVerRoad)
    {
        yield return new WaitForSeconds(0.2f);

        GameObject go_Temp = Instantiate(go_PerpRoad, v3_PerpendicularVerRoad, q_Rotation90);

        go_Temp.transform.position += new Vector3(0, -0.001f, 0);

        yield return null;
    }

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
