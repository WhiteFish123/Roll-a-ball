using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    // public float forceVal;
    public float moveSpeed=10f;
    public float extraGravityForce = 150f;
    private int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * extraGravityForce);
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");

        Vector3 moveDir=new Vector3(horizontal,0,vertical).normalized;

        Vector3 targetVelocity=moveDir*moveSpeed;
        rb.linearVelocity=targetVelocity;
        // Vector3 moveDir=new Vector3(horizontal,0,vertical);

        // rb.AddForce(moveDir*forceVal);
    }
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        score++;
        RefreshScoreText();
        
        if(score>=12)
        {
            winText.gameObject.SetActive(true); 
        }
    }
    void RefreshScoreText()
    {
        scoreText.text="Score: "+score;
    }
}
