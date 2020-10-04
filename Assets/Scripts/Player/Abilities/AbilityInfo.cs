using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityInfo
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Power of ability")]
    private int m_Power;
    public int Power
    {
        get
        {
            return m_Power;
        }
    }

    [SerializeField]
    [Tooltip("Range of ability")]
    private int m_Range;
    public int Range
    {
        get
        {
            return m_Range;
        }
    }
    #endregion
}
