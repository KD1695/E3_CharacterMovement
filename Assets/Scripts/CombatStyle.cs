using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatStyle : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] Image loaderImage;
    [SerializeField] List<GameObject> abilityPanels;
    [SerializeField] List<Sprite> sprites;
    int activeIndex = 0;
    float switchTime = 0.66f;
    float counter = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            if(counter >= switchTime)
            {
                abilityPanels[activeIndex].SetActive(false);
                activeIndex = (activeIndex == 1) ? 0 : 1;
                abilityPanels[activeIndex].SetActive(true);
                iconImage.sprite = sprites[activeIndex];
                counter = 0;
            }
            else
            {
                counter += Time.deltaTime;
                loaderImage.fillAmount = counter / switchTime;
            }
        }
        else
        {
            counter = 0;
            loaderImage.fillAmount = 0;
        }
    }
}
