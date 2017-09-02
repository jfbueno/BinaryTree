public class BinarySearchTree 
{
    public BSTNode Root;
    public bool Empty => Root == null;

    public void Clear() => Root = null;

    public BSTNode Search(int el) => Search(Root, el);

    private BSTNode Search (BSTNode pai, int el) 
    {
        while (pai != null) 
        {
            if (el == pai.Key) 
                return pai;
            else if (el < pai.Key)
                pai = pai.Left;
            else 
                pai = pai.Right;
        }
        return null;
    }

    public void ExclusaoFolha(ref BSTNode node) => node = null;
   
    public void ExclusaoUmFilho(BSTNode node) => ExclusaoUmFilho(EncontrarPai(node), node);

    public void ExclusaoUmFilho(BSTNode pai, BSTNode node)
    {
        var filho = node.Left ?? node.Right;

        if(pai.Left == node)
            pai.Left = filho;
        else
            pai.Right = filho;
    }    

    public void ExclusaoCopia(BSTNode node) 
    {
        var maior = node.Left; // A partir daqui tem-se uma subárvore com os menores apenas

        while(maior.Right != null)
        {
            maior = maior.Right;
        }

        //aqui `maior` é o maior elemento da subárvore da esquerda do nó a ser excluído
        node.Key = maior.Key;
        
        if(maior.Left != null) 
            ExclusaoUmFilho(maior);
        else
        {
            ExclusaoFolha(ref node.Left);
        }
    }

    public void ExclusaoFusao(BSTNode node)
    {
        BSTNode subRoot;
        var subEsquerda = subRoot = node.Left; // Aqui tem-se a subárvore da esquerda
        var subDireita = node.Right; // Aqui, a subárvore da direita

        while(subEsquerda.Right != null)
        {
            subEsquerda = subEsquerda.Right;
        }

        subEsquerda.Right = subDireita; // A subárvore da direita, passa a ser filha do maior elemento da sub da esquerda
        var pai = EncontrarPai(node);
        
        if(pai.Key < subRoot.Key)
            pai.Right = subRoot;
        else
            pai.Left = subRoot;

    }

    private BSTNode EncontrarPai(BSTNode child) => EncontrarPai(Root, child);

    public BSTNode EncontrarPai(BSTNode root, BSTNode child)
    {
        if(root.Left == null && root.Right == null)
            return null;        

        if(root.Left == child || root.Right == child)
            return root;

        var leftSearch = EncontrarPai(root.Left, child);        
        if (leftSearch != null)
            return leftSearch;
        
        return EncontrarPai(root.Right, child);
    }
}