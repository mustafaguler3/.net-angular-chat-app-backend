using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Entities
{
	public class Group
	{
		[Key]
		public string Name { get; set; }

		public Group()
		{

		}

		public Group(string name)
		{
			Name = name;
		}

		public ICollection<Connection> Connections { get; set; } = new List<Connection>();
	}
}

