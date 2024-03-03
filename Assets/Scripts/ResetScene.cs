using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    // This script handles the resetting of the current scene.
    public class ResetScene : MonoBehaviour
    {
        public void OnResetClick()
        {
            // Delete all PlayerPrefs data
            PlayerPrefs.DeleteAll();

            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
