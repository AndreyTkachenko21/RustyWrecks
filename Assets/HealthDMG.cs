using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDMG : MonoBehaviour
{
    public int healthPoints = 10; // ��������� ���������� ����� ��������
    public int damage = 1; // ���������� �����, ������� ������� ������ ��� ������������

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Object")
        { // ��������� ��� �������, � ������� ��������� ������������
            healthPoints -= damage; // �������� ���� ��������
            Debug.Log("Health points remaining: " + healthPoints); // ������� � ������� ���������� ���������� ����� ��������
        }
    }
}
