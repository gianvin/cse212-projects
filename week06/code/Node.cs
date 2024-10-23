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
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        return 0; // Replace this line with the correct return statement(s)
    }
}