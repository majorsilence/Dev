---
layout: post
title: Singly/Sorted Linked Lists
created: 1257702281
excerpt: !ruby/string:Sequel::SQL::Blob |-
  SSBhbSByZXJlYWRpbmcgc29tZSBjaGFwdGVycyBpbiAiRGF0YSBTdHJ1Y3R1
  cmVzICZhbXA7IFByb2JsZW0gU29sdmluZyBVc2luZyBKYXZhIi4gIEkganVz
  dCBmaW5pc2hlZCByZWFkaW5nIGNoYXB0ZXIgMTcgb24gbGlua2VkIGxpc3Rz
  LiAgSGVyZSBpcyB0aGUgc2luZ2x5IGxpbmtlZCBsaXN0IGFuZCBzb3J0ZWQg
  bGlua2VkIGxpc3QgZnJvbSB0aGlzIGNoYXB0ZXIgZG9uZSBpbiBjIy4gDQoN
  CkxpbmtlZExpc3QgLSB0aGUgbGlzdCBpdHNlbGYNClNvcnRlZExpbmtlZExp
  c3QgLSB0aGUgc29ydGVkIGxpbmtlZCBsaXN0DQpMaXN0Tm9kZSAtIHJlcHJl
  c2VudHMgdGhlIG5vZGUNCkxpbmtlZExpc3RJdGVyYXRvciAtIHJlcHJlc2Vu
  dHMgdGhlIHBvc2l0aW9uDQoNCg0KPHByZT4NCnVzaW5nIFN5c3RlbTsNCnVz
  aW5nIFN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljOw0KDQpuYW1lc3BhY2Ug
  TGlua2VkTGlzdHMNCnsNCglwdWJsaWMgY2xhc3MgTGlzdE5vZGU8VD4NCgl7
  DQoJCXByaXZhdGUgVCBlbGVtOw0KCQlwcml2YXRlIExpc3ROb2RlPFQ+IG5l
  eHROb2RlOw0KCQkNCgkJcHVibGljIFQgRWxlbWVudA0KCQl7DQ==
redirect_from:
  - /singly_linked_lists/
---
I am rereading some chapters in "Data Structures &amp; Problem Solving Using Java".  I just finished reading chapter 17 on linked lists.  Here is the singly linked list and sorted linked list from this chapter done in c#. 

LinkedList - the list itself
SortedLinkedList - the sorted linked list
ListNode - represents the node
LinkedListIterator - represents the position


