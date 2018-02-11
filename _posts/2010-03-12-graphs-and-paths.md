---
layout: post
title: Graphs and Paths
created: 1268352772
excerpt: !ruby/string:Sequel::SQL::Blob |-
  VGhpcyBpcyBteSBzdW1tYXJ5IG9mIHRoZSBHcmFwaHMgYW5kIFBhdGhzIGNo
  YXB0ZXIuICBBbGwgY29kZSBpcyB3cml0dGVuIGluIGMjIChjb252ZXJ0ZWQg
  ZnJvbSBqYXZhKS4NCg0KVHlwZXMgb2YgR3JhcGhzIChFIC0gRWRnZXMsIFYg
  LSBWZXJ0aWNlcykNClVud2VpZ2h0ZWQ6ICBPKHxFfCkgICAgQnJlYWR0aC1m
  aXJzdCBzZWFyY2gNCldlaWdodGVkLCBubyBuZWdhdGl2ZSBlZGdlczogIE8o
  fEV8IGxvZ3xWfCkgICAgRGlqa3N0cmEncyBhbGdvcml0aG0NCldlaWdodGVk
  LCBuZWdhdGl2ZSBlZGdlczogIE8ofEV8ICogfFZ8KSAgICBCZWxsbWFuLUZv
  cmQgYWxnb3JpdGhtDQpXZWlnaHRlZCwgYWN5Y2xpYzogIE8ofEV8KSAgICBV
  c2VzIHRvcG9sb2dpY2FsIHNvcnQNCg0KQSBjbGFzcyB0byByZXByZXNlbnQg
  dGhlIEVkZ2VzOg0KPHByZT4NCnVzaW5nIFN5c3RlbTsNCnVzaW5nIFN5c3Rl
  bS5Db2xsZWN0aW9uczsNCnVzaW5nIFN5c3RlbS5Db2xsZWN0aW9ucy5HZW5l
  cmljOw0KDQoJcHVibGljIGNsYXNzIEVkZ2UNCgl7DQoJCXB1YmxpYyBWZXJ0
  ZXggZGVzdDsgLy8gU2Vjb25kIHZlcnRleCBpbiBFZGdlDQ==
redirect_from:
  - /graphs_and_paths/
---
This is my summary of the Graphs and Paths chapter.  All code is written in c# (converted from java).

Types of Graphs (E - Edges, V - Vertices)
Unweighted:  O(|E|)    Breadth-first search
Weighted, no negative edges:  O(|E| log|V|)    Dijkstra's algorithm
Weighted, negative edges:  O(|E| * |V|)    Bellman-Ford algorithm
Weighted, acyclic:  O(|E|)    Uses topological sort

A class to represent the Edges:

```c#
using System;
using System.Collections;
using System.Collections.Generic;

public class Edge
{
	public Vertex dest; // Second vertex in Edge
	public double cost; // Edge cost
	
	public Edge(Vertex d, double c)
	{
		this.dest = d;
		this.cost = c;
	}
}
```

A class to represent the Vertices:

```c#
public class Vertex
{
	public string name; // Vertex name
	public List<Edge> adj; // Adjacent vertices
	public double dist; // cost
	public Vertex prev; // Previous vertex on shortest path
	public int pos; // Position on path?
	public int scratch; // Extra variable used in algorithm
	
	public Vertex(string nm)
	{
		this.name = nm;
		this.adj = new List<Edge>();
		reset();
	}
	
	public void reset()
	{
		this.dist = Graph.INFINITY;
		this.prev = null;
		this.pos = 0;
		this.scratch = 0 ;
	}
}
```

