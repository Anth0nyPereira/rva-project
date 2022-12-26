using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Match List", menuName = "Match List", order = 53)]
public class MatchListSO : ScriptableObject
{
    [SerializeField]
    private List<MatchSO> matchList;

    public List<MatchSO> ColorList { get => matchList; set => matchList = value; }
}
