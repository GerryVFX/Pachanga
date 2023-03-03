using UnityEngine;
using TMPro;

public class ItemKeeper : MonoBehaviour
{
    [SerializeField] TMP_Text pointsText;
    int points;

    private void Update()
    {
        pointsText.text = points.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {
            points += 10;
            Destroy(other.gameObject);
        }
    }
}
