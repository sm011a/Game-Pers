using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioStart;
    public AudioClip audioExit;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            audioSource.PlayOneShot(audioStart, 0.7f);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            audioSource.PlayOneShot(audioExit, 0.7f);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quit");
            Application.Quit();
            audioSource.PlayOneShot(audioExit, 0.7f);
        }
    }
}
