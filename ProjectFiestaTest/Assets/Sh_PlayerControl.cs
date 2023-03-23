using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;


public class Sh_PlayerControl : MonoBehaviour
{
    PhotonView pv;
    Rigidbody rb;
    [SerializeField] GameObject cameraHolder;
    [SerializeField] Button jump;
    [SerializeField] GameObject joyMove, joyCamera;
    [SerializeField] float lookSens, sprintSpeed, walkSpeed, jumpForce, smoothTime;

    float verticalRotation;
    [SerializeField]bool grounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        joyMove = GameObject.Find("Fixed Joystick(Move)");
        joyCamera = GameObject.Find("Fixed Joystick(Camera)");
        jump = GameObject.Find("JumpBTN").GetComponent<Button>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (!pv.IsMine) 
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
            return;
        } 
        jump.onClick.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pv.IsMine) return;
        Look();
        Move();
    }

    private void FixedUpdate()
    {
        if (!pv.IsMine) return;
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    void Look()
    {
        transform.Rotate(Vector3.up * joyCamera.GetComponent<FixedJoystick>().Horizontal * lookSens);

        verticalRotation += joyCamera.GetComponent<FixedJoystick>().Vertical * lookSens;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalRotation;
    }

    void Move()
    {
        Vector3 moveDir = new Vector3(joyMove.GetComponent<FixedJoystick>().Horizontal, 0, joyMove.GetComponent<FixedJoystick>().Vertical).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * walkSpeed, ref smoothMoveVelocity, smoothTime);
    }

    public void Jump()
    {
        if(grounded) rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
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
