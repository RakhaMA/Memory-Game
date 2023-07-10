using UnityEngine;

public class CardMatchParticle : MonoBehaviour
{
    private new ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop(); // Ensure the particle system starts in a stopped state
    }

    public void PlayParticleEffect()
    {
        particleSystem.Play();
    }
}
