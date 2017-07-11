using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
    	// //pega os comandos do teclado
     //    float moveHorizontal = Input.GetAxis ("Horizontal");
     //    float moveVertical = Input.GetAxis ("Vertical");

     //    //Vector3 se refere aos 3 eixos canonicos
     //    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        Vector3 dir = Vector3.zero;
        dir.x= Input.acceleration.x;
        dir.z= Input.acceleration.y;
        if(dir.sqrMagnitude>1)
            dir.Normalize();

        // dir *=Time.deltaTime;
        // transform.Translate(dir * speed);

        rb.AddForce (dir * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}