using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollection : MonoBehaviour
{
    public static coinCollection instance = null;
    private AudioSource audioSource;
    public float turnSpeed;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            GameState.instance.coinCollected();
            this.GetComponent<Renderer>().enabled = false;
        }
    }
}
