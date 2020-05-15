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