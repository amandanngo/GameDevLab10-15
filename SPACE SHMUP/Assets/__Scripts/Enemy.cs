using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoundsCheck))]  // Ensures BoundsCheck is attached
public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]
    public float health = 10f;   // Damage needed to destroy this enemy
    public int score = 100;      // Points earned for destroying this

    private BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    // Property to get/set position
    public Vector3 pos
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Update()
    {
        Move();

        // Check whether this Enemy has gone off the bottom of the screen
        if (!bndCheck.isOnScreen)
        {
            if (pos.y < bndCheck.camHeight - bndCheck.radius)
            {
                // We're off the bottom, so destroy this GameObject
                Destroy(gameObject);
            }
        }
    }

    // Virtual method for movement (can be overridden in subclasses)
    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= 10f * Time.deltaTime;  // Default downward movement
        pos = tempPos;
    }
}