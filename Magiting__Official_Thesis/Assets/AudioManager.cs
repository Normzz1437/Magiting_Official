
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicScore;

    public AudioClip background;

    private void Start()
    {
        musicScore.clip = background;
        musicScore.Play();
    }
}
