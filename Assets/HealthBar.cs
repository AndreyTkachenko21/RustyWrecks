using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFilling;
    [SerializeField] Health health;
    private Camera camera;

    public void Awake()
    {
        health.HealthChanged += OnHealthChanged;
        camera = Camera.main;
    }

    private void OnDestroy()
    {
        health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valueAsPercantage)
    {
        Debug.Log(valueAsPercantage);
        healthBarFilling.fillAmount = valueAsPercantage;
    }

    private void LateUpdate()
    {
       // transform.LookAt(new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z));
        //transform.Rotate(0, 90, 90);
    }
   
}
