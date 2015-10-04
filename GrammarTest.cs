using UnityEngine;
using System.Collections;

public class GrammarTest : MonoBehaviour {

	private Grammar grammar;

	// Use this for initialization
	void Start () {
		grammar = new Grammar();

		grammar.AddTag("story", new string[] {
			"#story_beginning# #story_problem# #story_climax# #story_ending#"
			});
		grammar.AddTag("story_beginning", new string[] {
			"Once upon a time there was a valiant #animal#"
			});
		grammar.AddTag("story_problem", new string[] {
			"that never #difficulty_verb#.",
			"that one day heard some strange words: #strange_calling#"
			});
		grammar.AddTag("story_climax", new string[] {
			"Suddenly, he decided to #resolution_verb#."
			});
		grammar.AddTag("story_ending", new string[] {
			"Finally he could #result_verb# without worries."
			});
		grammar.AddTag("difficulty_verb", new string[] {"slept", "danced", "talked"});
		grammar.AddTag("resolution_verb", new string[] {"run", "sing", "give up"});
		grammar.AddTag("result_verb", new string[] {"sleep", "dance", "talk freely"});

		grammar.AddTag("strange_calling", new string[] {"Hello #name#!", "Hello my #writer_object#!"});
		grammar.AddTag("animal", new string[] {"dolphin", "dog", "cat", "lamb", "lion"});
		grammar.AddTag("name", new string[] {"Mr. Gil", "Madame", "Masked Man"});
		grammar.AddTag("writer_object", new string[] {"text", "book", "beloved code"});



		InvokeRepeating("TestEvaluation", 1f, 2f);
	}
	
	// Update is called once per frame
	void TestEvaluation () 
	{
		Debug.Log(grammar.Evaluate("#story#"));
	}
}
