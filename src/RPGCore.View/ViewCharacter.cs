﻿using RPGCore.Behaviour;
using RPGCore.Traits;
using System.Collections.Generic;

namespace RPGCore.View
{
	public class ViewCharacter : Entity
	{
		public TraitCollection Traits;

		public EventField<EntityRef> SelectedTarget = new EventField<EntityRef> ();

		public ViewCharacter ()
		{
			Id = new EntityRef ()
			{
				EntityId = LocalId.NewId ()
			};
		}

		public override IEnumerable<KeyValuePair<string, IEventField>> SyncedObjects
		{
			get
			{
				yield return new KeyValuePair<string, IEventField> ("selectedTarget", SelectedTarget);
			}
		}

		public override string ToString ()
		{
			return Id.ToString ();
		}
	}
}