using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private CoinDisplayController coinDisplayController;
    public static CoinDisplayController CoinDisplayController { get; private set; }

    [SerializeField] private LifeDisplayController lifeDisplayController;
    public static LifeDisplayController LifeDisplayController { get; private set; }
    
    private void Awake() {
        CoinDisplayController = coinDisplayController;
        LifeDisplayController = lifeDisplayController;
    }
}
