package JavaProject.Entities;

public class UltraSuperPower extends SuperPower {

    public UltraSuperPower(){
    }

    public UltraSuperPower(SuperPower superPower){
        Name = superPower.Name;
        Description = superPower.Description;
        Strength = superPower.Strength;
        Cost = superPower.Cost;
        AlreadyUsed = false;
    }

    public Boolean AlreadyUsed;

}