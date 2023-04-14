using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class L_PlayerController : MonoBehaviour
{
    Rigidbody rb;
    bool groundCheck;
    [SerializeField] Button jump;
    [SerializeField] GameObject joyMove;
    [SerializeField] float walkSpeed, jumpForce;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        joyMove = GameObject.Find("Fixed Joystick(Move)");

        jump = GameObject.Find("JumpBTN").GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //if (!pv.IsMine)
        //{
        //    return;
        //}

        jump.onClick.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
        //if (!pv.IsMine) return;
        Move();
        //if (Timer.Instance.startGame)
        //{
            
        //}
    }

    void Move()
    {
        float moveH = joyMove.GetComponent<FixedJoystick>().Horizontal;
        float moveV = joyMove.GetComponent<FixedJoystick>().Vertical;

        Vector3 inputDir = new Vector3(moveH, 0, 0);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            groundCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            groundCheck = false;
        }
    }
    public void Jump()
    {
        if (groundCheck) rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
