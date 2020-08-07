using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public float zSpawn=0;
    public float tileLenght = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        SpwanTile(0);
        SpwanTile(1);
        SpwanTile(2);
        SpwanTile(3);
        SpwanTile(4);
        SpwanTile(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpwanTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLenght;

    }
}
