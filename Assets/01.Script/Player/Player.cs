using System;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private PlayerInput input;
   [SerializeField] private PlayerData playerData;
   
   
   private Rigidbody2D rigidbody2D;

   private void Awake()
   {  
      rigidbody2D = GetComponent<Rigidbody2D>();   
   }

   private void Update()
   {
      rigidbody2D.linearVelocity = input.Movement * playerData.MoveSpeed;
   }
   
   
}
