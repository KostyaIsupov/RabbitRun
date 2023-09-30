using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawner : MonoBehaviour
{
    public float MinTime = 1;
    public float MaxTime = 3;
    public float Percent = 0.1f;
    public GameObject SpawnObject;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Instantiate(SpawnObject, transform.position, Quaternion.identity);
        print("Carrot spawned");
    }

    IEnumerator Timer()
    {
        while (true)
        {
            float time = Random.Range(MinTime, MaxTime);

            yield return new WaitForSeconds(time);

            float random = Random.Range(0f, 1f);
            if (random < Percent)
            {
                Spawn();
            }
        }
    }
}
