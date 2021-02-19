public class Main {
    private void MainMethod() {
        Client client = new Client(
            "Bob",
            "Dupont",
            20); // constructeur
        
        client.ChangeSurname("Dylan");

        ClientPremium clientPremium = new ClientPremium(
            "Bob",
            "Dupont",
            20);
    }
}