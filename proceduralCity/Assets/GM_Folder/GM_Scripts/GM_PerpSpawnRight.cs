using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_PerpSpawnRight : MonoBehaviour
{
    [SerializeField]
    private GameObject go_RoadConnection;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnRight");
    }

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
