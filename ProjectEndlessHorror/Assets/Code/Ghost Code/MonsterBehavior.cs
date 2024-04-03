using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    public GameObject MonsterPrefab;
    public Transform MonsterSpawnIn;

    private void Start()
    {
        MonsterPrefab.SetActive(false);
    }
    /// <summary>
    /// This function would talk about how the ghost moves. To clarify, to scare the player, not to follow the player in any movment.
    /// </summary>
    public void GhostMovement()
    {

    }
    /// <summary>
    /// This function talks about where the Ghost will spawn at during the players progression.
    /// </summary>
    public void GhostSpawnPoints()
    {
        // I will mark places the ghost can spawn in, places that the player cannot reach just yet or in front of them.
    }
    /// <summary>
    /// Very self explaintory, the ghost will spawn behind the player and cast a shadow. It will be locked behind the player.
    /// </summary>
    public void GhostSpawnBehindPlayer()
    {

    }
    /// <summary>
    /// This function just resets the ghost pos before the player notices.
    /// </summary>
    public void ResetGhostPos()
    {

    }

}
