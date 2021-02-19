public class ClientPremium : Client {
    public int TauxDeReduction;
    
    public ClientPremium(string surname,
        string name,
        int age,
        int tauxDeReduction)
        : base(surname, name, age) {
        TauxDeReduction = tauxDeReduction;
    }
    
    public ClientPremium(string surname, string name, int age)
        : base(surname, name, age) {
        TauxDeReduction = 10;
    }
}