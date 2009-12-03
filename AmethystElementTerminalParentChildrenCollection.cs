/*****************************************************************************
 *                                                                           *
 *  AmethystElementTerminalParentChildrenCollection.cs                       *
 *  3 April 2008                                                             *
 *  Project: Amethyst                                                        *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2008 Metaphysics Industries, Inc.                            *
 *                                                                           *
 *  An unordered collection of Terminal objects.                             *
 *                                                                           *
 *****************************************************************************/

using System;
using System.Collections.Generic;
using MetaphysicsIndustries.Collections;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class AmethystElementTerminalParentChildrenCollection : ICollection<Terminal>, IDisposable
	{
		public AmethystElementTerminalParentChildrenCollection(AmethystElement parent)
		{
			_parent = parent;
		}

		public virtual void Dispose()
		{
			Clear();
		}


		//ICollection<Terminal>
		public virtual void Add(Terminal item)
		{
			if (!Contains(item))
			{
				item.ParentAmethystElement = null;
				_set.Add(item);

                _parent.TerminalsByConnection[item.ConnectionBase] = item;

				item.ParentAmethystElement = _parent;
			}
		}

		public virtual bool Contains(Terminal item)
		{
			return _set.Contains(item);
		}

		public virtual bool Remove(Terminal item)
		{
			if (Contains(item))
			{
				bool ret = _set.Remove(item);
				item.ParentAmethystElement = null;
				return ret;
			}

			return false;
		}

		public virtual void Clear()
		{
			Terminal[] r = new Terminal[Count];

			CopyTo(r, 0);

			foreach (Terminal item in r)
			{
				Remove(item);
			}

			_set.Clear();
		}

		public virtual void CopyTo(Terminal[] array, int arrayIndex)
		{
			_set.CopyTo(array, arrayIndex);
		}

		public virtual IEnumerator<Terminal> GetEnumerator()
		{
			return _set.GetEnumerator();
		}


		//ICollection<Terminal>
		public virtual int Count
		{
			get
			{
				return _set.Count;
			}
		}

		public virtual bool IsReadOnly
		{
			get
			{
				return (_set as ICollection<Terminal>).IsReadOnly;
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}


		private AmethystElement _parent;
		private Set<Terminal> _set = new Set<Terminal>();
	}
}



