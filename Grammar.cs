using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grammar 
{

	Dictionary<string, string[]> evaluationsByTags;

	public Grammar()
	{
		evaluationsByTags = new Dictionary<string, string[]>();
	}	

	public void AddTag(string tagName, string[] textEvaluations)
	{
		evaluationsByTags[tagName] = textEvaluations;
	}

	public string Evaluate(string taggedText)
	{
		List<string> tags = ParseTagsFrom(taggedText);

		if (tags.Count == 0) // No tags means a plain and normal text
		{
			return taggedText;
		}

		List<string> tagsEvaluated = Evaluate(tags);

		string textEvaluated = taggedText;

		for (int s = 0; s < tags.Count; s++)
		{
			textEvaluated = textEvaluated.Replace("#" + tags[s] + "#", tagsEvaluated[s]);
		}

		return textEvaluated;
	}

	private List<string> Evaluate(List<string> tagList)
	{
		List<string> evaluatedTagList = new List<string>();

		foreach (string tag in tagList) 
		{
			if (evaluationsByTags.ContainsKey(tag))
			{
				string taggedText = evaluationsByTags[tag].GetRandom<string>();
				evaluatedTagList.Add(Evaluate(taggedText));
			}
		}

		return evaluatedTagList;
	}

	/// <summary>
	/// Tags are between ##
	/// #tag1##tag2#
	/// </summary>
	private List<string> ParseTagsFrom(string taggedText)
	{
		List<string> tags = new List<string>();

		string tag = "";
		bool inTag = false;

		for (int i = 0; i < taggedText.Length; i++)
		{
			if (taggedText[i] == '#')
			{
				if (inTag)
				{
					tags.Add(tag);
				}

				tag = "";
				inTag = !inTag;
			}
			else if (inTag)
			{
				tag += taggedText[i];
			}

		}

		return tags;
	}
}
