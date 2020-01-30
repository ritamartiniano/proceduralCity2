using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will spawn connections to the right of the specific perpendicular road.
/// </summary>
public class GM_PerpSpawnRight : MonoBehaviour
{
    [Tooltip("The road connection tile prefab.")]
    [SerializeField]
    private GameObject go_RoadConnection;

    // Start is called before the first frame update. It starts the coroutine.
    void Start()
    {
        StartCoroutine("SpawnRight");
    }

    /// <summary>
    /// This coroutine checks if there is a road tile to its left and connects with it.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnRight()
    {
        yield return new WaitForSeconds(1);
        //Right
        Collider[] c_RoadsRight = Physics.OverlapSphere(transform.position + new Vector3(10, 0, 0), 1f);

        if (c_RoadsRight.Length >= 2)
        {
            if (c_RoadsRight[0].gameObject.CompareTag("RoadTile") || c_RoadsRight[1].gameObject.CompareTag("RoadTile"))
            {
                float fl_Distance = Vector3.Distance(transform.position, c_RoadsRight[0].gameObject.transform.position);
                Vector3 v3_Position = new Vector3(transform.position.x + fl_Distance / 2, -0.003f, transform.position.z);
                Instantiate(go_RoadConnection, v3_Position, Quaternion.identity);
            }
        }

        yield return null;
    }

}
