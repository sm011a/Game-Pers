using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private AudioSource audioSource;
    public AudioClip jumpSound;

    public float speed = 100f;
    private float jumpForce = 10f;

    public bool isOnGround = false;
    public bool gameOver = false;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpSound, 0.8f);
            isOnGround = false;
        }

        //Move Right
        else if (Input.GetKey(KeyCode.D) && !gameOver)
        {
            playerRb.AddForce(Vector2.right * speed * Time.deltaTime);
        }

        //Move Left
        else if (Input.GetKey(KeyCode.A) && !gameOver)
        {
            playerRb.AddForce(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Trampoline"))
        {
            gameObject.transform.Translate(Vector2.up * Time.deltaTime * 5000);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Exit");
        }
        if (other.gameObject.CompareTag("Exit Last"))
        {
            SceneManager.LoadScene(0);
            Debug.Log("Exit Last");
        }

        if (other.gameObject.CompareTag("Border"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Restart");
        }
    }
}
