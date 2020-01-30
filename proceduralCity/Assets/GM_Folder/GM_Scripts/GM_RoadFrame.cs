using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class detects if the particular road frame is attached to a road or not.
/// </summary>
public class GM_RoadFrame : MonoBehaviour
{
    [Tooltip("The object's collider.")]
    [SerializeField]
    private Collider c_Own;

    //Checks if the connection is a road tile (not perpendicular).
    private bool bl_IsRoadTile = false;

    //Enables the collider if disabled. Starts coroutine after 1 second (the time necessary for the road tiles to spawn in).
    private void Start()
    {
        c_Own.enabled = true;
        StartCoroutine("IsRoadTile");
    }

    /// <summary>
    /// Checks if the connection to this object is a road tile or not. If not, it destroys itself.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Changes the value of the bool in this script so when the coroutine is called, it will be able to either destroy itself or not.
    /// </summary>
    /// <param name="other"></param>
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
