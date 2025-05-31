using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using UnityEngine.Video;

public class Player : MonoBehaviour
{
    //int vida = 3;´para quando tiver os fantasmas
    public TextMeshProUGUI TextoPontos;
    public TextMeshProUGUI TextoVidas;
    public int Pontos = 0;

    void Start()
    {
        //Fazer o gameover
        

    }

    // Update is called once per frame
    void Update()
    {
        //Movimentos do pacman
        if (Input.GetAxisRaw("Horizontal") > 0)
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
          
    }

    void OnTriggerEnter(Collider comer)
    {
        if (comer.gameObject.tag == "Bolas")
        {
            Pontos += 10; ;
            Destroy(comer.gameObject);
            atualizarPontos();
        }

    }
    void atualizarPontos()
    {
        TextoPontos.SetText("Pontos: " + Pontos);
    }
}
