using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatbamSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private Katbam katbam;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }


    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;

            Instantiate(katbam, transform.position, Quaternion.identity);
        }
    }
}
