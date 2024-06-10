using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private Player playerReference;
    [SerializeField] protected float movementSpeed = 1.0f;
    [SerializeField] protected float attackingRange = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GetPlayerReference();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        ExplodeNearPlayer();
    }

    protected virtual void GetPlayerReference()
    {
        if (playerReference == null)
        {
            playerReference = FindObjectOfType<Player>();
        }
    }

    protected virtual void MoveTowardsPlayer()
    {
        if(Vector2.Distance(transform.position, playerReference.transform.position) >= attackingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerReference.transform.position, Time.deltaTime * movementSpeed);
        }
    }

    protected virtual void ExplodeNearPlayer()
    {
        if (Vector2.Distance(transform.position, playerReference.transform.position) <= 1.0f)
        {
            Destroy(gameObject);
        }
    }
}
