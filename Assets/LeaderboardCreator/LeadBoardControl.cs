using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class LeadBoardControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _entryTextObjects;
     [SerializeField] private String _usernameInputField;

     [SerializeField] private TMP_InputField _inputField;

     [SerializeField] Int score;
     [SerializeField] int Score=>score.Value;
    // Start is called before the first frame update
    void Start()
    {
        LoadEntries();
    }
 private void LoadEntries()
        {
            // Q: How do I reference my own leaderboard?
            // A: Leaderboards.<NameOfTheLeaderboard>
            Leaderboards.Myleaderboard.GetEntries(entries =>
            {
                foreach (var t in _entryTextObjects)
                    t.text = "";

                var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
                for (int i = 0; i < length; i++)
                    _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {entries[i].Score}";
            });
        }
        
        public void UploadEntry()
        { if(_usernameInputField.Value != ""){
            Leaderboards.Myleaderboard.UploadNewEntry(_usernameInputField.Value, Score, isSuccessful =>
            {
                if (isSuccessful)
                    LoadEntries();
            });
        }
        }
        public void UploadName(){
            print("cambio de nombre");
                _usernameInputField.Set(_inputField.text);
                UploadEntry();
        }
}
