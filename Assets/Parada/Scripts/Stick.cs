using System.Collections;
using UnityEngine;

public class Stick : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(TimeDestroy());
    }
    private IEnumerator TimeDestroy()
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(transform.gameObject);
    }
}
