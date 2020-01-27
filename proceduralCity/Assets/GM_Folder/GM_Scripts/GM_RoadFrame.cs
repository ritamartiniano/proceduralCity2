using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_RoadFrame : MonoBehaviour
{
    [SerializeField]
    Collider c_Own;

    private bool bl_IsRoadTile = false;

    private void Start()
    {
        c_Own.enabled = true;
        StartCoroutine("IsRoadTile");
    }

    private IEnumerator IsRoadTile()
    {
        yield return new WaitForSeconds(1f);

        if (bl_IsRoadTile == true)
        {
            this.enabled = false;
        }

        else
        {
            Destroy(gameObject);
        }

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Instance0") || other.CompareTag("Instance1") || other.CompareTag("Instance2") || other.CompareTag("Instance3") || other.CompareTag("Instance4") || other.CompareTag("PerpTile"))
        {
            bl_IsRoadTile = false;
        }

        else
        {
            bl_IsRoadTile = true;
        }
    }
}
