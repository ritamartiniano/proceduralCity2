using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM_CubeRoad : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Instance1") || other.CompareTag("Instance2") || other.CompareTag("Instance3") || other.CompareTag("Instance4") || other.CompareTag("Instance0"))
        {
            Destroy(other.gameObject);
            StartCoroutine("DestroyMe");
        }
    }

    private IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        yield return null;
    }
}