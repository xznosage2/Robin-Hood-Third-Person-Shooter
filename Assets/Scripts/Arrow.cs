using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{


    Rigidbody rb;
    BoxCollider bx;
    bool disableRotation;
    public float destroyTime = 10f;
    AudioSource arrowAudio;
    int playerIndex;
    public int dmg { get; set; } = 22;


    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();
        arrowAudio = GetComponent<AudioSource>();

        Destroy(this.gameObject, destroyTime);

    }
    void Update()
    {
        if (dmg > 1) UpgradeArrow(dmg);

        if (!disableRotation)
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            arrowAudio.Play();
            disableRotation = true;
            //rb.isKinematic = true;
            //bx.isTrigger = true;
        }

        if (collision.collider.tag == "Target")
        {

            GameObject.Find("InGameUI/TargetsLeft").GetComponent<TargetsLeftText>().targetsLeft--;
            collision.collider.gameObject.SetActive(false);

        }

        if (collision.gameObject.tag == "Zom")
        {
            collision.gameObject.GetComponent<charaterManager>().TakeDamage(dmg);
        }
    }

    public void setPlayerIndex(int player)
    {
        playerIndex = player;
    }
    public int getPlayerIndex()
    {
        return playerIndex;
    }

    public void UpgradeArrow(int dmg)
    {
        GetComponent<Damage>().setDamage(dmg);
        Debug.Log(dmg);
    }



}
