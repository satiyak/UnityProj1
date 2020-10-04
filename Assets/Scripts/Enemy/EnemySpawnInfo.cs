using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnInfo 
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Name of enemy")]
    private string m_name;
    public string EnemyName
    {
        get
        {
            return m_name;
        }
    }

    [SerializeField]
    [Tooltip("Prefab of enemy to be spawned")]
    private GameObject m_EnemyGO;
    public GameObject EnemyGO
    {
        get
        {
            return m_EnemyGO;
        }
    }

    [SerializeField]
    [Tooltip("Seconds before next enemy spawned")]
    private float m_TimeToNextSpawn;
    public float TimeToNextSpawn
    {
        get
        {
            return m_TimeToNextSpawn;
        }
    }

    [SerializeField]
    [Tooltip("Number of enemies to spawn. If 0, spawn endlessly")]
    private int m_NumberToSpawn;
    public int NumberToSpawn
    {
        get
        {
            return m_NumberToSpawn;
        }
    }

    #endregion
}
