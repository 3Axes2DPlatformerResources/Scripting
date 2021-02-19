public class Client {
    // Données
    private string name;
    private string surname;
    private int age;
    private int numberOfTimesAgeHasBeenModified;
    public static int numberOfClients;

    // Constructeur
    public Client(string surname, string name, int age) {
        this.name = name;
        this.surname = surname;
        this.age = age;
        numberOfTimesAgeHasBeenModified = 0;
        numberOfClients++;
    }
    
    // Méthodes
    public void ChangeSurname(string surname) {
        this.surname = surname;
    }

    public void ChangeAge(int newAge) {
        age = newAge;
        numberOfTimesAgeHasBeenModified++;
    }
}