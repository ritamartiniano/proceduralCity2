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

    // Start is called before the first frame update
    void Start()
    {
        float fl_seed = Random.Range(0, 100);
        for (int y = 0; y < mapHeight; y++)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                int result = (int)(Mathf.PerlinNoise(i / 10.0f + fl_seed, y / 10.0f + fl_seed) * 10);
                Vector3 pos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                if (result < 2)
                {
                    GameObject go_Temp = Instantiate(buildings[0], pos, Quaternion.identity);

                    //66.7% ROADS
                    //int in_Temp = Random.Range(0, 2);

                    //if (in_Temp > 0)
                    //{
                    //    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    //    StartCoroutine("SpawnRoad", pos);
                    //}

                    //PERLIN NOISE ROADS
                    int in_Road = (int)(Mathf.PerlinNoise(i / 10.0f + fl_seed, y / 10.0f + fl_seed) * 10);
                    Vector3 v3_RoadPos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                    if (4 < in_Road && in_Road < 6)
                    {
                        Instantiate(go_CubeRoad, pos, Quaternion.identity);
                        StartCoroutine("SpawnRoad", pos);
                    }
                }

                else if (result < 4)
                {
                    GameObject go_Temp = Instantiate(buildings[1], pos, Quaternion.identity);

                    //66.7% ROADS
                    //int in_Temp = Random.Range(0, 2);

                    //if (in_Temp > 0)
                    //{
                    //    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    //    StartCoroutine("SpawnRoad", pos);
                    //}


                    //PERLIN NOISE ROADS
                    int in_Road = (int)(Mathf.PerlinNoise(i / 10.0f + fl_seed, y / 10.0f + fl_seed) * 10);
                    Vector3 v3_RoadPos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                    if (3 < in_Road && in_Road < 6)
                    {
                        Instantiate(go_CubeRoad, pos, Quaternion.identity);
                        StartCoroutine("SpawnRoad", pos);
                    }
                }

                else if (result < 6)
                {
                    GameObject go_Temp = Instantiate(buildings[2], pos, Quaternion.identity);

                    //66.7% ROADS
                    //int in_Temp = Random.Range(0, 2);

                    //if (in_Temp > 0)
                    //{
                    //    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    //    StartCoroutine("SpawnRoad", pos);
                    //}

                    //PERLIN NOISE ROADS
                    int in_Road = (int)(Mathf.PerlinNoise(i / 10.0f + fl_seed, y / 10.0f + fl_seed) * 10);
                    Vector3 v3_RoadPos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                    if (4 < in_Road && in_Road < 6)
                    {
                        Instantiate(go_CubeRoad, pos, Quaternion.identity);
                        StartCoroutine("SpawnRoad", pos);
                    }
                }

                else if (result < 8)
                {
                    GameObject go_Temp = Instantiate(buildings[3], pos, Quaternion.identity);

                    //66.7% ROADS
                    //int in_Temp = Random.Range(0, 2);

                    //if (in_Temp > 0)
                    //{
                    //    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    //    StartCoroutine("SpawnRoad", pos);
                    //}

                    //PERLIN NOISE ROADS
                    int in_Road = (int)(Mathf.PerlinNoise(i / 10.0f + fl_seed, y / 10.0f + fl_seed) * 10);
                    Vector3 v3_RoadPos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                    if (4 < in_Road && in_Road < 6)
                    {
                        Instantiate(go_CubeRoad, pos, Quaternion.identity);
                        StartCoroutine("SpawnRoad", pos);
                    }
                }

                else if (result < 10)
                {
                    GameObject go_Temp = Instantiate(buildings[4], pos, Quaternion.identity);

                    //66.7% ROADS
                    //int in_Temp = Random.Range(0, 2);

                    //if (in_Temp > 0)
                    //{
                    //    Instantiate(go_CubeRoad, pos, Quaternion.identity);
                    //    StartCoroutine("SpawnRoad", pos);
                    //}

                    //PERLIN NOISE ROADS
                    int in_Road = (int)(Mathf.PerlinNoise(i / 10.0f + fl_seed, y / 10.0f + fl_seed) * 10);
                    Vector3 v3_RoadPos = new Vector3(i * buildingsSpacing, 0, y * buildingsSpacing) * 2;

                    if (4 < in_Road && in_Road < 6)
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
        Instantiate(go_RoadTile, v3_Coroutine, Quaternion.identity);
        yield return null;
    }
}