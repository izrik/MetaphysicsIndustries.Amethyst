/*****************************************************************************
 *                                                                           *
 *  OutputTerminalAmethystPathParentChildrenCollection.cs                    *
 *  4 April 2008                                                             *
 *  Project: Amethyst                                                        *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2008 Metaphysics Industries, Inc.                            *
 *                                                                           *
 *  An unordered collection of AmethystPath objects.                         *
 *                                                                           *
 *****************************************************************************/

using System;
using System.Collections.Generic;
using MetaphysicsIndustries.Collections;

namespace MetaphysicsIndustries.Amethyst
{
	public class OutputTerminalAmethystPathParentChildrenCollection : ICollection<AmethystPath>, IDisposable
	{
		public OutputTerminalAmethystPathParentChildrenCollection(OutputTerminal parent)
		{
			_parent = parent;
		}

		public virtual void Dispose()
		{
			Clear();
			//this._set.Dispose();
			_set = null;
		}


		//ICollection<AmethystPath>
		public virtual void Add(AmethystPath item)
		{
			if (!Contains(item))
			{
				item.FromTerminal = null;
				_set.Add(item);
                item.FromTerminal = _parent;
			}
		}

		public virtual bool Contains(AmethystPath item)
		{
			return _set.Contains(item);
		}

		public virtual bool Remove(AmethystPath item)
		{
			if (Contains(item))
			{
				bool ret = _set.Remove(item);
				item.FromTerminal = null;
				return ret;
			}

			return false;
		}

		public virtual void Clear()
		{
			AmethystPath[] r = new AmethystPath[Count];

			CopyTo(r, 0);

			foreach (AmethystPath item in r)
			{
				Remove(item);
			}

			_set.Clear();
		}

		public virtual void CopyTo(AmethystPath[] array, int arrayIndex)
		{
			_set.CopyTo(array, arrayIndex);
		}

		public virtual IEnumerator<AmethystPath> GetEnumerator()
		{
			return _set.GetEnumerator();
		}


		//ICollection<AmethystPath>
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
				return (_set as ICollection<AmethystPath>).IsReadOnly;
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}


		private OutputTerminal _parent;
		private Set<AmethystPath> _set = new Set<AmethystPath>();
	}
}



