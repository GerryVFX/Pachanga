using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Transform observer;
    [SerializeField] private Vector3[] facesLook;

    [SerializeField] private int currentFace;
    [SerializeField] private bool isRolling;
    private RaycastHit hit;
    
    public void ThrowDice()
    {
        if (isRolling) return;
        
        isRolling = true;
        StartCoroutine(RollDice());
    }

    private IEnumerator RollDice()
    {
        float timeElapsed = 0f;
        float timeduration = 1.5f;
       
        while(timeElapsed < timeduration)
        {
            transform.Rotate(1,1,1);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        int randomRotate = Random.Range(0, 5);
        transform.rotation = Quaternion.Euler(facesLook[randomRotate]);

        yield return new WaitForSeconds(0.2f);
        
        if(Physics.Raycast(observer.position, observer.TransformDirection(Vector3.forward), out hit, 1f))
        {
            if (hit.transform.gameObject.CompareTag("face"))
            {
                currentFace = int.Parse(hit.transform.gameObject.name);
            }
        }
        PlayerManager.Instance.totalMoves = currentFace;

        yield return new WaitUntil(() => PlayerManager.Instance.totalMoves > 0);
        PlayerManager.Instance.nDice -=1;
        isRolling = false;
        PhasesManager.Instance.currentPhase = Phases.None;
        
        yield return null;
    }
}
