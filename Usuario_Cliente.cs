using System;
using System.IO;
using System.Text;

class Usuario_Cliente : Usuario {
  private string cnpj;
  private string nomeFantasia;

  public string getCnpj(){
    return cnpj;
  }
  public string getNomeFantasia(){
    return nomeFantasia;
  }
  public void setCnpj(string novoCnpj){
    cnpj =  novoCnpj;
  }
  public void setnomeFantasia (string novoNomeFantasia){
   nomeFantasia =  novoNomeFantasia;
  }

  public Usuario_Cliente (string nomeFantasiaUsuario, string nomeUsuario ,string cnpjUsuario,  int numeroTeleUsuario, string endereçoUsuario, string cepUsuario) : base(nomeUsuario, numeroTeleUsuario, endereçoUsuario, cepUsuario)
  {
   cnpj = cnpjUsuario;
   nomeFantasia = nomeFantasiaUsuario;
  }
  
  // método de cadastro cliente 
  public static void cadastrarCliente(){
    Console.WriteLine("numero do cadastro:{0}",numeroDeCadastro()+1);
    Console.WriteLine( " Por Favor passe as seguintes informações para criar seu cadastro seguindo o exemplo: NomeFantasia,Nome,Cnpj,Telefon,Endereço,Cep ");
    Console.WriteLine("Sem letras maiúsculas nas iniciase e sem caracteres especiais tipo ! *  e Ç" );
    Console.WriteLine(" Exemplo:supermercado real,caio lucas,03.302.666/0001-56,995306180,rua verde sacramento california, 29153016 ");
    string dados = Console.ReadLine();
    
    FileStream arq = new FileStream("Cadastro_Cliente.text",FileMode.Append,FileAccess.Write);
    StreamWriter informaçoesbasicas= new StreamWriter(arq, Encoding.UTF7);    
    string infobasic = dados;
    informaçoesbasicas.WriteLine(infobasic);
    informaçoesbasicas.Close();
    arq.Close(); 
    Console.WriteLine ( " Cadastro realizado ");
    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3)); 

  }
   
  //número de cadastro do    cliente 
  public static int numeroDeCadastro(){
    int i = 0;
    FileStream  leiturArqCliente= new FileStream("Cadastro_Cliente.text",FileMode.Open,FileAccess.Read);
    StreamReader infoBasic =new StreamReader(leiturArqCliente,Encoding.UTF8);
 
    while(!infoBasic.EndOfStream){
      infoBasic.ReadLine();
      i++;
    } 
    infoBasic.Close();
    leiturArqCliente.Close();
    return i;
  }
}