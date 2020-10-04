using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Health of enemy")]
    private int m_MaxHealth;

    [SerializeField]
    [Tooltip("How fast enemy moves")]
    private float m_Speed;

    [SerializeField]
    [Tooltip("Damage dealt per frame")]
    private float m_Damage;

    [SerializeField]
    [Tooltip("Explosion on enemy death")]
    private ParticleSystem m_DeathExplosion;

    [SerializeField]
    [Tooltip("Chance of dropping health pill")]
    private float m_HealthPillDropRate;

    [SerializeField]
    [Tooltip("Type of health pill enemy drops")]
    private GameObject m_HealthPill;

    [SerializeField]
    [Tooltip("Points from killing this enemy")]
    private int m_Score;

    #endregion

    
    #region Private Variables
    private float p_curHealth;
    #endregion
    
    #region Cached Components
    private Rigidbody cc_Rb;
    #endregion

    #region Cached References
    private Transform cr_Player;
    #endregion

    #region Initalize
    private void Awake()
    {
        p_curHealth = m_MaxHealth;

        cc_Rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        cr_Player = FindObjectOfType<PlayerController>().transform;
    }
    #endregion

    #region Main Updates
    private void FixedUpdate()
    {
        Vector3 dir =  cr_Player.position - transform.position;
        dir.Normalize();
        cc_Rb.MovePosition(cc_Rb.position + dir * m_Speed * Time.fixedDeltaTime);
    }
    #endregion

    #region Collision Methods
    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().DecreaseHealth(m_Damage);
        }
    }
    #endregion

    #region Health Methods
    public void DecreaseHealth(float amount)
    {
        p_curHealth -= amount;
        if (p_curHealth <= 0)
        {
            ScoreManager.singleton.IncreaseScore(m_Score);
            if (Random.value < m_HealthPillDropRate)
            {
                Instantiate(m_HealthPill, transform.position, Quaternion.identity);
            }
            Instantiate(m_DeathExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    #endregion
}
