using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    
    public GameObject platform;
    public GameObject Diamonds;
    Vector3 lastpos;
    float size;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;
        for (int i = 0; i < 20; i++)
        {
            SpwanPlatforms();
        }
        
    }

    public void StartSpwaning()
    {
        InvokeRepeating("SpwanPlatforms", 0.1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpwanPlatforms");
        }

    }
    void SpwanPlatforms()
    {
        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else if (rand >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(Diamonds, new Vector3(pos.x, pos.y + 2, pos.z), Diamonds.transform.rotation);
        }
    }
    void SpawnZ()
    {
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(Diamonds, new Vector3(pos.x, pos.y + 2, pos.z), Diamonds.transform.rotation);
        }
    }
     
}
