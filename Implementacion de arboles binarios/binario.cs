public class BinarySearchTree
{
    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    public void Insert(int value)
    {
        root = InsertRecursive(root, value);
    }

    private Node InsertRecursive(Node current, int value)
    {
        if (current == null)
        {
            return new Node(value);
        }

        if (value < current.Value)
        {
            current.Left = InsertRecursive(current.Left, value);
        }
        else if (value > current.Value)
        {
            current.Right = InsertRecursive(current.Right, value);
        }

        return current;
    }

    public bool Search(int value)
    {
        return SearchRecursive(root, value);
    }

    private bool SearchRecursive(Node current, int value)
    {
        if (current == null)
        {
            return false;
        }

        if (value == current.Value)
        {
            return true;
        }

        return value < current.Value
            ? SearchRecursive(current.Left, value)
            : SearchRecursive(current.Right, value);
    }

    public void Delete(int value)
    {
        root = DeleteRecursive(root, value);
    }

    private Node DeleteRecursive(Node current, int value)
    {
        if (current == null)
        {
            return null;
        }

        if (value < current.Value)
        {
            current.Left = DeleteRecursive(current.Left, value);
        }
        else if (value > current.Value)
        {
            current.Right = DeleteRecursive(current.Right, value);
        }
        else
        {
            if (current.Left == null)
            {
                return current.Right;
            }
            else if (current.Right == null)
            {
                return current.Left;
            }

            current.Value = MinValue(current.Right);
            current.Right = DeleteRecursive(current.Right, current.Value);
        }

        return current;
    }

    private int MinValue(Node node)
    {
        int minValue = node.Value;
        while (node.Left != null)
        {
            minValue = node.Left.Value;
            node = node.Left;
        }
        return minValue;
    }

    public string PreOrder()
    {
        return TraversePreOrder(root).Trim();
    }

    private string TraversePreOrder(Node node)
    {
        if (node == null)
        {
            return "";
        }
        return $"{node.Value} " + TraversePreOrder(node.Left) + TraversePreOrder(node.Right);
    }

    public string InOrder()
    {
        return TraverseInOrder(root).Trim();
    }

    private string TraverseInOrder(Node node)
    {
        if (node == null)
        {
            return "";
        }
        return TraverseInOrder(node.Left) + $"{node.Value} " + TraverseInOrder(node.Right);
    }

    public string PostOrder()
    {
        return TraversePostOrder(root).Trim();
    }

    private string TraversePostOrder(Node node)
    {
        if (node == null)
        {
            return "";
        }
        return TraversePostOrder(node.Left) + TraversePostOrder(node.Right) + $"{node.Value} ";
    }
}