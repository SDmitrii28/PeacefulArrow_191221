using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject player;
    public GameObject panel_game_over;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Vector3 left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 right = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));
        //float height = (float)cam.pixelHeight / 2.0f;
        //Instantiate(player, new Vector3(right.x-1.5f, left.y+0.7f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        player.transform.position = new Vector2(right.x - 0.7f, left.y + 0.7f);
        player.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        player.transform.Translate(Vector3.up * Time.deltaTime);
        player.transform.Translate(Vector3.right*(-1) * Time.deltaTime);
        //player.GetComponent<Rigidbody2D>().velocity = player.transform.forward;
       // player.transform.position = new Vector2(player.transform.position.x-Time.deltaTime, player.transform.position.y+Time.deltaTime*2);
    }
    public void Click_Rotate()
    {
        player.transform.eulerAngles-= new Vector3(0, 0, 90);
    }
    public void InMenu()
    {
        panel_game_over.SetActive(false);
        Application.LoadLevel(0);
    }
    public void Restart()
    {
        panel_game_over.SetActive(false);
        Application.LoadLevel(1);
    }
}