A class to represent paths (used with dijkstra's algorithm):

```c#
/// <summary>
/// Used with the dijkstra function
/// </summary>
public class Path : IComparable<Path>
{
	private Vertex vdest;
	private double vcost;
	
	public Path(Vertex d, double c)
	{
		vdest = d;
		vcost = c;
	}
	
	public Vertex Dest
	{
		get {return vdest;}
		set {vdest = value;}
	}
	
	public double Cost
	{
		get { return vcost; }
		set { vcost = value; }
	}
	
	public int CompareTo(Path rhs)
	{
		double otherCost = rhs.Cost;
		if (vcost < otherCost)
		{
			return -1;
		}
		else if (vcost > otherCost)
		{
			return 1;
		}
		
		return 0;
				
	}
}
```

The PriorityQueue class.  This is needed with the dijkstra algorithm.  I never wrote this, found on the Internet (not sure where).

```c#
[Serializable] 
public class PriorityQueue<T>
{
    List<T> list = new List<T>();
    Comparison<T> comparer; 

    public PriorityQueue():this(Comparer<T>.Default.Compare)
    {           
    }

    public PriorityQueue(IComparer<T> comparer)
    {
        this.comparer = comparer.Compare;
    }

    public PriorityQueue(Comparison<T> comparer)
    {
         this.comparer = comparer;
    }


    public int Count
    {
        get
        {
            return list.Count;
        }
    }

    public bool Empty
    {
        get { return list.Count == 0; }
    }


    public int Push(T element)
    {
        int p = list.Count;
        list.Add(element); 
        do
        {
            if (p == 0)
                break;
            int p2 = (p - 1) / 2;
            if (Compare(p,p2) < 0)
            {
                SwitchElements(p, p2);
                p = p2;
            }
            else
                break;
        } while (true);
        return p;
    }

    public void PushAll(IEnumerable<T> elements)
    {
        foreach (var item in elements)
            Push(item);
    }

    public T Pop()
    {
        if (Empty)
            throw new InvalidOperationException("Empty Priority Qoeue");

        int p = 0;
        T result = list[0];
        list[0] = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        do
        {
            int pn = p;
            int p1 = 2 * p + 1;
            int p2 = 2 * p + 2;
            if (list.Count > p1 && Compare(p,p1) > 0)
                p = p1;
            if (list.Count > p2 && Compare(p,p2) > 0)
                p = p2;

            if (p == pn)
                break;

            SwitchElements(p, pn);
        } while (true);

        return result; 
    }

    public T Peek()
    {
        if (Empty)
            throw new InvalidOperationException("Invalied Priority Qoeue");

        return list[0];
    }



    public void Clear()
    {
        list.Clear();
    }

    public void Update(T element)
    {
        Update(list.IndexOf(element));
    }

    public bool Contains(T element)
    {
        return list.Contains(element);
    }


    int Compare(int i, int j)
    {
        return comparer(list[i], list[j]);
    }

    void SwitchElements(int i, int j)
    {
        T h = list[i];
        list[i] = list[j];
        list[j] = h;
    }

    void Update(int i)
    {
        int p = i, pn;
        int p1, p2;
        do
        {
            if (p == 0)
                break;
            p2 = (p - 1) / 2;
            if (Compare(p, p2) < 0)
            {
                SwitchElements(p, p2);
                p = p2;
            }
            else
                break;
        } while (true);
        if (p < i)
            return;
        do
        {
            pn = p;
            p1 = 2 * p + 1;
            p2 = 2 * p + 2;
            if (list.Count > p1 && Compare(p, p1) > 0)
                p = p1;
            if (list.Count > p2 && Compare(p, p2) > 0)
                p = p2;

            if (p == pn)
                break;
            SwitchElements(p, pn);
        } while (true);
    }
}
```


The Graph and GraphException class:

```c#

/// <summary>
/// Graph class: evaluate shortest paths.
/// 
/// CONSTRUCTION: with no parameters.
/// 
/// ***********************PUBLIC OPERATIONS*************
/// void AddEdge(string v, string w, double cvw) - Add additional edge
/// void PrintPath(string w) - Print path after alg is run
/// void Unweighted(string s) - Single-source unweighted
/// void Dijkstra(string s) - Single-source weighted
/// void Negative(string s) - Single-source negative
/// void Acyclic(string s) - Single-source acyclic
/// *********************ERRORS**************************
/// Some error checking is performed to make sure that graph the graph is ok
/// and that graph statisfies properties needed by each algorithm.
/// Exceptions are thrown if errors are detected.
/// </summary>
public class Graph
{
	public static readonly double INFINITY = double.MaxValue;
	
	
	/// <summary>
	/// Add a new edge to the graph.
	/// </summary>
	/// <param name="sourceName">
	/// A <see cref="System.String"/>
	/// </param>
	/// <param name="destName">
	/// A <see cref="System.String"/>
	/// </param>
	/// <param name="cost">
	/// A <see cref="System.Double"/>
	/// </param>
	public void AddEdge(string sourceName, string destName, double cost)
	{
		Vertex v = GetVertex(sourceName);
		Vertex w = GetVertex(destName);
		v.adj.Add(new Edge(w, cost));
	}
	
	/// <summary>
	/// Driver routine to handle unreachables and print total cost.
	/// It calls recursive routine to print shortest path to destNode
	/// after a shortest path algorithm has run.
	/// </summary>
	/// <param name="destName">
	/// A <see cref="System.String"/>
	/// </param>
	public void PrintPath(string destName)
	{
		Vertex w = (Vertex)vertexMap[destName];
		if(w == null)
		{
			throw new KeyNotFoundException();
		}
		else if(w.dist == INFINITY)
		{
			System.Console.WriteLine(destName + " is unreachable");
		}
		else
		{
			System.Console.Write("(Cost is: " + w.dist + ")");
			PrintPath(w);
			System.Console.WriteLine("");
		}
	}
	
	/// <summary>
	/// Unweighted single-source, shortest-path problem.
	/// 
	/// Find the shortest path (measured by number of edges) from a designated
	/// vertex S to every vertex.
	/// </summary>
	/// <param name="startName">
	/// A <see cref="System.String"/>
	/// </param>
	public void Unweighted(string startName)
	{
		ClearAll();
		
		Vertex start = (Vertex)vertexMap[startName];
		if(start == null)
		{
			throw new NullReferenceException("Start vertex not found");
		}
		
		Queue<Vertex> q = new Queue<Vertex>();
		q.Enqueue(start); start.dist=0;
		
		while(q.Count>0)
		{
			Vertex v = q.Dequeue();
			foreach(Edge e in v.adj)
			{
				Vertex w = e.dest;
				
				if(w.dist == INFINITY)
				{
					w.dist = v.dist + 1;
					w.prev = v;
					q.Enqueue(w);
				}
			}
		}
	}
	
	/// <summary>
	/// Positive-weighted, single-source, shortest-path problem
	/// 
	/// Find the shortest path (measured by total cost) from a designated vertex S
	/// to every vertex.  all edge costs are nonnegative.
	/// </summary>
	/// <param name="startName">
	/// A <see cref="System.String"/>
	/// </param>
	/// <remarks>Will not work with negative edges</remarks>
	public void Dijkstra(string startName)
	{
		PriorityQueue<Path> pq = new PriorityQueue<Path>();
		
		Vertex start = (Vertex)vertexMap[startName];
		if(start == null)
		{
			throw new NullReferenceException("Start vertex not found");
		}
		
		ClearAll();
		pq.Push(new Path(start, 0)); // add
		start.dist = 0;
		
		int nodesSeen = 0;
		
		while(pq.Count > 0 && nodesSeen < vertexMap.Count)
		{
			Path vrec = pq.Pop(); //remove
			Vertex v = vrec.Dest;
			if(v.scratch != 0) // already processed v
			{
				continue;
			}
			v.scratch = 1;
			nodesSeen++;
			
			foreach(Edge e in v.adj)
			{
				Vertex w = e.dest;
				double cvw = e.cost;
				
				if(cvw < 0)
				{
					throw new GraphException("Graph has negative edges");
				}
				
				if(w.dist > (v.dist + cvw))
				{
					w.dist = v.dist + cvw;
					w.prev = v;
					pq.Push(new Path(w, w.dist));
				}
			}
		}
	}
	
	/// <summary>
	/// Most General Case.
	/// 
	/// Negative-Weighted, single-source, shortest-path problem.
	/// Find the shortest path (measured by total cost) from a designated vertex S to
	/// every vertex.  Edge costs may be negative.
	/// </summary>
	/// <param name="startName">
	/// A <see cref="System.String"/>
	/// </param>
	public void Negative(string startName)
	{
		ClearAll();
		
		Vertex start = (Vertex)vertexMap[startName];
		if(start == null)
		{
			throw new NullReferenceException("Start vertex not found");
		}
		
		Queue<Vertex> q = new Queue<Vertex>();
		q.Enqueue(start);
		start.dist = 0;
		start.scratch++;
		
		while (q.Count > 0)
		{
			Vertex v = q.Dequeue();
			if(v.scratch++ > (2*vertexMap.Count))
			{
				throw new GraphException("Negative cycle detected");
			}
			
			foreach(Edge e in v.adj)
			{
				Vertex w = e.dest;
				double cvw = e.cost;
				
				if(w.dist > (v.dist + cvw))
				{
					w.dist = v.dist + cvw;
					w.prev = v;
					
					//Enqueue only if not already on the queue
					if((w.scratch++ % 2) == 0)
					{
						q.Enqueue(w);
					}
					else
					{
						w.scratch--; // undo the enqueue increment	
					}
				}
			}
		}
	}
	
	/// <summary>
	/// Weighted single-source, shortest-path problem for acyclic graphs.
	/// Find the shortest path (measured by total cost) from a designated
	/// vertex S to every vertex in an acyclic graph.  Edge costs are unrestricted.
	/// </summary>
	/// <param name="startName">
	/// A <see cref="System.String"/>
	/// </param>
	public void Acyclic(string startName)
	{
		Vertex start = (Vertex)vertexMap[startName];
		if (start == null)
		{
			throw new NullReferenceException("Start vertex not found");
		}
		
		ClearAll();
		
		Queue<Vertex> q = new Queue<Vertex>();
		start.dist = 0;
		
		// Compute the indegrees
		List<Vertex> vertexSet = new List<Vertex>();
		foreach(Vertex v in q)
		{
			vertexSet.Add(v);
		}
		
		foreach(Vertex v in vertexSet)
		{
			foreach(Edge e in v.adj)
			{
				e.dest.scratch++;
			}
		}
		
		foreach(Vertex v in vertexSet)
		{
			if(v.scratch == 0)
			{
				q.Enqueue(v);
			}
		}
		
		int iterations;
		for(iterations = 0; q.Count > 0; iterations++)
		{
			Vertex v = q.Dequeue();
			
			foreach(Edge e in v.adj)
			{
				Vertex w = e.dest;
				double cvw = e.cost;
				
				if(--w.scratch == 0)
				{
					q.Enqueue(w);
				}
				
				if(v.dist == INFINITY)
				{
					continue;
				}
				
				if(w.dist > (v.dist + cvw))
				{
					w.dist = v.dist + cvw;
					w.prev = v;
				}
			}
		}
		
		if(iterations != vertexMap.Count)
		{
			throw new GraphException("Graph has a cycle!");
		}
	}
	
	/// <summary>
	/// If vertexName is not present, add it to vertexMap.
	/// In either case, return the Vertex
	/// </summary>
	/// <param name="vertexName">
	/// A <see cref="System.String"/>
	/// </param>
	/// <returns>
	/// A <see cref="Vertex"/>
	/// </returns>
	private Vertex GetVertex(string vertexName)
	{
		Vertex v = (Vertex)vertexMap[vertexName];
		if(v == null)
		{
			v = new Vertex(vertexName);
			vertexMap.Add(vertexName, v);
		}
		return v;
	}
	
	/// <summary>
	/// Recursive routine to print shortest path to dest after running
	/// shortest path algorithm.  The path is known to exist.
	/// </summary>
	/// <param name="dest">
	/// A <see cref="Vertex"/>
	/// </param>
	private void PrintPath(Vertex dest)
	{
		if(dest.prev != null)
		{
			PrintPath(dest.prev);
			System.Console.Write(" to ");
		}
		System.Console.Write(dest.name);
	}
	
	/// <summary>
	/// Initializes the vertex output info prior to running
	/// any shortest path algorithm.
	/// </summary>
	private void ClearAll()
	{
		foreach(Vertex v in vertexMap.Values)
		{
			v.reset();
		}
	}
	
	/// <summary>
	/// <string, Vertex>
	/// </summary>
	public System.Collections.Hashtable vertexMap = new System.Collections.Hashtable();
	
}

public class GraphException : Exception
{
	public GraphException(string name) : base(name)
	{}
}
```

The main command line program:

```c#
class MainClass
{
	/// <summary>
	/// A main routine that
	/// 1. Reads a file (supplied as a command-line parameter) containing edges.
	/// 2. Forms the graph.
	/// 3. Repeatedly prompts for two vertices and runs the shortest path algorithm.
	/// 
	/// The data file is a sequence of lines of the format source destination.
	/// </summary>
	public static void Main(string []args)
	{
		Graph g = new Graph();
		StreamReader fin = new StreamReader("input.txt");//StreamReader(args[0]);
		
		
		try
		{
			string line;
			while( (line = fin.ReadLine()) != null )
			{
				string[] words = line.Split(char.Parse(" "));
				try
				{
					if (words.Length != 3)
					{
						System.Console.WriteLine("Skipping bad line " + line);
						continue;
					}
					
					string source = words[0];
					string dest = words[1];
					int cost = int.Parse(words[2]);
					g.AddEdge(source, dest, cost);
				}
				catch(Exception exi)
				{
						System.Console.WriteLine("Skipping bad line " + line);
				}
			}
		}
		catch(IOException ex)
		{
			System.Console.WriteLine(ex.StackTrace);
		}
		
		System.Console.WriteLine("File read...");
		System.Console.WriteLine(g.vertexMap.Count);
		
		while(ProcessRequest(g)){}
	}
				
	/// <summary>
	/// Process a request; return if end of file.
	/// </summary>
	/// <param name="fin">
	/// A <see cref="StreamReader"/>
	/// </param>
	/// <param name="g">
	/// A <see cref="Graph"/>
	/// </param>
	/// <returns>
	/// A <see cref="System.Boolean"/>
	/// </returns>
	public static Boolean ProcessRequest(Graph g)
	{
		string startName = null;
		string destName = null;
		string alg = null;
		
		try
		{
			Console.Write("Enter start node: ");
			if( (startName = Console.ReadLine()) == null )
			{
				return false;
			}
			Console.Write("Enter destination node: ");
			if( (destName = Console.ReadLine()) == null )
			{
				return false;
			}
			Console.Write("Enter algorithm (u, d, n, a): ");
			if( (alg = Console.ReadLine()) == null )
			{
				return false;
			}
			
			if(alg == "u")
			{
				g.Unweighted(startName);
			}
			else if(alg == "d")
			{
				g.Dijkstra(startName);
			}
			else if(alg == "n")
			{
				g.Negative(startName);
			}
			else
			{
				g.Acyclic(startName);
			}
			
			g.PrintPath(destName);
		}
		catch(IOException ioex)
		{
			Console.WriteLine(ioex.Message);
		}
		catch(Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		
		return true;
	}
}
```


The input graph (input.txt):
<pre>
D C 10
A B 12
D B 23
A D 87
E D 43
B E 11
C A 19
</pre>
