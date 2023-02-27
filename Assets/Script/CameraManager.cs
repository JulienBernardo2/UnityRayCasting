using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public AudioSource myAudio;
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            myAudio.Play();
            particleSystem.Play();

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData))
            {
                if(hitData.collider.tag == "Target")
                {
                    hitData.collider.gameObject.SetActive(false);
                    GameManager.Instance.IncrementScore();
                }
            }
        }
    }
}
