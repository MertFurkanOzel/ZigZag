using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [SerializeField] public float startSpeed;
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] GameObject tapToPlayPanel;
    private float score;
    Direction direction;
    Vector3 vector;
    readonly private float frequency = 25;
    public float speed;
    private bool isStart = false;
    private Status status;
    private float time = 0;
    enum Status
    {
        rolling,
        falling,
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!isStart)
        {
            isStart = true;
            tapToPlayPanel.SetActive(false);
            StartCoroutine(update());
        }
    }
    private void LateUpdate()
    {
       if(status==Status.rolling&&isStart)
       {
            score +=Time.deltaTime*speed/2;
       }
       scoretext.text = ((int)score).ToString();
    }
    IEnumerator update()
    {
        while(transform.position.y > 0)
        {
            time += Time.deltaTime;
            if (Input.GetMouseButtonDown(0))
            {
                if (direction != 0)
                {
                    vector = Vector3.right;
                    direction = Direction.left;
                }
                else
                {
                    vector = Vector3.forward;
                    direction = Direction.right;
                }
            }
            speed = startSpeed + time / frequency;
            transform.Translate(speed * Time.deltaTime * vector);
            yield return null;
        }
        status = Status.falling;
        StartCoroutine(gameOver());
    }
    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(.5f);
        PlayerPrefs.SetInt("Score", (int)score);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);           
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Cube10")
        {
            StartCoroutine(GameObject.Find("Game").GetComponent<Path>().reset_chunk(collision.transform.parent.gameObject));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Diamond"))
        {
            Diamonds.destroy_diamond(collision.gameObject);
            score+=4;
        }
    }
}
