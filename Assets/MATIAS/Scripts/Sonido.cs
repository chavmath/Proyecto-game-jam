using UnityEngine;

public class SoundController : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }
}
