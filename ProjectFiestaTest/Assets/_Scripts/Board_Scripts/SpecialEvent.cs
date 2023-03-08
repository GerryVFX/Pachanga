using UnityEngine;

public class SpecialEvent : MonoBehaviour
{
    [SerializeField] GameObject panelEvent;
    
    private void OnTriggerStay(Collider other)
    {
        if (!PlayerManager.Instance.endMove || !PlayerManager.Instance.inEvent) return;
        
        if (other.CompareTag("Player"))
        {
            panelEvent.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.Instance.inEvent = true;
        }
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
        PhasesManager.Instance.currentPhase = Phases.End;
    }
}
