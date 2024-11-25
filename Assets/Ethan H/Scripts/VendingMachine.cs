using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public GameObject[] pickupPrefab;
    public SpriteRenderer sr;
    public Sprite sprite;
    float vx;
    float vy;
    float vz;
    int rnd;
    bool isEmpty = false;
   


    public float shakeDuration = 0.5f; 
    public float shakeMagnitude = 0.1f; 


    void Start()
    {
       
        vx = transform.position.x;
        vy = transform.position.y;
        vz = transform.position.z;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Hitbox") && isEmpty == false)
        {

            StartCoroutine(Shake());

            rnd = Random.Range(0, 2);
            Debug.Log(rnd);
            Instantiate(pickupPrefab[rnd], new Vector3(vx, vy - 1, vz), Quaternion.identity);
            isEmpty = true;
            sr.sprite = sprite;
        }
    }
    IEnumerator Shake()
    {
        Vector3 originalPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Calculate a random offset for shaking
            float offsetX = Random.Range(-shakeMagnitude, shakeMagnitude);
            float offsetY = Random.Range(-shakeMagnitude, shakeMagnitude);

            // Apply the shake
            transform.position = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset position to original after shaking
        transform.position = originalPosition;
    }

}


