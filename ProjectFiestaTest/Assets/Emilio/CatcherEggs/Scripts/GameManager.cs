using System.Collections;
using TMPro;
using UnityEngine;

namespace Emilio.CatcherEggs
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        [SerializeField] private PlayerMovement player;
        [SerializeField] private int score = 0;
        [SerializeField] private float timeLeft = 60;

        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text timeLeftText;
        
        [SerializeField] private Egg[] eggPrefabs;
        [SerializeField] private Bomb bombPrefab;
        [SerializeField] private Transform[] spawnPoints;
        
        [SerializeField] private GameObject gameOverPanel;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnObject());
        }

        private void Update()
        {
            scoreText.text = score.ToString();
            timeLeftText.text = timeLeft.ToString("0.00");
            
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                gameOverPanel.SetActive(true);
                player.enabled = false;
                return;
            }
            
            timeLeft -= Time.deltaTime;
        }

        IEnumerator SpawnObject()
        {
            yield return new WaitForSeconds(1);
            while (timeLeft > 0)
            {
                // Selecionar al azar entre egg y bomb
                CatchingObject objectToSpawn =  RandomObject();

                // Seleccionar un punto de spawn al azar
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Instanciar el objeto en el punto de spawn
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
                
                yield return new WaitForSeconds(timeLeft > 15 ? timeLeft * 0.01f : 0.15f);
            }
        }
        
        private CatchingObject RandomObject()
        {
            var goldenEggThreshold = 0.1f; // Umbral de probabilidad, cuanto menor sea el valor, mayor será la probabilidad de que se seleccione esa opcion
            var bombThreshold = 0.4f;
            
            var randomNumber = Random.Range(0f, 1f);

            if (randomNumber < goldenEggThreshold)
            {
                return eggPrefabs[1];
            }
            else if(randomNumber < bombThreshold)
            {
                return bombPrefab;
            }
            else
            {
                return eggPrefabs[0];
            }
        }

        public void AddScore(int value)
        {
            score += value;
        }

        public float GetTimeLeft()
        {
            return timeLeft;
        }
    }
}

