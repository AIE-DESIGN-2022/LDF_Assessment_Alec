using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRespawner : MonoBehaviour
{
    public GameObject bomb;
    public float waitForRespawn;
    GameObject bombClone;

    // Start is called before the first frame update
    public void Awake()
    {
        //InstantiateBomb();      
    }

    public void CloneBomb()
    {
        Invoke("InstantiateBomb", waitForRespawn);
    }

    public void InstantiateBomb()
    {
        bombClone = Instantiate(bomb, transform.position, transform.rotation, this.transform);
    }
}
