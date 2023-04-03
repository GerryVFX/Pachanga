using UnityEngine;

namespace Emilio.CatcherEggs
{
    public class Egg : CatchingObject
    {
        public int value = 1;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.instance.AddScore(value);
                Destroy(gameObject);
            }
            
            if (other.name == "Floor")
            {
                Destroy(gameObject);
            }
        }
    }
}
