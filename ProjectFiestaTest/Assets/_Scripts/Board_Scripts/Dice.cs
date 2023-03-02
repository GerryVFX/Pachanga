using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    [SerializeField] Transform observer;
    [SerializeField] Vector3[] facesLook;

    public int currentFace;
    [SerializeField] private bool isRolling;
    RaycastHit hit;

    void Update()
    {
        if(Physics.Raycast(observer.position, observer.TransformDirection(Vector3.forward), out hit, 1f))
        {
            if (hit.transform.gameObject.tag == "face")
            {
                Debug.DrawRay(observer.position, observer.TransformDirection(Vector3.forward), Color.red);
                currentFace = int.Parse(hit.transform.gameObject.name);
            }
        }
    }

    public void ThrowDice()
    {
        if (!isRolling)
        {
            isRolling = true;
            StartCoroutine(RollDice());   
        }
    }

    IEnumerator RollDice()
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

        PlayerManager.Instance.totalMoves = currentFace;

        yield return new WaitUntil(() => PlayerManager.Instance.totalMoves > 0);
        PlayerManager.Instance.nDice -=1;
        PhasesManager.Instance.rollPhase = false;
        isRolling = false;
        yield return null;
    }
}
