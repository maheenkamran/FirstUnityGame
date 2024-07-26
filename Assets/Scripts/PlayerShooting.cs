using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject pebblePrefab;  // The pebble prefab
    public Transform shootPoint;     // The point from where the pebble will be shot
    public float shootForce = 10f;   // The force with which the pebble will be shot
    public float shootInterval = 0.5f; // Time interval between shots

    private float shootTimer;

    void Update()
    {
        // Check if enough time has passed to shoot another pebble
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        // Instantiate the pebble at the shoot point
        GameObject pebble = Instantiate(pebblePrefab, shootPoint.position, shootPoint.rotation);

        // Get the Rigidbody component of the pebble and apply force in the shootPoint's direction
        Rigidbody2D rb = pebble.GetComponent<Rigidbody2D>();
        rb.velocity = shootPoint.up * shootForce; // For 2D, use 'up'; for 3D, use 'forward'
    }
}
