﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class trims down the number of road frames.
/// </summary>
public class GM_CheckRoadFrames : MonoBehaviour
{
    // Start is called before the first frame update. It calls the CheckFrame coroutine (the roads are instantiated after 1.2 seconds).
    void Start()
    {
        StartCoroutine("CheckFrame");
    }

    /// <summary>
    /// Checks if the road frames are 20 or between 20 and 15. It will scale their number down by destroying them.
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckFrame() 
    {
        yield return new WaitForSeconds(1.2f);

        if (gameObject.transform.childCount == 20)
        {
            int in_Temp0 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp0) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp0).gameObject);
            }

            int in_Temp1 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp1) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp1).gameObject);
            }

            int in_Temp2 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp2) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp2).gameObject);
            }

            int in_Temp3 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp3) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp3).gameObject);
            }

            int in_Temp4 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp4) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp4).gameObject);
            }

            int in_Temp5 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp5) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp5).gameObject);
            }

            int in_Temp6 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp6) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp6).gameObject);
            }

            int in_Temp7 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp7) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp7).gameObject);
            }

            int in_Temp8 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp8) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp8).gameObject);
            }

            int in_Temp9 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp9) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp9).gameObject);
            }

            int in_Temp10 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp10) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp10).gameObject);
            }

            int in_Temp11 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp11) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp11).gameObject);
            }

            int in_Temp12 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp12) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp12).gameObject);
            }

            int in_Temp13 = Random.Range(0, 19);
            if (gameObject.transform.GetChild(in_Temp13) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp13).gameObject);
            }
        }

        else if (gameObject.transform.childCount < 20 && gameObject.transform.childCount >= 15)
        {
            int in_Temp0 = Random.Range(0, 15);
            if (gameObject.transform.GetChild(in_Temp0) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp0).gameObject);
            }

            int in_Temp1 = Random.Range(0, 15);
            if (gameObject.transform.GetChild(in_Temp1) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp1).gameObject);
            }

            int in_Temp2 = Random.Range(0, 15);
            if (gameObject.transform.GetChild(in_Temp2) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp2).gameObject);
            }

            int in_Temp3 = Random.Range(0, 15);
            if (gameObject.transform.GetChild(in_Temp3) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp3).gameObject);
            }

            int in_Temp4 = Random.Range(0, 15);
            if (gameObject.transform.GetChild(in_Temp4) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp4).gameObject);
            }

            int in_Temp5 = Random.Range(0, 15);
            if (gameObject.transform.GetChild(in_Temp5) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp5).gameObject);
            }

            int in_Temp6 = Random.Range(0, 15);
            if (gameObject.transform.GetChild(in_Temp6) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp6).gameObject);
            }

            int in_Temp7 = Random.Range(0, 15);
            if (gameObject.transform.GetChild(in_Temp7) != null)
            {
                Destroy(gameObject.transform.GetChild(in_Temp7).gameObject);
            }

            yield return null;
        }
    }
}
