using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public abstract class BaseEnemy : MonoBehaviour
{
    protected Animator animator;
    protected AudioSource audioSource;
    protected Health health;

    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] protected EnemyType[] enemyTypes;
    protected EnemyType enemyType;

    protected bool canAttack = true;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        health = GetComponent<Health>();

        health.OnHurt += HandleHurt;
        health.OnDead += HandleDeath;
        enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
    }

    //private int PickRandonEnemyTypesIndex() => Random.Range(0, enemyTypes.Length);

    protected abstract void Update();

    private void HandleHurt()
    {
        animator.SetTrigger("hurt");
        PlayHitParticle();
    }
    
    private void HandleDeath()
    {
        canAttack = false;
        GetComponent<Collider2D>().enabled = false;
        animator.SetTrigger("dead");
        PlayHitParticle();
        StartCoroutine(DestroyEnemy(2));
    }

    private IEnumerator DestroyEnemy(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    private void PlayHitParticle()
    {
        ParticleSystem instantiatedParticle = Instantiate(hitParticle, transform.position, transform.rotation);
        instantiatedParticle.Play();
    }
}
