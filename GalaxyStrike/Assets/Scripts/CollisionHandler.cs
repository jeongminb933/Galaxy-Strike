using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground") return;
        var Dparticle = Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Dparticle.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
