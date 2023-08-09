using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public float Timer;
    private int TrainSound;
    [SerializeField] private AudioSource trainSource;
    [SerializeField] private Transform train;
    public float startPos;

    public Vector3 speed;

    public bool gameEnded;

    [SerializeField] private AudioSource personAudio;
    [SerializeField] private Animator personAnim;

    public float struglTime;

    [SerializeField] private GameObject gameEnd;


    [SerializeField] private Transform mosqObj;
    [SerializeField] private AudioSource clickSource;

    public static int dialog; // 0 - ni s kem, 1 - s derevom, 2 - s cherviakom


    public bool mosq = false;

    [SerializeField] private Transform triaskaGovna;

    void Start()
    {
        Timer = 0f;
        TrainSound = 0;
        startPos = train.position.x;
        speed = (new Vector3(0, 0, 0) - new Vector3(startPos, 0, 0)) / 120f;
        struglTime= 0f;
        dialog = 0;
        gameEnded= false;
        mosq = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameEnded && Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene("SampleScene"); }

        struglTime-= Time.deltaTime;

        Timer += Time.deltaTime;

        train.transform.position += speed * Time.deltaTime;

        if(mosq == true)  { mosqObj.transform.position += speed*7f * Time.deltaTime + new Vector3(0,Random.RandomRange(-1f,1f),0);
            if(Vector3.Distance(mosqObj.transform.position, personAnim.transform.position) > 235f)
            {
                mosqObj.GetComponent<AudioSource>().volume = 0f;
            }
            else
            {
                mosqObj.GetComponent<AudioSource>().volume =  (235f - Vector3.Distance(new Vector3(mosqObj.transform.position.x,0,0), new Vector3(personAnim.transform.position.x,0,0)))/75f;
            }
             //135 - 0, 0 - 1
        
        }

        if (Input.GetKeyDown(KeyCode.Space) && !gameEnded && struglTime<0f)
        {
            Struggle();
        }

        if (Timer > 10f && TrainSound==0)
        {
            PlayTrainSound();

        }
        if (Timer > 30f && TrainSound == 1)
        {
            PlayTrainSound();

        }
        if (Timer > 60f && TrainSound == 2)
        {
            PlayTrainSound();
        }
        if (Timer > 100f && TrainSound == 3)
        {
            PlayTrainSound();

        }
        if (Timer > 116f && TrainSound == 4)
        {
            PlayTrainSound();

        }
        if (Timer > 130f && TrainSound == 5)
        {
            PlayTrainSound();

        }
        if (Timer > 150f && TrainSound == 5)
        {
            PlayTrainSound();

        }
        if(Timer> 119f && !gameEnded)
        {
            gameEnded = true;
            EndTheGame();
        }
        if (Timer > 70f)
        {
            mosq = true;
        }
        if (Timer > 110f)
        {
            triaskaGovna.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, Random.RandomRange(-1f, 1f));
            if(triaskaGovna.position.y > 25f)
            {
                triaskaGovna.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 23f);
            }
            if (triaskaGovna.position.y < -25f)
            {
                triaskaGovna.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -23f);
            }
        }
    }

    private void PlayTrainSound()
    {
        TrainSound++;
        trainSource.Play();



    }
    private void EndTheGame()
    {
        gameEnd.SetActive(true);
    }
    public void OnClickSound()
    {
        clickSource.Play();
    }
    public void Struggle()
    {
        if (!gameEnded && struglTime < 0f)
        {
            struglTime = 2f;
            personAnim.Play("struggle");
            personAudio.Play();
        }
    }
}
