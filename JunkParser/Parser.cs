using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace JunkParser
{


	public class ZipCodeParser
	{
		public static void Parse(string input)
		{
			// Regular expression to match 3-digit zip code followed by a word or a new line
			string pattern = @"(\d{3})(((?=[\n]))|((?=[^\n])(\s\w*)))";
			MatchCollection matches = Regex.Matches(input, pattern);
			var list = new SortedList<int,string>();

			//modifing the list so that zip codes without an associated state get XX as the state abreviation
			foreach (Match match in matches)
			{
				string zip, state;

				if (match.Value.Length > 4)
				{
					var line = match.Value.Split(' ');
					zip = line[0];
					state = line[1];

				}
				else
				{
					zip = $"{match.ToString().TrimEnd()}";
					state = "XX";
				}
			
				list.Add(int.Parse(zip), state);
			}

			//flattening the array on states to only give the lowest value of zip code
			var condencedList = new SortedList<int,string>();
			var lastZipState = list.First();
			condencedList.Add(lastZipState.Key, lastZipState.Value);
			foreach (KeyValuePair<int, string> zipState in list) {
				if (String.Equals(zipState.Value, lastZipState.Value)) continue;
				condencedList.Add(zipState.Key, zipState.Value);
				lastZipState = zipState;
			}

			//printing out the list to copy and paste into the java program
            foreach (var item in condencedList)
            {
				Console.WriteLine($"zipCodeMap.put({item.Key}, \"{item.Value}\");");
            }
        }

		public static void Main(string[] args)
		{
			// Replace "path/to/rawStates.txt" with the actual file path
			string filePath = "C:\\Users\\elimt\\source\\repos\\JunkParser\\JunkParser\\rawStates.txt";

			string data;
			try
			{
				data = File.ReadAllText(filePath);
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine($"Error: File not found - {filePath}, {e}");
				return;
			}

			Parse(data);
			Console.WriteLine("Done");
		}
	}
}
