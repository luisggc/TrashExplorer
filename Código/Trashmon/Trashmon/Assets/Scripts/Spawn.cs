using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{

    public GameObject barreiraabaixar;
    public GameObject barreirapular;
    public GameObject lixocan1;
    public GameObject lixocan2;
    public GameObject lixocan3;
    public GameObject lixocan4;
    public GameObject lixocan5;
    public GameObject lixocan6;
    //lixos chão

    public GameObject lixo1;
    public GameObject lixo2;
    public GameObject lixo3;
    public GameObject lixo4;
    public GameObject lixo5;
    public GameObject lixo6;


    //

    public float ratespawn;
    public float currentTime;
    private int rand;
    private float y;
    private int q;


    // Use this for initialization
    void Start()
    {
        currentTime = 0;
        q = 1;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= ratespawn)
        {
            currentTime = 0;
            if (q == 1)
            {
                rand = Random.Range(1, 100);
                if (rand > 50)
                {
                    GameObject tempbarreira = Instantiate(barreiraabaixar) as GameObject;
                    tempbarreira.transform.position = new Vector3(transform.position.x, y+ 0.49f);
                }
                else
                {
                    GameObject tempbarreira = Instantiate(barreirapular) as GameObject;
                    tempbarreira.transform.position = new Vector3(transform.position.x, y);
                    

                }
                
                q = 2;
            }
            else
            {
                if (q == 2)
                {
                    int rand = Random.Range(1, 100);
                    if ((rand%6) == 0)
                    {
                        GameObject templixocan = Instantiate(lixocan1) as GameObject;
                        templixocan.transform.position = new Vector3(transform.position.x, transform.position.y);
                    }
                    else
                    {
                        if ((rand%6) == 1)
                        {
                            GameObject templixocan = Instantiate(lixocan2) as GameObject;
                            templixocan.transform.position = new Vector3(transform.position.x, templixocan.transform.position.y);

                        }
                        else
                        {
                            if ((rand%6) == 2)
                            {
                                GameObject templixocan = Instantiate(lixocan3) as GameObject;
                                templixocan.transform.position = new Vector3(transform.position.x, templixocan.transform.position.y);
                            }
                            else
                                if ((rand % 6) == 3)
                            {
                                GameObject templixocan = Instantiate(lixocan4) as GameObject;
                                templixocan.transform.position = new Vector3(transform.position.x, templixocan.transform.position.y);
                            }
                            else
                            {
                                if ((rand % 6) == 4)
                                {
                                    GameObject templixocan = Instantiate(lixocan5) as GameObject;
                                    templixocan.transform.position = new Vector3(transform.position.x, templixocan.transform.position.y);
                                }
                                else
                                {
                                    if ((rand % 6) == 5)
                                    {
                                        GameObject templixocan = Instantiate(lixocan6) as GameObject;
                                        templixocan.transform.position = new Vector3(transform.position.x, templixocan.transform.position.y);
                                    }
                                }   
                             }
                        }

                    }
                    q = 3;
                }

                ////////////// outro caso //////////
                else
                {
                    if (q == 3)
                    {
                        rand = Random.Range(1, 100);
                        if ((rand % 6) == 0)
                        {
                            GameObject templixo = Instantiate(lixo1) as GameObject;
                            templixo.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f);
                        }
                        else
                        {
                            if ((rand % 6) == 1)
                            {
                                GameObject templixo = Instantiate(lixo2) as GameObject;
                                templixo.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f);
                            }
                            else
                            {
                                if ((rand % 6) == 2)
                                {
                                    GameObject templixo = Instantiate(lixo3) as GameObject;
                                    templixo.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f);
                                }
                                else
                                {
                                    if ((rand % 6) == 3)
                                    {
                                        GameObject templixo = Instantiate(lixo4) as GameObject;
                                        templixo.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f);
                                    }
                                    else
                                    {
                                        if ((rand % 6) == 4)
                                        {
                                            GameObject templixo = Instantiate(lixo5) as GameObject;
                                            templixo.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f);
                                        }
                                        else
                                        {
                                            if ((rand % 6) == 5)
                                            {
                                                GameObject templixo = Instantiate(lixo6) as GameObject;
                                                templixo.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f);
                                            }
                                        }
                                    }
                                }
                            }
                        }
               q = 1;
                    }
                }
            }
        }
    }
}

   