using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatStyle : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] List<GameObject> abilityPanels;
    [SerializeField] List<Sprite> sprites;
    int activeIndex = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            abilityPanels[activeIndex].SetActive(false);
            activeIndex = (activeIndex == 1) ? 0 : 1;
            abilityPanels[activeIndex].SetActive(true);
            iconImage.sprite = sprites[activeIndex];
        }
    }
}
