using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kaybetmedurumu : MonoBehaviour
{
    // Sahne ID'sini Inspector'dan ayarlayabilirsiniz
    public int nextSceneID;

    private void OnTriggerEnter(Collider other)
    {
        // Eğer çarpan nesne oyuncu ise (Player tag'i olan nesne)
        if (other.CompareTag("player"))
        {
         

            // Belirtilen sahneye geçiş yapar
            MoveToScene(nextSceneID);
        }
    }

    // Sahne geçiş fonksiyonu
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}

