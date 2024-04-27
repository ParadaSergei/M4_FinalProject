using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPointTrack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(ExitCollider(other));
    }
    private IEnumerator ExitCollider(Collider other)
    {
        yield return new WaitForSeconds(3f);
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
