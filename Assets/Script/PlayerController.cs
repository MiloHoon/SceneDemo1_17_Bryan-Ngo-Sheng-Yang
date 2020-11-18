using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float speed = 10;
    int healthBar = 10;
    int totalPowerUpLeft;
    int poweruUpCollected;

    public Text Life;
    public Text PowerUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PowerUp Left
        totalPowerUpLeft = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        Debug.Log("Total PowerUp Left" + totalPowerUpLeft);
        //Go To New Scene When 0 PowerUp Left
        if (totalPowerUpLeft == 0)
        {
            Debug.Log("Going To New Scene!");
            SceneManager.LoadScene("EndScene");
        }
        //Player Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        //Player Move Backward
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        //Player Move Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //Player Move Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthBar--;
            Life.GetComponent<Text>().text = "Life: " + healthBar;

            if (healthBar == 0)
            {
                Debug.Log("Going To New Scene!");
                SceneManager.LoadScene("EndScene");
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            poweruUpCollected ++;
            PowerUp.GetComponent<Text>().text = "PowerUp Collected: " + poweruUpCollected;

            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
