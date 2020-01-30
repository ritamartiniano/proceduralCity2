using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class prevents the instantiation of two or more road tiles on the same position.
/// </summary>
public class GM_DestroyRoadTile : MonoBehaviour
{
    private GameObject go_Tile;

    // Start is called before the first frame update. Assign a null value to the gameobject. Start the coroutine to destroy it.
    void Start()
    {
        go_Tile = null;
        StartCoroutine("DestroyTile");
    }

    //If it detects a road tile, assign it to the gameobject.
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("RoadTile"))
        {
            go_Tile = other.gameObject;
        }
    }

    /// <summary>
    /// This coroutine destroys the gameobject if it is a road. It then ends its process.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyTile()
    {
        yield return new WaitForSeconds(0.5f);

        if (go_Tile != null)
        {
            if (go_Tile.transform.rotation == gameObject.transform.rotation)
            {
                Destroy(go_Tile);
            }
        }

        this.enabled = false;
        yield return null;
    }
}