```c#
using System;
using System.Collections.Generic;

namespace LinkedLists
{
	public class ListNode<T>
	{
		private T elem;
		private ListNode<T> nextNode;
		
		public T Element
		{
			get {return elem;}
			set {elem = value;}
		}
		
		public ListNode<T> Next
		{
			get {return nextNode;}
			set {nextNode = value;}
		}
		
		public ListNode(T theElement) : 
			this(theElement, null)
		{
		}
		
		public ListNode(T theElement, ListNode<T> n)
		{
			elem = theElement; nextNode = n;
		}
		
		
	}
	
	public class LinkedListIterator<T>
	{
		private ListNode <T> cur;
		
		public LinkedListIterator(ListNode<T> theNode)
		{
			cur = theNode;
		}
		
		public ListNode<T> Current
		{
			get{return cur;}
			set{cur = value;}
		}
		
		public bool IsValid()
		{
			return cur != null;
		}
		
		public T Retrieve()
		{
			if ( IsValid() )
			{ 
				return cur.Element;
			}
			else
			{
				return default(T); //null;
			}
		}
		
		public void Advance()
		{
			if (IsValid())
			{
				cur	= cur.Next;
			}
		}
	}
	
	public class LinkedList<T>
	{
		private ListNode<T> header;
		
		/// <summary>
		/// Construct the List.
		/// </summary>
		public LinkedList()
		{
			this.header = new ListNode<T> (default(T)); //(null);
		}
		
		public bool IsEmpty()
		{
			return this.header.Next == null;
		}
		
		public void MakeEmpty()
		{
			this.header.Next = null;
		}
		
		/// <summary>
		/// Return an iterator representing the header node.
		/// </summary>
		/// <returns>
		/// A <see cref="LinkedListIterator"/>
		/// </returns>
		public LinkedListIterator<T> Zeroth()
		{
			return new LinkedListIterator<T> (this.header);
		}	
		
		/// <summary>
		/// Return an iterator representing the first node in the list.
		/// </summary>
		/// <returns>
		/// A <see cref="LinkedListIterator"/>
		/// </returns>
		public LinkedListIterator<T> First()
		{
			return new LinkedListIterator<T> (this.header.Next);
		}
		
		public LinkedListIterator<T> Find(T x)
		{
			ListNode<T> itr = this.header;
			
			while(itr != null && !itr.Element.Equals(x))
			{
				itr = itr.Next;
			}
			
			return new LinkedListIterator<T>(itr);
		}
		
		/// <summary>
		/// Remove the first occurrence of an item.  The code is not foolproof.
		/// There may be two iterators, and one can left dangling if the other
		/// removes a node.
		/// </summary>
		/// <param name="x">
		/// A <see cref="T"/>
		/// </param>
		public void Remove(T x)
		{
			LinkedListIterator<T> p = FindPrevious(x);
			if(p.Current.Next != null)
			{
				p.Current.Next = p.Current.Next.Next;
			}
		}
		
		/// <summary>
		/// Return iterator prior to the first node containing an item.
		/// </summary>
		/// <param name="x">
		/// A <see cref="T"/>
		/// </param>
		/// <returns>
		/// A <see cref="LinkedListIterator"/>
		/// </returns>
		public LinkedListIterator<T> FindPrevious(T x)
		{
			ListNode<T> itr = this.header;
			
			while (itr.Next != null && !itr.Next.Element.Equals(x))
			{
				itr = itr.Next;
			}
			return new LinkedListIterator<T>(itr);
		}
		
		public void Insert(T x, LinkedListIterator<T> p)
		{
			if(p != null && p.Current != null)
			{
				p.Current.Next = new ListNode<T>(x, p.Current.Next);
			}
		}
		
		public static void PrintList(LinkedList<T> theList)
		{
			if (theList.IsEmpty())
			{
				System.Console.WriteLine("Empty List");
			}
			else
			{
				LinkedListIterator<T> itr = theList.First();
				for( ; itr.IsValid(); itr.Advance())
				{
					System.Console.WriteLine(itr.Retrieve());
				}
			}
			
			System.Console.WriteLine("");
		}
	}
	
	public class SortedLinkedList<T> : LinkedList<T>
	{
		public new void Insert(T x, LinkedListIterator<T> p)
		{
			Insert(x);
		}
		
		public void Insert(T x)
		{
			LinkedListIterator<T> prev = Zeroth();
			LinkedListIterator<T> curr = First();
			
			//while(curr.IsValid() && ( x.CompareTo(curr.Retrieve() ) > 0) )
			while(curr.IsValid() && (!EqualityComparer<T>.Default.Equals(x, curr.Retrieve())) ) 
			{
				prev.Advance();
				curr.Advance();
			}
			
			base.Insert(x, prev);
		}
	}


        class MainClass
	{
		public static void Main(string[] args)
		{
			
			
	        LinkedList<int> theList = new LinkedList<int>( );
	        LinkedListIterator<int> theItr;
	        int i;
	
	        theItr = theList.Zeroth( );
	        theList.PrintList(theList);
	
	        for( i = 0; i < 10; i++ )
	        {
	            theList.Insert( i , theItr );
	            theList.PrintList( theList );
	            theItr.Advance( );
	        }
	        
	
	        for( i = 0; i < 10; i += 2 )
			{
	            theList.Remove( i );
			}
	
	        for( i = 0; i < 10; i++ )
			{
	            if( ( i % 2 == 0 ) == ( theList.Find( i ).IsValid( ) ) )
				{
	                Console.WriteLine( "Find fails!" );
				}
			}
	
	        Console.WriteLine( "Finished deletions" );
	        theList.PrintList( theList );
		}
	}

}

```
