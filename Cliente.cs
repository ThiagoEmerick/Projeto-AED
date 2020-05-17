using System;
using System.IO;
using System.Text;

class Cliente : Usuario {
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
  public Cliente( string nomeFant,string parametroNome,string parametroCnpj, string parametroEndereço ) : base(parametroNome, parametroEndereço){
    cnpj = parametroCnpj;
    nomeFantasia = nomeFant;
  }

 
  // método de cadastro cliente 
  public static void cadastrarCliente(){
    Console.WriteLine("numero do cadastro:{0}",numeroDeCadastro()+1);
    Console.WriteLine( " Por Favor passe as seguintes informações para criar seu cadastro seguindo o exemplo: NomeFantasia,NomeProprietario,Cnpj,Endereço");
    Console.WriteLine("Sem letras maiúsculas nas iniciase e sem caracteres especiais tipo ! *  e Ç" );
    Console.WriteLine(" Exemplo:supermercadoreal,caiolucas,03.302.666/0001-56,SacramentoCalifornia");
    string dados = Console.ReadLine();
    
    FileStream arq = new FileStream("Cliente.text",FileMode.Append,FileAccess.Write);
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
    FileStream  leiturArqCliente= new FileStream("Cliente.text",FileMode.Open,FileAccess.Read);
    StreamReader infoBasic =new StreamReader(leiturArqCliente,Encoding.UTF8);
 
    while(!infoBasic.EndOfStream){
      infoBasic.ReadLine();
      i++;
    } 
    infoBasic.Close();
    leiturArqCliente.Close();
    return i;
  } 
  public static Cliente retornaCliente(int numeroCadastro){
    int cont = 0;
    string cadastro = null;
    FileStream  leiturArqCliente= new FileStream("Cliente.text",FileMode.Open,FileAccess.Read);
    StreamReader infoBasic =new StreamReader(leiturArqCliente,Encoding.UTF8);   
    while(!infoBasic.EndOfStream){
      cont++;
      string linha = infoBasic.ReadLine();
      if( numeroCadastro == cont){
        cadastro =linha;  
       
      }  
    } 
    infoBasic.Close();
    leiturArqCliente.Close();
    
    string[] linhainformaçoes = cadastro.Split('/');
    string  nome = linhainformaçoes[0];
    string cpf= linhainformaçoes[1];
    string tipoProdutoVinculado = linhainformaçoes[2];
    string endereço = linhainformaçoes[3];
    Cliente cliente = new Cliente(nome,cpf,tipoProdutoVinculado,endereço);
    
    return cliente;
  }
  

}