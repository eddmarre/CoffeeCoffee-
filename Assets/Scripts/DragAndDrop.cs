using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
namespace CoffeeCoffee.Functionality
{


    public class DragAndDrop : MonoBehaviour
    {
        Vector3 mOffset;
        float mZCoord;
        Camera main;
        const float semiVisible = .5f;
        const float fullyVisible = 1f;
        const float disableClickDelayTime = .5f;
        WaitForSeconds delayTimer;
        new Collider2D collider2D;
        private void Awake()
        {
            main = Camera.main;
            collider2D = GetComponent<Collider2D>();
            delayTimer = new WaitForSeconds(disableClickDelayTime);
        }
        private void OnMouseDown()
        {
            GenerateOffSet();
            changeSpriteAlpha(semiVisible);
        }

        private void OnMouseUp()
        {
            changeSpriteAlpha(fullyVisible);
        }
        private void OnMouseDrag()
        {
            MoveObject();
        }
        private void GenerateOffSet()
        {
            mZCoord = main.WorldToScreenPoint(transform.position).z;
            mOffset = transform.position - GetMouseWorldPos();
        }

        private Vector3 MoveObject()
        {
            transform.rotation = Quaternion.identity;
            return transform.position = GetMouseWorldPos() + mOffset;
        }

        Vector3 GetMouseWorldPos()
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = mZCoord;
            return main.ScreenToWorldPoint(mousePoint);
        }
        void changeSpriteAlpha(float newAlpha)
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = newAlpha;
            GetComponent<SpriteRenderer>().color = tmp;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            LockPosition(other);
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            //lock position of object
            LockPosition(other);
            StartCoroutine(DisableClickTimer());
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            StopAllCoroutines();
        }
        private void LockPosition(Collider2D other)
        {
            transform.position = other.transform.position;
        }
        public void EnableClick()
        {
            collider2D.enabled = true;
        }
        private void DisableClick()
        {
            collider2D.enabled = false;
        }
        IEnumerator DisableClickTimer()
        {
            yield return delayTimer;
            DisableClick();
        }

    }
}