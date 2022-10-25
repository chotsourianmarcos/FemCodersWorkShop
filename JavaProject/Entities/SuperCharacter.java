package JavaProject.Entities;
import java.util.ArrayList;
import java.util.UUID;
import java.util.Date;

public class SuperCharacter {

    public SuperCharacter(String secretName){
        SecretName = secretName;
    }

    public int Id;
    public UUID IdWeb;
    public Date CreationDate;
    public Date UpdateDate;
    public Date DeleteDate;

    public String PublicName;
    private String SecretName;
    public Boolean Alignment;
    public ArrayList<SuperPower> SuperPowers = new ArrayList<SuperPower>();
    public UltraSuperPower ultraSuperPower;
    private int Stamina;
    public String Destiny;
    public String SecretWeakness;

    public int GetStamina(){
        return Stamina;
    }

    public void SetInitialStamina(){
        int initialStamina = 100;
        int powerCount = 1;
        if(SuperPowers.size() > 0){
            for(SuperPower sp:SuperPowers){
                initialStamina -= sp.Strength * powerCount;
                powerCount++;
            }
        }
        if(ultraSuperPower != null){
            initialStamina -= ultraSuperPower.Strength * powerCount * 5;
        }
        Stamina = initialStamina;
    }

    public String GetSecretName(){
        return SecretName;
    }
}