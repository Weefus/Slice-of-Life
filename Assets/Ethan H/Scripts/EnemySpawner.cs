using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public basicZombClass[] enemyPrefabs;
    public int prefab;
    float vx;
    float vy;
    bool hasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        prefab = Random.Range(0, enemyPrefabs.Length);
        vx = transform.position.x;
        vy = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasSpawned == false && collision.CompareTag("CameraRadius"))
        {
            Instantiate(enemyPrefabs[prefab], new Vector3(vx, vy, 4.33f), Quaternion.identity);
            hasSpawned = true;
        }
    }
}
