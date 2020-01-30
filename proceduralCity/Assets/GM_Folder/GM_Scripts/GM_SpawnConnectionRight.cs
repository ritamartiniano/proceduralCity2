using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class spawns every road connection that goes to the right, above, below, top left, and top right.
/// </summary>
public class GM_SpawnConnectionRight : MonoBehaviour
{
    [Tooltip("The prefab road connection.")]
    [SerializeField]
    private GameObject go_RoadConnection;

    //A member used to give a rotation value.
    private Vector3 v3_Rotation90;

    //A member used to store the correspondent rotation value.
    private Quaternion q_Rotation90;

    //A member used to give a rotation value.
    private Vector3 v3_Rotation30;

    //A member used to store the correspondent rotation value.
    private Quaternion q_Rotation30;

    //A member used to store the correspondent negative rotation value.
    private Quaternion q_RotationNeg30;

    //Checks if the road has a connection to its right.
    private bool bl_IsConnectedRight = false;

    //Checks if the road has a connection above.
    private bool bl_IsConnectedUp = false;

    //Checks if the road has a connection below.
    private bool bl_IsConnectedDown = false;

    [Tooltip("The layermask the roads are in (Should be Road).")]
    [SerializeField]
    private LayerMask lm_Road;

    // Start is called before the first frame update. It starts some rotation values and starts 
    //the coroutine after 1 second (the time for the roads to spawn).
    void Start()
    {
        v3_Rotation90 = new Vector3(0, 90, 0);
        q_Rotation90.eulerAngles = v3_Rotation90;

        v3_Rotation30 = new Vector3(0, 30, 0);
        q_Rotation30.eulerAngles = v3_Rotation30;

        q_RotationNeg30.eulerAngles = -v3_Rotation30;

        StartCoroutine("SpawnConnection");
    }

    /// <summary>
    /// Instantiates the connections between road tiles.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnConnection()
    {
        yield return new WaitForSeconds(1);

        //Instantiates a sphere collider to the right.
        Collider[] c_RoadsRight = Physics.OverlapSphere(transform.position + new Vector3(10, 0, 0), 1f, lm_Road);

        //Checks if it collides with two or more objects.
        if (c_RoadsRight.Length >= 2)
        {
            //If it finds a road, it calculates the distance from it and it instantiates a road tile between the two.
            //It has a particular y transform because in this way it won't clip with other roads.
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
        //Instantiates a sphere collider downwards.
        Collider[] c_PerpRoadsDown = Physics.OverlapSphere(transform.position + new Vector3(0, 0, -10), 1f, lm_Road);

        //Checks if it collides with one or more objects.
        if (c_PerpRoadsDown.Length >= 1)
        {
            //If it finds a pependicular road, it calculates the distance from it and it instantiates a road tile between the two.
            //It has a particular y transform because in this way it won't clip with other roads.
            //The connection road is rotated by 90°.
            if (c_PerpRoadsDown[0].gameObject.CompareTag("PerpTile"))
            {
                float fl_Distance = Vector3.Distance(transform.position, c_PerpRoadsDown[0].gameObject.transform.position);
                Vector3 v3_Position = new Vector3(transform.position.x, -0.003f, transform.position.z - fl_Distance / 2);
                bl_IsConnectedDown = true;
                Instantiate(go_RoadConnection, v3_Position, q_Rotation90);
            }
        }

        //Top
        //Instantiates a sphere collider upwards.
        Collider[] c_PerpRoadsAbove = Physics.OverlapSphere(transform.position + new Vector3(0, 0, 10), 1f, lm_Road);

        //Checks if it collides with one or more objects.
        if (c_PerpRoadsAbove.Length >= 1)
        {
            //If it finds a pependicular road, it calculates the distance from it and it instantiates a road tile between the two.
            //It has a particular y transform because in this way it won't clip with other roads.
            //The connection road is rotated by 90°.
            if (c_PerpRoadsAbove[0].gameObject.CompareTag("PerpTile"))
            {
                float fl_Distance = Vector3.Distance(transform.position, c_PerpRoadsAbove[0].gameObject.transform.position);
                Vector3 v3_Position = new Vector3(transform.position.x, -0.001f, transform.position.z + fl_Distance / 2);
                bl_IsConnectedUp = true;
                Instantiate(go_RoadConnection, v3_Position, q_Rotation90);
            }

            //If it finds a road tile, it means that the road is already connected upwards.
            if (c_PerpRoadsAbove[0].gameObject.CompareTag("RoadTile") || c_PerpRoadsAbove[1].gameObject.CompareTag("RoadTile"))
            {
                bl_IsConnectedUp = true;
            }
        }

        //Top Left
        //Instantiates a sphere collider to the top left.
        Collider[] c_RoadsTopLeft = Physics.OverlapSphere(transform.position + new Vector3(-10, 0, 10), 1f, lm_Road);

        //Checks if it collides with two objects.
        if (c_RoadsTopLeft.Length == 2)
        {
            //Checks if their rotations are the same. If they are not, do not connect.
            if (gameObject.transform.rotation == c_RoadsTopLeft[0].transform.rotation)
            {
                //Connect only if it is a road tile and not a perpendicular tile.
                if (c_RoadsTopLeft[0].gameObject.CompareTag("RoadTile"))
                {
                    //Just double checking this is not a perpendicular tile.
                    if (!c_RoadsTopLeft[0].gameObject.CompareTag("PerpTile") || !c_RoadsTopLeft[1].gameObject.CompareTag("PerpTile"))
                    {
                        //If it is not already connected above... Connect them with a rotation of 30°.
                        if (!bl_IsConnectedUp)
                        {
                            Vector3 v3_Position = new Vector3(transform.position.x - 5, -0.001f, transform.position.z + 5);
                            Instantiate(go_RoadConnection, v3_Position, q_Rotation30);  
                        }
                    }
                }                 
            }
        }

        //Top Right (Look above).
        Collider[] c_RoadsTopRight = Physics.OverlapSphere(transform.position + new Vector3(10, 0, 10), 1f, lm_Road);

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

        //Stop the script once it has run once.
        this.enabled = false;

        yield return null;
    }

    //Checks where the sphere is instantiated. Editor only.
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position + new Vector3(10, 0, 10), 1f);
    //}
}
