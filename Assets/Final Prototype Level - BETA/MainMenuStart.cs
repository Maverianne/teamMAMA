using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    public static MainMenuStart intance;
    public Animator anim;
    public bool canStart;
    public GameObject dialogue;
    [SerializeField] private AudioSource start;
    [SerializeField] private AudioSource fire;
    public bool startDialogue;


    private bool raiseVolume = false;
    private float volume = .1f; 

    private void Awake()
    {
        intance = this;
    }
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        start = gameObject.GetComponent<AudioSource>();
        canStart = false;
        fire.volume = volume;
    }
    private void Update()
    {
        fire.volume = volume;
        if (canStart)
        {
            if (Input.GetKeyDown("space"))
            {
                anim.SetTrigger("starting");
                start.Play();
                raiseVolume = true;
                dialogue.SetActive(true);

            }
        }
        if (raiseVolume)
        {
            PlayFire();
        }
    }
    public void CanStartGame()
    {
        canStart = true;
    }
    public void DestroyAnim()
    {
        startDialogue = true;
        Destroy(gameObject);
    }
    public void PlayFire()
    {
        if(volume <  .5f)
        volume = volume + (.1f * Time.deltaTime);
    }

}
