using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
        else if (scene.buildIndex == 2)
        {
            PhotonNetwork.Instantiate(Path.Combine("FallPlataformPB", "PF_PlayerManager"), Vector3.zero, Quaternion.identity);
        }
        else if (scene.buildIndex == 3)
        {
            PhotonNetwork.Instantiate(Path.Combine("ClimbPB", "C_PlayerManager"), Vector3.zero, Quaternion.identity);
        }
        else if (scene.buildIndex == 4)
        {
            PhotonNetwork.Instantiate(Path.Combine("CollectorPB", "PC_PlayerManager"), Vector3.zero, Quaternion.identity);
        }
        else return;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
