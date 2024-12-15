using System;
using System.Collections.Generic;
namespace UsingConstraints
{
    public class Employee : IComparable<Employee>
    {
        private string name;
        public Employee(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return this.name;
        }
        // implement the interface
        public int CompareTo(Employee rhs)
        {
            //comparo 
            return this.name.CompareTo(rhs.name);
        }
        public bool Equals(Employee rhs)
        {
            return this.name == rhs.name;
        }
    }
    // node must implement IComparable of Node of T.
    // constrain Nodes to only take items that implement IComparable
    // by using the where keyword.

    //T è un tipo generico. Questo significa che Node può contenere un qualsiasi tipo di dato,
    //ma il tipo T dovrà essere specificato quando la classe viene istanziata.
    public class Node<T> : IComparable<Node<T>> where T : IComparable<T>
    {
        // member fields
        private T data;
        private Node<T> next = null;    //rif a nodo successivo
        private Node<T> prev = null;    //rif a nodo prima

        // constructor
        public Node(T data)
        {
            this.data = data;
        }
        // properties
        public T Data { get { return this.data; } }
        public Node<T> Next
        {
            get { return this.next; }
        }
        public int CompareTo(Node<T> rhs)
        {
            // this works because of the constraint
            return data.CompareTo(rhs.data);
        }
        public bool Equals(Node<T> rhs)
        {
            return this.data.Equals(rhs.data);
        }
        // methods
        public Node<T> Add(Node<T> newNode)
        {
            if (this.CompareTo(newNode) > 0) // goes before me
            {
                newNode.next = this; // new node points to me
                // if I have a previous, set it to point to
                // the new node as its next
                if (this.prev != null)
                {
                    this.prev.next = newNode;
                    newNode.prev = this.prev;
                }
                // set prev in current node to point to new node
                this.prev = newNode;
                // return the newNode in case it is the new head
                return newNode;
            }
            else // goes after me
            {
                // if I have a next, pass the new node along for
                // comparison
                if (this.next != null)
                {
                    this.next.Add(newNode);
                }
                // I don't have a next so set the new node
                // to be my next and set its prev to point to me.
                else
                {
                }
                this.next = newNode;
                newNode.prev = this;
                return this;
            }
        }
        public override string ToString()
        {
            string output = data.ToString();
            if (next != null)
            {
                output += ", " + next.ToString();
            }
            return output;
        }
    } // end class
    public class LinkedList<T> where T : IComparable<T>
    {
        // member fields
        private Node<T> headNode = null;
        // properties
        // indexer
        public T this[int index]
        {
            get
            {
                int ctr = 0;
                Node<T> node = headNode;
                while (node != null && ctr <= index)
                {
                    if (ctr == index)
                    {
                        return node.Data;
                    }
                    else
                    {
                        node = node.Next;
                    }
                    ++ctr;
                } // end while
                throw new ArgumentOutOfRangeException();
            } // end get
        } // end indexer
        // constructor
        public LinkedList()
        {
        }
        // methods
        public void Add(T data)
        {
            if (headNode == null)
            {
                headNode = new Node<T>(data);
            }
            else
            {
                headNode = headNode.Add(new Node<T>(data));
            }
        }
        public override string ToString()
        {
            if (this.headNode != null)
            {
                return this.headNode.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
    // Test engine
    class Test
    {
        // entry point
        static void Main(string[] args)
        {
            // make an instance, run the method
            Test t = new Test();
            t.Run();
        }
        public void Run()
        {
            LinkedList<int> myLinkedList = new LinkedList<int>();
            Random rand = new Random();
            Console.Write("Adding: ");
            for (int i = 0; i < 10; i++)
            {
                int nextInt = rand.Next(10);
                Console.Write("{0} ", nextInt);
                myLinkedList.Add(nextInt);
            }
            LinkedList<Employee> employees = new LinkedList<Employee>();
            employees.Add(new Employee("Douglas"));
            employees.Add(new Employee("Paul"));
            employees.Add(new Employee("George"));
            employees.Add(new Employee("Ringo"));
            Console.WriteLine("\nRetrieving collections...");
            Console.WriteLine("Integers: " + myLinkedList);
            Console.WriteLine("Employees: " + employees);
        }
    }
}

/*
 Il metodo CompareTo restituirà un valore intero che può essere:

0: Se le due stringhe (this.name e rhs.name) sono uguali.
Un valore negativo: Se la stringa this.name è less than (inferiore a) rhs.name (in base all'ordinamento lessicale).
Un valore positivo: Se la stringa this.name è greater than (maggiore a) rhs.name (in base all'ordinamento lessicale).


 public class Node<T> : IComparable<Node<T>> where T : IComparable<T>{}

 Node<T> deve implementare l'interfaccia IComparable<Node<T>>,
Questo implica che ogni oggetto di tipo Node<T> deve essere confrontabile con un altro oggetto dello stesso tipo (Node<T>).
Inoltre T deve implementare l'interfaccia IComparable<T>


Immagina che ogni nodo contenga due cose:

I dati di tipo T (per esempio un numero intero o un oggetto).
Un riferimento al nodo successivo nella lista, che è rappresentato dal campo next (che è un altro oggetto di tipo Node<T>).
*/