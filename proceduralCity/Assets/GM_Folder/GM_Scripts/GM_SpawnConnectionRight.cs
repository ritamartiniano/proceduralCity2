using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_SpawnConnectionRight : MonoBehaviour
{
    [SerializeField]
    private GameObject go_RoadConnection;

    private Vector3 v3_Rotation90;

    private Quaternion q_Rotation90;

    private Vector3 v3_Rotation30;

    private Quaternion q_Rotation30;

    private Quaternion q_RotationNeg30;

    private bool bl_IsConnectedRight = false;

    private bool bl_IsConnectedUp = false;

    private bool bl_IsConnectedDown = false;

   // private bool bl_IsConnectedLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        v3_Rotation90 = new Vector3(0, 90, 0);
        q_Rotation90.eulerAngles = v3_Rotation90;

        v3_Rotation30 = new Vector3(0, 30, 0);
        q_Rotation30.eulerAngles = v3_Rotation30;

        q_RotationNeg30.eulerAngles = -v3_Rotation30;

        StartCoroutine("SpawnConnection");
    }

    private IEnumerator SpawnConnection()
    {
        yield return new WaitForSeconds(1);

        //Right
        Collider[] c_RoadsRight = Physics.OverlapSphere(transform.position + new Vector3(10, 0, 0), 1f);

        if (c_RoadsRight.Length >= 2)
        {
            if (c_RoadsRight[0].gameObject.CompareTag("RoadTile") || c_RoadsRight[1].gameObject.CompareTag("RoadTile") || c_RoadsRight[0].gameObject.CompareTag("PerpTile") || c_RoadsRight[1].gameObject.CompareTag("PerpTile"))
            {
                float fl_Distance = Vector3.Distance(transform.position, c_RoadsRight[0].gameObject.transform.position);
                Vector3 v3_Position = new Vector3(transform.position.x + fl_Distance / 2 - 1.5f, -0.003f, transform.position.z);
                Instantiate(go_RoadConnection, v3_Position, Quaternion.identity);
                bl_IsConnectedRight = true;
            }
        }

        //Left - This has been moved to perpendicular roads.
        //if (bl_IsConnectedRight == false)
        //{
        //    Collider[] c_RoadsLeft = Physics.OverlapSphere(transform.position + new Vector3(-10, 0, 0), 1f);

        //    if (c_RoadsLeft.Length >= 2)
        //    {
        //        if (c_RoadsLeft[0].gameObject.CompareTag("RoadTile") || c_RoadsLeft[0].gameObject.CompareTag("PerpTile") || c_RoadsLeft[1].gameObject.CompareTag("RoadTile") || c_RoadsLeft[1].gameObject.CompareTag("PerpTile"))
        //        {//THIS ONE BUG TO THE RIGHT
        //            float fl_Distance = Vector3.Distance(transform.position, c_RoadsLeft[0].gameObject.transform.position);
        //            Vector3 v3_Position = new Vector3(transform.position.x - fl_Distance / 2, 0, transform.position.z);
        //            bl_IsConnectedLeft = true;
        //            Instantiate(go_RoadConnection, v3_Position, Quaternion.identity);
        //        }
        //    }
        //}
        /**
        else if (bl_IsConnectedRight == true)
        {
            Collider[] c_RoadsLeft = Physics.OverlapSphere(transform.position + new Vector3(-10, 0, 0), 1f);

            if (c_RoadsLeft.Length >= 2)
            {
                if (c_RoadsLeft[0].gameObject.CompareTag("RoadTile") || c_RoadsLeft[0].gameObject.CompareTag("PerpTile") || c_RoadsLeft[1].gameObject.CompareTag("RoadTile") || c_RoadsLeft[1].gameObject.CompareTag("PerpTile"))
                {
                    bl_IsConnectedLeft = true;
                }
            }
        }
       **/
        //Down
        Collider[] c_PerpRoadsDown = Physics.OverlapSphere(transform.position + new Vector3(0, 0, -10), 1f);

        if (c_PerpRoadsDown.Length >= 1)
        {
            if (c_PerpRoadsDown[0].gameObject.CompareTag("PerpTile"))
            {
                float fl_Distance = Vector3.Distance(transform.position, c_PerpRoadsDown[0].gameObject.transform.position);
                Vector3 v3_Position = new Vector3(transform.position.x, -0.003f, transform.position.z - fl_Distance / 2);
                bl_IsConnectedDown = true;
                Instantiate(go_RoadConnection, v3_Position, q_Rotation90);
            }
        }

        //Top
        Collider[] c_PerpRoadsAbove = Physics.OverlapSphere(transform.position + new Vector3(0, 0, 10), 1f);

        if (c_PerpRoadsAbove.Length >= 1)
        {
            if (c_PerpRoadsAbove[0].gameObject.CompareTag("PerpTile"))
            {
                float fl_Distance = Vector3.Distance(transform.position, c_PerpRoadsAbove[0].gameObject.transform.position);
                Vector3 v3_Position = new Vector3(transform.position.x, -0.001f, transform.position.z + fl_Distance / 2);
                bl_IsConnectedUp = true;
                Instantiate(go_RoadConnection, v3_Position, q_Rotation90);
            }

            if (c_PerpRoadsAbove[0].gameObject.CompareTag("RoadTile") || c_PerpRoadsAbove[1].gameObject.CompareTag("RoadTile"))
            {
                bl_IsConnectedUp = true;
            }
        }

        //Top Left
        Collider[] c_RoadsTopLeft = Physics.OverlapSphere(transform.position + new Vector3(-10, 0, 10), 1f);

        if (c_RoadsTopLeft.Length == 2)
        {
            if (gameObject.transform.rotation == c_RoadsTopLeft[0].transform.rotation)
            {
                if (c_RoadsTopLeft[0].gameObject.CompareTag("RoadTile"))
                {
                    if (!c_RoadsTopLeft[0].gameObject.CompareTag("PerpTile") || !c_RoadsTopLeft[1].gameObject.CompareTag("PerpTile"))
                    {
                        if (!bl_IsConnectedUp)
                        {
                            Vector3 v3_Position = new Vector3(transform.position.x - 5, -0.001f, transform.position.z + 5);
                            Instantiate(go_RoadConnection, v3_Position, q_Rotation30);  
                        }
                    }
                }                 
            }
        }

        //Top Right
        Collider[] c_RoadsTopRight = Physics.OverlapSphere(transform.position + new Vector3(10, 0, 10), 1f);

        if (c_RoadsTopRight.Length == 2)
        {
            if (gameObject.transform.rotation == c_RoadsTopRight[0].transform.rotation)
            {
                if (c_RoadsTopRight[0].gameObject.CompareTag("RoadTile"))
                {
                    if (!c_RoadsTopRight[0].gameObject.CompareTag("PerpTile") || !c_RoadsTopRight[1].gameObject.CompareTag("PerpTile"))
                    {
                        if (!bl_IsConnectedUp && !bl_IsConnectedRight)
                        {
                            Vector3 v3_Position = new Vector3(transform.position.x + 5, -0.001f, transform.position.z + 5);
                            Instantiate(go_RoadConnection, v3_Position, q_RotationNeg30);
                        }
                    }
                }
            }
        }

        this.enabled = false;

        yield return null;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position + new Vector3(10, 0, 10), 1f);
    //}
}
