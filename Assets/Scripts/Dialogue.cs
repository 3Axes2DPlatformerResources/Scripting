using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject {
        [SerializeField] private List<string> list;
        public List<string> List => list;
}