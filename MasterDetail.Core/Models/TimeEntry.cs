using System;

namespace MasterDetail.Core.Models
{
	public class TimeEntry
	{
	  public static int index = 0;
		public TimeEntry()
		{
			Time = DateTime.Now;
			Title = Time.ToString();
			IsSpecial = true;
		  Id = index++;
		}

		public DateTime Time{ get; set; }
		public string Title { get; set; }
		public bool IsSpecial { get; set; }
    public int Id { get; set; }

		public override string ToString ()
		{
			return Time.ToString ();
		}
	}
}

