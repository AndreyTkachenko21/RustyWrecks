using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDMG : MonoBehaviour
{
    public int healthPoints = 10; // начальное количество очков здоровья
    public int damage = 1; // количество урона, который наносит объект при столкновении

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Object")
        { // проверяем тэг объекта, с которым произошло столкновение
            healthPoints -= damage; // отнимаем очки здоровья
            Debug.Log("Health points remaining: " + healthPoints); // выводим в консоль количество оставшихся очков здоровья
        }
    }
}
