using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectorUI : MonoBehaviour
{
  public GameObject optionPrefab;
  public Transform prevCharacter;
  public Transform selectedCharacter;

  private void Start() {
    foreach(Character c in CharacterManager.instance.characters){
        GameObject option = Instantiate(optionPrefab,transform);
        Button button = option.GetComponent<Button>();

        button.onClick.AddListener(() =>{
            CharacterManager.instance.SetCharacter(c);
            if(selectedCharacter != null){
                prevCharacter = selectedCharacter;
            }
            selectedCharacter = option.transform;
        });

        Text text = option.GetComponentInChildren<Text>();
        text.text = c.name;

        Image image = option.GetComponentInChildren<Image>();
        image.sprite = c.icon;
    }
  }

  private void Update(){
    if(selectedCharacter != null){
        selectedCharacter.localScale = Vector3.Lerp(selectedCharacter.localScale,new Vector3(1f,1f,1f),Time.deltaTime * 10);
    }
  }
}