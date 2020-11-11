using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleInimigo : MonoBehaviour
{
    private Rigidbody2D rig;
    private float mov = 1F;
    public GameObject sons;
    public Text txtVidas;
    public static int life;

    

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        life = 10;
        txtVidas.text = "Life: "+life;
    }
    void Update()  {
        if (mov>0) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if (mov<0) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        rig.velocity = new Vector2(mov, rig.velocity.y);
    }
  

      void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            if (col.gameObject.transform.position.y > gameObject.transform.position.y+1) {
                sons.GetComponents<AudioSource>()[2].Play();
                Destroy(gameObject);
            } else {
                if(life == 1){
                    sons.GetComponents<AudioSource>()[1].Play();
                    Destroy(col.gameObject);
                    SceneManager.LoadScene("GameOver");
                }
                else{
                    life--;
                    txtVidas.text = "Life: "+life;
                }

            }
        } else if (col.gameObject.tag == "Fire") {
            sons.GetComponents<AudioSource>()[2].Play();
            Destroy(gameObject);
        } else {
            mov = mov * -1;
        }
          if(col.gameObject.CompareTag("Coins")){
              Destroy(col.gameObject);

         }   

    }
}
    