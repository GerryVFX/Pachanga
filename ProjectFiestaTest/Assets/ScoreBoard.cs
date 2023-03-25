using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class ScoreBoard : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform container;
    [SerializeField] GameObject scoreBoardPref;

    Dictionary<Player, ScoreBoardItem> scoreboardItems = new Dictionary<Player, ScoreBoardItem>();

    private void Start()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddScoreBoardItem(player);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddScoreBoardItem(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemoveScoreBoardItem(otherPlayer);
    }

    void AddScoreBoardItem(Player player)
    {
        ScoreBoardItem item = Instantiate(scoreBoardPref, container).GetComponent<ScoreBoardItem>();
        item.Initialized(player);
        scoreboardItems[player] = item;
    }
    void RemoveScoreBoardItem(Player player)
    {
        Destroy(scoreboardItems[player].gameObject);
        scoreboardItems.Remove(player);
    }
}
