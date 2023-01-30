///* Scripted by Omabu - omabuarts@gmail.com */
//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections.Generic;

//public class ChangeObstacleAni : MonoBehaviour
//{
//    [SerializeField]
//    private List<string> animationList = new List<string> {
//                                                              "Attack",
//                                                              "Bounce",
//                                                              "Clicked",
//                                                              "Death",
//                                                              "Eat",
//                                                              "Fear",
//                                                              "Fly",
//                                                              "Hit",
//                                                              "Idle_A", "Idle_B", "Idle_C",
//                                                              "Jump",
//                                                              "Roll",
//                                                              "Run",
//                                                              "Sit",
//                                                              "Spin/Splash",
//                                                              "Swim",
//                                                              "Walk"
//                                                            };
//    private List<string> facialExpList = new List<string> {
//                                                              "Eyes_Annoyed",
//                                                              "Eyes_Blink",
//                                                              "Eyes_Cry",
//                                                              "Eyes_Dead",
//                                                              "Eyes_Excited",
//                                                              "Eyes_Happy",
//                                                              "Eyes_LookDown",
//                                                              "Eyes_LookIn",
//                                                              "Eyes_LookOut",
//                                                              "Eyes_LookUp",
//                                                              "Eyes_Rabid",
//                                                              "Eyes_Sad",
//                                                              "Eyes_Shrink",
//                                                              "Eyes_Sleep",
//                                                              "Eyes_Spin",
//                                                              "Eyes_Squint",
//                                                              "Eyes_Trauma",
//                                                              "Sweat_L",
//                                                              "Sweat_R",
//                                                              "Teardrop_L",
//                                                              "Teardrop_R"
//                                                            };

//    private List<string> animalNameList = new List<string> {
//                                                              "Alpaca",
//                                                              "Bull",
//                                                              "Goat",
//                                                              "Goose",
//                                                              "Horse",
//                                                              "Lamb",
//                                                              "Llama",
//                                                              "Mallard",
//                                                              "Turkey"
//                                                            };


//    public void ChangeAnimation()
//    {
//        gameObject.GetComponent<Animator>().Play("Death");
//    }

//}