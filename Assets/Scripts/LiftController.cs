using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LiftController : MonoBehaviour
{
    Rigidbody2D rb;
    public bool ByButton = false;
    GameObject Player;
    public GameObject FloorSelect;
  public  GameObject[] Floors,FloorSelectButton;
    bool Clicked = false;
   public int CurrentFloor, MovingfloorId;
    GameObject MovingFloor = null;
    public int OpenedFloors = 2;
    AudioSource FloorChoose,ElevatorCome;
    public AudioClip FloorChooseClip;
   public VolumeManager UpMusic, DownMusic;
    private void Start()
    {
        ElevatorCome = GetComponent<AudioSource>();
           rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
      
       // FloorSelectButton = GameObject.FindGameObjectsWithTag("FloorSelectButton");
        MovingFloor = Floors[0];
        CurrentFloor = 0;
        FloorSelect.SetActive(false);
      
       
        FloorChoose = gameObject.AddComponent<AudioSource>();
        FloorChoose.clip = FloorChooseClip;
        FloorChoose.outputAudioMixerGroup = ElevatorCome.outputAudioMixerGroup;
        foreach (GameObject obj in FloorSelectButton)
        {
            obj.gameObject.SetActive(false);
        }
        FloorSelectButton[1].gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        if (Clicked && CurrentFloor <= MovingfloorId) { 
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, MovingFloor.transform.position.y, 0f), Time.deltaTime * 0.5f);
        }
        if (Clicked && CurrentFloor >= MovingfloorId)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, MovingFloor.transform.position.y+4, 0f), Time.deltaTime * 0.5f);
        }
        if (transform.position.y < MovingFloor.transform.position.y + 3f && Clicked && CurrentFloor < MovingfloorId )
        {
            Clicked = false;
            Player.transform.parent = null;
            Player.AddComponent<PlayerController>();
            StopAllCoroutines();
            StartCoroutine("FloorSelectShrinkOut");
            CurrentFloor = MovingfloorId;
            MovingfloorId = 0;
        }
        if (transform.position.y > MovingFloor.transform.position.y + 3f && Clicked && CurrentFloor > MovingfloorId)
        {
            Clicked = false;
            Player.transform.parent = null;
            Player.AddComponent<PlayerController>();
            StopAllCoroutines();
            StartCoroutine("FloorSelectShrinkOut");
            CurrentFloor = MovingfloorId;
            MovingfloorId = 0;
        }

    }
    public void OnButtonClickFloor0()
    {
        MovingFloor = Floors[0];
        MovingfloorId = 0;
        SetParametresForLift();
        ReopenFloor(OpenedFloors);
        FloorSelectButton[MovingfloorId].gameObject.SetActive(false);
        StartCoroutine(SoundSwap(MovingfloorId));
    }
    public void OnButtonClickFloor1()
    {
        MovingFloor = Floors[1];
        SetParametresForLift();
        MovingfloorId = 1;
        ReopenFloor(OpenedFloors);
        FloorSelectButton[MovingfloorId].gameObject.SetActive(false);
        StartCoroutine(SoundSwap(MovingfloorId));
    }
    public void OnButtonClickFloor5()
    {
        MovingFloor = Floors[2];
        SetParametresForLift();
        MovingfloorId = 2;
        ReopenFloor(OpenedFloors);
        FloorSelectButton[MovingfloorId].gameObject.SetActive(false); 
        StartCoroutine(SoundSwap(MovingfloorId));
    }
    public void OnButtonClickFloor10()
    {
        MovingFloor = Floors[3];
        SetParametresForLift();
        MovingfloorId = 3;
        ReopenFloor(OpenedFloors);
        FloorSelectButton[MovingfloorId].gameObject.SetActive(false);
        StartCoroutine(SoundSwap(MovingfloorId));
    }
    public void OnButtonClickFloor15()
    {
        MovingFloor = Floors[4];
        SetParametresForLift();
        MovingfloorId = 4;
        ReopenFloor(OpenedFloors);
        FloorSelectButton[MovingfloorId].gameObject.SetActive(false);
        StartCoroutine(SoundSwap(MovingfloorId));
    }
    public void OnButtonClickFloor20()
    {
        MovingFloor = Floors[5];
        SetParametresForLift();
        MovingfloorId = 5;
        ReopenFloor(OpenedFloors);
        FloorSelectButton[MovingfloorId].gameObject.SetActive(false);
        StartCoroutine(SoundSwap(MovingfloorId));
    }
    public void OnButtonClickFloor25()
    {
        MovingFloor = Floors[6];
        SetParametresForLift();
        MovingfloorId = 6;
        ReopenFloor(OpenedFloors);
        FloorSelectButton[MovingfloorId].gameObject.SetActive(false);
        StartCoroutine(SoundSwap(MovingfloorId));
    }
    public void OnButtonClickFloor30()
    {
        MovingFloor = Floors[7];
        SetParametresForLift();
        MovingfloorId = 7;
        ReopenFloor(OpenedFloors);
        FloorSelectButton[MovingfloorId].gameObject.SetActive(false);
        StartCoroutine(SoundSwap(MovingfloorId));
    }

    void SetParametresForLift()
    {
        Clicked = true;
        if (!ByButton) { 
        Player.transform.parent = this.transform;
        }
        else
        {
            ByButton = false;
        }

        StopAllCoroutines();
        StartCoroutine("FloorSelectShrinkIn");
        Destroy(Player.GetComponent<PlayerController>());
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    IEnumerator FloorSelectShrinkIn()
    {
        float shrinking = 0.08f;
        while (shrinking-0.005f >0)
        {
            FloorSelect.transform.localScale = new Vector2(FloorSelect.transform.localScale.x - 0.003f, 0.08f);
            yield return new WaitForSeconds (0.01f);
            shrinking -= 0.003f;
        }
        FloorSelect.transform.localScale = Vector2.zero;
        yield return null;
    }

    void ReopenFloor(int OpenFlors)
    {
        FloorChoose.Play();
        for (int i = 0; i < OpenFlors; i++)
        {
            FloorSelectButton[i].gameObject.SetActive(true);
        }
    }
    void RenewGameobject(GameObject obj)
    {

    }
    IEnumerator FloorSelectShrinkOut()
    {
        ElevatorCome.Play();
        float shrinking = 0.0f;
        while (shrinking + 0.003f < 0.08)
        {
            FloorSelect.transform.localScale = new Vector2(FloorSelect.transform.localScale.x + 0.003f, 0.08f);
            yield return new WaitForSeconds(0.01f);
            shrinking += 0.003f;
        }
        FloorSelect.transform.localScale = new Vector2(0.08f, 0.08f);
       
        yield return null;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FloorSelect.SetActive(true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        FloorSelect.SetActive(false);
    }
    IEnumerator SoundSwap(int CurrentFloor)
    {
   if(CurrentFloor == 0)
        {
            DownMusic.VolumeDown();
            yield return new WaitForSeconds(3f);
            UpMusic.VolumeUp();
        }
        else
        {
            UpMusic.VolumeDown();
          
            yield return new WaitForSeconds(3f);
            DownMusic.VolumeUp();
        }
        yield return null;
    }
}
