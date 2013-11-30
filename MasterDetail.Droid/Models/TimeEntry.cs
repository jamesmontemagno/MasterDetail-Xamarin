using System;

namespace MasterDetail.Droid
{
	public class TimeEntry
	{
		public TimeEntry()
		{
			Time = DateTime.Now;
			Title = "Title";
			IsSpecial = true;
		}

		public DateTime Time{ get; set; }
		public string Title { get; set; }
		public bool IsSpecial { get; set; }

		public override string ToString ()
		{
			return Time.ToString ();
		}
	}
}

