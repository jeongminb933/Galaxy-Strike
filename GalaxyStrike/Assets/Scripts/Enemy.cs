using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int scoreValue = 10;
    private int hitCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Scoreboard scoreboard;
    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        hitCount++;
        Debug.Log("½Ã¹ß");
        GameObject Dparticle = Instantiate(destroyedVFX, transform.position, Quaternion.identity);

        if(hitCount == 3)
        {
            
            Dparticle.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject);
            hitCount = 0;
            scoreboard.IncreaseScore(scoreValue);
        }
        

    }
}
