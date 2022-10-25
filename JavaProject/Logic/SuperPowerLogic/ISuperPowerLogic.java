package JavaProject.Logic.SuperPowerLogic;
import JavaProject.Entities.SuperPower;

public interface ISuperPowerLogic {

    public boolean ValidateSuperPower(SuperPower superPower);
    public int InsertSuperPower(SuperPower superPower);
    public int UpdateSuperPower(SuperPower superPower);
    public int DeleteSuperPower(SuperPower superPower);
    
}
