using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Item;
using CoffeeCoffee.Triggers;
using UnityEngine;
using UnityEngine.Sprites;
namespace CoffeeCoffee.Functionality
{
    public class DragAndDrop : MonoBehaviour
    {
        const float semiVisible = .5f;
        const float fullyVisible = 1f;
        const float disableClickDelayTime = .5f;

        Vector3 mOffset;
        Camera main;
        WaitForSeconds delayTimer;
        new Collider2D collider2D;
        Triggerable triggerable;

        float mZCoord;
        new Rigidbody2D rigidbody2D;
        float gravityScale;

        bool canMove = true;
        private void Awake()
        {
            main = Camera.main;
            collider2D = GetComponent<Collider2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            gravityScale = rigidbody2D.gravityScale;
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
            if (canMove)
            {
                MoveObject();
            }
        }

        private void GenerateOffSet()
        {
            mZCoord = main.WorldToScreenPoint(rigidbody2D.position).z;
            mOffset = transform.position - GetMouseWorldPos();
        }
        private void MoveObject()
        {
            transform.rotation = Quaternion.identity;
            Vector2 mousePosition = GetMouseWorldPos() + mOffset;
            rigidbody2D.MovePosition(mousePosition);
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

        public void StopDragMovement()
        {
            canMove = false;
        }
        public void AllowDragMovement()
        {
            canMove=true;
        }
    }
}