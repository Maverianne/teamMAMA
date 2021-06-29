using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    public int myNumber;

    public void StartShake()
    {
        StartCoroutine(Shake(.5f, 3f));
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 startPos = transform.localPosition;
        float elapsed = 0.0f;
         while(elapsed < duration)
        {

            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * magnitude);

            transform.localPosition = new Vector3(newPos.x, startPos.y, startPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        gameObject.SetActive(false);
        transform.localPosition = startPos;
    }
}
