using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_resours : MonoBehaviour
{
    public GameObject[] ob;
    private float[] pos = { -1.59f, 0.15f, 1.76f };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn_ob());
    }

    IEnumerator spawn_ob()
    {
        while (true)
        {
            
                Instantiate(ob[Random.Range(0, ob.Length)], new Vector3(Random.Range(-1.59f, 1.76f), 8, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            yield return new WaitForSeconds(2f);
        }
    }

}
