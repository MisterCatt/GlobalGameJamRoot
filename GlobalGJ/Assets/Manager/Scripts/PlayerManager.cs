using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }

    public Transform[] playerSpawnPoints;
    public GameObject[] PlayerPrefabs;

    public int birdLinePoints, frogLinePoints;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {

            instance = this;
        }

        GameManager.OnStateChange += SpawnPlayers;
    }

    void SpawnPlayers(GameState _state)
    {
        if (_state == GameState.SETUP)
        {
            Instantiate(PlayerPrefabs[0], playerSpawnPoints[0]);
            Instantiate(PlayerPrefabs[1], playerSpawnPoints[1]);

            GameManager.instance.UpdateState(GameState.PLAY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
