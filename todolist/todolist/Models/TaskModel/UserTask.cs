using System;
using System.Collections.Generic;
using SQLite;

namespace todolist
{
	public class UserTask
	{
		public UserTask ()
		{
			
		}

		[PrimaryKey, AutoIncrement]
		public int taskID { get; set;}

		public string taskName { get; set;}

		public DateTime taskDate { get; set;}

		public DateTime taskTime { get; set;}
		 
		public Boolean taskStatus { get; set;}


	}
}

