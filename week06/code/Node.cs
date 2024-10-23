public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }
    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value < Data)
        {
            // Insert to the left
            if (Left == null) // change is null to == nul
            {
                Left = new Node(value);// add braces to if else statement
            }
            else
            {
                Left.Insert(value);
            }
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right == null)// change is null to == to null
            {
                Right = new Node(value);// add braces to the if else statement
            }
            else
            {
                Right.Insert(value);
            }
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true; // the value matched the current node's data
        }
        else if (value < Data && Left != null)
        {
            return Left.Contains(value);// search the left sub tree
        }
        else if (value > Data && Right != null)
        {
            return Right.Contains(value); // search the right sub tree
        }
        else
        {
            return false; // value is not found
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = Left?.GetHeight() ?? -1; // code to get height of the left subtree
        int rightHeight = Right?.GetHeight() ?? -1; // code to get the height of the right subtree
        return 1 + Math.Max(leftHeight, rightHeight); // Replace this line with the correct return statement(s) // get the height of the current node which is 1  + the maximum height of left and right subtrees
    }

}
