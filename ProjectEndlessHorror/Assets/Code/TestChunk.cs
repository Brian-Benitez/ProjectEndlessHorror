using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChunk : MonoBehaviour
{
    public GameObject Chunk;
    public Transform SpawnPoint;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Spawn();
        }
    }

    public void Spawn()
    {
        Instantiate(Chunk, SpawnPoint);
    }


}
