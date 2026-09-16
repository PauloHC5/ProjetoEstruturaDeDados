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
}
