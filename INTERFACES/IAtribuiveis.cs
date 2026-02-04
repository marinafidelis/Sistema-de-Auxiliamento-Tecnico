// Define um contrato para objetos que podem receber um técnico.
public interface IAtribuivel
{
    void AtribuirTecnico(Tecnico tecnico); // Qualquer classe que implementar esta interface, deve possuir um método para atribuir um técnico.
}
//SOLID APLICADO AQUI:
//ISP — Interface Segregation Principle: Interfaces pequenas e específicas, não genéricas demais.
//DIP — Dependency Inversion: Services podem depender da interface, não da classe concreta.