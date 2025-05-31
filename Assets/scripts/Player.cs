using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
