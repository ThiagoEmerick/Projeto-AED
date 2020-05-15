using System;
using System.IO;
using System.Text;

class Usuario_Associado : Usuario {
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

 public Usuario_Associado (string parametroCpf, string parametroTipoProdutoVinculado, string parametroNome, int parametroNumeroTele, string parametroEndereço, string parametroCp) : base(parametroNome, parametroNumeroTele, parametroEndereço, parametroCp)
  {
   cpf = parametroCpf;
   tipoProdutoVinculado = parametroTipoProdutoVinculado;
  }
  
  /*metodo de cadastra associado*/
  
  public static void cadastrarAssociado(){
   int numerodecadastro = numeroDeCadastroAssociado();
    Console.WriteLine("numero do cadastro:{0}",numerodecadastro +1); 
    Console.WriteLine( "Por Favor passe as seguintes informações para criar seu cadastro seguindo o exemplo: Nome,Cpf,tipo de produto Vinculado,Telefone,Endereço,Cep");
    Console.WriteLine("Sem espaço se o nome for composto,letras maiúsculas nas iniciase e sem caracteres especiais tipo !,* ect e Ç");
    Console.WriteLine("Exemplo: caioLucas,1230215402,leite,330302025,corrego da babilonia,33251000");
    string dados = Console.ReadLine();
    
    FileStream arq = new FileStream("Cadastro_Assosiado.text",FileMode.Append,FileAccess.Write);
    StreamWriter informaçoesbasicas= new StreamWriter(arq, Encoding.UTF7);    
    string infobasic = dados;
    informaçoesbasicas.WriteLine(infobasic);
    informaçoesbasicas.Close();
    arq.Close(); 
    Console.WriteLine ( " Cadastro realizado ");
    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3)); 
  }
  
  /*metodo de cadastro de associado*/  
  public static int numeroDeCadastroAssociado(){
    int i = 0;
    FileStream  leiturArqAssociado= new FileStream("Cadastro_Assosiado.text",FileMode.Open,FileAccess.Read);
    
    StreamReader infoBasic =new StreamReader(leiturArqAssociado,Encoding.UTF8);   
    while(!infoBasic.EndOfStream){
      infoBasic.ReadLine();
      i++;
    } 
    infoBasic.Close();
    leiturArqAssociado.Close();
    return i;
  }
/*
   public bool  VerificarCadastro(string cpf){
    
    AtualizarLista();
    
    foreach(Usuario_Associado u in usuarios){
      if ( email == u.getEmail() ){

        return false;
      }

    } 

    return true;
*/
  }
