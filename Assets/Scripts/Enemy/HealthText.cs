using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HackSlash.Player.StateMachine;

namespace HackSlash
{
    public class HealthText : MonoBehaviour
    {
        public TextMeshProUGUI text;
        Animator animator;

        int DropAnimationHash = Animator.StringToHash("Drop Animation");

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            animator = GetComponent<Animator>();



            text.text = "";
            
        }



        public void DisplayDamage(int amount)
        {
            text.text = $"-{amount.ToString()}";

            animator.SetBool(DropAnimationHash, true);

            StartCoroutine(HideDisplayDamage());


        }

        IEnumerator HideDisplayDamage()
        {
            yield return new WaitForSeconds(.45f);
            animator.SetBool(DropAnimationHash,false);
            if (text.text != "")
            {
                text.text = "";
            }
          
        }



    }
}
