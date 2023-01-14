using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public float velocidade = 12;
    Vector3 direcao;
    public LayerMask floorMask;
    public GameObject gameOverText;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX  = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        

        // transform.Translate(direcao * velocidade * Time.deltaTime);

        

        GetComponent<Animator>().SetBool("moving", (direcao != Vector3.zero));

        if(!alive)
        {
            if(Input.GetButtonDown("Fire2"))
            {
                SceneManager.LoadScene("game");
            }
        }

        // if(direcao != Vector3.zero)
        // {
        //     GetComponent<Animator>().SetBool("moving", true);
        // }
        // else
        // {
        //     GetComponent<Animator>().SetBool("moving", false);
        // }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * velocidade * Time.deltaTime));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit impact;

        if(Physics.Raycast(ray, out impact, 100))
        {
            Vector3 playerTargetPosition = impact.point - transform.position;


            playerTargetPosition.y = transform.position.y;

            Quaternion newRotation = Quaternion.LookRotation(playerTargetPosition);  

            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }
}
