using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Ana karakteri takip için gameobject
    public Transform target;

    // Kameranın karakterden olan mesafesi için offset değeri
    // Bunu deneyerek ayarlarız
    public Vector3 offset;

    // Kameranın hareket hızı
    // Rastgele koydum Bunu da denemek gerek
    public float smoothSpeed = 0.2f;

    void LateUpdate()
    {
        // İstenen pozisyon hesap
        Vector3 desiredPosition = target.position + offset;

        // smooth hareket için 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // pozisyon update 
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
