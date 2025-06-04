using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using NUnit.Framework.Constraints;
using System.Collections;

using UnityEngine.Video;

public class Player : MonoBehaviour
{
    //int vida = 3;´para quando tiver os fantasmas
    public TextMeshProUGUI TextoPontos;
    public TextMeshProUGUI TextoVidas;
    public int Pontos = 0;
    private float Horizontal;
    private float Vertical;
    private float velocidade = 2f;

    void Start()
    {
       
        

    }

    // Update is called once per frame
    void Update()
    {
        //Movimentos do pacman
        /* if (Input.GetAxisRaw("Horizontal") > 0)
         {
             transform.Translate(0.1f, 0, 0);
         }
         if (Input.GetAxisRaw("Horizontal") < 0)
         {
             transform.Translate(-0.1f, 0, 0);
         }

         if (Input.GetAxisRaw("Vertical") > 0)
         {
             transform.Translate(0, 0, 0.1f);
         }
         if (Input.GetAxisRaw("Vertical") < 0)
         {
             transform.Translate(0, 0, -0.1f);
         }
        */

        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(Horizontal , 0, Vertical) * velocidade * Time.deltaTime);
        

    }

    void OnTriggerEnter(Collider toque)
    {
        if (toque.gameObject.tag == "Bolas")
        {
            Pontos += 10; ;
            Destroy(toque.gameObject);
            atualizarPontos();
        }

        if (toque.gameObject.tag == "Glitter")
        {
            Camera.main.transform.Rotate(0,0,180);
            float sorteioTempo = Random.Range(5, 8);
            StartCoroutine(Fim(sorteioTempo));
            Destroy(toque.gameObject);
        }

        if (toque.gameObject.tag == "Pingo")
        {
            Camera.main.fieldOfView = 50;
            toque.gameObject.SetActive(false);
            float sorteioTempo = Random.Range(5, 8);
            StartCoroutine (Fim2(sorteioTempo));
        }
        
        if (toque.gameObject.tag =="Ghosts")
        {
            morrer();
        }

    }

    private void OnCollisionEnter(Collision bateu)
    {
        if (bateu.gameObject.name == "Bomba")
        {
            string nameObject = bateu.gameObject.name; 
            Destroy(bateu.gameObject);
            Debug.Log("Colidiu com a " + nameObject);


        }
    }

    void atualizarPontos()
    {
        TextoPontos.SetText("Pontos: " + Pontos);
        if (Pontos == 710)
        {
            SceneManager.LoadScene("Menu");
        }

    }

    IEnumerator Fim(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        Camera.main.transform.Rotate(0, 0, 180);
    }

    IEnumerator Fim2(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        Camera.main.fieldOfView = 60;

    }

    void morrer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}



