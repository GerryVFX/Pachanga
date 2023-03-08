using UnityEngine;

public enum SceneType
{
    Selection,
    Board,
    MiniGame
}

public delegate void OnSceneTypeChanged(SceneType sceneType);

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public event OnSceneTypeChanged SceneChanged;

    [Header("Escena actual")] 
    public SceneType currentSceneType;
    private SceneType _tempSceneType;

    [Header("Información de juego")]
    public int nRound;
    public bool newGame;
    public bool endRound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _tempSceneType = currentSceneType;
    }

    private void Update()
    {
        if (_tempSceneType == currentSceneType) return;
        
        SceneChanged?.Invoke(currentSceneType);
        _tempSceneType = currentSceneType;
    }   
}
