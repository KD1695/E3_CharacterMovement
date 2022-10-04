using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] float coolDownTime = 30f;
    [SerializeField] string animatorBoolString;
    [SerializeField] Button button;
    [SerializeField] KeyCode actionKeyCode;
    [SerializeField] Image loaderImage;

    float counter = 0f;
    bool isAvailable = true;

    public static event Action<string> setCurrentAttack;

    void OnEnable( )
    {
        button.onClick.AddListener(HandleAttack);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(HandleAttack);
    }

    void Update()
    {
        if(Input.GetKeyDown(actionKeyCode))
        {
            HandleAttack();
        }

        if(counter > 0)
        {
            counter -= Time.deltaTime;
            loaderImage.fillAmount = 1 - (counter / coolDownTime);
        }
        else if(counter <= 0)
        {
            SetAvailability(true);
        }
    }

    public void HandleAttack()
    {
        if(counter == 0)
        {
            setCurrentAttack(animatorBoolString);
            SetAvailability(false);
        }
    }

    public void SetAvailability(bool _isAvailable)
    {
        isAvailable = _isAvailable;
        counter = isAvailable ? 0 : coolDownTime;
        loaderImage.enabled = !isAvailable;
    }
}
