using UnityEngine;

namespace Emilio.CatcherEggs
{
    public class CatchingObject : MonoBehaviour
    {
        [SerializeField] protected float speed = 5;
        [SerializeField] protected float acceleration = 8;

        void Update()
        {
            if (GameManager.instance.GetTimeLeft() <= 0)
            {
                Destroy(gameObject);
            }
            
            speed += acceleration * Time.deltaTime;
            transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
        }
    }
}
