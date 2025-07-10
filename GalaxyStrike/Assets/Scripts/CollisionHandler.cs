using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    GameSceneManager gameSceneManager;
    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground") return;
        gameSceneManager.ReloadLevel();

        var Dparticle = Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Dparticle.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
      
    }
}
