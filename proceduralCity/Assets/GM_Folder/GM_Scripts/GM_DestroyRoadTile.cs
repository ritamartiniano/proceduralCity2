using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_DestroyRoadTile : MonoBehaviour
{
    private GameObject go_Tile;

    // Start is called before the first frame update
    void Start()
    {
        go_Tile = null;
        StartCoroutine("DestroyTile");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("RoadTile"))
        {
            go_Tile = other.gameObject;
        }
    }

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
