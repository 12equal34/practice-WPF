using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWPFbook
{
	public class Message
	{
		public string Sender { get; set; } = "";
		public string Content { get; set; } = "";
	}

	public class Talk : ObservableCollection<Message>
	{
		public Talk()
		{
			this.Add(new Message() { Sender = "Adventure Works", Content = "Hi, what can we do for you?" });
			this.Add(new Message() { Sender = "클라이언트", Content = "ㅁㄴㅇㄴㅁㅇ" });
			this.Add(new Message() { Sender = "Adventure Works", Content = "Hi, what can we do for you?" });
			this.Add(new Message() { Sender = "ㅋㅌㅊㅋ ㅋㅌㅊ", Content = "ㅂㅈㄷㄷㅂㅈㄷor you?" });
			this.Add(new Message() { Sender = "Adventure Works", Content = "Hi, what can we do for you?" });
		}
	}
}
