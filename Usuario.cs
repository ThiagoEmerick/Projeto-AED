class  Usuario{
  private  string nome = null;
  private  int numeroTelefone = 00;
  private  string endereço= null;
  private string  cep = null;

  public Usuario(string name, int numeroTele, string enderç, string cp){
   nome = name;
   numeroTelefone = numeroTele;
   endereço = enderç;
   cep = cp;
  }
  public Usuario(){
   nome = "Jane Done";
   numeroTelefone = 000000;
   endereço = "Sem endereço";
   cep = "0000";
  }
  public string getNome(){
    return nome;
  }
  public string getEndereço(){
    return endereço;
  }
   public string getCep(){
    return cep;
  }
  
  public int getNumeroTelefone(){
    return numeroTelefone;
  }
}