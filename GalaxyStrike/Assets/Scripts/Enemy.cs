using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnParticleCollision(GameObject other)
    {
        hitCount++;
        if(hitCount == 3)
        {
            Destroy(this.gameObject);
            hitCount = 0;
        }
        

    }
}
