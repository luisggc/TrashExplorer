using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Animator Anime;
    public Rigidbody2D PlayerRigidbody;
    public int ForceJump;
    public bool slide;
    public bool run;
    public bool nothing;
    //Pick
    public bool PickT;
    public float picktemp;

    //movimento
    public float speed;
    private float x;
    public bool LookingRight;
    // private int contflip;


    //verifica o chao
    public Transform GroundCheck;
    public bool grounded;
    public LayerMask whatisgroud;

    //Slide
    public float slidetemp;
    private float timetemp;
    private bool slidepressed;

    //djump
    private bool djump;
    private int djumpi;


    //colisor
    public Transform Colisor;
    private bool colibox;
    private bool colibox2;

    //Audio
    public AudioSource audiod;
    public AudioClip soundjump;
    public AudioClip soundSlide;

    //pontuacao
    private string txtlixo;
    public UnityEngine.UI.Text txtlixos;
    private string pontucao;
    public UnityEngine.UI.Text pontuacaos;
    public UnityEngine.UI.Text variacaos;
    private string variacao;
    private float guitime;
    private float guispeed;
    //public GUIText txtlixos;
    public static int pontuacao;

    //strings
    string[] aTs = new string[7];
    string[] aCs = new string[7];
    string[] text = new string[7];

    ///touch
    public float maxTime;
    public float minSwipeDsit;
    float startTime;
    float swipeTime;
    float endTime;
    Vector3 startPos;
    Vector3 endPos;
    float swipeDistance;

    private bool slideslidar;





    // Use this for initialization
    void Start() {

        for (int i = 1; i < 7; i++) {
            //Debug.Log(i);
            aTs[i] = "t" + i;
            aCs[i] = "c" + i;
        }
        text[1] = "Metal";
        text[2] = "Não reciclável";
        text[3] = "Lixo Orgânico";
        text[4] = "Papel";
        text[5] = "Plástico";
        text[6] = "Vidro";
        colibox = false;
        djump = false;
        djumpi = 0;
        pontuacao = 0;
        PlayerPrefs.SetInt("pontuacao", pontuacao);
        //para mover, mude isso
        run = true;
        nothing = true;
        LookingRight = true;
        //contflip = 0;
        PickT = false;
        guispeed = 3;


    }

    ////////////////////////////////////////////////////////// Update is called once per frame///////////////////////////////////////////////////
    void Update() {
        guitime += guispeed * Time.deltaTime;
        if (guitime >= 5)
        {
            variacaos.text = "";
        }



        //////////////////////////////////////////////////////////Jump//////////////////////////////////////
        if (Input.GetButtonDown("Jump") && ((grounded == true) | (djump == true))) {
            pular();
        }

        if (Input.touchCount > 0)
        {
            //foreach(Touch touch in Input.touches) ;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {

                endTime = Time.time;
                endPos = touch.position;
                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;


                if (swipeTime < maxTime && swipeDistance > minSwipeDsit)
                {
                    swipe();
                }
                else
                {
                    if ((grounded == true))
                    {

                        PickT = true;
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////Slide/////////////////////////////////////////////////////////////
        slidar();
        slideslidar = false;
        /*
        if (Input.GetButton("Slide") && grounded) {
           // slidar();
            slide = true;
            slidepressed = true;
            if (colibox == false)
            {
                audiod.PlayOneShot(soundSlide);
                audiod.volume = 0.5f; //baixa o volume para a metade
                Colisor.position = new Vector3(Colisor.position.x, Colisor.position.y - 0.3f, Colisor.position.z);
                colibox = true;
            }
            timetemp = 0;
        }
        else
        {
            slidepressed = false;
        }

        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatisgroud);

        if (slide == true)
        {
            timetemp += Time.deltaTime;
            if (timetemp >= slidetemp)
            {
                if (slide)
                {

                    slide = false;
                    Colisor.position = new Vector3(Colisor.position.x, Colisor.position.y + 0.3f, Colisor.position.z);
                    colibox = false;
                }
            }
        }
        */
        ////////////////////////////////////////////////////////Mover////////////////////////////////////////////////
        /*
        if (Input.GetButton("Right"))
        {
            if (contflip == 0)
            {
                if (!LookingRight)
                {
                    LookingRight = true;
                    flip();
                    contflip = 1;
                }
            }
            run = true;
            x = transform.position.x;
            x += speed * Time.deltaTime;
            transform.position = new Vector3(x, transform.position.y);
        }
        else
        {
            contflip = 0;
       
            if (Input.GetButton("Left"))
            {
                if (contflip == 0)
                {
                    if (LookingRight)
                    {
                        LookingRight = false;
                        flip();
                        contflip = 1;
                    }
                }
                run = true;
                x = transform.position.x;
                x -= speed * Time.deltaTime;
                transform.position = new Vector3(x, transform.position.y);
            }
            else
            {
                run = false;
                contflip = 0;
            }

        }

    */


        //////PICK//////////////

        if (Input.GetButtonDown("Pick") && (grounded == true)) {
            PickT = true;
        }
        if (PickT == true)
        {
            timetemp += Time.deltaTime;
            if (timetemp >= picktemp)
            {
                if (PickT)
                {

                    PickT = false;
                    timetemp = 0;
                }
            }
        }
        ////////////////////Animações//////////////////////
        ////////////////O primeiro é o nome no animator

        Anime.SetBool("Jump", !grounded);
        Anime.SetBool("Slide", slide);
        Anime.SetBool("Run", run && !slide);
        //.SetBool("Nothing", run);
        Anime.SetBool("PickT", PickT);





        if (!grounded)
        {
            colibox = false;
        }
        else
        {
            djumpi = 0;
        }



    }

    ////////////////////////////////////Fora loop///////////////////////////////////////

    ////////////////////////////Funcs/////////////////////////////

    public void slidar()
    {
        if ( grounded && ((Input.GetButton("Slide")) | (slideslidar==true)))
        {
            // slidar();
            slide = true;
            slidepressed = true;
            if (colibox == false)
            {
                audiod.PlayOneShot(soundSlide);
                audiod.volume = 0.5f; //baixa o volume para a metade
                Colisor.position = new Vector3(Colisor.position.x, Colisor.position.y - 0.3f, Colisor.position.z);
                colibox = true;
            }
            timetemp = 0;
        }
        else
        {
            slidepressed = false;
        }

        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatisgroud);

        if (slide == true)
        {
            timetemp += Time.deltaTime;
            if (timetemp >= slidetemp)
            {
                if (slide)
                {

                    slide = false;
                    Colisor.position = new Vector3(Colisor.position.x, Colisor.position.y + 0.3f, Colisor.position.z);
                    colibox = false;
                }
            }
        }
    }


    
       
    


    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 1; i < 7; i++)
        {
            if (other.tag == aTs[i])
            {
                if (PickT)
                {
                    txtlixo = text[i];
                    other.gameObject.SetActive(false);
                    txtlixos.text = txtlixo;
                    pontuacao = pontuacao + 5;
                    variacao = "+5";
                    variacaos.text = variacao;
                    pontuacaos.text = pontuacao.ToString();
                    guitime = 0;

                }

            }

            if (other.tag == aCs[i])
            {

                if (PickT && txtlixo == text[i])
                {
                    txtlixo = "";
                    txtlixos.text = txtlixo;
                    pontuacao = pontuacao + 10;
                    variacao = "+10";
                    variacaos.text = variacao;
                    pontuacaos.text = pontuacao.ToString();
                    guitime = 0;
                }
                else
                {
                    if (!PickT && txtlixo == text[i])
                    {
                        if (pontuacao >= 10)
                        {
                            pontuacao = pontuacao - 10;
                            variacao = "-10";
                            variacaos.text = variacao;
                            pontuacaos.text = pontuacao.ToString();
                            guitime = 0;
                        }
                        else
                        {
                            if (pontuacao < 10 && pontuacao >= 5)
                            {
                                pontuacao = pontuacao - 5;
                                variacao = "-5";
                                variacaos.text = variacao;
                                pontuacaos.text = pontuacao.ToString();
                                guitime = 0;
                            }
                        }
                    }
                    else
                    {
                        if (PickT && txtlixo != text[i])
                        {
                            if (pontuacao >= 10)
                            {
                                pontuacao = pontuacao - 10;
                                variacao = "-10";
                                variacaos.text = variacao;
                                pontuacaos.text = pontuacao.ToString();
                                guitime = 0;
                            }
                            else
                            {
                                if (pontuacao < 10 && pontuacao >= 5)
                                {
                                    pontuacao = pontuacao - 5;
                                    variacao = "-5";
                                    variacaos.text = variacao;
                                    pontuacaos.text = pontuacao.ToString();
                                    guitime = 0;

                                }
                            }
                        }
                    }

                }
            }
        }
        if (other.tag == "barreira")
        {
            PlayerPrefs.SetInt("pontuacao", pontuacao);

            if (pontuacao > PlayerPrefs.GetInt("recorde"))
            {
                PlayerPrefs.SetInt("recorde", pontuacao);
            }
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("gameover");
#pragma warning restore CS0618 // Type or member is obsolete
            // SceneManager.LoadScene("gameover");
        }




    }


    public void pular()
    {
        if (djumpi <= 0)
        {
            PlayerRigidbody.AddForce(new Vector2(0, ForceJump));
            djumpi += 1;
            audiod.PlayOneShot(soundjump);
            audiod.volume = 1;
            djump = true;
            if (slide)
            {
                Colisor.position = new Vector3(Colisor.position.x, Colisor.position.y + 0.3f, Colisor.position.z);
                slide = false;
                if (slidepressed)
                {
                    Colisor.position = new Vector3(Colisor.position.x, Colisor.position.y - 0.3f, Colisor.position.z);

                }

            }

        }
        else
        {
            djump = false;
        }
    }

    void swipe()
    {
        Vector2 distance = endPos - startPos;

        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {

            if (distance.x > 0)
            {
                Debug.Log("direita");
                /*if ((grounded == true))
                {
                    PickT = true;
                }*/
            }
            if (distance.x < 0)
            {
                Debug.Log("esquerda");
            }
         }
            
        
    

        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            if (distance.y > 0 && ((grounded == true) | (djump == true)))
            {
                Debug.Log("cima");
                pular();
            }
            else
            {
                slideslidar = true;
                Debug.Log("pra baixo");
                slidar();
            }
        }
    }
    }






/*void flip()
{
    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    LookingRight = transform.localScale.x > 0;
}

}
//Debug.Log("Falso run");
PlayerControler.pontuacao

*/
