class  Usuario{
  private  string nome = null;
  private  string endereço= null;

  public Usuario(string name, string enderço ){
   nome = name;
   endereço = enderço;
  }
  public Usuario(){
   nome = "Jane Done";
   endereço = "Sem endereço";
  }
  public string getNome(){
    return nome;
  }
  public string getEndereço(){
    return endereço;
  }
}