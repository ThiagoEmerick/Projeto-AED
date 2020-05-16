using System;
using System;
using System.IO;
using System.Text;

class MainClass {
  public static void Main (string[] args) {
    int sair = 1;
    int  entradaUsuario = 0; 
    int codProduto = 0;
    bool verificaResposta;
    string entrada = null;
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
          case 1 :
          Console.WriteLine("## teste 1 ##");
          break;

          case 2:
          Console.WriteLine("## teste 2 ##");
          break ;

          case 3:
          Console.WriteLine("## teste 3 ##");
          break ;
         
          default:
          sair = 0;
          break;
        }
       }
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
   
  
