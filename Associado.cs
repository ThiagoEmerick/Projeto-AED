using System;
using System.IO;
using System.Text;

class Associado : Usuario {
  private string cpf;
  private string tipoProdutoVinculado;

  public string getCpf(){
    return cpf;
  }
  public string getTipoProdutoVinculado(){
    return tipoProdutoVinculado;
  }
  public void setCpf(string novoCpf){
    cpf =  novoCpf;
  }
  public void setTipoProdutoVinculado (string novoTipoProduto){
   tipoProdutoVinculado =  novoTipoProduto;
  }

 public Associado ( string parametroNome,string parametroCpf, string tipoProdutoVin, string parametroEndereço ) : base(parametroNome, parametroEndereço)
  {
   cpf = parametroCpf;
   tipoProdutoVinculado = tipoProdutoVin;
  }
 
  /*metodo de cadastra associado*/
  
  public static void cadastrarAssociado(){
   int numerodecadastro = numerolinhas();
    Console.WriteLine("numero do cadastro:{0}",numerodecadastro +1); 
    Console.WriteLine( "Por Favor passe as seguintes informações para criar seu cadastro seguindo o exemplo: Nome/Cpf/tipo de produto Vinculado/Endereço");
    Console.WriteLine("Sem espaço se o nome for composto,letras maiúsculas nas iniciase e sem caracteres especiais tipo !,* ect e Ç");
    Console.WriteLine("Exemplo: caioLucas/1230215402/leite/corrego da babilonia");
    string dados = Console.ReadLine();
    
    FileStream arq = new FileStream("Assosiado.text",FileMode.Append,FileAccess.Write);
    StreamWriter informaçoesbasicas= new StreamWriter(arq, Encoding.UTF7);    
    string infobasic = dados;
    informaçoesbasicas.WriteLine(infobasic);
    informaçoesbasicas.Close();
    arq.Close(); 
    Console.WriteLine ( " Cadastro realizado ");
    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3)); 
  }
  
  /*metodo de cadastro de associado*/  
  public static int numerolinhas(){
    int i = 0;
    FileStream  leiturArqAssociado= new FileStream("Associado.text",FileMode.Open,FileAccess.Read);
    StreamReader infoBasic =new StreamReader(leiturArqAssociado,Encoding.UTF8);   
    while(!infoBasic.EndOfStream){
      infoBasic.ReadLine();
      i++;
    } 
    infoBasic.Close();
    leiturArqAssociado.Close();
    return i;
  }
  
  public static Associado retornaAssociado(int numeroCadastro){
    int cont = 0;
    string cadastro = null;
    FileStream  leiturArqAssociado= new FileStream("Associado.text",FileMode.Open,FileAccess.Read);
    StreamReader infoBasic =new StreamReader(leiturArqAssociado,Encoding.UTF8);   
    while(!infoBasic.EndOfStream){
      cont++;
      string linha = infoBasic.ReadLine();
      if( numeroCadastro == cont){
        cadastro =linha;  
       
      }  
    } 
    infoBasic.Close();
    leiturArqAssociado.Close();
    
    string[] linhainformaçoes = cadastro.Split('/');
    string  nome = linhainformaçoes[0];
    string cpf= linhainformaçoes[1];
    string tipoProdutoVinculado = linhainformaçoes[2];
    string endereço = linhainformaçoes[3];
    Associado associado = new Associado(nome,cpf,tipoProdutoVinculado,endereço);
   Console.WriteLine(associado);
    return associado;
  }
}
 
