using System;
using System.Collections.Generic;

namespace Assessment_Test
{
	public class Shapeshifter
	{
		private Entity _entity;
		private Boolean _melded;
		private  List<Entity> _entities=new List<Entity>();


		public Shapeshifter ()
		{
			_melded = false;
		}

		public Boolean Melded
		{
			get{
				return ( _entities.Count!=0);
			}
		}

		public void Meld(Entity entity)
		{
			_entities.Add (entity);
			_entity = entity;
		}


		public void Shift(bool flag)
		{
			if (flag)
				_melded = true;
			else
				_melded = false;

		}

		public void Call()
		{
		if (_entity!=null && _melded== true) {
			_entity.Call();
			} else {
			Console.WriteLine ("Hi There");
			}
		}

		public void MeldedEntity()
		{
			foreach (Entity entity in _entities) {
				Console.WriteLine (entity.Name);
			}
		}
	}
}


