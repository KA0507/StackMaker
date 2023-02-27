using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwithScene : MonoBehaviour
{
    public float delay = 1.5f; // thời gian chờ trước khi chuyển sang scene tiếp theo
    private int currentSceneIndex = 0;

    private void LoadNextScene()
    {
        // Tăng chỉ số scene và chuyển sang scene tiếp theo trong thứ tự
        currentSceneIndex++;
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            Debug.LogWarning("Không có scene tiếp theo để chuyển đến.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Lấy chỉ số của scene hiện tại
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            // Chờ một thời gian rồi chuyển sang scene tiếp theo
            Invoke("LoadNextScene", delay);
        }
    }
}
