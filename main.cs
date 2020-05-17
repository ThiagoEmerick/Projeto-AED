using System;
using System.IO;
using System.Text; 
class MainClass {

  public static void Main (string[] args) { 
    int sair = 1;
    bool confirmaçao = false;
    int  entradaUsuario = 0; 
    int entradaEscohida = 0;
    int codProduto = 0;
    bool verificaResposta;
    string entrada = null;
    Console.Clear();
    Console.WriteLine("## Bem Vindo a AgroCooper##");
    
    while(sair != 0 ){
      Console.WriteLine("## Digite o numero referente ao campo que quer acessar ##"); 
      Console.WriteLine("## 1 - Associado ##"); 
      Console.WriteLine("## 2 - Cliente ##");
      Console.WriteLine("## 3 - Produto ##");
      Console.WriteLine("## 0 - Finalizar Programa ##");  
      entrada = Console.ReadLine();
      //Tratar a entrada inicial
      verificaResposta = digitosCertos(entrada) ;
      if(verificaResposta == false ){
       sair= 1;  
      }else{
        entradaUsuario = int.Parse(entrada);
        switch (entradaUsuario){
          //Associado
          case 1:
          string tipoUsuario = "a";
          int entradaAssociado = 0;
            while(entradaAssociado >= 0 && entradaAssociado <= 2  ){
              verificaResposta = false;
              while(verificaResposta != true){
                Console.Clear();
                Console.WriteLine("## Digite o numero referente ao campo que quer acessar ##"); 
                Console.WriteLine("## 1 - Associado Cadastrado ##"); 
                Console.WriteLine("## 2 - Cadastrar  Associado  ##"); 
                Console.WriteLine("## 0 - Voltar menu inicial ##"); 
                entrada = Console.ReadLine();
                verificaResposta = digitosCertosUmDois(entrada);
                Console.Clear();
              }
              entradaAssociado = int.Parse(entrada);
              switch (entradaAssociado){
                //ASSOCIADO CADASTRADO
                case 1:
                
                  while(confirmaçao !=true){
                    Console.WriteLine("Informe numero usuario ou 0 para sair"); 
                    int numerousuario = int.Parse(Console.ReadLine());
                    if(numerousuario>0){
                      try {
                        Associado associado = Associado.retornaAssociado(numerousuario);
                        Console.WriteLine("Bem vindo(a) {0} !",associado.getNome());
                        confirmaçao = true;
                      }catch{
                        Console.WriteLine ("Usuario Invalido");
                        sair = 0;
                      }
                    }else{
                      sair = 0;
                      confirmaçao = true;
                    }
                    if(sair !=0){
                      Console.WriteLine("1_Realizar Compra\r\n2_Visualizar nota\r\n0_sair\r\n3_ ReceberProduto");
                      entradaEscohida = int.Parse(Console.ReadLine()); 
                      switch (entradaEscohida ){
                        case 1:
                          Produto [] carrinho = Pedido.Carrinho();
                          float [] valorNota = Pedido.valorNota(carrinho); 
                          Console.WriteLine("   Produto                 Valor    ");
                          Console.WriteLine(" {0} Leite                  {1}   ",valorNota [0],valorNota [1]);
                          Console.WriteLine(" {0} Saca de Café Conilon   {1}   ",valorNota [2],valorNota [3]);
                          Console.WriteLine(" Valor Final da Nota        {0}   ",valorNota [4]);
                          Console.WriteLine("1_Se deseja efeutar pedido\r\n0_ Sair");
                          int entradaEscolhida = int.Parse(Console.ReadLine());
                          if(entradaEscohida == 1){
                            Console.Clear();
                            Pedido.efuetarPedido( valorNota,numerousuario,tipoUsuario );
                          }else{
                            sair = 0;
                          }
                        break;  
                      
                        case 2:
                          Console.WriteLine("Informe numero da nota ");
                          int numeroNota = int.Parse(Console.ReadLine()); 
                          try{
                            Pedido.visualizarNota(numeroNota,tipoUsuario,numerousuario);
                          }catch{
                            Console.WriteLine("Informação inválida ");
                          }
                        break;
                        case 3:
                        Console.WriteLine("Informe codigo Prduto");
                        int cond = int.Parse(Console.ReadLine());
                        Console.WriteLine("Informe quantidade produto");
                        float quant = float.Parse(Console.ReadLine());
                        Estoque.adicionaEstoque(cond,quant);
                        break;
                        default:
                          sair =0;
                        break;
                      }
                    }
                    
                  }
               
                break;   
                  
                //CADASTRAR ASSOCIADO
                case 2:
                  Associado.cadastrarAssociado();
                  Console.WriteLine("Associado Cadastrado");
                  System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
                  sair = 1;
                  Console.Clear();  
                break;
                default:
                  sair = 0;
                  
                break;
              }
            }
          break;
             
          break;
          //CLIENTE
          case 2:
           verificaResposta = false;
            while(verificaResposta != true){
              Console.Clear();
              Console.WriteLine("## Digite o numero referente ao campo que quer acessar ##"); 
              Console.WriteLine("## 1 - Cliente Cadastrado ##"); 
              Console.WriteLine("## 2 - Cadastrar  Cliente ##"); 
              Console.WriteLine("## 0 - Voltar menu inicial ##"); 
              entrada = Console.ReadLine();
              verificaResposta = digitosCertosUmDois(entrada);
              Console.Clear();
            }
             int entradaC= int.Parse(entrada);
            tipoUsuario ="c";
            switch(entradaC){
              case 1:
                confirmaçao = false;
                while(confirmaçao !=true){
                  Console.WriteLine("Informe numero usuario ou 0 para sair"); 
                  int numerousuario = int.Parse(Console.ReadLine());
                  if(numerousuario!=0){
                    try {
                      Cliente cliente = Cliente.retornaCliente(1);
                      Console.WriteLine("Bem vindo(a) {0} !",cliente.getNome());
                      confirmaçao = true;
                    }catch {
                      Console.WriteLine ("Usuario Invalido");
                      confirmaçao = false;
                    }

                  }else{
                    sair = 0;
                    confirmaçao = true;
                  }
                  if(sair !=0){
                    Console.WriteLine("1_Realizar Compra\r\n2_Visualizar nota\r\n0_sair");
                    entradaEscohida = int.Parse(Console.ReadLine()); 
                    switch (entradaEscohida ){
                      case 1:
                        sair = RealiazarCompra(numerousuario,tipoUsuario);
                        
                      break;
                      case 2:
                        sair = VisualizarNota(tipoUsuario,numerousuario);
                      break;
                      default:
                      sair = 0;
                      break;
                    }
                  }else{
                    
                  }
                }
              break;
              case 2:
                Cliente.cadastrarCliente();
                Console.WriteLine("Cliente Cadastrado");
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
                sair = 1;
                Console.Clear(); 
              break;
              default:
                sair =0;
              break;
            }
            

          break;
          default:
            sair = 0;
          break;
          
          
        }
      }
    }
  }
  //  visualizar nota
  public static int VisualizarNota(string tipoUsuario,int numerousuario){
    Console.WriteLine("Informe numero da nota ");
    int numeroNota = int.Parse(Console.ReadLine()); 
    int sair = 0;
    while(numeroNota != 0){
      try{
        Pedido.visualizarNota(numeroNota,tipoUsuario,numerousuario);
        sair=1;
      }catch{
        Console.WriteLine("Informação inválida ");
        Console.WriteLine("digite informaçao certa ou 0 para sair");
        numeroNota = int.Parse(Console.ReadLine());
      }
    }
   
  return sair;
  }
  //RREALIZAR COMPRA
  public static int  RealiazarCompra(int numerousuario,string tipoUsuario){
    Produto [] carrinho = Pedido.Carrinho();
    int sair =0;
    float [] valorNota = Pedido.valorNota(carrinho); 
    Console.WriteLine("   Produto                 Valor    ");
    Console.WriteLine(" {0} Leite                  {1}   ",valorNota [0],valorNota [1]);
    Console.WriteLine(" {0} Saca de Café Conilon   {1}   ",valorNota [2],valorNota [3]);
    Console.WriteLine(" Valor Final da Nota        {0}   ",valorNota [4]);
    Console.WriteLine("1_Se deseja efeutar pedido\r\n0_ Sair");
    int entradaE= int.Parse(Console.ReadLine());
    if(entradaE== 1){
      Console.Clear();
      Pedido.efuetarPedido( valorNota,numerousuario,tipoUsuario );
      sair =1;
    }else{
      sair = 0;
    }
    return sair;
  }

