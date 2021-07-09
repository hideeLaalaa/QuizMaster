using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaster
{
	[Serializable]
	class Question
	{
		public String question { get; set; }
		public String optionA { get; set; }
		public String optionB { get; set; }
		public String optionC { get; set; }
		public String optionD { get; set; }
		public int answer { get; set; }
	}
}
