using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioStart;
    public AudioClip audioExit;

    public bool oneClick;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !oneClick)
        {
            oneClick = false;
            SceneManager.LoadScene(1);
            audioSource.PlayOneShot(audioStart, 0.7f);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quit");
            Application.Quit();
            audioSource.PlayOneShot(audioExit, 0.7f);
        }
    }
}