  //FUNÇAO TRATAR ENTRADA INICIAL(0,1,3) 
  public static bool digitosCertos(string entrada){
    char primeiroCaracter = entrada[0];
    int codigoAscii = Convert.ToInt32(primeiroCaracter );
    if(codigoAscii < 48 || codigoAscii > 51 || entrada.Length > 1){
      Console.WriteLine("Opção inválida");
      Console.WriteLine("Digite uma opção correta ou 0 prar sair");
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(4));
      Console.Clear();
      return false;
    }
    
    return true;  
  }
  //FUNÇAO TRATAR ENTRADA NUMERO 0,1,2.
  public static bool digitosCertosUmDois(string entrada){
    char primeiroCaracter = entrada[0];
    int codigoAscii = Convert.ToInt32(primeiroCaracter );
    if(codigoAscii == 48){
      return true; 
    }
    if(codigoAscii > 48 || codigoAscii <  52 || entrada.Length > 1){
      Console.WriteLine("Opção inválida");
      Console.WriteLine("Digite uma opção correta ou 0 prar sair");
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
      return false;   
    }
    return true;  
  }
 //FUNÇAO TRATAR ENTRADA NUMERO 1 E 0
  public static bool digitosCertosZeroUm(string entrada){
    char primeiroCaracter = entrada[0];
    int codigoAscii = Convert.ToInt32(primeiroCaracter );
    if(codigoAscii > 47 || codigoAscii < 51 || entrada.Length > 1){
      Console.WriteLine("Opção inválida");
      Console.WriteLine("Digite uma opção correta ou 0 prar sair");
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
      return false;
      
    }
    return true;  
  }
  
  //FUNÇAO TRATAR ENTRADA NUMERO CADASTRO
  public static bool digitosCertosNumeroQualquer(string entrada){
    char primeiroCaracter = entrada[0];
    int codigoAscii = Convert.ToInt32(primeiroCaracter );
    if(codigoAscii < 47 || codigoAscii > 57 || entrada.Length > 1){
      Console.WriteLine("Opção inválida");
      Console.WriteLine("Digite uma opção correta ou 0 prar sair");
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
      return false;  
    }
    return true;  
  }
}
