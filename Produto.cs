using System;
using System.IO;
using System.Text;

class Produto{
  private int codigoProduto = 0;
  private string nomeProduto = null;
  private float valorVenda = 0.0f ;
  private float valorBruto = 0.0f ;
  private float quantProduto = 0.0f ;
  
  public float getValorBruto(){
    return valorBruto;
  }
  public float getQuantProduto(){
    return quantProduto;
  }
  public float getValorVenda(){
    return valorVenda;
  }
  public string getNomeProduto(){
    return nomeProduto;
  }
  public int getCodProduto(){
    return codigoProduto;
  }
  public void setNovoValor(float novoValor){
   valorBruto = novoValor;
  }
  public void setQuantidadeProduto(float quantidade){
   quantProduto = quantidade;
  }
  public Produto(int codProduto){
    if(codProduto == 0)
    {
      //CONSTRUTOR LEITE
      codigoProduto = 0; 
      nomeProduto = "leite";
      float valorArq = retornaValorBruto(codigoProduto);
      valorBruto = valorArq;
      valorVenda = (valorBruto+((valorBruto*10)/(100)));
      Console.WriteLine(valorVenda);
    }else{
      //CONSTRUTOR CAFE
      codigoProduto = 1; 
      nomeProduto = "Cafe Conilon";
      float valorArq = retornaValorBruto(codigoProduto);
      valorBruto = valorArq;
      valorVenda = (valorBruto+((valorBruto*10)/(100)));
      
    }
    
  }
  //IDENTIFICA PRODUTO
  public  Produto identificaProduto(int codiProduto){
    if(codiProduto == 0 ){
      Produto produtoSelecionado= new Produto(0);
     return produtoSelecionado;
    }else{
      Produto produtoSelecionado = new Produto(1);
      return produtoSelecionado;
    }  
    
  }
  //RETORNA VALOR BRUTO
  public  float retornaValorBruto(int codiProduto){
   string [] valor = retornaArqProduto();
   float valorArq = 0.0f;
    if(codiProduto == 0 ){
     valorArq= float.Parse(valor[2]);
      return valorArq;
    }else{
      valorArq= float.Parse(valor[6]); 
      return valorArq;
    }  
    
  }
  //RETORNA INFORMAÇÕES PRODUTO
  public void retornaInformaçoesProduto(Produto produto)
  {
    
    Console.WriteLine("Nome: {0}\r\nCodigo Produto: {1}\r\nValor Venda:{2} ",produto.getNomeProduto(), produto.getCodProduto(),produto.getValorVenda());
    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
    Console.Clear();
  }
  //ALTERAR INFORMAÇAO
  public void alteraValor(Produto produto)
  {
    Console.WriteLine("Informe valor que deseja alterar:");
    string valor = Console.ReadLine();
    float valorNovo =  float.Parse(valor);
    produto.setNovoValor(valorNovo);
    Console.WriteLine(produto.getValorVenda());
    string  [] vetorAlterar = produto.retornaArqProduto();
    if( produto.getCodProduto() == 0 ){
      
      vetorAlterar [2] = valor;
      vetorAlterar [3] = ""+produto.getValorVenda();  
    } 
    if( produto.getCodProduto() == 1 ){
      vetorAlterar [6] = valor;
      vetorAlterar [7] = ""+produto.getValorVenda();  
    }  
 
    File.WriteAllLines("Produto.text", vetorAlterar);
    Console.WriteLine("Valor alterado");
    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(6));
    Console.Clear();
  }
  //RETORNA VETOR INFORM PRODUTO

  public string [] retornaArqProduto() {
    FileStream  arqProduto = new FileStream("Produto.text",FileMode.Open,FileAccess.Read);
    StreamReader lerArq =new StreamReader(arqProduto,Encoding.UTF8);     
    string [] vetor = new string [8];
    int contador = 0;
    while(!lerArq.EndOfStream){
      string informaçao  = lerArq.ReadLine();
      vetor [contador] = informaçao; 
      contador++;   
    }
    lerArq.Close();
    arqProduto.Close();
   
    return vetor;
  } 
   

 

}