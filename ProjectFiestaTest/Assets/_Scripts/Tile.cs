using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Transform[] conectors;
    [SerializeField] GameObject player;
    [SerializeField] GameObject camara;

    [SerializeField] float lerpDuration;

    public bool playerOn;
    public bool canMove;
    RaycastHit hit;

    public bool avalibleTile;
    public bool currentTile;
    public bool isBack;

    void Start()
    {
        camara = FindObjectOfType<Camera>().gameObject;
    }

    void Update()
    {
        if(player == null)
        {
            return;
        }
        else
        {
            camara.GetComponent<Camera>().transform.position = new Vector3(player.transform.position.x, 3f, player.transform.position.z-7f);
        }
        
        if (PlayerManager.Instance.endMove)
        {
            avalibleTile = false;
            if (currentTile) isBack = true; else isBack = false;
        }

        if (PhasesManager.Instance.movePhase)
        {
            if(canMove)
            {
                PlayerDirectionMove();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform.gameObject;
            currentTile = true;
            playerOn = true;
            canMove = true;

            if (isBack)
            {
                PlayerManager.Instance.totalMoves += 1;
            }
            else
            {
                isBack = true;
                PlayerManager.Instance.totalMoves -= 1;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canMove = false;
            avalibleTile = true;
            currentTile = false;
            playerOn = false;
        } 
    }

    private void PlayerDirectionMove()
    {
        int dirH = (int)Input.GetAxisRaw("Horizontal");
        int dirV = (int)Input.GetAxisRaw("Vertical");

        switch (dirH)
        {
            case 1:
                if (Physics.Raycast(conectors[0].position, conectors[0].TransformDirection(Vector3.forward), out hit, 1f))
                {
                    if (player.GetComponent<Player>().avalibleMoves > 0 || hit.transform.parent.transform.gameObject.GetComponent<Tile>().avalibleTile)
                    {
                        if (hit.transform.parent.transform.gameObject.GetComponent<Tile>().isBack == true)
                        {
                            StartCoroutine(BackTile());
                        }
                        else
                        {
                            StartCoroutine(ChangeTile(player.transform.position, hit.transform.parent.transform.position, 1f));
                        }
                    }
                }
                break;
            case -1:
                if (Physics.Raycast(conectors[1].position, conectors[1].TransformDirection(Vector3.forward), out hit, 1f))
                {
                    if (player.GetComponent<Player>().avalibleMoves > 0 || hit.transform.parent.transform.gameObject.GetComponent<Tile>().avalibleTile)
                    {

                        if (hit.transform.parent.transform.gameObject.GetComponent<Tile>().isBack == true)
                        {
                            StartCoroutine(BackTile());
                        }
                        else
                        {
                            StartCoroutine(ChangeTile(player.transform.position, hit.transform.parent.transform.position, 1f));
                        }
                    }
                }
                break;
        }

        switch (dirV)
        {
            case 1:
                if (Physics.Raycast(conectors[2].position, conectors[2].TransformDirection(Vector3.forward), out hit, 1f))
                {
                    if (player.GetComponent<Player>().avalibleMoves > 0 || hit.transform.parent.transform.gameObject.GetComponent<Tile>().avalibleTile)
                    {

                        if (hit.transform.parent.transform.gameObject.GetComponent<Tile>().isBack == true)
                        {
                            StartCoroutine(BackTile());
                        }
                        else
                        {
                            StartCoroutine(ChangeTile(player.transform.position, hit.transform.parent.transform.position, 1f));
                        }
                    }
                }
                break;
            case -1:
                if (Physics.Raycast(conectors[3].position, conectors[3].TransformDirection(Vector3.forward), out hit, 1f))
                {
                    if (player.GetComponent<Player>().avalibleMoves > 0 || hit.transform.parent.transform.gameObject.GetComponent<Tile>().avalibleTile)
                    {

                        if (hit.transform.parent.transform.gameObject.GetComponent<Tile>().isBack == true)
                        {
                            StartCoroutine(BackTile());
                        }
                        else
                        {
                           
                            StartCoroutine(ChangeTile(player.transform.position, hit.transform.parent.transform.position, 1f));
                        }
                    }
                }
                break;
        }                                                                                                    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(conectors[0].position, conectors[0].TransformDirection(Vector3.forward));
        Gizmos.DrawRay(conectors[1].position, conectors[1].TransformDirection(Vector3.forward));
        Gizmos.DrawRay(conectors[2].position, conectors[2].TransformDirection(Vector3.forward));
        Gizmos.DrawRay(conectors[3].position, conectors[3].TransformDirection(Vector3.forward));
    }

    IEnumerator ChangeTile(Vector3 start, Vector3 target, float duration)
    {
        float timeElapsed = 0f;
        canMove = false;
        while(timeElapsed < duration)
        {
            player.transform.position = Vector3.Lerp(start, target, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        player.transform.position = target;
        yield return null; 
    }

    IEnumerator BackTile()
    {
        isBack = false;
        yield return new WaitUntil(()=> isBack == false);

        StartCoroutine(ChangeTile(player.transform.position, hit.transform.parent.transform.position, 1f));
        yield return null;
    }
}
