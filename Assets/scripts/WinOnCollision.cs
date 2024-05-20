using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOnCollision : MonoBehaviour
{
    // Sahne ID'sini Inspector'dan ayarlayabilirsiniz
    public int nextSceneID;

    private void OnTriggerEnter(Collider other)
    {
        // Eğer çarpan nesne oyuncu ise (Player tag'i olan nesne)
        if (other.CompareTag("player"))
        {
            // Oyunu kazanma işlemleri burada yapılır
            Debug.Log("Tebrikler, oyunu kazandınız!");

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
