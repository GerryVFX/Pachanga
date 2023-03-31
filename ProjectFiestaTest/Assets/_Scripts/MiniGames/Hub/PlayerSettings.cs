using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public static PlayerSettings Instance;
    public int characterID;
    public int nPlayer = 1;

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
        }
    }
    
    public void SetCharacter01()
    {
        characterID = 1;
    }
    public void SetCharacter02()
    {
        characterID = 2;
    }
    public void SetCharacter03()
    {
        characterID = 3;
    }
    public void SetCharacter04()
    {
        characterID = 4;
    }
    public void SetCharacter05()
    {
        characterID = 5;
    }
    public void SetCharacter06()
    {
        characterID = 6;
    }
}
