using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Flappy_PlayerController : MonoBehaviour
{
    public float speed;   
    public float jumpForce;   
    public float moveDir;

    public TMP_Text coinTXT;

    int coins;

    Rigidbody rb;
    //PhotonView pv;

    [SerializeField] Button jump;
    [SerializeField] GameObject joyMove;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        joyMove = GameObject.Find("Fixed Joystick(Move)");
        jump = GameObject.Find("JumpBTN").GetComponent<Button>();
    }
    void Start()
    {
        //if (!pv.IsMine)
        //{
        //    Destroy(cameraF.gameObject);
        //    return;
        //}  

        jump.onClick.AddListener(Jump);
    }

    void Update()
    {
        moveDir = joyMove.GetComponent<FixedJoystick>().Horizontal;

        Vector3 inputDir = new Vector3(moveDir, 0, 0);
        transform.position = transform.position + inputDir * speed * Time.deltaTime;

        coinTXT.text = string.Format("Coins: {0}", coins);
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins += 1;
            Destroy(other.gameObject);
        }
    }
}
