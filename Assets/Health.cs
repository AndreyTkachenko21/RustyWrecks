using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [Header("Health stats")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private double currentHealth;
    [SerializeField] private double speed;
    public Rigidbody rb;

    public event Action<float> HealthChanged;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "block" || gameObject.tag == "block")
        {
           

            ChangeHealth(2);
            Debug.Log($"{gameObject.name} hit {collision.gameObject.name} || cur hp {gameObject.GetComponent<Health>().currentHealth}");
        }
        else
        {
            if (collision.gameObject.GetComponent<Health>())
        {
            double damage;
            if (speed > 20)
            {
                if (speed < 40)
                {
                    damage = speed * 0.10;
                }
                else
                {
                    damage = speed * 0.15755;
                }
            }
            else damage = 0;
            collision.gameObject.GetComponent<Health>().ChangeHealth(Math.Round(damage, 2, MidpointRounding.ToEven));

        }
        }
    }
    private void ChangeHealth(double value)
    {
        currentHealth -= value;

        if (currentHealth <= 0)
        {
            Death();
        }
        else
        {
            float currentHealthAsPercantage = (float)currentHealth / maxHealth;
            HealthChanged?.Invoke(currentHealthAsPercantage);
        }
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
        Destroy(gameObject);
        Debug.Log("Player has destroyed");
        SceneManager.LoadScene(3);

    }
    private void Update()
    {
        speed = rb.velocity.magnitude * 3.6f;
    }
}
