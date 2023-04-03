using UnityEngine;

namespace Emilio.CatcherEggs
{
    public class Bomb : CatchingObject
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerMovement>().Stuned();
                Destroy(gameObject);
            }
            
            if (other.name == "Floor")
            {
                Destroy(gameObject);
            }
        }
    }
}
