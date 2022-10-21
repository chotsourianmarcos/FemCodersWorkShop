package JavaProject.Entities;
import java.util.List;

public class SuperCharacter {

    public SuperCharacter(String secretName){
        SecretName = secretName;
    }
    public String PublicName;
    private String SecretName;
    public Boolean Alignment;
    public List<SuperPower> SuperPowers;
    public UltraSuperPower ultraSuperPower;
    private int Stamina;
    public String Destiny;
    public String SecretWeakness;

    public int GetStamina(){
        return Stamina;
    }
    public void SetInitialStamina(){
        int initialStamina = 100;
        int superPowerCount = 0;
        for(SuperPower sp:SuperPowers){
            superPowerCount++;
            initialStamina =- sp.Strength * superPowerCount;
        }
        Stamina = initialStamina;
    }
    public String GetSecretName(){
        return SecretName;
    }
}