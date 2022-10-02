using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Button : UI_Popup
{
	enum Buttons
	{
		PointButton
	}

	enum Texts
	{
		PointText,
		ScoreText,
	}

	enum GameObjects
	{
		TestObject,
	}

	enum Images
	{
		ItemIcon,
	}

	private void Start()
	{
		Bind<Button>(typeof(Buttons));
		Bind<Text>(typeof(Texts));
		Bind<GameObject>(typeof(GameObjects));
		Bind<Image>(typeof(Images));

		// extension method
		GetButton((int)Buttons.PointButton).gameObject.ADDUIEvent(OnButtonClicked);

		// non-extension method
		GameObject go = GetImage((int)Images.ItemIcon).gameObject;
		ADDUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
	}

	int _score = 0;

	public void OnButtonClicked(PointerEventData data)
	{
		_score++;
		GetText((int)Texts.ScoreText).text = $"점수: {_score}";
	}
}
