using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10f;
    public float strafeSpeed = 15f;
    public float extraGravityForce = 100f;
    public float jumpForce = 20f;
    private int score = 0;
    private bool jumpPressed;

    private string currentScene;

    public TextMeshProUGUI winText;
    public TextMeshProUGUI failText;
    public TextMeshProUGUI scoreText;

    public Button btn;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        btn.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        failText.gameObject.SetActive(false);
        currentScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }

        if (currentScene == "Scene1" && transform.position.z >= 150)
        {
            failText.gameObject.SetActive(true);
            btn.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * extraGravityForce);

        Vector3 targetVelocity;

        if (currentScene == "Scene2")//捡金币
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 moveDir = new Vector3(horizontal, 0, vertical).normalized;
            targetVelocity = moveDir * moveSpeed;
        }
        else//跑酷
        {
            float horizontal = Input.GetAxis("Horizontal");
            targetVelocity = new Vector3(horizontal * strafeSpeed, 0, moveSpeed);
        }

        if (jumpPressed)
        {
            jumpPressed = false;
            rb.linearVelocity = new Vector3(targetVelocity.x, 0, targetVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        score++;
        RefreshScoreText();

        if (currentScene == "Scene1" && score >= 20)
        {
            winText.gameObject.SetActive(true);
            btn.gameObject.SetActive(true);
        }
        else if (currentScene == "Scene2" && score >= 12)
        {
            winText.gameObject.SetActive(true);
            btn.gameObject.SetActive(true);
        }
    }

    void RefreshScoreText()
    {
        scoreText.text = "得分: " + score;
    }
}