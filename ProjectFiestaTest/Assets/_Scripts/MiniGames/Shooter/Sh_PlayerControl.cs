using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;

public class Sh_PlayerControl : MonoBehaviourPunCallbacks, IDamage
{

    PhotonView pv;
    Rigidbody rb;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Animator anim;
    [SerializeField] GameObject cameraHolder;
    [SerializeField] Image healthBar;
    [SerializeField] Button jump, changeWP, shoot;
    [SerializeField] GameObject joyMove, joyCamera;
    [SerializeField] float lookSens, sprintSpeed, walkSpeed, jumpForce, smoothTime;

    float verticalRotation;
    [SerializeField]bool grounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    [SerializeField] Sh_Item[] items;
    int itemIndex;
    int previousItemIndex = -1;
    public int weaponRange = 0;
    public bool haveRifle;

    const float maxHealth = 100f;
    [SerializeField]float currentHealth = maxHealth;

    Sh_PlayerManager playerManager;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();

        joyMove = GameObject.Find("Fixed Joystick(Move)");
        joyCamera = GameObject.Find("Fixed Joystick(Camera)");

        jump = GameObject.Find("JumpBTN").GetComponent<Button>();
        changeWP = GameObject.Find("WeaponBTN").GetComponent<Button>();
        shoot = GameObject.Find("ShootBTN").GetComponent<Button>();

        healthBar = GameObject.Find("Health").GetComponent<Image>();

        playerManager = PhotonView.Find((int)pv.InstantiationData[0]).GetComponent<Sh_PlayerManager>();
    }

    void Start()
    {
        if (!pv.IsMine) 
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
            return;
        }
        else
        {
            healthBar.fillAmount = currentHealth / maxHealth;
            EquipItem(0);
            jump.onClick.AddListener(Jump);
            changeWP.onClick.AddListener(ChangeWeapon);
            shoot.onClick.AddListener(Shoot);
        }     
    }

    // Update is called once per frame
    void Update()
    {
        if (!pv.IsMine) return;
        Look();
        Move();

        if (haveRifle)
        {
            changeWP.enabled = true;
        }
        else changeWP.enabled = false;
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

    void EquipItem(int _index)
    {
        itemIndex = _index;
 
        items[itemIndex].itemGO.SetActive(true);

        if(previousItemIndex != -1)
        {
            items[previousItemIndex].itemGO.SetActive(false);
        }
        previousItemIndex = itemIndex;

        if (pv.IsMine)
        {
            Hashtable hash = new Hashtable();
            hash.Add("itemIndex", itemIndex);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if(changedProps.ContainsKey("itemIndex") && !pv.IsMine && targetPlayer == pv.Owner)
        {
            EquipItem((int)changedProps["itemIndex"]);
        }   
    }

    void ChangeWeapon()
    {

        if (weaponRange == 0)
        {
            weaponRange += 1;
        }
        else if (weaponRange == 1) 
        {
            weaponRange -= 1;
        } 

        EquipItem(weaponRange);
    }

    void Shoot()
    {
        anim.SetTrigger("Shoot");
        audioSource.PlayOneShot(sounds[0]);
        items[itemIndex].Use();
    }

    public void TakeDamage(float damage)
    {
        pv.RPC(nameof(RPC_TakeDamage), pv.Owner, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage, PhotonMessageInfo info)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
            Sh_PlayerManager.find(info.Sender).GetKills();
        }
    }

    void Die()
    {
        playerManager.Die();
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

        if (other.CompareTag("item"))
        {
            haveRifle = true;
        }

        if (other.CompareTag("Finish"))
        {
            Die();
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
