using UnityEngine;

public class AI_BulletController : MonoBehaviour
{
    public Vector3 v3Direction;
    public float fSpeed = 0;
    
    private ParticleSystem myParticleSystem;
    [SerializeField] private ParticleSystem shootImpactFX;
    
    [SerializeField] private float timeToDestroy = 0.3f;
    
    [SerializeField] private int weaponDamage = 20;


    // Update is called once per frame
    private void OnEnable()
    {
        //shootImpactFX.Play();
    }
    void Update()
    {
        this.transform.position += v3Direction * fSpeed * Time.deltaTime;
    }

    public void Shoot(Vector3 v3Direction, float fSpeed)
    {
        this.fSpeed = fSpeed;
        this.v3Direction = v3Direction;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "AI")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(weaponDamage);
            
            //shootImpactFX.Play();
            Destroy(gameObject, timeToDestroy); 
        }

        
        
    }
}
