using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class oyunzamanı : MonoBehaviour
{
    public float totalTime = 60f;
    private float timer;
    public TMP_Text timerText;
    public int nextSceneID;
    public AudioSource audioSource; // Ses kaynağı

    private bool gameEnded = false;

    void Start()
    {
        timer = totalTime;
    }

    void Update()
    {
        if (!gameEnded)
        {
            timer -= Time.deltaTime;
            if (timerText != null)
            {
                timerText.text = "Kalan Zaman: " + Mathf.Ceil(timer).ToString();
            }

            if (timer <= 0)
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        gameEnded = true;
        // Sahne geçişini burada yapın
        SceneManager.LoadScene(nextSceneID);

        // Ses çal
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
