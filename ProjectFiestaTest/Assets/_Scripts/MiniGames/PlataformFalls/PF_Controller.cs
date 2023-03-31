using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PF_Controller : MonoBehaviour
{
    Rigidbody rb;
    PhotonView pv;

    [SerializeField] Button jump;
    [SerializeField] GameObject joyMove;
    [SerializeField] float walkSpeed, jumpForce;

    float verticalRotation;
    [SerializeField] bool grounded;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();
        joyMove = GameObject.Find("Fixed Joystick(Move)");
        jump = GameObject.Find("JumpBTN").GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!pv.IsMine) return;
        jump.onClick.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pv.IsMine) return;
        Move();
    }

    void Move()
    {
        float moveH = joyMove.GetComponent<FixedJoystick>().Horizontal;
        float moveV = joyMove.GetComponent<FixedJoystick>().Vertical;

        Vector3 inputDir = new Vector3(moveH, 0, moveV);
        transform.position = transform.position + inputDir * walkSpeed * Time.deltaTime;

        if (moveH > 0) transform.rotation = Quaternion.Euler(0, 90, 0);
        if (moveH < 0) transform.rotation = Quaternion.Euler(0, 270, 0);
        if (moveV > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (moveV < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        if (moveH > 0 && moveV > 0) transform.rotation = Quaternion.Euler(0, 45, 0);
        if (moveH > 0 && moveV < 0) transform.rotation = Quaternion.Euler(0, 135, 0);
        if (moveH < 0 && moveV > 0) transform.rotation = Quaternion.Euler(0, 315, 0);
        if (moveH < 0 && moveV < 0) transform.rotation = Quaternion.Euler(0, 225, 0);
    }
    public void Jump()
    {
        if (grounded) rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            grounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            grounded = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            grounded = true;
        }
    }
}