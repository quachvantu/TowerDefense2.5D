using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    [SerializeField] private List<PathNode> nextNodes = new List<PathNode>();
    [SerializeField] private List<int> weights = new List<int>();

    private void OnValidate()
    {
        if (nextNodes.Count != weights.Count)
        {
            Debug.LogWarning($"{name}: Số lượng Next Nodes và Weights không khớp!");
        }
        foreach (int weight in weights)
        {
            if (weight < 0)
            {
                Debug.LogWarning($"{name}: Weight không được nhỏ hơn 0!");
            }
        }
    }
    public PathNode GetNextNode()
    {
        if (nextNodes.Count == 0)
        {
            return null;
        }
        else if (nextNodes.Count == 1)
        {
            return nextNodes[0];
        }
        else
        {
            int current = 0;
            int randomValue = Random.Range(0, weights.Sum());
            for (int i = 0; i < weights.Count; i++)
            {
                current += weights[i];
                if (randomValue < current)
                {
                    return nextNodes[i];
                }
            }
        }
        return null;
    }
}
