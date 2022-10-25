package JavaProject.Logic.SuperCharacterLogic;
import JavaProject.Entities.SuperCharacter;

public interface ISuperCharacterLogic {

    public boolean ValidateSuperCharacter(SuperCharacter superCharacter);
    public int InsertSuperCharacter(SuperCharacter superCharacter);
    public int UpdateSuperCharacter(SuperCharacter superCharacter);
    public int DeleteSuperCharacter(SuperCharacter superCharacter);
    
}