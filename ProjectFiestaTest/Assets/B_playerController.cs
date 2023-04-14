using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_playerController : MonoBehaviour
{
    Rigidbody rb;
   
    [SerializeField] GameObject joyMove;
    [SerializeField] float walkSpeed;

    float verticalRotation;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        joyMove = GameObject.Find("Fixed Joystick(Move)");
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
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
}
