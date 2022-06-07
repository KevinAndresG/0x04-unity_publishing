using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private int score;
    public int health;
    public Text scoreText;
    public Text healthText;
    public Image pointsBG;
    public Text pointsText;
    public Image winLoseBG;
    public Text winLoseText;
    public Image coinsLeftBG;
    public Text coinsLefText;
    private Transform[] Coins;
    public PlayerController playerControll;
    public GameObject CoinsF;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1000f;
        score = 0;
        health = 5;
        Coins = CoinsF.GetComponentsInChildren<Transform>();
        pointsText.text = $"Level Coins: {Coins.Length - 1}";
        pointsBG.gameObject.SetActive(true);
        StartCoroutine(DisableIt(pointsBG));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
        }
        if (other.tag == "Goal" && score < Coins.Length - 1)
        {
            coinsLeftBG.gameObject.SetActive(true);
            coinsLefText.text = $"Coins Left: {Coins.Length - 1 - score}";
            StartCoroutine(DisableIt(coinsLeftBG));
        }
        if (other.tag == "Goal" && score >= (Coins.Length - 1))
        {
            winLoseBG.gameObject.SetActive(true);
            winLoseBG.color = Color.green;
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;
            playerControll.enabled = false;
            StartCoroutine(WinLoadScene(3));
        }
        if (health == 0)
        {
            winLoseBG.gameObject.SetActive(true);
            winLoseBG.color = Color.red;
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            playerControll.enabled = false;
            StartCoroutine(LoseLoadScene(3));
            Start();
        }
    }
    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }
    IEnumerator LoseLoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator WinLoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if ((SceneManager.GetActiveScene().buildIndex + 1) < 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("menu");
        }
    }
    IEnumerator DisableIt(Image toDisable)
    {
        yield return new WaitForSeconds(3);
        toDisable.gameObject.SetActive(false);
    }
}
