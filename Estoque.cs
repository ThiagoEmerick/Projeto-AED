using System;
using System.IO;
using System.Text;

class Estoque{
  //CONSTRUTOR
  private float quantEstoque = 0.0f;
  private Produto produtoEstoque;
 
 
  public Estoque ( Produto produto){
    produtoEstoque = produto;
    quantEstoque  =  retornaQuantEstoque ( produto.getCodProduto(), retornaArqEstoque());

  }
 //metodo de acesso
 public Produto getProdutoEstoque(){
   return produtoEstoque; 
 }

  public float getQuantEstoque(){
    return quantEstoque;
  }
  public void setQuantEstoque (float qntdEstoque){
    quantEstoque = qntdEstoque;
  } 
 
  //RETORNA INFORMAÇOES ESTOQUE PRODUTO
  public void retornaInformaçoesEstoque(Produto 
  produtoEstoque){
   Console.WriteLine("Nome: {0}\r\nCodigo Produto: {1}\r\n quantidade no estoque: ",produtoEstoque.getNomeProduto(), produtoEstoque.getCodProduto());
   
    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
    Console.Clear();
  }
  //RETORNA VETOR ESTOQUE
  public string [] retornaArqEstoque() {
    FileStream  arqEstoque = new FileStream("Estoque.text",FileMode.Open,FileAccess.Read);
    StreamReader lerArq =new StreamReader(arqEstoque,Encoding.UTF8);     
    string [] vetor = new string [6];
    int contador = 0;
    while(!lerArq.EndOfStream){
      string informaçao  = lerArq.ReadLine();
      vetor [contador] = informaçao; 
      contador++;   
    }
    lerArq.Close();
    arqEstoque.Close();
   
    return vetor;
  }
  
  public   float  retornaQuantEstoque ( int  codiProduto , string [] vetorEstoque ) {
   string [] quant  =  vetorEstoque ;
   float  quantidadeProduto  =  0.0f ;
    if ( codiProduto  ==  0 ) {
      quantidadeProduto  =  float . Parse ( quant [ 2 ]);  
    }else {
      quantidadeProduto  =  float . Parse ( quant [ 5 ]);
    } 
    return  quantidadeProduto ;
  } 
 
  //RETIRAR  ESTOQUE
  public  void retirarEstoque(int codiProduto, string [] vetorEstoque,float quantRetirar){
   string [] quant = vetorEstoque;
   float quantidadeProduto = 0.0f;
    if(codiProduto == 0 ){
      quantidadeProduto = float.Parse(quant[2]);
      quant[2] =""+( quantidadeProduto - quantRetirar);
      File.WriteAllLines("Estoque.text", quant);
      Console.WriteLine("Produto separado no estoque");
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(6));
      Console.Clear(); 
    }
    if(codiProduto == 1 ){
      quantidadeProduto = float.Parse(quant[5]);
      quant[5] =""+( quantidadeProduto - quantRetirar); 
      File.WriteAllLines("Estoque.text", quant);
      Console.WriteLine("Produto separado no estoque");
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(6));
      Console.Clear(); 
      
    } 
  }
  //ADICIONA ESTOQUE
  public  void adicionaEstoque(int codiProduto,float quantAdicionar){
   string [] quant = retornaArqEstoque();
   float quantidadeProduto = 0.0f;
    if(codiProduto == 0 ){
      quantidadeProduto = float.Parse(quant[2]);
      quant[2] =""+( quantidadeProduto + quantAdicionar);
      File.WriteAllLines("Estoque.text", quant);
      Console.WriteLine("Produto adionado ao estoque");
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(6));
      Console.Clear(); 
    }
    if(codiProduto == 1 ){
      quantidadeProduto = float.Parse(quant[5]);
      quant[5] =""+( quantidadeProduto + quantAdicionar); 
      File.WriteAllLines("Estoque.text", quant);
      Console.WriteLine("Produto adicionado ao estoque");
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(6));
      Console.Clear(); 
      
    } 
  }
  //CONFERIR QUANIDADE PRODUTO EM ESTOQUE
  public bool conferirQuantEstoque(Produto produto){
    bool confirmaEstoque = false;
    string [] quant = retornaArqEstoque();
    float quantConfere = float.Parse(quant[2]);
     float quantProduto = produto.getQuantProduto();
    if(produto.getCodProduto() == 0){
      if(quantProduto > 0){
        quantConfere = float.Parse(quant[2]);
        if(quantConfere > quantProduto){
          confirmaEstoque = true;
        }else{
          confirmaEstoque = false;
        }
      }else{
        confirmaEstoque = false;
      }

    }else{
      if(quantProduto > 0){
        quantConfere = float.Parse(quant[5]);
        if(quantConfere > quantProduto){
          confirmaEstoque = true;
        }else{
          confirmaEstoque = false;
        }
      }else{
        confirmaEstoque = false;
      }
    
    }
    return confirmaEstoque;
  }
}