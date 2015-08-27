using System;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace todolist
{
	public class SqliteHelper
	{
		static object locker = new object();

		SQLiteConnection connection;

		string DatabasePath {
			get{
				var sqliteFilename = "TodoSQLite.db3";
				#if __IOS__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
				var path = Path.Combine(libraryPath, sqliteFilename);
				#else
				#if __ANDROID__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				var path = Path.Combine(documentsPath, sqliteFilename);
				#else
				// WinPhone
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);;
				#endif
				#endif
				return path;
			}
		}

		// create the database
		public SqliteHelper (){
			connection = new SQLiteConnection (DatabasePath);
			connection.CreateTable<UserTask> ();
		}

		// fetch record from database
		public IEnumerable<UserTask> FetchUserTask(){
			lock (locker) {
				return ( from records in connection.Table<UserTask>() select records).ToList();
			}
		}
			
		// update / insert record in database

		public int SaveRecord(UserTask task){
			lock (locker) {
				if (task.taskID != 0) {
					connection.Update (task);
					return task.taskID;
				} else {
					return connection.Insert (task);
				}
			}
		}

		// delete particular record from database
		public int deleteUserTask (int taskID){
			lock (locker) {
				return connection.Delete<UserTask>(taskID);
			}
		}

		// fetch particular record
		public UserTask fetchTaskByID (int id){
			lock (locker) {
				return connection.Table<UserTask>().FirstOrDefault(task => task.taskID == id);
			}
		}
	}
}

