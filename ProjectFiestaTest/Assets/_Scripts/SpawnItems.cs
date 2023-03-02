using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField] bool itemEmpty;
    [SerializeField] GameObject item;
    void Update()
    {
        if (itemEmpty)
        {

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("item"))
        {
            itemEmpty = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("item"))
        {
            itemEmpty = true;
            StartCoroutine(SpawnItem());
        }
    }
    IEnumerator SpawnItem()
    {
        yield return new WaitUntil(() => itemEmpty == true);
        yield return new WaitForSeconds(3f);
        Instantiate(item, transform.position, Quaternion.identity);
        itemEmpty = false;
    }
}
