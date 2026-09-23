using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class List<ListType>
{
    private class Node<NodeType>
    {
        public NodeType value;
        public Node<NodeType> next;

        public Node(NodeType value)
        {
            this.value = value;
            this.next = null;
        }
    }

    private Node<ListType> first = null;
    private Node<ListType> last = null;
    private int count = 0;
    public int Count => count;

    public void Insert(ListType value)
    {
        Node<ListType> node = new Node<ListType>(value);

        ++count;

        if (first == null)
        {
            first = node;
            last = first;
        }
        else
        {
            last.next = node;
            last = node;
        }
    }

    public void InsertBack(ListType value)
    {
        Node<ListType> node = new Node<ListType>(value);
        ++count;

        if (first == null)
        {
            first = node;
            last = first;
        }
        else
        {
            node.next = first;
            first = node;
        }
    }

    public bool Remove(ListType value)
    {

        if (first.value.Equals(value))
        {
            Node<ListType> node = first.next;            
            first.next = null;
            first = node;
            --count;
            return true;
        }


        Node<ListType> prior = first;
        while (prior.next != null)
        {
            if(prior.next.value.Equals(value))
            {
                Node<ListType> nodeToRemove = prior.next;
                prior.next = nodeToRemove.next;
                nodeToRemove.next = null;
                --count;
                return true;
            }

            prior = prior.next;            
        }

        return false;
    }

    public ListType RemoveAt(int index)
    {
        Debug.Assert(index < count);
        Debug.Assert(count > 0);

        if (index == 0)
        {
            Node<ListType> nodeResult = first;
            first = nodeResult.next;
            ListType result = nodeResult.value;
            nodeResult.next = null;
            --count;
            return result;
        }
        else
        {
            Node<ListType> prior = FindByIndex(index - 1);
            Node<ListType> nodeToRemove = prior.next;
            prior.next = nodeToRemove.next;
            ListType result = nodeToRemove.value;
            if(nodeToRemove == last)
            {
                last = prior;
            }
            nodeToRemove.next = null;
            return result;

        }        
    }

    public ListType this[int index]
    {
        get
        {
            return FindByIndex(index).value;            
        }
        set
        {
            FindByIndex(index).value = value;
        }
    }

    public static List<ListType> operator +(List<ListType> a, List<ListType> b)
    {
        List<ListType> result = new List<ListType>();
        Node<ListType> node = a.first;
        while(node != null)
        {
            result.Insert(node.value);
            node = node.next;
        }

        node = b.first;
        while (node != null)
        {
            result.Insert(node.value);
            node = node.next;
        }

        return result;
    }

    private Node<ListType> FindByIndex(int index)
    {
        Debug.Assert(index < count);
        Debug.Assert(count > 0);

        Node<ListType> result = first;
        for (int i = 0; i < index; ++i)
        {
            result = result.next;
        }

        return result;
    }
}
