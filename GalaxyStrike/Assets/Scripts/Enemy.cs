using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    private int hitCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnParticleCollision(GameObject other)
    {
        hitCount++;
        GameObject Dparticle = Instantiate(destroyedVFX, transform.position, Quaternion.identity);

        if(hitCount == 3)
        {
            Dparticle.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject);
            hitCount = 0;
        }
        

    }
}
