using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{



    public Slider slider;
    // Start is called before the first frame update
   


    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        //slider.value = health;
    }
    public void SetHealth(float Health)
    {
        slider.value = Health;
    }


}
