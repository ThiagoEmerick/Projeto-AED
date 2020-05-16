using System;
using System.IO;
using System.Text;

class Pedido{

  public static  Produto [] Carrinho(){
    Produto [] produtoCarrinho = new Produto[100];
    int  sair = 1;
    int posiçao = 0;
    while(sair != 0){
      Console.WriteLine("Insira código produto:\r\n1_Leite\r\n2_Café Conilor\n0_sair");
      int entradaUsuario =  int.Parse(Console.ReadLine());
      if(sair!=0){
        
        Produto produto = new Produto (entradaUsuario-1 );
        Console.WriteLine("Insira a quantidade:");
        float quantidade = float.Parse(Console.ReadLine());
        produto.setQuantidadeProduto(quantidade);
        Estoque estoque = new Estoque(produto);
        bool produtoNoEstoque = estoque.conferirQuantEstoque(produto);
        if (produtoNoEstoque == true ){
          Console.WriteLine("Produto em estoque.Deseja adicionar no carrinho?\r\n1_sim\r\n2_não");
          int adCarinho =  int.Parse(Console.ReadLine());
          if(adCarinho == 1){
            produtoCarrinho[posiçao] = produto;  
            sair = 1;
          } else{
            sair = 0;
          }
          Console.WriteLine("1_Para consultar produto novamento\r\n0_Sair");
          sair = int.Parse(Console.ReadLine());
        }
        posiçao++;
        
      }else{
        sair = 0;
      }
    
    }
    
  return produtoCarrinho;
  } 
  public static float [] valorNota(Produto [] produtosCarrinho){
   
    float []valorNota = new float [6];
    float valorFinal= 0.0f;
    int cont = 0;
    float valorVendaL =0.0f;
    float valorVendaC =0.0f;
    int quantidadeProdutoLeite = 0;
    int quantidadeProdutoCafe = 0;
    while (produtosCarrinho[cont] != null){
      Produto produto = produtosCarrinho[cont];
      valorFinal = (valorFinal+produto.getValorVenda());
      
      if(produto.getCodProduto() == 0){
        quantidadeProdutoLeite++;
        valorVendaL = produto.getValorVenda();
      }else{
        quantidadeProdutoCafe++;
        valorVendaC = produto.getValorVenda();
      }
      cont++;
    }
    
    valorNota[0]= quantidadeProdutoLeite;
    valorNota[1]= valorVendaL;
    valorNota[2]= quantidadeProdutoCafe;
    valorNota[3]= valorVendaC;
    valorNota[4]= valorFinal;  
    return valorNota;
  }
  public static void visualizarNota(int numeroNota,string tipoUsuario,int codUsuario){
    Associado.retornaAssociado(codUsuario);
    if(tipoUsuario =="c"){
      Cliente cliente = Cliente.retornaCliente(codUsuario);
      Console.WriteLine("       AgroCooper    ");
      Console.WriteLine("Pedido número :{0} ",numeroNota);
      Console.WriteLine("Nome fantasia: {0}    Nome Proprietario:{1}",cliente.getNomeFantasia(),cliente.getNome());
      Console.WriteLine("Cnpj: {0}    ",cliente.getCnpj());
      Console.WriteLine("Endereço: {0}    ",cliente.getEndereço());
      int cont = 0;

      FileStream  leiturArq= new FileStream("Pedido.text",FileMode.Open,FileAccess.Read);
      StreamReader infoBasic =new StreamReader(leiturArq,Encoding.UTF8);   
      while(!infoBasic.EndOfStream){
        cont++;
        string linha = infoBasic.ReadLine();
        if(cont == (numeroNota+8)){
          Produto produto = new Produto(0);
          Console.WriteLine("  Produto {0} ",produto.getNomeProduto());
        } 
        if(cont == (numeroNota+9)){
          
          Console.WriteLine("  Valor unitario{0} ",linha);
        }
        if(cont == (numeroNota+10)){
          Produto produto = new Produto(1);
          Console.WriteLine("  Produto {0} ",produto.getNomeProduto());
        } 
        if(cont == (numeroNota+11)){
          
          Console.WriteLine("  Valor unitario{0} ",linha);
        }
        if(cont == (numeroNota+12)){
          
          Console.WriteLine("  Valor Total{0} ",linha);
        }
      } 
      infoBasic.Close();
      leiturArq.Close(); 
    }else{
      Associado associado = Associado.retornaAssociado(codUsuario);
      Console.WriteLine("       AgroCooper    ");
      Console.WriteLine("Pedido número :{0} ",numeroNota);
      Console.WriteLine("Nome fantasia: {0}  ",associado.getNome());
      Console.WriteLine("Cpf: {0}    ",associado.getCpf());
      Console.WriteLine("Endereço: {0}    ",associado.getEndereço());
      int cont = 0;
      string cadastro = null;
      FileStream  leiturArq= new FileStream("Pedido.text",FileMode.Open,FileAccess.Read);
      StreamReader infoBasic =new StreamReader(leiturArq,Encoding.UTF8);   
      while(!infoBasic.EndOfStream){
        cont++;
        string linha = infoBasic.ReadLine();
        if(cont>=numeroNota && cont<=(numeroNota +3)){
          Console.Write(linha); 
        
        }  
      } 
      infoBasic.Close();
      leiturArq.Close(); 
    }
  }

 
  //efetuar Pedido
  public static void efuetarPedido(float [] valorNota,int codUsuario, string tipoUsuario){
   
    int posiçao = 0;
      
    FileStream arq = new FileStream("Pedido.text",FileMode.Append,FileAccess.Write);
    StreamWriter informaçoesbasicas= new StreamWriter(arq, Encoding.UTF7);    
    
    informaçoesbasicas.WriteLine(tipoUsuario );
    String inf;
    inf= codUsuario.ToString();
    informaçoesbasicas.WriteLine( inf );
    while(posiçao <=4){
      inf = valorNota[posiçao].ToString();
      informaçoesbasicas.WriteLine(inf);
      
      posiçao++;
    }
    int prod=0;
     string[]vetor=Estoque.retornaArqEstoque();
    Estoque.retirarEstoque( prod , vetor,valorNota[0]);
    prod=1;
    Estoque.retirarEstoque( prod,vetor ,valorNota[2]);
    informaçoesbasicas.Close();
    arq.Close(); 
   
    Console.WriteLine ( " Pedido realizado ");
    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3)); 

  }
   
  
}