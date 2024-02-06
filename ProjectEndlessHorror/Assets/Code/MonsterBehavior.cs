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

}
