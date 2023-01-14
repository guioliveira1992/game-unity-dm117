using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiControl : MonoBehaviour
{
    public GameObject player;
    public float velocidade = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("personagem");
        // int typeZumbi = Random.Range(1, 28);
        // transform.GetChild(typeZumbi).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        Vector3 direcao  = player.transform.position -  transform.position;

        Quaternion newRotation = Quaternion.LookRotation(direcao);  
        GetComponent<Rigidbody>().MoveRotation(newRotation);

        if(distance > 2.7)
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position
            + (direcao.normalized * velocidade * Time.deltaTime));

            GetComponent<Animator>().SetBool("atack", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("atack", true);

        }
    }

    void AtackEnemy()
    {
        Time.timeScale = 0;
        player.GetComponent<PlayerControl>().gameOverText.SetActive(true);
         player.GetComponent<PlayerControl>().alive = false;
    }
}
