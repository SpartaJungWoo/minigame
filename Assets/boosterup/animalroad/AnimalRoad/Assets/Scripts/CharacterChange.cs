/* Scripted by Omabu - omabuarts@gmail.com */
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterChange : MonoBehaviour
{
	public int dropdowncheck;
	public int animal_name;
	[SerializeField]
	private GameObject[] animal;
	private GameObject[] animal_obstacle;

	[SerializeField]
	private int animalIndex;
	private List<string> animationList = new List<string> {
															  "Attack",
															  "Bounce",
															  "Clicked",
															  "Death",
															  "Eat",
															  "Fear",
															  "Fly",
															  "Hit",
															  "Idle_A", "Idle_B", "Idle_C",
															  "Jump",
															  "Roll",
															  "Run",
															  "Sit",
															  "Spin/Splash",
															  "Swim",
															  "Walk"
															};
	private List<string> facialExpList = new List<string> {
															  "Eyes_Annoyed",
															  "Eyes_Blink",
															  "Eyes_Cry",
															  "Eyes_Dead",
															  "Eyes_Excited",
															  "Eyes_Happy",
															  "Eyes_LookDown",
															  "Eyes_LookIn",
															  "Eyes_LookOut",
															  "Eyes_LookUp",
															  "Eyes_Rabid",
															  "Eyes_Sad",
															  "Eyes_Shrink",
															  "Eyes_Sleep",
															  "Eyes_Spin",
															  "Eyes_Squint",
															  "Eyes_Trauma",
															  "Sweat_L",
															  "Sweat_R",
															  "Teardrop_L",
															  "Teardrop_R"
															};

	private List<string> animalNameList = new List<string> {
															  "Husky",
															  "Lamb",
															  "Mallard"
															};

	[Space(10)]
	[Tooltip("Assign: the game object where the animal are parented to")]
	public Transform animal_parent;
	public Dropdown dropdownAnimal;
	public Dropdown dropdownAnimation;
	public Dropdown dropdownFacialExp;

	public int value;
	public int count_animal;


	public int random_animal;
	public int obstacle_setting = 3;
	public Transform animal_tag_parent;
	public int[] select_animal = new int[3];
	public string[] select_animal_tag_check = new string[3];

	void Awake()
	{

		int count = animal_parent.childCount;
		count_animal = count;
		animal = new GameObject[count];
		List<string> animalList = new List<string>();

		for (int i = 0; i < count; i++)
		{
			animal[i] = animal_parent.GetChild(i).gameObject;
			string n = animal_parent.GetChild(i).name;
			animalList.Add(n);
			// animalList.Add(n.Substring(0, n.IndexOf("_")));

			if (i == 0)
			{
				animal_name = i;
				animal[i].SetActive(true);
			}
			else
			{
				animal[i].SetActive(false);
			}
			
		}
		dropdownAnimal.AddOptions(animalList);
		dropdownAnimation.AddOptions(animationList);
		dropdownFacialExp.AddOptions(facialExpList);

		//SetRandomAnimal();
		dropdownFacialExp.value = 1;
		ChangeExpression();

		value = dropdownAnimal.value;
		Bounds b = animal[0].transform.GetChild(0).GetChild(0).GetComponent<Renderer>().bounds;


		animal_obstacle = new GameObject[3];

		for (int i = 0; i < obstacle_setting; i++)
		{
			animal_obstacle[i] = animal_tag_parent.GetChild(i).gameObject;
			select_animal_tag_check[i] = animal_obstacle[i].tag;

			select_animal[i] = animalList.IndexOf(select_animal_tag_check[i]);
		}

		//for (int i =0; i < obstacle_setting; i++)
  //      {
		//	animal_obstacle[i] = animal_tag_parent.GetChild(i).gameObject;
		//	select_animal_tag_check[i] = animal_obstacle[i].tag;
		//	for (int j = 0; i < 9; j++)
		//	{
		//		if (animalList[j] == animal_obstacle[i].tag)
		//			select_animal[i] = j;
		//			break;
		//	}
		//}

		random_animal = select_animal[Random.Range(0, 3)];
		FindObjectOfType<CharacterChange>().HopeAnimal(random_animal);
	}

	void Update()
	{
        //SetRandomAnimal();
        if (Input.GetKeyDown("up")) { PrevAnimal(); }
        else if (Input.GetKeyDown("down")) { NextAnimal(); }
        else if (Input.GetKeyDown("right")) { NextAnimation(); }
        else if (Input.GetKeyDown("left")) { PrevAnimation(); }
    }


	public void NextAnimal()
	{

		if (dropdownAnimal.value >= dropdownAnimal.options.Count - 1)
			dropdownAnimal.value = 0;
		else
			dropdownAnimal.value++;

		ChangeAnimal();
	}

	public void PrevAnimal()
	{

		if (dropdownAnimal.value <= 0)
			dropdownAnimal.value = dropdownAnimal.options.Count - 1;
		else
			dropdownAnimal.value--;

		ChangeAnimal();
	}

	public void ChangeAnimal()
	{

		animal[animalIndex].SetActive(false);
		animal[dropdownAnimal.value].SetActive(true);
		animalIndex = dropdownAnimal.value;

		ChangeAnimation();
		ChangeExpression();
	}

	public void NextAnimation()
	{

		if (dropdownAnimation.value >= dropdownAnimation.options.Count - 1)
			dropdownAnimation.value = 0;
		else
			dropdownAnimation.value++;

		ChangeAnimation();
	}


	public void PrevAnimation()
	{

		if (dropdownAnimation.value <= 0)
			dropdownAnimation.value = dropdownAnimation.options.Count - 1;
		else
			dropdownAnimation.value--;

		ChangeAnimation();
	}

	public void ChangeAnimation()
	{

		GameObject a = animal[dropdownAnimal.value];

		int count = a.transform.childCount;
		for (int i = 0; i < count; i++)
		{
			if (a.GetComponent<Animator>() != null)
			{
				a.GetComponent<Animator>().Play(dropdownAnimation.options[dropdownAnimation.value].text);
			}
			else if (a.transform.GetChild(i).GetComponent<Animator>() != null)
			{
				a.transform.GetChild(i).GetComponent<Animator>().Play(dropdownAnimation.options[dropdownAnimation.value].text);
			}
		}
	}

	public void NextExpression()
	{

		if (dropdownFacialExp.value >= dropdownFacialExp.options.Count - 1)
			dropdownFacialExp.value = 0;
		else
			dropdownFacialExp.value++;

		ChangeExpression();
	}

	public void PrevExpression()
	{

		if (dropdownFacialExp.value <= 0)
			dropdownFacialExp.value = dropdownFacialExp.options.Count - 1;
		else
			dropdownFacialExp.value--;

		ChangeExpression();
	}

	public void ChangeExpression()
	{

		GameObject a = animal[dropdownAnimal.value];

		int count = a.transform.childCount;
		for (int i = 0; i < count; i++)
		{
			if (a.GetComponent<Animator>() != null)
			{
				a.GetComponent<Animator>().Play(dropdownFacialExp.options[dropdownFacialExp.value].text);
			}
			else if (a.transform.GetChild(i).GetComponent<Animator>() != null)
			{
				a.transform.GetChild(i).GetComponent<Animator>().Play(dropdownFacialExp.options[dropdownFacialExp.value].text);
			}
		}
	}

	public void HopeAnimal(int random_animal)
	{
		dropdownAnimal.value = random_animal;
		dropdowncheck = dropdownAnimal.value;
		ChangeAnimal();
	}

	//public void HopeAnimal_exp(int count_animal)
	//{
	//	GameObject a = animal[count_animal];

	//	int count = a.transform.childCount;
	//	for (int i = 0; i < count; i++)
	//	{
	//		if (a.GetComponent<Animator>() != null)
	//		{
	//			a.GetComponent<Animator>().Play(dropdownFacialExp.options[count_animal].text);
	//		}
	//		else if (a.transform.GetChild(i).GetComponent<Animator>() != null)
	//		{
	//			a.transform.GetChild(i).GetComponent<Animator>().Play(dropdownFacialExp.options[count_animal].text);
	//		}
	//	}
	//}



	public void GoToWebsite(string URL)
	{

		Application.OpenURL(URL);
	}
}