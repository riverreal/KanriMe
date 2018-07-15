using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour {
	[SerializeField] TextMeshProUGUI m_kanriMeText;
	[SerializeField] RectTransform m_topBar;
	[SerializeField] RectTransform m_timeBar;

	void Start () {
		InitialAnimation();
	}

	void InitialAnimation()
	{
		Sequence seq = DOTween.Sequence();
		seq.Append(m_kanriMeText.DOFade(1.0f, 1.0f));
		var rect = m_kanriMeText.rectTransform.rect;
		var movePos = new Vector2(Common.Parameters.ReferenceLeft + rect.width/2, Common.Parameters.ReferenceTop - rect.height/2);
		seq.Append(m_kanriMeText.rectTransform.DOAnchorPos(movePos, 1.0f));
		seq.Join(m_topBar.DOAnchorPosY(Common.Parameters.ReferenceTop - m_topBar.rect.height/2, 1.0f));
		seq.Join(m_kanriMeText.rectTransform.DOScale(new Vector2(1.0f, 1.0f), 1.0f));
		seq.Append(m_timeBar.DOAnchorPosX(Common.Parameters.ReferenceLeft + m_timeBar.rect.width/2, 0.8f).OnComplete(()=>{
			foreach(Transform line in m_timeBar)
			{
				line.GetComponent<Image>().enabled = true;
			}
		}));
	}
}
