using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public bool canPick;
    public GameObject myParent; 
    public void StartShake()
    {
        myParent.GetComponent<CollectObjects>().currentItems++;
        StartCoroutine(Shake(.5f, .5f));
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        CharacterController2D.instance.collectItem = false;
        Vector3 startPos = transform.localPosition;
        float elapsed = 0.0f;
         while(elapsed < duration)
        {

            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * magnitude);

            transform.localPosition = new Vector3(newPos.x, startPos.y, startPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        //gameObject.SetActive(false);
        transform.localPosition = startPos;
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canPick = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canPick = false;
        }
    }
}
