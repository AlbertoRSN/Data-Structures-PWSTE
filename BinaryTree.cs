using System;

class Node
{
    public int data;
    public Node left, right;

    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

class BinaryTree
{

    Node root;
    public static int counter = 0;

    BinaryTree()
    {
        root = null;
    }



    void printPreorder(Node node)
    {
        if (node == null)
            return;
        Console.Write(node.data + "-");
        printPreorder(node.left);
        printPreorder(node.right);
    }


    bool search(Node root, int key)
    {
        while (root != null)
        {
            Console.Write(root.data + "-");
            if (key > root.data)
                root = root.right;
            else if (key < root.data)
                root = root.left;
            else
                return true;
        }
        return false;
    }

    Node searchRec(Node root, int key)
    {
        if (root == null || root.data == key)
            return root;

        if (root.data > key)
            return searchRec(root.left, key);

        return searchRec(root.right, key);
    }
    
    int maxKey(Node root)
    {
        int max = root.data;
        
        while(root != null){
            max = root.data;
            root = root.right;
        }
        
        return max;
    }
    
    int minKey(Node root)
    {
        int min = root.data;
        
        while(root != null){
            min = root.data;
            root = root.left;
        }
        
        return min;
    }
    
    
    bool isBST(Node node, int min, int max)
    {
        /* an empty tree is BST */
        if (node == null)
        {
            return true;
        }

        if (node.data < min || node.data > max)
        {
            return false;
        }

        return (isBST(node.left, min, node.data - 1)
            && isBST(node.right, node.data + 1, max));
    }
    
    
    void insert(Node root, int key)
    {
        if (root == null)		
        {
            Node node = new Node(key);
            this.root = node;
        }
        else if (key < root.data)
        {
            if (root.left != null)
            {
                insert(root.left, key);
            }
            else
            {
                root.left = new Node(key);
            }
        }
        else if (key > root.data)
        {
            if (root.right != null)
            {
                insert(root.right, key);
            }
            else
            {
            root.right = new Node(key);
            }
        }
    }
    
    
    
    private Node DeleteN(Node root, Node deleteNode) 
{
    if (root == null)
    {
        return root;
    }
    if (deleteNode.data < root.data)
    {
        root.left = DeleteN(root.left, deleteNode);
    }
    if (deleteNode.data > root.data)
    {
        root.right = DeleteN(root.right, deleteNode);
    }
    if (deleteNode.data == root.data)
    {
        //No child nodes
        if (root.left == null && root.right == null)
        {
            root = null;
            return root;
        }
        //No left child - DONT WORK
        else if (root.left == null)
        {
            Node temp = root;
            root = root.right;
            temp = null;
        }
        //No right child
        else if (root.right == null)
        {
            Node temp = root;
            root = root.left;
            temp = null;
        }
        //Has both child nodes
        else
        {
            root.data = minKey(root.right);
            root.right =  DeleteN(root.right, root.data);
        }
    }
    return root;
}

//Public method with arg: int value of node to be deleted
public void DeleteNode(int x)
{
    Node deleteNode = new Node(x);
    DeleteN(root, deleteNode);
}
    
    
    static public void Main(String[] args)
    {
        BinaryTree tree = new BinaryTree();

    /*
        tree.root = new Node(10);
        
        tree.root.left = new Node(2);
        
        tree.root.right = new Node(13);
        tree.root.left.left = new Node(1);
        tree.root.left.right = new Node(5);
        tree.root.right.left = new Node(11);
        tree.root.right.right = new Node(25);
    */
        /*
        tree.insert(tree.root, 10);
        tree.insert(tree.root, 7);
        tree.insert(tree.root, 11);
        tree.insert(tree.root, 20);
        tree.insert(tree.root, 17);
        tree.insert(tree.root, 8);
        */
        tree.insert(tree.root, 10);
        tree.insert(tree.root, 5);
        tree.insert(tree.root, 2);
        tree.insert(tree.root, 7);
        //tree.insert(tree.root, 12);
        tree.insert(tree.root, 11);
        tree.insert(tree.root, 13);

        
        Console.WriteLine("Preorder traversal ");
        tree.printPreorder(tree.root);

        /*
        Console.WriteLine("\n-----------------");
        if (tree.isBST(tree.root, 0, 20))
            Console.WriteLine("The tree is BST");
        else
            Console.WriteLine("The tree not is BST");
        */

        //Console.WriteLine ("\nInorder traversal ");
        //tree.printInorder (tree.root);

        //Console.WriteLine ("\nPostorder traversal ");
        //tree.printPostorder (tree.root);

        //-------------iterative------searching----
        /*
        Console.WriteLine ("\n-------------------");
        int key = 5;
        Console.WriteLine ("I am looking for " + key);
        Console.WriteLine (tree.search(tree.root, key));

        key = 11;
        Console.WriteLine ("I am looking for " + key);
        Console.WriteLine (tree.search(tree.root, key));

        key = 12;
        Console.WriteLine ("I am looking for " + key);
        Console.WriteLine (tree.search(tree.root, key));
*/

/*
        //-------------recursive------searching-----
        int key = 11;
        Console.WriteLine ("I am looking for " + key);
        Node what = tree.searchRec (tree.root, key);
        if (what != null)
          Console.WriteLine ("I found " + what.data);
        else
          Console.WriteLine ("I didn't find " + key);
        */
        int min = tree.minKey(tree.root);
        int max = tree.maxKey(tree.root);
        
        Console.WriteLine("\n\n----------------- Maximum Key ---------------");
        Console.Write("Maximum key is {0}", max);
        
        Console.WriteLine("\n\n----------------- Minimum Key ---------------");
        Console.Write("Minimum key is {0}", min);
        
        Console.WriteLine("\n\n----------------- Is BST? ---------------");
        if(tree.isBST(tree.root, min, max))
        {
            Console.Write("The tree is BST");
        }
        else
        {
            Console.Write("The tree is NOT BST");
        }
        
 


        //Console.ReadKey ();
        

    }
}






