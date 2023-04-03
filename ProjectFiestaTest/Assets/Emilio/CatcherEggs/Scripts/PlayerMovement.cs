using System.Collections;
using UnityEngine;

namespace Emilio.CatcherEggs
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementVelocity = 8f;
        [SerializeField] private int currentLane = 1;
        [SerializeField] private Transform[] lanes;
        
        [SerializeField] private bool stuned = false;
        [SerializeField] private float stunedTime = 3;

        private Vector3 initialPosition;
        private Vector3 targetPosition;
        private Collider playerCollider;
        private MeshRenderer renderer;
        

        private void Start()
        {
            initialPosition = new Vector3(lanes[currentLane].position.x, transform.position.y, transform.position.z);
            targetPosition = new Vector3(lanes[currentLane].position.x, transform.position.y, transform.position.z);
            playerCollider = GetComponent<Collider>();
            renderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, movementVelocity * Time.deltaTime);
            
            if(stuned) return;
            
            // Movimiento hacia la izquierda
            if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
            {
                currentLane--;
                targetPosition = new Vector3(lanes[currentLane].position.x, transform.position.y, transform.position.z);
            }

            // Movimiento hacia la derecha
            if (Input.GetKeyDown(KeyCode.D) && currentLane < 2)
            {
                currentLane++;
                targetPosition = new Vector3(lanes[currentLane].position.x, transform.position.y, transform.position.z);
            }
        }

        public void Stuned()
        {
            if (stuned) return;
            
            StartCoroutine(InvokeStuned());
        }
        
        private IEnumerator InvokeStuned()
        {    
            playerCollider.enabled = false;
            stuned = true;
            StartCoroutine(InvokeFlickering());

            yield return new WaitForSeconds(stunedTime);
            
            stuned = false;
        }
        
        private IEnumerator InvokeFlickering()
        {
            var baseColor = renderer.material.color;
            var flickerTimer = stunedTime;
            
            while (flickerTimer + 1 > 0)
            {
                Color flashAlpha = renderer.material.color;
                // PingPong between 0.3 and 1;
                flashAlpha.a = 0.5f;
                // Assuming your renderer is on this.gameObject!
                renderer.material.color = flashAlpha;
                    
                yield return new WaitForSeconds(0.5f);
                
                renderer.material.color = baseColor;
                
                yield return new WaitForSeconds(0.5f);
                flickerTimer -= 1f;
            }
            
            renderer.material.color = baseColor;
            playerCollider.enabled = true;
        }
    }
}
