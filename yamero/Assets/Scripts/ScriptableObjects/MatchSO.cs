using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Match", menuName = "match", order = 52)]
public class MatchSO : ScriptableObject
{

    [SerializeField]
    private string matchName;

    [SerializeField]
    private List<CollidableSO> collidables = new();

    public string MatchName { get => matchName; set => matchName = value; }
    public List<CollidableSO> Collidables { get => collidables; set => collidables = value; }
}
