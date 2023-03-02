using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEvent : MonoBehaviour
{
    [SerializeField] GameObject panelEvent;
    

    private void Start()
    {
         
    }

    private void OnTriggerStay(Collider other)
    {
        if (PlayerManager.Instance.endMove && PlayerManager.Instance.inEvent)
        {
            if (other.CompareTag("Player"))
            {
                panelEvent.SetActive(true);
            }
        }
        else return;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.Instance.inEvent = false;
        }
    }

    public void ClosePanel()
    {
        panelEvent.SetActive(false);
        PlayerManager.Instance.inEvent = false;
    }
}
