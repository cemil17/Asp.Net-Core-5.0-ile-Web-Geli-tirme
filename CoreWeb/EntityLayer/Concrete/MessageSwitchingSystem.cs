﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class MessageSwitchingSystem
	{
		[Key]
		public int ID { get; set; }
		public string? Sender { get; set; }
		public string? SenderName { get; set; }
		public string? Receiver { get; set; }
		public string? ReceiverName { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public DateTime Date { get; set; }
		public bool Status { get; set; }
	}
}
