using UnityEngine;
using UnityEngine.AI;
public class Ghosts : MonoBehaviour
{
    float velocidade = 0.5f;
    public Transform PacDiva;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PacDiva == null)
        {
            PacDiva = GameObject.FindWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PacDiva != null)
        {
            Vector3 direcao = (PacDiva.position - transform.position).normalized;
            transform.position += direcao * velocidade * Time.deltaTime;
        }
    }
}
