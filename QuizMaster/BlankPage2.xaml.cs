using System;
using System.Collections.Generic;
using System.IO;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Windows.UI.Popups;
using Windows.Storage.Streams;
using Windows.Storage;
using System.Threading.Tasks;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QuizMaster
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	/// 
	public class Quest
	{
		
		public String Quests { get; set; }
		public String OptionA { get; set; }
		public String OptionB { get; set; }
		public String OptionC { get; set; }
		public String OptionD { get; set; }
		public int Answer { get; set; }
	}

	public sealed partial class BlankPage2 : Page
	{

		List<Quest> allQuestions;
		public int count = 1;
		/// <summary>
		/// 
		/// </summary>
		public BlankPage2()
		{
			this.InitializeComponent();

			//writeJson();
			//fileSample();
			readJsonAsync();
			//nextQuestion();

//			createJson();
//		fileSample();
// Create sample file; replace if exists.

			/*	var questions = getQuestions();
				if(questions != null)
				{
					for(int i = 0; i < questions.Count; i++)
					{
						System.Diagnostics.Debug.Print(questions[i].question);
						question.Text = questions[i].Quests;
					}
				}
				else
				{
					question.Text = "null";
				}
				*/
		}

		public async void readJsonAsync()
		{
			await setQuestionsAsync();
			question.Text = allQuestions.ToArray()[0].Quests;
			optionA.Content = allQuestions.ToArray()[0].OptionA;
			optionB.Content = allQuestions.ToArray()[0].OptionB;
			optionC.Content = allQuestions.ToArray()[0].OptionC;
			optionD.Content = allQuestions.ToArray()[0].OptionD;
			
		}

		public void nextQuestion()
		{
			question.Text = allQuestions.ToArray()[0].Quests;
			optionA.Content = allQuestions.ToArray()[0].OptionA;
			optionB.Content = allQuestions.ToArray()[0].OptionB;
			optionC.Content = allQuestions.ToArray()[0].OptionC;
			optionD.Content = allQuestions.ToArray()[0].OptionD;
			count++;
		}

		public async void writeJson()
		{
			Quest q = new Quest
			{
				Quests = "23+25",
				OptionA = "43",
				OptionB = "-2",
				OptionC = "48",
				OptionD = "2325",
				Answer = 3
			};
			Quest q2 = new Quest
			{
				Quests = "Current Nigria President?",
				OptionA = "Bubu",
				OptionB = "Buhari",
				OptionC = "Adamu Garba",
				OptionD = "Tinubu",
				Answer = 2
			};
			Quest q3 = new Quest
			{
				Quests = "55-42",
				OptionA = "21",
				OptionB = "18",
				OptionC = "1",
				OptionD = "13",
				Answer = 4
			};
			Quest q4 = new Quest
			{
				Quests = "How many camera does the iphone XR have?",
				OptionA = "2",
				OptionB = "3",
				OptionC = "1",
				OptionD = "4",
				Answer = 3
			};
			Quest q5 = new Quest
			{
				Quests = "Full meaning of HP",
				OptionA = "Hewlett packard",
				OptionB = "Helwelt Package",
				OptionC = "Husman Packinson",
				OptionD = "Hot and Pretty",
				Answer = 1
			};
			List<Quest> test = new List<Quest>();
			test.Add(q);
			test.Add(q2);
			test.Add(q3);
			test.Add(q4);
			test.Add(q5);

			Windows.Storage.StorageFolder storageFolder = Windows.Storage.KnownFolders.DocumentsLibrary;

			 var file = await storageFolder.CreateFileAsync("sampleUWP.json",
			Windows.Storage.CreationCollisionOption.OpenIfExists);

			//var file = await storageFolder.GetFileAsync("sampleUWP.json");

			var fileContent = JsonConvert.SerializeObject(test);

			await Windows.Storage.FileIO.WriteTextAsync(file, fileContent);

		}

		public async void fileSample()
		{
			Windows.Storage.StorageFolder storageFolder =
			Windows.Storage.KnownFolders.DocumentsLibrary;
			
			Windows.Storage.StorageFile sampleFile =
				await storageFolder.GetFileAsync("sampleUWP.json");

//			await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow");
			string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
			allQuestions = JsonConvert.DeserializeObject<List<Quest>>
					(text);
			MessageDialog d = new MessageDialog(allQuestions.ToArray()[1].Quests);
			await d.ShowAsync();
		}

		async 
		Task
setQuestionsAsync()
		{
			Windows.Storage.StorageFolder storageFolder = Windows.Storage.KnownFolders.DocumentsLibrary;

			/*if (!File.Exists(Path.Combine(storageFolder.Path, "sampleUWP.json")))
			{
				return default(List<Quest>);
			}*/

			//	var file = await storageFolder.GetFileAsync("sampleUWP.json");
			//var fileContent = await FileIO.ReadTextAsync(file);

			//var questions = JsonConvert.DeserializeObject< List<Quest> >(fileContent);
			//return questions;

			//String fileName = @"E:\Documents\question.json";
			//String fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "tester.txt";
			
			Windows.Storage.StorageFile sampleFile =
				await storageFolder.GetFileAsync("sampleUWP.json") ;

			//			await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow");
			string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
			
			allQuestions = JsonConvert.DeserializeObject<List<Quest>>
					(text); 
		}

		public void createJson()
		{
			//String fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "tester.txt";
			//String fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "testers.txt");
			String fileName = @"C:\Users\Public\Documents\tester.txt";
			Quest q = new Quest
			{
				Quests = "23+25",
				OptionA = "43",
				OptionB = "-2",
				OptionC = "48",
				OptionD = "2325",
				Answer = 3
			};
			Quest q2 = new Quest
			{
				Quests = "Current Nigria President?",
				OptionA = "Bubu",
				OptionB = "Buhari",
				OptionC = "Adamu Garba",
				OptionD = "Tinubu",
				Answer = 2
			};
			Quest q3 = new Quest
			{
				Quests = "55-42",
				OptionA = "21",
				OptionB = "18",
				OptionC = "1",
				OptionD = "13",
				Answer = 4
			};
			Quest q4 = new Quest
			{
				Quests = "How many camera does the iphone XR have?",
				OptionA = "2",
				OptionB = "3",
				OptionC = "1",
				OptionD = "4",
				Answer = 3
			};
			Quest q5 = new Quest
			{
				Quests = "Full meaning of HP",
				OptionA = "Hewlett packard",
				OptionB = "Helwelt Package",
				OptionC = "Husman Packinson",
				OptionD = "Hot and Pretty",
				Answer = 1
			};
			List<Quest> test = new List<Quest>();
			test.Add(q);
			test.Add(q2);
			test.Add(q3);
			test.Add(q4);
			test.Add(q5);
			//JsonConvert.SerializeObject(test);
/*			try
			{
				File.CreateText(fileName);
				File.WriteAllText(fileName, "kkk");
				using (StreamWriter tw = new StreamWriter(fileName, true))
				{
					tw.WriteLine(JsonConvert.SerializeObject(test));
					tw.Close();
				}
					//File.WriteAllText(fileName, JsonConvert.SerializeObject(test));

			}catch(Exception e)
			{
				

			}
	*/
	}

		private void NextButton_Click(object sender, RoutedEventArgs e)
		{
			nextQuestion();
			Title.Text = "Question " + count;
		}
	}
}
