using UnityEngine;

public class Player00Controller : MonoBehaviour
{
    [SerializeField] float speedMove;

    private void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(inputH, 0, inputV);
        dir.Normalize();

        transform.position = transform.position + dir * speedMove * Time.deltaTime;

        switch ((int) inputH)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0,90,0);
                break;
            case -1:
                transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
        }
        switch ((int)inputV)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case -1:
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
        }
    }
}
