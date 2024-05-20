using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraFollow : MonoBehaviour
{
  
    // Ana karakteri takip  GameObject
    public Transform target;

    // Kameranın karakterden olan yüksekliği
    //Burayı duruma göre ayarlarız 
    public float height = 10f;

    void LateUpdate()
    {
        // Kameranın hedef pozisyonu
        Vector3 newPosition = target.position;
        newPosition.y += height;

        // Kameranın pozisyonu güncelle
        transform.position = newPosition;

        // Kameranın aşağıya bakması için
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
