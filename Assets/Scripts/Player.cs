using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject mesh;
    public static int count;
    public static float s;
    public GameObject[] ob;
    public Text text_score;
    private int scor;
    private int count_mesh;
    public GameObject panel_game_over;
    public Text score_text;
    public Text best_score_text;
    private int max_score;
    public AudioSource aud_start;
    public AudioSource aud_hits;
    public AudioSource aud_target;
    public GameObject[] constr;

    // Start is called before the first frame update
    void Start()
    {
        aud_start.Play();
        count = 0;
        s = 60;
        scor = 0;
        count_mesh = 0;
        PlayerPrefs.SetInt("scor", 1);
        PlayerPrefs.Save();
        Instantiate(mesh, new Vector3(Random.Range(-1.59f, 1.76f), Random.Range(-4f, 4f), 0), Quaternion.Euler(new Vector3(0, 0, 0)));


        Vector3 left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 right = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));
        //float height = (float)cam.pixelHeight / 2.0f;
        Instantiate(constr[0], new Vector3(left.x, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        Instantiate(constr[1], new Vector3(right.x, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        Instantiate(constr[2], new Vector3(0, left.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        Instantiate(constr[3], new Vector3(0, right.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
       // Debug.Log(left);
        Debug.Log(right);
    }

    // Update is called once per frame
    void Update()
    {
        text_score.text = "Score: " + scor.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("mesh"))
        {
            aud_target.Play();
            if (PlayerPrefs.HasKey("scor"))
            {
                scor += 100;
                PlayerPrefs.DeleteKey("scor");
            }
            else
                scor += 10;

            count_mesh++;
            Destroy(collision.gameObject);
            count++;
            Instantiate(mesh, new Vector3(Random.Range(-1.59f, 1.76f), Random.Range(-4f, 4f), 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            if (count == 3)
            {
                ob[0].GetComponent<Speed>().speed += 0.2f;
                ob[1].GetComponent<Speed>().speed += 0.2f;
                //Debug.Log("count = " + count);
                count = 0;
                s /= 2;
                //Debug.Log("count = " + s);
                StartCoroutine(spawn_ob());
            }
        }
        if (collision.collider.CompareTag("apply"))
        {
            aud_hits.Play();
            scor += (10 * count_mesh);
            Destroy(collision.gameObject);
        }

        if (collision.collider.CompareTag("hat"))
        {
            aud_hits.Play();
            Time.timeScale = 0f;
            panel_game_over.SetActive(true);
            score_text.text = "Score: " + scor.ToString();


            if (PlayerPrefs.HasKey("max_score"))
            {
                max_score = PlayerPrefs.GetInt("max_score");
            }
            else
            {
                max_score = 0;
            }
            if (scor > max_score)
            {
                best_score_text.text = "Best Score: " + scor.ToString();
                PlayerPrefs.SetInt("max_score", scor);

            }
            else
                best_score_text.text = "Best Score: " + max_score.ToString();

            Destroy(collision.gameObject);
        }
    }

    IEnumerator spawn_ob()
    {
        while (true)
        {

            Instantiate(ob[Random.Range(0, ob.Length)], new Vector3(Random.Range(-1.59f, 1.76f), 8, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            yield return new WaitForSeconds(s);
        }
    }
}
