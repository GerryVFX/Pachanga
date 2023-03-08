using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Transform[] connectors;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;
    
    [SerializeField] private bool canMove;
    
    [SerializeField] private bool availableTile;
    [SerializeField] private bool currentTile;
    [SerializeField] private bool isBack;
    
    RaycastHit hit;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>().gameObject;
    }

    private void Update()
    {
        if(player == null)
        {
            return;
        }

        var playerPosition = player.transform.position;
        mainCamera.GetComponent<Camera>().transform.position = new Vector3(playerPosition.x, 3f, playerPosition.z-7f);

        if (PlayerManager.Instance.endMove)
        {
            availableTile = false;
            isBack = currentTile;
        }

        if (PhasesManager.Instance.currentPhase == Phases.Move)
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
            availableTile = true;
            currentTile = false;
        } 
    }

    private void PlayerDirectionMove()
    {
        int dirH = (int)Input.GetAxisRaw("Horizontal");
        int dirV = (int)Input.GetAxisRaw("Vertical");

        switch (dirH)
        {
            case 1:
                if (Physics.Raycast(connectors[0].position, connectors[0].TransformDirection(Vector3.forward), out hit, 1f))
                {
                    if (PlayerManager.Instance.totalMoves > 0 || hit.transform.parent.transform.gameObject.GetComponent<Tile>().availableTile)
                    {
                        StartCoroutine(hit.transform.parent.transform.gameObject.GetComponent<Tile>().isBack
                            ? BackTile()
                            : ChangeTile(player.transform.position, hit.transform.parent.transform.position, 1f));
                    }
                }
                break;
            case -1:
                if (Physics.Raycast(connectors[1].position, connectors[1].TransformDirection(Vector3.forward), out hit, 1f))
                {
                    if (PlayerManager.Instance.totalMoves > 0 || hit.transform.parent.transform.gameObject.GetComponent<Tile>().availableTile)
                    {
                        StartCoroutine(hit.transform.parent.transform.gameObject.GetComponent<Tile>().isBack
                            ? BackTile()
                            : ChangeTile(player.transform.position, hit.transform.parent.transform.position, 1f));
                    }
                }
                break;
        }

        switch (dirV)
        {
            case 1:
                if (Physics.Raycast(connectors[2].position, connectors[2].TransformDirection(Vector3.forward), out hit, 1f))
                {
                    if (PlayerManager.Instance.totalMoves > 0 || hit.transform.parent.transform.gameObject.GetComponent<Tile>().availableTile)
                    {
                        StartCoroutine(hit.transform.parent.transform.gameObject.GetComponent<Tile>().isBack
                            ? BackTile()
                            : ChangeTile(player.transform.position, hit.transform.parent.transform.position, 1f));
                    }
                }
                break;
            case -1:
                if (Physics.Raycast(connectors[3].position, connectors[3].TransformDirection(Vector3.forward), out hit, 1f))
                {
                    if (PlayerManager.Instance.totalMoves > 0 || hit.transform.parent.transform.gameObject.GetComponent<Tile>().availableTile)
                    {
                        StartCoroutine(hit.transform.parent.transform.gameObject.GetComponent<Tile>().isBack
                            ? BackTile()
                            : ChangeTile(player.transform.position, hit.transform.parent.transform.position, 1f));
                    }
                }
                break;
        }                                                                                                    
    }
    
    private IEnumerator BackTile()
    {
        isBack = false;
        yield return new WaitUntil(()=> isBack == false);

        StartCoroutine(ChangeTile(player.transform.position, hit.transform.parent.transform.position, 1f));
        yield return null;
    }

    private IEnumerator ChangeTile(Vector3 start, Vector3 target, float duration)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(connectors[0].position, connectors[0].TransformDirection(Vector3.forward));
        Gizmos.DrawRay(connectors[1].position, connectors[1].TransformDirection(Vector3.forward));
        Gizmos.DrawRay(connectors[2].position, connectors[2].TransformDirection(Vector3.forward));
        Gizmos.DrawRay(connectors[3].position, connectors[3].TransformDirection(Vector3.forward));
    }
}
