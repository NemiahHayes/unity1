using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public float moveSpeed;
    public float health;
    private float currentHealth;

    private void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        float posx = this.transform.position.x + moveSpeed;
        this.transform.position = new Vector2(posx, this.transform.position.y);
    }

    public void DamageEnemy(float damage)
    {
        currentHealth-=damage;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        Debug.Log($"{gameObject.name} health: {currentHealth}");
    }
}
