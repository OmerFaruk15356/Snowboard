using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSound;

    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            FindObjectOfType<PlayerMovement>().DisableControl();
            Invoke("ReloadScene", 1f);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
